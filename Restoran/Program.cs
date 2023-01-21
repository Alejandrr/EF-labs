using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using Restoran3;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage;
using Castle.Core.Resource;
using System.Data;

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
object locker = new();
int x = 1;
Action writing = async () =>
{
    Monitor.Enter(locker);
    try
    {
        using (RestoranDbContext db = new RestoranDbContext(options))
        {
            for (int i = 0; i < 100; i++)
            {
                await db.Customers.AddAsync(new Customer
                {
                    CPib = x.ToString() +"ent",
                });
                x++;
            }
            db.SaveChanges();
        }
    }
    finally
    {
        Monitor.Exit(locker);
    }
};

Action reading = () =>
{
    using (RestoranDbContext db = new RestoranDbContext(options))
    {
        var Customers = db.Customers.ToListAsync();
        Customers.Result.ForEach(x => Console.WriteLine(x.CPib));
    }
};

Task task1 = new Task(writing);
Task task2 = new Task(writing);
Task task3 = new Task(reading);
task1.Start();
task2.Start();
task1.Wait();
task2.Wait();
task3.Start();
task3.Wait();



ThreadStart action = () =>
{
    Monitor.Enter(locker);
    try
    {
        using (RestoranDbContext db = new RestoranDbContext(options))
        {
            for (int i = 0; i < 100; i++)
            {
                db.Customers.AddAsync(new Customer
                {
                    CPib = x.ToString()+ "ent",
                });
                x++;
            }
            db.SaveChanges();
        }
    }
    finally
    {
        Monitor.Exit(locker);
    }
};

ThreadStart reading1 = () =>
{
    lock (locker)
    {
        using (RestoranDbContext db = new RestoranDbContext(options))
        {
            var customers = db.Customers.ToList();
            customers.ForEach(x => Console.WriteLine(x.CPib));
        }
    }
};

