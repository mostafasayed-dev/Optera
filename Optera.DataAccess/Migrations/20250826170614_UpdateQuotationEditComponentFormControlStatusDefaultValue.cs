using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateQuotationEditComponentFormControlStatusDefaultValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 37L,
                column: "DefaultValue",
                value: "Draft");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 37L,
                column: "DefaultValue",
                value: null);
        }
    }
}
