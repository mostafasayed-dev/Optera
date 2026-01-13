using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAuthorizationAddGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "Code", "Name", "Order" },
                values: new object[] { "AUTH_3011", "Add Group", 11 });

            migrationBuilder.InsertData(
                table: "Authorizations",
                columns: new[] { "Id", "Code", "Name", "Order", "ParentId" },
                values: new object[] { 14L, "AUTH_3020", "Users", 20, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "Code", "Name", "Order" },
                values: new object[] { "AUTH_3020", "Users", 20 });
        }
    }
}
