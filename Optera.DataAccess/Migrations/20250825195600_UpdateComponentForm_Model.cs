using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateComponentForm_Model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "ComponentForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ComponentForms",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Model",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentForms",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Model",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentForms",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Model",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentForms",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Model",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentForms",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Model",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentForms",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Model",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Model",
                table: "ComponentForms");
        }
    }
}
