using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autopark.DAL.Migrations
{
    public partial class RemoveApplicationUserIdFieldFromCustomerEmployeeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<int>(
            //    name: "CustomerTypeId",
            //    table: "AspNetUsers",
            //    type: "int",
            //    nullable: true,
            //    oldClrType: typeof(int),
            //    oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<int>(
            //    name: "CustomerTypeId",
            //    table: "AspNetUsers",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0,
            //    oldClrType: typeof(int),
            //    oldType: "int",
            //    oldNullable: true);
        }
    }
}
