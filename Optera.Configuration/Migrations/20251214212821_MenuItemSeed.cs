using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Optera.Configuration.Migrations
{
    /// <inheritdoc />
    public partial class MenuItemSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "MenuItems");

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Data", "Expanded", "Group", "Hidden", "Home", "Icon", "Link", "Order", "ParentId", "Target", "Title", "Url" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), null, null, null, null, true, "eva home-outline", "/pages/dashboard", 0, null, null, "Home", null },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "AUTH_1000", null, null, null, null, "eva options-2-outline", null, 0, null, null, "Miscellaneous", null },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "AUTH_1010", null, null, null, null, "eva globe-outline", "/pages/miscellaneous/countries", 10, new Guid("00000000-0000-0000-0000-000000000002"), null, "Countries", null },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "AUTH_1020", null, null, null, null, "eva home-outline", "/pages/miscellaneous/cities", 20, new Guid("00000000-0000-0000-0000-000000000002"), null, "Cities", null },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "AUTH_1030", null, null, null, null, "eva map-outline", "/pages/miscellaneous/regions", 30, new Guid("00000000-0000-0000-0000-000000000002"), null, "Regions", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "MenuItems",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "MenuItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
