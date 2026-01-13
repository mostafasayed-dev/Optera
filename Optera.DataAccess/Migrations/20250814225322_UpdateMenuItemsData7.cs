using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMenuItemsData7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Data", "Expanded", "Group", "Hidden", "Home", "Icon", "Link", "Order", "ParentId", "Target", "Title", "Url" },
                values: new object[] { 12L, "AUTH_3020", null, null, null, null, "arrow-right", "admin/users", 20, 10L, null, "Users", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 12L);
        }
    }
}
