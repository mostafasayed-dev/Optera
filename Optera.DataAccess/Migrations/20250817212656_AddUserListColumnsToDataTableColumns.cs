using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddUserListColumnsToDataTableColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DataTableColumns",
                columns: new[] { "Id", "Color", "DataTableId", "Datatype", "DisplayCurrency", "IsCheck", "Name", "Order", "Sortable", "Text", "Visible" },
                values: new object[,]
                {
                    { 36L, null, 8L, null, false, false, "id", 0, true, "ID", false },
                    { 37L, null, 8L, null, false, false, "userName", 1, true, "Username", true },
                    { 38L, null, 8L, null, false, false, "normalizedUserName", 2, true, "Normalized Username", true },
                    { 39L, null, 8L, null, false, false, "email", 3, true, "Email", true },
                    { 40L, null, 8L, null, false, false, "normalizedEmail", 4, true, "Normalized Email", true },
                    { 41L, null, 8L, null, false, false, "emailConfirmed", 5, true, "Email Confirmed", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 36L);

            migrationBuilder.DeleteData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 37L);

            migrationBuilder.DeleteData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 38L);

            migrationBuilder.DeleteData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 39L);

            migrationBuilder.DeleteData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 40L);

            migrationBuilder.DeleteData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 41L);
        }
    }
}
