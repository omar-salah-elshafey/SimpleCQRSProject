using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CQRSProject.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("22844454-56d1-4aa8-98b4-c0d5230853fa"), "Apple's latest flagship smartphone with a ProMotion display and improved cameras", "iPhone 15 Pro", 999.99m },
                    { new Guid("812e1e91-09fa-4e48-a353-aa9c4828f5fc"), "Dell's high-performance laptop with a 4K InfinityEdge display", "Dell XPS 15", 1899.99m },
                    { new Guid("d6dd6998-4ff3-487d-9424-bc21ffbe5d4b"), "Sony's top-of-the-line wireless noise-canceling headphones", "Sony WH-1000XM4", 349.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
