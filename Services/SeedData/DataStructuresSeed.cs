using ITSoftware.Models;

namespace ITSoftware.Services
{
    public static partial class PreviousYearQuestionSeeder
    {
        #region 7. Data Structures
        private static List<PreviousYearQuestion> GetDataStructuresQuestions()
        {
            const string cat = "Data Structures";
            const int order = 7;
            return new List<PreviousYearQuestion>
            {
                // Bangladesh Bank Exams
                new() { CategoryOrder = order, Category = cat, Year = 2025, ExamOrg = "Bangladesh Bank (DU)", Post = "Assistant Director (ICT)", QuestionText = "[MCQ] Which data structure is preferred for Priority Queue?\n(a) Heap Tree (b) Graph (c) Stack (d) Table\nAns: (a) Heap Tree" },
                new() { CategoryOrder = order, Category = cat, Year = 2025, ExamOrg = "Bangladesh Bank (DU)", Post = "Assistant Director (ICT)", QuestionText = "[MCQ] What is the worst case time complexity of inserting n elements into an empty linked list, if the linked list needs to be maintained in sorted order?\n(a) Θ(n) (b) Θ(n log n) (c) Θ(n²) (d) Θ(1)\nAns: (c) Θ(n²)" },
                new() { CategoryOrder = order, Category = cat, Year = 2025, ExamOrg = "Bangladesh Bank (DU)", Post = "Assistant Director (ICT)", QuestionText = "[MCQ] Which one of the following is an application of Stack Data Structure?\n(a) Managing function calls (b) The stock span problem (c) Arithmetic expression evaluation (d) All of the above\nAns: (d) All of the above" },
                new() { CategoryOrder = order, Category = cat, Year = 2025, ExamOrg = "Bangladesh Bank (DU)", Post = "Assistant Director (ICT)", QuestionText = "[MCQ] What is the best way to implement priority queue?\n(a) Array (b) Linked List (c) Heap (d) Stack\nAns: (c) Heap" },
                new() { CategoryOrder = order, Category = cat, Year = 2025, ExamOrg = "Bangladesh Bank (DU)", Post = "Assistant Director (ICT)", QuestionText = "Construction of Min Heap: Given values 12, 29, 33, 56, 66, 99, 100, and 344. Construct the Min Heap step-by-step." },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "[MCQ] Which of the following is a non linear data structure?\n(a) Array (b) Graph (c) Queue (d) Linked list\nAns: (b) Graph" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "[MCQ] Which data structure allows insertion and deletion of elements from both ends?\n(a) Deque (b) Queue (c) Stack (d) Linked list\nAns: (a) Deque" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "[MCQ] In a complete k-ary tree, every internal node has exactly k children. The number of leaves in such a tree with n internal nodes is:\n(a) (n-1)k+1 (b) nk (c) n(k-1) (d) n(k-1)+1\nAns: (d) n(k-1)+1" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "[MCQ] Access time of the symbolic table will be logarithmic if it is implemented by:\n(a) Linear list (b) Search tree (c) Hash table (d) Self organization list\nAns: (b) Search tree" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "Consider a hash table of size 13 with integer keys. Suppose the hash function is h(k) = k mod 13. Insert in given order entries with keys 10, 3, 6, 16, 17, 19 into the hash table using linear probing to resolve collisions. Show all work." },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "Given an adjacency list representation for a complete binary tree on 7 vertices. Give an equivalent adjacency matrix representation. Assume that vertices are numbered from 1 to 7 as in a binary heap." },
                new() { CategoryOrder = order, Category = cat, Year = 2016, ExamOrg = "Bangladesh Bank", Post = "Assistant Programmer", QuestionText = "[MCQ] Which is correct for stack?\n(a) FIFO (b) LIFO (c) Both A, B (d) None\nAns: (b) LIFO" },
                new() { CategoryOrder = order, Category = cat, Year = 2016, ExamOrg = "Bangladesh Bank", Post = "Assistant Programmer", QuestionText = "[MCQ] Find the correct arranged data after stack operation: push(1), push(2), pop, push(1), push(2), pop, pop, pop, push(2), pop.\n(a) 2 2 1 1 2 (b) 2 2 1 2 1 (c) 2 2 2 2 1 (d) 2 2 2 1 2\nAns: (a) 2 2 1 1 2" },
                new() { CategoryOrder = order, Category = cat, Year = 2016, ExamOrg = "Bangladesh Bank", Post = "Assistant Programmer", QuestionText = "[MCQ] Stack operations are:\n(a) delete, insertion (b) insertion, delete (c) push, pop (d) pop, push\nAns: (c) push, pop" },
                new() { CategoryOrder = order, Category = cat, Year = 2016, ExamOrg = "Bangladesh Bank", Post = "Assistant Programmer", QuestionText = "[MCQ] Which is not linear?\n(a) Linked list (b) array (c) graph (d) None\nAns: (c) graph" },
                new() { CategoryOrder = order, Category = cat, Year = 2016, ExamOrg = "Bangladesh Bank", Post = "Assistant Programmer", QuestionText = "Write prefix and postfix notations for the expression: ((A+B)*C-(D-E)^F)." },

                // Combined & Other Banks
                new() { CategoryOrder = order, Category = cat, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "Describe step-by-step how Binary Search locates a target value in a sorted array. Why does it fail if the array is unsorted?" },
                new() { CategoryOrder = order, Category = cat, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "You have two stacks. Explain the logic required to implement a Queue (FIFO) using only these two stacks." },
                new() { CategoryOrder = order, Category = cat, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "Explain the logic of Bubble Sort. Why is it considered inefficient for large datasets compared to Merge Sort?" },
                new() { CategoryOrder = order, Category = cat, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "Draw or describe a Flowchart to determine the largest of three distinct numbers A, B, C." },
                new() { CategoryOrder = order, Category = cat, Year = 2025, ExamOrg = "Combined Bank (BIBM)", Post = "Officer IT", QuestionText = "Determine whether the following pair of graphs are isomorphic and justify your answer in one sentence." },
                new() { CategoryOrder = order, Category = cat, Year = 2024, ExamOrg = "Combined 5 Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "Difference between stack and queue. Write two uses for each." },
                new() { CategoryOrder = order, Category = cat, Year = 2024, ExamOrg = "Combined 2 Bank (BIBM)", Post = "Officer IT", QuestionText = "Convert infix expression P = 12/(7-3)+2 to postfix and evaluate it." },
                new() { CategoryOrder = order, Category = cat, Year = 2024, ExamOrg = "Combined 2 Bank (BIBM)", Post = "Officer IT", QuestionText = "Explain the difference between a singly linked list and a doubly linked list." },
                new() { CategoryOrder = order, Category = cat, Year = 2024, ExamOrg = "Combined 2 Bank (BIBM)", Post = "Officer IT", QuestionText = "Describe and estimate the costs of inserting a new item into an existing binary max heap." },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Combined 5 Bank (BIBM)", Post = "Officer IT", QuestionText = "Max Heap operations [a–j] showing after each: Insert 5, Insert 6, Insert 8, Extract-Root, Insert 4, Insert 11, Extract-Root, Insert 7, Extract-Root, Extract-Root. Show which value is returned when root is extracted each time." },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Combined 5 Bank (BIBM)", Post = "Officer IT", QuestionText = "Consider two representations of a directed graph. Which problem is solved more efficiently by adjacency list vs. adjacency matrix?" },
                new() { CategoryOrder = order, Category = cat, Year = 2022, ExamOrg = "Security Printing Corp Bangladesh", Post = "Sub-Assistant Engineer", QuestionText = "Difference between LIFO and FIFO in data structure." },
                new() { CategoryOrder = order, Category = cat, Year = 2022, ExamOrg = "ANA JBL", Post = "Assistant Network Administrator", QuestionText = "Write adjacency matrix and adjacency list for a given graph. Calculate in-degree and out-degrees of all vertices." },
                new() { CategoryOrder = order, Category = cat, Year = 2022, ExamOrg = "SBL/BDBL", Post = "Senior Officer IT", QuestionText = "Construct a binary tree from Preorder: {1,2,4,5,3,6,8,9,7} and Postorder: {4,5,2,8,9,6,7,3,1}." },
                new() { CategoryOrder = order, Category = cat, Year = 2022, ExamOrg = "ADA SBL/JBL", Post = "Assistant Database Administrator", QuestionText = "How is hashing done for a set of numbers using f(x)=x mod 10? Show the process in diagrams and the resulting hash table." },
                new() { CategoryOrder = order, Category = cat, Year = 2021, ExamOrg = "ANE RBL", Post = "Assistant Network Engineer", QuestionText = "Construct a binary tree from In-order: 4,2,1,7,5,8,3,6 and Pre-order: 1,2,4,3,5,7,8,6." },
                new() { CategoryOrder = order, Category = cat, Year = 2020, ExamOrg = "BSCS Combined 2 Bank (SB&JB)", Post = "Officer IT", QuestionText = "Queue is an abstract data structure. Write the steps of the Enqueue operation of Queue." },
                new() { CategoryOrder = order, Category = cat, Year = 2020, ExamOrg = "Combined 3 Banks (SBL/BDBL)", Post = "Senior Officer IT", QuestionText = "Explain operation of Binary Search Tree (BST)." },
                new() { CategoryOrder = order, Category = cat, Year = 2020, ExamOrg = "ANE JBL", Post = "Assistant Network Engineer", QuestionText = "Given In-order: 10,20,40,50,60,70,90,100 and Pre-order: 50,20,10,40,70,60,90,100. (i) Construct BST. (ii) Write pseudocode for the sum of all nodes." },
                new() { CategoryOrder = order, Category = cat, Year = 2020, ExamOrg = "ADA SBL", Post = "Assistant Database Admin", QuestionText = "Construct Binary Search Tree (BST) for: 4, 7, 5, 1, 3, 9, 10, 8, 12. Show all steps." }
            };
        }
        #endregion
    }
}

