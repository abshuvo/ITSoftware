using ITSoftware.Models;

namespace ITSoftware.Services
{
    public static partial class McqQuestionSeeder
    {
        public static List<McqQuestion> GetOsSyncQuestions()
        {
            const string cat = "Operating System";
            const string subCat = "Process Synchronization";
            return new List<McqQuestion>
            {
                #region Inter Process Communication (IPC)
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Inter Process Communication",
                    QuestionText = "What are the two fundamental architectural models for Inter-Process Communication (IPC)?",
                    OptionA = "Paging and Segmentation",
                    OptionB = "Shared Memory and Message Passing",
                    OptionC = "Monolithic and Microkernel",
                    OptionD = "Direct and Indirect addressing",
                    CorrectAnswer = "B",
                    Explanation = "Shared Memory (processes map common RAM region) and Message Passing (packets exchanged via kernel primitives) are the two core IPC models."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Inter Process Communication",
                    QuestionText = "What is the primary speed advantage of Shared Memory over Message Passing?",
                    OptionA = "Shared memory requires no CPU synchronization",
                    OptionB = "Once the shared memory region is mapped, data transfers occur at RAM speeds without kernel intervention or data copying",
                    OptionC = "Shared memory uses optical fiber links",
                    OptionD = "Shared memory cannot experience race conditions",
                    CorrectAnswer = "B",
                    Explanation = "Message passing requires system calls and copying buffers into kernel space; shared memory accesses memory directly without OS overhead."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Inter Process Communication",
                    QuestionText = "How does an anonymous Unix Pipe communicate between processes?",
                    OptionA = "Through persistent files saved on disk",
                    OptionB = "As a unidirectional byte stream in kernel memory between processes that share a common parent-child ancestry",
                    OptionC = "Through raw network Ethernet broadcasts",
                    OptionD = "Via Bluetooth sockets",
                    CorrectAnswer = "B",
                    Explanation = "Anonymous pipes provide unidirectional byte streams between related processes (e.g. parent and child created via fork)."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Inter Process Communication",
                    QuestionText = "How does a Named Pipe (FIFO) in Unix differ from an anonymous pipe?",
                    OptionA = "A Named Pipe has a path name in the file system, allowing unrelated processes on the same system to communicate",
                    OptionB = "A Named Pipe only transmits binary integers",
                    OptionC = "A Named Pipe works without RAM",
                    OptionD = "A Named Pipe cannot be written to",
                    CorrectAnswer = "A",
                    Explanation = "FIFOs exist as special files in the directory hierarchy and allow communication between any processes with appropriate file permissions."
                },
                #endregion

                #region Process Synchronization, Race Condition & Critical Section
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Process Synchronization",
                    QuestionText = "Why is Process Synchronization necessary in modern operating systems?",
                    OptionA = "To ensure all computers have the same time zone",
                    OptionB = "To ensure orderly execution of cooperating concurrent processes sharing a logical address space or data, preventing data inconsistency",
                    OptionC = "To compile programs in parallel",
                    OptionD = "To defragment swap partitions",
                    CorrectAnswer = "B",
                    Explanation = "Concurrent access to shared data may result in data inconsistency; synchronization maintains consistency among cooperating processes."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Race Condition",
                    QuestionText = "What is a Race Condition in concurrent programming?",
                    OptionA = "Two CPUs competing to reach the lowest power state",
                    OptionB = "A situation where multiple threads or processes access and manipulate shared data concurrently, and the final outcome depends on the particular order of execution",
                    OptionC = "A competition between processes to acquire the largest RAM partition",
                    OptionD = "A network bandwidth saturation event",
                    CorrectAnswer = "B",
                    Explanation = "Race conditions produce non-deterministic, buggy behavior when multiple execution paths read and write shared data without synchronization."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Critical Section",
                    QuestionText = "What is the Critical Section in a program?",
                    OptionA = "The section containing privileged kernel code",
                    OptionB = "A segment of code in which a process accesses and modifies shared resources (memory, tables, files) that must not be concurrently executed by more than one process",
                    OptionC = "The BIOS initialization routine",
                    OptionD = "The error-handling section of code",
                    CorrectAnswer = "B",
                    Explanation = "The critical section is the code region operating on shared state where mutual exclusion must be strictly enforced."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Solutions to Process Synchronization Problems",
                    QuestionText = "Which three conditions must ANY valid solution to the Critical Section problem satisfy?",
                    OptionA = "Atomicity, Consistency, and Durability",
                    OptionB = "Mutual Exclusion, Progress, and Bounded Waiting",
                    OptionC = "Throughput, Latency, and Scalability",
                    OptionD = "First-Fit, Best-Fit, and Worst-Fit",
                    CorrectAnswer = "B",
                    Explanation = "Mutual Exclusion ensures only one process enters at a time; Progress ensures deadlock freedom; Bounded Waiting guarantees freedom from starvation."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Solutions to Process Synchronization Problems",
                    QuestionText = "What does the 'Progress' requirement guarantee in the critical section problem?",
                    OptionA = "That the program finishes execution within 1 minute",
                    OptionB = "If no process is in its critical section and some processes wish to enter, only those not in their remainder section can participate in the decision, and selection cannot be postponed indefinitely",
                    OptionC = "That all processes run on the fastest CPU core",
                    OptionD = "That processes take turns in strict alternating order",
                    CorrectAnswer = "B",
                    Explanation = "Progress ensures that a process outside its critical/entry section cannot block other waiting processes, preventing deadlock."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Solutions to Process Synchronization Problems",
                    QuestionText = "What does 'Bounded Waiting' prevent?",
                    OptionA = "Deadlock between RAM chips",
                    OptionB = "Starvation (by setting a limit on how many times other processes can enter their critical sections after a process has requested entry)",
                    OptionC = "CPU overheating",
                    OptionD = "Stack overflow errors",
                    CorrectAnswer = "B",
                    Explanation = "Bounded waiting ensures that every requesting process will eventually enter its critical section without waiting indefinitely."
                },
                #endregion

                #region Peterson’s, Dekker’s & Bakery Algorithms
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Peterson’s Algorithm",
                    QuestionText = "In Peterson's Algorithm for two processes P0 and P1, which shared variables are used?",
                    OptionA = "int count and int mutex",
                    OptionB = "int turn and boolean flag[2]",
                    OptionC = "int ticket[N] and int choosing[N]",
                    OptionD = "sem_t sem1 and sem_t sem2",
                    CorrectAnswer = "B",
                    Explanation = "`flag[i] = true` indicates process $i$ wants to enter; `turn = j` gives priority to the other process, guaranteeing mutual exclusion and progress."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Peterson’s Algorithm",
                    QuestionText = "Why might Peterson's Algorithm fail to work as expected on modern multi-core microprocessors without memory barriers?",
                    OptionA = "Modern CPUs lack boolean data types",
                    OptionB = "Modern compilers and out-of-order processors may reorder independent memory reads and writes to optimize performance",
                    OptionC = "Operating systems disable two-process arrays",
                    OptionD = "Modern RAM only supports 64-bit atomic operations",
                    CorrectAnswer = "B",
                    Explanation = "Out-of-order execution violates the sequential consistency assumptions of software algorithms unless memory fences/barriers are inserted."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Dekker’s algorithm",
                    QuestionText = "What is Dekker's Algorithm?",
                    OptionA = "The first known provably correct software solution to the mutual exclusion problem for two processes",
                    OptionB = "A disk scheduling algorithm for optical drives",
                    OptionC = "A memory compaction algorithm",
                    OptionD = "A page replacement algorithm",
                    CorrectAnswer = "A",
                    Explanation = "Formulated by Dutch mathematician Th. J. Dekker (1965), it was the first algorithmic solution for 2-process mutual exclusion using shared memory."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Bakery Algorithm",
                    QuestionText = "What is Lamport's Bakery Algorithm designed for?",
                    OptionA = "Baking hardware silicon wafers",
                    OptionB = "Solving the critical section problem for N concurrent processes using customer ticket numbers analogous to a bakery",
                    OptionC = "Scheduling threads on dual-socket servers",
                    OptionD = "Memory compaction in virtual memory",
                    CorrectAnswer = "B",
                    Explanation = "Lamport's Bakery algorithm handles $N$ processes by assigning increasing ticket numbers; the process with the smallest ticket (with PID as tiebreaker) enters next."
                },
                #endregion

                #region Hardware-Based Solutions, Semaphores & Mutex
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Hardware Based Solutions",
                    QuestionText = "What is the Test-and-Set (TSL) instruction?",
                    OptionA = "A compiler testing flag",
                    OptionB = "An atomic hardware instruction that reads the contents of a memory word and updates it to true in a single, non-interruptible operation",
                    OptionC = "A network diagnostic command",
                    OptionD = "A register shifting instruction",
                    CorrectAnswer = "B",
                    Explanation = "Test-and-Set executes atomically in hardware, enabling simple, correct spinlock implementations."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Hardware Based Solutions",
                    QuestionText = "What is the Compare-And-Swap (CAS) atomic instruction?",
                    OptionA = "An instruction that swaps two files on disk",
                    OptionB = "An instruction that compares memory content with an expected value and, only if equal, writes a new value, returning the old value atomically",
                    OptionC = "An instruction that compares two CPU clock speeds",
                    OptionD = "A method for sorting arrays in L1 cache",
                    CorrectAnswer = "B",
                    Explanation = "CAS is the foundation for modern lock-free algorithms, atomically checking if a memory location was modified before applying updates."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Semaphores",
                    QuestionText = "What is a Semaphore as defined by Edsger Dijkstra?",
                    OptionA = "A hardware interrupt line",
                    OptionB = "An integer synchronization variable accessed exclusively through two atomic operations: wait() (P) and signal() (V)",
                    OptionC = "A dynamic array in the heap",
                    OptionD = "A network socket header",
                    CorrectAnswer = "B",
                    Explanation = "Dijkstra's semaphore is an integer manipulated solely via atomic `wait()` (proberen / test) and `signal()` (verhogen / increment)."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Semaphores",
                    QuestionText = "In a non-busy-waiting (blocking) implementation of a Semaphore, what happens when a process executes wait() and the semaphore value is <= 0?",
                    OptionA = "The process spins in a tight while-loop burning CPU cycles",
                    OptionB = "The process is placed on the waiting queue associated with the semaphore and suspended (block() system call), yielding the CPU",
                    OptionC = "The process is terminated by SIGKILL",
                    OptionD = "The semaphore value resets to 1",
                    CorrectAnswer = "B",
                    Explanation = "To avoid busy-waiting (spinning), the process blocks itself, transitioning to the waiting state until another process calls `signal()` to awaken it."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Mutex vs. Semaphore",
                    QuestionText = "What is the fundamental difference between a Mutex and a Binary Semaphore?",
                    OptionA = "A Mutex can hold any integer; a Binary Semaphore holds only 0 or 1",
                    OptionB = "Ownership: A Mutex has an owner concept (only the thread that acquired/locked it can release it), whereas a Semaphore can be signaled by any thread",
                    OptionC = "Semaphores are hardware; Mutexes are software",
                    OptionD = "There is no difference in any system",
                    CorrectAnswer = "B",
                    Explanation = "Mutex is a locking mechanism with thread ownership; Semaphore is a signaling mechanism (thread A can signal thread B) without ownership."
                },
                #endregion

                #region Monitors, Priority Inversion & Classical IPC Problems
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Monitors",
                    QuestionText = "What is a Monitor in programming languages (e.g. Java synchronized, C# lock)?",
                    OptionA = "A display screen driver",
                    OptionB = "A high-level synchronization construct that encapsulates shared data and procedures, ensuring that only one thread can be active within the monitor at any time",
                    OptionC = "A hardware logic analyzer",
                    OptionD = "A network traffic auditor",
                    CorrectAnswer = "B",
                    Explanation = "Monitors automate mutual exclusion by allowing only one thread at a time to execute inside any of its synchronized procedures."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Monitors",
                    QuestionText = "How do Condition Variables operate within a Monitor?",
                    OptionA = "Via read() and write()",
                    OptionB = "Via wait() (suspends calling thread until signaled) and signal() (resumes exactly one suspended thread)",
                    OptionC = "Via push() and pop()",
                    OptionD = "Via malloc() and free()",
                    CorrectAnswer = "B",
                    Explanation = "Condition variables allow threads to wait inside a monitor for specific conditions to become true without holding the monitor lock."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Priority Inversion",
                    QuestionText = "What is Priority Inversion?",
                    OptionA = "A higher-priority process is indirectly prevented from executing because it waits on a lock held by a lower-priority process, which is preempted by medium-priority processes",
                    OptionB = "CPU scheduler running backwards",
                    OptionC = "All processes assigned equal priority",
                    OptionD = "A hardware interrupt taking priority over a kernel trap",
                    CorrectAnswer = "A",
                    Explanation = "Famous for affecting the Mars Pathfinder mission: High-priority task waits on Low-priority task, while Medium-priority tasks starve both."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Priority Inversion",
                    QuestionText = "What protocol is commonly used to prevent Priority Inversion?",
                    OptionA = "Banker's Algorithm",
                    OptionB = "Priority Inheritance Protocol (the low-priority process holding the lock temporarily inherits the high priority of the waiting process)",
                    OptionC = "Round Robin Quantum Doubling",
                    OptionD = "First-Come, First-Served Dispatching",
                    CorrectAnswer = "B",
                    Explanation = "Under Priority Inheritance, the low-priority process holding the resource temporarily runs at the highest waiting priority until it releases the resource."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Classical IPC Problems",
                    QuestionText = "In the Bounded-Buffer (Producer-Consumer) problem with buffer size N, which semaphores are used?",
                    OptionA = "mutex = 1, empty = N, full = 0",
                    OptionB = "mutex = 0, empty = 0, full = N",
                    OptionC = "mutex = N, empty = 1, full = 1",
                    OptionD = "Only a single binary semaphore",
                    CorrectAnswer = "A",
                    Explanation = "`empty` tracks open buffer slots ($N$), `full` tracks filled slots ($0$), and `mutex` ($1$) enforces mutual exclusion on buffer modification."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Classical IPC Problems",
                    QuestionText = "In the Dining Philosophers Problem with 5 philosophers, what condition can lead to an immediate deadlock?",
                    OptionA = "If all philosophers think at the same time",
                    OptionB = "If all 5 philosophers become hungry simultaneously and each picks up their right-hand chopstick, waiting indefinitely for the left",
                    OptionC = "If one philosopher eats twice in a row",
                    OptionD = "If the table is made of metal",
                    CorrectAnswer = "B",
                    Explanation = "When each philosopher grabs one chopstick and waits for the neighbor's chopstick, a circular wait arises, causing deadlock."
                },
                #endregion

                #region Quiz: Process Synchronization in OS
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Quiz: Process Synchronization in OS",
                    QuestionText = "A counting semaphore S is initialized to 10. If 12 wait() operations and 7 signal() operations are executed on S, what is the final value of S?",
                    OptionA = "5",
                    OptionB = "0",
                    OptionC = "3",
                    OptionD = "-5",
                    CorrectAnswer = "A",
                    Explanation = "Initial value = 10. Net change = -12 (wait) + 7 (signal) = -5. Final value = 10 - 5 = 5."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Quiz: Process Synchronization in OS",
                    QuestionText = "What is a Spinlock and when is it appropriate to use?",
                    OptionA = "A lock where a thread busy-waits in a loop testing a condition; appropriate on multi-core systems when the lock is held for extremely short durations",
                    OptionB = "A physical lock on the server rack",
                    OptionC = "A lock used on single-core processors for long I/O operations",
                    OptionD = "A non-blocking database queue",
                    CorrectAnswer = "A",
                    Explanation = "Spinlocks avoid context-switch overhead when the expected wait time is shorter than two context switches on multiprocessor architectures."
                }
                #endregion
            };
        }
    }
}

