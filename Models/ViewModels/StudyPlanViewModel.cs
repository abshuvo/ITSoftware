namespace ITSoftware.Models.ViewModels
{
    public class StudyPlanViewModel
    {
        // Plan info
        public StudyPlan? Plan { get; set; }

        // Setup form এর জন্য (plan তৈরির আগে)
        public DateTime StartDate { get; set; } = DateTime.Today;
        public DateTime EndDate { get; set; } = DateTime.Today.AddDays(6);
        public string PlanTitle { get; set; } = string.Empty;

        // প্রতিটি দিনের task list — key: date (date only, no time)
        public Dictionary<DateTime, List<StudyTask>> TasksByDate { get; set; } = new();

        // প্রতিটি দিনের completion %
        public Dictionary<DateTime, int> ProgressByDate { get; set; } = new();

        // Currently selected date
        public DateTime? ActiveDate { get; set; }

        // Selected date এর tasks (panel এ দেখাবে)
        public List<StudyTask> ActiveTasks => ActiveDate.HasValue
            && TasksByDate.ContainsKey(ActiveDate.Value.Date)
            ? TasksByDate[ActiveDate.Value.Date]
            : new List<StudyTask>();

        // Overall stats
        public int TotalTasks => TasksByDate.Values.SelectMany(t => t).Count();
        public int DoneTasks => TasksByDate.Values.SelectMany(t => t).Count(t => t.IsCompleted);
        public int OverallPercent => TotalTasks == 0 ? 0
            : (int)Math.Round(DoneTasks * 100.0 / TotalTasks);

        public int TotalDays => TasksByDate.Count;
        public int FullDays => TasksByDate.Values
            .Count(list => list.Count > 0 && list.All(t => t.IsCompleted));

        // All plans list (index page এর জন্য)
        public List<StudyPlan> AllPlans { get; set; } = new();

        // Active date এর progress
        public int ActiveDatePercent => ActiveDate.HasValue
            && ProgressByDate.ContainsKey(ActiveDate.Value.Date)
            ? ProgressByDate[ActiveDate.Value.Date]
            : 0;
    }
}