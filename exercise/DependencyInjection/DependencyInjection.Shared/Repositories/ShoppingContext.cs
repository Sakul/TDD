using DependencyInjection.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace DependencyInjection.Shared.Repositories
{
    public class ShoppingContext : DbContext
    {
        public DbSet<OrderInfo> Orders { get; set; }
        public DbSet<ProductInfo> Products { get; set; }

        public ShoppingContext(DbContextOptions<ShoppingContext> options)
            : base(options)
        {
        }
    }
}
