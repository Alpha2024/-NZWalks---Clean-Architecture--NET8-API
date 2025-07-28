using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZwalks.Infrasture.Migrations
{
    /// <inheritdoc />
    public partial class modelModification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "walk",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "walk",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "region",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "region",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "difficulty",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "difficulty",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "walk");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "walk");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "region");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "region");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "difficulty");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "difficulty");
        }
    }
}
