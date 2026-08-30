namespace ITSoftware.Models
{
    public class StudyGoal
    {
        public int Id { get; set; }

        // Daily MCQ practice target
        public int DailyMcqTarget { get; set; } = 20;

        // Daily topic revision target
        public int DailyTopicTarget { get; set; } = 2;

        // Daily notes review target (minutes)
        public int DailyNotesMinutes { get; set; } = 30;

        // Goal active আছে কিনা
        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
