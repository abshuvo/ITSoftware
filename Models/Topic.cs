using System.ComponentModel.DataAnnotations;

namespace ITSoftware.Models
{
    public class Topic
    {
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? Category { get; set; }  // e.g. "DSA", "Database", "Networking"

        public int Progress { get; set; } = 0;  // 0-100 percent

        public bool IsCompleted { get; set; } = false;

        [MaxLength(1000)]
        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
