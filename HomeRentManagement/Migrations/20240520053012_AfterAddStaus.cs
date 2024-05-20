using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeRentManagement.Migrations
{
    /// <inheritdoc />
    public partial class AfterAddStaus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Users",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Houses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Houses_StatusId",
                table: "Houses",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_Statuss_StatusId",
                table: "Houses",
                column: "StatusId",
                principalTable: "Statuss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Houses_Statuss_StatusId",
                table: "Houses");

            migrationBuilder.DropIndex(
                name: "IX_Houses_StatusId",
                table: "Houses");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Houses");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);
        }
    }
}
