using Microsoft.EntityFrameworkCore;
using FlowerShopAPI.Models;

namespace FlowerShopAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Flower> Flowers { get; set; }
    }
}
