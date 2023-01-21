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

////Lazy loading
//using (RestoranDbContext db = new RestoranDbContext(options))
//{

//    db.WorkRanks.Add(
//        new WorkRank { WrFullName = "New lazy entity1" }
//        );
//    db.Workers.Add(
//        new Worker
//        {
//            WIpn = "09870543",
//            WDocument = "90923477",
//            WPostId = 27,
//            WSalary = 3221,
//            WPib = "New lazy entity23"
//        }
//        );
//    db.Workers.Add(
//   new Worker
//   {
//       WIpn = "09871543",
//       WDocument = "90121487",
//       WPostId = 27,
//       WSalary = 3271,
//       WPib = "New lazy entity2we"
//   }
//   );
//    db.Workers.Add(
//   new Worker
//   {
//       WIpn = "09876243",
//       WDocument = "90123387",
//       WPostId = 27,
//       WSalary = 3921,
//       WPib = "New lazy entit3q"
//   }
//   );
//    db.SaveChanges();
//}
//using (RestoranDbContext db = new RestoranDbContext(options))
//{
//    var workers = db.Workers.ToList();
//    foreach (var val in workers)
//        Console.WriteLine($"{val.WPib}-|-{val.WPost.WrFullName}");

//}


//////////////AS NO TRACKING
//using (RestoranDbContext db = new RestoranDbContext(options))
//{
//    var customer = db.Customers.AsNoTracking().FirstOrDefault();
//    if(customer != null)
//    {
//        customer.CPib = "No traking";
//        db.SaveChanges();
//    }

//    var customers = db.Customers.ToList();
//    foreach(var n in customers)
//    {
//        Console.WriteLine($"{n.CPib}");
//    }
//}
//using (RestoranDbContext db = new RestoranDbContext(options))
//{
//    var c = db.Customers.FirstOrDefault();
//    var c2 = db.Customers.AsNoTracking().FirstOrDefault();

//    if (c != null && c2 != null)
//    {
//        Console.WriteLine($"Before Customer1 :{c.CPib}   Customer2 :{c2.CPib}");
//        c.CPib = "Changed";
//        Console.WriteLine($"After Customer1 :{c.CPib}   Customer2 :{c2.CPib}");

//    }
//}
////////////////////Eager loading
//using (RestoranDbContext db = new RestoranDbContext(options))
//{

//    db.WorkRanks.Add(
//          new WorkRank { WrFullName = "New lazy entity1" }
//    );
//    db.Workers.Add(
// new Worker
// {
//     WIpn = "098711624",
//     WDocument = "90121187",
//     WPostId = 28,
//     WSalary = 3921,
//     WPib = "New eager entity"
// });
//    db.SaveChanges();
//    var wr = db.WorkRanks.Include(x => x.Workers).ToList();
//    foreach(var worker in wr)
//    {
//        Console.WriteLine($"{worker.WrFullName}-|-{worker.Workers[0].WPib}");
//    }
//};
////Explicit loading
//using (RestoranDbContext db = new RestoranDbContext(options))
//{
//   db.Workers.Add(
//        new Worker
//        {
//            WIpn = "098711624",
//            WDocument = "90121187",
//            WPostId = 1,
//            WSalary = 3921,
//            WPib = "New eager entity"
//        });

//    db.SaveChanges();

//    WorkRank? wr = db.WorkRanks.FirstOrDefault();
//    if(wr != null)
//    {
//        db.Entry(wr).Collection(x => x.Workers).Load();
//        foreach(var val in wr.Workers)
//        {
//            Console.WriteLine($"{val.WPostId}|{val.WId}|{val.WPib}");
//        }
//    }
//}

//Procedures
using (RestoranDbContext db = new RestoranDbContext(options))
{
    Console.WriteLine("******Proc");

    SqlParameter parameter = new()
    {
        ParameterName = "@name",
        SqlDbType = System.Data.SqlDbType.VarChar,
        Direction = System.Data.ParameterDirection.Input,
        Size = 3000,
        SqlValue="Added from EF labs"
    };
  //  db.Database.ExecuteSqlRaw("addClient @name", parameter) executed;

    var customers = db.Customers;
    foreach(Customer val in customers)
         Console.WriteLine($"{val.CPib}");
}
//Functions
using (RestoranDbContext db = new RestoranDbContext(options))
{
    Console.WriteLine("******Func");
    var ranks = db.WorkRanks.FromSqlRaw("SELECT * FROM GetWorkRankes()").ToList();
    foreach (var val in ranks)
        Console.WriteLine($"{val.WrFullName}");

}
