using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateQuotationEditComponentFormModelData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ComponentForms",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Model",
                value: "customer");

            migrationBuilder.UpdateData(
                table: "ComponentForms",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Model",
                value: "customer");

            migrationBuilder.UpdateData(
                table: "ComponentForms",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Model",
                value: "customer");

            migrationBuilder.UpdateData(
                table: "ComponentForms",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Model",
                value: "quotation");

            migrationBuilder.UpdateData(
                table: "ComponentForms",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Model",
                value: "quotation");

            migrationBuilder.UpdateData(
                table: "ComponentForms",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Model",
                value: "quotation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
