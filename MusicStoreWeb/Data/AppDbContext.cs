using Microsoft.EntityFrameworkCore;
using MusicStoreWeb.Models;

namespace MusicStoreWeb.Data
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Category>? Categories { get; set; } 
        public DbSet<CoverType>? CoverTypes { get; set;}
        public DbSet<Band>? Bands { get; set; }
        public DbSet<BandMember>? BandMembers { get; set; }
        public DbSet<Product>? Products { get; set; }
    }
}
