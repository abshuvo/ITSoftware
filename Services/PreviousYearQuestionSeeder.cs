using ITSoftware.Data;
using ITSoftware.Models;
using ITSoftware.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ITSoftware.Services
{
    public static partial class PreviousYearQuestionSeeder
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ExamPrepDbContext>();

            try
            {
                await context.Database.EnsureCreatedAsync();
                await SyncQuestionsAsync(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Seeding error: {ex.Message}");
            }
        }

        public static async Task SyncQuestionsAsync(ExamPrepDbContext context)
        {
            var allSeedQuestions = GetAllQuestions();
            var existingQuestions = await context.PreviousYearQuestions.ToListAsync();

            if (existingQuestions.Count == 0)
            {
                await context.PreviousYearQuestions.AddRangeAsync(allSeedQuestions);
                await context.SaveChangesAsync();
                return;
            }

            // Sync missing questions and update category order / question numbers
            var existingDict = existingQuestions
                .GroupBy(q => NormalizeKey(q.Category, q.Year, q.ExamOrg, q.QuestionText))
                .ToDictionary(g => g.Key, g => g.First());

            var toAdd = new List<PreviousYearQuestion>();
            foreach (var sq in allSeedQuestions)
            {
                var key = NormalizeKey(sq.Category, sq.Year, sq.ExamOrg, sq.QuestionText);
                if (!existingDict.ContainsKey(key))
                {
                    toAdd.Add(sq);
                }
            }

            if (toAdd.Count > 0)
            {
                await context.PreviousYearQuestions.AddRangeAsync(toAdd);
                await context.SaveChangesAsync();
            }
        }

        private static string NormalizeKey(string cat, int year, string examOrg, string text)
        {
            var cleanText = text.Length > 80 ? text.Substring(0, 80) : text;
            return $"{cat.Trim().ToLowerInvariant()}|{year}|{examOrg.Trim().ToLowerInvariant()}|{cleanText.Trim().ToLowerInvariant()}";
        }

        public static List<TopicCategorySummary> GetCategoryMetadata(List<PreviousYearQuestion> allQuestions)
        {
            var meta = new List<(int Order, string Category, string Priority, int Stars, string Icon)>
            {
                (1, "Networking & Data Communication", "Critical", 5, "bi-wifi"),
                (2, "Programming & Algorithms", "Critical", 5, "bi-code-slash"),
                (3, "Hardware & Digital Logic", "Critical", 5, "bi-cpu"),
                (4, "Database & SQL", "Critical", 5, "bi-database"),
                (5, "Cybersecurity", "High", 4, "bi-shield-lock"),
                (6, "Software Engineering", "High", 4, "bi-diagram-2"),
                (7, "Data Structures", "Medium", 3, "bi-diagram-3"),
                (8, "Operating Systems", "Medium", 3, "bi-pc-display"),
                (9, "Banking & Digital Finance", "Medium", 3, "bi-bank"),
                (10, "Focus / Essay / Translation", "Low", 2, "bi-pencil-square"),
                (11, "OOP Concepts", "Low", 2, "bi-boxes"),
                (12, "Cloud & Virtualization", "Low", 2, "bi-cloud"),
                (13, "Math & Number Systems", "Low", 2, "bi-calculator"),
                (14, "General Knowledge", "Low", 2, "bi-globe")
            };

            int total = allQuestions.Count > 0 ? allQuestions.Count : 1;
            var list = new List<TopicCategorySummary>();
            foreach (var m in meta)
            {
                var catQuestions = allQuestions.Where(q => q.Category == m.Category).ToList();
                double pct = (catQuestions.Count * 100.0) / total;
                list.Add(new TopicCategorySummary
                {
                    Order = m.Order,
                    Category = m.Category,
                    TotalQuestions = catQuestions.Count,
                    SolvedQuestions = catQuestions.Count(q => q.IsSolved),
                    Priority = m.Priority,
                    StarRating = m.Stars,
                    Icon = m.Icon,
                    Percentage = $"{pct:F1}%"
                });
            }

            return list;
        }

        public static List<PreviousYearQuestion> GetAllQuestions()
        {
            var list = new List<PreviousYearQuestion>();
            list.AddRange(GetNetworkingQuestions());
            list.AddRange(GetProgrammingQuestions());
            list.AddRange(GetHardwareQuestions());
            list.AddRange(GetDatabaseQuestions());
            list.AddRange(GetCybersecurityQuestions());
            list.AddRange(GetSoftwareEngineeringQuestions());
            list.AddRange(GetDataStructuresQuestions());
            list.AddRange(GetOperatingSystemsQuestions());
            list.AddRange(GetBankingQuestions());
            list.AddRange(GetFocusEssayQuestions());
            list.AddRange(GetOopQuestions());
            list.AddRange(GetCloudQuestions());
            list.AddRange(GetMathQuestions());
            list.AddRange(GetGkQuestions());

            // Re-index question numbers sequentially per category
            var grouped = list.GroupBy(q => q.CategoryOrder).OrderBy(g => g.Key);
            var finalList = new List<PreviousYearQuestion>();
            foreach (var g in grouped)
            {
                int qNo = 1;
                foreach (var item in g.OrderByDescending(q => q.Year).ThenBy(q => q.ExamOrg))
                {
                    item.QuestionNo = qNo++;
                    finalList.Add(item);
                }
            }
            return finalList;
        }
    }
}

