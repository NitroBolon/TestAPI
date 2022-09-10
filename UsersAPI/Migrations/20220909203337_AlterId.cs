using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsersAPI.Migrations
{
    public partial class AlterId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            ConvertStringIdToGuidId("Users", migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Users");
        }

        private void ConvertStringIdToGuidId(string tableName, MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>("Id2", $"{tableName}", nullable: true, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
            migrationBuilder.DropPrimaryKey($"PK_{tableName}", $"{tableName}");
            migrationBuilder.DropColumn("Id", $"{tableName}");
            migrationBuilder.RenameColumn("Id2", $"{tableName}", "Id");

            migrationBuilder.Sql(
        @$"UPDATE {tableName} SET Id = NEWID () ;");

            migrationBuilder.AlterColumn<Guid>(name: "Id", table: $"{tableName}", nullable: false, oldNullable: true);
            migrationBuilder.AddPrimaryKey($"PK_{tableName}", $"{tableName}", column: "Id");
        }
    }
}
