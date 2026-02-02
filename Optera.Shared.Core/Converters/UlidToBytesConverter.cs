using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optera.Shared.Core.Converters
{
    public class UlidToBytesConverter : ValueConverter<Ulid, byte[]>
    {
        public UlidToBytesConverter()
        : base(
            ulid => ulid.ToByteArray(),
            bytes => Ulid.Parse(bytes))
        {
        }
    }
}
