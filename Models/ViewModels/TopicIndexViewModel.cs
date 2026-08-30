using ITSoftware.Models;

namespace ITSoftware.Models.ViewModels
{
    public class TopicIndexViewModel
    {
        public List<Topic> Topics { get; set; } = new();
        public List<string> Categories { get; set; } = new();
        public string? ActiveCategory { get; set; }
        public string? ActiveStatus { get; set; }
        public int TotalCount { get; set; }
        public int DoneCount { get; set; }
        public int InProgressCount { get; set; }
        public int NotStartedCount { get; set; }

        public int OverallPercent => TotalCount == 0 ? 0
            : (int)((double)DoneCount / TotalCount * 100);
    }
}