using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddQuotationEditComponentForms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ComponentForms",
                columns: new[] { "Id", "ComponentId", "Label", "Name" },
                values: new object[,]
                {
                    { 1L, 1L, "Customer Info.", "customerInfoForm" },
                    { 2L, 1L, "Contact Info.", "contactInfoForm" },
                    { 3L, 1L, "Address Info.", "addressInfoForm" },
                    { 4L, 1L, "Person in Charge", "inChargePersonInfoForm" },
                    { 5L, 1L, "Terms & Conditions", "paymentAndTermsInfoForm" },
                    { 6L, 1L, "Other Info.", "otherInfoForm" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ComponentForms",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ComponentForms",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "ComponentForms",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "ComponentForms",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "ComponentForms",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "ComponentForms",
                keyColumn: "Id",
                keyValue: 6L);
        }
    }
}
