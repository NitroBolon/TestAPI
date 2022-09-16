using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TenantsAPI.Migrations
{
    public partial class RenameTableTenants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TenantSettings_Tasks_TenantId",
                schema: "tenant",
                table: "TenantSettings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                schema: "tenant",
                table: "Tasks");

            migrationBuilder.RenameTable(
                name: "Tasks",
                schema: "tenant",
                newName: "Tenants",
                newSchema: "tenant");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tenants",
                schema: "tenant",
                table: "Tenants",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TenantSettings_Tenants_TenantId",
                schema: "tenant",
                table: "TenantSettings",
                column: "TenantId",
                principalSchema: "tenant",
                principalTable: "Tenants",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TenantSettings_Tenants_TenantId",
                schema: "tenant",
                table: "TenantSettings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tenants",
                schema: "tenant",
                table: "Tenants");

            migrationBuilder.RenameTable(
                name: "Tenants",
                schema: "tenant",
                newName: "Tasks",
                newSchema: "tenant");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                schema: "tenant",
                table: "Tasks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TenantSettings_Tasks_TenantId",
                schema: "tenant",
                table: "TenantSettings",
                column: "TenantId",
                principalSchema: "tenant",
                principalTable: "Tasks",
                principalColumn: "Id");
        }
    }
}
