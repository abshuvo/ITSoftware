using ITSoftware.Data;
using ITSoftware.Models;
using ITSoftware.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITSoftware.Controllers
{
    public class StudyPlanController : Controller
    {
        private readonly ExamPrepDbContext _context;

        public StudyPlanController(ExamPrepDbContext context)
        {
            _context = context;
        }

        // ══════════════════════════════════════════════
        //  GET: /StudyPlan
        //  সব plan এর list দেখাও
        // ══════════════════════════════════════════════
        public async Task<IActionResult> Index()
        {
            var plans = await _context.StudyPlans
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();

            var vm = new StudyPlanViewModel { AllPlans = plans };
            return View(vm);
        }

        // ══════════════════════════════════════════════
        //  POST: /StudyPlan/Create
        //  নতুন plan তৈরি করো
        // ══════════════════════════════════════════════
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string planTitle, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(planTitle))
            {
                TempData["Error"] = "Plan এর একটা নাম দাও।";
                return RedirectToAction(nameof(Index));
            }

            if (startDate > endDate)
            {
                TempData["Error"] = "শুরুর তারিখ শেষের তারিখের আগে হতে হবে।";
                return RedirectToAction(nameof(Index));
            }

            if ((endDate - startDate).TotalDays > 90)
            {
                TempData["Error"] = "সর্বোচ্চ ৯০ দিনের plan তৈরি করা যাবে।";
                return RedirectToAction(nameof(Index));
            }

            var plan = new StudyPlan
            {
                Title = planTitle.Trim(),
                StartDate = startDate.Date,
                EndDate = endDate.Date,
                CreatedAt = DateTime.Now
            };

            _context.StudyPlans.Add(plan);
            await _context.SaveChangesAsync();

            TempData["Success"] = $"'{plan.Title}' plan তৈরি হয়েছে।";
            return RedirectToAction(nameof(Detail), new { id = plan.Id });
        }

        // ══════════════════════════════════════════════
        //  GET: /StudyPlan/Detail/5?activeDate=2025-08-01
        //  Plan এর detail + date cards + task panel
        // ══════════════════════════════════════════════
        public async Task<IActionResult> Detail(int id, string? activeDate)
        {
            var plan = await _context.StudyPlans
                .Include(p => p.Tasks.OrderBy(t => t.SortOrder).ThenBy(t => t.CreatedAt))
                .FirstOrDefaultAsync(p => p.Id == id);

            if (plan == null) return NotFound();

            var vm = BuildViewModel(plan, activeDate);
            return View(vm);
        }

        // ══════════════════════════════════════════════
        //  POST: /StudyPlan/AddTask
        //  Task যোগ করো
        // ══════════════════════════════════════════════
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTask(int planId, string taskDate, string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                TempData["Error"] = "Task এর title দাও।";
                return RedirectToAction(nameof(Detail), new { id = planId, activeDate = taskDate });
            }

            if (!DateTime.TryParse(taskDate, out var date))
            {
                TempData["Error"] = "তারিখ ঠিক নেই।";
                return RedirectToAction(nameof(Detail), new { id = planId });
            }

            // সর্বোচ্চ sort order বের করো
            var maxOrder = await _context.StudyTasks
                .Where(t => t.StudyPlanId == planId && t.TaskDate.Date == date.Date)
                .MaxAsync(t => (int?)t.SortOrder) ?? 0;

            var task = new StudyTask
            {
                StudyPlanId = planId,
                TaskDate = date.Date,
                Title = title.Trim(),
                IsCompleted = false,
                SortOrder = maxOrder + 1,
                CreatedAt = DateTime.Now
            };

            _context.StudyTasks.Add(task);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Detail), new { id = planId, activeDate = taskDate });
        }

        // ══════════════════════════════════════════════
        //  POST: /StudyPlan/ToggleTask
        //  Checkbox toggle — AJAX endpoint
        // ══════════════════════════════════════════════
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleTask([FromBody] ToggleTaskRequest req)
        {
            var task = await _context.StudyTasks
                .Include(t => t.StudyPlan)
                .FirstOrDefaultAsync(t => t.Id == req.TaskId);

            if (task == null) return NotFound(new { error = "Task পাওয়া যায়নি।" });

            task.IsCompleted = !task.IsCompleted;
            await _context.SaveChangesAsync();

            // দিনের progress
            var dayTasks = await _context.StudyTasks
                .Where(t => t.StudyPlanId == task.StudyPlanId
                         && t.TaskDate.Date == task.TaskDate.Date)
                .ToListAsync();

            int dayTotal = dayTasks.Count;
            int dayDone = dayTasks.Count(t => t.IsCompleted);
            int dayPct = dayTotal == 0 ? 0 : (int)Math.Round(dayDone * 100.0 / dayTotal);

            // সামগ্রিক progress
            var allTasks = await _context.StudyTasks
                .Where(t => t.StudyPlanId == task.StudyPlanId)
                .ToListAsync();

            int totalAll = allTasks.Count;
            int doneAll = allTasks.Count(t => t.IsCompleted);
            int overallPct = totalAll == 0 ? 0 : (int)Math.Round(doneAll * 100.0 / totalAll);

            return Json(new
            {
                isCompleted = task.IsCompleted,
                dayPercent = dayPct,
                dayDone = dayDone,
                dayTotal = dayTotal,
                overallPercent = overallPct,
                overallDone = doneAll,
                overallTotal = totalAll
            });
        }

        // ══════════════════════════════════════════════
        //  POST: /StudyPlan/EditTask
        //  Task title edit করো
        // ══════════════════════════════════════════════
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTask(int taskId, int planId, string taskDate, string newTitle)
        {
            if (string.IsNullOrWhiteSpace(newTitle))
            {
                TempData["Error"] = "Task এর নাম খালি রাখা যাবে না।";
                return RedirectToAction(nameof(Detail), new { id = planId, activeDate = taskDate });
            }

            var task = await _context.StudyTasks.FindAsync(taskId);
            if (task == null) return NotFound();

            task.Title = newTitle.Trim();
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Detail), new { id = planId, activeDate = taskDate });
        }

        // ══════════════════════════════════════════════
        //  POST: /StudyPlan/DeleteTask
        //  Task delete করো
        // ══════════════════════════════════════════════
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTask(int taskId, int planId, string taskDate)
        {
            var task = await _context.StudyTasks.FindAsync(taskId);
            if (task != null)
            {
                _context.StudyTasks.Remove(task);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Task delete হয়েছে।";
            }

            return RedirectToAction(nameof(Detail), new { id = planId, activeDate = taskDate });
        }

        // ══════════════════════════════════════════════
        //  POST: /StudyPlan/DeletePlan
        //  পুরো plan delete করো
        // ══════════════════════════════════════════════
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePlan(int id)
        {
            var plan = await _context.StudyPlans
                .Include(p => p.Tasks)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (plan == null) return NotFound();

            _context.StudyTasks.RemoveRange(plan.Tasks);
            _context.StudyPlans.Remove(plan);
            await _context.SaveChangesAsync();

            TempData["Success"] = $"'{plan.Title}' plan delete হয়েছে।";
            return RedirectToAction(nameof(Index));
        }

        // ══════════════════════════════════════════════
        //  Private helper — ViewModel build করো
        // ══════════════════════════════════════════════
        private StudyPlanViewModel BuildViewModel(StudyPlan plan, string? activeDateStr)
        {
            var vm = new StudyPlanViewModel
            {
                Plan = plan,
                StartDate = plan.StartDate,
                EndDate = plan.EndDate
            };

            // Date range loop
            for (var d = plan.StartDate.Date; d <= plan.EndDate.Date; d = d.AddDays(1))
            {
                var dayTasks = plan.Tasks
                    .Where(t => t.TaskDate.Date == d)
                    .OrderBy(t => t.SortOrder)
                    .ThenBy(t => t.CreatedAt)
                    .ToList();

                vm.TasksByDate[d] = dayTasks;

                int total = dayTasks.Count;
                int done = dayTasks.Count(t => t.IsCompleted);
                vm.ProgressByDate[d] = total == 0 ? 0 : (int)Math.Round(done * 100.0 / total);
            }

            // Active date set করো
            if (!string.IsNullOrWhiteSpace(activeDateStr)
                && DateTime.TryParse(activeDateStr, out var parsed))
            {
                var activeKey = parsed.Date;
                if (vm.TasksByDate.ContainsKey(activeKey))
                    vm.ActiveDate = activeKey;
            }

            return vm;
        }
    }

    // ══════════════════════════════════════════════
    //  AJAX request DTO
    // ══════════════════════════════════════════════
    public class ToggleTaskRequest
    {
        public int TaskId { get; set; }
    }
}