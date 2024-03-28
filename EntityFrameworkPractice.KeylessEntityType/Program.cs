using EntityFrameworkPractice.KeylessEntityType.DataAccess;
using EntityFrameworkPractice.KeylessEntityType.Entity;

namespace EntityFrameworkPractice.KeylessEntityType;

internal class Program
{
    static void Main(string[] args)
    {
        Initializer.Build();
        using (var context = new KeylessEntityTypeDbContext())
        {
            //context.Categories.Add(new Category(){Name = "Teknoloji"});
            //context.SaveChanges();
            //var category = context.Categories.First();
            //if (category != null)
            //{
            //    category.Products.Add(new Product() {Name = "Laptop", Price = 2500, Stock = 15, ProductFeature = new ()
            //    {
            //        Color = "Black",
            //        Width = 36,
            //        Height = 25
            //    }});
            //    category.Products.Add(new Product()
            //    {
            //        Name = "Desktop",
            //        Price = 2000,
            //        Stock = 10,
            //        ProductFeature = new()
            //        {
            //            Color = "Gray",
            //            Width = 50,
            //            Height = 40
            //        }
            //    });
            //    context.SaveChanges();
            //    Console.WriteLine("Success\n");
            //}

            var result = (from c in context.Categories
                join p in context.Products on c.Id equals p.CategoryId
                join pf in context.ProductFeatures on p.Id equals pf.Id
                select new
                {
                    CategoryName = c.Name,
                    ProductName = p.Name,
                    Stock = p.Stock,
                    Price = p.Price,
                    Color = pf.Color,
                    Width = pf.Width,
                    Height = pf.Height,
                }).ToList();

            var result2 = context.Categories.Join(context.Products, x => x.Id,y => y.CategoryId,(c,p) => new {Category=c.Name,Product = p.Name}).ToList();

            result.ForEach(c =>
            {
                Console.WriteLine(
                    $"{c.CategoryName} - {c.ProductName} {c.Stock} {c.Price} {c.Color} {c.Width} {c.Height}");
            });

            result2.ForEach(x =>
            {
                Console.WriteLine($"{x.Category} => {x.Product}");
            });
        }

    }
}
