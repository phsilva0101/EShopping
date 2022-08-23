using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekShopping.Product.API.Migrations
{
    public partial class SeedProductDataTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TAB_Products",
                columns: new[] { "id", "category_name", "description", "image_url", "name", "price" },
                values: new object[,]
                {
                    { 2L, "SmartPhones", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent quis pharetra metus. Suspendisse p", "", "Iphone 12", 5899.00m },
                    { 3L, "SmartPhones", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent quis pharetra metus. Suspendisse p", "", "Iphone XR", 2899.00m },
                    { 4L, "SmartPhones", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent quis pharetra metus. Suspendisse p", "", "Iphone 8", 2300.00m },
                    { 5L, "SmartPhones", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent quis pharetra metus. Suspendisse p", "", "Samsumg Galaxy S21", 3000.00m },
                    { 6L, "Games", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent quis pharetra metus. Suspendisse p", "", "Xbox One", 2699.00m },
                    { 7L, "Games", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent quis pharetra metus. Suspendisse p", "", "Playstation 5", 3800.00m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TAB_Products",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "TAB_Products",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "TAB_Products",
                keyColumn: "id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "TAB_Products",
                keyColumn: "id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "TAB_Products",
                keyColumn: "id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "TAB_Products",
                keyColumn: "id",
                keyValue: 7L);
        }
    }
}
