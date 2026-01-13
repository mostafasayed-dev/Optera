using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDataTableModel1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 30L,
                column: "Text",
                value: "Brand Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 30L,
                column: "Text",
                value: "Customer Brand Name");
        }
    }
}
