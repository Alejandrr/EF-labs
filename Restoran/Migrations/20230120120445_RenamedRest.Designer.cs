// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Restoran;

#nullable disable

namespace Restoran.Migrations
{
    [DbContext(typeof(RestoranDbContext))]
    [Migration("20230120120445_RenamedRest")]
    partial class RenamedRest
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Restoran.Customer", b =>
                {
                    b.Property<short>("CId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("CId"));

                    b.Property<string>("CPib")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("C_PIB");

                    b.HasKey("CId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Restoran.Dish", b =>
                {
                    b.Property<short>("DId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("DId"));

                    b.Property<bool?>("DAviable")
                        .HasColumnType("bit");

                    b.Property<int?>("DCalority")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("DName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<decimal?>("DPrice")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("money")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("DType")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("DId");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("Restoran.DishNumerate", b =>
                {
                    b.Property<short>("DnId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("DnId"));

                    b.Property<int>("DnDishes")
                        .HasColumnType("int");

                    b.Property<decimal?>("DnPrice")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("money")
                        .HasDefaultValueSql("((10.2))");

                    b.Property<DateTime?>("DnTimestamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("('2022-06-07 07:07:00')");

                    b.HasKey("DnId");

                    b.ToTable("DishNumerates");
                });

            modelBuilder.Entity("Restoran.Ingridient", b =>
                {
                    b.Property<short>("IId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("IId"));

                    b.Property<bool?>("IAviable")
                        .HasColumnType("bit");

                    b.Property<string>("IName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal?>("IPriceFromZavod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("money")
                        .HasDefaultValueSql("((1))");

                    b.Property<decimal?>("IWeight")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18, 0)")
                        .HasDefaultValueSql("((1))");

                    b.HasKey("IId");

                    b.ToTable("Ingridients");
                });

            modelBuilder.Entity("Restoran.Ordering", b =>
                {
                    b.Property<short>("OId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("OId"));

                    b.Property<short>("OCId")
                        .HasColumnType("smallint");

                    b.Property<short>("ODnId")
                        .HasColumnType("smallint");

                    b.Property<short>("OPId")
                        .HasColumnType("smallint");

                    b.Property<byte>("OPosition")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("OTimestamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("('2022 June 07 08:7:0')");

                    b.Property<short>("OWId")
                        .HasColumnType("smallint");

                    b.HasKey("OId");

                    b.HasIndex("OCId");

                    b.HasIndex("ODnId");

                    b.HasIndex("OPId");

                    b.HasIndex("OWId");

                    b.ToTable("Orderings");
                });

            modelBuilder.Entity("Restoran.Position", b =>
                {
                    b.Property<short>("PId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("PId"));

                    b.Property<short>("PChairs")
                        .HasColumnType("smallint");

                    b.Property<string>("PRoomType")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("PType")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("PId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("Restoran.Recept", b =>
                {
                    b.Property<short>("RId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("RId"));

                    b.Property<TimeSpan?>("RCookTime")
                        .HasColumnType("time");

                    b.Property<short?>("RDId")
                        .HasColumnType("smallint");

                    b.Property<short?>("RIId")
                        .HasColumnType("smallint");

                    b.HasKey("RId");

                    b.HasIndex("RDId");

                    b.HasIndex("RIId");

                    b.ToTable("Recepts");
                });

            modelBuilder.Entity("Restoran.Restoraunt", b =>
                {
                    b.Property<short>("RId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("RId"));

                    b.Property<string>("RAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("RClients")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("RName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<short>("RTables")
                        .HasColumnType("smallint");

                    b.Property<int>("RWorkers")
                        .HasColumnType("int");

                    b.HasKey("RId");

                    b.HasIndex("RAddress")
                        .IsUnique();

                    b.HasIndex("RName")
                        .IsUnique();

                    b.ToTable("Restorans");
                });

            modelBuilder.Entity("Restoran.WorkRank", b =>
                {
                    b.Property<short>("WrId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("WrId"));

                    b.Property<string>("WrFullName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("WrId");

                    b.ToTable("WorkRanks");
                });

            modelBuilder.Entity("Restoran.Worker", b =>
                {
                    b.Property<short>("WId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("WId"));

                    b.Property<string>("WDocument")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("WIpn")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("WPib")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<short?>("WPostId")
                        .HasColumnType("smallint");

                    b.Property<decimal>("WSalary")
                        .HasColumnType("money");

                    b.HasKey("WId");

                    b.HasIndex("WDocument")
                        .IsUnique();

                    b.HasIndex("WIpn")
                        .IsUnique();

                    b.HasIndex("WPib")
                        .IsUnique();

                    b.HasIndex("WPostId");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("Restoran.Ordering", b =>
                {
                    b.HasOne("Restoran.Customer", "OC")
                        .WithMany("Orderings")
                        .HasForeignKey("OCId")
                        .IsRequired();

                    b.HasOne("Restoran.DishNumerate", "ODn")
                        .WithMany("Orderings")
                        .HasForeignKey("ODnId")
                        .IsRequired();

                    b.HasOne("Restoran.Position", "OP")
                        .WithMany("Orderings")
                        .HasForeignKey("OPId")
                        .IsRequired();

                    b.HasOne("Restoran.Worker", "OW")
                        .WithMany("Orderings")
                        .HasForeignKey("OWId")
                        .IsRequired();

                    b.Navigation("OC");

                    b.Navigation("ODn");

                    b.Navigation("OP");

                    b.Navigation("OW");
                });

            modelBuilder.Entity("Restoran.Recept", b =>
                {
                    b.HasOne("Restoran.Dish", "RD")
                        .WithMany("Recepts")
                        .HasForeignKey("RDId");

                    b.HasOne("Restoran.Ingridient", "RI")
                        .WithMany("Recepts")
                        .HasForeignKey("RIId");

                    b.Navigation("RD");

                    b.Navigation("RI");
                });

            modelBuilder.Entity("Restoran.Worker", b =>
                {
                    b.HasOne("Restoran.WorkRank", "WPost")
                        .WithMany("Workers")
                        .HasForeignKey("WPostId");

                    b.Navigation("WPost");
                });

            modelBuilder.Entity("Restoran.Customer", b =>
                {
                    b.Navigation("Orderings");
                });

            modelBuilder.Entity("Restoran.Dish", b =>
                {
                    b.Navigation("Recepts");
                });

            modelBuilder.Entity("Restoran.DishNumerate", b =>
                {
                    b.Navigation("Orderings");
                });

            modelBuilder.Entity("Restoran.Ingridient", b =>
                {
                    b.Navigation("Recepts");
                });

            modelBuilder.Entity("Restoran.Position", b =>
                {
                    b.Navigation("Orderings");
                });

            modelBuilder.Entity("Restoran.WorkRank", b =>
                {
                    b.Navigation("Workers");
                });

            modelBuilder.Entity("Restoran.Worker", b =>
                {
                    b.Navigation("Orderings");
                });
#pragma warning restore 612, 618
        }
    }
}
