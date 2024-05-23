using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeRentManagement.Migrations
{
    /// <inheritdoc />
    public partial class newMigrationd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Units_UnitID",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "ElectricityBill",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "GasBill",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "Rent",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "ServiceCharge",
                table: "Rentals");

            migrationBuilder.RenameColumn(
                name: "UnitID",
                table: "Rentals",
                newName: "TenantID");

            migrationBuilder.RenameIndex(
                name: "IX_Rentals_UnitID",
                table: "Rentals",
                newName: "IX_Rentals_TenantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Tenants_TenantID",
                table: "Rentals",
                column: "TenantID",
                principalTable: "Tenants",
                principalColumn: "TenantID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Tenants_TenantID",
                table: "Rentals");

            migrationBuilder.RenameColumn(
                name: "TenantID",
                table: "Rentals",
                newName: "UnitID");

            migrationBuilder.RenameIndex(
                name: "IX_Rentals_TenantID",
                table: "Rentals",
                newName: "IX_Rentals_UnitID");

            migrationBuilder.AddColumn<decimal>(
                name: "ElectricityBill",
                table: "Rentals",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "GasBill",
                table: "Rentals",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Rent",
                table: "Rentals",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ServiceCharge",
                table: "Rentals",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Units_UnitID",
                table: "Rentals",
                column: "UnitID",
                principalTable: "Units",
                principalColumn: "UnitID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
