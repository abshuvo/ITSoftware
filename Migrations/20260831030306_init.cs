using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITSoftware.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "McqQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    OptionA = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    OptionB = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    OptionC = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    OptionD = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CorrectAnswer = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_McqQuestions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NonTechTopics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Progress = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonTechTopics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SubCategory = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudyGoals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DailyMcqTarget = table.Column<int>(type: "int", nullable: false),
                    DailyTopicTarget = table.Column<int>(type: "int", nullable: false),
                    DailyNotesMinutes = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyGoals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudyLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ActivityCount = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ReferenceId = table.Column<int>(type: "int", nullable: true),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudyPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Syllabuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Syllabuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Progress = table.Column<int>(type: "int", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudyTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudyPlanId = table.Column<int>(type: "int", nullable: false),
                    TaskDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyTasks_StudyPlans_StudyPlanId",
                        column: x => x.StudyPlanId,
                        principalTable: "StudyPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "NonTechTopics",
                columns: new[] { "Id", "Category", "Content", "CreatedAt", "Progress", "Title" },
                values: new object[,]
                {
                    { 1, "GK", null, new DateTime(2026, 8, 31, 9, 3, 6, 22, DateTimeKind.Local).AddTicks(1768), 0, "বাংলাদেশের ইতিহাস" },
                    { 2, "English", null, new DateTime(2026, 8, 31, 9, 3, 6, 22, DateTimeKind.Local).AddTicks(1774), 0, "Sentence Correction" },
                    { 3, "Math", null, new DateTime(2026, 8, 31, 9, 3, 6, 22, DateTimeKind.Local).AddTicks(1775), 0, "Aptitude — Percentage" },
                    { 4, "Viva", null, new DateTime(2026, 8, 31, 9, 3, 6, 22, DateTimeKind.Local).AddTicks(1776), 0, "Common HR Questions" }
                });

            migrationBuilder.InsertData(
                table: "StudyGoals",
                columns: new[] { "Id", "CreatedAt", "DailyMcqTarget", "DailyNotesMinutes", "DailyTopicTarget", "IsActive", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 30, 2, true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Category", "CreatedAt", "IsCompleted", "Notes", "Progress", "Title" },
                values: new object[,]
                {
                    { 1, "DSA", new DateTime(2026, 8, 31, 9, 3, 6, 22, DateTimeKind.Local).AddTicks(1667), false, null, 0, "Data Structures & Algorithms" },
                    { 2, "Database", new DateTime(2026, 8, 31, 9, 3, 6, 22, DateTimeKind.Local).AddTicks(1679), false, null, 0, "Database Management" },
                    { 3, "Network", new DateTime(2026, 8, 31, 9, 3, 6, 22, DateTimeKind.Local).AddTicks(1680), false, null, 0, "Networking" },
                    { 4, "OOP", new DateTime(2026, 8, 31, 9, 3, 6, 22, DateTimeKind.Local).AddTicks(1681), false, null, 0, "OOP Concepts" },
                    { 5, "OS", new DateTime(2026, 8, 31, 9, 3, 6, 22, DateTimeKind.Local).AddTicks(1681), false, null, 0, "Operating Systems" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudyTasks_StudyPlanId",
                table: "StudyTasks",
                column: "StudyPlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "McqQuestions");

            migrationBuilder.DropTable(
                name: "NonTechTopics");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "StudyGoals");

            migrationBuilder.DropTable(
                name: "StudyLogs");

            migrationBuilder.DropTable(
                name: "StudyTasks");

            migrationBuilder.DropTable(
                name: "Syllabuses");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "StudyPlans");
        }
    }
}
