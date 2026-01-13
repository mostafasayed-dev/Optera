using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialQuotationModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quotations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfBranches = table.Column<int>(type: "int", nullable: true),
                    PermissionRequired = table.Column<bool>(type: "bit", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubmitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InChargePersonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InChargePersonPositionId = table.Column<long>(type: "bigint", nullable: true),
                    InChargePersonPhone1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InChargePersonPhone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InChargePersonEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTermId = table.Column<long>(type: "bigint", nullable: true),
                    ValidityPeriodId = table.Column<long>(type: "bigint", nullable: true),
                    PriceNoteId = table.Column<long>(type: "bigint", nullable: true),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Updator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quotations_CategoryItems_InChargePersonPositionId",
                        column: x => x.InChargePersonPositionId,
                        principalTable: "CategoryItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Quotations_CategoryItems_PaymentTermId",
                        column: x => x.PaymentTermId,
                        principalTable: "CategoryItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Quotations_CategoryItems_PriceNoteId",
                        column: x => x.PriceNoteId,
                        principalTable: "CategoryItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Quotations_CategoryItems_ValidityPeriodId",
                        column: x => x.ValidityPeriodId,
                        principalTable: "CategoryItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Quotations_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ReferenceNumbers",
                columns: new[] { "Id", "Prefix", "Segment1", "Segment1_Format", "Segment2", "Segment2_Format", "Segment3", "Segment3_Format", "Segment4", "Segment4_Format" },
                values: new object[] { 2L, "QUT", "00", null, "yyMMdd", "Date", "000000", "Sequence", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_CustomerId",
                table: "Quotations",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_InChargePersonPositionId",
                table: "Quotations",
                column: "InChargePersonPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_PaymentTermId",
                table: "Quotations",
                column: "PaymentTermId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_PriceNoteId",
                table: "Quotations",
                column: "PriceNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_ValidityPeriodId",
                table: "Quotations",
                column: "ValidityPeriodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quotations");

            migrationBuilder.DeleteData(
                table: "ReferenceNumbers",
                keyColumn: "Id",
                keyValue: 2L);
        }
    }
}
