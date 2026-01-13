using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optera.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace Optera.DataAccess.Configuration
{
    public class WorkflowInstanceConfig : IEntityTypeConfiguration<WorkflowInstance>
    {
        public void Configure(EntityTypeBuilder<WorkflowInstance> builder)
        {
            builder.HasOne(i => i.CurrentStep)
                .WithMany(s => s.WorkflowInstances)
                .HasForeignKey(i => i.CurrentStepId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
