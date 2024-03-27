using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkPractice.OwnedEntityType.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;

namespace EntityFrameworkPractice.OwnedEntityType.DataAccess;
public class OwnedEntityDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Initializer.Build();
        optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon2"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().OwnsOne(p => p.Person, p =>
        {
            p.Property(x => x.FirstName).HasColumnName("FirstName");
            p.Property(x => x.LastName).HasColumnName("LastName");
            p.Property(x => x.Email).HasColumnName("Email");
            p.Property(x => x.Phone).HasColumnName("Phone");
        });
        modelBuilder.Entity<Customer>().OwnsOne(p => p.Person, p =>
        {
            p.Property(x => x.FirstName).HasColumnName("FirstName");
            p.Property(x => x.LastName).HasColumnName("LastName");
            p.Property(x => x.Email).HasColumnName("Email");
            p.Property(x => x.Phone).HasColumnName("Phone");
        });
        modelBuilder.Entity<Employee>().Property(p => p.Salary).HasPrecision(9, 2);
        modelBuilder.Entity<Customer>().Property(p => p.Balance).HasPrecision(9, 2);
        base.OnModelCreating(modelBuilder);
    }
}
