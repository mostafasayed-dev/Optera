using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optera.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.DataAccess.Configuration
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //builder.Property(p => p.Status)
            //       .HasDefaultValue("Active")
            //       .IsRequired();

            //builder.Property(p => p.CreatedAt)
            //       .HasDefaultValueSql("getdate()")
            //       .ValueGeneratedOnAdd()
            //       .IsRequired();

            //builder.Property(p => p.UpdatedAt)
            //       .HasDefaultValueSql("getdate()")
            //       .IsRequired();

            builder.HasOne(u => u.Employee)
                   .WithOne(e => e.User)
                   .HasForeignKey<Employee>(e => e.UserId);

        }
    }
}
