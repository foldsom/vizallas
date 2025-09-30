using Microsoft.EntityFrameworkCore;
using vizallas.Models;

namespace vizallas.Data
{
    public class VizallasContext : DbContext
    {
        public VizallasContext(DbContextOptions<VizallasContext> options) : base(options) { }

        public DbSet<Vizallas> Vizallas { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)//xdd
        {
            modelBuilder.Entity<Vizallas>().ToTable("Vizallas");
        }
    }
}
