using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Optera.Configuration.Migrations
{
    /// <inheritdoc />
    public partial class DataTableSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DataTables",
                columns: new[] { "Id", "ItemsPerPage", "Name", "Title" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), 10, "countries-list", "Countries" });

            migrationBuilder.InsertData(
                table: "DataTableColumns",
                columns: new[] { "Id", "Color", "DataTableId", "Datatype", "DisplayCurrency", "IsCheck", "Name", "Order", "Sortable", "Text", "Visible" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), null, new Guid("00000000-0000-0000-0000-000000000001"), null, false, false, "id", 0, true, "ID", false },
                    { new Guid("00000000-0000-0000-0000-000000000002"), null, new Guid("00000000-0000-0000-0000-000000000001"), null, false, false, "name", 1, true, "Country Name", true },
                    { new Guid("00000000-0000-0000-0000-000000000003"), null, new Guid("00000000-0000-0000-0000-000000000001"), null, false, false, "name_OtherLanguage", 2, true, "Country Name (Other)", true },
                    { new Guid("00000000-0000-0000-0000-000000000004"), null, new Guid("00000000-0000-0000-0000-000000000001"), null, false, false, "isoCode", 3, true, "ISO Code", true },
                    { new Guid("00000000-0000-0000-0000-000000000005"), null, new Guid("00000000-0000-0000-0000-000000000001"), null, false, false, "creator", 4, true, "Created By", true },
                    { new Guid("00000000-0000-0000-0000-000000000006"), null, new Guid("00000000-0000-0000-0000-000000000001"), null, false, false, "updater", 5, true, "Modified By", true },
                    { new Guid("00000000-0000-0000-0000-000000000007"), null, new Guid("00000000-0000-0000-0000-000000000001"), null, false, false, "createdAt", 6, true, "Created At", true },
                    { new Guid("00000000-0000-0000-0000-000000000008"), null, new Guid("00000000-0000-0000-0000-000000000001"), null, false, false, "updatedAt", 7, true, "Modified At", true },
                    { new Guid("00000000-0000-0000-0000-000000000009"), null, new Guid("00000000-0000-0000-0000-000000000001"), null, false, false, "status", 8, true, "Status", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "DataTables",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));
        }
    }
}
