using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optera.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace Optera.DataAccess.Configuration
{
    public class AuthorizationConfig : IEntityTypeConfiguration<Authorization>
    {
        public void Configure(EntityTypeBuilder<Authorization> builder)
        {
            builder.Ignore(p => p.CreatedAt);
            builder.Ignore(p => p.UpdatedAt);
            builder.Ignore(p => p.Creator);
            builder.Ignore(p => p.Updator);
            builder.Ignore(p => p.Status);

            builder.HasIndex(a => a.Code).IsUnique();

            builder.HasMany(m => m.Children)
                    .WithOne(m => m.Parent)
                    .HasForeignKey(m => m.ParentId)
                    .OnDelete(DeleteBehavior.Restrict);
            // Settings
            builder.HasData(new Authorization { Id = 1, Code = "AUTH_1000", Name = "Miscellaneous", Order = 0 });
            builder.HasData(new Authorization { Id = 2, Code = "AUTH_1010", Name = "Countries", Order = 10, ParentId = 1 });
            builder.HasData(new Authorization { Id = 3, Code = "AUTH_1020", Name = "Cities", Order = 20, ParentId = 1 });
            builder.HasData(new Authorization { Id = 4, Code = "AUTH_1030", Name = "Regions", Order = 30 , ParentId = 1 });
            builder.HasData(new Authorization { Id = 5, Code = "AUTH_1040", Name = "Categories", Order = 40 , ParentId = 1 });
            builder.HasData(new Authorization { Id = 6, Code = "AUTH_1041", Name = "Categories Items", Order = 41 , ParentId = 5 });
            // Business Process
            builder.HasData(new Authorization { Id = 7, Code = "AUTH_2000", Name = "Business Process", Order = 0 });
            builder.HasData(new Authorization { Id = 8, Code = "AUTH_2010", Name = "Quotation Request", Order = 10 , ParentId = 7 });
            builder.HasData(new Authorization { Id = 9, Code = "AUTH_2011", Name = "Add Quotation Request", Order = 11 , ParentId = 8 });
            builder.HasData(new Authorization { Id = 10, Code = "AUTH_2012", Name = "Edit Quotation Request", Order = 12 , ParentId = 8 });
            // Admin
            builder.HasData(new Authorization { Id = 11, Code = "AUTH_3000", Name = "Administration", Order = 0 });
            builder.HasData(new Authorization { Id = 12, Code = "AUTH_3010", Name = "Security", Order = 10, ParentId = 11 });
            builder.HasData(new Authorization { Id = 13, Code = "AUTH_3020", Name = "Groups", Order = 20, ParentId = 12 });
            builder.HasData(new Authorization { Id = 14, Code = "AUTH_3021", Name = "Add Group", Order = 21, ParentId = 13 });
            builder.HasData(new Authorization { Id = 15, Code = "AUTH_3030", Name = "Users", Order = 30, ParentId = 12 });
            builder.HasData(new Authorization { Id = 16, Code = "AUTH_3031", Name = "Add User", Order = 31, ParentId = 15 });
            builder.HasData(new Authorization { Id = 17, Code = "AUTH_3032", Name = "Edit User", Order = 32, ParentId = 15 });
            builder.HasData(new Authorization { Id = 18, Code = "AUTH_3040", Name = "Settings", Order = 40, ParentId = 11 });
            builder.HasData(new Authorization { Id = 19, Code = "AUTH_3050", Name = "Workflow Definition", Order = 50, ParentId = 18 });
            builder.HasData(new Authorization { Id = 20, Code = "AUTH_3060", Name = "Workflow Steps", Order = 60, ParentId = 18 });
            builder.HasData(new Authorization { Id = 21, Code = "AUTH_3070", Name = "Workflow Transitions", Order = 70, ParentId = 18 });
        }
    }
}
