using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FronDeskApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Firtname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Phone = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "StorageTypes",
                columns: table => new
                {
                    StorageTypeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageTypes", x => x.StorageTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Storages",
                columns: table => new
                {
                    StorageId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StorageTypeId = table.Column<int>(nullable: false),
                    Row = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storages", x => x.StorageId);
                    table.ForeignKey(
                        name: "FK_Storages_StorageTypes_StorageTypeId",
                        column: x => x.StorageTypeId,
                        principalTable: "StorageTypes",
                        principalColumn: "StorageTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerStorages",
                columns: table => new
                {
                    CustomerStorageId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerId = table.Column<int>(nullable: false),
                    StorageId = table.Column<int>(nullable: false),
                    In = table.Column<DateTime>(nullable: false),
                    Out = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerStorages", x => x.CustomerStorageId);
                    table.ForeignKey(
                        name: "FK_CustomerStorages_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerStorages_Storages_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storages",
                        principalColumn: "StorageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "StorageTypes",
                columns: new[] { "StorageTypeId", "Description", "Name" },
                values: new object[] { 1, "Small", "Small" });

            migrationBuilder.InsertData(
                table: "StorageTypes",
                columns: new[] { "StorageTypeId", "Description", "Name" },
                values: new object[] { 2, "Medium", "Medium" });

            migrationBuilder.InsertData(
                table: "StorageTypes",
                columns: new[] { "StorageTypeId", "Description", "Name" },
                values: new object[] { 3, "Large", "Large" });

            migrationBuilder.InsertData(
                table: "Storages",
                columns: new[] { "StorageId", "Row", "StorageTypeId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Storages",
                columns: new[] { "StorageId", "Row", "StorageTypeId" },
                values: new object[] { 2, 1, 1 });

            migrationBuilder.InsertData(
                table: "Storages",
                columns: new[] { "StorageId", "Row", "StorageTypeId" },
                values: new object[] { 3, 1, 1 });

            migrationBuilder.InsertData(
                table: "Storages",
                columns: new[] { "StorageId", "Row", "StorageTypeId" },
                values: new object[] { 4, 1, 2 });

            migrationBuilder.InsertData(
                table: "Storages",
                columns: new[] { "StorageId", "Row", "StorageTypeId" },
                values: new object[] { 5, 1, 3 });

            migrationBuilder.InsertData(
                table: "Storages",
                columns: new[] { "StorageId", "Row", "StorageTypeId" },
                values: new object[] { 6, 1, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerStorages_CustomerId",
                table: "CustomerStorages",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerStorages_StorageId",
                table: "CustomerStorages",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_Storages_StorageTypeId",
                table: "Storages",
                column: "StorageTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerStorages");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Storages");

            migrationBuilder.DropTable(
                name: "StorageTypes");
        }
    }
}
