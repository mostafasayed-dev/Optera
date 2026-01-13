using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optera.Miscellaneous.Models.Base;

namespace Optera.Miscellaneous.Configurations.Base
{
    public class BaseModelConfig<T> : IEntityTypeConfiguration<T>
    where T : BaseModel
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(e => e.Id)
                   .ValueGeneratedOnAdd()
                   .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder.Property(p => p.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()")
                   .ValueGeneratedOnAdd()
                   .IsRequired();

            builder.Property(p => p.UpdatedAt)
                   .IsRequired();

            builder.Property(p => p.Creator)
                   .IsRequired(false);

            builder.Property(p => p.Updater)
                   .IsRequired(false);

            builder.Property(p => p.Status)
                   .HasDefaultValue("Active")
                   .IsRequired();

            builder.Property(e => e.RowVersion)
                   .IsRowVersion()
                   .IsConcurrencyToken();
        }
    }
}
