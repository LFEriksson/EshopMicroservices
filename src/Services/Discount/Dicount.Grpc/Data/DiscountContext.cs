using Dicount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace Dicount.Grpc.Data;

public class DiscountContext : DbContext
{

    public DiscountContext(DbContextOptions<DiscountContext> options)
       : base(options)
    {
    }
    public DbSet<Coupon> Coupons { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coupon>().HasData(
            new Coupon { Id = 1, ProductName = "Product 1", Description = "Product 1 Discount", DicountAmount = 10 },
            new Coupon { Id = 2, ProductName = "Product 2", Description = "Product 2 Discount", DicountAmount = 20 });
    }
}
