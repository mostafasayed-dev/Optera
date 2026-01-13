using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateReferenceNumberModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ReferenceNumbers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Segment3_Format",
                value: "Sequence");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ReferenceNumbers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Segment3_Format",
                value: null);
        }
    }
}
