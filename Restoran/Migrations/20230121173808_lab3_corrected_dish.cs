using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restoran.Migrations
{
    /// <inheritdoc />
    public partial class lab3correcteddish : Migration
    {
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
