using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace Restoran;

public partial class RestoranDbContext : DbContext
{
    public RestoranDbContext(DbContextOptions<RestoranDbContext> options)
    : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Dish> Dishes { get; set; }

    public virtual DbSet<DishNumerate> DishNumerates { get; set; }

    public virtual DbSet<Ingridient> Ingridients { get; set; }

    public virtual DbSet<Ordering> Orderings { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Restoraunt> Restorans { get; set; }

    public virtual DbSet<Worker> Workers { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CId);

            entity.Property(e => e.CPib)
                .HasMaxLength(40)
                .HasColumnName("C_PIB");
        });

        modelBuilder.Entity<Dish>(entity =>
        {
            entity.HasKey(e => e.DId);

            entity.Property(e => e.DCalority)
                .HasDefaultValueSql("((1))");


            entity.Property(e => e.DName)
                .HasMaxLength(40);

            entity.Property(e => e.DPrice)
                .HasDefaultValueSql("((1))")
                .HasColumnType("money");

            entity.Property(e => e.DType)
                .HasMaxLength(10);

        });

        modelBuilder.Entity<DishNumerate>(entity =>
        {
            entity.HasKey(e => e.DnId);

            entity.Property(e => e.DnPrice)
                .HasDefaultValueSql("((10.2))")
                .HasColumnType("money");
            entity.Property(e => e.DnTimestamp)
                .HasDefaultValueSql("('2022-06-07 07:07:00')")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Ingridient>(entity =>
        {
            entity.HasKey(e => e.IId);


            entity.Property(e => e.IName)
                .HasMaxLength(30);

            entity.Property(e => e.IPriceFromZavod)
                .HasDefaultValueSql("((1))")
                .HasColumnType("money");

            entity.Property(e => e.IWeight)
                .HasDefaultValueSql("((1))")
                .HasColumnType("decimal(18, 0)");

        });

        modelBuilder.Entity<Ordering>(entity =>
        {
            entity.HasKey(e => e.OId);


            entity.Property(e => e.OTimestamp)
                .HasDefaultValueSql("('2022 June 07 08:7:0')")
                .HasColumnType("datetime");



            entity.HasOne(d => d.OC).WithMany(p => p.Orderings)
                .HasForeignKey(d => d.OCId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ODn).WithMany(p => p.Orderings)
                .HasForeignKey(d => d.ODnId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.OP).WithOne(p => p.POrder);

            entity.HasOne(d => d.OW).WithMany(p => p.Orderings)
                .HasForeignKey(d => d.OWId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.PId);
            entity.HasOne(e => e.POrder).WithOne(p => p.OP);

            entity.Property(e => e.PType).HasColumnName("PType");
            entity.ToTable(t => t.HasCheckConstraint("PType", "PType IN('Small', 'Medium', 'Large')"));
            entity.Property(e => e.PRoomType)
                .HasMaxLength(10)
                .HasColumnName("PRoomType");
            entity.ToTable(t => t.HasCheckConstraint("PRoomType", "PRoomType IN('For love','Bathroom','Bar','Terrasa')"));

            entity.Property(e => e.PType)
                .HasMaxLength(30);

        });


        modelBuilder.Entity<Restoraunt>(entity =>
        {
            entity.HasKey(e => e.RId);

            entity.HasIndex(e => e.RAddress, "Restorans_RAddress").IsUnique();

            entity.HasIndex(e => e.RName, "Restorans_RName").IsUnique();

            entity.Property(e => e.RId).HasColumnName("RId");
            entity.Property(e => e.RAddress)
                .HasMaxLength(50)
                .HasColumnName("RAddress");
            entity.Property(e => e.RClients)
                .HasDefaultValueSql("((0))")
                .HasColumnName("RClients");
            entity.Property(e => e.RName)
                .HasMaxLength(30)
                .HasColumnName("RName");
            entity.Property(e => e.RTables).HasColumnName("RTables");
            entity.Property(e => e.RWorkers).HasColumnName("RWorkers");
        });

        modelBuilder.Entity<Worker>(entity =>
        {
           
            entity.HasIndex(e => e.WDocument, "Workers_WDocument").IsUnique();

            entity.HasIndex(e => e.WIpn, "Workers_WIpn").IsUnique();

            entity.HasIndex(e => e.WPib, "Workers_WPib").IsUnique();

         

            entity.Property(e => e.WId).HasColumnName("WId");
            entity.Property(e => e.WDocument)
                .HasMaxLength(8)
                .HasColumnName("WDocument");
            entity.Property(e => e.WIpn)
                .HasMaxLength(8)
                .HasColumnName("WIpn");
            entity.Property(e => e.WPib)
                .HasMaxLength(40)
                .HasColumnName("WPib");
         
            entity.Property(e => e.WSalary)
                .HasColumnType("money")
                .HasColumnName("WSalary");

          
        });

    }
    public class SampleContextFactory : IDesignTimeDbContextFactory<RestoranDbContext>
    {
        public RestoranDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RestoranDbContext>();

            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            IConfigurationRoot config = builder.Build();

            string connectionString = config.GetConnectionString("DefaultConnection")!;
            optionsBuilder.UseSqlServer(connectionString);
            return new RestoranDbContext(optionsBuilder.Options);
        }
    }
}

