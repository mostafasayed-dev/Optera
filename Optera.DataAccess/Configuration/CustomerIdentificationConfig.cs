using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optera.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.DataAccess.Configuration
{
    public class CustomerIdentificationConfig : IEntityTypeConfiguration<CustomerIdentification>
    {
        public void Configure(EntityTypeBuilder<CustomerIdentification> builder)
        {
            builder.HasOne(e => e.Country)
                .WithMany()
                .HasForeignKey(e => e.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.City)
                .WithMany()
                .HasForeignKey(e => e.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.IdentificationType)
                .WithMany()
                .HasForeignKey(e => e.IdentificationTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
