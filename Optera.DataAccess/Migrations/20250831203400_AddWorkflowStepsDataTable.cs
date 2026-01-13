using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkflowStepsDataTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DataTables",
                columns: new[] { "Id", "ItemsPerPage", "Name", "Title" },
                values: new object[] { 10L, 10, "workflow-steps-list", "Workflow Steps" });

            migrationBuilder.InsertData(
                table: "DataTableColumns",
                columns: new[] { "Id", "Color", "DataTableId", "Datatype", "DisplayCurrency", "IsCheck", "Name", "Order", "Sortable", "Text", "Visible" },
                values: new object[,]
                {
                    { 47L, null, 10L, null, false, false, "id", 0, true, "ID", false },
                    { 48L, null, 10L, null, false, false, "workflowDefinitionId", 1, true, "Workflow Definition ID", false },
                    { 49L, null, 10L, null, false, false, "workflowDefinitionName", 2, true, "Definition Name", true },
                    { 50L, null, 10L, null, false, false, "name", 3, true, "Name", true },
                    { 51L, null, 10L, null, false, false, "order", 4, true, "Order", true },
                    { 52L, null, 10L, null, false, false, "isFinal", 5, true, "Final Step", true },
                    { 53L, null, 10L, null, false, false, "status", 6, true, "Status", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 47L);

            migrationBuilder.DeleteData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 48L);

            migrationBuilder.DeleteData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 49L);

            migrationBuilder.DeleteData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 50L);

            migrationBuilder.DeleteData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 51L);

            migrationBuilder.DeleteData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 52L);

            migrationBuilder.DeleteData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 53L);

            migrationBuilder.DeleteData(
                table: "DataTables",
                keyColumn: "Id",
                keyValue: 10L);
        }
    }
}
