using MassTransit;
using Optera.Query.Models;
using Optera.Query.Repositories.Interfaces;
using Optera.Shared.Messaging.Events.Miscellaneous;

namespace Optera.Query.Consumers
{
    public class CountryCreatedConsumer : IConsumer<CountryCreated>
    {
        private readonly ICountryRepository countryRepository;

        public CountryCreatedConsumer(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        public async Task Consume(ConsumeContext<CountryCreated> context)
        {
            var @event = context.Message;

            var country = new Country
            {
                Id = @event.Id,
                Name = @event.Name,
                Name_OtherLanguage = @event.Name_OtherLanguage,
                ISOCode = @event.ISOCode,
                Creator = @event.Username,
                Updater = @event.Username,
            };

            await countryRepository.AddAsync(country);
            await countryRepository.SaveChangesAsync();
        }
    }
}
