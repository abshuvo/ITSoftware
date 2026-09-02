using ITSoftware.Models;

namespace ITSoftware.Services
{
    public static partial class PreviousYearQuestionSeeder
    {
        #region 13. Math & Number Systems
        private static List<PreviousYearQuestion> GetMathQuestions()
        {
            const string cat = "Math & Number Systems";
            const int order = 13;
            return new List<PreviousYearQuestion>
            {
                // Bangladesh Bank Exams
                new() { CategoryOrder = order, Category = cat, Year = 2025, ExamOrg = "Bangladesh Bank (DU)", Post = "Assistant Director (ICT)", QuestionText = "[MCQ] What is the 2's complement of (65)₁₆ number?\n(a) 10011011 (b) 10011010 (c) 00011011 (d) 10011100\nAns: (a) 10011011" },
                new() { CategoryOrder = order, Category = cat, Year = 2025, ExamOrg = "Bangladesh Bank (DU)", Post = "Assistant Director (ICT)", QuestionText = "[MCQ] A pipe can fill a tank in 4 hours, and another pipe can fill it in 6 hours. How much time will they take to fill the tank together?\n(a) 40 hours (b) 4.5 hours (c) 2.4 hours (d) 5 hours\nAns: (c) 2.4 hours" },
                new() { CategoryOrder = order, Category = cat, Year = 2025, ExamOrg = "Bangladesh Bank (DU)", Post = "Assistant Director (ICT)", QuestionText = "[MCQ] A went 5 meters to the north, then 3 meters to the east, and then 2 meters to the south. What is the distance from A's starting point to his final position?\n(a) 4.24 meters (b) 5.24 meters (c) 3.24 meters (d) 4 meters\nAns: (a) 4.24 meters" },
                new() { CategoryOrder = order, Category = cat, Year = 2025, ExamOrg = "Bangladesh Bank (DU)", Post = "Assistant Director (ICT)", QuestionText = "[MCQ] Mr. X uses 30% of his salary for one expense, 20% for another, and 10% for another. His remaining amount is 12,000 Taka. What is his total salary?\n(a) 25,000TK (b) 30,000TK (c) 35,000TK (d) 3,000TK\nAns: (b) 30,000TK" },
                new() { CategoryOrder = order, Category = cat, Year = 2025, ExamOrg = "Bangladesh Bank (DU)", Post = "Assistant Director (ICT)", QuestionText = "[MCQ] The father's age is 36 and the son's age is 16. How many years ago was the father's age three times the son's age?\n(a) 6 years ago (b) 36 years ago (c) 12 years ago (d) 4 years ago\nAns: (a) 6 years ago" },
                new() { CategoryOrder = order, Category = cat, Year = 2025, ExamOrg = "Bangladesh Bank (DU)", Post = "Assistant Director (ICT)", QuestionText = "[MCQ] There are 8 balls, and one of them is heavier than the other 7, which are of the same weight. How many weighings are required to guarantee finding the heavier ball?\n(a) 1 (b) 2 (c) 3 (d) 4\nAns: (b) 2" },
                new() { CategoryOrder = order, Category = cat, Year = 2025, ExamOrg = "Bangladesh Bank (DU)", Post = "Assistant Director (ICT)", QuestionText = "Evaluate the definite integral: ∫ (2x² + 3x) dx with limits from 0 to 2." },
                new() { CategoryOrder = order, Category = cat, Year = 2025, ExamOrg = "Bangladesh Bank (DU)", Post = "Assistant Director (ICT)", QuestionText = "In Bangladesh Bank, there are 6 Assistant Directors (ADs) and 4 Deputy Directors (DDs). Each AD brings a bag, while only half of the DDs bring a bag. If a bag is selected at random from all the bags, what is the probability that the chosen bag belongs to a Deputy Director (DD)?" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Maintenance Engineer", QuestionText = "[MCQ] The greatest negative number which can be stored in a computer that has 8-bits word length and uses 2's complement arithmetic is:\n(a) -256 (b) -127 (c) -255 (d) -128\nAns: (d) -128" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Maintenance Engineer", QuestionText = "[MCQ] Calculate: 3²⁰ + 3²⁰ + 3²⁰ = ?\n(a) 3²⁰ (b) 3²¹ (9²⁰) (c) 9⁶⁰ (d) 3⁶⁰\nAns: (b) 3²¹" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Maintenance Engineer", QuestionText = "A father has divided his property between his two sons A and B. A invests the amount at a compound profit of 8% p.a. B invests the amount at 10% p.a. simple profit. At the end of 2 years, the profit received by B is Taka 1336 more than the interest received by A. Find A's share in the father's property of Taka 25000." },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Maintenance Engineer", QuestionText = "The percentage profit earned by selling an article for Tk. 1920 is equal to the percentage loss incurred by selling the same article for Tk. 1280. At what price should the article be sold to make 25% profit?" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Maintenance Engineer", QuestionText = "AD is the longest side of triangle ABD. What is the length of the longest side of triangle ABC (geometry problem with angles and sides)?" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Maintenance Engineer", QuestionText = "Simplify the expression: [4(√6 + √2) / (√6 - √2)] - [(2 + √3) / (2 - √3)] = ?" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "[MCQ] If the radius is increased by 100%, then by how much will the area of the circle be increased?\n(a) 100% (b) 200% (c) 300% (d) 400%\nAns: (c) 300%" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "If x is an Integer and x + 1/x = 17/4, then what is the value of x - 1/x?" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "A basketball team has won 15 games and lost 9. If these games represent 16 2/3% of the games to be played, then how many more games must the team win to average 75% for the season?" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "Students of a class are made to stand in rows. If 4 students are extra in each row, then there would be 2 rows less. If 4 students are less in each row, then there would be 4 more rows. What is the number of students in the class?" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "In the given figure, PQT is a right triangle. What is the area of square QRST?" },
                new() { CategoryOrder = order, Category = cat, Year = 2019, ExamOrg = "Bangladesh Bank (DU)", Post = "Assistant Programmer", QuestionText = "A 10-bit number is taken randomly. Find the probability that all the bits are 1." },
                new() { CategoryOrder = order, Category = cat, Year = 2019, ExamOrg = "Bangladesh Bank (DU)", Post = "Assistant Programmer", QuestionText = "Convert (12345)₁₀ = (?)₈" },
                new() { CategoryOrder = order, Category = cat, Year = 2016, ExamOrg = "Bangladesh Bank", Post = "Assistant Maintenance Engineer", QuestionText = "You have created a file containing 1 million characters. Suppose you want to save the file in ASCII format. How much memory space in MB is needed to store the file?" },

                // Combined & Other Banks
                new() { CategoryOrder = order, Category = cat, Year = 2024, ExamOrg = "Combined 2 Bank (BIBM)", Post = "Officer IT", QuestionText = "Find sets X and Y if XUY={1,2,3,5,6,8,9,10}, X∩Y={1,5}, Y−X={2,6,9,10}" },
                new() { CategoryOrder = order, Category = cat, Year = 2024, ExamOrg = "Combined 2 Bank (BIBM)", Post = "Officer IT", QuestionText = "If you throw two unbiased dice together, what is the probability that the sum of upward faces is 7? Explain." },
                new() { CategoryOrder = order, Category = cat, Year = 2020, ExamOrg = "BSCS Combined 2 Bank (SB&JB)", Post = "Officer IT", QuestionText = "Number system conversions: (i) Convert (10010.101)₂ = (?)₁₀ (ii) Convert (543)₁₀ = (?)₁₆" }
            };
        }
        #endregion
    }
}

