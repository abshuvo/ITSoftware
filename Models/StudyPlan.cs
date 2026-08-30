using System.ComponentModel.DataAnnotations;

namespace ITSoftware.Models
{
    public class StudyPlan
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation
        public ICollection<StudyTask> Tasks { get; set; } = new List<StudyTask>();
    }
}