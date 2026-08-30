using System.ComponentModel.DataAnnotations;

namespace ITSoftware.Models
{
    public class StudyLog
    {
        public int Id { get; set; }

        // কোন ধরনের activity — "MCQ", "Topic", "Notes", "Syllabus"
        [Required, MaxLength(50)]
        public string ActivityType { get; set; } = string.Empty;

        // কতটা করেছে — MCQ হলে count, Notes হলে minutes
        public int ActivityCount { get; set; } = 1;

        [MaxLength(200)]
        public string? Description { get; set; }

        // Reference ID — কোন MCQ quiz বা Topic এর জন্য
        public int? ReferenceId { get; set; }

        // শুধু date রাখবো — time না, daily comparison এর জন্য
        public DateTime LogDate { get; set; } = DateTime.Today;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
