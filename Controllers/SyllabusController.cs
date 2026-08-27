using ITSoftware.Data;
using ITSoftware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITSoftware.Controllers
{
    public class SyllabusController : Controller
    {
        private readonly ExamPrepDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SyllabusController(ExamPrepDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET — সব syllabus দেখাও
        public async Task<IActionResult> Index()
        {
            var list = await _context.Syllabuses
                .OrderByDescending(s => s.UploadedAt)
                .ToListAsync();
            return View(list);
        }

        // POST — নতুন file upload করো
        // POST — নতুন file upload করো
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(string title, string? description, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                TempData["Error"] = "কোনো file select করা হয়নি।";
                return RedirectToAction(nameof(Index));
            }

            // PDF, DOCX এর সাথে Image (JPG, PNG) allow করা হলো
            var allowedExtensions = new[] { ".pdf", ".docx", ".doc", ".jpg", ".jpeg", ".png" };
            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();

            if (!allowedExtensions.Contains(ext))
            {
                // মেসেজটি আপডেট করা হলো
                TempData["Error"] = "শুধু PDF, Word এবং Image (JPG, PNG) file upload করা যাবে।";
                return RedirectToAction(nameof(Index));
            }

            // Max 20MB
            if (file.Length > 20 * 1024 * 1024)
            {
                TempData["Error"] = "File size সর্বোচ্চ 20MB হতে পারবে।";
                return RedirectToAction(nameof(Index));
            }

            // Unique filename তৈরি করো
            var uniqueName = $"{Guid.NewGuid()}{ext}";
            var uploadPath = Path.Combine(_env.WebRootPath, "uploads", "syllabus");
            Directory.CreateDirectory(uploadPath);
            var fullPath = Path.Combine(uploadPath, uniqueName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var syllabus = new Syllabus
            {
                Title = title,
                Description = description,
                FileName = file.FileName,
                FilePath = $"/uploads/syllabus/{uniqueName}",
                UploadedAt = DateTime.Now
            };

            _context.Syllabuses.Add(syllabus);
            await _context.SaveChangesAsync();

            TempData["Success"] = $"'{file.FileName}' সফলভাবে upload হয়েছে।";
            return RedirectToAction(nameof(Index));
        }

        // POST — Delete করো
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var syllabus = await _context.Syllabuses.FindAsync(id);
            if (syllabus == null)
                return NotFound();

            // Physical file delete করো
            if (!string.IsNullOrEmpty(syllabus.FilePath))
            {
                var fullPath = Path.Combine(_env.WebRootPath,
                    syllabus.FilePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
                if (System.IO.File.Exists(fullPath))
                    System.IO.File.Delete(fullPath);
            }

            _context.Syllabuses.Remove(syllabus);
            await _context.SaveChangesAsync();

            TempData["Success"] = "File সফলভাবে delete হয়েছে।";
            return RedirectToAction(nameof(Index));
        }
    }
}
