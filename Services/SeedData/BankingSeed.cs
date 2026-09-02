using ITSoftware.Models;

namespace ITSoftware.Services
{
    public static partial class PreviousYearQuestionSeeder
    {
        #region 9. Banking & Digital Finance
        private static List<PreviousYearQuestion> GetBankingQuestions()
        {
            const string cat = "Banking & Digital Finance";
            const int order = 9;
            return new List<PreviousYearQuestion>
            {
                // Bangladesh Bank Exams
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "Write a comprehensive note on the growing use of technology in the Financial Service Industry." },
                new() { CategoryOrder = order, Category = cat, Year = 2019, ExamOrg = "Bangladesh Bank (BUET)", Post = "Assistant Maintenance Engineer", QuestionText = "How would you test an Automated Teller Machine (ATM) in a banking system? List test cases covering functional, network, security, and edge failure scenarios." },

                // Combined & Other Banks
                new() { CategoryOrder = order, Category = cat, Year = 2024, ExamOrg = "Combined 5 Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "About a real-life software project you built. What problems/challenges did you face and how did you solve them?" },
                new() { CategoryOrder = order, Category = cat, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "AME/AE IT", QuestionText = "Describe the transformative power of ICT with ten innovative applications for the online banking system." },
                new() { CategoryOrder = order, Category = cat, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "AME/AE IT", QuestionText = "What is policy, guideline, and procedure? Why should the auditor maintain control as policy? Explain different types of audit risks." },
                new() { CategoryOrder = order, Category = cat, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "Senior Officer IT", QuestionText = "What is an IT disaster recovery plan? Describe your approach to disaster recovery and business continuity planning for the data center." },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Combined Bank (BIBM)", Post = "Officer IT", QuestionText = "Scenario-based question: server-related problems — how do you handle them for your company?" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Combined 4 Bank (BIBM)", Post = "SO IT", QuestionText = "What is blockchain? How it works, benefits of blockchain, usage of blockchain." },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Combined 4 Bank (BIBM)", Post = "SO IT", QuestionText = "Difference between Digital Banking System and Traditional Banking System." },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Combined Bank (BIBM)", Post = "Senior Officer AHE/AME", QuestionText = "What is digital banking and how does it differ from traditional banking? How can digital banking promote financial inclusion?" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Combined Bank (BIBM)", Post = "Senior Officer AHE/AME", QuestionText = "Describe the typical web application deployment architecture and explain how components interact during deployment." },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Combined Bank (BIBM)", Post = "Senior Officer AHE/AME", QuestionText = "For a digital banking solution, describe the steps to comply with information system audit and control policies." },
                new() { CategoryOrder = order, Category = cat, Year = 2021, ExamOrg = "ASA JBL", Post = "Assistant System Administrator", QuestionText = "Write down the role of System Administrator." },
                new() { CategoryOrder = order, Category = cat, Year = 2021, ExamOrg = "AHE SBL/JBL/RBL", Post = "Assistant Hardware Engineer", QuestionText = "Write down the different types of e-commerce." },
                new() { CategoryOrder = order, Category = cat, Year = 2020, ExamOrg = "BSCS Combined 2 Bank (SB&JB)", Post = "Officer IT", QuestionText = "Make a list of banking software used in Bangladesh. List the essential features for successful Banking Software and Apps." },
                new() { CategoryOrder = order, Category = cat, Year = 2020, ExamOrg = "ANE JBL", Post = "Assistant Network Engineer", QuestionText = "Write about the Role of Information Technology (IT) in the Banking Sector." }
            };
        }
        #endregion
    }
}

