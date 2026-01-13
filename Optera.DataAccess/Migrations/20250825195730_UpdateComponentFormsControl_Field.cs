using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateComponentFormsControl_Field : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Field",
                table: "ComponentFormControls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Field",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Field",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Field",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Field",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Field",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Field",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Field",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Field",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 9L,
                column: "Field",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 10L,
                column: "Field",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 11L,
                column: "Field",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 12L,
                column: "Field",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 13L,
                column: "Field",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 14L,
                column: "Field",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 15L,
                column: "Field",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 16L,
                column: "Field",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 17L,
                column: "Field",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 18L,
                column: "Field",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 19L,
                column: "Field",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 20L,
                column: "Field",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 21L,
                column: "Field",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 22L,
                column: "Field",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 23L,
                column: "Field",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 24L,
                column: "Field",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 25L,
                column: "Field",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 26L,
                column: "Field",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 27L,
                column: "Field",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 28L,
                column: "Field",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 29L,
                column: "Field",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 30L,
                column: "Field",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 31L,
                column: "Field",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 32L,
                column: "Field",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 33L,
                column: "Field",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 34L,
                column: "Field",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 35L,
                column: "Field",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 36L,
                column: "Field",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 37L,
                column: "Field",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Field",
                table: "ComponentFormControls");
        }
    }
}
