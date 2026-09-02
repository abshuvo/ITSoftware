using System.ComponentModel.DataAnnotations;

namespace ITSoftware.Models
{
    public class Flashcard
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Category { get; set; } = string.Empty;

        [Required, MaxLength(500)]
        public string FrontText { get; set; } = string.Empty;

        [Required, MaxLength(2000)]
        public string BackText { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Hint { get; set; }

        [MaxLength(20)]
        public string Difficulty { get; set; } = "Medium"; // "Easy", "Medium", "Hard"

        public bool IsMastered { get; set; } = false;

        public int ReviewCount { get; set; } = 0;

        public DateTime? LastReviewedAt { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
