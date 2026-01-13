using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateQuotationsListRemoveCustomerIdDataTableColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 31L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DataTableColumns",
                columns: new[] { "Id", "Color", "DataTableId", "Datatype", "DisplayCurrency", "IsCheck", "Name", "Order", "Sortable", "Text", "Visible" },
                values: new object[] { 31L, null, 6L, null, false, false, "customer.id", 4, true, "Customer Id", false });
        }
    }
}
