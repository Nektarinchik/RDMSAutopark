using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autopark.WEB.Migrations.Rdbmsdb
{
    public partial class RemoveEmployeeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "CustomerEmployee",
                nullable: true);

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerEmployee_Employee_EmployeeId",
                table: "CustomerEmployee");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.RenameColumn(
                name: "CustomerUserId",
                table: "CustomerEmployee",
                newName: "CustomerId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_CustomerEmployee_CustomerUserId",
            //    table: "CustomerEmployee",
            //    newName: "IX_CustomerEmployee_CustomerId");

            //migrationBuilder.AddColumn<int>(
            //    name: "ApplicationUserId",
            //    table: "CustomerEmployee",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_CustomerEmployee_ApplicationUserId",
            //    table: "CustomerEmployee",
            //    column: "ApplicationUserId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_CustomerEmployee_AspNetUsers_ApplicationUserId",
            //    table: "CustomerEmployee",
            //    column: "ApplicationUserId",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerEmployee_Employee_EmployeeId",
                table: "CustomerEmployee",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_CustomerEmployee_AspNetUsers_ApplicationUserId",
            //    table: "CustomerEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerEmployee_Employee_EmployeeId",
                table: "CustomerEmployee");

            //migrationBuilder.DropIndex(
            //    name: "IX_CustomerEmployee_ApplicationUserId",
            //    table: "CustomerEmployee");

            //migrationBuilder.DropColumn(
            //    name: "ApplicationUserId",
            //    table: "CustomerEmployee");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "CustomerEmployee",
                newName: "CustomerUserId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_CustomerEmployee_CustomerId",
            //    table: "CustomerEmployee",
            //    newName: "IX_CustomerEmployee_CustomerUserId");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerEmployee_Employee_EmployeeId",
                table: "CustomerEmployee",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
