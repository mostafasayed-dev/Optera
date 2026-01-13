using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddDataTableModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataTables",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataTables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataTableColumns",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataTableId = table.Column<long>(type: "bigint", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sortable = table.Column<bool>(type: "bit", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false),
                    DisplayCurrency = table.Column<bool>(type: "bit", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCheck = table.Column<bool>(type: "bit", nullable: false),
                    Datatype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataTableColumns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataTableColumns_DataTables_DataTableId",
                        column: x => x.DataTableId,
                        principalTable: "DataTables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DataTables",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "countries-list" },
                    { 2L, "cities-list" },
                    { 3L, "regions-list" },
                    { 4L, "categories-list" },
                    { 5L, "categories-items-list" },
                    { 6L, "quotations-list" }
                });

            migrationBuilder.InsertData(
                table: "DataTableColumns",
                columns: new[] { "Id", "Color", "DataTableId", "Datatype", "DisplayCurrency", "IsCheck", "Name", "Order", "Sortable", "Text", "Visible" },
                values: new object[,]
                {
                    { 1L, null, 1L, null, false, false, "id", 0, true, "ID", false },
                    { 2L, null, 1L, null, false, false, "name", 1, true, "Country Name", true },
                    { 3L, null, 1L, null, false, false, "name_OtherLanguage", 2, true, "Country Name (Other Lang.)", true },
                    { 4L, null, 1L, null, false, false, "status", 3, true, "Status", true },
                    { 5L, null, 2L, null, false, false, "id", 0, true, "ID", false },
                    { 6L, null, 2L, null, false, false, "name", 1, true, "City Name", true },
                    { 7L, null, 2L, null, false, false, "name_OtherLanguage", 2, true, "City Name (Other Lang.)", true },
                    { 8L, null, 2L, null, false, false, "countryName", 3, true, "Country", true },
                    { 9L, null, 2L, null, false, false, "status", 4, true, "Status", true },
                    { 10L, null, 3L, null, false, false, "id", 0, true, "ID", false },
                    { 11L, null, 3L, null, false, false, "name", 1, true, "Region Name", true },
                    { 12L, null, 3L, null, false, false, "name_OtherLanguage", 2, true, "Region Name (Other Lang.)", true },
                    { 13L, null, 3L, null, false, false, "cityName", 3, true, "City", true },
                    { 14L, null, 3L, null, false, false, "cityId", 4, true, "City ID", false },
                    { 15L, null, 3L, null, false, false, "countryName", 5, true, "Country", true },
                    { 16L, null, 3L, null, false, false, "status", 6, true, "Status", true },
                    { 17L, null, 4L, null, false, false, "id", 0, true, "ID", false },
                    { 18L, null, 4L, null, false, false, "name", 1, true, "Category Name", true },
                    { 19L, null, 4L, null, false, false, "description", 2, true, "Description", true },
                    { 20L, null, 4L, null, false, false, "status", 3, true, "Status", true },
                    { 21L, null, 5L, null, false, false, "id", 0, true, "ID", false },
                    { 22L, null, 5L, null, false, false, "name", 1, true, "Category Name", true },
                    { 23L, null, 5L, null, false, false, "name_OtherLanguage", 2, true, "Description", true },
                    { 24L, null, 5L, null, false, false, "categoryName", 3, true, "Description", true },
                    { 25L, null, 5L, null, false, false, "categoryId", 4, true, "Description", false },
                    { 26L, null, 5L, null, false, false, "status", 5, true, "Status", true },
                    { 27L, null, 6L, null, false, false, "id", 0, true, "ID", false },
                    { 28L, null, 6L, null, false, false, "code", 1, true, "Code", true },
                    { 29L, null, 6L, null, false, false, "customerName", 2, true, "Customer Name", true },
                    { 30L, null, 6L, null, false, false, "customerBrandName", 3, true, "Customer Brand Name", true },
                    { 31L, null, 6L, "date", false, false, "effectiveDate", 4, true, "Effective Date", true },
                    { 32L, null, 6L, null, false, false, "status", 5, true, "Status", true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataTableColumns_DataTableId",
                table: "DataTableColumns",
                column: "DataTableId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataTableColumns");

            migrationBuilder.DropTable(
                name: "DataTables");
        }
    }
}
