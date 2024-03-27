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
            var category = context.Categories.First();
            if (category != null)
            {
                category.Products.Add(new Product() {Name = "Laptop", Price = 2500, Stock = 15, ProductFeature = new ()
                {
                    Color = "Black",
                    Width = 36,
                    Height = 25
                }});
                category.Products.Add(new Product()
                {
                    Name = "Desktop",
                    Price = 2000,
                    Stock = 10,
                    ProductFeature = new()
                    {
                        Color = "Gray",
                        Width = 50,
                        Height = 40
                    }
                });
                context.SaveChanges();
                Console.WriteLine("Success\n");
            }

        }
        
    }
}
