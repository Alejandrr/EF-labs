using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using Restoran3;
var builder = new ConfigurationBuilder();
builder.SetBasePath(Directory.GetCurrentDirectory());
builder.AddJsonFile("appsettings.json");
var config = builder.Build();
string connectionString = config.GetConnectionString("DefaultConnection")!;

var optionsBuilder = new DbContextOptionsBuilder<RestoranDbContext>();
var options = optionsBuilder.UseSqlServer(connectionString).Options;

using (RestoranDbContext db = new RestoranDbContext(options))
{
 //   db.Database.EnsureDeleted();
   // db.Database.Migrate();
}
//Select
using (RestoranDbContext db = new RestoranDbContext(options))
{
    Console.WriteLine("*****Select");
    var CNames = (from Customer in db.Customers select Customer.CPib);
    Console.WriteLine("*****Customers");
    foreach (var val in CNames)
        Console.WriteLine($"{val}");

    var WNames = (from Worker in db.Workers select Worker.WPib);
    Console.WriteLine("*****Workers");
    foreach (var val in WNames)
        Console.WriteLine($"{val}");
}
//Union
//SELECT Worker.W_PIB  FROM Worker
//UNION
//SELECT Customer.C_PIB FROM Customer
using (RestoranDbContext db = new RestoranDbContext(options))
{
    var names = (from Customer in db.Customers select Customer.CPib)
        .Union(from Worker in db.Workers select Worker.WPib);
    Console.WriteLine("*****Union");
    foreach (var val in names)
        Console.WriteLine($"{val}");
}
//Except
//SELECT W_PIB FROM Worker
//EXCEPT SELECT C_PIB FROM Customer
using (RestoranDbContext db = new RestoranDbContext(options))
{
    var query1 = (from Worker in db.Workers
                  select Worker.WPib).Take(3);
    foreach (var name in query1)
        db.Customers.Add(new Customer() { CPib = name });
    //db.SaveChanges();

    var query = (from Customer in db.Customers
                 select Customer.CPib)
                 .Except(from Worker in db.Workers
                         select Worker.WPib).ToList();

    Console.WriteLine("*****Except");
    foreach (var val in query)
        Console.WriteLine($"{val}");
}
//Distinct 
//select distinct * from customer
using (RestoranDbContext db = new RestoranDbContext(options))
{
    Console.WriteLine("*****Distinct");
    var query = (from worker in db.Workers
                 select new { worker.WId, worker.WPib, worker.WIpn, worker.WSalary, worker.WDocument }
                 ).Distinct().ToList();
    foreach (var val in query)
    {
        Console.WriteLine($"{val.WId}|{val.WPib}|{val.WSalary}|{val.WDocument}|{val.WIpn}");
    }

}

    //Intersect
    //SELECT W_PIB FROM Worker
    //INTERSECT SELECT C_PIB FROM Customer
using (RestoranDbContext db = new RestoranDbContext(options))
{
    var query1 = (from Worker in db.Workers
                  select Worker.WPib).Take(3);
    foreach (var name in query1)
        db.Customers.Add(new Customer() { CPib = name });
    //db.SaveChanges();

    var query = (from Customer in db.Customers
                 select Customer.CPib)
                 .Intersect(from Worker in db.Workers
                            select Worker.WPib).ToList();

    Console.WriteLine("*****Intersect");
    foreach (var val in query)
        Console.WriteLine($"{val}");
}


//JOIN
using (RestoranDbContext db = new RestoranDbContext(options))
{
    Console.WriteLine("*****Join");
    var query =
        from w in db.Workers
        join wr in db.WorkRanks on w.WPostId equals wr.WrId
        orderby wr.WrFullName
        select new { w, wr };
    foreach(var val in query)
    {
        Console.Write($"{val.w.WPib}|");
        if(val.wr.WrFullName != null)
        {
            Console.WriteLine($"{val.wr.WrFullName}");
        }
        else
        {
            Console.WriteLine("null");
        }
    }
}
// COUNT,MAX,MIN
using (RestoranDbContext db = new RestoranDbContext(options))
{
    var count = db.Workers.Count();
    var max = db.Workers.Max(x=>x.WSalary);
    var min = db.Workers.Min(x=>x.WSalary);

    Console.WriteLine($"***********Max salary:{max}|Min salary:{min}|Count of workers :{count}");
}