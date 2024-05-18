using Microsoft.EntityFrameworkCore;

namespace SportsStore.Web.Models;

public class ApplicationContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) 
    {        
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var products = SeedProductData.EnsurePopulated(); 

        modelBuilder.Entity<Product>().HasData(products);
        base.OnModelCreating(modelBuilder);
    }
}
