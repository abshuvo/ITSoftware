using ITSoftware.Data;
using ITSoftware.Models;
using Microsoft.EntityFrameworkCore;

namespace ITSoftware.Services
{
    public static class FlashcardSeeder
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ExamPrepDbContext>();

            if (await context.Flashcards.AnyAsync())
            {
                return; // Already seeded
            }

            var flashcards = GetInitialFlashcards();
            context.Flashcards.AddRange(flashcards);
            await context.SaveChangesAsync();
        }

        public static List<Flashcard> GetInitialFlashcards()
        {
            return new List<Flashcard>
            {
                // Networking
                new Flashcard
                {
                    Category = "Networking",
                    FrontText = "OSI Model এর ৭টি লেয়ার নিচ থেকে উপরে কী কী?",
                    BackText = "১. Physical Layer\n২. Data Link Layer\n৩. Network Layer\n৪. Transport Layer\n৫. Session Layer\n৬. Presentation Layer\n৭. Application Layer\n\n📌 মনে রাখার শর্টকাট: Please Do Not Touch Steve's Pet Alligator",
                    Hint = "Physical to Application",
                    Difficulty = "Easy"
                },
                new Flashcard
                {
                    Category = "Networking",
                    FrontText = "গুরুত্বপূর্ণ প্রোটোকল ও তাদের পোর্ট নম্বর (Port Numbers)",
                    BackText = "• HTTP: 80\n• HTTPS: 443\n• DNS: 53\n• FTP: 20, 21\n• SSH / SFTP: 22\n• Telnet: 23\n• SMTP: 25\n• POP3: 110\n• IMAP: 143\n• DHCP: 67, 68\n• SNMP: 161",
                    Hint = "HTTP, HTTPS, SSH, DNS...",
                    Difficulty = "Medium"
                },
                new Flashcard
                {
                    Category = "Networking",
                    FrontText = "TCP vs UDP এর মূল পার্থক্য কী?",
                    BackText = "• TCP (Transmission Control Protocol): Connection-oriented, Reliable, Error checking & Acknowledgement আছে, তুলনামূলক ধীর (Web, Email, File transfer)।\n\n• UDP (User Datagram Protocol): Connectionless, Unreliable, No Acknowledgement, অত্যন্ত দ্রুত ও Lightweight (Streaming, Gaming, VoIP, DNS)।",
                    Hint = "Connection-oriented vs Connectionless",
                    Difficulty = "Easy"
                },
                new Flashcard
                {
                    Category = "Networking",
                    FrontText = "IPv4 vs IPv6 এর সাইজ এবং ফরম্যাট",
                    BackText = "• IPv4: 32-bit (4 bytes), ডটেড ডেসিমাল ফরম্যাট (যেমন: 192.168.1.1), মোট প্রায় ৪.৩ বিলিয়ন অ্যাড্রেস।\n\n• IPv6: 128-bit (16 bytes), হেক্সাডেসিমাল কোলন ফরম্যাট (যেমন: 2001:0db8::ff00:42), 2^128 টি বিশাল অ্যাড্রেস স্পেস।",
                    Hint = "32-bit vs 128-bit",
                    Difficulty = "Medium"
                },

                // Database
                new Flashcard
                {
                    Category = "Database",
                    FrontText = "ACID Properties in DBMS কী কী?",
                    BackText = "• Atomicity (অল অর নাথিং): সম্পূর্ণ ট্রানজাকশন সম্পন্ন হবে অথবা রোলব্যাক হবে।\n• Consistency: ট্রানজাকশনের আগে ও পরে ডেটাবেজ ভ্যালিড স্টেটে থাকবে।\n• Isolation: একাধিক ট্রানজাকশন একে অপরের থেকে স্বাধীনভাবে চলবে।\n• Durability: একবার কমিট হলে সিস্টেম ক্র্যাশ করলেও ডেটা স্থায়ী থাকবে।",
                    Hint = "A-C-I-D",
                    Difficulty = "Easy"
                },
                new Flashcard
                {
                    Category = "Database",
                    FrontText = "Normalization Rules (1NF, 2NF, 3NF, BCNF)",
                    BackText = "• 1NF: Atomic values (no repeating groups / multi-valued attributes).\n• 2NF: 1NF + No Partial Dependency (সকল non-key attribute সম্পূর্ণ Candidate Key-র ওপর নির্ভরশীল)।\n• 3NF: 2NF + No Transitive Dependency (non-key attribute অন্য non-key attribute-র ওপর নির্ভরশীল হতে পারবে না)।\n• BCNF: 3NF + For every functional dependency X -> Y, X must be a Super Key.",
                    Hint = "Atomic, Partial, Transitive, Super Key",
                    Difficulty = "Hard"
                },
                new Flashcard
                {
                    Category = "Database",
                    FrontText = "Clustered Index vs Non-Clustered Index",
                    BackText = "• Clustered Index: টেবিলের ফিজিক্যাল ডেটা সারিকে ওই অর্ডারে সাজায়। প্রতি টেবিলে সর্বোচ্চ ১টি Clustered Index থাকে (ডিফল্টভাবে Primary Key)।\n\n• Non-Clustered Index: ডেটা থেকে আলাদা একটি ইনডেক্স ট্রি তৈরি করে যেখানে পয়েন্টার থাকে। একটি টেবিলে একাধিক Non-Clustered Index থাকতে পারে।",
                    Hint = "Physical data order vs Pointer index",
                    Difficulty = "Medium"
                },
                new Flashcard
                {
                    Category = "Database",
                    FrontText = "SQL DDL, DML, DCL, TCL কমান্ডের উদাহরণ",
                    BackText = "• DDL (Data Definition): CREATE, ALTER, DROP, TRUNCATE, RENAME\n• DML (Data Manipulation): SELECT, INSERT, UPDATE, DELETE\n• DCL (Data Control): GRANT, REVOKE\n• TCL (Transaction Control): COMMIT, ROLLBACK, SAVEPOINT",
                    Hint = "CREATE vs INSERT vs GRANT vs COMMIT",
                    Difficulty = "Easy"
                },

                // Operating Systems
                new Flashcard
                {
                    Category = "Operating System",
                    FrontText = "Deadlock এর ৪টি অপরিহার্য শর্ত (Coffman Conditions)",
                    BackText = "১. Mutual Exclusion (একবারে একজন রিসোর্স ব্যবহার করবে)\n২. Hold and Wait (একটি রিসোর্স ধরে রেখে অন্যটির জন্য অপেক্ষা)\n৩. No Preemption (জোর করে রিসোর্স কেড়ে নেওয়া যাবে না)\n৪. Circular Wait (রিসোর্সের জন্য একটি চক্রাকার অপেক্ষার চেইন তৈরি হওয়া)",
                    Hint = "Mutual Exclusion, Hold & Wait, No Preemption, Circular Wait",
                    Difficulty = "Medium"
                },
                new Flashcard
                {
                    Category = "Operating System",
                    FrontText = "Process vs Thread",
                    BackText = "• Process: একটি এক্সিকিউটিং প্রোগ্রাম। নিজস্ব মেমোরি স্পেস (Address space) থাকে। তৈরি ও কনটেক্সট সুইচে বেশি ওভারহেড।\n\n• Thread: প্রসেসের ভেতরে একটি লাইটওয়েট এক্সিকিউশন ইউনিট। একই প্রসেসের থ্রেডগুলো কোড, ডেটা ও ফাইল শেয়ার করে। দ্রুত তৈরি ও সুইচ হয়।",
                    Hint = "Heavyweight isolated vs Lightweight shared memory",
                    Difficulty = "Easy"
                },
                new Flashcard
                {
                    Category = "Operating System",
                    FrontText = "Virtual Memory & Paging কী?",
                    BackText = "• Virtual Memory: হার্ডডিস্কের কিছু অংশকে র‍্যামের সম্প্রসারণ হিসেবে ব্যবহার করে যাতে ফিজিক্যাল মেমোরির চেয়ে বড় প্রোগ্রামও রান করা যায়।\n\n• Paging: লজিক্যাল মেমোরিকে সমান সাইজের ব্লকে ভাগ করাকে 'Pages' এবং ফিজিক্যাল মেমোরিকে 'Frames' বলে। পেজ মেমরিতে না থাকলে 'Page Fault' ঘটে।",
                    Hint = "Pages, Frames, Page Fault",
                    Difficulty = "Medium"
                },

                // Data Structures & Algorithms
                new Flashcard
                {
                    Category = "DSA",
                    FrontText = "Common Sorting Algorithms Time Complexities",
                    BackText = "• Quick Sort: Best/Avg: O(n log n), Worst: O(n^2)\n• Merge Sort: Best/Avg/Worst: O(n log n)\n• Heap Sort: Best/Avg/Worst: O(n log n)\n• Bubble / Selection / Insertion: Avg/Worst: O(n^2)\n• Binary Search: O(log n)",
                    Hint = "Merge Sort vs Quick Sort vs Binary Search",
                    Difficulty = "Medium"
                },
                new Flashcard
                {
                    Category = "DSA",
                    FrontText = "Stack vs Queue ডেটা স্ট্রাকচার",
                    BackText = "• Stack: LIFO (Last In First Out)। অপারেশন: push(), pop(), peek() - O(1)। ব্যবহার: ফাংশন কল স্ট্যাক, Undo/Redo, ব্র্যাকেট ম্যাচিং।\n\n• Queue: FIFO (First In First Out)। অপারেশন: enqueue(), dequeue() - O(1)। ব্যবহার: CPU শিডিউলিং, প্রিন্টার বাফার, BFS ট্রাভার্সাল।",
                    Hint = "LIFO vs FIFO",
                    Difficulty = "Easy"
                },
                new Flashcard
                {
                    Category = "DSA",
                    FrontText = "Tree Traversal কৌশলসমূহ (Inorder, Preorder, Postorder)",
                    BackText = "• Inorder: Left -> Root -> Right (BST এর ক্ষেত্রে সর্টেড অর্ডারে আউটপুট দেয়)\n• Preorder: Root -> Left -> Right (ট্রি কপি তৈরিতে ব্যবহৃত)\n• Postorder: Left -> Right -> Root (ট্রি ডিলিট ও বটম-আপ ক্যালকুলেশনে ব্যবহৃত)\n• Level Order: BFS ভিত্তিক লেভেল অনুযায়ী ট্রাভার্সাল।",
                    Hint = "Left, Root, Right এর ক্রম",
                    Difficulty = "Medium"
                },

                // Software Engineering & OOP
                new Flashcard
                {
                    Category = "OOP & SE",
                    FrontText = "SOLID Principles in Software Engineering",
                    BackText = "• S - Single Responsibility Principle (একটি ক্লাসের একটিই দায়িত্ব থাকবে)\n• O - Open/Closed Principle (Open for extension, closed for modification)\n• L - Liskov Substitution Principle (সাবক্লাস দিয়ে প্যারেন্ট ক্লাস রিপ্লেস করা যাবে)\n• I - Interface Segregation Principle (অপ্রয়োজনীয় ইন্টারফেস মেথড চাপিয়ে না দেওয়া)\n• D - Dependency Inversion Principle (High level modules should depend on abstractions)",
                    Hint = "S-O-L-I-D",
                    Difficulty = "Hard"
                },
                new Flashcard
                {
                    Category = "OOP & SE",
                    FrontText = "OOP এর ৪টি মূল স্তম্ভ (Four Pillars)",
                    BackText = "১. Encapsulation: ডেটা এবং মেথডকে একটি ইউনিটে বাইন্ড করা এবং প্রাইভেট ভ্যারিয়েবল রক্ষা করা।\n২. Abstraction: অভ্যন্তরীণ জটিলতা লুকিয়ে শুধু প্রয়োজনীয় ইন্টারফেস প্রদর্শন করা।\n৩. Inheritance: প্যারেন্ট ক্লাসের কোড ও বৈশিষ্ট্য চাইল্ড ক্লাসে পুনঃব্যবহার করা।\n৪. Polymorphism: একই মেথড বা ইন্টারফেসের ভিন্ন ভিন্ন আচরণ (Method Overloading & Overriding)।",
                    Hint = "Encapsulation, Abstraction, Inheritance, Polymorphism",
                    Difficulty = "Easy"
                }
            };
        }
    }
}
