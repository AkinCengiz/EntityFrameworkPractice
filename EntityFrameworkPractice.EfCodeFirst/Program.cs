using System.ComponentModel.DataAnnotations;
using EntityFrameworkPractice.EfCodeFirst.DataAccess;
using EntityFrameworkPractice.EfCodeFirst;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkPractice.EfCodeFirst;

internal class Program
{
	static void Main(string[] args)
	{
		Initializer.Build();
		using (var context = new EfCodeFirstDbContext())
		{
            //var products = context.Products.ToList();
            //products.ForEach(p =>
            //         {
            //             var state = context.Entry(p).State;
            //             Console.WriteLine($"{p.Id} - {p.Name}\t{p.Stock} => {p.Price} - State : {state}");
            //         });

            //var newProduct = new Product() { Name = "Kitap", Price = 43, Stock = 47, Barcode = "dfkfşdfksşlf fdfksş" };
            //Console.WriteLine($"İlk State : {context.Entry(newProduct).State}");
            //context.Add(newProduct);
            //Console.WriteLine($"İlk State : {context.Entry(newProduct).State}");
            //context.SaveChanges();
            //Console.WriteLine($"İlk State : {context.Entry(newProduct).State}");

            //var product = context.Products.First();
            //Console.WriteLine($"İlk State : {context.Entry(product).State}");
            //product.Stock = 5000;
            //Console.WriteLine($"İkinci State : {context.Entry(product).State}");
            //context.Entry(product).State = EntityState.Unchanged;
            //Console.WriteLine($"İlk State : {context.Entry(product).State}");
            //context.SaveChanges();
            //Console.WriteLine($"Son State : {context.Entry(product).State}");

            //context.Update(new Product()
            //{
            //    Id = 3,
            //    Name = "Silgi",
            //    Stock = 29,
            //    Price = 15,
            //    Barcode = "silgi3522"
            //});
            //context.SaveChanges();

            //var prd = context.Products.AsNoTracking().ToList();

            //prd.ForEach(p =>
            //{
            //    Console.WriteLine($"{p.Name} --- {p.Stock} --- {p.Price}");
            //});

            //context.ChangeTracker.Entries().ToList().ForEach(p =>
            //{
            //    if (p.Entity is Product pdt)
            //    {
            //        Console.WriteLine($"{pdt.Id} - {pdt.Name} - {pdt.Stock} - {pdt.Price}");
            //    }
            //});

            //context.Products.Add(new()
            //{
            //    Name = "Çanta",
            //    Stock = 15,
            //    Price = 95,
            //    Barcode = "1234asdf"
            //});

            //context.ChangeTracker.Entries().ToList().ForEach(e =>
            //{
            //    if (e.Entity is Product pdt)
            //    {
            //        if (e.State == EntityState.Added)
            //        {
            //            pdt.CreatedDate = DateTime.Now;
            //        }
            //    }
            //});
            var entity = context.Products.First();
            entity.Price = 125;
            context.SaveChanges();
        }
	}
}
