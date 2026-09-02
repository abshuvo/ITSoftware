using System.ComponentModel.DataAnnotations;

namespace ITSoftware.Models
{
    public class MockExamResult
    {
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string ExamTitle { get; set; } = "Bank IT Mock Test";

        [MaxLength(100)]
        public string Category { get; set; } = "All Topics";

        public int TotalQuestions { get; set; }

        public int CorrectCount { get; set; }

        public int WrongCount { get; set; }

        public int UnattemptedCount { get; set; }

        public double NegativeMarks { get; set; } = 0;

        public double TotalScore { get; set; }

        public double Percentage { get; set; }

        public int DurationMinutes { get; set; }

        public int TimeTakenSeconds { get; set; }

        public bool IsPassed { get; set; }

        public DateTime CompletedAt { get; set; } = DateTime.Now;
    }
}
