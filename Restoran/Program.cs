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
    db.Database.EnsureCreated();
 //   db.Database.EnsureDeleted();
   // db.Database.Migrate();
}
// TPH
//using (RestoranDbContext db = new RestoranDbContext(options))
//{
//    Customer customer = new Customer { CPib = "Vova" };
//    GoodCustomer goodCustomer = new GoodCustomer { CPib = "Alisa", AverageOrderPrice = 900 };
//    BadCustomer badCustomer = new BadCustomer { CPib = "Bogdan", ReasonForDeleting = "Drink vodka with pivo" };
//    db.Customers.Add(customer);
//    db.Customers.Add(badCustomer);
//    db.Customers.Add(goodCustomer);
//    db.SaveChanges();
//}

//add  first time value 
using (RestoranDbContext db = new RestoranDbContext(options))
{
    //    // Restoran.Restoran restoran = new Restoran.Restoran { RAddress = "mayakovskogo", RClients = 2, RName = "Krusovice", RTables = 2, RWorkers = 3 }; ;
    //    Restoran.Restoraunt[] restorans = {
    //     new Restoran.Restoraunt { RAddress = "mayakovskogo", RClients = 2, RName = "Krusovice", RTables = 2, RWorkers = 3 },
    //     new Restoran.Restoraunt { RAddress = "ostrovskogo", RClients = 3, RName = "Gallia", RTables = 4, RWorkers = 4 },
    //     new Restoran.Restoraunt { RAddress = "pigovskogo", RClients = 4, RName = "Tartala", RTables = 6, RWorkers = 5 },
    //     new Restoran.Restoraunt { RAddress = "rodovskogo", RClients = 5, RName = "Pivobar", RTables = 1, RWorkers = 2 }
    //    };
    //    foreach(var  val in restorans)
    //    {
    //        db.Restorans.Add(val);
    //    }
  
    db.Customers.AddRange(
    
        new Customer {CPib = "Alexa"},
        new Customer {CPib = "Yana"},
        new Customer {CPib = "Maria"},
        new Customer {CPib = "Alex"}

    );
    db.Positions.AddRange(
    
        new Position {PChairs = 3,PRoomType="For Love",PType="Small"},
        new Position {PChairs = 5,PRoomType="Bathroom",PType="Large" }

    );
    db.Dishes.AddRange(
    
        new Dish {DAviable=true,DCalority=34,DName="Meetballs",DPrice=10,DType="Base menu"},
        new Dish {DAviable=true,DCalority=314,DName="Chicken NuGets",DPrice=50,DType="Base menu"},
        new Dish {DAviable=true,DCalority=124,DName="Apple juice",DPrice=5,DType="Drink"}

    );
    db.Ingridients.AddRange(
    
        new Ingridient {IAviable=false,IWeight=1,IName="Fox meet",IPriceFromZavod=200},
        new Ingridient {IAviable=true,IWeight=2,IName="Duck meet",IPriceFromZavod=2100},
        new Ingridient {IAviable=true,IWeight=10,IName="Dog meet",IPriceFromZavod=3},
        new Ingridient {IAviable=true,IWeight=5,IName="Chicken meet",IPriceFromZavod=250}
    );
    db.Workers.AddRange(
        new Worker {WDocument="12345678",WIpn="32147865",WPib="Omela",WSalary=124},
        new Worker {WDocument="12345978",WIpn="32047865",WPib="Petrosuan",WSalary=134},
        new Worker {WDocument="15345678",WIpn="32147835",WPib="Pomela",WSalary=127}
    );
  
    db.SaveChanges();
}
//delete
using (RestoranDbContext db = new RestoranDbContext(options))
{
    Worker? worker = db.Workers.FirstOrDefault();
    if (worker != null)
    {
        db.Workers.Remove(worker);
        db.SaveChanges();
    }
}
//edit
using (RestoranDbContext db = new RestoranDbContext(options))
{
    Worker? worker = db.Workers.FirstOrDefault();
    if(worker!= null)
    {
        worker.WSalary = 10000;
        db.SaveChanges();
    }
}
//read
using (RestoranDbContext db = new RestoranDbContext(options))
{
    var val = db.Restorans.ToList();
    foreach(var it in val)
    {
        Console.WriteLine($"{it.RId}|{it.RName}|{it.RAddress}|{it.RWorkers}|{it.RClients}|{it.RTables}");
    }
}