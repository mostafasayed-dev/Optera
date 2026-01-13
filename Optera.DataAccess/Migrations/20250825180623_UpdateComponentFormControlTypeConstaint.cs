using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optera.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateComponentFormControlTypeConstaint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_ComponentControl_Type",
                table: "ComponentFormControls");

            migrationBuilder.AddCheckConstraint(
                name: "CK_ComponentControl_Type",
                table: "ComponentFormControls",
                sql: "[Type] IN ('text','number','email','date', 'boolean')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_ComponentControl_Type",
                table: "ComponentFormControls");

            migrationBuilder.AddCheckConstraint(
                name: "CK_ComponentControl_Type",
                table: "ComponentFormControls",
                sql: "[Type] IN ('text','number','email','date')");
        }
    }
}
