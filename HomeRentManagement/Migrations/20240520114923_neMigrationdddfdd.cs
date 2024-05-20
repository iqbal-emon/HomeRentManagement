using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeRentManagement.Migrations
{
    /// <inheritdoc />
    public partial class neMigrationdddfdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Users_OwnerId",
                table: "Units");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Units",
                newName: "OwnerI");

            migrationBuilder.RenameIndex(
                name: "IX_Units_OwnerId",
                table: "Units",
                newName: "IX_Units_OwnerI");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Users_OwnerI",
                table: "Units",
                column: "OwnerI",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Users_OwnerI",
                table: "Units");

            migrationBuilder.RenameColumn(
                name: "OwnerI",
                table: "Units",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Units_OwnerI",
                table: "Units",
                newName: "IX_Units_OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Users_OwnerId",
                table: "Units",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
