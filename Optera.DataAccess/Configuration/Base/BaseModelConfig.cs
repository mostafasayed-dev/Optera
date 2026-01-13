using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optera.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.DataAccess.Configuration.Base
{
    public abstract class BaseModelConfig<TModel> : IEntityTypeConfiguration<TModel>
        where TModel : BaseModel
    {
        public virtual void Configure(EntityTypeBuilder<TModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Status)
                   .HasDefaultValue("Active")
                   .IsRequired();

            builder.Property(p => p.CreatedAt)
                   .HasDefaultValueSql("getdate()")
                   .ValueGeneratedOnAdd()
                   .IsRequired();

            builder.Property(p => p.UpdatedAt)
                   .HasDefaultValueSql("getdate()")
                   .IsRequired();

            builder.Property(p => p.Creator)
                   .HasDefaultValue("System")
                   .IsRequired();

            builder.Property(p => p.Updator)
                   .HasDefaultValue("System")
                   .IsRequired();

        }
    }
}
