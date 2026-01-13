using Microsoft.EntityFrameworkCore;
using Optera.Configuration.Models;
using System.Data;
using System.Diagnostics.Metrics;
using System.Reflection;

namespace Optera.Configuration
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Models.DataTable> DataTables { get; set; }
        public DbSet<DataTableColumn> DataTableColumns { get; set; }
        //public DbSet<Component> Components { get; set; }
        //public DbSet<ComponentForm> ComponentForms { get; set; }
        //public DbSet<ComponentFormControl> ComponentFormControls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // apply all configration classes that implements IEntityTypeConfiguration in current assembly
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
