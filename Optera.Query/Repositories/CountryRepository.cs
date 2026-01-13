using Optera.Query.Models;
using Optera.Query.Repositories.Base;
using Optera.Query.Repositories.Interfaces;

namespace Optera.Query.Repositories
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
