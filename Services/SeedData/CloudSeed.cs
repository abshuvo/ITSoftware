using ITSoftware.Models;

namespace ITSoftware.Services
{
    public static partial class PreviousYearQuestionSeeder
    {
        #region 12. Cloud & Virtualization
        private static List<PreviousYearQuestion> GetCloudQuestions()
        {
            const string cat = "Cloud & Virtualization";
            const int order = 12;
            return new List<PreviousYearQuestion>
            {
                // Bangladesh Bank Exams
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Maintenance Engineer", QuestionText = "[MCQ] Which one of the following is related to the services provided by cloud?\n(a) Sourcing (b) Ownership (c) Reliability (d) PaaS\nAns: (d) PaaS" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Maintenance Engineer", QuestionText = "[MCQ] What type of computing technology refers to services and applications that typically run on a distributed network through virtualized resources?\n(a) Distributed Computing (b) Cloud Computing (c) Soft Computing (d) Parallel Computing\nAns: (b) Cloud Computing" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Maintenance Engineer", QuestionText = "[MCQ] Cloud Computing architecture is a combination of:\n(a) Service-oriented architecture and grid computing (b) Utility computing and event-driven architecture (c) Service-oriented architecture and event-driven architecture (d) Virtualization and event-driven architecture\nAns: (c)" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Maintenance Engineer", QuestionText = "[MCQ] Service that generally focuses on the hardware follows which one of the following services models?\n(a) IaaS (b) PaaS (c) SaaS (d) Both A and B\nAns: (a) IaaS" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Maintenance Engineer", QuestionText = "[MCQ] Which one of the following cloud concepts is related to sharing and pooling resources?\n(a) Virtualization (b) Polymorphism (c) Abstraction (d) None of the above\nAns: (a) Virtualization" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Maintenance Engineer", QuestionText = "Explain IaaS, PaaS, and SaaS with respect to cloud computing." },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Maintenance Engineer", QuestionText = "Define a virtual machine with a neat diagram, explain the working of VM. What are the benefits of a VM?" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Maintenance Engineer", QuestionText = "What are the challenges in optimizing energy efficiency of data centers? Explain." },

                // Combined & Other Banks
                new() { CategoryOrder = order, Category = cat, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "What is cloud computing? Mention its service models (IaaS, PaaS, SaaS)." },
                new() { CategoryOrder = order, Category = cat, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "Define Virtualization. Explain the role of the Hypervisor and the difference between a Virtual Machine (VM) and a container." },
                new() { CategoryOrder = order, Category = cat, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "AME/AE IT", QuestionText = "Your bank wants to transform the full data center into a cloud. Sketch your strategy and plan to implement this procedure." },
                new() { CategoryOrder = order, Category = cat, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "Senior Officer IT", QuestionText = "What is SaaS and multi-tenant architecture? How are they related? Advantages and disadvantages of multi-tenancy? For a multi-vendor e-commerce app, single DB vs separate DB per vendor — which to choose and why?" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Combined Bank (BIBM)", Post = "Senior Officer AHE/AME", QuestionText = "You want to host a new banking solution in a data center. Describe the most important factors for purchasing decisions for the data center." },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "RAKUB (BIBM)", Post = "ANSE", QuestionText = "Write about Hypervisor." }
            };
        }
        #endregion
    }
}

