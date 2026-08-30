using ITSoftware.Data;
using ITSoftware.Models;
using ITSoftware.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITSoftware.Controllers
{
    public class NoteController : Controller
    {
        private readonly ExamPrepDbContext _context;
        private readonly IWebHostEnvironment _env;

        public NoteController(ExamPrepDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // ══════════════════════════════════════
        //  Index — Category sidebar + file list
        // ══════════════════════════════════════
        public async Task<IActionResult> Index(string? category, string? search)
        {
            var query = _context.Notes.AsQueryable();

            // Search filter
            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(n =>
                    n.Title.Contains(search) ||
                    n.Category.Contains(search) ||
                    (n.SubCategory != null && n.SubCategory.Contains(search)) ||
                    (n.Description != null && n.Description.Contains(search)));

            // Category filter
            if (!string.IsNullOrWhiteSpace(category))
                query = query.Where(n => n.Category == category);

            var notes = await query.OrderBy(n => n.Category)
                                   .ThenByDescending(n => n.UploadedAt)
                                   .ToListAsync();

            // Category list (count সহ)
            var allNotes = await _context.Notes.ToListAsync();
            var categories = allNotes
                .GroupBy(n => n.Category)
                .OrderBy(g => g.Key)
                .Select(g => g.Key)
                .ToList();

            // Group করো category অনুযায়ী (sidebar এর জন্য)
            var grouped = notes
                .GroupBy(n => n.Category)
                .ToDictionary(g => g.Key, g => g.ToList());

            var vm = new NoteIndexViewModel
            {
                AllNotes = notes,
                GroupedByCategory = grouped,
                Categories = categories,
                ActiveCategory = category,
                SearchQuery = search,
                TotalCount = await _context.Notes.CountAsync()
            };

            return View(vm);
        }

        // ══════════════════════════════════════
        //  Upload
        // ══════════════════════════════════════
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(
            string title,
            string category,
            string? subCategory,
            string? description,
            IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                TempData["Error"] = "কোনো file select করা হয়নি।";
                return RedirectToAction(nameof(Index));
            }

            var allowed = new[] { ".pdf", ".doc", ".docx", ".jpg", ".jpeg", ".png" };
            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();

            if (!allowed.Contains(ext))
            {
                TempData["Error"] = "PDF, Word, অথবা Image file upload করা যাবে।";
                return RedirectToAction(nameof(Index));
            }

            if (file.Length > 30 * 1024 * 1024)
            {
                TempData["Error"] = "File size সর্বোচ্চ 30MB হতে পারবে।";
                return RedirectToAction(nameof(Index));
            }

            // Category folder এ রাখবো — search সহজ হবে
            // uploads/notes/DBMS/filename.pdf
            var safeCategory = SanitizeFolderName(category);
            var uploadPath = Path.Combine(
                _env.WebRootPath, "uploads", "notes", safeCategory);
            Directory.CreateDirectory(uploadPath);

            var uniqueName = $"{Guid.NewGuid()}{ext}";
            var fullPath = Path.Combine(uploadPath, uniqueName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
                await file.CopyToAsync(stream);

            // File type determine করো
            var fileType = ext switch
            {
                ".pdf" => "pdf",
                ".doc" or ".docx" => "doc",
                ".jpg" or ".jpeg"
                    or ".png" => "image",
                _ => "other"
            };

            var note = new Note
            {
                Title = title,
                Category = category.Trim(),
                SubCategory = string.IsNullOrWhiteSpace(subCategory)
                                  ? null : subCategory.Trim(),
                Description = description,
                FileName = file.FileName,
                FilePath = $"/uploads/notes/{safeCategory}/{uniqueName}",
                FileType = fileType,
                FileSize = file.Length,
                UploadedAt = DateTime.Now
            };

            _context.Notes.Add(note);
            await _context.SaveChangesAsync();

            TempData["Success"] = $"'{file.FileName}' — {category} category তে upload হয়েছে।";
            return RedirectToAction(nameof(Index), new { category });
        }

        // ══════════════════════════════════════
        //  Delete
        // ══════════════════════════════════════
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, string? returnCategory)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note == null) return NotFound();

            if (!string.IsNullOrEmpty(note.FilePath))
            {
                var fullPath = Path.Combine(
                    _env.WebRootPath,
                    note.FilePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
                if (System.IO.File.Exists(fullPath))
                    System.IO.File.Delete(fullPath);
            }

            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Note delete হয়েছে।";
            return RedirectToAction(nameof(Index), new { category = returnCategory });
        }

        // ══════════════════════════════════════
        //  Category rename — একটা category এর
        //  সব note অন্য category তে move করো
        // ══════════════════════════════════════
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RenameCategory(
            string oldCategory, string newCategory)
        {
            var notes = await _context.Notes
                .Where(n => n.Category == oldCategory)
                .ToListAsync();

            foreach (var note in notes)
                note.Category = newCategory.Trim();

            await _context.SaveChangesAsync();
            TempData["Success"] =
                $"'{oldCategory}' → '{newCategory}' rename হয়েছে ({notes.Count}টি note)।";
            return RedirectToAction(nameof(Index), new { category = newCategory });
        }

        // ══════════════════════════════════════
        //  Helper — folder name safe করো
        // ══════════════════════════════════════
        private static string SanitizeFolderName(string name)
        {
            var invalid = Path.GetInvalidFileNameChars();
            return string.Concat(name.Trim()
                .Select(c => invalid.Contains(c) ? '_' : c))
                .Replace(' ', '_');
        }
    }
}