using Microsoft.EntityFrameworkCore;
using MouseTracker.Data.Models;

namespace MouseTracker.Data
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