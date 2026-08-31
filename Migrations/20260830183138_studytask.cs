using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITSoftware.Migrations
{
    public partial class studytask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudyTask_StudyPlans_StudyPlanId",
                table: "StudyTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudyTask",
                table: "StudyTask");

            migrationBuilder.RenameTable(
                name: "StudyTask",
                newName: "StudyTasks");

            migrationBuilder.RenameIndex(
                name: "IX_StudyTask_StudyPlanId",
                table: "StudyTasks",
                newName: "IX_StudyTasks_StudyPlanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudyTasks",
                table: "StudyTasks",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "NonTechTopics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 0, 31, 38, 228, DateTimeKind.Local).AddTicks(9172));

            migrationBuilder.UpdateData(
                table: "NonTechTopics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 0, 31, 38, 228, DateTimeKind.Local).AddTicks(9174));

            migrationBuilder.UpdateData(
                table: "NonTechTopics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 0, 31, 38, 228, DateTimeKind.Local).AddTicks(9175));

            migrationBuilder.UpdateData(
                table: "NonTechTopics",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 0, 31, 38, 228, DateTimeKind.Local).AddTicks(9176));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 0, 31, 38, 228, DateTimeKind.Local).AddTicks(9089));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 0, 31, 38, 228, DateTimeKind.Local).AddTicks(9098));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 0, 31, 38, 228, DateTimeKind.Local).AddTicks(9100));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 0, 31, 38, 228, DateTimeKind.Local).AddTicks(9100));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 0, 31, 38, 228, DateTimeKind.Local).AddTicks(9101));

            migrationBuilder.AddForeignKey(
                name: "FK_StudyTasks_StudyPlans_StudyPlanId",
                table: "StudyTasks",
                column: "StudyPlanId",
                principalTable: "StudyPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudyTasks_StudyPlans_StudyPlanId",
                table: "StudyTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudyTasks",
                table: "StudyTasks");

            migrationBuilder.RenameTable(
                name: "StudyTasks",
                newName: "StudyTask");

            migrationBuilder.RenameIndex(
                name: "IX_StudyTasks_StudyPlanId",
                table: "StudyTask",
                newName: "IX_StudyTask_StudyPlanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudyTask",
                table: "StudyTask",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "NonTechTopics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 0, 19, 26, 828, DateTimeKind.Local).AddTicks(3723));

            migrationBuilder.UpdateData(
                table: "NonTechTopics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 0, 19, 26, 828, DateTimeKind.Local).AddTicks(3726));

            migrationBuilder.UpdateData(
                table: "NonTechTopics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 0, 19, 26, 828, DateTimeKind.Local).AddTicks(3727));

            migrationBuilder.UpdateData(
                table: "NonTechTopics",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 0, 19, 26, 828, DateTimeKind.Local).AddTicks(3728));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 0, 19, 26, 828, DateTimeKind.Local).AddTicks(3625));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 0, 19, 26, 828, DateTimeKind.Local).AddTicks(3635));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 0, 19, 26, 828, DateTimeKind.Local).AddTicks(3635));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 0, 19, 26, 828, DateTimeKind.Local).AddTicks(3636));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 0, 19, 26, 828, DateTimeKind.Local).AddTicks(3637));

            migrationBuilder.AddForeignKey(
                name: "FK_StudyTask_StudyPlans_StudyPlanId",
                table: "StudyTask",
                column: "StudyPlanId",
                principalTable: "StudyPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
