using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateQuotationEditComponentFormControlFieldData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Field",
                value: "name");

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Field",
                value: "name_OtherLanguage");

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Field",
                value: "brandName");

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Field",
                value: "brandName_OtherLanguage");

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Field",
                value: "classId");

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Field",
                value: "sectorId");

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Field",
                value: "email");

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Field",
                value: "phone");

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 9L,
                column: "Field",
                value: "mobile");

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 10L,
                column: "Field",
                value: "landLine");

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 11L,
                column: "Field",
                value: "fax");

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 12L,
                column: "Field",
                value: "addressLine1");

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 13L,
                column: "Field",
                value: "addressLine2");

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 14L,
                column: "Field",
                value: "buildingNo");

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 15L,
                column: "Field",
                value: "secondaryNo");

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 16L,
                column: "Field",
                value: "postalCode");

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 17L,
                column: "Field",
                value: "street");

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 18L,
                column: "Field",
                value: "street_OtherLanguage");

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 19L,
                column: "Field",
                value: "district");

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 20L,
                column: "Field",
                value: "district_OtherLanguage");

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 21L,
                column: "Field",
                value: "countryId");

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 22L,
                column: "Field",
                value: "cityId");

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 23L,
                column: "Field",
                value: "regionId");

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 24L,
                column: "Field",
                value: "inChargePersonName");

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 25L,
                column: "Field",
                value: "inChargePersonPositionId");

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 26L,
                column: "Field",
                value: "inChargePersonPhone1");

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 27L,
                column: "Field",
                value: "inChargePersonPhone2");

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 28L,
                column: "Field",
                value: "inChargePersonEmail");

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 29L,
                column: "Field",
                value: "paymentTermId");

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 30L,
                column: "Field",
                value: "validityPeriodId");

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 31L,
                column: "Field",
                value: "priceNoteId");

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 32L,
                column: "Field",
                value: "numberOfBranches");

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 33L,
                column: "Field",
                value: "permissionRequired");

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 34L,
                column: "Field",
                value: "note");

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 35L,
                column: "Field",
                value: "description");

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 36L,
                column: "Field",
                value: "effectiveDate");

            migrationBuilder.UpdateData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 37L,
                column: "Field",
                value: "status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
