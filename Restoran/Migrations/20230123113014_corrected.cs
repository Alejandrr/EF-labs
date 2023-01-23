using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restoran.Migrations
{
    /// <inheritdoc />
    public partial class corrected : Migration
    {
        /// <inheritdoc />
    //    protected override void Up(MigrationBuilder migrationBuilder)
    //    {
    //        migrationBuilder.CreateTable(
    //            name: "Customer",
    //            columns: table => new
    //            {
    //                CID = table.Column<short>(name: "C_ID", type: "smallint", nullable: false)
    //                    .Annotation("SqlServer:Identity", "1, 1"),
    //                CPIB = table.Column<string>(name: "C_PIB", type: "varchar(40)", unicode: false, maxLength: 40, nullable: false)
    //            },
    //            constraints: table =>
    //            {
    //                table.PrimaryKey("PK_Customer", x => x.CID);
    //            });

    //        migrationBuilder.CreateTable(
    //            name: "DishNumerate",
    //            columns: table => new
    //            {
    //                DNID = table.Column<short>(name: "DN_ID", type: "smallint", nullable: false)
    //                    .Annotation("SqlServer:Identity", "1, 1"),
    //                DNPrice = table.Column<decimal>(name: "DN_Price", type: "money", nullable: true, defaultValueSql: "((10.2))"),
    //                DNTimestamp = table.Column<DateTime>(name: "DN_Timestamp", type: "datetime", nullable: true, defaultValueSql: "('2022-06-07 07:07:07')"),
    //                DNDishes = table.Column<int>(name: "DN_Dishes", type: "int", nullable: false)
    //            },
    //            constraints: table =>
    //            {
    //                table.PrimaryKey("PK_DishNumerate", x => x.DNID);
    //            });

    //        migrationBuilder.CreateTable(
    //            name: "Ingridient",
    //            columns: table => new
    //            {
    //                IID = table.Column<short>(name: "I_ID", type: "smallint", nullable: false)
    //                    .Annotation("SqlServer:Identity", "1, 1"),
    //                IName = table.Column<string>(name: "I_Name", type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
    //                IWeight = table.Column<decimal>(name: "I_Weight", type: "decimal(18,0)", nullable: true, defaultValueSql: "((1))"),
    //                IAviable = table.Column<bool>(name: "I_Aviable", type: "bit", nullable: true),
    //                IPriceFromZavod = table.Column<decimal>(name: "I_PriceFromZavod", type: "money", nullable: true, defaultValueSql: "((1))")
    //            },
    //            constraints: table =>
    //            {
    //                table.PrimaryKey("PK_Ingridient", x => x.IID);
    //            });

    //        migrationBuilder.CreateTable(
    //            name: "Position",
    //            columns: table => new
    //            {
    //                PID = table.Column<short>(name: "P_ID", type: "smallint", nullable: false)
    //                    .Annotation("SqlServer:Identity", "1, 1"),
    //                PChairs = table.Column<short>(name: "P_Chairs", type: "smallint", nullable: false),
    //                PType = table.Column<string>(name: "P_Type", type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
    //                PRoomType = table.Column<string>(name: "P_Room_Type", type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
    //            },
    //            constraints: table =>
    //            {
    //                table.PrimaryKey("PK_Position", x => x.PID);
    //            });

    //        migrationBuilder.CreateTable(
    //            name: "Restoran",
    //            columns: table => new
    //            {
    //                RID = table.Column<short>(name: "R_ID", type: "smallint", nullable: false)
    //                    .Annotation("SqlServer:Identity", "1, 1"),
    //                RName = table.Column<string>(name: "R_Name", type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
    //                RAddress = table.Column<string>(name: "R_Address", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
    //                RTables = table.Column<short>(name: "R_Tables", type: "smallint", nullable: false),
    //                RWorkers = table.Column<int>(name: "R_Workers", type: "int", nullable: false),
    //                RClients = table.Column<int>(name: "R_Clients", type: "int", nullable: true, defaultValueSql: "((0))")
    //            },
    //            constraints: table =>
    //            {
    //                table.PrimaryKey("PK_Restoran", x => x.RID);
    //            });

    //        migrationBuilder.CreateTable(
    //            name: "WorkRank",
    //            columns: table => new
    //            {
    //                WRID = table.Column<short>(name: "WR_ID", type: "smallint", nullable: false)
    //                    .Annotation("SqlServer:Identity", "1, 1"),
    //                WRFullName = table.Column<string>(name: "WR_FullName", type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
    //            },
    //            constraints: table =>
    //            {
    //                table.PrimaryKey("PK_WorkRank", x => x.WRID);
    //            });

    //        migrationBuilder.CreateTable(
    //            name: "Dish",
    //            columns: table => new
    //            {
    //                DID = table.Column<short>(name: "D_ID", type: "smallint", nullable: false)
    //                    .Annotation("SqlServer:Identity", "1, 1"),
    //                DDnid = table.Column<short>(type: "smallint", nullable: false),
    //                DName = table.Column<string>(name: "D_Name", type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
    //                DType = table.Column<string>(name: "D_Type", type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
    //                DAviable = table.Column<bool>(name: "D_Aviable", type: "bit", nullable: true),
    //                DCalority = table.Column<int>(name: "D_Calority", type: "int", nullable: true, defaultValueSql: "((1))"),
    //                DPrice = table.Column<decimal>(name: "D_Price", type: "money", nullable: true, defaultValueSql: "((1))")
    //            },
    //            constraints: table =>
    //            {
    //                table.PrimaryKey("PK_Dish", x => x.DID);
    //                table.ForeignKey(
    //                    name: "FK_Ordering_DN",
    //                    column: x => x.DDnid,
    //                    principalTable: "DishNumerate",
    //                    principalColumn: "DN_ID",
    //                    onDelete: ReferentialAction.Restrict);
    //            });

    //        migrationBuilder.CreateTable(
    //            name: "Worker",
    //            columns: table => new
    //            {
    //                WID = table.Column<short>(name: "W_ID", type: "smallint", nullable: false)
    //                    .Annotation("SqlServer:Identity", "1, 1"),
    //                WPIB = table.Column<string>(name: "W_PIB", type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
    //                WDocument = table.Column<string>(name: "W_Document", type: "varchar(8)", unicode: false, maxLength: 8, nullable: false),
    //                WIPN = table.Column<string>(name: "W_IPN", type: "varchar(8)", unicode: false, maxLength: 8, nullable: false),
    //                WPostID = table.Column<short>(name: "W_PostID", type: "smallint", nullable: true),
    //                WSalary = table.Column<decimal>(name: "W_Salary", type: "money", nullable: false)
    //            },
    //            constraints: table =>
    //            {
    //                table.PrimaryKey("PK_Worker", x => x.WID);
    //                table.ForeignKey(
    //                    name: "FK_Worker_PostID",
    //                    column: x => x.WPostID,
    //                    principalTable: "WorkRank",
    //                    principalColumn: "WR_ID");
    //            });

    //        migrationBuilder.CreateTable(
    //            name: "Recept",
    //            columns: table => new
    //            {
    //                RID = table.Column<short>(name: "R_ID", type: "smallint", nullable: false)
    //                    .Annotation("SqlServer:Identity", "1, 1"),
    //                RCookTime = table.Column<TimeSpan>(name: "R_CookTime", type: "time", nullable: true),
    //                RDID = table.Column<short>(name: "R_D_ID", type: "smallint", nullable: true),
    //                RIID = table.Column<short>(name: "R_I_ID", type: "smallint", nullable: true)
    //            },
    //            constraints: table =>
    //            {
    //                table.PrimaryKey("PK_Recept", x => x.RID);
    //                table.ForeignKey(
    //                    name: "FK_Recept_R_D_ID",
    //                    column: x => x.RDID,
    //                    principalTable: "Dish",
    //                    principalColumn: "D_ID");
    //                table.ForeignKey(
    //                    name: "FK_Recept_R_I_ID",
    //                    column: x => x.RIID,
    //                    principalTable: "Ingridient",
    //                    principalColumn: "I_ID");
    //            });

    //        migrationBuilder.CreateTable(
    //            name: "Ordering",
    //            columns: table => new
    //            {
    //                OID = table.Column<short>(name: "O_ID", type: "smallint", nullable: false)
    //                    .Annotation("SqlServer:Identity", "1, 1"),
    //                OCID = table.Column<short>(name: "O_C_ID", type: "smallint", nullable: false),
    //                OWID = table.Column<short>(name: "O_W_ID", type: "smallint", nullable: false),
    //                OPID = table.Column<short>(name: "O_P_ID", type: "smallint", nullable: false),
    //                ODNID = table.Column<short>(name: "O_DN_ID", type: "smallint", nullable: false),
    //                OTimestamp = table.Column<DateTime>(name: "O_Timestamp", type: "datetime", nullable: true, defaultValueSql: "('2022 June 07 08:7:0')"),
    //                OPosition = table.Column<byte>(name: "O_Position", type: "tinyint", nullable: false)
    //            },
    //            constraints: table =>
    //            {
    //                table.PrimaryKey("PK_Ordering", x => x.OID);
    //                table.ForeignKey(
    //                    name: "FK_Ordering_C_ID",
    //                    column: x => x.OCID,
    //                    principalTable: "Customer",
    //                    principalColumn: "C_ID",
    //                    onDelete: ReferentialAction.Restrict);
    //                table.ForeignKey(
    //                    name: "FK_Ordering_DN",
    //                    column: x => x.ODNID,
    //                    principalTable: "DishNumerate",
    //                    principalColumn: "DN_ID",
    //                    onDelete: ReferentialAction.Restrict);
    //                table.ForeignKey(
    //                    name: "FK_Ordering_P_ID",
    //                    column: x => x.OPID,
    //                    principalTable: "Position",
    //                    principalColumn: "P_ID",
    //                    onDelete: ReferentialAction.Restrict);
    //                table.ForeignKey(
    //                    name: "FK_Ordering_W_ID",
    //                    column: x => x.OWID,
    //                    principalTable: "Worker",
    //                    principalColumn: "W_ID",
    //                    onDelete: ReferentialAction.Restrict);
    //            });

    //        migrationBuilder.CreateIndex(
    //            name: "IX_Dish_DDnid",
    //            table: "Dish",
    //            column: "DDnid");

    //        migrationBuilder.CreateIndex(
    //            name: "IX_Ordering_O_C_ID",
    //            table: "Ordering",
    //            column: "O_C_ID");

    //        migrationBuilder.CreateIndex(
    //            name: "IX_Ordering_O_DN_ID",
    //            table: "Ordering",
    //            column: "O_DN_ID");

    //        migrationBuilder.CreateIndex(
    //            name: "IX_Ordering_O_P_ID",
    //            table: "Ordering",
    //            column: "O_P_ID");

    //        migrationBuilder.CreateIndex(
    //            name: "IX_Ordering_O_W_ID",
    //            table: "Ordering",
    //            column: "O_W_ID");

    //        migrationBuilder.CreateIndex(
    //            name: "IX_Recept_R_D_ID",
    //            table: "Recept",
    //            column: "R_D_ID");

    //        migrationBuilder.CreateIndex(
    //            name: "IX_Recept_R_I_ID",
    //            table: "Recept",
    //            column: "R_I_ID");

    //        migrationBuilder.CreateIndex(
    //            name: "UQ_Restoran_Address",
    //            table: "Restoran",
    //            column: "R_Address",
    //            unique: true);

    //        migrationBuilder.CreateIndex(
    //            name: "UQ_Restoran_Name",
    //            table: "Restoran",
    //            column: "R_Name",
    //            unique: true);

    //        migrationBuilder.CreateIndex(
    //            name: "IX_Worker_W_PostID",
    //            table: "Worker",
    //            column: "W_PostID");

    //        migrationBuilder.CreateIndex(
    //            name: "UQ_Worker_Doc",
    //            table: "Worker",
    //            column: "W_Document",
    //            unique: true);

    //        migrationBuilder.CreateIndex(
    //            name: "UQ_Worker_IPN",
    //            table: "Worker",
    //            column: "W_IPN",
    //            unique: true);

    //        migrationBuilder.CreateIndex(
    //            name: "UQ_Worker_PIB",
    //            table: "Worker",
    //            column: "W_PIB",
    //            unique: true);
    //    }

    //    /// <inheritdoc />
    //    protected override void Down(MigrationBuilder migrationBuilder)
    //    {
    //        migrationBuilder.DropTable(
    //            name: "Ordering");

    //        migrationBuilder.DropTable(
    //            name: "Recept");

    //        migrationBuilder.DropTable(
    //            name: "Restoran");

    //        migrationBuilder.DropTable(
    //            name: "Customer");

    //        migrationBuilder.DropTable(
    //            name: "Position");

    //        migrationBuilder.DropTable(
    //            name: "Worker");

    //        migrationBuilder.DropTable(
    //            name: "Dish");

    //        migrationBuilder.DropTable(
    //            name: "Ingridient");

    //        migrationBuilder.DropTable(
    //            name: "WorkRank");

    //        migrationBuilder.DropTable(
    //            name: "DishNumerate");
    //    }
    //}
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<short>(
            name: "DDnid",
            table: "Dish",
            type: "smallint",
            nullable: false,
            defaultValue: (short)0);

        migrationBuilder.CreateIndex(
            name: "IX_Dish_DDnid",
            table: "Dish",
            column: "DDnid");

        migrationBuilder.AddForeignKey(
            name: "FK_Ordering_DN",
            table: "Dish",
            column: "DDnid",
            principalTable: "DishNumerate",
            principalColumn: "DN_ID",
            onDelete: ReferentialAction.Restrict);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Ordering_DN",
            table: "Dish");

        migrationBuilder.DropIndex(
            name: "IX_Dish_DDnid",
            table: "Dish");

        migrationBuilder.DropColumn(
            name: "DDnid",
            table: "Dish");
    }
}
}
