using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TenantsAPI.Migrations
{
    public partial class ExtendTenantProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "tenant",
                table: "Tenants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "LicenseId",
                schema: "tenant",
                table: "Tenants",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                schema: "tenant",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "tenant",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "LicenseId",
                schema: "tenant",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                schema: "tenant",
                table: "Tenants");
        }
    }
}
