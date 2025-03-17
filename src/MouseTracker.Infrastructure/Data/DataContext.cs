using Microsoft.EntityFrameworkCore;
using MouseTracker.Domain.Entities;

namespace MouseTracker.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<MouseMovement> MouseMovements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MouseMovement>()
                .Property(m => m.Id)
                .ValueGeneratedOnAdd();
        }
    }
}