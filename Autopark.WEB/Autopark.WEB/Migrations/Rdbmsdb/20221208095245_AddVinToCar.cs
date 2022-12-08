using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autopark.WEB.Migrations.Rdbmsdb
{
    public partial class AddVinToCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Vin",
                table: "Cars",
                type: "nvarchar(17)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<double>(
                name: "SpendingBalance",
                table: "AspNetUsers",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vin",
                table: "Cars");

            migrationBuilder.AlterColumn<double>(
                name: "SpendingBalance",
                table: "AspNetUsers",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }
    }
}
