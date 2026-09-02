using ITSoftware.Data;
using Microsoft.EntityFrameworkCore;

namespace ITSoftware.Services
{
    public static class DbMigrationHelper
    {
        public static async Task EnsureTablesAndColumnsExistAsync(ExamPrepDbContext context)
        {
            // 1. Ensure Flashcards table exists
            var createFlashcardsSql = @"
                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Flashcards')
                BEGIN
                    CREATE TABLE [Flashcards] (
                        [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
                        [Category] NVARCHAR(100) NOT NULL,
                        [FrontText] NVARCHAR(500) NOT NULL,
                        [BackText] NVARCHAR(2000) NOT NULL,
                        [Hint] NVARCHAR(500) NULL,
                        [Difficulty] NVARCHAR(20) NOT NULL DEFAULT 'Medium',
                        [IsMastered] BIT NOT NULL DEFAULT 0,
                        [ReviewCount] INT NOT NULL DEFAULT 0,
                        [LastReviewedAt] DATETIME2 NULL,
                        [CreatedAt] DATETIME2 NOT NULL DEFAULT GETDATE()
                    );
                END
            ";

            // 2. Ensure MockExamResults table exists
            var createMockExamResultsSql = @"
                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'MockExamResults')
                BEGIN
                    CREATE TABLE [MockExamResults] (
                        [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
                        [ExamTitle] NVARCHAR(150) NOT NULL DEFAULT 'Bank IT Mock Test',
                        [Category] NVARCHAR(100) NULL,
                        [TotalQuestions] INT NOT NULL DEFAULT 0,
                        [CorrectCount] INT NOT NULL DEFAULT 0,
                        [WrongCount] INT NOT NULL DEFAULT 0,
                        [UnattemptedCount] INT NOT NULL DEFAULT 0,
                        [NegativeMarks] FLOAT NOT NULL DEFAULT 0,
                        [TotalScore] FLOAT NOT NULL DEFAULT 0,
                        [Percentage] FLOAT NOT NULL DEFAULT 0,
                        [DurationMinutes] INT NOT NULL DEFAULT 0,
                        [TimeTakenSeconds] INT NOT NULL DEFAULT 0,
                        [IsPassed] BIT NOT NULL DEFAULT 0,
                        [CompletedAt] DATETIME2 NOT NULL DEFAULT GETDATE()
                    );
                END
            ";

            // 3. Ensure McqMistakes table exists
            var createMcqMistakesSql = @"
                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'McqMistakes')
                BEGIN
                    CREATE TABLE [McqMistakes] (
                        [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
                        [McqQuestionId] INT NOT NULL,
                        [SelectedOption] NVARCHAR(1) NULL,
                        [WrongAttemptCount] INT NOT NULL DEFAULT 1,
                        [IsResolved] BIT NOT NULL DEFAULT 0,
                        [LastAttemptedAt] DATETIME2 NULL,
                        [CreatedAt] DATETIME2 NOT NULL DEFAULT GETDATE()
                    );
                END
            ";

            // 4. Ensure new columns exist on McqQuestions table
            var alterMcqQuestionsSql = @"
                IF EXISTS (SELECT * FROM sys.tables WHERE name = 'McqQuestions')
                BEGIN
                    IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('McqQuestions') AND name = 'IsBookmarked')
                    BEGIN
                        ALTER TABLE [McqQuestions] ADD [IsBookmarked] BIT NOT NULL DEFAULT 0;
                    END

                    IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('McqQuestions') AND name = 'IsSolved')
                    BEGIN
                        ALTER TABLE [McqQuestions] ADD [IsSolved] BIT NOT NULL DEFAULT 0;
                    END

                    IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('McqQuestions') AND name = 'WrongCount')
                    BEGIN
                        ALTER TABLE [McqQuestions] ADD [WrongCount] INT NOT NULL DEFAULT 0;
                    END
                END
            ";

            try
            {
                await context.Database.ExecuteSqlRawAsync(createFlashcardsSql);
                await context.Database.ExecuteSqlRawAsync(createMockExamResultsSql);
                await context.Database.ExecuteSqlRawAsync(createMcqMistakesSql);
                await context.Database.ExecuteSqlRawAsync(alterMcqQuestionsSql);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DbMigrationHelper] Error applying schema updates: {ex.Message}");
            }
        }
    }
}

