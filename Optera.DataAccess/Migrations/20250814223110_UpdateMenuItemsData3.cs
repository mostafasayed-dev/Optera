using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMenuItemsData3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Order",
                value: 0);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Order",
                value: 0);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Data", "Order" },
                values: new object[] { "AUTH_1005", 1 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Data", "Order" },
                values: new object[] { "AUTH_1010", 2 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Data", "Order" },
                values: new object[] { "AUTH_1015", 3 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "Data", "Order" },
                values: new object[] { "AUTH_1020", 4 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "Data", "Order" },
                values: new object[] { "AUTH_2000", 0 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "Data", "Order" },
                values: new object[] { "AUTH_2005", 1 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "Data", "Order" },
                values: new object[] { "AUTH_2010", 2 });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Data", "Expanded", "Group", "Hidden", "Home", "Icon", "Link", "Order", "ParentId", "Target", "Title", "Url" },
                values: new object[,]
                {
                    { 10L, "AUTH_3000", null, null, null, null, "shield-outline", null, 0, null, null, "Administration", null },
                    { 11L, "AUTH_3005", null, null, null, null, "shield-outline", "admin/groups", 1, 10L, null, "Groups", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Order",
                value: 2);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Data", "Order" },
                values: new object[] { "AUTH_1001", 3 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Data", "Order" },
                values: new object[] { "AUTH_1002", 4 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Data", "Order" },
                values: new object[] { "AUTH_1003", 5 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "Data", "Order" },
                values: new object[] { "AUTH_1004", 6 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "Data", "Order" },
                values: new object[] { "AUTH_2001", 7 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "Data", "Order" },
                values: new object[] { "AUTH_2002", 8 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "Data", "Order" },
                values: new object[] { "AUTH_2003", 9 });
        }
    }
}
