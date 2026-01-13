using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkflowDefinitionMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Data", "Expanded", "Group", "Hidden", "Home", "Icon", "Link", "Order", "ParentId", "Target", "Title", "Url" },
                values: new object[] { 15L, "AUTH_3050", null, null, null, null, "eva repeat-outline", "/pages/admin/workflow-definition", 50, 14L, null, "Workflow Definition", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 15L);
        }
    }
}
