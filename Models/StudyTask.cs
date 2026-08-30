using System.ComponentModel.DataAnnotations;

namespace ITSoftware.Models
{
    public class StudyTask
    {
        public int Id { get; set; }

        public int StudyPlanId { get; set; }

        [Required]
        public DateTime TaskDate { get; set; }

        [Required]
        [MaxLength(500)]
        public string Title { get; set; } = string.Empty;

        public bool IsCompleted { get; set; } = false;

        public int SortOrder { get; set; } = 0;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation
        public StudyPlan StudyPlan { get; set; } = null!;
    }
}