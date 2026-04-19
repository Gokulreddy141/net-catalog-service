using CatalogService.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infrastructure.Data;

public class CatalogDbContext : DbContext
{
    public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    // ADD THIS BLOCK TO SEED DATA
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = Guid.NewGuid(), Name = "Mechanical Keyboard", Price = 120.50m, StockQuantity = 15 },
            new Product { Id = Guid.NewGuid(), Name = "Wireless Mouse", Price = 45.99m, StockQuantity = 30 }
        );
    }
}