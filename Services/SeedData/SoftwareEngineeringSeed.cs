using ITSoftware.Models;

namespace ITSoftware.Services
{
    public static partial class PreviousYearQuestionSeeder
    {
        #region 6. Software Engineering
        private static List<PreviousYearQuestion> GetSoftwareEngineeringQuestions()
        {
            const string cat = "Software Engineering";
            const int order = 6;
            return new List<PreviousYearQuestion>
            {
                // Bangladesh Bank Exams
                new() { CategoryOrder = order, Category = cat, Year = 2025, ExamOrg = "Bangladesh Bank (DU)", Post = "Assistant Director (ICT)", QuestionText = "[MCQ] What is the major drawback of waterfall Model?\n(a) It is difficult to manage (b) It requires too many resources (c) It is inflexible and not suitable for changing requirements (d) It lacks proper documentation\nAns: (c) It is inflexible and not suitable for changing requirements" },
                new() { CategoryOrder = order, Category = cat, Year = 2025, ExamOrg = "Bangladesh Bank (DU)", Post = "Assistant Director (ICT)", QuestionText = "[MCQ] Integration testing is the process of testing the ________ between two software units or modules.\n(a) Performance (b) Functionality (c) Interface (d) Security\nAns: (c) Interface" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Maintenance Engineer", QuestionText = "[MCQ] How many steps in waterfall model?\n(a) 5 (b) 6 (c) 7 (d) 8\nAns: (c) 7" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Maintenance Engineer", QuestionText = "[MCQ] Which of the following is protected by copyright ACT?\n(a) Intellectual property (b) Original work of authorship (c) Software (d) All\nAns: (b) Original work of authorship / (d)" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Maintenance Engineer", QuestionText = "Verification and validation are two process areas at CMMI level 3. For both of these areas:\n(a) Provide a definition.\n(b) Provide a description of how you can fulfill these areas in your software testing activities." },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "[MCQ] The ________ system may manage a high degree of interaction between processes and is very useful for high speed and real-time processing.\n(a) strongly coupled and loosely cohesive (b) loosely coupled and strongly cohesive (c) loosely coupled and loosely cohesive (d) strongly coupled and strongly cohesive\nAns: (a)" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "[MCQ] Design pattern for hierarchical structure is:\n(a) Structure chart (b) DFD (c) ERD (d) UML\nAns: (a) Structure chart" },
                new() { CategoryOrder = order, Category = cat, Year = 2019, ExamOrg = "Bangladesh Bank (BUET)", Post = "Assistant Maintenance Engineer", QuestionText = "Discuss the necessity of using application frameworks in web application development (e.g. Ruby on Rails, Django, Angular, ASP.NET, Meteor, Laravel, CodeIgniter)." },
                new() { CategoryOrder = order, Category = cat, Year = 2011, ExamOrg = "Bangladesh Bank", Post = "Assistant Programmer", QuestionText = "[MCQ] The tool provided with .NET framework to register assemblies for use by COM is:\n(a) Regasm (b) Regsvr32 (c) ILDASM (d) Regedit\nAns: (a) Regasm" },

                // Combined & Other Banks
                new() { CategoryOrder = order, Category = cat, Year = 2026, ExamOrg = "Sonali Bank PLC", Post = "ADA", QuestionText = "Define software testing levels: unit, integration, system, and user acceptance testing. How are these complementary to each other?" },
                new() { CategoryOrder = order, Category = cat, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "What is the difference between functional and non-functional requirements? What is requirement validation?" },
                new() { CategoryOrder = order, Category = cat, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "Critically analyze the limitations of the Waterfall model and explain how Agile methodologies address those limitations." },
                new() { CategoryOrder = order, Category = cat, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "Explain the Software Development Life Cycle (SDLC) and describe its main phases." },
                new() { CategoryOrder = order, Category = cat, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "What is Version Control (e.g., Git)? Explain the specific difference between \"Committing\" code and \"Pushing\" code." },
                new() { CategoryOrder = order, Category = cat, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "Construct a logical argument explaining why a heuristic (like A* search) might be faster than a blind search (like BFS), even if it doesn't guarantee the absolute perfect path in all cases." },
                new() { CategoryOrder = order, Category = cat, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "Compare and contrast the three fundamental paradigms of Machine Learning: Supervised Learning, Unsupervised Learning, and Reinforcement Learning." },
                new() { CategoryOrder = order, Category = cat, Year = 2025, ExamOrg = "Combined Bank (BIBM)", Post = "Officer IT", QuestionText = "Explain Reinforcement Learning (RL), Deep Learning (DL), and Federated Learning (FL). Describe how each differs in learning mechanism, data usage, and real-world applications." },
                new() { CategoryOrder = order, Category = cat, Year = 2025, ExamOrg = "Combined Bank (BIBM)", Post = "Officer IT", QuestionText = "A government agency is developing an AI-based citizen service chatbot. Explain how Generative AI can power it, and how Explainable AI (XAI) ensures transparent, reliable, accountable responses." },
                new() { CategoryOrder = order, Category = cat, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "Senior Officer IT", QuestionText = "What is Software Quality Assurance (SQA)? As an SQA team leader purchasing a software system, what aspects will you look into for quality software?" },
                new() { CategoryOrder = order, Category = cat, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "Senior Officer IT", QuestionText = "Lead a team to develop and deploy software fast. Between Waterfall and Incremental approach, which do you choose? Explain." },
                new() { CategoryOrder = order, Category = cat, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "Senior Officer IT", QuestionText = "What is machine learning? Difference between supervised, unsupervised, and reinforcement learning." },
                new() { CategoryOrder = order, Category = cat, Year = 2024, ExamOrg = "Combined 2 Bank (BIBM)", Post = "Officer IT", QuestionText = "Consider a \"buy a product\" use case (browse, select, checkout, shipping, payment, authorization, confirmation). Draw a use case diagram." },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Combined 5 Bank (BIBM)", Post = "Officer IT", QuestionText = "Software project: UFP=180, value-added factor=0.87, performance factor=4. Find required effort in person-months." },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Combined Bank (BIBM)", Post = "Officer IT", QuestionText = "Which SDLC do you prefer between Agile and Waterfall? Explain with an example." },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Combined 4 Bank (BIBM)", Post = "SO IT", QuestionText = "What is project management? If you are a project manager, what are the approaches to complete a project?" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Combined 4 Bank (BIBM)", Post = "SO IT", QuestionText = "What is platform-independent software? Give an example." },
                new() { CategoryOrder = order, Category = cat, Year = 2022, ExamOrg = "ANE JBL", Post = "Assistant Network Engineer", QuestionText = "Difference between Waterfall model and Spiral model. Which model is preferable in software development and why?" },
                new() { CategoryOrder = order, Category = cat, Year = 2022, ExamOrg = "ANE JBL", Post = "Assistant Network Engineer", QuestionText = "Construct FA on {0,1} which accepts even number of 1's and even number of 0's." },
                new() { CategoryOrder = order, Category = cat, Year = 2022, ExamOrg = "SBL/BDBL", Post = "Senior Officer IT", QuestionText = "Draw DFA of a string with at least two b's." },
                new() { CategoryOrder = order, Category = cat, Year = 2021, ExamOrg = "ASA JBL", Post = "Assistant System Administrator", QuestionText = "Draw a DFA diagram to identify all valid file names. A file name is a non-empty string starting with underscore or alphanumeric only." },
                new() { CategoryOrder = order, Category = cat, Year = 2020, ExamOrg = "BSCS Combined 2 Bank (SB&JB)", Post = "Officer IT", QuestionText = "Testing is an activity performed to verify correct behavior of a program. Describe different types of tests conducted in the implementation stage." },
                new() { CategoryOrder = order, Category = cat, Year = 2020, ExamOrg = "Combined 3 Banks (SBL/BDBL)", Post = "Senior Officer IT", QuestionText = "Write the different approaches of debugging a code." }
            };
        }
        #endregion
    }
}

