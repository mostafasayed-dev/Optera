using MassTransit;
using Optera.Query.Models;
using Optera.Query.Services.Interfaces;
using Optera.Shared.Messaging.Events.Users;

namespace Optera.Query.Consumers
{
    public class UserRegisteredConsumer : IConsumer<UserRegistered>
    {
        private readonly IUserService userService;

        public UserRegisteredConsumer(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task Consume(ConsumeContext<UserRegistered> context)
        {
            var @event = context.Message;

            var user = new User
            {
                //Id = @event.Id,
                UserName = @event.UserName,
                NormalizedUserName = @event.NormalizedUserName,
                Email = @event.Email,
                NormalizedEmail = @event.NormalizedEmail,
                EmailConfirmed = @event.EmailConfirmed,
                PhoneNumber = @event.PhoneNumber,
                PhoneNumberConfirmed = @event.PhoneNumberConfirmed,
                Creator = @event.Username,
                Updater = @event.Username,
            };

            await userService.CreateUser(user);
        }
    }
}
