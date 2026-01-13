using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optera.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optera.DataAccess.Configuration
{
    public class WorkflowStepConfig : IEntityTypeConfiguration<WorkflowStep>
    {
        public void Configure(EntityTypeBuilder<WorkflowStep> builder)
        {
            //builder.HasData(new WorkflowStep
            //{
            //    Id = 1,
            //    WorkflowDefinitionId = 1,
            //    Name = "Quotation Submitted",
            //    Order = 1,
            //    IsFinal = false,
            //    CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            //    UpdatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            //});
            //builder.HasData(new WorkflowStep
            //{
            //    Id = 2,
            //    WorkflowDefinitionId = 1,
            //    Name = "Quotation Review",
            //    Order = 2,
            //    IsFinal = false,
            //    CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            //    UpdatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            //});
            //builder.HasData(new WorkflowStep
            //{
            //    Id = 3,
            //    WorkflowDefinitionId = 1,
            //    Name = "Quotation Approval",
            //    Order = 3,
            //    IsFinal = false,
            //    CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            //    UpdatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            //});
            //builder.HasData(new WorkflowStep
            //{
            //    Id = 4,
            //    WorkflowDefinitionId = 1,
            //    Name = "Approved",
            //    Order = 4,
            //    IsFinal = true,
            //    CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            //    UpdatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            //});
            //builder.HasData(new WorkflowStep
            //{
            //    Id = 5,
            //    WorkflowDefinitionId = 1,
            //    Name = "Rejected",
            //    Order = 5,
            //    IsFinal = true,
            //    CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            //    UpdatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            //});
        }
    }
}
