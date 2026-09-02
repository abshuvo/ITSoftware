using ITSoftware.Data;
using Microsoft.EntityFrameworkCore;

namespace ITSoftware.Services
{
    public class StreakInfo
    {
        public int CurrentStreak { get; set; }
        public int LongestStreak { get; set; }
        public int TotalActiveDays { get; set; }
        public bool IsActiveToday { get; set; }
        public int TodayActivityCount { get; set; }
        public List<DailyActivityStat> Last7Days { get; set; } = new();
        public List<DailyActivityStat> Last30Days { get; set; } = new();
    }

    public class DailyActivityStat
    {
        public DateTime Date { get; set; }
        public string DayLabel { get; set; } = string.Empty;
        public int McqCount { get; set; }
        public int QuestionsSolved { get; set; }
        public int StudyMinutes { get; set; }
        public int TotalActivities { get; set; }
    }

    public class StudyStreakService
    {
        private readonly ExamPrepDbContext _context;

        public StudyStreakService(ExamPrepDbContext context)
        {
            _context = context;
        }

        public async Task<StreakInfo> GetStreakInfoAsync()
        {
            var logs = await _context.StudyLogs
                .OrderBy(l => l.LogDate)
                .ToListAsync();

            var today = DateTime.Today;
            var distinctDates = logs
                .Select(l => l.LogDate.Date)
                .Distinct()
                .OrderBy(d => d)
                .ToList();

            var info = new StreakInfo
            {
                TotalActiveDays = distinctDates.Count,
                IsActiveToday = distinctDates.Contains(today),
                TodayActivityCount = logs.Where(l => l.LogDate.Date == today).Sum(l => l.ActivityCount)
            };

            // Calculate current streak
            int currentStreak = 0;
            var checkDate = info.IsActiveToday ? today : today.AddDays(-1);

            while (distinctDates.Contains(checkDate))
            {
                currentStreak++;
                checkDate = checkDate.AddDays(-1);
            }
            info.CurrentStreak = currentStreak;

            // Calculate longest streak
            int longestStreak = 0;
            int tempStreak = 0;
            DateTime? prevDate = null;

            foreach (var date in distinctDates)
            {
                if (prevDate == null || date == prevDate.Value.AddDays(1))
                {
                    tempStreak++;
                }
                else
                {
                    tempStreak = 1;
                }

                if (tempStreak > longestStreak)
                {
                    longestStreak = tempStreak;
                }

                prevDate = date;
            }
            info.LongestStreak = Math.Max(longestStreak, currentStreak);

            // Populate Last 7 Days and Last 30 Days stats
            info.Last7Days = GetDailyStats(logs, 7, today);
            info.Last30Days = GetDailyStats(logs, 30, today);

            return info;
        }

        private List<DailyActivityStat> GetDailyStats(List<Models.StudyLog> logs, int days, DateTime today)
        {
            var stats = new List<DailyActivityStat>();
            var startDate = today.AddDays(-days + 1);

            for (int i = 0; i < days; i++)
            {
                var curDate = startDate.AddDays(i);
                var dayLogs = logs.Where(l => l.LogDate.Date == curDate).ToList();

                var mcqCount = dayLogs.Where(l => l.ActivityType == "MCQ" || l.ActivityType == "MockExam").Sum(l => l.ActivityCount);
                var notesMin = dayLogs.Where(l => l.ActivityType == "Notes").Sum(l => l.ActivityCount);
                var totalAct = dayLogs.Sum(l => l.ActivityCount);

                stats.Add(new DailyActivityStat
                {
                    Date = curDate,
                    DayLabel = curDate.ToString("dd MMM"),
                    McqCount = mcqCount,
                    QuestionsSolved = mcqCount,
                    StudyMinutes = notesMin,
                    TotalActivities = totalAct
                });
            }

            return stats;
        }

        public async Task RecordActivityAsync(string activityType, int count, string? description = null, int? referenceId = null)
        {
            var log = new Models.StudyLog
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
    }
}
