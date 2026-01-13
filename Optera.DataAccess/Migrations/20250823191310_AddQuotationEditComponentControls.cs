using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddQuotationEditComponentControls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "ComponentControls",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "ComponentControls",
                columns: new[] { "Id", "ComponentId", "Enabled", "Label", "Mask", "Name", "Required", "Type", "Visible" },
                values: new object[,]
                {
                    { 1L, 1L, true, "Customer Name", null, "customerInfo.name", false, null, true },
                    { 2L, 1L, true, "Customer Name (Other Lang.)", null, "customerInfo.name_OtherLanguage", false, null, true },
                    { 3L, 1L, true, "Brand Name", null, "customerInfo.brandName", false, null, true },
                    { 4L, 1L, true, "Brand Name (Other Lang.)", null, "customerInfo.brandName_OtherLanguage", false, null, true },
                    { 5L, 1L, true, "Class", null, "customerInfo.classId", false, null, true },
                    { 6L, 1L, true, "Business Sector", null, "customerInfo.sectorId", false, null, true },
                    { 7L, 1L, true, "Email", null, "contactInfo.email", false, null, true },
                    { 8L, 1L, true, "Phone", null, "contactInfo.phone", false, null, true },
                    { 9L, 1L, true, "Mobile", null, "contactInfo.mobile", false, null, true },
                    { 10L, 1L, true, "Land Line", null, "contactInfo.landLine", false, null, true },
                    { 11L, 1L, true, "Fax", null, "contactInfo.fax", false, null, true },
                    { 12L, 1L, true, "Address Line 1", null, "addressInfo.addressLine1", false, null, true },
                    { 13L, 1L, true, "Address Line 2", null, "addressInfo.addressLine2", false, null, true },
                    { 14L, 1L, true, "Building No.", null, "addressInfo.buildingNo", false, null, true },
                    { 15L, 1L, true, "Secondary No.", null, "addressInfo.secondaryNo", false, null, true },
                    { 16L, 1L, true, "Postal Code", null, "addressInfo.postalCode", false, null, true },
                    { 17L, 1L, true, "Street", null, "addressInfo.street", false, null, true },
                    { 18L, 1L, true, "Street (Other Lang)", null, "addressInfo.street_OtherLanguage", false, null, true },
                    { 19L, 1L, true, "District", null, "addressInfo.district", false, null, true },
                    { 20L, 1L, true, "District (Other Lang)", null, "addressInfo.district_OtherLanguage", false, null, true },
                    { 21L, 1L, true, "Country", null, "addressInfo.countryId", false, null, true },
                    { 22L, 1L, true, "City", null, "addressInfo.cityId", false, null, true },
                    { 23L, 1L, true, "Region", null, "addressInfo.regionId", false, null, true },
                    { 24L, 1L, true, "Name", null, "inChargePersonInfo.inChargePersonName", false, null, true },
                    { 25L, 1L, true, "Position", null, "inChargePersonInfo.inChargePersonPositionId", false, null, true },
                    { 26L, 1L, true, "Phone 1", null, "inChargePersonInfo.inChargePersonPhone1", false, null, true },
                    { 27L, 1L, true, "Phone 2", null, "inChargePersonInfo.inChargePersonPhone2", false, null, true },
                    { 28L, 1L, true, "Email", null, "inChargePersonInfo.inChargePersonEmail", false, null, true },
                    { 29L, 1L, true, "Payment Term", null, "paymentAndTermsInfo.paymentTermId", false, null, true },
                    { 30L, 1L, true, "Validity Period", null, "paymentAndTermsInfo.validityPeriodId", false, null, true },
                    { 31L, 1L, true, "Price Note", null, "paymentAndTermsInfo.priceNoteId", false, null, true },
                    { 32L, 1L, true, "Number of Branches", null, "otherInfo.numberOfBranches", false, null, true },
                    { 33L, 1L, true, "Permission Required", null, "otherInfo.permissionRequired", false, null, true },
                    { 34L, 1L, true, "Notes", null, "otherInfo.note", false, null, true },
                    { 35L, 1L, true, "Description", null, "otherInfo.description", false, null, true },
                    { 36L, 1L, true, "Effective Date", null, "otherInfo.effectiveDate", false, null, true },
                    { 37L, 1L, true, "Status", null, "otherInfo.status", false, null, true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ComponentControls",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ComponentControls",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "ComponentControls",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "ComponentControls",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "ComponentControls",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "ComponentControls",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "ComponentControls",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "ComponentControls",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "ComponentControls",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "ComponentControls",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "ComponentControls",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "ComponentControls",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "ComponentControls",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "ComponentControls",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "ComponentControls",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "ComponentControls",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "ComponentControls",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "ComponentControls",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "ComponentControls",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "ComponentControls",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "ComponentControls",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "ComponentControls",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "ComponentControls",
                keyColumn: "Id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "ComponentControls",
                keyColumn: "Id",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "ComponentControls",
                keyColumn: "Id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "ComponentControls",
                keyColumn: "Id",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "ComponentControls",
                keyColumn: "Id",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "ComponentControls",
                keyColumn: "Id",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "ComponentControls",
                keyColumn: "Id",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "ComponentControls",
                keyColumn: "Id",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                table: "ComponentControls",
                keyColumn: "Id",
                keyValue: 31L);

            migrationBuilder.DeleteData(
                table: "ComponentControls",
                keyColumn: "Id",
                keyValue: 32L);

            migrationBuilder.DeleteData(
                table: "ComponentControls",
                keyColumn: "Id",
                keyValue: 33L);

            migrationBuilder.DeleteData(
                table: "ComponentControls",
                keyColumn: "Id",
                keyValue: 34L);

            migrationBuilder.DeleteData(
                table: "ComponentControls",
                keyColumn: "Id",
                keyValue: 35L);

            migrationBuilder.DeleteData(
                table: "ComponentControls",
                keyColumn: "Id",
                keyValue: 36L);

            migrationBuilder.DeleteData(
                table: "ComponentControls",
                keyColumn: "Id",
                keyValue: 37L);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "ComponentControls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
