using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restoran.Migrations
{
    /// <inheritdoc />
    public partial class Rebased : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orderings_Positions_OPId",
                table: "Orderings");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_WorkRanks_WPostId",
                table: "Workers");

            migrationBuilder.DropTable(
                name: "Recepts");

            migrationBuilder.DropTable(
                name: "WorkRanks");

            migrationBuilder.DropIndex(
                name: "IX_Workers_WPostId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Orderings_OPId",
                table: "Orderings");

            migrationBuilder.DropColumn(
                name: "WPostId",
                table: "Workers");

            migrationBuilder.RenameIndex(
                name: "IX_Workers_WPib",
                table: "Workers",
                newName: "Workers_WPib");

            migrationBuilder.RenameIndex(
                name: "IX_Workers_WIpn",
                table: "Workers",
                newName: "Workers_WIpn");

            migrationBuilder.RenameIndex(
                name: "IX_Workers_WDocument",
                table: "Workers",
                newName: "Workers_WDocument");

            migrationBuilder.RenameIndex(
                name: "IX_Restorans_RName",
                table: "Restorans",
                newName: "Restorans_RName");

            migrationBuilder.RenameIndex(
                name: "IX_Restorans_RAddress",
                table: "Restorans",
                newName: "Restorans_RAddress");

            migrationBuilder.AddColumn<string>(
                name: "WRank",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "DishDId",
                table: "DishNumerates",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "IngridientIId",
                table: "Dishes",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddCheckConstraint(
                name: "PRoomType",
                table: "Positions",
                sql: "PRoomType IN('For love','Bathroom','Bar','Terrasa')");

            migrationBuilder.AddCheckConstraint(
                name: "PType",
                table: "Positions",
                sql: "P_Type IN('Small', 'Medium', 'Large')");

            migrationBuilder.CreateIndex(
                name: "IX_Orderings_OPId",
                table: "Orderings",
                column: "OPId",
                unique: true);

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
                name: "FK_Orderings_Positions_OPId",
                table: "Orderings",
                column: "OPId",
                principalTable: "Positions",
                principalColumn: "PId",
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
                name: "FK_Orderings_Positions_OPId",
                table: "Orderings");

            migrationBuilder.DropCheckConstraint(
                name: "PRoomType",
                table: "Positions");

            migrationBuilder.DropCheckConstraint(
                name: "PType",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Orderings_OPId",
                table: "Orderings");

            migrationBuilder.DropIndex(
                name: "IX_DishNumerates_DishDId",
                table: "DishNumerates");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_IngridientIId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "WRank",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "DishDId",
                table: "DishNumerates");

            migrationBuilder.DropColumn(
                name: "IngridientIId",
                table: "Dishes");

            migrationBuilder.RenameIndex(
                name: "Workers_WPib",
                table: "Workers",
                newName: "IX_Workers_WPib");

            migrationBuilder.RenameIndex(
                name: "Workers_WIpn",
                table: "Workers",
                newName: "IX_Workers_WIpn");

            migrationBuilder.RenameIndex(
                name: "Workers_WDocument",
                table: "Workers",
                newName: "IX_Workers_WDocument");

            migrationBuilder.RenameIndex(
                name: "Restorans_RName",
                table: "Restorans",
                newName: "IX_Restorans_RName");

            migrationBuilder.RenameIndex(
                name: "Restorans_RAddress",
                table: "Restorans",
                newName: "IX_Restorans_RAddress");

            migrationBuilder.AddColumn<short>(
                name: "WPostId",
                table: "Workers",
                type: "smallint",
                nullable: true);

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
                name: "IX_Workers_WPostId",
                table: "Workers",
                column: "WPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Orderings_OPId",
                table: "Orderings",
                column: "OPId");

            migrationBuilder.CreateIndex(
                name: "IX_Recepts_RDId",
                table: "Recepts",
                column: "RDId");

            migrationBuilder.CreateIndex(
                name: "IX_Recepts_RIId",
                table: "Recepts",
                column: "RIId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orderings_Positions_OPId",
                table: "Orderings",
                column: "OPId",
                principalTable: "Positions",
                principalColumn: "PId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_WorkRanks_WPostId",
                table: "Workers",
                column: "WPostId",
                principalTable: "WorkRanks",
                principalColumn: "WrId");
        }
    }
}
