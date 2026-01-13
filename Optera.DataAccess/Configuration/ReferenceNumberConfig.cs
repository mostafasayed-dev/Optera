using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optera.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.DataAccess.Configuration
{
    public class ReferenceNumberConfig : IEntityTypeConfiguration<ReferenceNumber>
    {
        public void Configure(EntityTypeBuilder<ReferenceNumber> builder)
        {
            builder.Ignore(p => p.CreatedAt);
            builder.Ignore(p => p.Creator);
            builder.Ignore(p => p.UpdatedAt);
            builder.Ignore(p => p.Updator);
            builder.Ignore(p => p.Status);
            builder.Property(p => p.LastSequence).HasDefaultValue(0);

            builder.HasData(new ReferenceNumber { 
                Id = 1,
                Prefix = "CUS",
                Segment1 = "000000",
                Segment1_Format = "Sequence",
                LastSequence = 0
            });
            builder.HasData(new ReferenceNumber
            {
                Id = 2,
                Prefix = "QUT",
                Segment1 = "00",
                Segment2 = "yyMMdd",
                Segment2_Format = "Date",
                Segment3 = "000000",
                Segment3_Format = "Sequence",
                LastSequence = 0
            });
        }
    }
}
