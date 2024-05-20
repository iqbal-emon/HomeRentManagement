using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeRentManagement.Migrations
{
    /// <inheritdoc />
    public partial class errrosd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Users_OwnerI",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_OwnerI",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "OwnerI",
                table: "Units");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "OwnerI",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Units_OwnerI",
                table: "Units",
                column: "OwnerI");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Users_OwnerI",
                table: "Units",
                column: "OwnerI",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
