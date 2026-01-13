using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWorkflowRemoveNumberOfLevels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkflowScenarios",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "WorkflowScenarios",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "WorkflowScenarios",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DropColumn(
                name: "NumberOfLevels",
                table: "Workflow");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfLevels",
                table: "Workflow",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Workflow",
                keyColumn: "Id",
                keyValue: 1L,
                column: "NumberOfLevels",
                value: 3);

            migrationBuilder.InsertData(
                table: "WorkflowScenarios",
                columns: new[] { "Id", "ActorId", "ApprovalStatus", "Creator", "Name", "PreviousStatus", "RejectionStatus", "Status", "StepOrder", "Updator", "WorkflowId" },
                values: new object[,]
                {
                    { 1L, 3, "ApprovedBySalesCoordinator", "System", "Quotation - Sales Coordinator Scenario", "UnderReview", "Submitted", "Active", 1, "System", 1L },
                    { 2L, 4, "ApprovedBySalesExecutive", "System", "Quotation - Sales Executive Scenario", "ApprovedBySalesCoordinator", "Submitted", "Active", 2, "System", 1L },
                    { 3L, 2, "ApprovedByCEO", "System", "Quotation - CEO Scenario", "ApprovedBySalesExecutive", "Submitted", "Active", 3, "System", 1L }
                });
        }
    }
}
