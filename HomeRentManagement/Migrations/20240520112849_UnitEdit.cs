using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeRentManagement.Migrations
{
    /// <inheritdoc />
    public partial class UnitEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Units_OwnerId",
                table: "Units",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_StatusId",
                table: "Units",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Statuss_StatusId",
                table: "Units",
                column: "StatusId",
                principalTable: "Statuss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Users_OwnerId",
                table: "Units",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Statuss_StatusId",
                table: "Units");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Users_OwnerId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_OwnerId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_StatusId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Units");
        }
    }
}
