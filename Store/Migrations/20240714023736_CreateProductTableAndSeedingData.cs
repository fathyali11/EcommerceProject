using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebStore.Migrations
{
    /// <inheritdoc />
    public partial class CreateProductTableAndSeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ListPrice", "Name", "Price", "Price100", "Price50" },
                values: new object[,]
                {
                    { 1, "Logitech", 1, "Ergonomic gaming mouse with customizable DPI", 49.990000000000002, "Gaming Mouse", 45.990000000000002, 39.990000000000002, 43.990000000000002 },
                    { 2, "Corsair", 1, "Mechanical keyboard with RGB lighting", 99.989999999999995, "Mechanical Keyboard", 89.989999999999995, 79.989999999999995, 84.989999999999995 },
                    { 3, "DXRacer", 2, "Comfortable gaming chair with lumbar support", 199.99000000000001, "Gaming Chair", 179.99000000000001, 159.99000000000001, 169.99000000000001 },
                    { 4, "Samsung", 1, "27-inch 4K UHD monitor with HDR", 399.99000000000001, "4K Monitor", 379.99000000000001, 339.99000000000001, 359.99000000000001 },
                    { 5, "HyperX", 1, "Surround sound gaming headset with microphone", 79.989999999999995, "Gaming Headset", 74.989999999999995, 64.989999999999995, 69.989999999999995 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
