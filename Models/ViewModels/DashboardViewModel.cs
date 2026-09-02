namespace ITSoftware.Models.ViewModels
{
    public class DashboardViewModel
    {
        // Section counts
        public int SyllabusCount { get; set; }
        public int TopicCount { get; set; }
        public int CompletedTopicCount { get; set; }
        public int McqCount { get; set; }
        public int NoteCount { get; set; }
        public int NonTechCount { get; set; }
        public int PreviousYearQuestionCount { get; set; }
        public int PreviousYearSolvedCount { get; set; }

        // Overall progress (0-100)
        public int OverallProgress { get; set; }

        // Recent items for quick preview
        public List<Topic> RecentTopics { get; set; } = new();
        public List<McqQuestion> RecentMcqs { get; set; } = new();

        // Topic progress by category
        public List<CategoryProgress> CategoryProgressList { get; set; } = new();
    }

    public class CategoryProgress
    {
        public string Category { get; set; } = string.Empty;
        public int Total { get; set; }
        public int Completed { get; set; }
        public int ProgressPercent => Total == 0 ? 0 : (int)((double)Completed / Total * 100);
    }
}
