using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EntityFrameworkPractice.EfCodeFirst.DataAccess;
public class EfCodeFirstDbContext : DbContext
{
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		Initializer.Build();
		optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));
	}

	public DbSet<Product> Products { get; set; }
}
