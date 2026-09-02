using ITSoftware.Data;
using ITSoftware.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITSoftware.Controllers
{
    public class BookmarkController : Controller
    {
        private readonly ExamPrepDbContext _context;

        public BookmarkController(ExamPrepDbContext context)
        {
            _context = context;
        }

        // ══════════════════════════════════════════════
        //  Index: Unified Bookmarks Hub
        // ══════════════════════════════════════════════
        public async Task<IActionResult> Index(string? tab, string? category, string? search)
        {
            var activeTab = string.IsNullOrEmpty(tab) ? "questions" : tab.ToLower();

            // Bookmarked Previous Year Questions
            var pyqQuery = _context.PreviousYearQuestions
                .Where(q => q.IsBookmarked)
                .AsQueryable();

            if (!string.IsNullOrEmpty(category) && category != "All")
            {
                pyqQuery = pyqQuery.Where(q => q.Category == category);
            }

            if (!string.IsNullOrEmpty(search))
            {
                pyqQuery = pyqQuery.Where(q => q.QuestionText.Contains(search) || q.ExamOrg.Contains(search) || q.Post.Contains(search));
            }

            var bookmarkedPyqs = await pyqQuery
                .OrderBy(q => q.CategoryOrder)
                .ThenBy(q => q.QuestionNo)
                .ToListAsync();

            // Bookmarked Technical MCQs
            var mcqQuery = _context.McqQuestions
                .Where(q => q.IsBookmarked)
                .AsQueryable();

            if (!string.IsNullOrEmpty(category) && category != "All")
            {
                mcqQuery = mcqQuery.Where(q => q.Category == category);
            }

            if (!string.IsNullOrEmpty(search))
            {
                mcqQuery = mcqQuery.Where(q => q.QuestionText.Contains(search) || (q.Explanation != null && q.Explanation.Contains(search)));
            }

            var bookmarkedMcqs = await mcqQuery
                .OrderBy(q => q.Category)
                .ThenBy(q => q.SubCategory)
                .ToListAsync();

            var questionCategories = await _context.PreviousYearQuestions
                .Where(q => q.IsBookmarked)
                .Select(q => q.Category)
                .Distinct()
                .OrderBy(c => c)
                .ToListAsync();

            var mcqCategories = await _context.McqQuestions
                .Where(q => q.IsBookmarked && !string.IsNullOrEmpty(q.Category))
                .Select(q => q.Category!)
                .Distinct()
                .OrderBy(c => c)
                .ToListAsync();

            var vm = new BookmarkIndexViewModel
            {
                BookmarkedQuestions = bookmarkedPyqs,
                BookmarkedMcqs = bookmarkedMcqs,
                ActiveTab = activeTab,
                CategoryFilter = category,
                SearchQuery = search,
                QuestionCategories = questionCategories,
                McqCategories = mcqCategories
            };

            return View(vm);
        }

        // ══════════════════════════════════════════════
        //  Toggle MCQ Bookmark (AJAX)
        // ══════════════════════════════════════════════
        [HttpPost]
        public async Task<IActionResult> ToggleMcqBookmark(int id)
        {
            var mcq = await _context.McqQuestions.FindAsync(id);
            if (mcq == null)
            {
                return Json(new { success = false, message = "MCQ not found" });
            }

            mcq.IsBookmarked = !mcq.IsBookmarked;
            await _context.SaveChangesAsync();

            var totalBookmarked = await _context.McqQuestions.CountAsync(q => q.IsBookmarked);

            return Json(new
            {
                success = true,
                isBookmarked = mcq.IsBookmarked,
                totalBookmarked = totalBookmarked
            });
        }
    }
}
