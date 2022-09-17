using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LicensesAPI.Migrations
{
    public partial class ExtendLicenseModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Licenses_LicenseTypes_TypeId",
                schema: "license",
                table: "Licenses");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "license",
                table: "LicenseTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsOfferActive",
                schema: "license",
                table: "LicenseTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<long>(
                name: "TypeId",
                schema: "license",
                table: "Licenses",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Licenses_LicenseTypes_TypeId",
                schema: "license",
                table: "Licenses",
                column: "TypeId",
                principalSchema: "license",
                principalTable: "LicenseTypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Licenses_LicenseTypes_TypeId",
                schema: "license",
                table: "Licenses");

            migrationBuilder.DropColumn(
                name: "IsOfferActive",
                schema: "license",
                table: "LicenseTypes");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "license",
                table: "LicenseTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "TypeId",
                schema: "license",
                table: "Licenses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Licenses_LicenseTypes_TypeId",
                schema: "license",
                table: "Licenses",
                column: "TypeId",
                principalSchema: "license",
                principalTable: "LicenseTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
