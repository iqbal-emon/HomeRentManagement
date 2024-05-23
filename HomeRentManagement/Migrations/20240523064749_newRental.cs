using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeRentManagement.Migrations
{
    /// <inheritdoc />
    public partial class newRental : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Tenants_TenantID",
                table: "Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Units_UnitID",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_TenantID",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "TenantID",
                table: "Rentals");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Units_UnitID",
                table: "Rentals",
                column: "UnitID",
                principalTable: "Units",
                principalColumn: "UnitID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Units_UnitID",
                table: "Rentals");

            migrationBuilder.AddColumn<int>(
                name: "TenantID",
                table: "Rentals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_TenantID",
                table: "Rentals",
                column: "TenantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Tenants_TenantID",
                table: "Rentals",
                column: "TenantID",
                principalTable: "Tenants",
                principalColumn: "TenantID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Units_UnitID",
                table: "Rentals",
                column: "UnitID",
                principalTable: "Units",
                principalColumn: "UnitID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
