using LojaOnline.OrderApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaOnline.OrderApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Order> Orders { get; set; }
    }
}
