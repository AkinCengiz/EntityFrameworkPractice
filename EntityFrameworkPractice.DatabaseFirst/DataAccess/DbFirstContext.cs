using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkPractice.DatabaseFirst.DataAccess;
public class DbFirstContext : DbContext
{
	public DbSet<Product> Products { get; set; }

	public DbFirstContext()
	{
		
	}
	public DbFirstContext(DbContextOptions<DbFirstContext> options) : base(options)
	{
		
	}
}
