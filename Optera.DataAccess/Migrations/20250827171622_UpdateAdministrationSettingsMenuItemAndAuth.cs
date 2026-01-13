using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAdministrationSettingsMenuItemAndAuth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 14L,
                column: "Order",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 15L,
                column: "Order",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 16L,
                column: "Order",
                value: 31);

            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 17L,
                column: "Order",
                value: 32);

            migrationBuilder.InsertData(
                table: "Authorizations",
                columns: new[] { "Id", "Code", "Name", "Order", "ParentId" },
                values: new object[] { 18L, "AUTH_3040", "Settings", 40, 11L });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Data", "Expanded", "Group", "Hidden", "Home", "Icon", "Link", "Order", "ParentId", "Target", "Title", "Url" },
                values: new object[] { 14L, "AUTH_3040", null, null, null, null, "eva options-2-outline", null, 40, 10L, null, "Settings", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 14L,
                column: "Order",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 15L,
                column: "Order",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 16L,
                column: "Order",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 17L,
                column: "Order",
                value: 22);
        }
    }
}
