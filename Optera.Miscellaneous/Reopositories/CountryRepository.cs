using Optera.Miscellaneous.Models;
using Optera.Miscellaneous.Reopositories.Interfaces;
using Optera.Shared.Core.Identity;
using Optera.Shared.Core.Repositories;
using Optera.Shared.Identity;

namespace Optera.Miscellaneous.Reopositories
{
    public class CountryRepository : BaseRepository<Country, AppDbContext>, ICountryRepository
    {
        public CountryRepository(AppDbContext appDbContext, ICurrentUserContext currentUserContext) 
            : base(appDbContext, currentUserContext)
        {
        }
    }
}
