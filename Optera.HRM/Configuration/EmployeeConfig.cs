using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optera.HRM.Models;
using Optera.Shared.Core.Domain;

namespace Optera.HRM.Configuration
{
    public class EmployeeConfig : BaseModelConfig<Employee>
    {
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            base.Configure(builder);
        }
    }
}
