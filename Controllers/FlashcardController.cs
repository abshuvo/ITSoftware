using ITSoftware.Data;
using ITSoftware.Models;
using ITSoftware.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITSoftware.Controllers
{
    public class FlashcardController : Controller
    {
        private readonly ExamPrepDbContext _context;
        private readonly StudyStreakService _streakService;

        public FlashcardController(ExamPrepDbContext context, StudyStreakService streakService)
        {
            _context = context;
            _streakService = streakService;
        }

        // ══════════════════════════════════════════════
        //  Index: Flashcards Deck & Mastery View
        // ══════════════════════════════════════════════
        public async Task<IActionResult> Index(string? category, string? filter)
        {
            var query = _context.Flashcards.AsQueryable();

            if (!string.IsNullOrEmpty(category) && category != "All")
            {
                query = query.Where(f => f.Category == category);
            }

            if (filter == "learning")
            {
                query = query.Where(f => !f.IsMastered);
            }
            else if (filter == "mastered")
            {
                query = query.Where(f => f.IsMastered);
            }

            var cards = await query.OrderBy(f => f.IsMastered).ThenBy(f => f.Id).ToListAsync();

            var categories = await _context.Flashcards
                .Select(f => f.Category)
                .Distinct()
                .OrderBy(c => c)
                .ToListAsync();

            var totalCount = await _context.Flashcards.CountAsync();
            var masteredCount = await _context.Flashcards.CountAsync(f => f.IsMastered);

            ViewBag.ActiveCategory = category ?? "All";
            ViewBag.ActiveFilter = filter ?? "all";
            ViewBag.Categories = categories;
            ViewBag.TotalCount = totalCount;
            ViewBag.MasteredCount = masteredCount;
            ViewBag.MasteryPercent = totalCount == 0 ? 0 : (int)((double)masteredCount / totalCount * 100);

            return View(cards);
        }

        // ══════════════════════════════════════════════
        //  Toggle Mastered (AJAX)
        // ══════════════════════════════════════════════
        [HttpPost]
        public async Task<IActionResult> ToggleMastered(int id)
        {
            var card = await _context.Flashcards.FindAsync(id);
            if (card == null)
            {
                return Json(new { success = false, message = "Card not found" });
            }

            card.IsMastered = !card.IsMastered;
            card.ReviewCount++;
            card.LastReviewedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            // Record to StudyLog & Streak
            if (card.IsMastered)
            {
                await _streakService.RecordActivityAsync("Notes", 1, $"Mastered Flashcard: {card.FrontText}", card.Id);
            }

            var totalCount = await _context.Flashcards.CountAsync();
            var masteredCount = await _context.Flashcards.CountAsync(f => f.IsMastered);

            return Json(new
            {
                success = true,
                isMastered = card.IsMastered,
                masteredCount = masteredCount,
                totalCount = totalCount,
                percent = totalCount == 0 ? 0 : (int)((double)masteredCount / totalCount * 100)
            });
        }

        // ══════════════════════════════════════════════
        //  Reset Mastery
        // ══════════════════════════════════════════════
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetMastery(string? category)
        {
            var query = _context.Flashcards.AsQueryable();
            if (!string.IsNullOrEmpty(category) && category != "All")
            {
                query = query.Where(f => f.Category == category);
            }

            var cards = await query.ToListAsync();
            foreach (var card in cards)
            {
                card.IsMastered = false;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { category });
        }
    }
}
