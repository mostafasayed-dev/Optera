using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAdministrationSecurityMenuItemAndAuth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 12L,
                column: "Name",
                value: "Security");

            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 15L,
                columns: new[] { "Code", "Name", "Order", "ParentId" },
                values: new object[] { "AUTH_3030", "Users", 20, 12L });

            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 14L,
                columns: new[] { "Code", "Name", "Order", "ParentId" },
                values: new object[] { "AUTH_3021", "Add Group", 11, 13L });

            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "Code", "Name", "Order" },
                values: new object[] { "AUTH_3020", "Groups", 20 });

            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 16L,
                columns: new[] { "Code", "Name", "Order", "ParentId" },
                values: new object[] { "AUTH_3031", "Add User", 21, 15L });

            migrationBuilder.InsertData(
                table: "Authorizations",
                columns: new[] { "Id", "Code", "Name", "Order", "ParentId" },
                values: new object[] { 17L, "AUTH_3032", "Edit User", 22, 15L });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "Icon", "Link", "Title" },
                values: new object[] { "eva shield-outline", null, "Security" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "Icon", "Link", "ParentId", "Title" },
                values: new object[] { "eva people-outline", "/pages/admin/groups", 11L, "Groups" });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Data", "Expanded", "Group", "Hidden", "Home", "Icon", "Link", "Order", "ParentId", "Target", "Title", "Url" },
                values: new object[] { 13L, "AUTH_3030", null, null, null, null, "eva person-outline", "/pages/admin/users", 30, 11L, null, "Users", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 12L,
                column: "Name",
                value: "Groups");

            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "Code", "Name", "Order" },
                values: new object[] { "AUTH_3011", "Add Group", 11 });

            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 14L,
                columns: new[] { "Code", "Name", "Order", "ParentId" },
                values: new object[] { "AUTH_3020", "Users", 20, 11L });

            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 15L,
                columns: new[] { "Code", "Name", "Order", "ParentId" },
                values: new object[] { "AUTH_3021", "Add User", 21, 14L });

            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 16L,
                columns: new[] { "Code", "Name", "Order", "ParentId" },
                values: new object[] { "AUTH_3022", "Edit User", 22, 14L });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "Icon", "Link", "Title" },
                values: new object[] { "eva people-outline", "/pages/admin/groups", "Groups" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "Icon", "Link", "ParentId", "Title" },
                values: new object[] { "eva person-outline", "/pages/admin/users", 10L, "Users" });
        }
    }
}
