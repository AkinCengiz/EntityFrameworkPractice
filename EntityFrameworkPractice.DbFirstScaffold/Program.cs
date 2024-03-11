using EntityFrameworkPractice.DbFirstScaffold.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkPractice.DbFirstScaffold;

internal class Program
{
	static void Main(string[] args)
	{
		using (var context = new EfCoreDatabaseFirstDbContext())
		{
			var products = context.Products.ToList();

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
