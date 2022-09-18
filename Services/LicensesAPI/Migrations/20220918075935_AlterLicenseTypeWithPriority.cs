using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LicensesAPI.Migrations
{
    public partial class AlterLicenseTypeWithPriority : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Priority",
                schema: "license",
                table: "LicenseTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                schema: "license",
                table: "LicenseTypes");
        }
    }
}
