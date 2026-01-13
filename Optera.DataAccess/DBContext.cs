using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Optera.Models;
using System.Data;
using System.Reflection;

namespace Optera.DataAccess
{
    public class DBContext : IdentityDbContext<User, Role, int>
    {

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<ReferenceNumber> ReferenceNumbers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryItem> CategoryItems { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerIdentification> CustomerIdentifications { get; set; }
        public DbSet<CustomerContactPerson> CustomerContactPersons { get; set; }
        //public DbSet<Workflow> Workflow { get; set; }
        //public DbSet<WorkflowScenario> WorkflowScenarios { get; set; }
        public DbSet<Quotation> Quotations { get; set; }
        public DbSet<Models.DataTable> DataTables { get; set; }
        public DbSet<DataTableColumn> DataTableColumns { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Authorization> Authorizations { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<ComponentForm> ComponentForms { get; set; }
        public DbSet<ComponentFormControl> ComponentFormControls { get; set; }
        public DbSet<WorkflowDefinition> WorkflowDefinitions { get; set; }
        public DbSet<WorkflowStep> WorkflowSteps { get; set; }
        public DbSet<WorkflowTransition> WorkflowTransitions { get; set; }
        public DbSet<WorkflowInstance> WorkflowInstances { get; set; }

        public DBContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // apply all configration classes that implements IEntityTypeConfiguration in current assembly
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
