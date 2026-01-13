namespace Optera.Notification.Services.Interfaces
{
    public interface ISMTPService
    {
        public Task SendEmail(string toMail, string subject, string body);
    }
}
