using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCustomerIdentificationModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerIdentifications",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentificationTypeId = table.Column<long>(type: "bigint", nullable: false),
                    IdentificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CountryId = table.Column<long>(type: "bigint", nullable: true),
                    CityId = table.Column<long>(type: "bigint", nullable: true),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Updator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerIdentifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerIdentifications_CategoryItems_IdentificationTypeId",
                        column: x => x.IdentificationTypeId,
                        principalTable: "CategoryItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerIdentifications_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerIdentifications_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerIdentifications_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Creator", "Description", "Name", "Status", "UpdatedAt", "Updator" },
                values: new object[] { 5L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System", "Customer Identification Types", "Identification Types", "Active", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System" });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerIdentifications_CityId",
                table: "CustomerIdentifications",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerIdentifications_CountryId",
                table: "CustomerIdentifications",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerIdentifications_CustomerId",
                table: "CustomerIdentifications",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerIdentifications_IdentificationTypeId",
                table: "CustomerIdentifications",
                column: "IdentificationTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerIdentifications");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5L);
        }
    }
}
