using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace gateway.Migrations
{
    /// <inheritdoc />
    public partial class emailaddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvailableSlot");

            migrationBuilder.DropTable(
                name: "DesignSetting");

            migrationBuilder.DropTable(
                name: "PsychologistBookingRequest");

            migrationBuilder.DropTable(
                name: "RequestApproval");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Psychologist",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Parent",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Child",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Child",
                keyColumn: "ChildID",
                keyValue: 1,
                column: "EmailAddress",
                value: null);

            migrationBuilder.UpdateData(
                table: "Child",
                keyColumn: "ChildID",
                keyValue: 2,
                column: "EmailAddress",
                value: null);

            migrationBuilder.UpdateData(
                table: "Parent",
                keyColumn: "ParentID",
                keyValue: 1,
                column: "EmailAddress",
                value: null);

            migrationBuilder.UpdateData(
                table: "Parent",
                keyColumn: "ParentID",
                keyValue: 2,
                column: "EmailAddress",
                value: null);

            migrationBuilder.UpdateData(
                table: "Psychologist",
                keyColumn: "PsychologistID",
                keyValue: 1,
                column: "EmailAddress",
                value: null);

            migrationBuilder.UpdateData(
                table: "Psychologist",
                keyColumn: "PsychologistID",
                keyValue: 2,
                column: "EmailAddress",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Psychologist");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Parent");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Child");

            migrationBuilder.CreateTable(
                name: "AvailableSlot",
                columns: table => new
                {
                    AvailableSlotID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PsychologistID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableSlot", x => x.AvailableSlotID);
                    table.ForeignKey(
                        name: "FK_AvailableSlot_Psychologist_PsychologistID",
                        column: x => x.PsychologistID,
                        principalTable: "Psychologist",
                        principalColumn: "PsychologistID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DesignSetting",
                columns: table => new
                {
                    SettingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FontSize = table.Column<int>(type: "int", nullable: false),
                    ThemeColor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesignSetting", x => x.SettingID);
                });

            migrationBuilder.CreateTable(
                name: "PsychologistBookingRequest",
                columns: table => new
                {
                    RequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChildID = table.Column<int>(type: "int", nullable: false),
                    ParentID = table.Column<int>(type: "int", nullable: false),
                    PsychologistID = table.Column<int>(type: "int", nullable: false),
                    DecisionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreferredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PreferredTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PsychologistBookingRequest", x => x.RequestID);
                    table.ForeignKey(
                        name: "FK_PsychologistBookingRequest_Child_ChildID",
                        column: x => x.ChildID,
                        principalTable: "Child",
                        principalColumn: "ChildID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PsychologistBookingRequest_Parent_ParentID",
                        column: x => x.ParentID,
                        principalTable: "Parent",
                        principalColumn: "ParentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PsychologistBookingRequest_Psychologist_PsychologistID",
                        column: x => x.PsychologistID,
                        principalTable: "Psychologist",
                        principalColumn: "PsychologistID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestApproval",
                columns: table => new
                {
                    RequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PsychologistID = table.Column<int>(type: "int", nullable: false),
                    ApprovalStatus = table.Column<bool>(type: "bit", nullable: false),
                    NotificationSent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestApproval", x => x.RequestID);
                    table.ForeignKey(
                        name: "FK_RequestApproval_Psychologist_PsychologistID",
                        column: x => x.PsychologistID,
                        principalTable: "Psychologist",
                        principalColumn: "PsychologistID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserRole = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.InsertData(
                table: "DesignSetting",
                columns: new[] { "SettingID", "FontSize", "ThemeColor" },
                values: new object[] { 1, 14, "green" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserID", "LastLogin", "UserName", "UserRole" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User 1", "Admin" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User 2", "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvailableSlot_PsychologistID",
                table: "AvailableSlot",
                column: "PsychologistID");

            migrationBuilder.CreateIndex(
                name: "IX_PsychologistBookingRequest_ChildID",
                table: "PsychologistBookingRequest",
                column: "ChildID");

            migrationBuilder.CreateIndex(
                name: "IX_PsychologistBookingRequest_ParentID",
                table: "PsychologistBookingRequest",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_PsychologistBookingRequest_PsychologistID",
                table: "PsychologistBookingRequest",
                column: "PsychologistID");

            migrationBuilder.CreateIndex(
                name: "IX_RequestApproval_PsychologistID",
                table: "RequestApproval",
                column: "PsychologistID");
        }
    }
}
