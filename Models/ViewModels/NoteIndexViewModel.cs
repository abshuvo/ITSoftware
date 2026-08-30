namespace ITSoftware.Models.ViewModels
{
    public class NoteIndexViewModel
    {
        public List<Note> AllNotes { get; set; } = new();
        public Dictionary<string, List<Note>> GroupedByCategory { get; set; } = new();
        public List<string> Categories { get; set; } = new();
        public string? ActiveCategory { get; set; }
        public string? SearchQuery { get; set; }
        public int TotalCount { get; set; }
    }
}
