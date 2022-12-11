using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autopark.WEB.Migrations.Rdbmsdb
{
    public partial class EmployeeRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "AspNetRoles");
        }
    }
}
