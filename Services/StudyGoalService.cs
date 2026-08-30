using ITSoftware.Data;
using ITSoftware.Models.ViewModels;
using ITSoftware.Models;
using Microsoft.EntityFrameworkCore;

namespace ITSoftware.Services
{
    public class StudyGoalService
    {
        private readonly ExamPrepDbContext _context;

        public StudyGoalService(ExamPrepDbContext context)
        {
            _context = context;
        }

        // ══════════════════════════════
        //  Active goal আনো
        // ══════════════════════════════
        public async Task<StudyGoal> GetActiveGoalAsync()
        {
            var goal = await _context.StudyGoals
                .Where(g => g.IsActive)
                .OrderByDescending(g => g.CreatedAt)
                .FirstOrDefaultAsync();

            // না থাকলে default বানাও
            if (goal == null)
            {
                goal = new StudyGoal();
                _context.StudyGoals.Add(goal);
                await _context.SaveChangesAsync();
            }

            return goal;
        }

        // ══════════════════════════════
        //  আজকের activity log করো
        // ══════════════════════════════
        public async Task LogActivityAsync(
            string activityType,
            int count,
            string? description = null,
            int? referenceId = null)
        {
            var log = new StudyLog
            {
                ActivityType = activityType,
                ActivityCount = count,
                Description = description,
                ReferenceId = referenceId,
                LogDate = DateTime.Today,
                CreatedAt = DateTime.Now
            };

            _context.StudyLogs.Add(log);
            await _context.SaveChangesAsync();
        }

        // ══════════════════════════════
        //  Dashboard ViewModel বানাও
        // ══════════════════════════════
        public async Task<StudyGoalViewModel> GetDashboardAsync()
        {
            var goal = await GetActiveGoalAsync();
            var today = DateTime.Today;

            // আজকের logs
            var todayLogs = await _context.StudyLogs
                .Where(l => l.LogDate == today)
                .OrderByDescending(l => l.CreatedAt)
                .ToListAsync();

            // আজকের totals
            int mcqDone = todayLogs
                .Where(l => l.ActivityType == "MCQ")
                .Sum(l => l.ActivityCount);
            int topicDone = todayLogs
                .Where(l => l.ActivityType == "Topic")
                .Sum(l => l.ActivityCount);
            int notesDone = todayLogs
                .Where(l => l.ActivityType == "Notes")
                .Sum(l => l.ActivityCount);

            // Last 7 দিনের history
            var last7Days = Enumerable.Range(0, 7)
                .Select(i => today.AddDays(-i))
                .ToList();

            var weekLogs = await _context.StudyLogs
                .Where(l => l.LogDate >= today.AddDays(-6))
                .ToListAsync();

            var weekHistory = last7Days.Select(date =>
            {
                var dayLogs = weekLogs.Where(l => l.LogDate == date).ToList();
                int dMcq = dayLogs.Where(l => l.ActivityType == "MCQ")
                                     .Sum(l => l.ActivityCount);
                int dTopic = dayLogs.Where(l => l.ActivityType == "Topic")
                                     .Sum(l => l.ActivityCount);
                int dNotes = dayLogs.Where(l => l.ActivityType == "Notes")
                                     .Sum(l => l.ActivityCount);

                bool met = dMcq >= goal.DailyMcqTarget &&
                           dTopic >= goal.DailyTopicTarget &&
                           dNotes >= goal.DailyNotesMinutes;

                return new DailyHistory
                {
                    Date = date,
                    McqDone = dMcq,
                    TopicDone = dTopic,
                    NotesDone = dNotes,
                    GoalMet = met
                };
            })
            .OrderBy(h => h.Date)
            .ToList();

            // Streak calculate করো
            int streak = 0;
            foreach (var day in weekHistory.OrderByDescending(h => h.Date))
            {
                if (day.Date == today) continue; // আজকে count করবো না
                if (day.GoalMet) streak++;
                else break;
            }

            return new StudyGoalViewModel
            {
                Goal = goal,
                TodayMcqDone = mcqDone,
                TodayTopicDone = topicDone,
                TodayNotesDone = notesDone,
                WeekHistory = weekHistory,
                TodayLogs = todayLogs,
                CurrentStreak = streak
            };
        }

        // ══════════════════════════════
        //  Goal update করো
        // ══════════════════════════════
        public async Task UpdateGoalAsync(
            int mcqTarget, int topicTarget, int notesMinutes)
        {
            var goal = await GetActiveGoalAsync();
            goal.DailyMcqTarget = Math.Max(0, mcqTarget);
            goal.DailyTopicTarget = Math.Max(0, topicTarget);
            goal.DailyNotesMinutes = Math.Max(0, notesMinutes);
            goal.UpdatedAt = DateTime.Now;
            await _context.SaveChangesAsync();
        }
    }
}
