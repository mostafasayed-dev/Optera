using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optera.Configuration.Models;
using Optera.Shared.Core.Domain;

namespace Optera.Configuration.Configuration
{
    public class DataTableColumnConfig : BaseModelConfig<DataTableColumn>
    {
        public override void Configure(EntityTypeBuilder<DataTableColumn> builder)
        {
            base.Configure(builder);

            builder.Ignore(p => p.Creator);
            builder.Ignore(p => p.Updater);
            builder.Ignore(p => p.CreatedAt);
            builder.Ignore(p => p.UpdatedAt);
            builder.Ignore(p => p.Status);
        }
    }
}
