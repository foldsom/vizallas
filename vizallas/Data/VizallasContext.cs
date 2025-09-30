using Microsoft.EntityFrameworkCore;

namespace vizallas.Data
{
    public class VizallasContext : DbContext
    {
        public VizallasContext (DbContextOptions<VizallasContext> options)
            : base(options) { }
        public DbSet<vizallas.Models.Vizallas> Vizallas { get; set; } = default!;

    }
}
