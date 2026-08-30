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
                value: new DateTime(2026, 8, 28, 21, 1, 2, 451, DateTimeKind.Local).AddTicks(187));

            migrationBuilder.UpdateData(
                table: "NonTechTopics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 28, 21, 1, 2, 451, DateTimeKind.Local).AddTicks(190));

            migrationBuilder.UpdateData(
                table: "NonTechTopics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 28, 21, 1, 2, 451, DateTimeKind.Local).AddTicks(191));

            migrationBuilder.UpdateData(
                table: "NonTechTopics",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 28, 21, 1, 2, 451, DateTimeKind.Local).AddTicks(192));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 28, 21, 1, 2, 451, DateTimeKind.Local).AddTicks(15));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 28, 21, 1, 2, 451, DateTimeKind.Local).AddTicks(28));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 28, 21, 1, 2, 451, DateTimeKind.Local).AddTicks(30));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 28, 21, 1, 2, 451, DateTimeKind.Local).AddTicks(31));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 28, 21, 1, 2, 451, DateTimeKind.Local).AddTicks(32));
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
                value: new DateTime(2026, 8, 28, 10, 35, 36, 169, DateTimeKind.Local).AddTicks(4798));

            migrationBuilder.UpdateData(
                table: "NonTechTopics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 28, 10, 35, 36, 169, DateTimeKind.Local).AddTicks(4800));

            migrationBuilder.UpdateData(
                table: "NonTechTopics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 28, 10, 35, 36, 169, DateTimeKind.Local).AddTicks(4801));

            migrationBuilder.UpdateData(
                table: "NonTechTopics",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 28, 10, 35, 36, 169, DateTimeKind.Local).AddTicks(4801));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 28, 10, 35, 36, 169, DateTimeKind.Local).AddTicks(4714));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 28, 10, 35, 36, 169, DateTimeKind.Local).AddTicks(4725));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 28, 10, 35, 36, 169, DateTimeKind.Local).AddTicks(4726));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 28, 10, 35, 36, 169, DateTimeKind.Local).AddTicks(4726));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 28, 10, 35, 36, 169, DateTimeKind.Local).AddTicks(4727));
        }
    }
}
