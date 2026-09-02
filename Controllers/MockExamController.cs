using ITSoftware.Data;
using ITSoftware.Models;
using ITSoftware.Models.ViewModels;
using ITSoftware.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ITSoftware.Controllers
{
    public class MockExamController : Controller
    {
        private readonly ExamPrepDbContext _context;
        private readonly StudyStreakService _streakService;
        private const string ExamSessionKey = "CurrentMockExamSession";

        public MockExamController(ExamPrepDbContext context, StudyStreakService streakService)
        {
            _context = context;
            _streakService = streakService;
        }

        // ══════════════════════════════════════════════
        //  Index: Exam Setup & Past Results History
        // ══════════════════════════════════════════════
        public async Task<IActionResult> Index()
        {
            var categories = await _context.McqQuestions
                .Where(q => !string.IsNullOrEmpty(q.Category))
                .Select(q => q.Category!)
                .Distinct()
                .OrderBy(c => c)
                .ToListAsync();

            var pastResults = await _context.MockExamResults
                .OrderByDescending(r => r.CompletedAt)
                .Take(10)
                .ToListAsync();

            var totalQuestions = await _context.McqQuestions.CountAsync();

            var vm = new MockExamSetupViewModel
            {
                AvailableCategories = categories,
                PastExamResults = pastResults,
                TotalBankQuestions = totalQuestions
            };

            return View(vm);
        }

        // ══════════════════════════════════════════════
        //  Start: Initialize exam & select questions
        // ══════════════════════════════════════════════
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Start(MockExamSetupViewModel setup)
        {
            var query = _context.McqQuestions.AsQueryable();

            if (!string.IsNullOrEmpty(setup.Category) && setup.Category != "All")
            {
                query = query.Where(q => q.Category == setup.Category);
            }

            var allMatching = await query.ToListAsync();

            if (allMatching.Count == 0)
            {
                TempData["ErrorMessage"] = "নির্বাচিত ক্যাটাগরিতে কোনো প্রশ্ন পাওয়া যায়নি!";
                return RedirectToAction("Index");
            }

            // Shuffle randomly and take requested count
            var rng = new Random();
            var selectedQuestions = allMatching
                .OrderBy(_ => rng.Next())
                .Take(Math.Min(setup.QuestionCount, allMatching.Count))
                .ToList();

            var activeExam = new MockExamActiveViewModel
            {
                ExamTitle = setup.Category == "All" ? "Bank IT Comprehensive Mock Test" : $"{setup.Category} Mock Test",
                Category = setup.Category ?? "All Topics",
                TotalQuestions = selectedQuestions.Count,
                DurationMinutes = setup.DurationMinutes,
                TotalSeconds = setup.DurationMinutes * 60,
                HasNegativeMarking = setup.HasNegativeMarking,
                Questions = selectedQuestions.Select((q, index) => new ExamQuestionItem
                {
                    Index = index + 1,
                    QuestionId = q.Id,
                    QuestionText = q.QuestionText,
                    OptionA = q.OptionA,
                    OptionB = q.OptionB,
                    OptionC = q.OptionC,
                    OptionD = q.OptionD,
                    Category = q.Category
                }).ToList()
            };

            // Store in Session
            HttpContext.Session.SetString(ExamSessionKey, JsonSerializer.Serialize(activeExam));

            return RedirectToAction("Take");
        }

        // ══════════════════════════════════════════════
        //  Take: Live Exam Hall with Timer
        // ══════════════════════════════════════════════
        public IActionResult Take()
        {
            var json = HttpContext.Session.GetString(ExamSessionKey);
            if (string.IsNullOrEmpty(json))
            {
                return RedirectToAction("Index");
            }

            var activeExam = JsonSerializer.Deserialize<MockExamActiveViewModel>(json);
            if (activeExam == null)
            {
                return RedirectToAction("Index");
            }

            return View(activeExam);
        }

        // ══════════════════════════════════════════════
        //  Submit: Grade exam, save result & mistakes
        // ══════════════════════════════════════════════
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit(MockExamSubmitInputModel input)
        {
            var questionIds = input.Answers.Select(a => a.QuestionId).ToList();
            var questions = await _context.McqQuestions
                .Where(q => questionIds.Contains(q.Id))
                .ToDictionaryAsync(q => q.Id);

            int correctCount = 0;
            int wrongCount = 0;
            int unattemptedCount = 0;
            var mistakesToRecord = new List<McqMistake>();

            foreach (var ans in input.Answers)
            {
                if (!questions.TryGetValue(ans.QuestionId, out var q))
                    continue;

                if (string.IsNullOrWhiteSpace(ans.SelectedOption))
                {
                    unattemptedCount++;
                }
                else if (string.Equals(ans.SelectedOption.Trim(), q.CorrectAnswer?.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    correctCount++;
                    q.IsSolved = true;
                }
                else
                {
                    wrongCount++;
                    q.WrongCount++;

                    // Add to mistake bank
                    var existingMistake = await _context.McqMistakes
                        .FirstOrDefaultAsync(m => m.McqQuestionId == q.Id && !m.IsResolved);

                    if (existingMistake != null)
                    {
                        existingMistake.WrongAttemptCount++;
                        existingMistake.SelectedOption = ans.SelectedOption;
                        existingMistake.LastAttemptedAt = DateTime.Now;
                    }
                    else
                    {
                        mistakesToRecord.Add(new McqMistake
                        {
                            McqQuestionId = q.Id,
                            SelectedOption = ans.SelectedOption,
                            WrongAttemptCount = 1,
                            IsResolved = false,
                            LastAttemptedAt = DateTime.Now,
                            CreatedAt = DateTime.Now
                        });
                    }
                }
            }

            if (mistakesToRecord.Count > 0)
            {
                _context.McqMistakes.AddRange(mistakesToRecord);
            }

            double negativeMarkPerWrong = input.HasNegativeMarking ? 0.25 : 0.0;
            double negativeMarks = wrongCount * negativeMarkPerWrong;
            double totalScore = Math.Max(0, correctCount - negativeMarks);
            int totalQ = input.Answers.Count;
            double percentage = totalQ == 0 ? 0 : Math.Round((totalScore / totalQ) * 100, 1);
            bool isPassed = percentage >= 50.0; // 50% pass mark

            var examResult = new MockExamResult
            {
                ExamTitle = input.Category == "All Topics" ? "Comprehensive Bank IT Mock Test" : $"{input.Category} Mock Test",
                Category = input.Category,
                TotalQuestions = totalQ,
                CorrectCount = correctCount,
                WrongCount = wrongCount,
                UnattemptedCount = unattemptedCount,
                NegativeMarks = negativeMarks,
                TotalScore = totalScore,
                Percentage = percentage,
                DurationMinutes = input.DurationMinutes,
                TimeTakenSeconds = input.TimeTakenSeconds,
                IsPassed = isPassed,
                CompletedAt = DateTime.Now
            };

            _context.MockExamResults.Add(examResult);
            await _context.SaveChangesAsync();

            // Record to StudyLog & update Streak
            await _streakService.RecordActivityAsync("MockExam", correctCount + wrongCount, $"Mock Test: {examResult.ExamTitle} ({percentage}%)", examResult.Id);

            // Store detailed review data in Session for review view
            var reviewVm = new MockExamDetailedResultViewModel
            {
                Result = examResult,
                Reviews = input.Answers.Select((a, idx) =>
                {
                    questions.TryGetValue(a.QuestionId, out var qObj);
                    bool isUnattempted = string.IsNullOrWhiteSpace(a.SelectedOption);
                    bool isCorrect = !isUnattempted && string.Equals(a.SelectedOption?.Trim(), qObj?.CorrectAnswer?.Trim(), StringComparison.OrdinalIgnoreCase);

                    return new ExamQuestionReviewItem
                    {
                        Index = idx + 1,
                        Question = qObj ?? new McqQuestion(),
                        SelectedOption = a.SelectedOption,
                        IsCorrect = isCorrect,
                        IsUnattempted = isUnattempted
                    };
                }).ToList()
            };

            HttpContext.Session.SetString($"MockExamReview_{examResult.Id}", JsonSerializer.Serialize(reviewVm));
            HttpContext.Session.Remove(ExamSessionKey);

            return RedirectToAction("Result", new { id = examResult.Id });
        }

        // ══════════════════════════════════════════════
        //  Result: Detailed Scorecard & Review
        // ══════════════════════════════════════════════
        public async Task<IActionResult> Result(int id)
        {
            var result = await _context.MockExamResults.FindAsync(id);
            if (result == null)
            {
                return RedirectToAction("Index");
            }

            var reviewJson = HttpContext.Session.GetString($"MockExamReview_{id}");
            if (!string.IsNullOrEmpty(reviewJson))
            {
                var cachedVm = JsonSerializer.Deserialize<MockExamDetailedResultViewModel>(reviewJson);
                if (cachedVm != null)
                {
                    return View(cachedVm);
                }
            }

            // Fallback if session expired
            var vm = new MockExamDetailedResultViewModel
            {
                Result = result
            };

            return View(vm);
        }
    }
}
