using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restoran.Migrations
{
    /// <inheritdoc />
    public partial class fixMissed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WRank",
                table: "Workers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WRank",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
