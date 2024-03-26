using EntityFrameworkPractice.Inheritance.DataAccess;
using EntityFrameworkPractice.Inheritance.Entity;

namespace EntityFrameworkPractice.Inheritance;

internal class Program
{
    static void Main(string[] args)
    {
        Initializer.Build();

        using (var context = new InheritanceContext())
        {
            CreatePerson(context);
            GetListAllPerson(context);

            AddAnimal(context);

            List<Animal> animals = context.Animals.ToList();
            animals.ForEach(animal =>
            {
                if (animal is Bird)
                {
                    Bird bird = (Bird) animal;
                    Console.WriteLine($"{bird.Name}\t{bird.Age}\t{bird.Length}\t{bird.Weight}\t{bird.Wingspan}");
                }
            });
        }
    }

    private static void AddAnimal(InheritanceContext context)
    {
        context.Birds.Add(new Bird()
        {
            Name = "Black Eagle",
            Age = 15,
            Length = 0.7m,
            Weight = 30,
            Wingspan = 5
        });
        context.Mammals.Add(new Mammal()
        {
            Name = "Wolf",
            Age = 15,
            FootNumber = 4,
            Length = 2,
            Weight = 30
        });

        context.Animals.Add(new Bird()
        {
            Name = "Eagle",
            Age = 15,
            Length = 0.7m,
            Weight = 30,
            Wingspan = 5
        });
        context.Animals.Add(new Mammal()
        {
            Name = "Cow",
            Age = 15,
            Length = 4,
            Weight = 1000,
            FootNumber = 4
        });
        context.SaveChanges();
        Console.WriteLine("Animals added success");
    }

    private static void GetListAllPerson(InheritanceContext context)
    {
        List<Person> personList = context.Persons.ToList();
        personList.ForEach(p =>
        {
            if (p is Manager)
            {
                Manager m = (Manager)p;
                Console.WriteLine($"{m.FirstName}\t{m.LastName}\t{m.Age}\t{m.Grade}");
            }

            if (p is Employee)
            {
                Employee m = (Employee)p;
                Console.WriteLine($"{m.FirstName}\t{m.LastName}\t{m.Age}\t{m.Salary}");
            }
        });
    }

    private static void CreatePerson(InheritanceContext context)
    {
        context.Managers.Add(new()
        {
            FirstName = "Manager 1",
            LastName = "Manager 1",
            Age = 45,
            Grade = 1
        });

        context.Employees.Add(new Employee()
        {
            FirstName = "Employee 1",
            LastName = "Employee 1",
            Age = 25,
            Salary = 32000
        });
        context.Persons.Add(new Manager()
        {
            FirstName = "Manager 2",
            LastName = "Manager 2",
            Age = 47,
            Grade = 2
        });
        context.Persons.Add(new Employee()
        {
            FirstName = "Employee 2",
            LastName = "Employee 2",
            Age = 35,
            Salary = 30000
        });
        context.SaveChanges();
        Console.WriteLine("Success");
    }
}
