using ITSoftware.Models;

namespace ITSoftware.Services
{
    public static partial class PreviousYearQuestionSeeder
    {
        #region 14. General Knowledge
        private static List<PreviousYearQuestion> GetGkQuestions()
        {
            const string cat = "General Knowledge";
            const int order = 14;
            return new List<PreviousYearQuestion>
            {
                // Bangladesh Bank Exams
                new() { CategoryOrder = order, Category = cat, Year = 2025, ExamOrg = "Bangladesh Bank (DU)", Post = "Assistant Director (ICT)", QuestionText = "[MCQ] Which connect the two Seas in Suez Canal?\n(a) Arabian Sea and Mediterranean Sea (b) Mediterranean Sea and Red Sea (c) Persian Gulf and Black Sea (d) Black Sea and Arabian Sea\nAns: (b) Mediterranean Sea and Red Sea" },
                new() { CategoryOrder = order, Category = cat, Year = 2025, ExamOrg = "Bangladesh Bank (DU)", Post = "Assistant Director (ICT)", QuestionText = "[MCQ] Who is the first ICC ODI men's world Cup winner captain?\n(a) Clive Lloyd (b) Kapil Dev (c) Alan Border (d) Steve Waugh\nAns: (a) Clive Lloyd" },
                new() { CategoryOrder = order, Category = cat, Year = 2025, ExamOrg = "Bangladesh Bank (DU)", Post = "Assistant Director (ICT)", QuestionText = "[MCQ] Who won Nobel Peace prize in 2024?\n(a) David Baker (b) John Jumper (c) Nihon Hidankyo (d) Gary Ruvkun\nAns: (c) Nihon Hidankyo" },
                new() { CategoryOrder = order, Category = cat, Year = 2025, ExamOrg = "Bangladesh Bank (DU)", Post = "Assistant Director (ICT)", QuestionText = "[MCQ] The highest peak in Bangladesh is:\n(a) Saka Haphong (b) Bijoy Tajingdong (c) Dumlong (d) Keokradong\nAns: (a) Saka Haphong" },
                new() { CategoryOrder = order, Category = cat, Year = 2025, ExamOrg = "Bangladesh Bank (DU)", Post = "Assistant Director (ICT)", QuestionText = "[MCQ] Strasbourg belongs to which country?\n(a) France (b) Germany (c) Canada (d) Russia\nAns: (a) France" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Maintenance Engineer", QuestionText = "[MCQ] Which country is known as the 'Rainbow nation'?\n(a) China (b) South Korea (c) Japan (d) South Africa\nAns: (d) South Africa" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Maintenance Engineer", QuestionText = "[MCQ] Which is the third largest economic country?\n(a) United States (b) Japan (c) China (d) India\nAns: (b) Japan" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Maintenance Engineer", QuestionText = "[MCQ] Who won the Ballon d'Or award in 2022?\n(a) Lionel Messi (b) Kylian Mbappe (c) Karim Benzema (d) Ronaldo\nAns: (c) Karim Benzema" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Maintenance Engineer", QuestionText = "[MCQ] The lead character in the film 'The Bandit Queen' was played by:\n(a) Rupa Ganguly (b) Seema Biswas (c) Pratiba Sinha (d) Shabana Azmi\nAns: (b) Seema Biswas" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "[MCQ] World Environment Day is celebrated on:\n(a) 5th June (b) 6th June (c) 2nd June (d) 1st June\nAns: (a) 5th June" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "[MCQ] When was International Mother Language Day declared by UNESCO?\n(a) November, 1999 (b) February, 2000 (c) February, 1999 (d) November, 2000\nAns: (a) November, 1999" },

                // Combined & Other Banks
                new() { CategoryOrder = order, Category = cat, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "GK: (i) First earthquake observation centre in Bangladesh (ii) Full form of WIPO (iii) Year VAT introduced in Bangladesh (iv) First bank owned by Bengali Entrepreneurs (v) CIRDAP location (vi) Who invented dynamite? (vii) Men's singles ITTF world championship 2025 winner's country (viii) Number of OSI layers (ix) Meaning of \"Terracotta\" (x) Which org offered GSP+?" },
                new() { CategoryOrder = order, Category = cat, Year = 2026, ExamOrg = "BSCS AP (BIBM/CTI)", Post = "Assistant Programmer", QuestionText = "Evaluate the challenges and prospects of managing the Rohingya refugee crisis in Bangladesh. How important is international cooperation, and what reforms should be prioritized?" }
            };
        }
        #endregion
    }
}

