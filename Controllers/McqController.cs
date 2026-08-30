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
        public async Task<IActionResult> Index(string? category)
        {
            var query = _context.McqQuestions.AsQueryable();

            if (!string.IsNullOrEmpty(category))
                query = query.Where(q => q.Category == category);

            var vm = new McqIndexViewModel
            {
                Questions = await query.OrderByDescending(q => q.CreatedAt).ToListAsync(),
                Categories = await _context.McqQuestions
                                     .Where(q => q.Category != null)
                                     .Select(q => q.Category!)
                                     .Distinct()
                                     .OrderBy(c => c)
                                     .ToListAsync(),
                FilterCategory = category,
                TotalCount = await _context.McqQuestions.CountAsync()
            };

            vm.ImportedCount = TempData["ImportedCount"] != null
                ? (int)TempData["ImportedCount"]!
                : 0;

            return View(vm);
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
        public async Task<IActionResult> StartQuiz(string? category)
        {
            var query = _context.McqQuestions.AsQueryable();
            if (!string.IsNullOrEmpty(category))
                query = query.Where(q => q.Category == category);

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
            await _goalService.LogActivityAsync( activityType: "MCQ", count: session.QuestionIds.Count, description: $"Quiz — {session.CorrectCount}/{session.QuestionIds.Count} সঠিক", referenceId: null);
            // Session clear করো
            HttpContext.Session.Remove(SessionKey);
            return View(vm);
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
    }
}
