using MassTransit;
using Optera.Events;
using Optera.Notification.Services.Interfaces;

namespace Optera.Notification.Consumers
{
    public class UserEventsConsumer : IConsumer<UserRegisteredEvent>,
                                      IConsumer<UserLoggedInEvent>
    {
        private readonly IEmailService emailService;
        public UserEventsConsumer(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        public async Task Consume(ConsumeContext<UserRegisteredEvent> context)
        {
            var evt = context.Message;
            await emailService.SendNewAccountConfirmationEmail(evt.Email, "Mostafa Sayed", evt.UserName, "https://www.google.com/");
        }

        public async Task Consume(ConsumeContext<UserLoggedInEvent> context)
        {
            var evt = context.Message;
            await emailService.SendNewAccountConfirmationEmail(evt.Email, "Mostafa Sayed", evt.UserName, "https://www.google.com/");
        }
    }
}
