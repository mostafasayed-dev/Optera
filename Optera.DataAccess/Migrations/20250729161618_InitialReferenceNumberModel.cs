using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialReferenceNumberModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReferenceNumbers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prefix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Segment1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Segment2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Segment3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Segment4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Segment1_Format = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Segment2_Format = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Segment3_Format = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Segment4_Format = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastSequence = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferenceNumbers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ReferenceNumbers",
                columns: new[] { "Id", "Prefix", "Segment1", "Segment1_Format", "Segment2", "Segment2_Format", "Segment3", "Segment3_Format", "Segment4", "Segment4_Format" },
                values: new object[] { 1L, "WO", "00", null, "yyMMdd", "Date", "000000", null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReferenceNumbers");
        }
    }
}
