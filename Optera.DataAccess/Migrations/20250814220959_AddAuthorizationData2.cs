using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthorizationData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "Name", "ParentId" },
                values: new object[] { "Quotation Request (Add)", 8L });

            migrationBuilder.InsertData(
                table: "Authorizations",
                columns: new[] { "Id", "Code", "Name", "Order", "ParentId" },
                values: new object[] { 10L, "AUTH_2003", "Quotation Request (Edit)", 10, 8L });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "Name", "ParentId" },
                values: new object[] { "Contract Request", 7L });
        }
    }
}
