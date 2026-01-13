using Optera.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Services
{
    public class EmailService: IEmailService
    {
        private readonly ISMTPService sMTPService;

        public EmailService(ISMTPService sMTPService)
        {
            this.sMTPService = sMTPService;
        }

        public void SendNewAccountConfirmationEmail(string toEmail, string employeeName, string username, string url)
        {
            string subject = "Welcome to OPTERA! Your Account Has Been Created";
            string body = "<!DOCTYPE html>\r\n" +
            "<html>\r\n" +
            "<head>\r\n  <meta charset=\"UTF-8\">\r\n  <title>Account Created</title>\r\n</head>\r\n" +
            "<body style=\"font-family: Arial, sans-serif; line-height: 1.6; color: #333;\">\r\n" +
            "  <h2 style=\"color: #2c3e50;\">Welcome to OPTERA!</h2>\r\n" +
            "  <p>Hello " + employeeName + ",</p>\r\n" +
            "  <p>We are excited to inform you that your account has been successfully created.</p>\r\n" +
            "  <p><strong>Your account details:</strong></p>\r\n" +
            "  <ul>\r\n    <li>Username: " + username + "</li>\r\n  </ul>\r\n" +
            "  <p>You can now log in to your account using the link below:</p>\r\n" +
            "  <p>\r\n" +
            "    <a href=\"" + url + "\" style=\"display: inline-block; padding: 10px 20px; background-color: #007bff; color: white; text-decoration: none; border-radius: 4px;\">Log In</a>\r\n" +
            "  </p>\r\n" +
            "  <p>If you did not create this account, please ignore this email or contact our support.</p>\r\n" +
            "  <p>Thank you,<br>System Administrator</p>\r\n" +
            "  <hr style=\"border: none; border-top: 1px solid #ccc;\">\r\n" +
            "  <p style=\"font-size: 0.9em; color: #999;\">OPTERA, [Company Address or Website]</p>\r\n" +
            "</body>\r\n" +
            "</html>";

            sMTPService.SendEmail(toEmail, subject, body);
        }
    }
}
