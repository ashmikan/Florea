using Microsoft.EntityFrameworkCore;
using Floréa.Models;

namespace Floréa.Data
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