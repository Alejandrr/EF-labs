using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Restoran.In;

public partial class RestoranContext : DbContext
{
    public RestoranContext()
    {
    }

    public RestoranContext(DbContextOptions<RestoranContext> options)
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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-PMFJBLL\\MSSQL;Database=Restoran;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Cid);

            entity.Property(e => e.Cid).HasColumnName("CId");
            entity.Property(e => e.CPib)
                .HasMaxLength(40)
                .HasColumnName("C_PIB");
        });

        modelBuilder.Entity<Dish>(entity =>
        {
            entity.HasKey(e => e.Did);

            entity.Property(e => e.Did).HasColumnName("DId");
            entity.Property(e => e.Daviable).HasColumnName("DAviable");
            entity.Property(e => e.Dcalority)
                .HasDefaultValueSql("((1))")
                .HasColumnName("DCalority");
            entity.Property(e => e.Dname)
                .HasMaxLength(40)
                .HasColumnName("DName");
            entity.Property(e => e.Dprice)
                .HasDefaultValueSql("((1))")
                .HasColumnType("money")
                .HasColumnName("DPrice");
            entity.Property(e => e.Dtype)
                .HasMaxLength(10)
                .HasColumnName("DType");
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
            entity.HasKey(e => e.Iid);

            entity.Property(e => e.Iid).HasColumnName("IId");
            entity.Property(e => e.Iaviable).HasColumnName("IAviable");
            entity.Property(e => e.Iname)
                .HasMaxLength(30)
                .HasColumnName("IName");
            entity.Property(e => e.IpriceFromZavod)
                .HasDefaultValueSql("((1))")
                .HasColumnType("money")
                .HasColumnName("IPriceFromZavod");
            entity.Property(e => e.Iweight)
                .HasDefaultValueSql("((1))")
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("IWeight");
        });

        modelBuilder.Entity<Ordering>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.HasIndex(e => e.Ocid, "IX_Orderings_OCId");

            entity.HasIndex(e => e.OdnId, "IX_Orderings_ODnId");

            entity.HasIndex(e => e.Opid, "IX_Orderings_OPId");

            entity.HasIndex(e => e.Owid, "IX_Orderings_OWId");

            entity.Property(e => e.Oid).HasColumnName("OId");
            entity.Property(e => e.Ocid).HasColumnName("OCId");
            entity.Property(e => e.OdnId).HasColumnName("ODnId");
            entity.Property(e => e.Opid).HasColumnName("OPId");
            entity.Property(e => e.Oposition).HasColumnName("OPosition");
            entity.Property(e => e.Otimestamp)
                .HasDefaultValueSql("('2022 June 07 08:7:0')")
                .HasColumnType("datetime")
                .HasColumnName("OTimestamp");
            entity.Property(e => e.Owid).HasColumnName("OWId");

            entity.HasOne(d => d.Oc).WithMany(p => p.Orderings)
                .HasForeignKey(d => d.Ocid)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Odn).WithMany(p => p.Orderings)
                .HasForeignKey(d => d.OdnId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Op).WithMany(p => p.Orderings)
                .HasForeignKey(d => d.Opid)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Ow).WithMany(p => p.Orderings)
                .HasForeignKey(d => d.Owid)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Pid);

            entity.Property(e => e.Pid).HasColumnName("PId");
            entity.Property(e => e.Pchairs).HasColumnName("PChairs");
            entity.Property(e => e.ProomType)
                .HasMaxLength(10)
                .HasColumnName("PRoomType");
            entity.Property(e => e.Ptype)
                .HasMaxLength(30)
                .HasColumnName("PType");
        });

        modelBuilder.Entity<Recept>(entity =>
        {
            entity.HasKey(e => e.Rid);

            entity.HasIndex(e => e.Rdid, "IX_Recepts_RDId");

            entity.HasIndex(e => e.Riid, "IX_Recepts_RIId");

            entity.Property(e => e.Rid).HasColumnName("RId");
            entity.Property(e => e.RcookTime).HasColumnName("RCookTime");
            entity.Property(e => e.Rdid).HasColumnName("RDId");
            entity.Property(e => e.Riid).HasColumnName("RIId");

            entity.HasOne(d => d.Rd).WithMany(p => p.Recepts).HasForeignKey(d => d.Rdid);

            entity.HasOne(d => d.Ri).WithMany(p => p.Recepts).HasForeignKey(d => d.Riid);
        });

        modelBuilder.Entity<Restoran>(entity =>
        {
            entity.HasKey(e => e.Rid);

            entity.HasIndex(e => e.Raddress, "IX_Restorans_RAddress").IsUnique();

            entity.HasIndex(e => e.Rname, "IX_Restorans_RName").IsUnique();

            entity.Property(e => e.Rid).HasColumnName("RId");
            entity.Property(e => e.Raddress)
                .HasMaxLength(50)
                .HasColumnName("RAddress");
            entity.Property(e => e.Rclients)
                .HasDefaultValueSql("((0))")
                .HasColumnName("RClients");
            entity.Property(e => e.Rname)
                .HasMaxLength(30)
                .HasColumnName("RName");
            entity.Property(e => e.Rtables).HasColumnName("RTables");
            entity.Property(e => e.Rworkers).HasColumnName("RWorkers");
        });

        modelBuilder.Entity<WorkRank>(entity =>
        {
            entity.HasKey(e => e.WrId);

            entity.Property(e => e.WrFullName).HasMaxLength(30);
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.HasKey(e => e.Wid);

            entity.HasIndex(e => e.Wdocument, "IX_Workers_WDocument").IsUnique();

            entity.HasIndex(e => e.Wipn, "IX_Workers_WIpn").IsUnique();

            entity.HasIndex(e => e.Wpib, "IX_Workers_WPib").IsUnique();

            entity.HasIndex(e => e.WpostId, "IX_Workers_WPostId");

            entity.Property(e => e.Wid).HasColumnName("WId");
            entity.Property(e => e.Wdocument)
                .HasMaxLength(8)
                .HasColumnName("WDocument");
            entity.Property(e => e.Wipn)
                .HasMaxLength(8)
                .HasColumnName("WIpn");
            entity.Property(e => e.Wpib)
                .HasMaxLength(40)
                .HasColumnName("WPib");
            entity.Property(e => e.WpostId).HasColumnName("WPostId");
            entity.Property(e => e.Wsalary)
                .HasColumnType("money")
                .HasColumnName("WSalary");

            entity.HasOne(d => d.Wpost).WithMany(p => p.Workers).HasForeignKey(d => d.WpostId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
