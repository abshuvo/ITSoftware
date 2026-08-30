using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITSoftware.Migrations
{
    public partial class AddNoteCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "Notes",
                newName: "SubCategory");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Notes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Notes",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FileSize",
                table: "Notes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "NonTechTopics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 30, 10, 6, 54, 621, DateTimeKind.Local).AddTicks(7302));

            migrationBuilder.UpdateData(
                table: "NonTechTopics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 30, 10, 6, 54, 621, DateTimeKind.Local).AddTicks(7304));

            migrationBuilder.UpdateData(
                table: "NonTechTopics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 30, 10, 6, 54, 621, DateTimeKind.Local).AddTicks(7305));

            migrationBuilder.UpdateData(
                table: "NonTechTopics",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 30, 10, 6, 54, 621, DateTimeKind.Local).AddTicks(7305));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 30, 10, 6, 54, 621, DateTimeKind.Local).AddTicks(7221));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 30, 10, 6, 54, 621, DateTimeKind.Local).AddTicks(7230));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 30, 10, 6, 54, 621, DateTimeKind.Local).AddTicks(7231));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 30, 10, 6, 54, 621, DateTimeKind.Local).AddTicks(7231));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 30, 10, 6, 54, 621, DateTimeKind.Local).AddTicks(7232));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "FileSize",
                table: "Notes");

            migrationBuilder.RenameColumn(
                name: "SubCategory",
                table: "Notes",
                newName: "Subject");

            migrationBuilder.UpdateData(
                table: "NonTechTopics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 15, 26, 9, 917, DateTimeKind.Local).AddTicks(159));

            migrationBuilder.UpdateData(
                table: "NonTechTopics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 15, 26, 9, 917, DateTimeKind.Local).AddTicks(161));

            migrationBuilder.UpdateData(
                table: "NonTechTopics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 15, 26, 9, 917, DateTimeKind.Local).AddTicks(162));

            migrationBuilder.UpdateData(
                table: "NonTechTopics",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 15, 26, 9, 917, DateTimeKind.Local).AddTicks(163));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 15, 26, 9, 917, DateTimeKind.Local).AddTicks(53));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 15, 26, 9, 917, DateTimeKind.Local).AddTicks(62));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 15, 26, 9, 917, DateTimeKind.Local).AddTicks(64));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 15, 26, 9, 917, DateTimeKind.Local).AddTicks(64));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 15, 26, 9, 917, DateTimeKind.Local).AddTicks(65));
        }
    }
}
