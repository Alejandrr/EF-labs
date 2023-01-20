using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Restoran;

public partial class RestoranDbContext : DbContext
{
    public RestoranDbContext()
    {
    }

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

    public virtual DbSet<Recept> Recepts { get; set; }

    public virtual DbSet<Restoraunt> Restorans { get; set; }

    public virtual DbSet<WorkRank> WorkRanks { get; set; }

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

            entity.HasOne(d => d.OP).WithMany(p => p.Orderings)
                .HasForeignKey(d => d.OPId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.OW).WithMany(p => p.Orderings)
                .HasForeignKey(d => d.OWId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.PId);

            entity.Property(e => e.PRoomType)
                .HasMaxLength(10);
           
            entity.Property(e => e.PType)
                .HasMaxLength(30);
        });

        modelBuilder.Entity<Recept>(entity =>
        {
            entity.HasKey(e => e.RId);

            entity.HasOne(d => d.RD).WithMany(p => p.Recepts)
                .HasForeignKey(d => d.RDId);
             

            entity.HasOne(d => d.RI).WithMany(p => p.Recepts)
                .HasForeignKey(d => d.RIId);
        });

        modelBuilder.Entity<Restoraunt>(entity =>
        {
            entity.HasKey(e => e.RId);

            entity.HasIndex(e => e.RName).IsUnique();

            entity.HasIndex(e => e.RAddress).IsUnique();

            entity.Property(e => e.RAddress)
                .HasMaxLength(50);

            entity.Property(e => e.RClients)
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.RName)
                .HasMaxLength(30);
        });

        modelBuilder.Entity<WorkRank>(entity =>
        {
            entity.HasKey(e => e.WrId);

            entity.Property(e => e.WrFullName)
                .HasMaxLength(30);
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.HasKey(e => e.WId);
           
            entity.HasIndex(e => e.WIpn).IsUnique();

            entity.HasIndex(e => e.WPib).IsUnique();

            entity.HasIndex(e => e.WDocument).IsUnique();

            entity.Property(e => e.WDocument)
                .HasMaxLength(8);

            entity.Property(e => e.WIpn)
                .HasMaxLength(8);

            entity.Property(e => e.WPib)
                .HasMaxLength(40);
                  
            entity.Property(e => e.WSalary)
                .HasColumnType("money");


            entity.HasOne(d => d.WPost).WithMany(p => p.Workers)
                .HasForeignKey(d => d.WPostId);
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

