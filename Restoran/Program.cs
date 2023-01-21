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
Action action = async () =>
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

Task task1 = new Task(action);
Task task2 = new Task(action);
Task task3 = new Task(reading);
task1.Start();
task2.Start();
task1.Wait();
task2.Wait();
task3.Start();
task3.Wait();



ThreadStart action1 = () =>
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

var thread1 = new Thread(action1);
var thread2 = new Thread(action1);
var thread3 = new Thread(action1);
var thread4 = new Thread(action1);

thread1.Start();
thread2.Start();
thread3.Start();
thread4.Start();
DateTime date = DateTime.Now;
var actionThreadsAreDone = false;
while (!actionThreadsAreDone)
{
    actionThreadsAreDone = thread1.ThreadState == ThreadState.Stopped &&
    thread2.ThreadState == ThreadState.Stopped &&
    thread3.ThreadState == ThreadState.Stopped &&
    thread4.ThreadState == ThreadState.Stopped;
};
DateTime dateafter = DateTime.Now;
Console.WriteLine(dateafter - date);

thread3 = new Thread(reading1);
thread4 = new Thread(reading1);
thread3.Start();
thread4.Start();

