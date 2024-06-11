using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace gateway.Migrations
{
    /// <inheritdoc />
    public partial class seeders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Child",
                columns: ["ChildID", "ChildName"],
                values: new object[,]
                {
                    { 1, "Child 1" },
                    { 2, "Child 2" }
                }
            );

            migrationBuilder.InsertData(
                table: "DesignSetting",
                columns: ["SettingID", "FontSize", "ThemeColor"],
                values: [1, 14, "green"]
            );

            migrationBuilder.InsertData(
                table: "Parent",
                columns: ["ParentID", "ParentName"],
                values: new object[,]
                {
                    { 1, "Parent 1" },
                    { 2, "Parent 2" }
                }
            );

            migrationBuilder.InsertData(
                table: "Psychologist",
                columns: ["PsychologistID", "PsychologistName"],
                values: new object[,]
                {
                    { 1, "Psychologist 1" },
                    { 2, "Psychologist 2" }
                }
            );

            migrationBuilder.InsertData(
                table: "User",
                columns: ["UserID", "LastLogin", "UserName", "UserRole"],
                values: new object[,]
                {
                    {
                        1,
                        new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        "User 1",
                        "Admin"
                    },
                    {
                        2,
                        new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        "User 2",
                        "Admin"
                    }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(table: "Child", keyColumn: "ChildID", keyValue: 1);

            migrationBuilder.DeleteData(table: "Child", keyColumn: "ChildID", keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DesignSetting",
                keyColumn: "SettingID",
                keyValue: 1
            );

            migrationBuilder.DeleteData(table: "Parent", keyColumn: "ParentID", keyValue: 1);

            migrationBuilder.DeleteData(table: "Parent", keyColumn: "ParentID", keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Psychologist",
                keyColumn: "PsychologistID",
                keyValue: 1
            );

            migrationBuilder.DeleteData(
                table: "Psychologist",
                keyColumn: "PsychologistID",
                keyValue: 2
            );

            migrationBuilder.DeleteData(table: "User", keyColumn: "UserID", keyValue: 1);

            migrationBuilder.DeleteData(table: "User", keyColumn: "UserID", keyValue: 2);
        }
    }
}
