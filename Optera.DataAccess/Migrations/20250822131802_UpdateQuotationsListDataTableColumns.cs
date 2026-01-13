using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateQuotationsListDataTableColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 29L,
                column: "Name",
                value: "customer.name");

            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 30L,
                column: "Name",
                value: "customer.brandName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 29L,
                column: "Name",
                value: "customerName");

            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 30L,
                column: "Name",
                value: "customerBrandName");
        }
    }
}
