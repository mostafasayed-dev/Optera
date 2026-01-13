using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddQuotationRequestWorkflowDefinition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WorkflowDefinitions",
                columns: new[] { "Id", "CreatedAt", "Creator", "Name", "Status", "UpdatedAt", "Updator" },
                values: new object[] { 1L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Quotation Request Workflow", "Active", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkflowDefinitions",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
