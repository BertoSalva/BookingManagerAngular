using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gateway.Migrations
{
    /// <inheritdoc />
    public partial class addnamecolumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserName",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PsychologistName",
                table: "Psychologist",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ParentName",
                table: "Parent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ChildName",
                table: "Child",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PsychologistName",
                table: "Psychologist");

            migrationBuilder.DropColumn(
                name: "ParentName",
                table: "Parent");

            migrationBuilder.DropColumn(
                name: "ChildName",
                table: "Child");
        }
    }
}
