namespace Optera.Notification.Services.Interfaces
{
    public interface IEmailService
    {
        public Task SendNewAccountConfirmationEmail(string toEmail, string employeeName, string username, string url);
    }
}
