using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optera.Configuration.Models;
using Optera.Shared.Domain;

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

            //countries-list
            builder.HasData(
                new DataTableColumn { Id = DataTableColumnSeedIds.CountriesList_Id, DataTableId = DataTableSeedIds.CountriesList, Name = "id", Text = "ID", Sortable = true, Visible = false, Order = 0 },
                new DataTableColumn { Id = DataTableColumnSeedIds.CountriesList_Name, DataTableId = DataTableSeedIds.CountriesList, Name = "name", Text = "Country Name", Sortable = true, Visible = true, Order = 1 },
                new DataTableColumn { Id = DataTableColumnSeedIds.CountriesList_Name_OtherLanguage, DataTableId = DataTableSeedIds.CountriesList, Name = "name_OtherLanguage", Text = "Country Name (Other)", Sortable = true, Visible = true, Order = 2 },
                new DataTableColumn { Id = DataTableColumnSeedIds.CountriesList_ISOCode, DataTableId = DataTableSeedIds.CountriesList, Name = "isoCode", Text = "ISO Code", Sortable = true, Visible = true, Order = 3 },
                new DataTableColumn { Id = DataTableColumnSeedIds.CountriesList_Creator, DataTableId = DataTableSeedIds.CountriesList, Name = "creator", Text = "Created By", Sortable = true, Visible = true, Order = 4 },
                new DataTableColumn { Id = DataTableColumnSeedIds.CountriesList_Updater, DataTableId = DataTableSeedIds.CountriesList, Name = "updater", Text = "Modified By", Sortable = true, Visible = true, Order = 5 },
                new DataTableColumn { Id = DataTableColumnSeedIds.CountriesList_CreatedAt, DataTableId = DataTableSeedIds.CountriesList, Name = "createdAt", Text = "Created At", Sortable = true, Visible = true, Order = 6 },
                new DataTableColumn { Id = DataTableColumnSeedIds.CountriesList_UpdatedAt, DataTableId = DataTableSeedIds.CountriesList, Name = "updatedAt", Text = "Modified At", Sortable = true, Visible = true, Order = 7 },
                new DataTableColumn { Id = DataTableColumnSeedIds.CountriesList_Status, DataTableId = DataTableSeedIds.CountriesList, Name = "status", Text = "Status", Sortable = true, Visible = true, Order = 8 }
                );
        }
    }

    public static class DataTableColumnSeedIds
    {
        public static readonly Guid CountriesList_Id =
            new("00000000-0000-0000-0000-000000000001");
        public static readonly Guid CountriesList_Name =
            new("00000000-0000-0000-0000-000000000002");
        public static readonly Guid CountriesList_Name_OtherLanguage =
            new("00000000-0000-0000-0000-000000000003");
        public static readonly Guid CountriesList_ISOCode =
            new("00000000-0000-0000-0000-000000000004");
        public static readonly Guid CountriesList_Creator =
            new("00000000-0000-0000-0000-000000000005");
        public static readonly Guid CountriesList_Updater =
            new("00000000-0000-0000-0000-000000000006");
        public static readonly Guid CountriesList_CreatedAt =
            new("00000000-0000-0000-0000-000000000007");
        public static readonly Guid CountriesList_UpdatedAt =
            new("00000000-0000-0000-0000-000000000008");
        public static readonly Guid CountriesList_Status =
            new("00000000-0000-0000-0000-000000000009");
    }
}
