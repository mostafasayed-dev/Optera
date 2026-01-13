using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddDataTableRows : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DataTables",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Title",
                value: "Countries");

            migrationBuilder.UpdateData(
                table: "DataTables",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Title",
                value: "Cities");

            migrationBuilder.UpdateData(
                table: "DataTables",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Title",
                value: "Regions");

            migrationBuilder.UpdateData(
                table: "DataTables",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Title",
                value: "Categories");

            migrationBuilder.UpdateData(
                table: "DataTables",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Title",
                value: "Category Items");

            migrationBuilder.UpdateData(
                table: "DataTables",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Title",
                value: "Quotations");

            migrationBuilder.InsertData(
                table: "DataTables",
                columns: new[] { "Id", "ItemsPerPage", "Name", "Title" },
                values: new object[,]
                {
                    { 7L, 10, "groups-list", "Groups" },
                    { 8L, 10, "users-list", "Users" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DataTables",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "DataTables",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.UpdateData(
                table: "DataTables",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Title",
                value: null);

            migrationBuilder.UpdateData(
                table: "DataTables",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Title",
                value: null);

            migrationBuilder.UpdateData(
                table: "DataTables",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Title",
                value: null);

            migrationBuilder.UpdateData(
                table: "DataTables",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Title",
                value: null);

            migrationBuilder.UpdateData(
                table: "DataTables",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Title",
                value: null);

            migrationBuilder.UpdateData(
                table: "DataTables",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Title",
                value: null);
        }
    }
}
