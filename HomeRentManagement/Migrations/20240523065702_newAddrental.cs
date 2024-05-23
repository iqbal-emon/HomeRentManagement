using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeRentManagement.Migrations
{
    /// <inheritdoc />
    public partial class newAddrental : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Rentals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Rentals");
        }
    }
}
