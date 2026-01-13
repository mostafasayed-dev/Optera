using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWorkflowStepsDataTableIsCheck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 52L,
                column: "IsCheck",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DataTableColumns",
                keyColumn: "Id",
                keyValue: 52L,
                column: "IsCheck",
                value: false);
        }
    }
}
