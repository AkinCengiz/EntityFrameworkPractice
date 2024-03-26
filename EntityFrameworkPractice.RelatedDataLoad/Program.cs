using EntityFrameworkPractice.RelatedDataLoad.DataAccess;
using EntityFrameworkPractice.RelatedDataLoad.Entity;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkPractice.RelatedDataLoad;

internal class Program
{
    static void Main(string[] args)
    {
        Initializer.Build();


        using (var context = new RelatedDataLoadContext())
        {
            //CategoryAndProductAdd(context);
            //GetCategoryEagerLoading(context);
            //GetEntitiesExplicitLoading(context);
            //GetCategoryEasyLoading(context);

            GetCategoryEasyLoading(context);

            Console.WriteLine("\nİşlem başarılı...");
        }
    }

    private static void GetCategoryEasyLoading(RelatedDataLoadContext context)
    {
        var category = context.Categories.First();
        var products = category.Products;

        products.ForEach(p =>
        {
            Console.WriteLine(
                $"{p.Name}\t| Color : {p.ProductFeature.Color,-10}\t| Width : {p.ProductFeature.Width}\t| Height : {p.ProductFeature.Height}");
        });
    }

    private static void GetEntitiesExplicitLoading(RelatedDataLoadContext context)
    {
        var category = context.Categories.First();

        context.Entry(category).Collection(x => x.Products).Load();
        

        category.Products.ForEach(p =>
        {
            //Console.WriteLine($"{p.Name}\t");
            context.Entry(p).Reference(f => f.ProductFeature).Load();
            Console.WriteLine($"{p.Name}\t| Color : {p.ProductFeature.Color,-10}\t| Width : {p.ProductFeature.Width}\t| Height : {p.ProductFeature.Height}");
        });
        //var products = category.Products;
        //var features = products.Where(p => p.ProductFeature.Id == p.Id).ToList();
        //Console.WriteLine("Category Name\t: " + category.Name);
        //Console.WriteLine("*********************************");
        //products.ForEach(p =>
        //{
        //    features.ForEach(f =>
        //    {
        //        Console.WriteLine($"{p.Name}\t| Color : {f.ProductFeature.Color,-10}\t| Width : {f.ProductFeature.Width}\t| Height : {f.ProductFeature.Height}");
        //    });
            
        //});
    }

    private static void GetCategoryEagerLoading(RelatedDataLoadContext context)
    {
        var fullEntity = context.Categories.Include(c => c.Products).ThenInclude(p => p.ProductFeature).First();
        Console.WriteLine(fullEntity.Name + " kategorisi altındaki ürünler...\n");
        fullEntity.Products.ForEach(p =>
        {
            Console.WriteLine(
                $"{p.Name}\t| Color : {p.ProductFeature.Color,-10}\t| Width : {p.ProductFeature.Width}\t| Height : {p.ProductFeature.Height}");
        });
    }

    private static void CategoryAndProductAdd(RelatedDataLoadContext context)
    {
        var category = new Category() { Name = "Teknoloji" };
        category.Products.Add(new Product()
        {
            Name = "Toshiba Laptop",
            Price = 1500,
            Stock = 15,
            ProductFeature = new ProductFeature() { Color = "Black", Width = 40, Height = 25 }
        });
        category.Products.Add(new Product()
        {
            Name = "Hp Laptop",
            Price = 1250,
            Stock = 15,
            ProductFeature = new ProductFeature() { Color = "Gray", Width = 40, Height = 25 }
        });
        category.Products.Add(new Product()
        {
            Name = "Dell Laptop",
            Price = 1450,
            Stock = 15,
            ProductFeature = new ProductFeature() { Color = "Black-Red", Width = 40, Height = 25 }
        });
        context.Categories.Add(category);
        context.SaveChanges();
    }
}
