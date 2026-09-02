using ITSoftware.Data;
using ITSoftware.Models;
using Microsoft.EntityFrameworkCore;

namespace ITSoftware.Services
{
    public static partial class McqQuestionSeeder
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider, bool forceReset = false)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ExamPrepDbContext>();

            try
            {
                await context.Database.EnsureCreatedAsync();

                // Ensure SubCategory and Tag columns exist in SQL Server table
                try
                {
                    await context.Database.ExecuteSqlRawAsync(@"
                        IF NOT EXISTS (
                            SELECT 1 FROM sys.columns 
                            WHERE object_id = OBJECT_ID('McqQuestions') AND name = 'SubCategory'
                        )
                        BEGIN
                            ALTER TABLE McqQuestions ADD SubCategory NVARCHAR(150) NULL;
                        END

                        IF NOT EXISTS (
                            SELECT 1 FROM sys.columns 
                            WHERE object_id = OBJECT_ID('McqQuestions') AND name = 'Tag'
                        )
                        BEGIN
                            ALTER TABLE McqQuestions ADD Tag NVARCHAR(150) NULL;
                        END
                    ");
                }
                catch { /* ignore */ }

                // Check if database needs re-seed (e.g. old category names "Basics", "Process Scheduling" instead of "Operating System")
                var needsReseed = forceReset ||
                    await context.McqQuestions.AnyAsync(q => q.Category == "Basics" || q.Category == "Process Scheduling" || q.Category == "Process Synchronization") ||
                    !await context.McqQuestions.AnyAsync(q => q.Category == "Operating System");

                if (needsReseed)
                {
                    context.McqQuestions.RemoveRange(context.McqQuestions);
                    await context.SaveChangesAsync();
                    await context.McqQuestions.AddRangeAsync(GetAllMcqQuestions());
                    await context.SaveChangesAsync();
                    return;
                }

                await SyncMcqQuestionsAsync(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MCQ Seeding error: {ex.Message}");
            }
        }

        public static async Task SyncMcqQuestionsAsync(ExamPrepDbContext context)
        {
            var seedList = GetAllMcqQuestions();
            var existingQuestions = await context.McqQuestions.ToListAsync();

            if (existingQuestions.Count == 0)
            {
                await context.McqQuestions.AddRangeAsync(seedList);
                await context.SaveChangesAsync();
                return;
            }

            var existingKeys = existingQuestions
                .Select(q => q.QuestionText.Trim().ToLowerInvariant())
                .ToHashSet();

            var toAdd = seedList
                .Where(sq => !existingKeys.Contains(sq.QuestionText.Trim().ToLowerInvariant()))
                .ToList();

            if (toAdd.Count > 0)
            {
                await context.McqQuestions.AddRangeAsync(toAdd);
                await context.SaveChangesAsync();
            }
        }

        public static List<McqQuestion> GetAllMcqQuestions()
        {
            var list = new List<McqQuestion>();
            // Operating System (7 major subtopics)
            list.AddRange(GetOsBasicsQuestions());
            list.AddRange(GetOsSchedulingQuestions());
            list.AddRange(GetOsSyncQuestions());
            list.AddRange(GetOsDeadlockQuestions());
            list.AddRange(GetOsThreadingQuestions());
            list.AddRange(GetOsMemoryQuestions());
            list.AddRange(GetOsDiskQuestions());

            // Other Subjects: Networking, DSA, Database, etc.
            list.AddRange(GetGeneralBankMcqs());
            return list;
        }

        private static List<McqQuestion> GetGeneralBankMcqs()
        {
            return new List<McqQuestion>
            {
                #region 1. Networking & Data Communication
                new() {
                    Category = "Networking & Data Communication", SubCategory = "Networking Protocols & OSI",
                    QuestionText = "Which layer of the OSI model does Ethernet belong to?",
                    OptionA = "Physical and Data Link",
                    OptionB = "Data Link and Network",
                    OptionC = "Network and Transport",
                    OptionD = "Application and Presentation",
                    CorrectAnswer = "A",
                    Explanation = "Bangladesh Bank AD ICT 2025 — Ethernet (IEEE 802.3) covers Layer 1 (Physical) and Layer 2 (Data Link - MAC/LLC)."
                },
                new() {
                    Category = "Networking & Data Communication", SubCategory = "Networking Protocols & OSI",
                    QuestionText = "Total delay of a packet from source to destination is:",
                    OptionA = "Transmission delay + Queuing delay",
                    OptionB = "Propagation delay + Transmission delay + Queuing delay + Processing delay",
                    OptionC = "Propagation delay + Transmission delay",
                    OptionD = "Processing delay + Queuing delay",
                    CorrectAnswer = "B",
                    Explanation = "Bangladesh Bank AD ICT 2025 — Total nodal delay = d_proc + d_queue + d_trans + d_prop."
                },
                new() {
                    Category = "Networking & Data Communication", SubCategory = "Networking Protocols & OSI",
                    QuestionText = "Which one of the following is an interior gateway routing protocol?",
                    OptionA = "BGP",
                    OptionB = "OSPF",
                    OptionC = "EGP",
                    OptionD = "None of the above",
                    CorrectAnswer = "B",
                    Explanation = "Bangladesh Bank AD ICT 2025 — OSPF (Open Shortest Path First) and RIP are Interior Gateway Protocols (IGP); BGP is Exterior (EGP)."
                },
                new() {
                    Category = "Networking & Data Communication", SubCategory = "Networking Protocols & OSI",
                    QuestionText = "The 32-bit IP address 10001010 00010101 10001111 00000000 in dotted decimal notation is:",
                    OptionA = "138.20.143.0",
                    OptionB = "138.21.143.0",
                    OptionC = "138.20.144.0",
                    OptionD = "138.21.144.0",
                    CorrectAnswer = "B",
                    Explanation = "Bangladesh Bank AME 2023 — 10001010=138, 00010101=21, 10001111=143, 00000000=0."
                },
                new() {
                    Category = "Networking & Data Communication", SubCategory = "Networking Protocols & OSI",
                    QuestionText = "Suppose computers A and B have IP addresses 10.105.1.113 and 10.105.1.91 respectively and both use the same netmask N. Which value of N will place A and B in different subnets?",
                    OptionA = "255.255.255.0",
                    OptionB = "255.255.255.128",
                    OptionC = "255.255.255.192",
                    OptionD = "255.255.255.224",
                    CorrectAnswer = "C",
                    Explanation = "Bangladesh Bank AME 2023 — With /26 (255.255.255.192), subnets are 0-63, 64-127, 128-191. 91 is in (64-127) while 113 is in (64-127), so 255.255.255.224 (/27) or 255.255.255.192 splits them."
                },
                new() {
                    Category = "Networking & Data Communication", SubCategory = "Networking Protocols & OSI",
                    QuestionText = "How many bytes are present in an Ethernet MAC address?",
                    OptionA = "4",
                    OptionB = "6",
                    OptionC = "8",
                    OptionD = "16",
                    CorrectAnswer = "B",
                    Explanation = "Bangladesh Bank AME 2023 — MAC address is 48 bits = 6 bytes."
                },
                new() {
                    Category = "Networking & Data Communication", SubCategory = "Networking Protocols & OSI",
                    QuestionText = "Packets of the same session may take different paths in which network?",
                    OptionA = "Virtual Circuit packet switched network",
                    OptionB = "Datagram packet switched network",
                    OptionC = "Circuit switched network",
                    OptionD = "All of the above",
                    CorrectAnswer = "B",
                    Explanation = "Bangladesh Bank AP 2023 — In connectionless Datagram networks, each packet is routed independently."
                },
                new() {
                    Category = "Networking & Data Communication", SubCategory = "Networking Protocols & OSI",
                    QuestionText = "Which one of the following is true for the sliding window flow control protocol?",
                    OptionA = "Window size at receiver is always 1",
                    OptionB = "Window size at sender is always greater than 1",
                    OptionC = "Window size at sender can be 1",
                    OptionD = "Window size at receiver is always greater than 1",
                    CorrectAnswer = "C",
                    Explanation = "Bangladesh Bank AP 2023 — In Stop-and-Wait ARQ (special case of sliding window), sender window size = 1."
                },
                new() {
                    Category = "Networking & Data Communication", SubCategory = "Networking Protocols & OSI",
                    QuestionText = "The term 'Duplex' in data transmission means:",
                    OptionA = "Communication is one directional only",
                    OptionB = "Communication is bi-directional",
                    OptionC = "Communication is both directional but not at the same time",
                    OptionD = "None",
                    CorrectAnswer = "B",
                    Explanation = "Bangladesh Bank AD IT 2016 — Duplex (Full-Duplex) allows simultaneous bi-directional communication."
                },
                new() {
                    Category = "Networking & Data Communication", SubCategory = "Networking Protocols & OSI",
                    QuestionText = "The protocol that operates at the transport layer of the OSI model is:",
                    OptionA = "IP",
                    OptionB = "UDP",
                    OptionC = "ARP",
                    OptionD = "HTTP",
                    CorrectAnswer = "B",
                    Explanation = "Bangladesh Bank AP 2016 — TCP and UDP are Layer 4 (Transport Layer) protocols."
                },
                new() {
                    Category = "Networking & Data Communication", SubCategory = "Networking Protocols & OSI",
                    QuestionText = "Default subnet mask for Class C network is:",
                    OptionA = "255.0.0.0",
                    OptionB = "255.255.0.0",
                    OptionC = "255.255.255.0",
                    OptionD = "255.255.255.255",
                    CorrectAnswer = "C",
                    Explanation = "Bangladesh Bank AME 2013 — Class C default mask is 255.255.255.0 (/24)."
                },
                new() {
                    Category = "Networking & Data Communication", SubCategory = "Networking Protocols & OSI",
                    QuestionText = "What frequency band does Bluetooth operate in?",
                    OptionA = "2.4 GHz ISM band",
                    OptionB = "5.0 GHz band",
                    OptionC = "900 MHz band",
                    OptionD = "60 GHz band",
                    CorrectAnswer = "A",
                    Explanation = "Bangladesh Bank AME 2011 — Bluetooth uses 2.4 GHz (2.402 to 2.480 GHz) ISM unlicensed band."
                },
                new() {
                    Category = "Networking & Data Communication", SubCategory = "Networking Protocols & OSI",
                    QuestionText = "The port number of DNS service is:",
                    OptionA = "21",
                    OptionB = "25",
                    OptionC = "53",
                    OptionD = "80",
                    CorrectAnswer = "C",
                    Explanation = "Bangladesh Bank AME 2011 — DNS uses Port 53 (UDP/TCP)."
                },
                new() {
                    Category = "Networking & Data Communication", SubCategory = "Networking Protocols & OSI",
                    QuestionText = "Which device connects two different LANs with different protocols?",
                    OptionA = "Bridge",
                    OptionB = "Repeater",
                    OptionC = "Gateway",
                    OptionD = "Hub",
                    CorrectAnswer = "C",
                    Explanation = "Bangladesh Bank AP 2011 — A Gateway performs protocol conversion between disparate architectures."
                },
                #endregion

                #region 2. Programming & Algorithms
                new() {
                    Category = "Data Structures & Algorithms", SubCategory = "Programming & Algorithms",
                    QuestionText = "Given code:\nint a = 1, b = 2;\nint *p = &a, *q = &b;\n*p = *q;\nWhat are the values of a and b?",
                    OptionA = "a = 1, b = 2",
                    OptionB = "a = 2, b = 2",
                    OptionC = "a = 1, b = 1",
                    OptionD = "a = 2, b = 1",
                    CorrectAnswer = "B",
                    Explanation = "Bangladesh Bank AD ICT 2025 — *p dereferences a, so a is assigned the value of *q (which is b=2). Hence a=2, b=2."
                },
                new() {
                    Category = "Data Structures & Algorithms", SubCategory = "Programming & Algorithms",
                    QuestionText = "Given nested loop:\nfor(int i=0; i<n; i++)\n  for(int j=0; j<n; j++)\n    for(int k=0; k<n; k++)\n      statement;\nWhat is the time complexity?",
                    OptionA = "O(n)",
                    OptionB = "O(n²)",
                    OptionC = "O(n³)",
                    OptionD = "O(log n)",
                    CorrectAnswer = "C",
                    Explanation = "Bangladesh Bank AD ICT 2025 — 3 nested loops each iterating n times result in O(n³) operations."
                },
                new() {
                    Category = "Data Structures & Algorithms", SubCategory = "Programming & Algorithms",
                    QuestionText = "Which language does NOT support pointers directly for memory manipulation?",
                    OptionA = "C",
                    OptionB = "C++",
                    OptionC = "Java",
                    OptionD = "Assembly",
                    CorrectAnswer = "C",
                    Explanation = "Bangladesh Bank AD ICT 2025 — Java eliminates explicit pointer arithmetic for security and simplicity."
                },
                new() {
                    Category = "Data Structures & Algorithms", SubCategory = "Programming & Algorithms",
                    QuestionText = "Given loop in C:\nfor(int i=0; i<10; i++) {\n  if(i % 2 == 0) continue;\n  printf(\"%d \", i);\n}\nWhat is printed?",
                    OptionA = "0 2 4 6 8",
                    OptionB = "1 3 5 7 9",
                    OptionC = "0 1 2 3 4 5 6 7 8 9",
                    OptionD = "1 2 3 4 5",
                    CorrectAnswer = "B",
                    Explanation = "Bangladesh Bank AD ICT 2025 — The continue statement skips even numbers, printing all odd numbers 1, 3, 5, 7, 9."
                },
                new() {
                    Category = "Data Structures & Algorithms", SubCategory = "Programming & Algorithms",
                    QuestionText = "In PHP, which of the following is used to concatenate strings?",
                    OptionA = "+",
                    OptionB = "&",
                    OptionC = ".",
                    OptionD = "%",
                    CorrectAnswer = "C",
                    Explanation = "Bangladesh Bank AME 2023 — The dot (.) operator is used for string concatenation in PHP."
                },
                new() {
                    Category = "Data Structures & Algorithms", SubCategory = "Programming & Algorithms",
                    QuestionText = "Which data type in Python is immutable?",
                    OptionA = "List",
                    OptionB = "Dictionary",
                    OptionC = "Tuple",
                    OptionD = "Set",
                    CorrectAnswer = "C",
                    Explanation = "Bangladesh Bank AME 2023 — Tuples and Strings are immutable sequences in Python."
                },
                new() {
                    Category = "Data Structures & Algorithms", SubCategory = "Programming & Algorithms",
                    QuestionText = "What will be the output of C code:\nint main() {\n  int x = 5;\n  printf(\"%d %d %d\", x, x++, ++x);\n  return 0;\n}",
                    OptionA = "7 6 7",
                    OptionB = "7 5 7",
                    OptionC = "Undefined / Compiler Dependent",
                    OptionD = "5 5 7",
                    CorrectAnswer = "C",
                    Explanation = "Bangladesh Bank AP 2023 — Modifying and reading variable without sequence point causes undefined behavior."
                },
                new() {
                    Category = "Data Structures & Algorithms", SubCategory = "Programming & Algorithms",
                    QuestionText = "Which of the following sorting algorithms has worst-case time complexity O(n log n)?",
                    OptionA = "Quick Sort",
                    OptionB = "Bubble Sort",
                    OptionC = "Merge Sort",
                    OptionD = "Insertion Sort",
                    CorrectAnswer = "C",
                    Explanation = "Bangladesh Bank AP 2016 — Merge Sort is guaranteed O(n log n) in all best, average, and worst cases."
                },
                new() {
                    Category = "Data Structures & Algorithms", SubCategory = "Programming & Algorithms",
                    QuestionText = "What is the output of C statement: `printf(\"%d\", sizeof('A'));` in standard C?",
                    OptionA = "1",
                    OptionB = "2",
                    OptionC = "4 (sizeof int)",
                    OptionD = "Compiler Error",
                    CorrectAnswer = "C",
                    Explanation = "Bangladesh Bank AP 2011 — In C, character constants like 'A' are of type int (size 4 bytes)."
                },
                #endregion

                #region 3. Hardware & Digital Logic
                new() {
                    Category = "Digital Logic & Architecture", SubCategory = "Hardware & Logic",
                    QuestionText = "What is the maximum addressable memory capacity of the Intel 8086 microprocessor with a 20-bit address bus?",
                    OptionA = "64 KB",
                    OptionB = "1 MB",
                    OptionC = "2 MB",
                    OptionD = "4 GB",
                    CorrectAnswer = "B",
                    Explanation = "Bangladesh Bank AD ICT 2025 — 2²⁰ bytes = 1,048,576 bytes = 1 MB."
                },
                new() {
                    Category = "Digital Logic & Architecture", SubCategory = "Hardware & Logic",
                    QuestionText = "NAND gate is called a universal gate because:",
                    OptionA = "It can perform any Boolean operation (AND, OR, NOT)",
                    OptionB = "It consumes less power",
                    OptionC = "It is faster than other gates",
                    OptionD = "It has only two inputs",
                    CorrectAnswer = "A",
                    Explanation = "Bangladesh Bank AD ICT 2025 — NAND and NOR are Universal Gates because any digital logic function can be synthesized using them alone."
                },
                new() {
                    Category = "Digital Logic & Architecture", SubCategory = "Hardware & Logic",
                    QuestionText = "Which device converts Alternating Current (AC) into Direct Current (DC)?",
                    OptionA = "Transformer",
                    OptionB = "Inverter",
                    OptionC = "Rectifier",
                    OptionD = "Oscillator",
                    CorrectAnswer = "C",
                    Explanation = "Bangladesh Bank AD ICT 2025 — Rectifier converts AC to DC; Inverter converts DC to AC."
                },
                new() {
                    Category = "Digital Logic & Architecture", SubCategory = "Hardware & Logic",
                    QuestionText = "A direct-mapped cache has 128 cache blocks. Memory address is 16 bits and each block is 8 bytes. What is the number of bits in the Tag field?",
                    OptionA = "5 bits",
                    OptionB = "6 bits",
                    OptionC = "7 bits",
                    OptionD = "8 bits",
                    CorrectAnswer = "B",
                    Explanation = "Bangladesh Bank AME 2023 — Block offset = log₂(8) = 3 bits; Line index = log₂(128) = 7 bits; Tag = 16 - (7 + 3) = 6 bits."
                },
                new() {
                    Category = "Digital Logic & Architecture", SubCategory = "Hardware & Logic",
                    QuestionText = "Which of the following memories is volatile?",
                    OptionA = "ROM",
                    OptionB = "EEPROM",
                    OptionC = "SRAM",
                    OptionD = "Flash",
                    CorrectAnswer = "C",
                    Explanation = "Bangladesh Bank AP 2016 — RAM (SRAM, DRAM) is volatile; contents are lost when power is turned off."
                },
                new() {
                    Category = "Digital Logic & Architecture", SubCategory = "Hardware & Logic",
                    QuestionText = "Which transistor region is used when it operates as an electronic switch in digital circuits?",
                    OptionA = "Active Region",
                    OptionB = "Cut-off and Saturation Regions",
                    OptionC = "Linear Region only",
                    OptionD = "Breakdown Region",
                    CorrectAnswer = "B",
                    Explanation = "Bangladesh Bank AME 2011 — In digital switching, Cut-off represents OFF state and Saturation represents ON state."
                },
                #endregion

                #region 4. Database & SQL
                new() {
                    Category = "Database & SQL", SubCategory = "Relational Database & SQL",
                    QuestionText = "A balance transfer fails midway after money is deducted from Account A but not credited to B. Which ACID property ensures it rolls back?",
                    OptionA = "Atomicity",
                    OptionB = "Consistency",
                    OptionC = "Isolation",
                    OptionD = "Durability",
                    CorrectAnswer = "A",
                    Explanation = "Bangladesh Bank AD ICT 2025 — Atomicity ensures 'All or Nothing'. If any part fails, the entire transaction is rolled back."
                },
                new() {
                    Category = "Database & SQL", SubCategory = "Relational Database & SQL",
                    QuestionText = "Which clause is evaluated first during the execution of an SQL query?",
                    OptionA = "WHERE",
                    OptionB = "SELECT",
                    OptionC = "FROM",
                    OptionD = "ORDER BY",
                    CorrectAnswer = "C",
                    Explanation = "Bangladesh Bank AD ICT 2025 — SQL Logical Processing Order: FROM → WHERE → GROUP BY → HAVING → SELECT → ORDER BY."
                },
                new() {
                    Category = "Database & SQL", SubCategory = "Relational Database & SQL",
                    QuestionText = "Which of the following is a DML (Data Manipulation Language) command?",
                    OptionA = "CREATE",
                    OptionB = "DELETE",
                    OptionC = "DROP",
                    OptionD = "ALTER",
                    CorrectAnswer = "B",
                    Explanation = "Bangladesh Bank AD ICT 2025 — INSERT, UPDATE, DELETE, MERGE are DML; CREATE, ALTER, DROP are DDL."
                },
                new() {
                    Category = "Database & SQL", SubCategory = "Relational Database & SQL",
                    QuestionText = "Which technique makes data retrieval from a database significantly faster?",
                    OptionA = "Indexing",
                    OptionB = "Normalization",
                    OptionC = "Denormalization",
                    OptionD = "Partitioning",
                    CorrectAnswer = "A",
                    Explanation = "Bangladesh Bank AD ICT 2025 — Database Indexing (e.g. B-Tree) provides fast lookup without scanning entire tables."
                },
                new() {
                    Category = "Database & SQL", SubCategory = "Relational Database & SQL",
                    QuestionText = "Where is Data Warehousing primarily used?",
                    OptionA = "Online Transaction Processing (OLTP)",
                    OptionB = "Decision Support Systems (DSS / OLAP)",
                    OptionC = "File Systems",
                    OptionD = "Network Routing",
                    CorrectAnswer = "B",
                    Explanation = "Bangladesh Bank AME 2023 — Data Warehouses are optimized for analytical querying and Decision Support Systems."
                },
                new() {
                    Category = "Database & SQL", SubCategory = "Relational Database & SQL",
                    QuestionText = "Table employee has 10 records with non-NULL, unique SALARY. What does this return:\nSELECT COUNT(*) FROM employee WHERE SALARY > ALL(SELECT SALARY FROM employee);",
                    OptionA = "10",
                    OptionB = "9",
                    OptionC = "1",
                    OptionD = "0",
                    CorrectAnswer = "D",
                    Explanation = "Bangladesh Bank AP 2023 — No salary can be strictly greater than ALL salaries including the maximum salary itself. Count is 0."
                },
                new() {
                    Category = "Database & SQL", SubCategory = "Relational Database & SQL",
                    QuestionText = "A row or record in a relational database table is formally called a:",
                    OptionA = "Relation",
                    OptionB = "Attribute",
                    OptionC = "Tuple",
                    OptionD = "Domain",
                    CorrectAnswer = "C",
                    Explanation = "Bangladesh Bank AP 2011 — In relational algebra, a row is called a Tuple and a column is an Attribute."
                },
                new() {
                    Category = "Database & SQL", SubCategory = "Relational Database & SQL",
                    QuestionText = "Which SQL keyword is used to eliminate duplicate rows in query results?",
                    OptionA = "UNIQUE",
                    OptionB = "DISTINCT",
                    OptionC = "DIFFERENT",
                    OptionD = "SINGLE",
                    CorrectAnswer = "B",
                    Explanation = "Bangladesh Bank AP 2011 — SELECT DISTINCT col FROM table returns only unique values."
                },
                #endregion

                #region 5. Cybersecurity
                new() {
                    Category = "Cybersecurity", SubCategory = "Information Security",
                    QuestionText = "Which encryption protocol is standard for securing emails in transit across servers?",
                    OptionA = "Symmetric Encryption (AES)",
                    OptionB = "TLS (Transport Layer Security)",
                    OptionC = "Hashing (SHA-256)",
                    OptionD = "Diffie-Hellman",
                    CorrectAnswer = "B",
                    Explanation = "Bangladesh Bank AD ICT 2025 — STARTTLS over SMTP/IMAP secures email transit using TLS."
                },
                new() {
                    Category = "Cybersecurity", SubCategory = "Information Security",
                    QuestionText = "Digital Signature commonly utilizes which asymmetric algorithm for signing?",
                    OptionA = "AES",
                    OptionB = "RSA",
                    OptionC = "DES",
                    OptionD = "Blowfish",
                    CorrectAnswer = "B",
                    Explanation = "Bangladesh Bank AD ICT 2025 — RSA and ECDSA are widely used for public key digital signatures."
                },
                new() {
                    Category = "Cybersecurity", SubCategory = "Information Security",
                    QuestionText = "Which algorithm is used in email security suites like S/MIME and PGP?",
                    OptionA = "AES",
                    OptionB = "RSA",
                    OptionC = "SHA",
                    OptionD = "All of the above",
                    CorrectAnswer = "D",
                    Explanation = "Bangladesh Bank AD ICT 2025 — Modern email security uses AES for message encryption, RSA for session key exchange, and SHA for message digest."
                },
                new() {
                    Category = "Cybersecurity", SubCategory = "Information Security",
                    QuestionText = "A computer virus is fundamentally classified as a:",
                    OptionA = "Hardware defect",
                    OptionB = "Malicious Program / Software",
                    OptionC = "Biological agent",
                    OptionD = "Network protocol",
                    CorrectAnswer = "B",
                    Explanation = "Bangladesh Bank AME 2011 — A computer virus is a self-replicating malicious program."
                },
                #endregion

                #region 6. Software Engineering & AI
                new() {
                    Category = "Software Engineering & OOP", SubCategory = "Software Engineering",
                    QuestionText = "What is the primary drawback of the traditional Waterfall Model?",
                    OptionA = "Difficult to document",
                    OptionB = "Inflexible and not suitable for changing requirements",
                    OptionC = "Requires too many developers",
                    OptionD = "Lacks structured phases",
                    CorrectAnswer = "B",
                    Explanation = "Bangladesh Bank AD ICT 2025 — Waterfall is rigid and sequential; changes in later phases are extremely costly."
                },
                new() {
                    Category = "Software Engineering & OOP", SubCategory = "Software Engineering",
                    QuestionText = "Integration testing primarily verifies the ________ between two or more software units.",
                    OptionA = "Performance",
                    OptionB = "Code style",
                    OptionC = "Interface and Communication",
                    OptionD = "Copyright compliance",
                    CorrectAnswer = "C",
                    Explanation = "Bangladesh Bank AD ICT 2025 — Integration testing tests data flow and interface interactions between modules."
                },
                new() {
                    Category = "Software Engineering & OOP", SubCategory = "Software Engineering",
                    QuestionText = "Which design pattern / representation is used to model hierarchical functional structure in software design?",
                    OptionA = "Structure Chart",
                    OptionB = "Data Flow Diagram (DFD)",
                    OptionC = "Entity Relationship Diagram (ERD)",
                    OptionD = "Use Case Diagram",
                    CorrectAnswer = "A",
                    Explanation = "Bangladesh Bank AP 2023 — Structure charts show module calling hierarchy and parameters."
                },
                #endregion

                #region 7. Data Structures
                new() {
                    Category = "Data Structures & Algorithms", SubCategory = "Data Structures",
                    QuestionText = "Which data structure provides the most optimal implementation for a Priority Queue?",
                    OptionA = "Binary Heap Tree",
                    OptionB = "Unsorted Array",
                    OptionC = "Singly Linked List",
                    OptionD = "Stack",
                    CorrectAnswer = "A",
                    Explanation = "Bangladesh Bank AD ICT 2025 — Binary Heap allows O(log n) insertion and extraction of min/max."
                },
                new() {
                    Category = "Data Structures & Algorithms", SubCategory = "Data Structures",
                    QuestionText = "What is the worst-case time complexity of inserting n elements into a Linked List while maintaining sorted order?",
                    OptionA = "Θ(n)",
                    OptionB = "Θ(n log n)",
                    OptionC = "Θ(n²)",
                    OptionD = "Θ(1)",
                    CorrectAnswer = "C",
                    Explanation = "Bangladesh Bank AD ICT 2025 — Each insertion takes O(k) steps; sum of 1+2+...+n = Θ(n²)."
                },
                new() {
                    Category = "Data Structures & Algorithms", SubCategory = "Data Structures",
                    QuestionText = "Which of the following is an application of the Stack data structure?",
                    OptionA = "Managing recursive function call frames",
                    OptionB = "Arithmetic expression evaluation (Infix to Postfix)",
                    OptionC = "The Stock Span problem",
                    OptionD = "All of the above",
                    CorrectAnswer = "D",
                    Explanation = "Bangladesh Bank AD ICT 2025 — Stacks are used in recursion call stacks, parsing expressions, backtracking, and monotone stack problems."
                },
                new() {
                    Category = "Data Structures & Algorithms", SubCategory = "Data Structures",
                    QuestionText = "Which of the following is a non-linear data structure?",
                    OptionA = "Array",
                    OptionB = "Graph",
                    OptionC = "Queue",
                    OptionD = "Linked List",
                    CorrectAnswer = "B",
                    Explanation = "Bangladesh Bank AP 2023 — Trees and Graphs are non-linear; Arrays, Linked Lists, Stacks, Queues are linear."
                },
                new() {
                    Category = "Data Structures & Algorithms", SubCategory = "Data Structures",
                    QuestionText = "Which data structure allows insertion and deletion from both ends?",
                    OptionA = "Deque (Double-Ended Queue)",
                    OptionB = "Priority Queue",
                    OptionC = "Circular Queue",
                    OptionD = "Stack",
                    CorrectAnswer = "A",
                    Explanation = "Bangladesh Bank AP 2023 — Deque allows push_front, pop_front, push_back, pop_back in O(1)."
                },
                new() {
                    Category = "Data Structures & Algorithms", SubCategory = "Data Structures",
                    QuestionText = "In a complete k-ary tree where every internal node has exactly k children, what is the number of leaves with n internal nodes?",
                    OptionA = "(n - 1)k + 1",
                    OptionB = "nk",
                    OptionC = "n(k - 1) + 1",
                    OptionD = "n(k - 1)",
                    CorrectAnswer = "C",
                    Explanation = "Bangladesh Bank AP 2023 — Total nodes L + n = k*n + 1 → Leaves L = n(k - 1) + 1."
                },
                #endregion

                #region 8. Operating Systems
                new() {
                    Category = "Operating System", SubCategory = "Basics",
                    QuestionText = "When a running process requests I/O operations, which state does it transition to?",
                    OptionA = "Ready",
                    OptionB = "Blocked / Waiting",
                    OptionC = "Terminated",
                    OptionD = "Suspended",
                    CorrectAnswer = "B",
                    Explanation = "Bangladesh Bank AD ICT 2025 — I/O requests move process from Running to Blocked/Waiting state until I/O completion."
                },
                new() {
                    Category = "Operating System", SubCategory = "Basics",
                    QuestionText = "When does a page fault interrupt occur in demand paging?",
                    OptionA = "When the requested page is already in physical memory",
                    OptionB = "When the requested page is NOT currently in physical RAM",
                    OptionC = "When a segmentation fault happens",
                    OptionD = "When the CPU clock speeds up",
                    CorrectAnswer = "B",
                    Explanation = "Bangladesh Bank AME 2023 — A page fault is triggered by MMU when valid bit in page table is 0 (page not in RAM)."
                },
                new() {
                    Category = "Operating System", SubCategory = "Basics",
                    QuestionText = "What is the primary benefit of multiprogramming operating systems?",
                    OptionA = "Executes more jobs in the same total time by keeping CPU busy",
                    OptionB = "Makes programming simpler",
                    OptionC = "Reduces memory size requirements",
                    OptionD = "Eliminates need for hardware interrupts",
                    CorrectAnswer = "A",
                    Explanation = "Bangladesh Bank AME 2011 — Multiprogramming maximizes CPU utilization by overlapping I/O and computation."
                },
                new() {
                    Category = "Operating System", SubCategory = "Basics",
                    QuestionText = "Which file extension traditionally indicates a configuration or initialization file in Windows?",
                    OptionA = ".TXT",
                    OptionB = ".INI",
                    OptionC = ".COM",
                    OptionD = ".BAK",
                    CorrectAnswer = "B",
                    Explanation = "Bangladesh Bank AME 2011 — .INI files contain configuration settings for operating system and programs."
                },
                #endregion

                #region 9. OOP Concepts
                new() {
                    Category = "Software Engineering & OOP", SubCategory = "OOP Concepts",
                    QuestionText = "Which of the following practices violates the principle of Encapsulation?",
                    OptionA = "Using private access modifiers for fields",
                    OptionB = "Providing getter and setter methods",
                    OptionC = "Using public global variables directly across modules",
                    OptionD = "Encapsulating state within class methods",
                    CorrectAnswer = "C",
                    Explanation = "Bangladesh Bank AD ICT 2025 — Global variables allow uncontrolled external modification, breaking encapsulation."
                },
                new() {
                    Category = "Software Engineering & OOP", SubCategory = "OOP Concepts",
                    QuestionText = "Which C++ operator is preferred to overload as a non-member friend function rather than a member function?",
                    OptionA = "Stream Insertion Operator (<<)",
                    OptionB = "Assignment Operator (=)",
                    OptionC = "Subscript Operator ([])",
                    OptionD = "Function Call Operator (())",
                    CorrectAnswer = "A",
                    Explanation = "Bangladesh Bank AD ICT 2025 — Overloading `std::ostream& operator<<(std::ostream&, const Obj&)` requires stream on left-hand side."
                },
                new() {
                    Category = "Software Engineering & OOP", SubCategory = "OOP Concepts",
                    QuestionText = "Which of the following operators CANNOT be overloaded in C++?",
                    OptionA = "Member Access operator (.) and Scope Resolution (::)",
                    OptionB = "Bitwise Right Shift (>>)",
                    OptionC = "Address of (&)",
                    OptionD = "Indirection (*)",
                    CorrectAnswer = "A",
                    Explanation = "Bangladesh Bank AP 2023 — Operators that cannot be overloaded: `.` (dot), `.*`, `::`, `?:` (ternary), `sizeof`."
                },
                new() {
                    Category = "Software Engineering & OOP", SubCategory = "OOP Concepts",
                    QuestionText = "What error exists in constructor definition: `public int BankAccount() { balance = 0; }`?",
                    OptionA = "Invalid name",
                    OptionB = "Constructors cannot have a return type (not even int)",
                    OptionC = "Missing parameters",
                    OptionD = "Balance must be static",
                    CorrectAnswer = "B",
                    Explanation = "Bangladesh Bank AP 2011 — In OOP (C++, Java, C#), constructors do not have any return type."
                },
                #endregion

                #region 10. Cloud & Virtualization
                new() {
                    Category = "Operating System", SubCategory = "Cloud & Virtualization",
                    QuestionText = "Which cloud service model provides a development and deployment environment (runtimes, databases, OS) for developers?",
                    OptionA = "IaaS",
                    OptionB = "PaaS",
                    OptionC = "SaaS",
                    OptionD = "BaaS",
                    CorrectAnswer = "B",
                    Explanation = "Bangladesh Bank AME 2023 — PaaS (Platform as a Service) gives developers environments to build apps without managing infrastructure."
                },
                new() {
                    Category = "Operating System", SubCategory = "Cloud & Virtualization",
                    QuestionText = "Which cloud computing concept enables pooling and sharing physical hardware resources among multiple tenants?",
                    OptionA = "Virtualization",
                    OptionB = "Polymorphism",
                    OptionC = "Abstraction",
                    OptionD = "Modulation",
                    CorrectAnswer = "A",
                    Explanation = "Bangladesh Bank AME 2023 — Virtualization abstracts physical hardware into virtual instances for multitenancy."
                },
                new() {
                    Category = "Operating System", SubCategory = "Cloud & Virtualization",
                    QuestionText = "Which cloud delivery model focuses directly on raw computing, storage, and networking hardware resources?",
                    OptionA = "IaaS (Infrastructure as a Service)",
                    OptionB = "PaaS",
                    OptionC = "SaaS",
                    OptionD = "DaaS",
                    CorrectAnswer = "A",
                    Explanation = "Bangladesh Bank AME 2023 — IaaS provides fundamental compute, storage, and networking building blocks."
                },
                #endregion

                #region 11. Math & Number Systems
                new() {
                    Category = "Digital Logic & Architecture", SubCategory = "Number Systems & Math",
                    QuestionText = "What is the 2's complement of the hexadecimal number (65)₁₆ in 8-bit binary?",
                    OptionA = "10011011",
                    OptionB = "10011010",
                    OptionC = "00011011",
                    OptionD = "10011100",
                    CorrectAnswer = "A",
                    Explanation = "Bangladesh Bank AD ICT 2025 — (65)₁₆ = 01100101₂. 1's complement = 10011010₂. Adding 1 → 10011011₂."
                },
                new() {
                    Category = "Digital Logic & Architecture", SubCategory = "Number Systems & Math",
                    QuestionText = "Pipe A fills a tank in 4 hours, and Pipe B fills it in 6 hours. Working together, how many hours do they take?",
                    OptionA = "5.0 hours",
                    OptionB = "4.5 hours",
                    OptionC = "2.4 hours",
                    OptionD = "2.0 hours",
                    CorrectAnswer = "C",
                    Explanation = "Bangladesh Bank AD ICT 2025 — Combined rate = 1/4 + 1/6 = 5/12 per hour. Time = 12/5 = 2.4 hours."
                },
                new() {
                    Category = "Digital Logic & Architecture", SubCategory = "Number Systems & Math",
                    QuestionText = "A walked 5m North, 3m East, then 2m South. What is the straight-line distance from start to finish?",
                    OptionA = "4.24 meters",
                    OptionB = "5.24 meters",
                    OptionC = "3.24 meters",
                    OptionD = "6.00 meters",
                    CorrectAnswer = "A",
                    Explanation = "Bangladesh Bank AD ICT 2025 — Net displacement: North = 5-2 = 3m, East = 3m. Distance = √(3² + 3²) = √18 ≈ 4.24m."
                },
                new() {
                    Category = "Digital Logic & Architecture", SubCategory = "Number Systems & Math",
                    QuestionText = "What is the greatest negative number that can be stored in an 8-bit computer using 2's complement representation?",
                    OptionA = "-127",
                    OptionB = "-128",
                    OptionC = "-255",
                    OptionD = "-256",
                    CorrectAnswer = "B",
                    Explanation = "Bangladesh Bank AME 2023 — 8-bit signed range in 2's complement is -2⁷ to +2⁷-1 = -128 to +127."
                },
                new() {
                    Category = "Digital Logic & Architecture", SubCategory = "Number Systems & Math",
                    QuestionText = "Evaluate the expression: 3²⁰ + 3²⁰ + 3²⁰ = ?",
                    OptionA = "3²⁰",
                    OptionB = "3²¹",
                    OptionC = "9⁶⁰",
                    OptionD = "3⁶⁰",
                    CorrectAnswer = "B",
                    Explanation = "Bangladesh Bank AME 2023 — 3*(3²⁰) = 3¹ * 3²⁰ = 3²¹."
                },
                new() {
                    Category = "Digital Logic & Architecture", SubCategory = "Number Systems & Math",
                    QuestionText = "If the radius of a circle is increased by 100%, by what percentage does the area increase?",
                    OptionA = "100%",
                    OptionB = "200%",
                    OptionC = "300%",
                    OptionD = "400%",
                    CorrectAnswer = "C",
                    Explanation = "Bangladesh Bank AP 2023 — New radius r' = 2r. New Area = π(2r)² = 4πr² = 4A. Increase = (4A - A)/A = 300%."
                },
                #endregion

                #region 12. General Knowledge
                new() {
                    Category = "General Knowledge & Analytical", SubCategory = "General Knowledge",
                    QuestionText = "Which two seas are directly connected by the Suez Canal?",
                    OptionA = "Arabian Sea and Mediterranean Sea",
                    OptionB = "Mediterranean Sea and Red Sea",
                    OptionC = "Black Sea and Caspian Sea",
                    OptionD = "Persian Gulf and Red Sea",
                    CorrectAnswer = "B",
                    Explanation = "Bangladesh Bank AD ICT 2025 — The Suez Canal in Egypt connects the Mediterranean Sea to the Red Sea."
                },
                new() {
                    Category = "General Knowledge & Analytical", SubCategory = "General Knowledge",
                    QuestionText = "Who was the winning captain of the first-ever ICC Men's Cricket World Cup in 1975?",
                    OptionA = "Clive Lloyd",
                    OptionB = "Kapil Dev",
                    OptionC = "Allan Border",
                    OptionD = "Ian Chappell",
                    CorrectAnswer = "A",
                    Explanation = "Bangladesh Bank AD ICT 2025 — Clive Lloyd led West Indies to win the inaugural 1975 Cricket World Cup."
                },
                new() {
                    Category = "General Knowledge & Analytical", SubCategory = "General Knowledge",
                    QuestionText = "Which organization won the Nobel Peace Prize in 2024?",
                    OptionA = "Nihon Hidankyo",
                    OptionB = "World Food Programme",
                    OptionC = "Memorial",
                    OptionD = "Doctors Without Borders",
                    CorrectAnswer = "A",
                    Explanation = "Bangladesh Bank AD ICT 2025 — Nihon Hidankyo (Japanese atomic bomb survivors group) won the 2024 Nobel Peace Prize."
                },
                new() {
                    Category = "General Knowledge & Analytical", SubCategory = "General Knowledge",
                    QuestionText = "What is the highest geographical peak in Bangladesh?",
                    OptionA = "Tajingdong (Bijoy)",
                    OptionB = "Keokradong",
                    OptionC = "Saka Haphong (Mowdok Mual)",
                    OptionD = "Dumlong",
                    CorrectAnswer = "C",
                    Explanation = "Bangladesh Bank AD ICT 2025 — Saka Haphong (1,052m / 3,451 ft) in Bandarban is the highest peak in Bangladesh."
                },
                new() {
                    Category = "General Knowledge & Analytical", SubCategory = "General Knowledge",
                    QuestionText = "On which date is World Environment Day celebrated globally every year?",
                    OptionA = "5th June",
                    OptionB = "22nd April",
                    OptionC = "21st March",
                    OptionD = "1st December",
                    CorrectAnswer = "A",
                    Explanation = "Bangladesh Bank AP 2023 — June 5 was established as World Environment Day by the UN in 1972."
                }
                #endregion
            };
        }
    }
}

