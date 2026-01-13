using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optera.Configuration.Models;
using Optera.Shared.Domain;

namespace Optera.Configuration.Configuration
{
    public class DataTableConfig : BaseModelConfig<DataTable>
    {
        public override void Configure(EntityTypeBuilder<DataTable> builder)
        {
            base.Configure(builder);

            builder.Ignore(p => p.Creator);
            builder.Ignore(p => p.Updater);
            builder.Ignore(p => p.CreatedAt);
            builder.Ignore(p => p.UpdatedAt);
            builder.Ignore(p => p.Status);

            builder.Property(p => p.ItemsPerPage).HasDefaultValue(10);

            builder.HasData(
                new DataTable { Id = DataTableSeedIds.CountriesList, Name = "countries-list", Title = "Countries" }
                );
        }
    }

    public static class DataTableSeedIds
    {
        // Home
        public static readonly Guid CountriesList =
            new("00000000-0000-0000-0000-000000000001");
    }
}
