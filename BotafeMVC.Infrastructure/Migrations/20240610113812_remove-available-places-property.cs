using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BotafeMVC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removeavailableplacesproperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlacesAvailable",
                table: "Events");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlacesAvailable",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
