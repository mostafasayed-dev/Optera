using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthorizationData3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Order",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Code", "Order" },
                values: new object[] { "AUTH_1010", 10 });

            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Code", "Order" },
                values: new object[] { "AUTH_1020", 20 });

            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Code", "Order" },
                values: new object[] { "AUTH_1030", 30 });

            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Code", "Order" },
                values: new object[] { "AUTH_1040", 40 });

            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "Code", "Order" },
                values: new object[] { "AUTH_1041", 41 });

            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Order",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "Code", "Order" },
                values: new object[] { "AUTH_2010", 10 });

            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "Code", "Order" },
                values: new object[] { "AUTH_2011", 11 });

            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "Code", "Order" },
                values: new object[] { "AUTH_2012", 12 });

            migrationBuilder.InsertData(
                table: "Authorizations",
                columns: new[] { "Id", "Code", "Name", "Order", "ParentId" },
                values: new object[,]
                {
                    { 11L, "AUTH_3000", "Administration", 0, null },
                    { 12L, "AUTH_3010", "Groups", 10, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Code", "Order" },
                values: new object[] { "AUTH_1001", 2 });

            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Code", "Order" },
                values: new object[] { "AUTH_1002", 3 });

            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Code", "Order" },
                values: new object[] { "AUTH_1003", 4 });

            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Code", "Order" },
                values: new object[] { "AUTH_1004", 5 });

            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "Code", "Order" },
                values: new object[] { "AUTH_1005", 6 });

            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Order",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "Code", "Order" },
                values: new object[] { "AUTH_2001", 8 });

            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "Code", "Order" },
                values: new object[] { "AUTH_2002", 9 });

            migrationBuilder.UpdateData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "Code", "Order" },
                values: new object[] { "AUTH_2003", 10 });
        }
    }
}
