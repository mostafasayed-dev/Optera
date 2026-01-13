using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.Infrastructure.Services
{
    public interface ISMTPService
    {
        public void SendEmail(string toMail, string subject, string body);
    }
}
