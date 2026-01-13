using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkflowTransitionsDataTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DataTables",
                columns: new[] { "Id", "ItemsPerPage", "Name", "Title" },
                values: new object[] { 11L, 10, "workflow-transitions-list", "Workflow Transitions" });

            migrationBuilder.InsertData(
                table: "DataTableColumns",
                columns: new[] { "Id", "Color", "DataTableId", "Datatype", "DisplayCurrency", "IsCheck", "Name", "Order", "Sortable", "Text", "Visible" },
                values: new object[,]
                {
                    { 54L, null, 11L, null, false, false, "id", 0, true, "ID", false },
                    { 55L, null, 11L, null, false, false, "workflowDefinitionId", 1, true, "Workflow Definition ID", false },
                    { 56L, null, 11L, null, false, false, "workflowDefinitionName", 2, true, "Definition Name", true },
                    { 57L, null, 11L, null, false, false, "actionName", 3, true, "Action", true },
                    { 58L, null, 11L, null, false, false, "fromStepName", 4, true, "From Step", true },
                    { 59L, null, 11L, null, false, false, "fromStepId", 5, true, "From Step ID", false },
                    { 60L, null, 11L, null, false, false, "toStepName", 6, true, "To Step", true },
                    { 61L, null, 11L, null, false, false, "toStepId", 7, true, "To Step ID", false },
                    { 62L, null, 11L, null, false, false, "targetStatus", 8, true, "Target Status", true },
                    { 63L, null, 11L, null, false, false, "roleId", 9, true, "Role ID", false },
                    { 64L, null, 11L, null, false, false, "roleName", 10, true, "Role", true },
                    { 65L, null, 11L, null, false, false, "status", 11, true, "Status", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 54L);

            migrationBuilder.DeleteData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 55L);

            migrationBuilder.DeleteData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 56L);

            migrationBuilder.DeleteData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 57L);

            migrationBuilder.DeleteData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 58L);

            migrationBuilder.DeleteData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 59L);

            migrationBuilder.DeleteData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 60L);

            migrationBuilder.DeleteData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 61L);

            migrationBuilder.DeleteData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 62L);

            migrationBuilder.DeleteData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 63L);

            migrationBuilder.DeleteData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 64L);

            migrationBuilder.DeleteData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 65L);

            migrationBuilder.DeleteData(
                table: "DataTables",
                keyColumn: "Id",
                keyValue: 11L);
        }
    }
}
