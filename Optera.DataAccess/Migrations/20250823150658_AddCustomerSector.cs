using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerSector : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CategoryItems_ClassId",
                table: "Customers");

            migrationBuilder.AlterColumn<long>(
                name: "ClassId",
                table: "Customers",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "SectorId",
                table: "Customers",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_SectorId",
                table: "Customers",
                column: "SectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CategoryItems_ClassId",
                table: "Customers",
                column: "ClassId",
                principalTable: "CategoryItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CategoryItems_SectorId",
                table: "Customers",
                column: "SectorId",
                principalTable: "CategoryItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CategoryItems_ClassId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CategoryItems_SectorId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_SectorId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "SectorId",
                table: "Customers");

            migrationBuilder.AlterColumn<long>(
                name: "ClassId",
                table: "Customers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CategoryItems_ClassId",
                table: "Customers",
                column: "ClassId",
                principalTable: "CategoryItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
