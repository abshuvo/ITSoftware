using ITSoftware.Models;

namespace ITSoftware.Services
{
    public static partial class McqQuestionSeeder
    {
        public static List<McqQuestion> GetOsThreadingQuestions()
        {
            const string cat = "Operating System";
            const string subCat = "Multithreading";
            return new List<McqQuestion>
            {
                #region Operating System | Thread
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Operating System | Thread",
                    QuestionText = "What is a Thread in an operating system?",
                    OptionA = "A physical copper wire inside the CPU bus",
                    OptionB = "A basic unit of CPU utilization (Lightweight Process) consisting of a thread ID, program counter, register set, and a stack",
                    OptionC = "An entire virtual memory page table",
                    OptionD = "A network packet sequence",
                    CorrectAnswer = "B",
                    Explanation = "A thread is an execution flow within a process. Multiple threads of the same process share code, data, and OS resources."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Operating System | Thread",
                    QuestionText = "Which of the following resources is strictly PRIVATE to an individual thread and NOT shared among peer threads of the same process?",
                    OptionA = "Text (code) segment",
                    OptionB = "Data segment and global variables",
                    OptionC = "Execution Stack and CPU Registers (including Program Counter)",
                    OptionD = "Open file descriptors and network sockets",
                    CorrectAnswer = "C",
                    Explanation = "Each thread must have its own private call stack (for local variables and function returns) and register state to execute independently."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Operating System | Thread",
                    QuestionText = "What is Thread-Local Storage (TLS)?",
                    OptionA = "A USB drive attached to a single thread",
                    OptionB = "A dedicated memory area where each thread has its own unique instance of a static/global variable throughout its execution",
                    OptionC = "L1 CPU cache partition",
                    OptionD = "Swap partition on an SSD",
                    CorrectAnswer = "B",
                    Explanation = "TLS provides thread-specific data instances across functions without passing parameters, useful in multi-threaded transaction systems."
                },
                #endregion

                #region User Level Vs Kernel Level threads
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "User Level Vs Kernel Level threads",
                    QuestionText = "What is the primary operational difference between User-Level Threads (ULT) and Kernel-Level Threads (KLT)?",
                    OptionA = "ULTs are managed entirely in user space by a thread library without kernel awareness; KLTs are directly recognized and scheduled by the OS kernel",
                    OptionB = "ULTs execute faster than hardware clock speed",
                    OptionC = "KLTs do not consume memory",
                    OptionD = "ULTs require administrator root permissions",
                    CorrectAnswer = "A",
                    Explanation = "ULT management is fast because it involves no kernel mode transitions; KLT management requires kernel intervention and system calls."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "User Level Vs Kernel Level threads",
                    QuestionText = "What is the major vulnerability/disadvantage of User-Level Threads (ULT)?",
                    OptionA = "High context switch overhead",
                    OptionB = "If any single thread makes a blocking system call (e.g. read()), the kernel blocks the ENTIRE process, halting all other threads in the process",
                    OptionC = "Inability to use heap memory",
                    OptionD = "They cannot run on 64-bit systems",
                    CorrectAnswer = "B",
                    Explanation = "Because the kernel only sees the process and not the user-level threads, one blocking I/O call suspends the whole process."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "User Level Vs Kernel Level threads",
                    QuestionText = "Can pure User-Level Threads (Many-to-One model) run in parallel on multiple physical CPU cores?",
                    OptionA = "Yes, they automatically distribute across all available cores",
                    OptionB = "No, because the kernel schedules only the single parent process onto one core at any given moment",
                    OptionC = "Yes, if hyper-threading is turned off",
                    OptionD = "Only if the application is written in Assembly",
                    CorrectAnswer = "B",
                    Explanation = "Since the kernel is oblivious to individual ULTs, it cannot schedule them across distinct hardware cores simultaneously."
                },
                #endregion

                #region Process-based and Thread-based Multitasking
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Process-based and Thread-based Multitasking",
                    QuestionText = "What distinguishes Process-based Multitasking from Thread-based Multitasking?",
                    OptionA = "Process multitasking allows concurrent execution of separate programs with isolated address spaces; Thread multitasking allows concurrent tasks within a single program sharing the same address space",
                    OptionB = "Process multitasking requires no CPU scheduler",
                    OptionC = "Thread multitasking is only available on supercomputers",
                    OptionD = "They are identical in implementation and cost",
                    CorrectAnswer = "A",
                    Explanation = "Processes are heavyweight with protected private memory; threads are lightweight execution units inside a common memory boundary."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Process-based and Thread-based Multitasking",
                    QuestionText = "Why is context switching between threads of the SAME process significantly faster than context switching between two distinct processes?",
                    OptionA = "Threads do not use CPU registers",
                    OptionB = "Thread switching does not require changing the virtual memory address space, page table pointers (CR3 register), or flushing the TLB cache",
                    OptionC = "Thread switching happens at compile time",
                    OptionD = "Process switching requires rebooting the motherboard",
                    CorrectAnswer = "B",
                    Explanation = "Switching threads preserves the existing page tables and warmed CPU cache; switching processes invalidates virtual address translations."
                },
                #endregion

                #region Multi threading models & Benefits
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Multi threading models",
                    QuestionText = "Which multithreading model maps each user-level thread directly to a corresponding kernel thread?",
                    OptionA = "Many-to-One Model",
                    OptionB = "One-to-One Model",
                    OptionC = "Many-to-Many Model",
                    OptionD = "Two-Level Model",
                    CorrectAnswer = "B",
                    Explanation = "The One-to-One model is standard in modern OS (Linux, Windows), allowing true multi-core hardware concurrency."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Multi threading models",
                    QuestionText = "What is the primary trade-off of the One-to-One multithreading model?",
                    OptionA = "Inability to perform I/O operations",
                    OptionB = "Creating a user thread requires creating a corresponding kernel thread, which consumes kernel memory and can degrade performance if too many threads are spawned",
                    OptionC = "Lack of true parallelism",
                    OptionD = "Blocking calls suspend the whole application",
                    CorrectAnswer = "B",
                    Explanation = "Because each thread allocates kernel data structures, creating thousands of threads can exhaust OS resources (leading to Thread Pools)."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Multi threading models",
                    QuestionText = "What characterizes the Many-to-Many multithreading model?",
                    OptionA = "Multiplexes many user-level threads to a smaller or equal number of kernel threads, allowing the developer to create arbitrary user threads while achieving multi-core concurrency",
                    OptionB = "One thread per computer on a network",
                    OptionC = "A model without kernel support",
                    OptionD = "A model designed solely for optical disc drives",
                    CorrectAnswer = "A",
                    Explanation = "Many-to-Many combines ULT efficiency with KLT multi-core scaling, though it is complex to implement in the kernel scheduler."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Benefits of Multithreading",
                    QuestionText = "What are the four primary benefits of Multithreading in software engineering?",
                    OptionA = "Compilation speed, binary compression, security encryption, and optical rendering",
                    OptionB = "Responsiveness, Resource Sharing, Economy (lower allocation/switching cost), and Scalability (multi-core architecture utilization)",
                    OptionC = "Elimination of race conditions, zero memory consumption, automated database indexing, and network routing",
                    OptionD = "Static typing, garbage collection, JIT compilation, and pointer arithmetic",
                    CorrectAnswer = "B",
                    Explanation = "Multithreading keeps interactive applications responsive, shares memory easily, costs less than processes, and scales across CPU cores."
                },
                #endregion

                #region Quiz: Multithreading
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Quiz: Multithreading",
                    QuestionText = "According to Amdahl's Law, if 40% of an application is inherently serial (S = 0.40), what is the maximum theoretical speedup achievable even with an infinite number of CPU cores?",
                    OptionA = "1.5x",
                    OptionB = "2.5x",
                    OptionC = "4.0x",
                    OptionD = "10.0x",
                    CorrectAnswer = "B",
                    Explanation = "Max Speedup = 1 / S = 1 / 0.40 = 2.5. Regardless of how many processor cores are added, speedup cannot exceed 2.5x."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Quiz: Multithreading",
                    QuestionText = "What is a Thread Pool and what problem does it solve?",
                    OptionA = "A physical coolant bath for multi-core CPUs",
                    OptionB = "A collection of pre-instantiated worker threads waiting for tasks, avoiding the latency and overhead of repeatedly creating and destroying threads dynamically",
                    OptionC = "A shared database connection cache",
                    OptionD = "A thread debugging utility",
                    CorrectAnswer = "B",
                    Explanation = "Thread pools bound the total number of concurrent threads to prevent resource exhaustion and eliminate thread creation latency."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Quiz: Multithreading",
                    QuestionText = "In Pthreads, which function is used to gracefully wait for the completion and termination of a target thread?",
                    OptionA = "pthread_wait()",
                    OptionB = "pthread_join()",
                    OptionC = "pthread_sleep()",
                    OptionD = "pthread_kill()",
                    CorrectAnswer = "B",
                    Explanation = "`pthread_join()` blocks the calling thread until the specified thread terminates, releasing its resources analogous to wait() for processes."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Quiz: Multithreading",
                    QuestionText = "What is the difference between Asynchronous and Deferred Thread Cancellation?",
                    OptionA = "Asynchronous terminates the target thread immediately; Deferred allows the thread to periodically check cancellation points to exit cleanly",
                    OptionB = "Asynchronous runs on Sundays; Deferred runs on Mondays",
                    OptionC = "Deferred cancellation aborts immediately without saving state",
                    OptionD = "There is no functional difference",
                    CorrectAnswer = "A",
                    Explanation = "Deferred cancellation is safer because it allows the target thread to clean up resources, locks, and heap pointers before exiting."
                }
                #endregion
            };
        }
    }
}

