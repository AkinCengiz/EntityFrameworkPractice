using EntityFrameworkPractice.EfCodeFirst.DataAccess;

namespace EntityFrameworkPractice.EfCodeFirst;

internal class Program
{
	static void Main(string[] args)
	{
		Initializer.Build();
		using (var context = new EfCodeFirstDbContext())
		{
			var products = context.Products.ToList();
			products.ForEach(p =>
			{
				Console.WriteLine($"{p.Id} - {p.Name}\t{p.Stock} => {p.Price}");
			});
		}
	}
}
