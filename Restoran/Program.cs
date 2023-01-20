using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
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
 //   db.Database.EnsureDeleted();
    db.Database.Migrate();
}

using(RestoranDbContext db = new RestoranDbContext(options))
{
    // Restoran.Restoran restoran = new Restoran.Restoran { RAddress = "mayakovskogo", RClients = 2, RName = "Krusovice", RTables = 2, RWorkers = 3 }; ;
    Restoran.Restoraunt[] restorans = {
     new Restoran.Restoraunt { RAddress = "mayakovskogo", RClients = 2, RName = "Krusovice", RTables = 2, RWorkers = 3 },
     new Restoran.Restoraunt { RAddress = "ostrovskogo", RClients = 3, RName = "Gallia", RTables = 4, RWorkers = 4 },
     new Restoran.Restoraunt { RAddress = "pigovskogo", RClients = 4, RName = "Tartala", RTables = 6, RWorkers = 5 },
     new Restoran.Restoraunt { RAddress = "rodovskogo", RClients = 5, RName = "Pivobar", RTables = 1, RWorkers = 2 }
    };
    foreach(var  val in restorans)
    {
        db.Restorans.Add(val);
    }
   
    db.SaveChanges();
}
