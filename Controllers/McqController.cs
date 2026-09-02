using ITSoftware.Data;
using ITSoftware.Models;
using ITSoftware.Models.ViewModels;
using ITSoftware.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ITSoftware.Controllers
{
    public class McqController : Controller
    {
        private readonly ExamPrepDbContext _context;
        private readonly McqImportService _importer;
        private readonly StudyGoalService _goalService;
        private const string SessionKey = "QuizSession";

        public McqController(ExamPrepDbContext context, McqImportService importer, StudyGoalService goalService)
        {
            _context = context;
            _importer = importer;
            _goalService = goalService;
        }

        // ══════════════════════════════
        //  Index — MCQ list + upload
        // ══════════════════════════════
        public async Task<IActionResult> Index(string? category, string? subCategory, string? search, int page = 1, int pageSize = 20)
        {
            if (pageSize < 5) pageSize = 20;
            if (pageSize > 100) pageSize = 100;

            // Auto seed / sync if questions are empty, missing, or using old category names
            var totalSeedCount = McqQuestionSeeder.GetAllMcqQuestions().Count;
            var currentDbCount = await _context.McqQuestions.CountAsync();
            var hasNewFormat = await _context.McqQuestions.AnyAsync(q => q.Category == "Operating System");
            var hasOldFormat = await _context.McqQuestions.AnyAsync(q => q.Category == "Basics" || q.Category == "Process Scheduling" || q.Category == "Process Synchronization");
            if (currentDbCount < totalSeedCount || !hasNewFormat || hasOldFormat)
            {
                await McqQuestionSeeder.InitializeAsync(HttpContext.RequestServices);
            }

            var query = _context.McqQuestions.AsQueryable();

            if (!string.IsNullOrWhiteSpace(category))
                query = query.Where(q => q.Category == category);

            if (!string.IsNullOrWhiteSpace(subCategory))
                query = query.Where(q => q.SubCategory == subCategory);

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(q =>
                    q.QuestionText.Contains(search) ||
                    (q.Explanation != null && q.Explanation.Contains(search)) ||
                    (q.Category != null && q.Category.Contains(search)) ||
                    (q.SubCategory != null && q.SubCategory.Contains(search)) ||
                    (q.Tag != null && q.Tag.Contains(search)));
            }

            var filteredCount = await query.CountAsync();
            var totalPages = pageSize > 0 ? (int)Math.Ceiling((double)filteredCount / pageSize) : 1;
            if (page < 1) page = 1;
            if (page > totalPages && totalPages > 0) page = totalPages;

            var questions = await query
                .OrderBy(q => q.Category)
                .ThenBy(q => q.SubCategory)
                .ThenBy(q => q.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var allMcqs = await _context.McqQuestions.ToListAsync();
            var categoryCounts = allMcqs
                .Where(q => !string.IsNullOrEmpty(q.Category))
                .GroupBy(q => q.Category!)
                .ToDictionary(g => g.Key, g => g.Count());

            var subCategoryQuery = allMcqs.AsEnumerable();
            if (!string.IsNullOrEmpty(category))
            {
                subCategoryQuery = subCategoryQuery.Where(q => q.Category == category);
            }

            var subCategoryCounts = subCategoryQuery
                .Where(q => !string.IsNullOrEmpty(q.SubCategory))
                .GroupBy(q => q.SubCategory!)
                .ToDictionary(g => g.Key, g => g.Count());

            var categories = categoryCounts.Keys.OrderBy(GetCategorySortOrder).ThenBy(c => c).ToList();
            var subCategories = subCategoryCounts.Keys.OrderBy(GetSubCategorySortOrder).ThenBy(c => c).ToList();

            var categoryTree = allMcqs
                .Where(q => !string.IsNullOrEmpty(q.Category))
                .GroupBy(q => q.Category!)
                .OrderBy(g => GetCategorySortOrder(g.Key))
                .ThenBy(g => g.Key)
                .Select(g => new CategoryTreeItem
                {
                    CategoryName = g.Key,
                    TotalCount = g.Count(),
                    SubCategories = g
                        .Where(q => !string.IsNullOrEmpty(q.SubCategory))
                        .GroupBy(q => q.SubCategory!)
                        .OrderBy(sg => GetSubCategorySortOrder(sg.Key))
                        .ThenBy(sg => sg.Key)
                        .Select(sg => new SubCategoryItem
                        {
                            SubCategoryName = sg.Key,
                            Count = sg.Count()
                        })
                        .ToList()
                })
                .ToList();

            var vm = new McqIndexViewModel
            {
                Questions = questions,
                CategoryTree = categoryTree,
                Categories = categories,
                CategoryCounts = categoryCounts,
                SubCategories = subCategories,
                SubCategoryCounts = subCategoryCounts,
                FilterCategory = category,
                FilterSubCategory = subCategory,
                SearchQuery = search,
                TotalCount = allMcqs.Count,
                FilteredCount = filteredCount,
                CurrentPage = page,
                PageSize = pageSize
            };

            vm.ImportedCount = TempData["ImportedCount"] != null
                ? (int)TempData["ImportedCount"]!
                : 0;

            return View(vm);
        }

        // ══════════════════════════════
        //  Reset / Re-seed all MCQs
        // ══════════════════════════════
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetData()
        {
            await McqQuestionSeeder.InitializeAsync(HttpContext.RequestServices, forceReset: true);
            var count = McqQuestionSeeder.GetAllMcqQuestions().Count;
            TempData["Success"] = $"সকল {count}টি নতুন টপিকভিত্তিক টেকনিক্যাল MCQ সফলভাবে লোড করা হয়েছে!";
            return RedirectToAction(nameof(Index));
        }

        // ══════════════════════════════
        //  CSV Import
        // ══════════════════════════════
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Import(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                TempData["Error"] = "কোনো file select করা হয়নি।";
                return RedirectToAction(nameof(Index));
            }

            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (ext != ".csv")
            {
                TempData["Error"] = "শুধু .csv file import করা যাবে।";
                return RedirectToAction(nameof(Index));
            }

            using var stream = file.OpenReadStream();
            var questions = _importer.ParseCsv(stream);

            if (!questions.Any())
            {
                TempData["Error"] = "CSV file এ কোনো valid question পাওয়া যায়নি। Format চেক করো।";
                return RedirectToAction(nameof(Index));
            }

            await _context.McqQuestions.AddRangeAsync(questions);
            await _context.SaveChangesAsync();

            TempData["Success"] = $"{questions.Count}টি MCQ সফলভাবে import হয়েছে।";
            TempData["ImportedCount"] = questions.Count;
            return RedirectToAction(nameof(Index));
        }

        // ══════════════════════════════
        //  Manual Add — single MCQ
        // ══════════════════════════════
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(McqQuestion model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "সব required field পূরণ করো।";
                return RedirectToAction(nameof(Index));
            }

            model.CreatedAt = DateTime.Now;
            _context.McqQuestions.Add(model);
            await _context.SaveChangesAsync();

            TempData["Success"] = "MCQ সফলভাবে যোগ হয়েছে।";
            return RedirectToAction(nameof(Index));
        }

        // ══════════════════════════════
        //  Delete
        // ══════════════════════════════
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var q = await _context.McqQuestions.FindAsync(id);
            if (q != null)
            {
                _context.McqQuestions.Remove(q);
                await _context.SaveChangesAsync();
                TempData["Success"] = "MCQ delete হয়েছে।";
            }
            return RedirectToAction(nameof(Index));
        }

        // ══════════════════════════════
        //  Quiz — Start
        // ══════════════════════════════
        public async Task<IActionResult> StartQuiz(string? category, string? subCategory)
        {
            var query = _context.McqQuestions.AsQueryable();
            if (!string.IsNullOrEmpty(category))
                query = query.Where(q => q.Category == category);
            if (!string.IsNullOrEmpty(subCategory))
                query = query.Where(q => q.SubCategory == subCategory);

            var ids = await query.Select(q => q.Id).ToListAsync();

            if (!ids.Any())
            {
                TempData["Error"] = "Quiz শুরু করতে কমপক্ষে ১টি MCQ লাগবে।";
                return RedirectToAction(nameof(Index));
            }

            // Shuffle করো
            var rng = new Random();
            ids = ids.OrderBy(_ => rng.Next()).ToList();

            var session = new QuizSessionViewModel
            {
                QuestionIds = ids,
                CurrentIndex = 0,
                CorrectCount = 0,
                WrongCount = 0,
                Category = category,
                SubCategory = subCategory,
                IsFinished = false
            };

            SaveSession(session);
            return RedirectToAction(nameof(Quiz));
        }

        // ══════════════════════════════
        //  Quiz — Show current question
        // ══════════════════════════════
        public async Task<IActionResult> Quiz()
        {
            var session = GetSession();
            if (session == null)
                return RedirectToAction(nameof(Index));

            if (session.IsFinished)
                return RedirectToAction(nameof(Result));

            var questionId = session.QuestionIds[session.CurrentIndex];
            var question = await _context.McqQuestions.FindAsync(questionId);
            if (question == null)
                return RedirectToAction(nameof(Index));

            var vm = new QuizQuestionViewModel
            {
                Question = question,
                CurrentNumber = session.CurrentIndex + 1,
                TotalQuestions = session.QuestionIds.Count,
                CorrectSoFar = session.CorrectCount,
                WrongSoFar = session.WrongCount,
                Answered = false
            };

            return View(vm);
        }

        // ══════════════════════════════
        //  Quiz — Submit answer
        // ══════════════════════════════
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitAnswer(int questionId, string selectedAnswer)
        {
            var session = GetSession();
            if (session == null)
                return RedirectToAction(nameof(Index));

            var question = await _context.McqQuestions.FindAsync(questionId);
            if (question == null)
                return RedirectToAction(nameof(Index));

            bool isCorrect = selectedAnswer.ToUpper() == question.CorrectAnswer.ToUpper();

            if (isCorrect) session.CorrectCount++;
            else
            {
                session.WrongCount++;
                session.WrongIds.Add(questionId);
            }

            // Answer দেখানোর জন্য ViewModel
            var vm = new QuizQuestionViewModel
            {
                Question = question,
                CurrentNumber = session.CurrentIndex + 1,
                TotalQuestions = session.QuestionIds.Count,
                CorrectSoFar = session.CorrectCount,
                WrongSoFar = session.WrongCount,
                SelectedAnswer = selectedAnswer.ToUpper(),
                Answered = true,
                IsCorrect = isCorrect
            };

            // Session update করো (index এখনো বাড়াইনি — Next button এ বাড়বে)
            SaveSession(session);
            return View("Quiz", vm);
        }

        // ══════════════════════════════
        //  Quiz — Next question
        // ══════════════════════════════
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NextQuestion()
        {
            var session = GetSession();
            if (session == null)
                return RedirectToAction(nameof(Index));

            session.CurrentIndex++;

            if (session.CurrentIndex >= session.QuestionIds.Count)
            {
                session.IsFinished = true;
                SaveSession(session);
                return RedirectToAction(nameof(Result));
            }

            SaveSession(session);
            return RedirectToAction(nameof(Quiz));
        }

        // ══════════════════════════════
        //  Quiz — Result
        // ══════════════════════════════
        public async Task<IActionResult> Result()
        {
            var session = GetSession();
            if (session == null)
                return RedirectToAction(nameof(Index));

            var wrongQuestions = await _context.McqQuestions
                .Where(q => session.WrongIds.Contains(q.Id))
                .ToListAsync();

            int total = session.QuestionIds.Count;
            int score = total == 0 ? 0
                : (int)((double)session.CorrectCount / total * 100);

            var vm = new QuizResultViewModel
            {
                TotalQuestions = total,
                CorrectCount = session.CorrectCount,
                WrongCount = session.WrongCount,
                ScorePercent = score,
                WrongQuestions = wrongQuestions,
                Category = session.Category
            };

            // Log wrong questions into McqMistakes table
            foreach (var wId in session.WrongIds)
            {
                var existingMistake = await _context.McqMistakes.FirstOrDefaultAsync(m => m.McqQuestionId == wId && !m.IsResolved);
                if (existingMistake != null)
                {
                    existingMistake.WrongAttemptCount++;
                    existingMistake.LastAttemptedAt = DateTime.Now;
                }
                else
                {
                    _context.McqMistakes.Add(new McqMistake
                    {
                        McqQuestionId = wId,
                        WrongAttemptCount = 1,
                        IsResolved = false,
                        LastAttemptedAt = DateTime.Now,
                        CreatedAt = DateTime.Now
                    });
                }
            }
            await _context.SaveChangesAsync();

            await _goalService.LogActivityAsync(activityType: "MCQ", count: session.QuestionIds.Count, description: $"Quiz — {session.CorrectCount}/{session.QuestionIds.Count} সঠিক", referenceId: null);
            // Session clear করো
            HttpContext.Session.Remove(SessionKey);
            return View(vm);
        }

        // ══════════════════════════════
        //  Mistake Bank — View & Practice
        // ══════════════════════════════
        public async Task<IActionResult> MistakeBank(string? category, string? search)
        {
            var query = _context.McqMistakes
                .Include(m => m.McqQuestion)
                .Where(m => !m.IsResolved && m.McqQuestion != null)
                .AsQueryable();

            if (!string.IsNullOrEmpty(category) && category != "All")
            {
                query = query.Where(m => m.McqQuestion!.Category == category);
            }

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(m => m.McqQuestion!.QuestionText.Contains(search) || (m.McqQuestion.Explanation != null && m.McqQuestion.Explanation.Contains(search)));
            }

            var mistakes = await query
                .OrderByDescending(m => m.WrongAttemptCount)
                .ThenByDescending(m => m.LastAttemptedAt)
                .ToListAsync();

            var categories = await _context.McqMistakes
                .Include(m => m.McqQuestion)
                .Where(m => !m.IsResolved && m.McqQuestion != null && !string.IsNullOrEmpty(m.McqQuestion.Category))
                .Select(m => m.McqQuestion!.Category!)
                .Distinct()
                .OrderBy(c => c)
                .ToListAsync();

            ViewBag.ActiveCategory = category ?? "All";
            ViewBag.SearchQuery = search;
            ViewBag.Categories = categories;
            ViewBag.TotalMistakes = mistakes.Count;

            return View(mistakes);
        }

        // ══════════════════════════════
        //  Resolve Mistake (AJAX)
        // ══════════════════════════════
        [HttpPost]
        public async Task<IActionResult> ResolveMistake(int id)
        {
            var mistake = await _context.McqMistakes.FindAsync(id);
            if (mistake == null)
            {
                return Json(new { success = false, message = "Mistake record not found" });
            }

            mistake.IsResolved = true;
            await _context.SaveChangesAsync();

            var remaining = await _context.McqMistakes.CountAsync(m => !m.IsResolved);

            return Json(new
            {
                success = true,
                remaining = remaining
            });
        }

        // ══════════════════════════════
        //  Toggle MCQ Bookmark (AJAX)
        // ══════════════════════════════
        [HttpPost]
        public async Task<IActionResult> ToggleBookmark(int id)
        {
            var q = await _context.McqQuestions.FindAsync(id);
            if (q == null)
            {
                return Json(new { success = false, message = "Question not found" });
            }

            q.IsBookmarked = !q.IsBookmarked;
            await _context.SaveChangesAsync();

            var totalBookmarked = await _context.McqQuestions.CountAsync(x => x.IsBookmarked);

            return Json(new
            {
                success = true,
                isBookmarked = q.IsBookmarked,
                totalBookmarked = totalBookmarked
            });
        }

        // ══════════════════════════════
        //  Clear All Resolved Mistakes
        // ══════════════════════════════
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ClearAllMistakes()
        {
            var activeMistakes = await _context.McqMistakes.Where(m => !m.IsResolved).ToListAsync();
            foreach (var m in activeMistakes)
            {
                m.IsResolved = true;
            }
            await _context.SaveChangesAsync();

            return RedirectToAction("MistakeBank");
        }

        // ══════════════════════════════
        //  Session helpers
        // ══════════════════════════════
        private void SaveSession(QuizSessionViewModel session)
        {
            var json = JsonSerializer.Serialize(session);
            HttpContext.Session.SetString(SessionKey, json);
        }

        private QuizSessionViewModel? GetSession()
        {
            var json = HttpContext.Session.GetString(SessionKey);
            return json == null ? null
                : JsonSerializer.Deserialize<QuizSessionViewModel>(json);
        }

        private static int GetCategorySortOrder(string cat) => cat switch
        {
            "Operating System" => 1,
            "Data Structures & Algorithms" => 2,
            "Networking & Data Communication" => 3,
            "Database & SQL" => 4,
            "Software Engineering & OOP" => 5,
            "Digital Logic & Architecture" => 6,
            "Cybersecurity" => 7,
            "General Knowledge & Analytical" => 8,
            _ => 99
        };

        private static int GetSubCategorySortOrder(string subCat) => subCat switch
        {
            "Basics" => 1,
            "Process Scheduling" => 2,
            "Process Synchronization" => 3,
            "Deadlock" => 4,
            "Multithreading" => 5,
            "Memory Management" => 6,
            "Disk Management" => 7,
            _ => 50
        };
    }
}
