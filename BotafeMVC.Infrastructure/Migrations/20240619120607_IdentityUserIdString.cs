using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BotafeMVC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IdentityUserIdString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventEnrollments_AspNetUsers_IdentityUserId1",
                table: "EventEnrollments");

            migrationBuilder.DropIndex(
                name: "IX_EventEnrollments_IdentityUserId1",
                table: "EventEnrollments");

            migrationBuilder.DropColumn(
                name: "IdentityUserId1",
                table: "EventEnrollments");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserId",
                table: "EventEnrollments",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_EventEnrollments_IdentityUserId",
                table: "EventEnrollments",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventEnrollments_AspNetUsers_IdentityUserId",
                table: "EventEnrollments",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventEnrollments_AspNetUsers_IdentityUserId",
                table: "EventEnrollments");

            migrationBuilder.DropIndex(
                name: "IX_EventEnrollments_IdentityUserId",
                table: "EventEnrollments");

            migrationBuilder.AlterColumn<int>(
                name: "IdentityUserId",
                table: "EventEnrollments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId1",
                table: "EventEnrollments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventEnrollments_IdentityUserId1",
                table: "EventEnrollments",
                column: "IdentityUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_EventEnrollments_AspNetUsers_IdentityUserId1",
                table: "EventEnrollments",
                column: "IdentityUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
