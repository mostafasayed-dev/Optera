using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserDataTableColumnsModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 42L);

            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 38L,
                columns: new[] { "Name", "Text" },
                values: new object[] { "employeeName", "Employee Name" });

            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 40L,
                columns: new[] { "Name", "Text" },
                values: new object[] { "emailConfirmed", "Email Confirmed" });

            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 41L,
                columns: new[] { "Name", "Text" },
                values: new object[] { "locked", "Locked" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 38L,
                columns: new[] { "Name", "Text" },
                values: new object[] { "normalizedUserName", "Normalized Username" });

            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 40L,
                columns: new[] { "Name", "Text" },
                values: new object[] { "normalizedEmail", "Normalized Email" });

            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 41L,
                columns: new[] { "Name", "Text" },
                values: new object[] { "emailConfirmed", "Email Confirmed" });

            migrationBuilder.InsertData(
                table: "DataTableColumns",
                columns: new[] { "Id", "Color", "DataTableId", "Datatype", "DisplayCurrency", "IsCheck", "Name", "Order", "Sortable", "Text", "Visible" },
                values: new object[] { 42L, null, 8L, null, false, false, "locked", 6, true, "Locked", true });
        }
    }
}
