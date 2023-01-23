﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Restoran3;

#nullable disable

namespace Restoran.Migrations
{
    [DbContext(typeof(RestoranDbContext))]
    [Migration("20230123113014_corrected")]
    partial class corrected
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Restoran3.Customer", b =>
                {
                    b.Property<short>("CId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("C_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("CId"));

                    b.Property<string>("CPib")
                        .IsRequired()
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("C_PIB");

                    b.HasKey("CId")
                        .HasName("PK_Customer");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("Restoran3.Dish", b =>
                {
                    b.Property<short>("DId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("D_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("DId"));

                    b.Property<bool?>("DAviable")
                        .HasColumnType("bit")
                        .HasColumnName("D_Aviable");

                    b.Property<int?>("DCalority")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("D_Calority")
                        .HasDefaultValueSql("((1))");

                    b.Property<short>("DDnid")
                        .HasColumnType("smallint");

                    b.Property<string>("DName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("D_Name");

                    b.Property<decimal?>("DPrice")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("money")
                        .HasColumnName("D_Price")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("DType")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("D_Type");

                    b.HasKey("DId")
                        .HasName("PK_Dish");

                    b.HasIndex("DDnid");

                    b.ToTable("Dish", (string)null);
                });

            modelBuilder.Entity("Restoran3.DishNumerate", b =>
                {
                    b.Property<short>("DnId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("DN_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("DnId"));

                    b.Property<int>("DnDishes")
                        .HasColumnType("int")
                        .HasColumnName("DN_Dishes");

                    b.Property<decimal?>("DnPrice")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("money")
                        .HasColumnName("DN_Price")
                        .HasDefaultValueSql("((10.2))");

                    b.Property<DateTime?>("DnTimestamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("DN_Timestamp")
                        .HasDefaultValueSql("('2022-06-07 07:07:07')");

                    b.HasKey("DnId")
                        .HasName("PK_DishNumerate");

                    b.ToTable("DishNumerate", (string)null);
                });

            modelBuilder.Entity("Restoran3.Ingridient", b =>
                {
                    b.Property<short>("IId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("I_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("IId"));

                    b.Property<bool?>("IAviable")
                        .HasColumnType("bit")
                        .HasColumnName("I_Aviable");

                    b.Property<string>("IName")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("I_Name");

                    b.Property<decimal?>("IPriceFromZavod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("money")
                        .HasColumnName("I_PriceFromZavod")
                        .HasDefaultValueSql("((1))");

                    b.Property<decimal?>("IWeight")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18, 0)")
                        .HasColumnName("I_Weight")
                        .HasDefaultValueSql("((1))");

                    b.HasKey("IId")
                        .HasName("PK_Ingridient");

                    b.ToTable("Ingridient", (string)null);
                });

            modelBuilder.Entity("Restoran3.Ordering", b =>
                {
                    b.Property<short>("OId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("O_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("OId"));

                    b.Property<short>("OCId")
                        .HasColumnType("smallint")
                        .HasColumnName("O_C_ID");

                    b.Property<short>("ODnId")
                        .HasColumnType("smallint")
                        .HasColumnName("O_DN_ID");

                    b.Property<short>("OPId")
                        .HasColumnType("smallint")
                        .HasColumnName("O_P_ID");

                    b.Property<byte>("OPosition")
                        .HasColumnType("tinyint")
                        .HasColumnName("O_Position");

                    b.Property<DateTime?>("OTimestamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("O_Timestamp")
                        .HasDefaultValueSql("('2022 June 07 08:7:0')");

                    b.Property<short>("OWId")
                        .HasColumnType("smallint")
                        .HasColumnName("O_W_ID");

                    b.HasKey("OId")
                        .HasName("PK_Ordering");

                    b.HasIndex("OCId");

                    b.HasIndex("ODnId");

                    b.HasIndex("OPId");

                    b.HasIndex("OWId");

                    b.ToTable("Ordering", (string)null);
                });

            modelBuilder.Entity("Restoran3.Position", b =>
                {
                    b.Property<short>("PId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("P_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("PId"));

                    b.Property<short>("PChairs")
                        .HasColumnType("smallint")
                        .HasColumnName("P_Chairs");

                    b.Property<string>("PRoomType")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("P_Room_Type");

                    b.Property<string>("PType")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("P_Type");

                    b.HasKey("PId")
                        .HasName("PK_Position");

                    b.ToTable("Position", (string)null);
                });

            modelBuilder.Entity("Restoran3.Recept", b =>
                {
                    b.Property<short>("RId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("R_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("RId"));

                    b.Property<TimeSpan?>("RCookTime")
                        .HasColumnType("time")
                        .HasColumnName("R_CookTime");

                    b.Property<short?>("RDId")
                        .HasColumnType("smallint")
                        .HasColumnName("R_D_ID");

                    b.Property<short?>("RIId")
                        .HasColumnType("smallint")
                        .HasColumnName("R_I_ID");

                    b.HasKey("RId")
                        .HasName("PK_Recept");

                    b.HasIndex("RDId");

                    b.HasIndex("RIId");

                    b.ToTable("Recept", (string)null);
                });

            modelBuilder.Entity("Restoran3.Restoran", b =>
                {
                    b.Property<short>("RId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("R_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("RId"));

                    b.Property<string>("RAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("R_Address");

                    b.Property<int?>("RClients")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("R_Clients")
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("RName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("R_Name");

                    b.Property<short>("RTables")
                        .HasColumnType("smallint")
                        .HasColumnName("R_Tables");

                    b.Property<int>("RWorkers")
                        .HasColumnType("int")
                        .HasColumnName("R_Workers");

                    b.HasKey("RId")
                        .HasName("PK_Restoran");

                    b.HasIndex(new[] { "RAddress" }, "UQ_Restoran_Address")
                        .IsUnique();

                    b.HasIndex(new[] { "RName" }, "UQ_Restoran_Name")
                        .IsUnique();

                    b.ToTable("Restoran", (string)null);
                });

            modelBuilder.Entity("Restoran3.WorkRank", b =>
                {
                    b.Property<short>("WrId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("WR_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("WrId"));

                    b.Property<string>("WrFullName")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("WR_FullName");

                    b.HasKey("WrId")
                        .HasName("PK_WorkRank");

                    b.ToTable("WorkRank", (string)null);
                });

            modelBuilder.Entity("Restoran3.Worker", b =>
                {
                    b.Property<short>("WId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("W_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("WId"));

                    b.Property<string>("WDocument")
                        .IsRequired()
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("varchar(8)")
                        .HasColumnName("W_Document");

                    b.Property<string>("WIpn")
                        .IsRequired()
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("varchar(8)")
                        .HasColumnName("W_IPN");

                    b.Property<string>("WPib")
                        .IsRequired()
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("W_PIB");

                    b.Property<short?>("WPostId")
                        .HasColumnType("smallint")
                        .HasColumnName("W_PostID");

                    b.Property<decimal>("WSalary")
                        .HasColumnType("money")
                        .HasColumnName("W_Salary");

                    b.HasKey("WId")
                        .HasName("PK_Worker");

                    b.HasIndex("WPostId");

                    b.HasIndex(new[] { "WDocument" }, "UQ_Worker_Doc")
                        .IsUnique();

                    b.HasIndex(new[] { "WIpn" }, "UQ_Worker_IPN")
                        .IsUnique();

                    b.HasIndex(new[] { "WPib" }, "UQ_Worker_PIB")
                        .IsUnique();

                    b.ToTable("Worker", (string)null);
                });

            modelBuilder.Entity("Restoran3.Dish", b =>
                {
                    b.HasOne("Restoran3.DishNumerate", "DDn")
                        .WithMany("Dishes")
                        .HasForeignKey("DDnid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Ordering_DN");

                    b.Navigation("DDn");
                });

            modelBuilder.Entity("Restoran3.Ordering", b =>
                {
                    b.HasOne("Restoran3.Customer", "OC")
                        .WithMany("Orderings")
                        .HasForeignKey("OCId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Ordering_C_ID");

                    b.HasOne("Restoran3.DishNumerate", "ODn")
                        .WithMany("Orderings")
                        .HasForeignKey("ODnId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Ordering_DN");

                    b.HasOne("Restoran3.Position", "OP")
                        .WithMany("Orderings")
                        .HasForeignKey("OPId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Ordering_P_ID");

                    b.HasOne("Restoran3.Worker", "OW")
                        .WithMany("Orderings")
                        .HasForeignKey("OWId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Ordering_W_ID");

                    b.Navigation("OC");

                    b.Navigation("ODn");

                    b.Navigation("OP");

                    b.Navigation("OW");
                });

            modelBuilder.Entity("Restoran3.Recept", b =>
                {
                    b.HasOne("Restoran3.Dish", "RD")
                        .WithMany("Recepts")
                        .HasForeignKey("RDId")
                        .HasConstraintName("FK_Recept_R_D_ID");

                    b.HasOne("Restoran3.Ingridient", "RI")
                        .WithMany("Recepts")
                        .HasForeignKey("RIId")
                        .HasConstraintName("FK_Recept_R_I_ID");

                    b.Navigation("RD");

                    b.Navigation("RI");
                });

            modelBuilder.Entity("Restoran3.Worker", b =>
                {
                    b.HasOne("Restoran3.WorkRank", "WPost")
                        .WithMany("Workers")
                        .HasForeignKey("WPostId")
                        .HasConstraintName("FK_Worker_PostID");

                    b.Navigation("WPost");
                });

            modelBuilder.Entity("Restoran3.Customer", b =>
                {
                    b.Navigation("Orderings");
                });

            modelBuilder.Entity("Restoran3.Dish", b =>
                {
                    b.Navigation("Recepts");
                });

            modelBuilder.Entity("Restoran3.DishNumerate", b =>
                {
                    b.Navigation("Dishes");

                    b.Navigation("Orderings");
                });

            modelBuilder.Entity("Restoran3.Ingridient", b =>
                {
                    b.Navigation("Recepts");
                });

            modelBuilder.Entity("Restoran3.Position", b =>
                {
                    b.Navigation("Orderings");
                });

            modelBuilder.Entity("Restoran3.WorkRank", b =>
                {
                    b.Navigation("Workers");
                });

            modelBuilder.Entity("Restoran3.Worker", b =>
                {
                    b.Navigation("Orderings");
                });
#pragma warning restore 612, 618
        }
    }
}
