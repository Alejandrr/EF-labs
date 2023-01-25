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
    public virtual DbSet<BadCustomer> BadCustomers { get; set; }
    public virtual DbSet<GoodCustomer> GoodCustomers { get; set; }
    public virtual DbSet<Dish> Dishes { get; set; }
    public virtual DbSet<Ingridient> Ingridients { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
        modelBuilder.Entity<Dish>()
            .HasMany<Ingridient>(d => d.DIngridients)
            .WithMany(i => i.IDishes);
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
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CId);

            entity.Property(e => e.CPib)
                .HasMaxLength(40)
                .HasColumnName("C_PIB");
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

