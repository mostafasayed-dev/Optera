using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDataTableModelProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemsPerPage",
                table: "DataTables",
                type: "int",
                nullable: false,
                defaultValue: 10);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "DataTables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DataTables",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ItemsPerPage", "Title" },
                values: new object[] { 10, null });

            migrationBuilder.UpdateData(
                table: "DataTables",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ItemsPerPage", "Title" },
                values: new object[] { 10, null });

            migrationBuilder.UpdateData(
                table: "DataTables",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "ItemsPerPage", "Title" },
                values: new object[] { 10, null });

            migrationBuilder.UpdateData(
                table: "DataTables",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "ItemsPerPage", "Title" },
                values: new object[] { 10, null });

            migrationBuilder.UpdateData(
                table: "DataTables",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "ItemsPerPage", "Title" },
                values: new object[] { 10, null });

            migrationBuilder.UpdateData(
                table: "DataTables",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "ItemsPerPage", "Title" },
                values: new object[] { 10, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemsPerPage",
                table: "DataTables");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "DataTables");
        }
    }
}
