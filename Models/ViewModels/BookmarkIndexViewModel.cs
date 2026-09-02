namespace ITSoftware.Models.ViewModels
{
    public class BookmarkIndexViewModel
    {
        public List<PreviousYearQuestion> BookmarkedQuestions { get; set; } = new();
        public List<McqQuestion> BookmarkedMcqs { get; set; } = new();
        public string ActiveTab { get; set; } = "questions"; // "questions" or "mcqs"
        public string? CategoryFilter { get; set; }
        public string? SearchQuery { get; set; }
        public List<string> QuestionCategories { get; set; } = new();
        public List<string> McqCategories { get; set; } = new();
    }
}
