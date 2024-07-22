using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebStore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateColumsOfProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ListPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Price50",
                table: "Products",
                newName: "OldPrice");

            migrationBuilder.RenameColumn(
                name: "Price100",
                table: "Products",
                newName: "NewPrice");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NewPrice", "OldPrice" },
                values: new object[] { 45.990000000000002, 49.990000000000002 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NewPrice", "OldPrice" },
                values: new object[] { 89.989999999999995, 99.989999999999995 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "NewPrice", "OldPrice" },
                values: new object[] { 179.99000000000001, 199.99000000000001 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "NewPrice", "OldPrice" },
                values: new object[] { 379.99000000000001, 399.99000000000001 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "NewPrice", "OldPrice" },
                values: new object[] { 74.989999999999995, 79.989999999999995 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OldPrice",
                table: "Products",
                newName: "Price50");

            migrationBuilder.RenameColumn(
                name: "NewPrice",
                table: "Products",
                newName: "Price100");

            migrationBuilder.AddColumn<double>(
                name: "ListPrice",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ListPrice", "Price", "Price100", "Price50" },
                values: new object[] { 49.990000000000002, 45.990000000000002, 39.990000000000002, 43.990000000000002 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ListPrice", "Price", "Price100", "Price50" },
                values: new object[] { 99.989999999999995, 89.989999999999995, 79.989999999999995, 84.989999999999995 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ListPrice", "Price", "Price100", "Price50" },
                values: new object[] { 199.99000000000001, 179.99000000000001, 159.99000000000001, 169.99000000000001 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ListPrice", "Price", "Price100", "Price50" },
                values: new object[] { 399.99000000000001, 379.99000000000001, 339.99000000000001, 359.99000000000001 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ListPrice", "Price", "Price100", "Price50" },
                values: new object[] { 79.989999999999995, 74.989999999999995, 64.989999999999995, 69.989999999999995 });
        }
    }
}
