namespace ITSoftware.Models.ViewModels
{
    // MCQ list page এর জন্য
    public class McqIndexViewModel
    {
        public List<McqQuestion> Questions { get; set; } = new();
        public List<string> Categories { get; set; } = new();
        public string? FilterCategory { get; set; }
        public int TotalCount { get; set; }
        public int ImportedCount { get; set; }  // last import এ কতটা এলো
    }

    // Quiz session track করার জন্য
    public class QuizSessionViewModel
    {
        public List<int> QuestionIds { get; set; } = new();  // shuffle করা IDs
        public int CurrentIndex { get; set; } = 0;
        public int CorrectCount { get; set; } = 0;
        public int WrongCount { get; set; } = 0;
        public List<int> WrongIds { get; set; } = new();  // review এর জন্য
        public bool IsFinished { get; set; } = false;
        public string? Category { get; set; }           // filtered category
    }

    // একটা question দেখানোর জন্য
    public class QuizQuestionViewModel
    {
        public McqQuestion Question { get; set; } = null!;
        public int CurrentNumber { get; set; }
        public int TotalQuestions { get; set; }
        public int CorrectSoFar { get; set; }
        public int WrongSoFar { get; set; }
        public string? SelectedAnswer { get; set; }  // user এর answer
        public bool Answered { get; set; }  // answer দিয়েছে?
        public bool IsCorrect { get; set; }
    }

    // Quiz শেষে result দেখানোর জন্য
    public class QuizResultViewModel
    {
        public int TotalQuestions { get; set; }
        public int CorrectCount { get; set; }
        public int WrongCount { get; set; }
        public int ScorePercent { get; set; }
        public List<McqQuestion> WrongQuestions { get; set; } = new();
        public string? Category { get; set; }
    }
}
