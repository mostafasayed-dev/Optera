using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Infrastructure.Services
{
    public interface IEmailService
    {
        public void SendNewAccountConfirmationEmail(string toEmail, string employeeName, string username, string url);
    }
}
