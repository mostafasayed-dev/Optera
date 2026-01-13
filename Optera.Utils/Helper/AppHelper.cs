using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Optera.Utils.Helper
{
    public static class AppHelper
    {
        private static readonly string KeyBase64 = "NdK/c7XebedbblX8dc7zK87YcR3V+tuG+ufnE+VCyb4=";
        private static readonly string IvBase64 = "O5vsFWCB5ObOwMLu8Yr5qA==";

        public static string Decrypt(string encryptedBase64)
        {
            var key = Convert.FromBase64String(KeyBase64);
            var iv = Convert.FromBase64String(IvBase64);

            // The encryptedBase64 might be URL-encoded — decode first
            if (!IsValidBase64(encryptedBase64))
                return "-1";
            var encryptedBytes = Convert.FromBase64String(Uri.UnescapeDataString(encryptedBase64));

            using var aes = Aes.Create();
            aes.Key = key;
            aes.IV = iv;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            using var decryptor = aes.CreateDecryptor();
            using var ms = new MemoryStream(encryptedBytes);
            using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using var reader = new StreamReader(cs, Encoding.UTF8);
            return reader.ReadToEnd();
        }

        private static bool IsValidBase64(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            // Remove URL encoding artifacts (optional)
            input = Uri.UnescapeDataString(input);

            // Must be divisible by 4 and only contain valid chars
            if (input.Length % 4 != 0)
                return false;

            try
            {
                // This will throw if it's not valid base64
                Convert.FromBase64String(input);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
