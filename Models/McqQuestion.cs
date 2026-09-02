using System.ComponentModel.DataAnnotations;

namespace ITSoftware.Models
{
    public class McqQuestion
    {
        public int Id { get; set; }

        [Required, MaxLength(1000)]
        public string QuestionText { get; set; } = string.Empty;

        [Required, MaxLength(500)]
        public string OptionA { get; set; } = string.Empty;

        [Required, MaxLength(500)]
        public string OptionB { get; set; } = string.Empty;

        [Required, MaxLength(500)]
        public string OptionC { get; set; } = string.Empty;

        [Required, MaxLength(500)]
        public string OptionD { get; set; } = string.Empty;

        // "A", "B", "C", or "D"
        [Required, MaxLength(1)]
        public string CorrectAnswer { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string? Explanation { get; set; }

        [MaxLength(100)]
        public string? Category { get; set; }

        [MaxLength(150)]
        public string? SubCategory { get; set; }

        [MaxLength(150)]
        public string? Tag { get; set; }

        public bool IsBookmarked { get; set; } = false;

        public bool IsSolved { get; set; } = false;

        public int WrongCount { get; set; } = 0;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string CorrectOptionText => CorrectAnswer?.Trim().ToUpperInvariant() switch
        {
            "A" => OptionA,
            "B" => OptionB,
            "C" => OptionC,
            "D" => OptionD,
            _ => OptionA
        };
    }
}
