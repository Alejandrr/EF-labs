using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Restoran;
var builder = new ConfigurationBuilder();
builder.SetBasePath(Directory.GetCurrentDirectory());
builder.AddJsonFile("appsettings.json");
var config = builder.Build();
string connectionString = config.GetConnectionString("DefaultConnection")!;

var optionsBuilder = new DbContextOptionsBuilder<RestoranDbContext>();
var options = optionsBuilder.UseSqlServer(connectionString).Options;

using (RestoranDbContext db = new RestoranDbContext(options))
{
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();
}
//// Many to many
using (RestoranDbContext db = new RestoranDbContext(options))
{
    Dish[] dishes =
    {
        new Dish{DName = "Буженина"},
        new Dish{DName = "Бутерброд"},
        new Dish{DName = "Відбивна"}
    };
    Ingridient[] ingridients =
    {
        new Ingridient{IName = "Яйце"},
        new Ingridient{IName = "Мука"},
        new Ingridient{IName = "Мясо"},
        new Ingridient{IName = "Масло"},
    };
    dishes[0].DIngridients.AddRange(new List<Ingridient> { ingridients[1], ingridients[0] });
    dishes[1].DIngridients.AddRange(new List<Ingridient> { ingridients[3], ingridients[2] });
    dishes[2].DIngridients.AddRange(new List<Ingridient> { ingridients[1]});

    db.Dishes.AddRange(dishes);
    db.Ingridients.AddRange(ingridients);
    db.SaveChanges();
    Console.WriteLine("\tDishes:");
    foreach (var val in db.Dishes)
    {
        Console.WriteLine(val.DName);
        Console.WriteLine("*");
        foreach (var item in val.DIngridients)
        {
            Console.WriteLine(item.IName);
        }
        Console.WriteLine("*****");
    }
    Console.WriteLine("\tIngridients:");
    foreach (var val in db.Ingridients)
    {
        Console.WriteLine(val.IName);
        Console.WriteLine("*");
        foreach (var item in val.IDishes)
        {
            Console.WriteLine(item.DName);
        }
        Console.WriteLine("*******");
    }
}
//TPT,TPH
using (RestoranDbContext db = new RestoranDbContext(options))
{
    Customer customer = new Customer { CPib = "Vova" };
    GoodCustomer goodCustomer = new GoodCustomer { CPib = "Alisa", AverageOrderPrice = 900 };
    BadCustomer badCustomer = new BadCustomer { CPib = "Bogdan", ReasonForDeleting = "Bad salary" };
    db.Customers.Add(customer);
    db.Customers.Add(badCustomer);
    db.Customers.Add(goodCustomer);
    db.SaveChanges();
    foreach (Customer val in db.Customers)
    {
        Console.WriteLine($"{val.CPib}");
    }
    Console.WriteLine("***");
    foreach (GoodCustomer val in db.GoodCustomers)
    {
        Console.WriteLine($"{val.CPib}|{val.AverageOrderPrice}");
    }
    Console.WriteLine("***");
    foreach (BadCustomer val in db.BadCustomers)
    {
        Console.WriteLine($"{val.CPib}|{val.ReasonForDeleting}");
    }
}