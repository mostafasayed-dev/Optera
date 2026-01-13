using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkflowScenario2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WorkflowScenarios",
                columns: new[] { "Id", "ActorId", "ApprovalStatus", "Creator", "Name", "PreviousStatus", "RejectionStatus", "Status", "StepOrder", "Updator", "WorkflowId" },
                values: new object[] { 2L, 4, "ApprovedBySalesExecutive", "System", "Quotation Approved BySales Coordinator Scenario", "ApprovedBySalesCoordinator", "RejectedBySalesExecutive", "Active", 2, "System", 1L });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkflowScenarios",
                keyColumn: "Id",
                keyValue: 2L);
        }
    }
}
