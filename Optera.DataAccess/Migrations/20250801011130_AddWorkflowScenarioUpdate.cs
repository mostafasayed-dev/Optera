using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkflowScenarioUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "WorkflowScenarios",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Name", "RejectionStatus" },
                values: new object[] { "Quotation - Sales Coordinator Scenario", "Submitted" });

            migrationBuilder.UpdateData(
                table: "WorkflowScenarios",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Name", "RejectionStatus" },
                values: new object[] { "Quotation - Sales Executive Scenario", "Submitted" });

            migrationBuilder.UpdateData(
                table: "WorkflowScenarios",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Name", "RejectionStatus" },
                values: new object[] { "Quotation - CEO Scenario", "Submitted" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "WorkflowScenarios",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Name", "RejectionStatus" },
                values: new object[] { "Quotation Under Review Scenario", "RejectedBySalesCoordinator" });

            migrationBuilder.UpdateData(
                table: "WorkflowScenarios",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Name", "RejectionStatus" },
                values: new object[] { "Quotation Approved By Sales Coordinator Scenario", "RejectedBySalesExecutive" });

            migrationBuilder.UpdateData(
                table: "WorkflowScenarios",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Name", "RejectionStatus" },
                values: new object[] { "Quotation Approved By Sales Executive Scenario", "RejectedByCEO" });
        }
    }
}
