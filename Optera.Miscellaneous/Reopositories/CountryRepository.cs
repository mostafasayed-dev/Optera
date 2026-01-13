using Optera.Miscellaneous.Models;
using Optera.Miscellaneous.Reopositories.Base;
using Optera.Miscellaneous.Reopositories.Interfaces;
using Optera.Shared.Identity;

namespace Optera.Miscellaneous.Reopositories
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(AppDbContext appDbContext, ICurrentUserContext currentUserContext) 
            : base(appDbContext, currentUserContext)
        {
        }
    }
}
