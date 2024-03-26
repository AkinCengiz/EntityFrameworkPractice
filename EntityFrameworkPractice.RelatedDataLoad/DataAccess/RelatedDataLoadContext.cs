using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkPractice.RelatedDataLoad.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EntityFrameworkPractice.RelatedDataLoad.DataAccess;
public class RelatedDataLoadContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Initializer.Build();
        optionsBuilder.UseLazyLoadingProxies().UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon2"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasOne(c => c.Category).WithMany(p => p.Products)
            .HasForeignKey(p => p.CategoryId);
        modelBuilder.Entity<Product>().HasOne(p => p.ProductFeature).WithOne(p => p.Product)
            .HasForeignKey<ProductFeature>(p => p.Id);
        modelBuilder.Entity<Product>().Property(p => p.Price).HasPrecision(9, 2);
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductFeature> ProductFeatures { get; set; }
}
