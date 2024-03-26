using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkPractice.Inheritance.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EntityFrameworkPractice.Inheritance.DataAccess;
public class InheritanceContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Initializer.Build();
        optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon2"));
    }

    public DbSet<Person> Persons { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Manager> Managers { get; set; }
    public DbSet<Animal> Animals { get; set; }
    public DbSet<Bird> Birds { get; set; }
    public DbSet<Mammal> Mammals { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Animal>().ToTable("Animals");
        modelBuilder.Entity<Mammal>().ToTable("Mammals");
        modelBuilder.Entity<Bird>().ToTable("Birds");
        base.OnModelCreating(modelBuilder);
    }
}
