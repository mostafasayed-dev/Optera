using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddMenuItemsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Data", "Expanded", "Group", "Hidden", "Home", "Icon", "Link", "Order", "ParentId", "Target", "Title", "Url" },
                values: new object[,]
                {
                    { 1L, null, null, null, null, true, "home-outline", "/pages/dashboard", 1, null, null, "Home", null },
                    { 2L, "Settings", null, null, null, null, "settings-outline", null, 2, null, null, "Settings", null },
                    { 7L, "BusinessProcess", null, null, null, null, "flip-2-outline", null, 7, null, null, "Business Process", null },
                    { 3L, "CountriesList", null, null, null, null, "arrow-right", "settings/countries", 3, 2L, null, "Countries", null },
                    { 4L, "Cities", null, null, null, null, "arrow-right", "settings/cities", 4, 2L, null, "Cities", null },
                    { 5L, "RegionsList", null, null, null, null, "arrow-right", "settings/regions", 5, 2L, null, "Regions", null },
                    { 6L, "CategoriesList", null, null, null, null, "arrow-right", "settings/categories", 6, 2L, null, "Categories", null },
                    { 8L, "QuotationsList", null, null, null, null, "arrow-right", "business-process/quotations", 8, 7L, null, "Quotation Request", null },
                    { 9L, "ContractsList", null, null, null, null, "arrow-right", "business-process/contracts", 9, 7L, null, "Contract Request", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7L);
        }
    }
}
