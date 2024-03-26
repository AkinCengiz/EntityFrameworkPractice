using System.Runtime.CompilerServices;
using EntityFrameworkPractice.RelationShips.DataAccess;
using EntityFrameworkPractice.RelationShips.Entity;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkPractice.RelationShips;

internal class Program
{
    static void Main(string[] args)
    {
        Initializer.Build();
        using (var context = new EntityRelationContext())
        {
            var category = context.Categories.First();
            var products = category.Products;

            foreach (var product in products)
            {
                Console.WriteLine(product.Name);
            }
            products.ForEach(p =>
            {
                Console.WriteLine(p.Name);
            });
            //EagerLoading(context);


            //CategoryProductAdd(context);

            //NewMethod(context);
            //Method2(context);

            //NewMethod3(context);
            //NewMethod4(context);

            //NewMethod5(context);
        }
    }

    private static void EagerLoading(EntityRelationContext context)
    {
        var categoryWithProduct = context.Categories.Include(x => x.Products).First();

        Console.WriteLine(categoryWithProduct.Name +
                          " Kategorisinde bulunan ürünler\n*************************************\n");
        foreach (var product in categoryWithProduct.Products)
        {
            Console.WriteLine(product.Name);
        }

        categoryWithProduct =
            context.Categories.Include(p => p.Products).ThenInclude(t => t.ProductFeature).First();

        Console.WriteLine(categoryWithProduct.Name +
                          " Kategorisinde bulunan ürünler\n*************************************\n");
        foreach (var product in categoryWithProduct.Products)
        {
            Console.WriteLine(
                $"Name : {product.Name}\tPrice{product.Price}\nÖzellikleri\t:\n**********************************\nColor\t: {product.ProductFeature.Color}\tWidth\t: {product.ProductFeature.Width}\tHeight\t:{product.ProductFeature.Height}");
        }
    }

    private static void CategoryProductAdd(EntityRelationContext context)
    {
        var category = new Category { Name = "Küçük Ev Aletleri" };
        category.Products.Add(new Product()
        {
            Name = "Saç Kurutma",
            Price = 3500,
            Tax = 0.08m,
            Stock = 25,
            ProductFeature = new ProductFeature()
            {
                Color = "Green",
                Width = 25,
                Height = 30
            }
        });
        context.Categories.Add(category);
        context.SaveChanges();
        Console.WriteLine("Success...");
    }

    private static void NewMethod5(EntityRelationContext context)
    {
        var student = new Student()
        {
            FirstName = "Liva",
            LastName = "Varan",
            Classroom = "5-C"
        };
        student.Teachers.Add(context.Teachers.FirstOrDefault(t => t.FirstName == "Akın"));
        student.Teachers.Add(context.Teachers.FirstOrDefault(t => t.FirstName == "Seda"));
        student.Teachers.Add(context.Teachers.FirstOrDefault(t => t.FirstName == "Serap"));
        context.Students.Add(student);
        Teacher teacher = new Teacher()
        {
            FirstName = "Serpil",
            LastName = "Telci",
            Branch = "Saç Tasarım",
        };
        List<Student> students = context.Students.ToList();
        teacher.Students.AddRange(students);
        context.Add(teacher);
        var category = context.Categories.FirstOrDefault(c => c.Id == 3);
        context.Categories.Remove(category);
        context.Categories.Add(new Category()
        {
            Name = "Beyaz Eşya",
            Products = new List<Product>()
            {
                context.Products.FirstOrDefault(p => p.Id == 3),
                context.Products.FirstOrDefault(p => p.Id == 4)
            }
        });
        context.Products.Add(new Product()
        {
            Name = "Desktop",
            Price = 10000,
            Tax = 0.1m,
            Stock = 5,
            Category = context.Categories.First(),
            ProductFeature = new ProductFeature() { Color = "Black", Width = 25, Height = 25 }
        });
        context.SaveChanges();
        Console.WriteLine("Kayıt işlemi başarılı...");
    }

    private static void NewMethod4(EntityRelationContext context)
    {
        Student student = context.Students.FirstOrDefault(s => s.FirstName == "Derin");
        var teacher = new Teacher()
        {
            FirstName = "Seda",
            LastName = "Varan",
            Branch = "Güzellik Uzmanlığı",
            Students = new List<Student>() { context.Students.FirstOrDefault(s => s.FirstName == "Derin") }
        };
        context.Add(teacher);
    }

    private static void NewMethod3(EntityRelationContext context)
    {
        var student = new Student()
        {
            FirstName = "Derin",
            LastName = "Cingöz",
            Classroom = "11-B",
            Teachers = new List<Teacher>()
            {
                new Teacher() { FirstName = "Akın", LastName = "Cengiz", Branch = "Matematik" },
                new Teacher() { FirstName = "Serap", LastName = "Cengiz", Branch = "Güzel Sanatlar" }
            }
        };
        context.Add(student);
    }

    private static void Method2(EntityRelationContext context)
    {
        Category category = context.Categories.FirstOrDefault(c => c.Name == "Beyaz Eşya");
        category.Products.Add(new Product()
        {
            Name = "Çamaşır Makinesi", Price = 20000, Stock = 8,
            ProductFeature = new ProductFeature() { Color = "White", Height = 50, Width = 100 }
        });
        context.SaveChanges();
    }

    private static void NewMethod(EntityRelationContext context)
    {
        Category category = new Category();
        category.Name = "Beyaz Eşya";
        context.Categories.Add(category);
        Product beko = new()
        {
            Name = "Buzdolabı",
            Price = 25000,
            Stock = 5,
            Category = category
        };
        context.Products.Add(beko);
        ProductFeature productFeature = new()
        {
            Width = 8,
            Height = 18,
            Color = "Red",
            Product = beko
        };
        context.ProductFeatures.Add(productFeature);
        context.SaveChanges();
        Console.WriteLine("Kayıt işlemi başarılı...");
    }
}
