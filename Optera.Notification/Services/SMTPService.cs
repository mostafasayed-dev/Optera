using Optera.Notification.Services.Interfaces;
using System.Net;
using System.Net.Mail;

namespace Optera.Notification.Services
{
    public class SMTPService : ISMTPService
    {
        private readonly string _smtpServer;
        private readonly int _port;
        private readonly string _email;
        private readonly string _username;
        private readonly string _password;
        private readonly string _displayName;

        public SMTPService()
        {
            this._smtpServer = "smtp.gmail.com";
            this._port = 587;
            this._email = "glitterice.notification@gmail.com";
            this._username = "glitterice.notification@gmail.com";
            this._password = "twmh cqvl asin ueac";
            this._displayName = "OPTERA";
        }

        public async Task SendEmail(string toMail, string subject, string body)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(_email, _displayName);
                mail.To.Add(toMail);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                // Configure the SMTP client
                SmtpClient smtpClient = new SmtpClient(_smtpServer)
                {
                    Port = _port,
                    Credentials = new NetworkCredential(_username, _password),
                    EnableSsl = true
                };

                // Send the email
                await smtpClient.SendMailAsync(mail);
            }
        }
    }
}
