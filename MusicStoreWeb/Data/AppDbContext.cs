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
        DbSet<Category>? Categories { get; set; } 
    }
}
