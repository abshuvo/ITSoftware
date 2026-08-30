namespace ITSoftware.Models.ViewModels
{
    public class StudyGoalViewModel
    {
        // Goal targets
        public StudyGoal Goal { get; set; } = new();

        // আজকের progress
        public int TodayMcqDone { get; set; }
        public int TodayTopicDone { get; set; }
        public int TodayNotesDone { get; set; }

        // Percentage (0-100)
        public int McqPercent => Goal.DailyMcqTarget == 0 ? 0
            : Math.Min(100, (int)((double)TodayMcqDone / Goal.DailyMcqTarget * 100));
        public int TopicPercent => Goal.DailyTopicTarget == 0 ? 0
            : Math.Min(100, (int)((double)TodayTopicDone / Goal.DailyTopicTarget * 100));
        public int NotesPercent => Goal.DailyNotesMinutes == 0 ? 0
            : Math.Min(100, (int)((double)TodayNotesDone / Goal.DailyNotesMinutes * 100));

        // সামগ্রিক আজকের progress
        public int OverallTodayPercent =>
            (McqPercent + TopicPercent + NotesPercent) / 3;

        // Goal complete হয়েছে কিনা
        public bool IsMcqDone => TodayMcqDone >= Goal.DailyMcqTarget;
        public bool IsTopicDone => TodayTopicDone >= Goal.DailyTopicTarget;
        public bool IsNotesDone => TodayNotesDone >= Goal.DailyNotesMinutes;
        public bool IsAllDone => IsMcqDone && IsTopicDone && IsNotesDone;

        // Last 7 দিনের history
        public List<DailyHistory> WeekHistory { get; set; } = new();

        // আজকের logs (detail)
        public List<StudyLog> TodayLogs { get; set; } = new();

        // Streak
        public int CurrentStreak { get; set; }
    }

    public class DailyHistory
    {
        public DateTime Date { get; set; }
        public int McqDone { get; set; }
        public int TopicDone { get; set; }
        public int NotesDone { get; set; }
        public bool GoalMet { get; set; }

        // Chart এ দেখানোর জন্য
        public string DateLabel => Date.ToString("ddd dd");
    }
}
