using ITSoftware.Models;

namespace ITSoftware.Services
{
    public static partial class PreviousYearQuestionSeeder
    {
        #region 11. OOP Concepts
        private static List<PreviousYearQuestion> GetOopQuestions()
        {
            const string cat = "OOP Concepts";
            const int order = 11;
            return new List<PreviousYearQuestion>
            {
                // Bangladesh Bank Exams
                new() { CategoryOrder = order, Category = cat, Year = 2025, ExamOrg = "Bangladesh Bank (DU)", Post = "Assistant Director (ICT)", QuestionText = "[MCQ] Which of the following does NOT achieve encapsulation?\n(a) Using private access specifier (b) Using classes in object-oriented programming (c) Using getter and setter methods (d) Using global variables\nAns: (d) Using global variables" },
                new() { CategoryOrder = order, Category = cat, Year = 2025, ExamOrg = "Bangladesh Bank (DU)", Post = "Assistant Director (ICT)", QuestionText = "[MCQ] Which of the following operators should be preferred to overload as a global function rather than a member method?\n(a) Postfix ++ (b) Comparison Operator (c) Insertion Operator << (d) Prefix ++\nAns: (c) Insertion Operator <<" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "[MCQ] Which of the following operators cannot be overloaded in C/C++?\n(a) Bitwise right shift assignment (b) Address of\n(c) Indirection (d) Structure reference\nAns: (d) Structure reference" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "Consider the following code:\nPublic class Class A {\n  Public void m1(){}\n  Public void m2(int i){}\n  Public void m3(int i){}\n  Public static void m4(int i){}\n}\nPublic class class B extends Class A {\n  Public static void m1(int i){}\n  Public void m2(int i){}\n  Public void m3(string s){}\n  Public static void m4(int i){}\n}\nMention which of the methods overload, override and hide super class methods. What about the remaining methods?" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "Draw a class diagram. A token-ring based local area network (LAN) is a network consisting of nodes in which network packets are sent around. Every node has a unique name within the network, and refers to its next node. Different kinds of nodes exist: Workstations are originators of messages; servers and printers are network nodes that can receive messages. Packets contain an originator, a destination and content. A LAN is a circular configuration of nodes." },
                new() { CategoryOrder = order, Category = cat, Year = 2019, ExamOrg = "Bangladesh Bank (DU)", Post = "Assistant Programmer", QuestionText = "Suppose you are implementing an \"Overdraft Account (OD)\" class using Java for a banking app. An OD type account is opened with an approved loan limit (ex. 100000/-). The account holder can deposit any amount of money in the OD account at any time. S/he can draw an amount of money from the account (acn) until sufficient balance. S/he is allowed to draw money beyond his/her acn balance if the total over-drawing amount remains within the loan limit. Write a Java class sketch for OD account running in multi-threading mode." },
                new() { CategoryOrder = order, Category = cat, Year = 2016, ExamOrg = "Bangladesh Bank", Post = "Assistant Programmer", QuestionText = "What is polymorphism? What is the difference between method overriding and method overloading?" },
                new() { CategoryOrder = order, Category = cat, Year = 2011, ExamOrg = "Bangladesh Bank", Post = "Assistant Programmer", QuestionText = "[MCQ] Overloaded functions are:\n(a) Very long functions that can hardly run (b) One function containing another one or more functions inside it (c) Two or more functions with same name but different number of parameters or type (d) None of above\nAns: (c)" },
                new() { CategoryOrder = order, Category = cat, Year = 2011, ExamOrg = "Bangladesh Bank", Post = "Assistant Programmer", QuestionText = "[MCQ] Find any errors in the following BankAccount constructor in C#.NET: public int BankAccount() { balance=0; }\n(a) Name (b) Formal parameters (c) Return type (d) None\nAns: (c) Return type" },

                // Combined & Other Banks
                new() { CategoryOrder = order, Category = cat, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "Explain the concept of inheritance in OOP. Name and briefly describe three common types of inheritance." },
                new() { CategoryOrder = order, Category = cat, Year = 2025, ExamOrg = "Combined Bank (BIBM)", Post = "Officer IT", QuestionText = "Write a program using OOP (C++/Java/Python) representing a Bank Account with: data members (account holder name, account number, balance), methods (deposit, withdraw ensuring sufficient balance, display). Demonstrate encapsulation." },
                new() { CategoryOrder = order, Category = cat, Year = 2024, ExamOrg = "Combined 5 Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "What is polymorphism? Describe different types of polymorphism." },
                new() { CategoryOrder = order, Category = cat, Year = 2024, ExamOrg = "Combined 2 Bank (BIBM)", Post = "Officer IT", QuestionText = "Explain how encapsulation and inheritance are advantageous in OOP." },
                new() { CategoryOrder = order, Category = cat, Year = 2024, ExamOrg = "Combined 2 Bank (BIBM)", Post = "Officer IT", QuestionText = "Design a Circle class that: is translatable from its origin, gives perimeter and area. Identify data and method requirements and give data flow of the translation method." },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Combined 5 Bank (BIBM)", Post = "Officer IT", QuestionText = "Draw a class diagram for a Book: composed of parts → chapters → sections. Book has publisher, publication date, ISBN. Part has title and number. Chapter has title, number, abstract. Section has title and number." },
                new() { CategoryOrder = order, Category = cat, Year = 2022, ExamOrg = "ANE JBL", Post = "Assistant Network Engineer", QuestionText = "Explain OOP concepts with proper examples." },
                new() { CategoryOrder = order, Category = cat, Year = 2021, ExamOrg = "AHE SBL/JBL/RBL", Post = "Assistant Hardware Engineer", QuestionText = "Difference between Object Oriented Programming and Procedural Oriented Programming." },
                new() { CategoryOrder = order, Category = cat, Year = 2021, ExamOrg = "AHE SBL/JBL/RBL", Post = "Assistant Hardware Engineer", QuestionText = "Explain method overloading and method overriding." },
                new() { CategoryOrder = order, Category = cat, Year = 2020, ExamOrg = "BSCS Combined 2 Bank (SB&JB)", Post = "Officer IT", QuestionText = "Inheritance is one of the important issues for OOP. Explain in brief different types of inheritance." }
            };
        }
        #endregion
    }
}

