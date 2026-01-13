using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optera.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.DataAccess.Configuration
{
    public class WorkflowDefinitionConfig : IEntityTypeConfiguration<WorkflowDefinition>
    {
        public void Configure(EntityTypeBuilder<WorkflowDefinition> builder)
        {
            builder.HasData(
                new WorkflowDefinition
                {
                    Id = 1,
                    Name = "Quotation Request Workflow",
                    CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    Creator = "System",
                    Updator = "System",
                });
        }
    }
}
