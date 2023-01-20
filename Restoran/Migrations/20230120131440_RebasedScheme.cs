using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restoran.Migrations
{
    /// <inheritdoc />
    public partial class RebasedScheme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orderings_Customers_OCId",
                table: "Orderings");

            migrationBuilder.DropForeignKey(
                name: "FK_Orderings_DishNumerates_ODnId",
                table: "Orderings");

            migrationBuilder.DropForeignKey(
                name: "FK_Orderings_Positions_OPId",
                table: "Orderings");

            migrationBuilder.DropForeignKey(
                name: "FK_Orderings_Workers_OWId",
                table: "Orderings");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_WorkRanks_WPostId",
                table: "Workers");

            migrationBuilder.DropTable(
                name: "Recepts");

            migrationBuilder.DropTable(
                name: "WorkRanks");

            migrationBuilder.DropIndex(
                name: "IX_Workers_WDocument",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_WIpn",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_WPib",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_WPostId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Restorans_RAddress",
                table: "Restorans");

            migrationBuilder.DropIndex(
                name: "IX_Restorans_RName",
                table: "Restorans");

            migrationBuilder.DropIndex(
                name: "IX_Orderings_ODnId",
                table: "Orderings");

            migrationBuilder.DropColumn(
                name: "WPib",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "WPostId",
                table: "Workers");

            migrationBuilder.RenameColumn(
                name: "WId",
                table: "Workers",
                newName: "CId");

            migrationBuilder.RenameColumn(
                name: "C_PIB",
                table: "Customers",
                newName: "CPib");

            migrationBuilder.AlterColumn<decimal>(
                name: "WSalary",
                table: "Workers",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<string>(
                name: "WIpn",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                name: "WDocument",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8);

            migrationBuilder.AddColumn<string>(
                name: "CPib",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WRank",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RName",
                table: "Restorans",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<int>(
                name: "RClients",
                table: "Restorans",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValueSql: "((0))");

            migrationBuilder.AlterColumn<string>(
                name: "RAddress",
                table: "Restorans",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "PType",
                table: "Positions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PRoomType",
                table: "Positions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OTimestamp",
                table: "Orderings",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "('2022 June 07 08:7:0')");

            migrationBuilder.AddColumn<short>(
                name: "DishNumerateDnId",
                table: "Orderings",
                type: "smallint",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "IWeight",
                table: "Ingridients",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)",
                oldNullable: true,
                oldDefaultValueSql: "((1))");

            migrationBuilder.AlterColumn<decimal>(
                name: "IPriceFromZavod",
                table: "Ingridients",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldNullable: true,
                oldDefaultValueSql: "((1))");

            migrationBuilder.AlterColumn<string>(
                name: "IName",
                table: "Ingridients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DnTimestamp",
                table: "DishNumerates",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "('2022-06-07 07:07:00')");

            migrationBuilder.AlterColumn<decimal>(
                name: "DnPrice",
                table: "DishNumerates",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldNullable: true,
                oldDefaultValueSql: "((10.2))");

            migrationBuilder.AddColumn<short>(
                name: "DishDId",
                table: "DishNumerates",
                type: "smallint",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DType",
                table: "Dishes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DPrice",
                table: "Dishes",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldNullable: true,
                oldDefaultValueSql: "((1))");

            migrationBuilder.AlterColumn<string>(
                name: "DName",
                table: "Dishes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<int>(
                name: "DCalority",
                table: "Dishes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValueSql: "((1))");

            migrationBuilder.AddColumn<short>(
                name: "IngridientIId",
                table: "Dishes",
                type: "smallint",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CPib",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.CreateIndex(
                name: "IX_Orderings_DishNumerateDnId",
                table: "Orderings",
                column: "DishNumerateDnId");

            migrationBuilder.CreateIndex(
                name: "IX_DishNumerates_DishDId",
                table: "DishNumerates",
                column: "DishDId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_IngridientIId",
                table: "Dishes",
                column: "IngridientIId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Ingridients_IngridientIId",
                table: "Dishes",
                column: "IngridientIId",
                principalTable: "Ingridients",
                principalColumn: "IId");

            migrationBuilder.AddForeignKey(
                name: "FK_DishNumerates_Dishes_DishDId",
                table: "DishNumerates",
                column: "DishDId",
                principalTable: "Dishes",
                principalColumn: "DId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orderings_Customers_OCId",
                table: "Orderings",
                column: "OCId",
                principalTable: "Customers",
                principalColumn: "CId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orderings_DishNumerates_DishNumerateDnId",
                table: "Orderings",
                column: "DishNumerateDnId",
                principalTable: "DishNumerates",
                principalColumn: "DnId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orderings_Positions_OPId",
                table: "Orderings",
                column: "OPId",
                principalTable: "Positions",
                principalColumn: "PId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orderings_Workers_OWId",
                table: "Orderings",
                column: "OWId",
                principalTable: "Workers",
                principalColumn: "CId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Ingridients_IngridientIId",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_DishNumerates_Dishes_DishDId",
                table: "DishNumerates");

            migrationBuilder.DropForeignKey(
                name: "FK_Orderings_Customers_OCId",
                table: "Orderings");

            migrationBuilder.DropForeignKey(
                name: "FK_Orderings_DishNumerates_DishNumerateDnId",
                table: "Orderings");

            migrationBuilder.DropForeignKey(
                name: "FK_Orderings_Positions_OPId",
                table: "Orderings");

            migrationBuilder.DropForeignKey(
                name: "FK_Orderings_Workers_OWId",
                table: "Orderings");

            migrationBuilder.DropIndex(
                name: "IX_Orderings_DishNumerateDnId",
                table: "Orderings");

            migrationBuilder.DropIndex(
                name: "IX_DishNumerates_DishDId",
                table: "DishNumerates");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_IngridientIId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "CPib",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "WRank",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "DishNumerateDnId",
                table: "Orderings");

            migrationBuilder.DropColumn(
                name: "DishDId",
                table: "DishNumerates");

            migrationBuilder.DropColumn(
                name: "IngridientIId",
                table: "Dishes");

            migrationBuilder.RenameColumn(
                name: "CId",
                table: "Workers",
                newName: "WId");

            migrationBuilder.RenameColumn(
                name: "CPib",
                table: "Customers",
                newName: "C_PIB");

            migrationBuilder.AlterColumn<decimal>(
                name: "WSalary",
                table: "Workers",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "WIpn",
                table: "Workers",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "WDocument",
                table: "Workers",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "WPib",
                table: "Workers",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<short>(
                name: "WPostId",
                table: "Workers",
                type: "smallint",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RName",
                table: "Restorans",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "RClients",
                table: "Restorans",
                type: "int",
                nullable: true,
                defaultValueSql: "((0))",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RAddress",
                table: "Restorans",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PType",
                table: "Positions",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PRoomType",
                table: "Positions",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OTimestamp",
                table: "Orderings",
                type: "datetime",
                nullable: true,
                defaultValueSql: "('2022 June 07 08:7:0')",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "IWeight",
                table: "Ingridients",
                type: "decimal(18,0)",
                nullable: true,
                defaultValueSql: "((1))",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "IPriceFromZavod",
                table: "Ingridients",
                type: "money",
                nullable: true,
                defaultValueSql: "((1))",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IName",
                table: "Ingridients",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DnTimestamp",
                table: "DishNumerates",
                type: "datetime",
                nullable: true,
                defaultValueSql: "('2022-06-07 07:07:00')",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DnPrice",
                table: "DishNumerates",
                type: "money",
                nullable: true,
                defaultValueSql: "((10.2))",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DType",
                table: "Dishes",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DPrice",
                table: "Dishes",
                type: "money",
                nullable: true,
                defaultValueSql: "((1))",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DName",
                table: "Dishes",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "DCalority",
                table: "Dishes",
                type: "int",
                nullable: true,
                defaultValueSql: "((1))",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "C_PIB",
                table: "Customers",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Recepts",
                columns: table => new
                {
                    RId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RDId = table.Column<short>(type: "smallint", nullable: true),
                    RIId = table.Column<short>(type: "smallint", nullable: true),
                    RCookTime = table.Column<TimeSpan>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recepts", x => x.RId);
                    table.ForeignKey(
                        name: "FK_Recepts_Dishes_RDId",
                        column: x => x.RDId,
                        principalTable: "Dishes",
                        principalColumn: "DId");
                    table.ForeignKey(
                        name: "FK_Recepts_Ingridients_RIId",
                        column: x => x.RIId,
                        principalTable: "Ingridients",
                        principalColumn: "IId");
                });

            migrationBuilder.CreateTable(
                name: "WorkRanks",
                columns: table => new
                {
                    WrId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WrFullName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkRanks", x => x.WrId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workers_WDocument",
                table: "Workers",
                column: "WDocument",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workers_WIpn",
                table: "Workers",
                column: "WIpn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workers_WPib",
                table: "Workers",
                column: "WPib",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workers_WPostId",
                table: "Workers",
                column: "WPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Restorans_RAddress",
                table: "Restorans",
                column: "RAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restorans_RName",
                table: "Restorans",
                column: "RName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orderings_ODnId",
                table: "Orderings",
                column: "ODnId");

            migrationBuilder.CreateIndex(
                name: "IX_Recepts_RDId",
                table: "Recepts",
                column: "RDId");

            migrationBuilder.CreateIndex(
                name: "IX_Recepts_RIId",
                table: "Recepts",
                column: "RIId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orderings_Customers_OCId",
                table: "Orderings",
                column: "OCId",
                principalTable: "Customers",
                principalColumn: "CId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orderings_DishNumerates_ODnId",
                table: "Orderings",
                column: "ODnId",
                principalTable: "DishNumerates",
                principalColumn: "DnId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orderings_Positions_OPId",
                table: "Orderings",
                column: "OPId",
                principalTable: "Positions",
                principalColumn: "PId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orderings_Workers_OWId",
                table: "Orderings",
                column: "OWId",
                principalTable: "Workers",
                principalColumn: "WId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_WorkRanks_WPostId",
                table: "Workers",
                column: "WPostId",
                principalTable: "WorkRanks",
                principalColumn: "WrId");
        }
    }
}
