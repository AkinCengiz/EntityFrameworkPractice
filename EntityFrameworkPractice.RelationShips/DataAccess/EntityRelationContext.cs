using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkPractice.RelationShips.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EntityFrameworkPractice.RelationShips.DataAccess;
public class EntityRelationContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Initializer.Build();
        //optionsBuilder.UseSqlServer(
        //    @"Data Source=AKINCENGIZ;initial catalog=EntityRelationshipDb;Integrated Security=True;Trust Server Certificate=True;");
        optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductFeature> ProductFeatures { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasOne(p => p.ProductFeature).WithOne(p => p.Product)
            .HasForeignKey<ProductFeature>(p => p.Id);
        modelBuilder.Entity<Product>().Property(x => x.TotalPrice).HasComputedColumnSql("[Price]*[Tax]+[Price]");
        //modelBuilder.Entity<Category>().HasMany(p => p.Products).WithOne(p => p.Category)
        //    .HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.SetNull);
        //modelBuilder.Entity<Category>().HasMany(x => x.Products).WithOne(x => x.Category)
        //    .HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Cascade);
        //modelBuilder.Entity<Category>().HasMany(c => c.Products).WithOne(p => p.Category)
        //    .HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.Restrict);
        //modelBuilder.Entity<Student>().HasMany(s => s.Teachers).WithMany(t => t.Students)
        //    .UsingEntity<Dictionary<string, object>>("StudentTeachers",
        //        st => st.HasOne<Teacher>().WithMany().HasForeignKey("TeacherId").HasConstraintName("FK_TeacherId"),
        //        st => st.HasOne<Student>().WithMany().HasForeignKey("StudentId").HasConstraintName("FK_StudentId"));
        base.OnModelCreating(modelBuilder);
    }
}
