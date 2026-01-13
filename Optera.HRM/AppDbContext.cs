using MassTransit;
using Microsoft.EntityFrameworkCore;
using Optera.HRM.Models;
using System.ComponentModel;
using System.Reflection;

namespace Optera.HRM
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // apply all configration classes that implements IEntityTypeConfiguration in current assembly
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.AddTransactionalOutboxEntities();
        }
    }
}
