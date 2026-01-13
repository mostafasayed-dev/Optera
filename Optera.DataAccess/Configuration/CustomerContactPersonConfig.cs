using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optera.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.DataAccess.Configuration
{
    public class CustomerContactPersonConfig : IEntityTypeConfiguration<CustomerContactPerson>
    {
        public void Configure(EntityTypeBuilder<CustomerContactPerson> builder)
        {
            builder.HasOne(e => e.Position)
                .WithMany()
                .HasForeignKey(e => e.PositionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
