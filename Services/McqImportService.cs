using ITSoftware.Models;

namespace ITSoftware.Services
{
    public class McqImportService
    {
        // CSV parse করবো — format:
        // Question,OptionA,OptionB,OptionC,OptionD,CorrectAnswer,Explanation,Category
        public List<McqQuestion> ParseCsv(Stream stream)
        {
            var result = new List<McqQuestion>();

            using var reader = new StreamReader(stream);
            string? line;
            bool isFirstLine = true;

            while ((line = reader.ReadLine()) != null)
            {
                // Header row skip করো
                if (isFirstLine) { isFirstLine = false; continue; }
                if (string.IsNullOrWhiteSpace(line)) continue;

                var cols = SplitCsvLine(line);
                if (cols.Length < 6) continue;

                var q = new McqQuestion
                {
                    QuestionText = cols[0].Trim(),
                    OptionA = cols[1].Trim(),
                    OptionB = cols[2].Trim(),
                    OptionC = cols[3].Trim(),
                    OptionD = cols[4].Trim(),
                    CorrectAnswer = cols[5].Trim().ToUpper(),
                    Explanation = cols.Length > 6 ? cols[6].Trim() : null,
                    Category = cols.Length > 7 ? cols[7].Trim() : null,
                    CreatedAt = DateTime.Now
                };

                // Validate correct answer
                if (new[] { "A", "B", "C", "D" }.Contains(q.CorrectAnswer))
                    result.Add(q);
            }

            return result;
        }

        // Comma এর ভেতরে quote থাকলেও handle করবে
        private string[] SplitCsvLine(string line)
        {
            var result = new List<string>();
            var current = new System.Text.StringBuilder();
            bool inQuote = false;

            foreach (char c in line)
            {
                if (c == '"') { inQuote = !inQuote; }
                else if (c == ',' && !inQuote)
                {
                    result.Add(current.ToString());
                    current.Clear();
                }
                else { current.Append(c); }
            }
            result.Add(current.ToString());
            return result.ToArray();
        }
    }
}
