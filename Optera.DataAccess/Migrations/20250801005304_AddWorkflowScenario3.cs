using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkflowScenario3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "WorkflowScenarios",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Name",
                value: "Quotation Approved By Sales Coordinator Scenario");

            migrationBuilder.InsertData(
                table: "WorkflowScenarios",
                columns: new[] { "Id", "ActorId", "ApprovalStatus", "Creator", "Name", "PreviousStatus", "RejectionStatus", "Status", "StepOrder", "Updator", "WorkflowId" },
                values: new object[] { 3L, 2, "ApprovedByCEO", "System", "Quotation Approved By Sales Executive Scenario", "ApprovedBySalesExecutive", "RejectedByCEO", "Active", 3, "System", 1L });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkflowScenarios",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.UpdateData(
                table: "WorkflowScenarios",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Name",
                value: "Quotation Approved BySales Coordinator Scenario");
        }
    }
}
