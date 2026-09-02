namespace ITSoftware.Models.ViewModels
{
    public class MockExamSetupViewModel
    {
        public int QuestionCount { get; set; } = 25; // 20, 25, 50, 100
        public string? Category { get; set; } = "All";
        public int DurationMinutes { get; set; } = 25; // 15, 25, 45, 60, 90
        public bool HasNegativeMarking { get; set; } = true; // -0.25 per wrong answer
        public List<string> AvailableCategories { get; set; } = new();
        public List<MockExamResult> PastExamResults { get; set; } = new();
        public int TotalBankQuestions { get; set; }
    }

    public class MockExamActiveViewModel
    {
        public string SessionId { get; set; } = Guid.NewGuid().ToString();
        public string ExamTitle { get; set; } = "Bank IT Mock Test";
        public string Category { get; set; } = "All Topics";
        public int TotalQuestions { get; set; }
        public int DurationMinutes { get; set; }
        public int TotalSeconds { get; set; }
        public bool HasNegativeMarking { get; set; }
        public List<ExamQuestionItem> Questions { get; set; } = new();
    }

    public class ExamQuestionItem
    {
        public int Index { get; set; }
        public int QuestionId { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public string OptionA { get; set; } = string.Empty;
        public string OptionB { get; set; } = string.Empty;
        public string OptionC { get; set; } = string.Empty;
        public string OptionD { get; set; } = string.Empty;
        public string? Category { get; set; }
        public string? SelectedOption { get; set; } // "A", "B", "C", "D" or null
        public bool IsMarkedForReview { get; set; } = false;
    }

    public class MockExamSubmitInputModel
    {
        public string Category { get; set; } = "All Topics";
        public int DurationMinutes { get; set; }
        public int TimeTakenSeconds { get; set; }
        public bool HasNegativeMarking { get; set; }
        public List<ExamAnswerSubmission> Answers { get; set; } = new();
    }

    public class ExamAnswerSubmission
    {
        public int QuestionId { get; set; }
        public string? SelectedOption { get; set; }
    }

    public class MockExamDetailedResultViewModel
    {
        public MockExamResult Result { get; set; } = new();
        public List<ExamQuestionReviewItem> Reviews { get; set; } = new();
    }

    public class ExamQuestionReviewItem
    {
        public int Index { get; set; }
        public McqQuestion Question { get; set; } = new();
        public string? SelectedOption { get; set; }
        public bool IsCorrect { get; set; }
        public bool IsUnattempted { get; set; }
    }
}
