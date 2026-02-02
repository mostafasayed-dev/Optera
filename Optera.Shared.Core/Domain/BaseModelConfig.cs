using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optera.Shared.Core.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optera.Shared.Core.Domain
{
    public class BaseModelConfig<T> : IEntityTypeConfiguration<T>
    where T : BaseModel
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()")
                   .ValueGeneratedOnAdd()
                   .IsRequired();

            builder.Property(p => p.UpdatedAt)
                   .HasDefaultValueSql("GETUTCDATE()")
                   .ValueGeneratedOnAddOrUpdate()
                   .IsRequired();

            builder.Property(p => p.Creator)
                   .HasMaxLength(256)
                   .IsRequired(false);

            builder.Property(p => p.Updater)
                   .HasMaxLength(256)
                   .IsRequired(false);

            builder.Property(p => p.Status)
                   .HasMaxLength(50)
                   .HasDefaultValue("Active")
                   .IsRequired();

            builder.Property(e => e.RowVersion)
                   .IsRowVersion()
                   .IsConcurrencyToken()
                   .ValueGeneratedOnAddOrUpdate();

            builder.Property(x => x.RowKey)
                   .HasConversion<UlidToBytesConverter>()
                   .HasColumnType("varbinary(16)")
                   .ValueGeneratedNever();

            builder.HasIndex(x => x.CreatedAt);
            builder.HasIndex(x => x.Updater);
            builder.HasIndex(x => x.Creator);
            builder.HasIndex(x => x.RowKey).IsUnique();
        }
    }
}
