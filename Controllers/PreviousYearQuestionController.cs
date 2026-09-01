using ITSoftware.Data;
using ITSoftware.Models;
using ITSoftware.Models.ViewModels;
using ITSoftware.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITSoftware.Controllers
{
    public class PreviousYearQuestionController : Controller
    {
        private readonly ExamPrepDbContext _context;

        public PreviousYearQuestionController(ExamPrepDbContext context)
        {
            _context = context;
        }

        // ═════════════════════════════════════════════════════════
        //  Index — Category sidebar + questions + multi-filtering
        // ═════════════════════════════════════════════════════════
        public async Task<IActionResult> Index(
            string? category,
            int? year,
            string? examOrg,
            string? post,
            string? search,
            string? status)
        {
            // Auto seed or sync if questions are missing
            var totalSeedCount = PreviousYearQuestionSeeder.GetAllQuestions().Count;
            var currentDbCount = await _context.PreviousYearQuestions.CountAsync();
            if (currentDbCount < totalSeedCount)
            {
                await PreviousYearQuestionSeeder.SyncQuestionsAsync(_context);
            }

            var allQuestions = await _context.PreviousYearQuestions.ToListAsync();
            var query = _context.PreviousYearQuestions.AsQueryable();

            // Category filter
            if (!string.IsNullOrWhiteSpace(category))
                query = query.Where(q => q.Category == category);

            // Year filter
            if (year.HasValue && year.Value > 0)
                query = query.Where(q => q.Year == year.Value);

            // Exam / Organisation filter
            if (!string.IsNullOrWhiteSpace(examOrg))
                query = query.Where(q => q.ExamOrg == examOrg);

            // Post filter
            if (!string.IsNullOrWhiteSpace(post))
                query = query.Where(q => q.Post == post);

            // Search filter
            if (!string.IsNullOrWhiteSpace(search))
            {
                var s = search.Trim();
                query = query.Where(q =>
                    q.QuestionText.Contains(s) ||
                    q.ExamOrg.Contains(s) ||
                    q.Post.Contains(s) ||
                    q.Category.Contains(s) ||
                    (q.UserNotes != null && q.UserNotes.Contains(s)));
            }

            // Status filter: solved, unsolved, bookmarked
            if (!string.IsNullOrWhiteSpace(status))
            {
                if (status.Equals("solved", StringComparison.OrdinalIgnoreCase))
                    query = query.Where(q => q.IsSolved);
                else if (status.Equals("unsolved", StringComparison.OrdinalIgnoreCase))
                    query = query.Where(q => !q.IsSolved);
                else if (status.Equals("bookmarked", StringComparison.OrdinalIgnoreCase))
                    query = query.Where(q => q.IsBookmarked);
            }

            var filteredQuestions = await query
                .OrderBy(q => q.CategoryOrder)
                .ThenBy(q => q.QuestionNo)
                .ThenByDescending(q => q.Year)
                .ToListAsync();

            // Distinct filter options
            var categories = allQuestions
                .GroupBy(q => new { q.CategoryOrder, q.Category })
                .OrderBy(g => g.Key.CategoryOrder)
                .Select(g => g.Key.Category)
                .ToList();

            var years = allQuestions
                .Select(q => q.Year)
                .Distinct()
                .OrderByDescending(y => y)
                .ToList();

            var examOrgs = allQuestions
                .Select(q => q.ExamOrg)
                .Distinct()
                .OrderBy(e => e)
                .ToList();

            var posts = allQuestions
                .Select(q => q.Post)
                .Distinct()
                .OrderBy(p => p)
                .ToList();

            var categorySummaries = PreviousYearQuestionSeeder.GetCategoryMetadata(allQuestions);

            var vm = new PreviousYearQuestionIndexViewModel
            {
                Questions = filteredQuestions,
                Categories = categories,
                Years = years,
                ExamOrgs = examOrgs,
                Posts = posts,
                ActiveCategory = category,
                ActiveYear = year,
                ActiveExamOrg = examOrg,
                ActivePost = post,
                SearchQuery = search,
                ActiveStatus = string.IsNullOrWhiteSpace(status) ? "all" : status,
                TotalCount = allQuestions.Count,
                SolvedCount = allQuestions.Count(q => q.IsSolved),
                BookmarkedCount = allQuestions.Count(q => q.IsBookmarked),
                CategorySummaries = categorySummaries
            };

            return View(vm);
        }

        // ═════════════════════════════════════════════════════════
        //  Summary / Analytics View
        // ═════════════════════════════════════════════════════════
        public async Task<IActionResult> Summary()
        {
            var allQuestions = await _context.PreviousYearQuestions.ToListAsync();
            var summaries = PreviousYearQuestionSeeder.GetCategoryMetadata(allQuestions);
            return View(summaries);
        }

        // ═════════════════════════════════════════════════════════
        //  AJAX Toggle Solved
        // ═════════════════════════════════════════════════════════
        [HttpPost]
        public async Task<IActionResult> ToggleSolved(int id)
        {
            var q = await _context.PreviousYearQuestions.FindAsync(id);
            if (q == null) return Json(new { success = false, message = "Question not found" });

            q.IsSolved = !q.IsSolved;
            await _context.SaveChangesAsync();

            var totalSolved = await _context.PreviousYearQuestions.CountAsync(x => x.IsSolved);
            return Json(new { success = true, isSolved = q.IsSolved, totalSolved });
        }

        // ═════════════════════════════════════════════════════════
        //  AJAX Toggle Bookmark
        // ═════════════════════════════════════════════════════════
        [HttpPost]
        public async Task<IActionResult> ToggleBookmark(int id)
        {
            var q = await _context.PreviousYearQuestions.FindAsync(id);
            if (q == null) return Json(new { success = false, message = "Question not found" });

            q.IsBookmarked = !q.IsBookmarked;
            await _context.SaveChangesAsync();

            var totalBookmarked = await _context.PreviousYearQuestions.CountAsync(x => x.IsBookmarked);
            return Json(new { success = true, isBookmarked = q.IsBookmarked, totalBookmarked });
        }

        // ═════════════════════════════════════════════════════════
        //  AJAX Save User Notes / Solution
        // ═════════════════════════════════════════════════════════
        [HttpPost]
        public async Task<IActionResult> SaveNote(int id, string? note)
        {
            var q = await _context.PreviousYearQuestions.FindAsync(id);
            if (q == null) return Json(new { success = false, message = "Question not found" });

            q.UserNotes = note;
            await _context.SaveChangesAsync();

            return Json(new { success = true, note = q.UserNotes });
        }

        // ═════════════════════════════════════════════════════════
        //  Add Question (Manual)
        // ═════════════════════════════════════════════════════════
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(PreviousYearQuestion model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "অনুগ্রহ করে সব প্রয়োজনীয় ফিল্ড পূরণ করুন।";
                return RedirectToAction(nameof(Index));
            }

            model.CreatedAt = DateTime.Now;
            _context.PreviousYearQuestions.Add(model);
            await _context.SaveChangesAsync();

            TempData["Success"] = "নতুন প্রশ্ন সফলভাবে যোগ করা হয়েছে।";
            return RedirectToAction(nameof(Index), new { category = model.Category });
        }

        // ═════════════════════════════════════════════════════════
        //  Edit Question
        // ═════════════════════════════════════════════════════════
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PreviousYearQuestion model)
        {
            var q = await _context.PreviousYearQuestions.FindAsync(model.Id);
            if (q == null) return NotFound();

            q.QuestionText = model.QuestionText;
            q.Category = model.Category;
            q.CategoryOrder = model.CategoryOrder;
            q.Year = model.Year;
            q.ExamOrg = model.ExamOrg;
            q.Post = model.Post;
            q.UserNotes = model.UserNotes;

            await _context.SaveChangesAsync();
            TempData["Success"] = "প্রশ্ন সফলভাবে আপডেট করা হয়েছে।";
            return RedirectToAction(nameof(Index), new { category = model.Category });
        }

        // ═════════════════════════════════════════════════════════
        //  Delete Question
        // ═════════════════════════════════════════════════════════
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, string? returnCategory)
        {
            var q = await _context.PreviousYearQuestions.FindAsync(id);
            if (q != null)
            {
                _context.PreviousYearQuestions.Remove(q);
                await _context.SaveChangesAsync();
                TempData["Success"] = "প্রশ্ন মুছে ফেলা হয়েছে।";
            }
            return RedirectToAction(nameof(Index), new { category = returnCategory });
        }

        // ═════════════════════════════════════════════════════════
        //  Re-seed / Reset Data
        // ═════════════════════════════════════════════════════════
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetData()
        {
            _context.PreviousYearQuestions.RemoveRange(_context.PreviousYearQuestions);
            await _context.SaveChangesAsync();

            var seedData = PreviousYearQuestionSeeder.GetAllQuestions();
            await _context.PreviousYearQuestions.AddRangeAsync(seedData);
            await _context.SaveChangesAsync();

            TempData["Success"] = $"মোট {seedData.Count}টি বিগত সালের প্রশ্ন রিসেট ও সিড করা হয়েছে।";
            return RedirectToAction(nameof(Index));
        }

        // ═════════════════════════════════════════════════════════
        //  Export Questions to Excel (.xlsx)
        // ═════════════════════════════════════════════════════════
        [HttpGet]
        public async Task<IActionResult> ExportExcel(
            string? category,
            int? year,
            string? examOrg,
            string? post,
            string? search,
            string? status,
            string? bankType,
            bool all = false)
        {
            var questions = await GetFilteredQuestionsForExport(category, year, examOrg, post, search, status, bankType, all);

            using var workbook = new ClosedXML.Excel.XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Previous Year Questions");

            // 3 Columns: Question | Year | Bank Name
            worksheet.Cell(1, 1).Value = "Question";
            worksheet.Cell(1, 2).Value = "Year";
            worksheet.Cell(1, 3).Value = "Bank Name";

            var headerRow = worksheet.Range("A1:C1");
            headerRow.Style.Font.Bold = true;
            headerRow.Style.Font.FontSize = 11;
            headerRow.Style.Font.FontColor = ClosedXML.Excel.XLColor.White;
            headerRow.Style.Fill.BackgroundColor = ClosedXML.Excel.XLColor.FromHtml("#1E3A8A"); // Navy blue
            headerRow.Style.Alignment.Vertical = ClosedXML.Excel.XLAlignmentVerticalValues.Center;
            worksheet.Cell(1, 1).Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Left;
            worksheet.Cell(1, 2).Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Center;
            worksheet.Cell(1, 3).Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Center;
            worksheet.Row(1).Height = 26;

            int row = 2;
            foreach (var q in questions)
            {
                var bankName = IsBangladeshBank(q.ExamOrg) ? "Bangladesh Bank" : "Combined Bank";

                worksheet.Cell(row, 1).Value = q.QuestionText;
                worksheet.Cell(row, 2).Value = q.Year;
                worksheet.Cell(row, 3).Value = bankName;

                worksheet.Cell(row, 2).Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Center;
                worksheet.Cell(row, 3).Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Center;
                worksheet.Row(row).Style.Alignment.Vertical = ClosedXML.Excel.XLAlignmentVerticalValues.Top;

                if (row % 2 == 1)
                {
                    worksheet.Range(row, 1, row, 3).Style.Fill.BackgroundColor = ClosedXML.Excel.XLColor.FromHtml("#F8FAFC");
                }

                row++;
            }

            worksheet.Column(1).Style.Alignment.WrapText = true;
            worksheet.Column(1).Width = 85;
            worksheet.Column(2).Width = 14;
            worksheet.Column(3).Width = 24;

            if (row > 2)
            {
                var dataRange = worksheet.Range(1, 1, row - 1, 3);
                dataRange.Style.Border.OutsideBorder = ClosedXML.Excel.XLBorderStyleValues.Thin;
                dataRange.Style.Border.InsideBorder = ClosedXML.Excel.XLBorderStyleValues.Thin;
                dataRange.Style.Border.OutsideBorderColor = ClosedXML.Excel.XLColor.FromHtml("#CBD5E1");
                dataRange.Style.Border.InsideBorderColor = ClosedXML.Excel.XLColor.FromHtml("#E2E8F0");
                dataRange.SetAutoFilter();
            }

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            var content = stream.ToArray();

            var prefix = string.IsNullOrWhiteSpace(bankType) ? "Bank_IT" : (bankType.ToLower() == "bb" ? "Bangladesh_Bank" : "Combined_Bank");
            var fileName = $"{prefix}_Previous_Questions_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";
            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }

        // ═════════════════════════════════════════════════════════
        //  Export Questions to CSV
        // ═════════════════════════════════════════════════════════
        [HttpGet]
        public async Task<IActionResult> ExportCsv(
            string? category,
            int? year,
            string? examOrg,
            string? post,
            string? search,
            string? status,
            string? bankType,
            bool all = false)
        {
            var questions = await GetFilteredQuestionsForExport(category, year, examOrg, post, search, status, bankType, all);

            var sb = new System.Text.StringBuilder();
            sb.AppendLine("Question,Year,Bank Name");

            foreach (var q in questions)
            {
                var bankName = IsBangladeshBank(q.ExamOrg) ? "Bangladesh Bank" : "Combined Bank";
                var cleanQ = "\"" + q.QuestionText.Replace("\"", "\"\"") + "\"";
                sb.AppendLine($"{cleanQ},{q.Year},\"{bankName}\"");
            }

            // UTF-8 BOM
            var preamble = System.Text.Encoding.UTF8.GetPreamble();
            var body = System.Text.Encoding.UTF8.GetBytes(sb.ToString());
            var bytes = preamble.Concat(body).ToArray();

            var prefix = string.IsNullOrWhiteSpace(bankType) ? "Bank_IT" : (bankType.ToLower() == "bb" ? "Bangladesh_Bank" : "Combined_Bank");
            return File(bytes, "text/csv; charset=utf-8", $"{prefix}_Previous_Questions_{DateTime.Now:yyyyMMdd_HHmm}.csv");
        }

        private async Task<List<PreviousYearQuestion>> GetFilteredQuestionsForExport(
            string? category,
            int? year,
            string? examOrg,
            string? post,
            string? search,
            string? status,
            string? bankType,
            bool all)
        {
            var query = _context.PreviousYearQuestions.AsQueryable();

            if (!all)
            {
                if (!string.IsNullOrWhiteSpace(category))
                    query = query.Where(q => q.Category == category);

                if (year.HasValue && year.Value > 0)
                    query = query.Where(q => q.Year == year.Value);

                if (!string.IsNullOrWhiteSpace(examOrg))
                    query = query.Where(q => q.ExamOrg == examOrg);

                if (!string.IsNullOrWhiteSpace(post))
                    query = query.Where(q => q.Post == post);

                if (!string.IsNullOrWhiteSpace(search))
                {
                    var s = search.Trim();
                    query = query.Where(q =>
                        q.QuestionText.Contains(s) ||
                        q.ExamOrg.Contains(s) ||
                        q.Post.Contains(s) ||
                        q.Category.Contains(s) ||
                        (q.UserNotes != null && q.UserNotes.Contains(s)));
                }

                if (!string.IsNullOrWhiteSpace(status))
                {
                    if (status.Equals("solved", StringComparison.OrdinalIgnoreCase))
                        query = query.Where(q => q.IsSolved);
                    else if (status.Equals("unsolved", StringComparison.OrdinalIgnoreCase))
                        query = query.Where(q => !q.IsSolved);
                    else if (status.Equals("bookmarked", StringComparison.OrdinalIgnoreCase))
                        query = query.Where(q => q.IsBookmarked);
                }
            }

            var questions = await query
                .OrderByDescending(q => q.Year)
                .ThenBy(q => q.CategoryOrder)
                .ThenBy(q => q.QuestionNo)
                .ToListAsync();

            if (!string.IsNullOrWhiteSpace(bankType))
            {
                if (bankType.Equals("bb", StringComparison.OrdinalIgnoreCase))
                    questions = questions.Where(q => IsBangladeshBank(q.ExamOrg)).ToList();
                else if (bankType.Equals("combined", StringComparison.OrdinalIgnoreCase))
                    questions = questions.Where(q => !IsBangladeshBank(q.ExamOrg)).ToList();
            }

            return questions;
        }

        private static bool IsBangladeshBank(string? examOrg)
        {
            if (string.IsNullOrWhiteSpace(examOrg)) return false;
            return examOrg.IndexOf("Bangladesh Bank", StringComparison.OrdinalIgnoreCase) >= 0 ||
                   examOrg.IndexOf("বাংলাদেশ ব্যাংক", StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}

