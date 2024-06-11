using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gateway.Migrations
{
    /// <inheritdoc />
    public partial class bookingtableupdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequestDateTime",
                table: "BookingRequest",
                newName: "RequestDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "PreferredDateTime",
                table: "BookingRequest",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PsychologistID",
                table: "BookingRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookingRequest_PsychologistID",
                table: "BookingRequest",
                column: "PsychologistID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingRequest_Psychologist_PsychologistID",
                table: "BookingRequest",
                column: "PsychologistID",
                principalTable: "Psychologist",
                principalColumn: "PsychologistID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingRequest_Psychologist_PsychologistID",
                table: "BookingRequest");

            migrationBuilder.DropIndex(
                name: "IX_BookingRequest_PsychologistID",
                table: "BookingRequest");

            migrationBuilder.DropColumn(
                name: "PreferredDateTime",
                table: "BookingRequest");

            migrationBuilder.DropColumn(
                name: "PsychologistID",
                table: "BookingRequest");

            migrationBuilder.RenameColumn(
                name: "RequestDate",
                table: "BookingRequest",
                newName: "RequestDateTime");
        }
    }
}
