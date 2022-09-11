using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsersAPI.Migrations
{
    public partial class AlterProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProperties_Users_UserId1",
                table: "UserProperties");

            migrationBuilder.DropIndex(
                name: "IX_UserProperties_UserId1",
                table: "UserProperties");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserProperties");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<long>(
                name: "ValueInt",
                table: "UserProperties",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ValueDateTime",
                table: "UserProperties",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserProperties",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ValueBool",
                table: "UserProperties",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserProperties_UserId",
                table: "UserProperties",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProperties_Users_UserId",
                table: "UserProperties",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProperties_Users_UserId",
                table: "UserProperties");

            migrationBuilder.DropIndex(
                name: "IX_UserProperties_UserId",
                table: "UserProperties");

            migrationBuilder.DropColumn(
                name: "ValueBool",
                table: "UserProperties");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<long>(
                name: "ValueInt",
                table: "UserProperties",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ValueDateTime",
                table: "UserProperties",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserProperties",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "UserProperties",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_UserProperties_UserId1",
                table: "UserProperties",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProperties_Users_UserId1",
                table: "UserProperties",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
