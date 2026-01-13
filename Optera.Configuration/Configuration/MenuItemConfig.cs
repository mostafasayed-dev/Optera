using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optera.Configuration.Models;
using Optera.Shared.Domain;

namespace Optera.Configuration.Configuration
{
    public class MenuItemConfig : BaseModelConfig<MenuItem>
    {
        public override void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            base.Configure(builder);
            
            builder.Ignore(p => p.Creator);
            builder.Ignore(p => p.Updater);
            builder.Ignore(p => p.CreatedAt);
            builder.Ignore(p => p.UpdatedAt);
            builder.Ignore(p => p.Status);

            builder.HasMany(m => m.Children)
                .WithOne(m => m.Parent)
                .HasForeignKey(m => m.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

            //Home
            builder.HasData(new MenuItem { Id = MenuItemSeedIds.Home, Title = "Home", Icon = "eva home-outline", Link = "/pages/dashboard", Home = true, Order = 0 });
            //Miscellaneous
            builder.HasData(new MenuItem { Id = MenuItemSeedIds.Miscellaneous, Title = "Miscellaneous", Icon = "eva options-2-outline", Data = "AUTH_1000", Order = 0 });
            //Countries
            builder.HasData(new MenuItem { Id = MenuItemSeedIds.Countries, Title = "Countries", Icon = "eva globe-outline", Data = "AUTH_1010", Link = "/pages/miscellaneous/countries", ParentId = MenuItemSeedIds.Miscellaneous, Order = 10 });
            //Cities
            builder.HasData(new MenuItem { Id = MenuItemSeedIds.Cities, Title = "Cities", Icon = "eva home-outline", Data = "AUTH_1020", Link = "/pages/miscellaneous/cities", ParentId = MenuItemSeedIds.Miscellaneous, Order = 20 });
            //Regions
            builder.HasData(new MenuItem { Id = MenuItemSeedIds.Regions, Title = "Regions", Icon = "eva map-outline", Data = "AUTH_1030", Link = "/pages/miscellaneous/regions", ParentId = MenuItemSeedIds.Miscellaneous, Order = 30 });
        }
    }

    public static class MenuItemSeedIds
    {
        // Home
        public static readonly Guid Home =
            new("00000000-0000-0000-0000-000000000001");

        // Miscellaneous
        public static readonly Guid Miscellaneous =
            new("00000000-0000-0000-0000-000000000002");

        public static readonly Guid Countries =
            new("00000000-0000-0000-0000-000000000003");

        public static readonly Guid Cities =
            new("00000000-0000-0000-0000-000000000004");

        public static readonly Guid Regions =
            new("00000000-0000-0000-0000-000000000005");
    }
}
