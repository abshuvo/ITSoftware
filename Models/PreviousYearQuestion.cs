using System.ComponentModel.DataAnnotations;

namespace ITSoftware.Models
{
    public class PreviousYearQuestion
    {
        public int Id { get; set; }

        public int CategoryOrder { get; set; }

        [Required, MaxLength(150)]
        public string Category { get; set; } = string.Empty;

        public int QuestionNo { get; set; }

        public int Year { get; set; }

        [Required, MaxLength(150)]
        public string ExamOrg { get; set; } = string.Empty;

        [Required, MaxLength(150)]
        public string Post { get; set; } = string.Empty;

        [Required]
        public string QuestionText { get; set; } = string.Empty;

        public bool IsSolved { get; set; } = false;

        public bool IsBookmarked { get; set; } = false;

        public string? UserNotes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
