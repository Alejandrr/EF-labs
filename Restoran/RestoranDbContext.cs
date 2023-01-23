using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Restoran3;

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

    public virtual DbSet<Restoran> Restorans { get; set; }

    public virtual DbSet<WorkRank> WorkRanks { get; set; }

    public virtual DbSet<Worker> Workers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CId).HasName("PK_Customer");
            entity.ToTable("Customer");
            entity.Property(e => e.CId).HasColumnName("C_ID");
            entity.Property(e => e.CPib)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("C_PIB");
        });

        modelBuilder.Entity<Dish>(entity =>
        {
            entity.HasKey(e => e.DId).HasName("PK_Dish");

            entity.ToTable("Dish");

            entity.Property(e => e.DId).HasColumnName("D_ID");
            entity.Property(e => e.DAviable).HasColumnName("D_Aviable");
            entity.Property(e => e.DCalority)
                .HasDefaultValueSql("((1))")
                .HasColumnName("D_Calority");
            entity.Property(e => e.DName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("D_Name");
            entity.Property(e => e.DPrice)
                .HasDefaultValueSql("((1))")
                .HasColumnType("money")
                .HasColumnName("D_Price");
            entity.Property(e => e.DType)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("D_Type");
            entity.Property(e => e.DDnid)
           .HasColumnName("D_DN_ID");
            entity.HasOne(d => d.DDn).WithMany(p => p.Dishes)
             .HasForeignKey(d => d.DDnid)
             .OnDelete(DeleteBehavior.Restrict)
             .HasConstraintName("FK_Dish_Ddnid");
           
             
            
        });

        modelBuilder.Entity<DishNumerate>(entity =>
        {
            entity.HasKey(e => e.DnId).HasName("PK_DishNumerate");

            entity.ToTable("DishNumerate");

            entity.Property(e => e.DnId).HasColumnName("DN_ID");
            entity.Property(e => e.DnDishes).HasColumnName("DN_Dishes");
            entity.Property(e => e.DnPrice)
                .HasDefaultValueSql("((10.2))")
                .HasColumnType("money")
                .HasColumnName("DN_Price");
            entity.Property(e => e.DnTimestamp)
                .HasDefaultValueSql("('2022-06-07 07:07:07')")
                .HasColumnType("datetime")
                .HasColumnName("DN_Timestamp");

        });

        modelBuilder.Entity<Ingridient>(entity =>
        {
            entity.HasKey(e => e.IId).HasName("PK_Ingridient");

            entity.ToTable("Ingridient");

            entity.Property(e => e.IId).HasColumnName("I_ID");
            entity.Property(e => e.IAviable).HasColumnName("I_Aviable");
            entity.Property(e => e.IName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("I_Name");
            entity.Property(e => e.IPriceFromZavod)
                .HasDefaultValueSql("((1))")
                .HasColumnType("money")
                .HasColumnName("I_PriceFromZavod");
            entity.Property(e => e.IWeight)
                .HasDefaultValueSql("((1))")
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("I_Weight");
        });

        modelBuilder.Entity<Ordering>(entity =>
        {
            entity.HasKey(e => e.OId).HasName("PK_Ordering");

            entity.ToTable("Ordering");

            entity.Property(e => e.OId).HasColumnName("O_ID");
            entity.Property(e => e.OCId).HasColumnName("O_C_ID");
            entity.Property(e => e.ODnId).HasColumnName("O_DN_ID");
            entity.Property(e => e.OPId).HasColumnName("O_P_ID");
            entity.Property(e => e.OPosition).HasColumnName("O_Position");
            entity.Property(e => e.OTimestamp)
                .HasDefaultValueSql("('2022 June 07 08:7:0')")
                .HasColumnType("datetime")
                .HasColumnName("O_Timestamp");
            entity.Property(e => e.OWId).HasColumnName("O_W_ID");

            entity.HasOne(d => d.OC).WithMany(p => p.Orderings)
                .HasForeignKey(d => d.OCId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Ordering_C_ID");

            entity.HasOne(d => d.ODn).WithMany(p => p.Orderings)
                .HasForeignKey(d => d.ODnId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Ordering_DN");

            entity.HasOne(d => d.OP).WithMany(p => p.Orderings)
                .HasForeignKey(d => d.OPId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Ordering_P_ID");

            entity.HasOne(d => d.OW).WithMany(p => p.Orderings)
                .HasForeignKey(d => d.OWId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Ordering_W_ID");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.PId).HasName("PK_Position");

            entity.ToTable("Position");

            entity.Property(e => e.PId).HasColumnName("P_ID");
            entity.Property(e => e.PChairs).HasColumnName("P_Chairs");
            entity.Property(e => e.PRoomType)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("P_Room_Type");
            entity.Property(e => e.PType)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("P_Type");
        });

        modelBuilder.Entity<Recept>(entity =>
        {
            entity.HasKey(e => e.RId).HasName("PK_Recept");

            entity.ToTable("Recept");

            entity.Property(e => e.RId).HasColumnName("R_ID");
            entity.Property(e => e.RCookTime).HasColumnName("R_CookTime");
            entity.Property(e => e.RDId).HasColumnName("R_D_ID");
            entity.Property(e => e.RIId).HasColumnName("R_I_ID");

            entity.HasOne(d => d.RD).WithMany(p => p.Recepts)
                .HasForeignKey(d => d.RDId)
                .HasConstraintName("FK_Recept_R_D_ID");

            entity.HasOne(d => d.RI).WithMany(p => p.Recepts)
                .HasForeignKey(d => d.RIId)
                .HasConstraintName("FK_Recept_R_I_ID");
        });

        modelBuilder.Entity<Restoran>(entity =>
        {
            entity.HasKey(e => e.RId).HasName("PK_Restoran");

            entity.ToTable("Restoran");

            entity.HasIndex(e => e.RName, "UQ_Restoran_Name").IsUnique();

            entity.HasIndex(e => e.RAddress, "UQ_Restoran_Address").IsUnique();

            entity.Property(e => e.RId).HasColumnName("R_ID");
            entity.Property(e => e.RAddress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("R_Address");
            entity.Property(e => e.RClients)
                .HasDefaultValueSql("((0))")
                .HasColumnName("R_Clients");
            entity.Property(e => e.RName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("R_Name");
            entity.Property(e => e.RTables).HasColumnName("R_Tables");
            entity.Property(e => e.RWorkers).HasColumnName("R_Workers");
        });

        modelBuilder.Entity<WorkRank>(entity =>
        {
            entity.HasKey(e => e.WrId).HasName("PK_WorkRank");

            entity.ToTable("WorkRank");

            entity.Property(e => e.WrId).HasColumnName("WR_ID");
            entity.Property(e => e.WrFullName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("WR_FullName");
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.HasKey(e => e.WId).HasName("PK_Worker");

            entity.ToTable("Worker");

            entity.HasIndex(e => e.WIpn, "UQ_Worker_IPN").IsUnique();

            entity.HasIndex(e => e.WPib, "UQ_Worker_PIB").IsUnique();

            entity.HasIndex(e => e.WDocument, "UQ_Worker_Doc").IsUnique();

            entity.Property(e => e.WId).HasColumnName("W_ID");
            entity.Property(e => e.WDocument)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("W_Document");
            entity.Property(e => e.WIpn)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("W_IPN");
            entity.Property(e => e.WPib)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("W_PIB");
            entity.Property(e => e.WPostId).HasColumnName("W_PostID");
            entity.Property(e => e.WSalary)
                .HasColumnType("money")
                .HasColumnName("W_Salary");

            entity.HasOne(d => d.WPost).WithMany(p => p.Workers)
                .HasForeignKey(d => d.WPostId)
                .HasConstraintName("FK_Worker_PostID");
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
