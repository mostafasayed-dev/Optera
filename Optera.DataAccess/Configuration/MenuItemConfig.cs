using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optera.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace Optera.DataAccess.Configuration
{
    public class MenuItemConfig : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.Ignore(p => p.CreatedAt);
            builder.Ignore(p => p.UpdatedAt);
            builder.Ignore(p => p.Creator);
            builder.Ignore(p => p.Updator);
            builder.Ignore(p => p.Status);

            builder.HasMany(m => m.Children)
                    .WithOne(m => m.Parent)
                    .HasForeignKey(m => m.ParentId)
                    .OnDelete(DeleteBehavior.Restrict);
            //Home
            builder.HasData(new MenuItem { Id = 1, Title = "Home", Icon = "home-outline", Link = "/pages/dashboard", Home = true, Order = 0 });
            //Settings
            builder.HasData(new MenuItem { Id = 2, Title = "Miscellaneous", Icon = "eva options-2-outline", Data = "AUTH_1000", Order = 0 });
            builder.HasData(new MenuItem { Id = 3, Title = "Countries", Icon = "eva globe-outline", Data = "AUTH_1010", Link = "/pages/miscellaneous/countries", ParentId = 2, Order = 10 });
            builder.HasData(new MenuItem { Id = 4, Title = "Cities", Icon = "eva home-outline", Data = "AUTH_1020", Link = "/pages/miscellaneous/cities", ParentId = 2, Order = 20 });
            builder.HasData(new MenuItem { Id = 5, Title = "Regions", Icon = "eva map-outline", Data = "AUTH_1030", Link = "/pages/miscellaneous/regions", ParentId = 2, Order = 30 });
            builder.HasData(new MenuItem { Id = 6, Title = "Categories", Icon = "eva pricetags-outline", Data = "AUTH_1040", Link = "/pages/miscellaneous/categories", ParentId = 2, Order = 40 });
            //Business Process
            builder.HasData(new MenuItem { Id = 7, Title = "Business Process", Icon = "eva flip-2-outline", Data = "AUTH_2000", Order = 0 });
            builder.HasData(new MenuItem { Id = 8, Title = "Quotation Request", Icon = "eva file-add-outline", Data = "AUTH_2010", Link = "/pages/business-process/quotations", ParentId = 7, Order = 10 });
            builder.HasData(new MenuItem { Id = 9, Title = "Contract Request", Icon = "eva edit-2-outline", Data = "AUTH_2020", Link = "/pages/business-process/contracts", ParentId = 7, Order = 20 });
            // Admin
            builder.HasData(new MenuItem { Id = 10, Title = "Administration", Icon = "eva keypad-outline", Data = "AUTH_3000", Order = 0 });
            builder.HasData(new MenuItem { Id = 11, Title = "Security", Icon = "eva shield-outline", Data = "AUTH_3010", Order = 10, ParentId = 10 });
            builder.HasData(new MenuItem { Id = 12, Title = "Groups", Icon = "eva people-outline", Data = "AUTH_3020", Link = "/pages/admin/groups", ParentId = 11, Order = 20 });
            builder.HasData(new MenuItem { Id = 13, Title = "Users", Icon = "eva person-outline", Data = "AUTH_3030", Link = "/pages/admin/users", ParentId = 11, Order = 30 });
            builder.HasData(new MenuItem { Id = 14, Title = "Settings", Icon = "eva settings-2-outline", Data = "AUTH_3040", ParentId = 10, Order = 40 });
            builder.HasData(new MenuItem { Id = 15, Title = "Workflow Definition", Icon = "eva flip-2-outline", Data = "AUTH_3050", Link = "/pages/admin/settings/workflow-definition", ParentId = 14, Order = 50 });
        }
    }
}
