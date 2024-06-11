using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gateway.Migrations
{
    /// <inheritdoc />
    public partial class bookingtableupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreferredDate",
                table: "BookingRequest");

            migrationBuilder.DropColumn(
                name: "PreferredTime",
                table: "BookingRequest");

            migrationBuilder.RenameColumn(
                name: "RequestDate",
                table: "BookingRequest",
                newName: "RequestDateTime");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "BookingRequest",
                newName: "Comments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequestDateTime",
                table: "BookingRequest",
                newName: "RequestDate");

            migrationBuilder.RenameColumn(
                name: "Comments",
                table: "BookingRequest",
                newName: "Notes");

            migrationBuilder.AddColumn<DateTime>(
                name: "PreferredDate",
                table: "BookingRequest",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "PreferredTime",
                table: "BookingRequest",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
