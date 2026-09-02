using System.ComponentModel.DataAnnotations;

namespace ITSoftware.Models
{
    public class McqMistake
    {
        public int Id { get; set; }

        public int McqQuestionId { get; set; }

        public McqQuestion? McqQuestion { get; set; }

        [MaxLength(1)]
        public string? SelectedOption { get; set; }

        public int WrongAttemptCount { get; set; } = 1;

        public bool IsResolved { get; set; } = false;

        public DateTime? LastAttemptedAt { get; set; } = DateTime.Now;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
