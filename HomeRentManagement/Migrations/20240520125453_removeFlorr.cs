using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeRentManagement.Migrations
{
    /// <inheritdoc />
    public partial class removeFlorr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Floors_HouseID",
                table: "Floors");

            migrationBuilder.AddColumn<int>(
                name: "floorNumber",
                table: "Houses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Floors_HouseID",
                table: "Floors",
                column: "HouseID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Floors_HouseID",
                table: "Floors");

            migrationBuilder.DropColumn(
                name: "floorNumber",
                table: "Houses");

            migrationBuilder.CreateIndex(
                name: "IX_Floors_HouseID",
                table: "Floors",
                column: "HouseID",
                unique: true);
        }
    }
}
