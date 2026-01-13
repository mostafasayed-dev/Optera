using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RenameComponentControlToComponentFormControlModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComponentControls");

            migrationBuilder.CreateTable(
                name: "ComponentFormControls",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComponentId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Required = table.Column<bool>(type: "bit", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false),
                    Mask = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Min = table.Column<int>(type: "int", nullable: true),
                    Max = table.Column<int>(type: "int", nullable: true),
                    MinLength = table.Column<int>(type: "int", nullable: true),
                    MaxLength = table.Column<int>(type: "int", nullable: true),
                    DefaultValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentFormControls", x => x.Id);
                    table.CheckConstraint("CK_ComponentControl_Type", "[Type] IN ('text','number','email','date')");
                    table.ForeignKey(
                        name: "FK_ComponentFormControls_Components_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Components",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ComponentFormControls_ComponentId",
                table: "ComponentFormControls",
                column: "ComponentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComponentFormControls");

            migrationBuilder.CreateTable(
                name: "ComponentControls",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComponentId = table.Column<long>(type: "bigint", nullable: false),
                    DefaultValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mask = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Max = table.Column<int>(type: "int", nullable: true),
                    MaxLength = table.Column<int>(type: "int", nullable: true),
                    Min = table.Column<int>(type: "int", nullable: true),
                    MinLength = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Required = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Visible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentControls", x => x.Id);
                    table.CheckConstraint("CK_ComponentControl_Type", "[Type] IN ('text','number','email','date')");
                    table.ForeignKey(
                        name: "FK_ComponentControls_Components_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Components",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ComponentControls",
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

            migrationBuilder.CreateIndex(
                name: "IX_ComponentControls_ComponentId",
                table: "ComponentControls",
                column: "ComponentId");
        }
    }
}
