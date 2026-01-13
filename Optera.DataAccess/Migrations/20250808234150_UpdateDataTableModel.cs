using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDataTableModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 22L,
                column: "Text",
                value: "Category Item Name");

            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 23L,
                column: "Text",
                value: "Category Item Name (Other Lang.)");

            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 24L,
                column: "Text",
                value: "Category Name");

            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 25L,
                column: "Text",
                value: "Category ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 22L,
                column: "Text",
                value: "Category Name");

            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 23L,
                column: "Text",
                value: "Description");

            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 24L,
                column: "Text",
                value: "Description");

            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 25L,
                column: "Text",
                value: "Description");
        }
    }
}
