using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkflowScenario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "WorkflowScenarios");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "WorkflowScenarios");

            migrationBuilder.InsertData(
                table: "WorkflowScenarios",
                columns: new[] { "Id", "ActorId", "ApprovalStatus", "Creator", "Name", "PreviousStatus", "RejectionStatus", "Status", "StepOrder", "Updator", "WorkflowId" },
                values: new object[] { 1L, 3, "ApprovedBySalesCoordinator", "System", "Quotation Under Review Scenario", "UnderReview", "RejectedBySalesCoordinator", "Active", 1, "System", 1L });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkflowScenarios",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "WorkflowScenarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "WorkflowScenarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
