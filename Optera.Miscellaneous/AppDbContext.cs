using MassTransit;
using Microsoft.EntityFrameworkCore;
using Optera.Miscellaneous.Models;
using System.Reflection;

namespace Optera.Miscellaneous
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Country> Countries { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // apply all configration classes that implements IEntityTypeConfiguration in current assembly
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.AddTransactionalOutboxEntities();
        }
    }
}
