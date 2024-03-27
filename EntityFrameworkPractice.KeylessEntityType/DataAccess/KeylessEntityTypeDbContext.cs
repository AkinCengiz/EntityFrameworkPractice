using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkPractice.KeylessEntityType.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EntityFrameworkPractice.KeylessEntityType.DataAccess;
public class KeylessEntityTypeDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Initializer.Build();
        optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon2"));
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().Property(p => p.Price).HasPrecision(9, 2);
        modelBuilder.Entity<Category>().HasMany(c => c.Products).WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId);
        modelBuilder.Entity<Product>().HasOne(p => p.ProductFeature).WithOne(p => p.Product)
            .HasForeignKey<ProductFeature>(p => p.Id);
        modelBuilder.Entity<Product>().Property(p => p.Price).HasPrecision(9, 2);
        base.OnModelCreating(modelBuilder);
    }
}
