using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autopark.DAL.Migrations
{
    public partial class AddingYearOfReleasecolumninCarentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "YearOfRelease",
                table: "Cars",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YearOfRelease",
                table: "Cars");
        }
    }
}
