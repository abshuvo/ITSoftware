using ITSoftware.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITSoftware.Controllers
{
    public class StudyGoalController : Controller
    {
        private readonly StudyGoalService _goalService;

        public StudyGoalController(StudyGoalService goalService)
        {
            _goalService = goalService;
        }

        // ══════════════════════════════
        //  Dashboard
        // ══════════════════════════════
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Daily Study Goal";
            ViewData["Subtitle"] = "আজকের পড়াশোনার লক্ষ্য";

            var vm = await _goalService.GetDashboardAsync();
            return View(vm);
        }

        // ══════════════════════════════
        //  Goal settings update
        // ══════════════════════════════
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateGoal(
            int mcqTarget, int topicTarget, int notesMinutes)
        {
            await _goalService.UpdateGoalAsync(
                mcqTarget, topicTarget, notesMinutes);

            TempData["Success"] = "Goal সফলভাবে আপডেট হয়েছে।";
            return RedirectToAction(nameof(Index));
        }

        // ══════════════════════════════
        //  Manual activity log
        // ══════════════════════════════
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogActivity(
            string activityType, int count, string? description)
        {
            if (count <= 0)
            {
                TempData["Error"] = "Count অবশ্যই ০ এর বেশি হতে হবে।";
                return RedirectToAction(nameof(Index));
            }

            await _goalService.LogActivityAsync(
                activityType, count, description);

            var label = activityType switch
            {
                "MCQ" => $"{count}টি MCQ",
                "Topic" => $"{count}টি Topic",
                "Notes" => $"{count} মিনিট Notes",
                _ => $"{count} টি activity"
            };

            TempData["Success"] = $"{label} log হয়েছে। চালিয়ে যাও! 💪";
            return RedirectToAction(nameof(Index));
        }

        // ══════════════════════════════
        //  AJAX — quick log (sidebar widget থেকে)
        // ══════════════════════════════
        [HttpPost]
        public async Task<IActionResult> QuickLog(
            string activityType, int count)
        {
            if (count <= 0)
                return Json(new { success = false, message = "Invalid count" });

            await _goalService.LogActivityAsync(activityType, count);

            // Updated today's progress return করো
            var vm = await _goalService.GetDashboardAsync();
            return Json(new
            {
                success = true,
                mcqDone = vm.TodayMcqDone,
                topicDone = vm.TodayTopicDone,
                notesDone = vm.TodayNotesDone,
                mcqPercent = vm.McqPercent,
                topicPercent = vm.TopicPercent,
                notesPercent = vm.NotesPercent,
                overallPct = vm.OverallTodayPercent,
                isAllDone = vm.IsAllDone
            });
        }
    }
}
