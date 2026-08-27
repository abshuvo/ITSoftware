using System.ComponentModel.DataAnnotations;

namespace ITSoftware.Models
{
    public class Note
    {
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? Subject { get; set; }

        public string? FilePath { get; set; }
        public string? FileName { get; set; }

        // PDF, Image, Doc type
        [MaxLength(20)]
        public string? FileType { get; set; }

        public DateTime UploadedAt { get; set; } = DateTime.Now;
    }
}
