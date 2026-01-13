using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optera.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.DataAccess.Configuration
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(new Role { Id = 1, Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = "a1111111-a222-a333-a444-a55555555555" });
            //    new Role { Id = 2, Name = "CEO", NormalizedName = "CEO", ConcurrencyStamp = "a1111111-a222-a333-a444-a44444444444" },
            //    new Role { Id = 3, Name = "Sales Coordinator", NormalizedName = "SALES COORDINATOR", ConcurrencyStamp = "a1111111-a222-a333-a444-a33333333333" },
            //    new Role { Id = 4, Name = "Sales Executive", NormalizedName = "SALES EXECUTIVE", ConcurrencyStamp = "a1111111-a222-a333-a444-a22222222222" }
            //    );
        }
    }
}
