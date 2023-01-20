using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restoran.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPIB = table.Column<string>(name: "C_PIB", type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CId);
                });

            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    DId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    DType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DAviable = table.Column<bool>(type: "bit", nullable: true),
                    DCalority = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))"),
                    DPrice = table.Column<decimal>(type: "money", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.DId);
                });

            migrationBuilder.CreateTable(
                name: "DishNumerates",
                columns: table => new
                {
                    DnId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DnPrice = table.Column<decimal>(type: "money", nullable: true, defaultValueSql: "((10.2))"),
                    DnTimestamp = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "('2022-06-07 07:07:00')"),
                    DnDishes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishNumerates", x => x.DnId);
                });

            migrationBuilder.CreateTable(
                name: "Ingridients",
                columns: table => new
                {
                    IId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IWeight = table.Column<decimal>(type: "decimal(18,0)", nullable: true, defaultValueSql: "((1))"),
                    IAviable = table.Column<bool>(type: "bit", nullable: true),
                    IPriceFromZavod = table.Column<decimal>(type: "money", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingridients", x => x.IId);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    PId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PChairs = table.Column<short>(type: "smallint", nullable: false),
                    PType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PRoomType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.PId);
                });

            migrationBuilder.CreateTable(
                name: "Restorans",
                columns: table => new
                {
                    RId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    RAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RTables = table.Column<short>(type: "smallint", nullable: false),
                    RWorkers = table.Column<int>(type: "int", nullable: false),
                    RClients = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restorans", x => x.RId);
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

            migrationBuilder.CreateTable(
                name: "Recepts",
                columns: table => new
                {
                    RId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RCookTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    RDId = table.Column<short>(type: "smallint", nullable: true),
                    RIId = table.Column<short>(type: "smallint", nullable: true)
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
                name: "Workers",
                columns: table => new
                {
                    WId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WPib = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    WDocument = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    WIpn = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    WSalary = table.Column<decimal>(type: "money", nullable: false),
                    WPostId = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.WId);
                    table.ForeignKey(
                        name: "FK_Workers_WorkRanks_WPostId",
                        column: x => x.WPostId,
                        principalTable: "WorkRanks",
                        principalColumn: "WrId");
                });

            migrationBuilder.CreateTable(
                name: "Orderings",
                columns: table => new
                {
                    OId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OCId = table.Column<short>(type: "smallint", nullable: false),
                    OWId = table.Column<short>(type: "smallint", nullable: false),
                    OPId = table.Column<short>(type: "smallint", nullable: false),
                    ODnId = table.Column<short>(type: "smallint", nullable: false),
                    OTimestamp = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "('2022 June 07 08:7:0')"),
                    OPosition = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orderings", x => x.OId);
                    table.ForeignKey(
                        name: "FK_Orderings_Customers_OCId",
                        column: x => x.OCId,
                        principalTable: "Customers",
                        principalColumn: "CId");
                    table.ForeignKey(
                        name: "FK_Orderings_DishNumerates_ODnId",
                        column: x => x.ODnId,
                        principalTable: "DishNumerates",
                        principalColumn: "DnId");
                    table.ForeignKey(
                        name: "FK_Orderings_Positions_OPId",
                        column: x => x.OPId,
                        principalTable: "Positions",
                        principalColumn: "PId");
                    table.ForeignKey(
                        name: "FK_Orderings_Workers_OWId",
                        column: x => x.OWId,
                        principalTable: "Workers",
                        principalColumn: "WId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orderings_OCId",
                table: "Orderings",
                column: "OCId");

            migrationBuilder.CreateIndex(
                name: "IX_Orderings_ODnId",
                table: "Orderings",
                column: "ODnId");

            migrationBuilder.CreateIndex(
                name: "IX_Orderings_OPId",
                table: "Orderings",
                column: "OPId");

            migrationBuilder.CreateIndex(
                name: "IX_Orderings_OWId",
                table: "Orderings",
                column: "OWId");

            migrationBuilder.CreateIndex(
                name: "IX_Recepts_RDId",
                table: "Recepts",
                column: "RDId");

            migrationBuilder.CreateIndex(
                name: "IX_Recepts_RIId",
                table: "Recepts",
                column: "RIId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orderings");

            migrationBuilder.DropTable(
                name: "Recepts");

            migrationBuilder.DropTable(
                name: "Restorans");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "DishNumerates");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Ingridients");

            migrationBuilder.DropTable(
                name: "WorkRanks");
        }
    }
}
