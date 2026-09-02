using ITSoftware.Data;
using ITSoftware.Models;
using ITSoftware.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ITSoftware.Controllers
{
    public class HomeController : Controller
    {
        private readonly ExamPrepDbContext _context;

        public HomeController(ExamPrepDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var topics = await _context.Topics.ToListAsync();
            var mcqs = await _context.McqQuestions.ToListAsync();

            // Category-wise progress
            var categoryProgress = topics
                .GroupBy(t => t.Category ?? "General")
                .Select(g => new CategoryProgress
                {
                    Category = g.Key,
                    Total = g.Count(),
                    Completed = g.Count(t => t.IsCompleted)
                })
                .ToList();

            // Overall progress calculation
            int totalTopics = topics.Count;
            int completedTopics = topics.Count(t => t.IsCompleted);
            int overallProgress = totalTopics == 0
                ? 0
                : (int)((double)completedTopics / totalTopics * 100);

            var vm = new DashboardViewModel
            {
                SyllabusCount = await _context.Syllabuses.CountAsync(),
                TopicCount = totalTopics,
                CompletedTopicCount = completedTopics,
                McqCount = mcqs.Count,
                NoteCount = await _context.Notes.CountAsync(),
                NonTechCount = await _context.NonTechTopics.CountAsync(),
                PreviousYearQuestionCount = await _context.PreviousYearQuestions.CountAsync(),
                PreviousYearSolvedCount = await _context.PreviousYearQuestions.CountAsync(q => q.IsSolved),
                OverallProgress = overallProgress,
                RecentTopics = topics.OrderByDescending(t => t.CreatedAt).Take(5).ToList(),
                RecentMcqs = mcqs.OrderByDescending(m => m.CreatedAt).Take(3).ToList(),
                CategoryProgressList = categoryProgress
            };

            return View(vm);
        }
    }
}
