using EntityFrameworkPractice.DatabaseFirst.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkPractice.DatabaseFirst;

internal class Program
{
	static async Task Main(string[] args)
	{
		DbContextInitializer.Build();
		using (var context = new DbFirstContext())
		{
			var products =  await context.Products.ToListAsync();

			foreach (var product in products)
			{
				Console.WriteLine(product.Name);
			}

			products.ForEach(p =>
			{
				Console.WriteLine($"{p.Id} - {p.Name} - {p.Price}");
			});
		}
	}
}
