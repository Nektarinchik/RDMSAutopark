using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autopark.DAL.Migrations
{
    public partial class TestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "AspNetRoles",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoles", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CarShowrooms",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Title = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
            //        Rating = table.Column<int>(type: "int", nullable: true),
            //        Phone = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CarShowrooms_Id", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CarTypes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Title = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CarTypes_Id", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CustomerTypes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Title = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CustomerTypes_Id", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Discounts",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Title = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
            //        Value = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Discounts_Id", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Manufacturers",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Title = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Manufacturers_Id", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetRoleClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        RoleId = table.Column<int>(type: "int", nullable: false),
            //        ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUsers",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CustomerTypeId = table.Column<int>(type: "int", nullable: false),
            //        SpendingBalance = table.Column<double>(type: "float", nullable: true),
            //        UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //        PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //        TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
            //        LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
            //        LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
            //        AccessFailedCount = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUsers", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetUsers_CustomerTypes_CustomerTypeId",
            //            column: x => x.CustomerTypeId,
            //            principalTable: "CustomerTypes",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Models",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ManufacturerId = table.Column<int>(type: "int", nullable: false),
            //        Title = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Models_Id", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Models_Manufacturers_ManufacturerId",
            //            column: x => x.ManufacturerId,
            //            principalTable: "Manufacturers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<int>(type: "int", nullable: false),
            //        ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserClaims_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserLogins",
            //    columns: table => new
            //    {
            //        LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        UserId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserLogins_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserRoles",
            //    columns: table => new
            //    {
            //        UserId = table.Column<int>(type: "int", nullable: false),
            //        RoleId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserTokens",
            //    columns: table => new
            //    {
            //        UserId = table.Column<int>(type: "int", nullable: false),
            //        LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserTokens_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CustomerEmployee",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        EmployeeId = table.Column<int>(type: "int", nullable: false),
            //        CustomerId = table.Column<int>(type: "int", nullable: false),
            //        ApplicationUserId = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CustomerEmployee_Id", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_CustomerEmployee_AspNetUsers_ApplicationUserId",
            //            column: x => x.ApplicationUserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_CustomerEmployee_Customer_CustomerId",
            //            column: x => x.CustomerId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_CustomerEmployee_Employee_EmployeeId",
            //            column: x => x.EmployeeId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Logs",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<int>(type: "int", nullable: true),
            //        LogTime = table.Column<DateTime>(type: "datetime", nullable: false),
            //        LogMessage = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Logs_Id", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Logs_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.SetNull);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Generations",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ModelId = table.Column<int>(type: "int", nullable: false),
            //        Title = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Generations_Id", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Generations_Models_ModelId",
            //            column: x => x.ModelId,
            //            principalTable: "Models",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Cars",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CarTypeId = table.Column<int>(type: "int", nullable: false),
            //        CarShowroomId = table.Column<int>(type: "int", nullable: true),
            //        GenerationId = table.Column<int>(type: "int", nullable: false),
            //        Price = table.Column<double>(type: "float", nullable: true),
            //        Vin = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Cars_Id", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Cars_CarShowrooms_CarShowroomId",
            //            column: x => x.CarShowroomId,
            //            principalTable: "CarShowrooms",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.SetNull);
            //        table.ForeignKey(
            //            name: "FK_Cars_CarTypes_CarTypeId",
            //            column: x => x.CarTypeId,
            //            principalTable: "CarTypes",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_Cars_Generations_GenerationId",
            //            column: x => x.GenerationId,
            //            principalTable: "Generations",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Orders",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CustomerEmployeeId = table.Column<int>(type: "int", nullable: true),
            //        DiscountId = table.Column<int>(type: "int", nullable: true),
            //        CarId = table.Column<int>(type: "int", nullable: true),
            //        Date = table.Column<DateTime>(type: "date", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Orders_Id", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Orders_Cars_CarId",
            //            column: x => x.CarId,
            //            principalTable: "Cars",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.SetNull);
            //        table.ForeignKey(
            //            name: "FK_Orders_CustomerEmployee_CustomerEmployeeId",
            //            column: x => x.CustomerEmployeeId,
            //            principalTable: "CustomerEmployee",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.SetNull);
            //        table.ForeignKey(
            //            name: "FK_Orders_Discounts_DiscountId",
            //            column: x => x.DiscountId,
            //            principalTable: "Discounts",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.SetNull);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetRoleClaims_RoleId",
            //    table: "AspNetRoleClaims",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "RoleNameIndex",
            //    table: "AspNetRoles",
            //    column: "NormalizedName",
            //    unique: true,
            //    filter: "[NormalizedName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserClaims_UserId",
            //    table: "AspNetUserClaims",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserLogins_UserId",
            //    table: "AspNetUserLogins",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserRoles_RoleId",
            //    table: "AspNetUserRoles",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "EmailIndex",
            //    table: "AspNetUsers",
            //    column: "NormalizedEmail");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUsers_CustomerTypeId",
            //    table: "AspNetUsers",
            //    column: "CustomerTypeId");

            //migrationBuilder.CreateIndex(
            //    name: "UserNameIndex",
            //    table: "AspNetUsers",
            //    column: "NormalizedUserName",
            //    unique: true,
            //    filter: "[NormalizedUserName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Cars_CarShowroomId",
            //    table: "Cars",
            //    column: "CarShowroomId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Cars_CarTypeId",
            //    table: "Cars",
            //    column: "CarTypeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Cars_GenerationId",
            //    table: "Cars",
            //    column: "GenerationId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CustomerEmployee_ApplicationUserId",
            //    table: "CustomerEmployee",
            //    column: "ApplicationUserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CustomerEmployee_CustomerId",
            //    table: "CustomerEmployee",
            //    column: "CustomerId");

            //migrationBuilder.CreateIndex(
            //    name: "UQ_EmployeeId_CustomerId",
            //    table: "CustomerEmployee",
            //    columns: new[] { "EmployeeId", "CustomerId" },
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Generations_ModelId",
            //    table: "Generations",
            //    column: "ModelId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Logs_UserId",
            //    table: "Logs",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Models_ManufacturerId",
            //    table: "Models",
            //    column: "ManufacturerId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Orders_CarId",
            //    table: "Orders",
            //    column: "CarId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Orders_CustomerEmployeeId",
            //    table: "Orders",
            //    column: "CustomerEmployeeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Orders_DiscountId",
            //    table: "Orders",
            //    column: "DiscountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "AspNetRoleClaims");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserClaims");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserLogins");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserRoles");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserTokens");

            //migrationBuilder.DropTable(
            //    name: "Logs");

            //migrationBuilder.DropTable(
            //    name: "Orders");

            //migrationBuilder.DropTable(
            //    name: "AspNetRoles");

            //migrationBuilder.DropTable(
            //    name: "Cars");

            //migrationBuilder.DropTable(
            //    name: "CustomerEmployee");

            //migrationBuilder.DropTable(
            //    name: "Discounts");

            //migrationBuilder.DropTable(
            //    name: "CarShowrooms");

            //migrationBuilder.DropTable(
            //    name: "CarTypes");

            //migrationBuilder.DropTable(
            //    name: "Generations");

            //migrationBuilder.DropTable(
            //    name: "AspNetUsers");

            //migrationBuilder.DropTable(
            //    name: "Models");

            //migrationBuilder.DropTable(
            //    name: "CustomerTypes");

            //migrationBuilder.DropTable(
            //    name: "Manufacturers");
        }
    }
}
