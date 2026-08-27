using System.ComponentModel.DataAnnotations;

namespace ITSoftware.Models
{
    public class NonTechTopic
    {
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        // "GK", "Bangla", "English", "Math", "Viva"
        [Required, MaxLength(50)]
        public string Category { get; set; } = string.Empty;

        [MaxLength(2000)]
        public string? Content { get; set; }

        public int Progress { get; set; } = 0;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
