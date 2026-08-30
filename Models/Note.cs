using System.ComponentModel.DataAnnotations;

namespace ITSoftware.Models
{
    public class Note
    {
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        // Main category — DBMS, OS, Network, DSA etc.
        [Required, MaxLength(100)]
        public string Category { get; set; } = string.Empty;

        // Sub-category — optional, আরো specific করতে
        // যেমন: Category=DBMS, SubCategory=Normalization
        [MaxLength(100)]
        public string? SubCategory { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public string? FilePath { get; set; }
        public string? FileName { get; set; }

        // pdf, image, doc
        [MaxLength(20)]
        public string? FileType { get; set; }

        // File size bytes — display এর জন্য
        public long FileSize { get; set; }

        public DateTime UploadedAt { get; set; } = DateTime.Now;
    }
}
