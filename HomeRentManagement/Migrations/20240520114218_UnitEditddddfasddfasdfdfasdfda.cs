using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeRentManagement.Migrations
{
    /// <inheritdoc />
    public partial class UnitEditddddfasddfasdfdfasdfda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Users_UserId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_UserId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Units");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Units",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Units_UserId",
                table: "Units",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Users_UserId",
                table: "Units",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
