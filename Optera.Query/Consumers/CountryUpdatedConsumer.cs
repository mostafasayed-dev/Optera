using MassTransit;
using Optera.Query.Repositories.Interfaces;
using Optera.Shared.Messaging.Events.Miscellaneous;

namespace Optera.Query.Consumers
{
    public class CountryUpdatedConsumer : IConsumer<CountryUpdated>
    {
        private readonly ICountryRepository countryRepository;

        public CountryUpdatedConsumer(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        public async Task Consume(ConsumeContext<CountryUpdated> context)
        {
            var @event = context.Message;

            var country = await countryRepository.GetByIdAsync(@event.Id);

            if(country != null)
            {
                country.Name = @event.Name;
                country.Name_OtherLanguage = @event.Name_OtherLanguage;
                country.ISOCode = @event.ISOCode;
                country.Updater = @event.Username;

                countryRepository.Update(country);
                await countryRepository.SaveChangesAsync();
            }
        }
    }
}
