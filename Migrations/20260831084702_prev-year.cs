using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITSoftware.Migrations
{
    public partial class prevyear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PreviousYearQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryOrder = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    QuestionNo = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    ExamOrg = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Post = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSolved = table.Column<bool>(type: "bit", nullable: false),
                    IsBookmarked = table.Column<bool>(type: "bit", nullable: false),
                    UserNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreviousYearQuestions", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "NonTechTopics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 14, 47, 2, 687, DateTimeKind.Local).AddTicks(4269));

            migrationBuilder.UpdateData(
                table: "NonTechTopics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 14, 47, 2, 687, DateTimeKind.Local).AddTicks(4272));

            migrationBuilder.UpdateData(
                table: "NonTechTopics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 14, 47, 2, 687, DateTimeKind.Local).AddTicks(4273));

            migrationBuilder.UpdateData(
                table: "NonTechTopics",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 14, 47, 2, 687, DateTimeKind.Local).AddTicks(4273));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 14, 47, 2, 687, DateTimeKind.Local).AddTicks(4187));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 14, 47, 2, 687, DateTimeKind.Local).AddTicks(4197));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 14, 47, 2, 687, DateTimeKind.Local).AddTicks(4198));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 14, 47, 2, 687, DateTimeKind.Local).AddTicks(4198));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 14, 47, 2, 687, DateTimeKind.Local).AddTicks(4199));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PreviousYearQuestions");

            migrationBuilder.UpdateData(
                table: "NonTechTopics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 9, 3, 6, 22, DateTimeKind.Local).AddTicks(1768));

            migrationBuilder.UpdateData(
                table: "NonTechTopics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 9, 3, 6, 22, DateTimeKind.Local).AddTicks(1774));

            migrationBuilder.UpdateData(
                table: "NonTechTopics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 9, 3, 6, 22, DateTimeKind.Local).AddTicks(1775));

            migrationBuilder.UpdateData(
                table: "NonTechTopics",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 9, 3, 6, 22, DateTimeKind.Local).AddTicks(1776));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 9, 3, 6, 22, DateTimeKind.Local).AddTicks(1667));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 9, 3, 6, 22, DateTimeKind.Local).AddTicks(1679));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 9, 3, 6, 22, DateTimeKind.Local).AddTicks(1680));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 9, 3, 6, 22, DateTimeKind.Local).AddTicks(1681));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 9, 3, 6, 22, DateTimeKind.Local).AddTicks(1681));
        }
    }
}
