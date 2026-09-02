using ITSoftware.Models;

namespace ITSoftware.Models.ViewModels
{
    public class PreviousYearQuestionIndexViewModel
    {
        public List<PreviousYearQuestion> Questions { get; set; } = new();
        public List<string> Categories { get; set; } = new();
        public List<int> Years { get; set; } = new();
        public List<string> ExamOrgs { get; set; } = new();
        public List<string> Posts { get; set; } = new();

        public string? ActiveCategory { get; set; }
        public int? ActiveYear { get; set; }
        public string? ActiveExamOrg { get; set; }
        public string? ActivePost { get; set; }
        public string? SearchQuery { get; set; }
        public string? ActiveStatus { get; set; } // "all", "solved", "unsolved", "bookmarked"

        public int TotalCount { get; set; }
        public int SolvedCount { get; set; }
        public int BookmarkedCount { get; set; }

        public List<TopicCategorySummary> CategorySummaries { get; set; } = new();
    }

    public class TopicCategorySummary
    {
        public int Order { get; set; }
        public string Category { get; set; } = string.Empty;
        public int TotalQuestions { get; set; }
        public int SolvedQuestions { get; set; }
        public string Priority { get; set; } = "Medium";
        public int StarRating { get; set; } = 3;
        public string Icon { get; set; } = "bi-folder2";
        public string Percentage { get; set; } = "0.0%";
        public int ProgressPercent => TotalQuestions == 0 ? 0 : (int)((double)SolvedQuestions / TotalQuestions * 100);
    }
}

