using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optera.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.DataAccess.Configuration
{
    public class QuotationConfig : IEntityTypeConfiguration<Quotation>
    {
        public void Configure(EntityTypeBuilder<Quotation> builder)
        {
            builder.HasOne(q => q.Employee)
                    .WithMany(e => e.Quotations)
                    .HasForeignKey(q => q.EmployeeId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(a => a.Code).IsUnique();
        }
    }
}
