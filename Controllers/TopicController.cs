using ITSoftware.Data;
using ITSoftware.Models;
using ITSoftware.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamPrepPortal.Controllers
{
    public class TopicController : Controller
    {
        private readonly ExamPrepDbContext _context;

        public TopicController(ExamPrepDbContext context)
        {
            _context = context;
        }

        // ══════════════════════════════
        //  Index
        // ══════════════════════════════
        public async Task<IActionResult> Index(string? category, string? status)
        {
            ViewData["Title"] = "Important Topics";
            ViewData["Subtitle"] = "Topic অনুযায়ী প্রস্তুতির অগ্রগতি";

            var query = _context.Topics.AsQueryable();

            if (!string.IsNullOrEmpty(category))
                query = query.Where(t => t.Category == category);

            if (status == "done")
                query = query.Where(t => t.IsCompleted);
            else if (status == "inprogress")
                query = query.Where(t => !t.IsCompleted && t.Progress > 0);
            else if (status == "notstarted")
                query = query.Where(t => t.Progress == 0);

            var topics = await query.OrderBy(t => t.Category)
                                    .ThenBy(t => t.Title)
                                    .ToListAsync();

            var allTopics = await _context.Topics.ToListAsync();
            var categories = allTopics
                .Where(t => t.Category != null)
                .Select(t => t.Category!)
                .Distinct()
                .OrderBy(c => c)
                .ToList();

            var vm = new TopicIndexViewModel
            {
                Topics = topics,
                Categories = categories,
                ActiveCategory = category,
                ActiveStatus = status,
                TotalCount = allTopics.Count,
                DoneCount = allTopics.Count(t => t.IsCompleted),
                InProgressCount = allTopics.Count(t => !t.IsCompleted && t.Progress > 0),
                NotStartedCount = allTopics.Count(t => t.Progress == 0)
            };

            return View(vm);
        }

        // ══════════════════════════════
        //  Add new topic
        // ══════════════════════════════
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(string title, string? category, string? notes)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                TempData["Error"] = "Title দিতে হবে।";
                return RedirectToAction(nameof(Index));
            }

            var topic = new Topic
            {
                Title = title.Trim(),
                Category = category?.Trim(),
                Notes = notes?.Trim(),
                Progress = 0,
                CreatedAt = DateTime.Now
            };

            _context.Topics.Add(topic);
            await _context.SaveChangesAsync();

            TempData["Success"] = $"'{title}' topic যোগ হয়েছে।";
            return RedirectToAction(nameof(Index),
                new { category = topic.Category });
        }

        // ══════════════════════════════
        //  Update progress (AJAX)
        // ══════════════════════════════
        [HttpPost]
        public async Task<IActionResult> UpdateProgress(int id, int progress)
        {
            var topic = await _context.Topics.FindAsync(id);
            if (topic == null)
                return Json(new { success = false });

            topic.Progress = Math.Clamp(progress, 0, 100);
            topic.IsCompleted = topic.Progress == 100;
            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true,
                progress = topic.Progress,
                isCompleted = topic.IsCompleted
            });
        }

        // ══════════════════════════════
        //  Toggle complete (AJAX)
        // ══════════════════════════════
        [HttpPost]
        public async Task<IActionResult> ToggleComplete(int id)
        {
            var topic = await _context.Topics.FindAsync(id);
            if (topic == null)
                return Json(new { success = false });

            topic.IsCompleted = !topic.IsCompleted;
            topic.Progress = topic.IsCompleted ? 100 : topic.Progress;
            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true,
                isCompleted = topic.IsCompleted,
                progress = topic.Progress
            });
        }

        // ══════════════════════════════
        //  Edit notes (AJAX)
        // ══════════════════════════════
        [HttpPost]
        public async Task<IActionResult> UpdateNotes(int id, string? notes)
        {
            var topic = await _context.Topics.FindAsync(id);
            if (topic == null)
                return Json(new { success = false });

            topic.Notes = notes?.Trim();
            await _context.SaveChangesAsync();

            return Json(new { success = true });
        }

        // ══════════════════════════════
        //  Delete
        // ══════════════════════════════
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, string? returnCategory)
        {
            var topic = await _context.Topics.FindAsync(id);
            if (topic != null)
            {
                _context.Topics.Remove(topic);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Topic delete হয়েছে।";
            }
            return RedirectToAction(nameof(Index),
                new { category = returnCategory });
        }
    }
}