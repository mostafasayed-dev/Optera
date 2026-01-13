using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddQuotationEditComponentFormsControlsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ComponentFormControls",
                columns: new[] { "Id", "ComponentFormId", "DefaultValue", "Enabled", "Label", "Mask", "Max", "MaxLength", "Min", "MinLength", "Name", "Required", "Type", "Visible" },
                values: new object[,]
                {
                    { 1L, 1L, null, true, "Customer Name", null, null, null, null, null, "name", false, null, true },
                    { 2L, 1L, null, true, "Customer Name (Other Lang.)", null, null, null, null, null, "name_OtherLanguage", false, null, true },
                    { 3L, 1L, null, true, "Brand Name", null, null, null, null, null, "brandName", false, null, true },
                    { 4L, 1L, null, true, "Brand Name (Other Lang.)", null, null, null, null, null, "brandName_OtherLanguage", false, null, true },
                    { 5L, 1L, null, true, "Class", null, null, null, null, null, "classId", false, null, true },
                    { 6L, 1L, null, true, "Business Sector", null, null, null, null, null, "sectorId", false, null, true },
                    { 7L, 2L, null, true, "Email", null, null, null, null, null, "email", false, null, true },
                    { 8L, 2L, null, true, "Phone", null, null, null, null, null, "phone", false, null, true },
                    { 9L, 2L, null, true, "Mobile", null, null, null, null, null, "mobile", false, null, true },
                    { 10L, 2L, null, true, "Land Line", null, null, null, null, null, "landLine", false, null, true },
                    { 11L, 2L, null, true, "Fax", null, null, null, null, null, "fax", false, null, true },
                    { 12L, 3L, null, true, "Address Line 1", null, null, null, null, null, "addressLine1", false, null, true },
                    { 13L, 3L, null, true, "Address Line 2", null, null, null, null, null, "addressLine2", false, null, true },
                    { 14L, 3L, null, true, "Building No.", null, null, null, null, null, "buildingNo", false, null, true },
                    { 15L, 3L, null, true, "Secondary No.", null, null, null, null, null, "secondaryNo", false, null, true },
                    { 16L, 3L, null, true, "Postal Code", null, null, null, null, null, "postalCode", false, null, true },
                    { 17L, 3L, null, true, "Street", null, null, null, null, null, "street", false, null, true },
                    { 18L, 3L, null, true, "Street (Other Lang)", null, null, null, null, null, "street_OtherLanguage", false, null, true },
                    { 19L, 3L, null, true, "District", null, null, null, null, null, "district", false, null, true },
                    { 20L, 3L, null, true, "District (Other Lang)", null, null, null, null, null, "district_OtherLanguage", false, null, true },
                    { 21L, 3L, null, true, "Country", null, null, null, null, null, "countryId", false, null, true },
                    { 22L, 3L, null, true, "City", null, null, null, null, null, "cityId", false, null, true },
                    { 23L, 3L, null, true, "Region", null, null, null, null, null, "regionId", false, null, true },
                    { 24L, 4L, null, true, "Name", null, null, null, null, null, "inChargePersonName", false, null, true },
                    { 25L, 4L, null, true, "Position", null, null, null, null, null, "inChargePersonPositionId", false, null, true },
                    { 26L, 4L, null, true, "Phone 1", null, null, null, null, null, "inChargePersonPhone1", false, null, true },
                    { 27L, 4L, null, true, "Phone 2", null, null, null, null, null, "inChargePersonPhone2", false, null, true },
                    { 28L, 4L, null, true, "Email", null, null, null, null, null, "inChargePersonEmail", false, null, true },
                    { 29L, 5L, null, true, "Payment Term", null, null, null, null, null, "paymentTermId", false, null, true },
                    { 30L, 5L, null, true, "Validity Period", null, null, null, null, null, "validityPeriodId", false, null, true },
                    { 31L, 5L, null, true, "Price Note", null, null, null, null, null, "priceNoteId", false, null, true },
                    { 32L, 6L, null, true, "Number of Branches", null, null, null, null, null, "numberOfBranches", false, null, true },
                    { 33L, 6L, null, true, "Permission Required", null, null, null, null, null, "permissionRequired", false, null, true },
                    { 34L, 6L, null, true, "Notes", null, null, null, null, null, "note", false, null, true },
                    { 35L, 6L, null, true, "Description", null, null, null, null, null, "description", false, null, true },
                    { 36L, 6L, null, true, "Effective Date", null, null, null, null, null, "effectiveDate", false, null, true },
                    { 37L, 6L, null, true, "Status", null, null, null, null, null, "status", false, null, true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 31L);

            migrationBuilder.DeleteData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 32L);

            migrationBuilder.DeleteData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 33L);

            migrationBuilder.DeleteData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 34L);

            migrationBuilder.DeleteData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 35L);

            migrationBuilder.DeleteData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 36L);

            migrationBuilder.DeleteData(
                table: "ComponentFormControls",
                keyColumn: "Id",
                keyValue: 37L);
        }
    }
}
