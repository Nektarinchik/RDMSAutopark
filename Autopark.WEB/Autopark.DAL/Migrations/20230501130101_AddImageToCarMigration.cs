using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autopark.DAL.Migrations
{
    public partial class AddImageToCarMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Cars",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Cars");
        }
    }
}
