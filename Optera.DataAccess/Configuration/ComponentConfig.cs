using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optera.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.DataAccess.Configuration
{
    public class ComponentConfig : IEntityTypeConfiguration<Component>
    {
        public void Configure(EntityTypeBuilder<Component> builder)
        {
            builder.Ignore(p => p.CreatedAt);
            builder.Ignore(p => p.Creator);
            builder.Ignore(p => p.UpdatedAt);
            builder.Ignore(p => p.Updator);
            builder.Ignore(p => p.Status);

            builder.HasData(new Component { Id = 1, Name = "QuotationEditComponent", Title = "Add/ Edit Quotation Request" });
        }
    }
}
