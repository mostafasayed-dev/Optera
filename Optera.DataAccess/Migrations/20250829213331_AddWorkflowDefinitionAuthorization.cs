using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkflowDefinitionAuthorization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authorizations",
                columns: new[] { "Id", "Code", "Name", "Order", "ParentId" },
                values: new object[] { 19L, "AUTH_3050", "Workflow Definition", 50, 18L });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 19L);
        }
    }
}
