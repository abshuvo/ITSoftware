using ITSoftware.Models;
using Microsoft.EntityFrameworkCore;

namespace ITSoftware.Data
{
    public class ExamPrepDbContext : DbContext
    {
        public ExamPrepDbContext(DbContextOptions<ExamPrepDbContext> options)
            : base(options)
        {
        }

        public DbSet<Syllabus> Syllabuses { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<McqQuestion> McqQuestions { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<NonTechTopic> NonTechTopics { get; set; }

        public DbSet<StudyGoal> StudyGoals { get; set; }
        public DbSet<StudyLog> StudyLogs { get; set; }

        public DbSet<StudyPlan> StudyPlans { get; set; }
        public DbSet<StudyTask> StudyTasks { get; set; }
        public DbSet<PreviousYearQuestion> PreviousYearQuestions { get; set; }
        public DbSet<Flashcard> Flashcards { get; set; }
        public DbSet<MockExamResult> MockExamResults { get; set; }
        public DbSet<McqMistake> McqMistakes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed kichhu sample data
            modelBuilder.Entity<Topic>().HasData(
                new Topic { Id = 1, Title = "Data Structures & Algorithms", Category = "DSA", Progress = 0 },
                new Topic { Id = 2, Title = "Database Management", Category = "Database", Progress = 0 },
                new Topic { Id = 3, Title = "Networking", Category = "Network", Progress = 0 },
                new Topic { Id = 4, Title = "OOP Concepts", Category = "OOP", Progress = 0 },
                new Topic { Id = 5, Title = "Operating Systems", Category = "OS", Progress = 0 }
            );

            modelBuilder.Entity<NonTechTopic>().HasData(
                new NonTechTopic { Id = 1, Title = "বাংলাদেশের ইতিহাস", Category = "GK", Progress = 0 },
                new NonTechTopic { Id = 2, Title = "Sentence Correction", Category = "English", Progress = 0 },
                new NonTechTopic { Id = 3, Title = "Aptitude — Percentage", Category = "Math", Progress = 0 },
                new NonTechTopic { Id = 4, Title = "Common HR Questions", Category = "Viva", Progress = 0 }
            );

            modelBuilder.Entity<StudyGoal>().HasData(
                        new StudyGoal
                        {
                            Id = 1,
                            DailyMcqTarget = 20,
                            DailyTopicTarget = 2,
                            DailyNotesMinutes = 30,
                            IsActive = true,
                            CreatedAt = new DateTime(2024, 1, 1),
                            UpdatedAt = new DateTime(2024, 1, 1)
                        }
);
        }
    }
}
