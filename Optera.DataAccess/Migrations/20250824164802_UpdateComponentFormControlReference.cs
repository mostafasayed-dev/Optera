using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateComponentFormControlReference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComponentFormControls_Components_ComponentId",
                table: "ComponentFormControls");

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

            migrationBuilder.RenameColumn(
                name: "ComponentId",
                table: "ComponentFormControls",
                newName: "ComponentFormId");

            migrationBuilder.RenameIndex(
                name: "IX_ComponentFormControls_ComponentId",
                table: "ComponentFormControls",
                newName: "IX_ComponentFormControls_ComponentFormId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComponentFormControls_ComponentForms_ComponentFormId",
                table: "ComponentFormControls",
                column: "ComponentFormId",
                principalTable: "ComponentForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComponentFormControls_ComponentForms_ComponentFormId",
                table: "ComponentFormControls");

            migrationBuilder.RenameColumn(
                name: "ComponentFormId",
                table: "ComponentFormControls",
                newName: "ComponentId");

            migrationBuilder.RenameIndex(
                name: "IX_ComponentFormControls_ComponentFormId",
                table: "ComponentFormControls",
                newName: "IX_ComponentFormControls_ComponentId");

            migrationBuilder.InsertData(
                table: "ComponentFormControls",
                columns: new[] { "Id", "ComponentId", "DefaultValue", "Enabled", "Label", "Mask", "Max", "MaxLength", "Min", "MinLength", "Name", "Required", "Type", "Visible" },
                values: new object[,]
                {
                    { 1L, 1L, null, true, "Customer Name", null, null, null, null, null, "customerInfo.name", false, null, true },
                    { 2L, 1L, null, true, "Customer Name (Other Lang.)", null, null, null, null, null, "customerInfo.name_OtherLanguage", false, null, true },
                    { 3L, 1L, null, true, "Brand Name", null, null, null, null, null, "customerInfo.brandName", false, null, true },
                    { 4L, 1L, null, true, "Brand Name (Other Lang.)", null, null, null, null, null, "customerInfo.brandName_OtherLanguage", false, null, true },
                    { 5L, 1L, null, true, "Class", null, null, null, null, null, "customerInfo.classId", false, null, true },
                    { 6L, 1L, null, true, "Business Sector", null, null, null, null, null, "customerInfo.sectorId", false, null, true },
                    { 7L, 1L, null, true, "Email", null, null, null, null, null, "contactInfo.email", false, null, true },
                    { 8L, 1L, null, true, "Phone", null, null, null, null, null, "contactInfo.phone", false, null, true },
                    { 9L, 1L, null, true, "Mobile", null, null, null, null, null, "contactInfo.mobile", false, null, true },
                    { 10L, 1L, null, true, "Land Line", null, null, null, null, null, "contactInfo.landLine", false, null, true },
                    { 11L, 1L, null, true, "Fax", null, null, null, null, null, "contactInfo.fax", false, null, true },
                    { 12L, 1L, null, true, "Address Line 1", null, null, null, null, null, "addressInfo.addressLine1", false, null, true },
                    { 13L, 1L, null, true, "Address Line 2", null, null, null, null, null, "addressInfo.addressLine2", false, null, true },
                    { 14L, 1L, null, true, "Building No.", null, null, null, null, null, "addressInfo.buildingNo", false, null, true },
                    { 15L, 1L, null, true, "Secondary No.", null, null, null, null, null, "addressInfo.secondaryNo", false, null, true },
                    { 16L, 1L, null, true, "Postal Code", null, null, null, null, null, "addressInfo.postalCode", false, null, true },
                    { 17L, 1L, null, true, "Street", null, null, null, null, null, "addressInfo.street", false, null, true },
                    { 18L, 1L, null, true, "Street (Other Lang)", null, null, null, null, null, "addressInfo.street_OtherLanguage", false, null, true },
                    { 19L, 1L, null, true, "District", null, null, null, null, null, "addressInfo.district", false, null, true },
                    { 20L, 1L, null, true, "District (Other Lang)", null, null, null, null, null, "addressInfo.district_OtherLanguage", false, null, true },
                    { 21L, 1L, null, true, "Country", null, null, null, null, null, "addressInfo.countryId", false, null, true },
                    { 22L, 1L, null, true, "City", null, null, null, null, null, "addressInfo.cityId", false, null, true },
                    { 23L, 1L, null, true, "Region", null, null, null, null, null, "addressInfo.regionId", false, null, true },
                    { 24L, 1L, null, true, "Name", null, null, null, null, null, "inChargePersonInfo.inChargePersonName", false, null, true },
                    { 25L, 1L, null, true, "Position", null, null, null, null, null, "inChargePersonInfo.inChargePersonPositionId", false, null, true },
                    { 26L, 1L, null, true, "Phone 1", null, null, null, null, null, "inChargePersonInfo.inChargePersonPhone1", false, null, true },
                    { 27L, 1L, null, true, "Phone 2", null, null, null, null, null, "inChargePersonInfo.inChargePersonPhone2", false, null, true },
                    { 28L, 1L, null, true, "Email", null, null, null, null, null, "inChargePersonInfo.inChargePersonEmail", false, null, true },
                    { 29L, 1L, null, true, "Payment Term", null, null, null, null, null, "paymentAndTermsInfo.paymentTermId", false, null, true },
                    { 30L, 1L, null, true, "Validity Period", null, null, null, null, null, "paymentAndTermsInfo.validityPeriodId", false, null, true },
                    { 31L, 1L, null, true, "Price Note", null, null, null, null, null, "paymentAndTermsInfo.priceNoteId", false, null, true },
                    { 32L, 1L, null, true, "Number of Branches", null, null, null, null, null, "otherInfo.numberOfBranches", false, null, true },
                    { 33L, 1L, null, true, "Permission Required", null, null, null, null, null, "otherInfo.permissionRequired", false, null, true },
                    { 34L, 1L, null, true, "Notes", null, null, null, null, null, "otherInfo.note", false, null, true },
                    { 35L, 1L, null, true, "Description", null, null, null, null, null, "otherInfo.description", false, null, true },
                    { 36L, 1L, null, true, "Effective Date", null, null, null, null, null, "otherInfo.effectiveDate", false, null, true },
                    { 37L, 1L, null, true, "Status", null, null, null, null, null, "otherInfo.status", false, null, true }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ComponentFormControls_Components_ComponentId",
                table: "ComponentFormControls",
                column: "ComponentId",
                principalTable: "Components",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
