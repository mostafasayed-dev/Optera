using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optera.Miscellaneous.Models;
using Optera.Shared.Core.Domain;

namespace Optera.Miscellaneous.Configurations
{
    public class CountryConfig : BaseModelConfig<Country>
    {
        public override void Configure(EntityTypeBuilder<Country> builder)
        {
            base.Configure(builder);
        }
    }
}
