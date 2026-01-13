using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateQuotationsListCustomerIdDataTableColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 31L,
                columns: new[] { "Datatype", "Name", "Text", "Visible" },
                values: new object[] { null, "customer.id", "Customer Id", false });

            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 32L,
                columns: new[] { "Datatype", "Name", "Text" },
                values: new object[] { "date", "effectiveDate", "Effective Date" });

            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 33L,
                columns: new[] { "DataTableId", "Name", "Order", "Text", "Visible" },
                values: new object[] { 6L, "status", 6, "Status", true });

            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 34L,
                columns: new[] { "Name", "Order", "Text", "Visible" },
                values: new object[] { "id", 0, "ID", false });

            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 35L,
                columns: new[] { "Name", "Order", "Text" },
                values: new object[] { "name", 1, "Group Name" });

            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 36L,
                columns: new[] { "DataTableId", "Name", "Order", "Text", "Visible" },
                values: new object[] { 7L, "normalizedName", 2, "Group Name (Normalized)", true });

            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 37L,
                columns: new[] { "Name", "Order", "Text", "Visible" },
                values: new object[] { "id", 0, "ID", false });

            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 38L,
                columns: new[] { "Name", "Order", "Text" },
                values: new object[] { "userName", 1, "Username" });

            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 39L,
                columns: new[] { "Name", "Order", "Text" },
                values: new object[] { "employeeName", 2, "Employee Name" });

            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 40L,
                columns: new[] { "Name", "Order", "Text" },
                values: new object[] { "email", 3, "Email" });

            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 41L,
                columns: new[] { "Name", "Order", "Text" },
                values: new object[] { "emailConfirmed", 4, "Email Confirmed" });

            migrationBuilder.InsertData(
                table: "DataTableColumns",
                columns: new[] { "Id", "Color", "DataTableId", "Datatype", "DisplayCurrency", "IsCheck", "Name", "Order", "Sortable", "Text", "Visible" },
                values: new object[] { 42L, null, 8L, null, false, false, "locked", 5, true, "Locked", true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 42L);

            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 31L,
                columns: new[] { "Datatype", "Name", "Text", "Visible" },
                values: new object[] { "date", "effectiveDate", "Effective Date", true });

            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 32L,
                columns: new[] { "Datatype", "Name", "Text" },
                values: new object[] { null, "status", "Status" });

            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 33L,
                columns: new[] { "DataTableId", "Name", "Order", "Text", "Visible" },
                values: new object[] { 7L, "id", 0, "ID", false });

            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 34L,
                columns: new[] { "Name", "Order", "Text", "Visible" },
                values: new object[] { "name", 1, "Group Name", true });

            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 35L,
                columns: new[] { "Name", "Order", "Text" },
                values: new object[] { "normalizedName", 2, "Group Name (Normalized)" });

            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 36L,
                columns: new[] { "DataTableId", "Name", "Order", "Text", "Visible" },
                values: new object[] { 8L, "id", 0, "ID", false });

            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 37L,
                columns: new[] { "Name", "Order", "Text", "Visible" },
                values: new object[] { "userName", 1, "Username", true });

            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 38L,
                columns: new[] { "Name", "Order", "Text" },
                values: new object[] { "employeeName", 2, "Employee Name" });

            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 39L,
                columns: new[] { "Name", "Order", "Text" },
                values: new object[] { "email", 3, "Email" });

            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 40L,
                columns: new[] { "Name", "Order", "Text" },
                values: new object[] { "emailConfirmed", 4, "Email Confirmed" });

            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 41L,
                columns: new[] { "Name", "Order", "Text" },
                values: new object[] { "locked", 5, "Locked" });
        }
    }
}
