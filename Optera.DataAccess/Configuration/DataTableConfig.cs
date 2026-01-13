using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optera.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.DataAccess.Configuration
{
    public class DataTableConfig : IEntityTypeConfiguration<DataTable>
    {
        public void Configure(EntityTypeBuilder<DataTable> builder)
        {
            builder.Ignore(p => p.Status);
            builder.Ignore(p => p.CreatedAt);
            builder.Ignore(p => p.UpdatedAt);
            builder.Ignore(p => p.Creator);
            builder.Ignore(p => p.Updator);

            builder.Property(p => p.ItemsPerPage).HasDefaultValue(10);

            builder.HasData(
                new DataTable { Id = 1, Name = "countries-list", Title = "Countries" },
                new DataTable { Id = 2, Name = "cities-list", Title = "Cities" },
                new DataTable { Id = 3, Name = "regions-list", Title = "Regions" },
                new DataTable { Id = 4, Name = "categories-list", Title = "Categories" },
                new DataTable { Id = 5, Name = "categories-items-list", Title = "Category Items" },
                new DataTable { Id = 6, Name = "quotations-list", Title = "Quotations" },
                new DataTable { Id = 7, Name = "groups-list", Title = "Groups" },
                new DataTable { Id = 8, Name = "users-list", Title = "Users" },
                new DataTable { Id = 9, Name = "workflow-definitions-list", Title = "Workflow Definitions" },
                new DataTable { Id = 10, Name = "workflow-steps-list", Title = "Workflow Steps" },
                new DataTable { Id = 11, Name = "workflow-transitions-list", Title = "Workflow Transitions" }
                );
        }
    }
}
