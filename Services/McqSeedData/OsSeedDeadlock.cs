using ITSoftware.Models;

namespace ITSoftware.Services
{
    public static partial class McqQuestionSeeder
    {
        public static List<McqQuestion> GetOsDeadlockQuestions()
        {
            const string cat = "Operating System";
            const string subCat = "Deadlock";
            return new List<McqQuestion>
            {
                #region Introduction & Coffman Conditions
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Introduction",
                    QuestionText = "What is a Deadlock in an operating system?",
                    OptionA = "A program that crashes due to a null pointer dereference",
                    OptionB = "A permanent blocking condition where every process in a set is waiting for an event or resource that can only be released by another process in the same set",
                    OptionC = "A hardware clock failure",
                    OptionD = "An operating system running out of swap space",
                    CorrectAnswer = "B",
                    Explanation = "In a deadlock, none of the processes in the set can proceed, release resources, or be awakened, permanently freezing progress."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Introduction",
                    QuestionText = "Which four conditions (Coffman Conditions) are simultaneously NECESSARY and SUFFICIENT for a deadlock to occur?",
                    OptionA = "First-Fit, Best-Fit, Worst-Fit, Next-Fit",
                    OptionB = "Mutual Exclusion, Hold and Wait, No Preemption, and Circular Wait",
                    OptionC = "Atomicity, Consistency, Isolation, Durability",
                    OptionD = "Paging, Segmentation, Swapping, Compaction",
                    CorrectAnswer = "B",
                    Explanation = "First formulated by Edward G. Coffman Jr. (1971), all four conditions must hold concurrently for a deadlock to arise."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Introduction",
                    QuestionText = "What does the 'Hold and Wait' condition state?",
                    OptionA = "The CPU waits for RAM to refresh",
                    OptionB = "A process must currently be holding at least one resource and simultaneously waiting to acquire additional resources held by other processes",
                    OptionC = "The user holds down a key on the keyboard",
                    OptionD = "Network packets are held in a router buffer",
                    CorrectAnswer = "B",
                    Explanation = "Hold and Wait requires that processes retain previously allocated resources while requesting new ones."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Introduction",
                    QuestionText = "What does the 'No Preemption' condition specify in deadlock theory?",
                    OptionA = "The CPU cannot use a timer quantum",
                    OptionB = "Resources cannot be forcibly confiscated from a process; they can only be released voluntarily by the process holding them after completing its task",
                    OptionC = "Threads cannot yield the CPU",
                    OptionD = "System calls cannot be interrupted",
                    CorrectAnswer = "B",
                    Explanation = "No preemption means allocated resources cannot be seized by the OS; they must be freed voluntarily by the holding process."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Introduction",
                    QuestionText = "What is Circular Wait?",
                    OptionA = "A circular ring buffer",
                    OptionB = "A closed chain of processes {P0, P1, ..., Pn} exists such that P0 waits for a resource held by P1, P1 waits for P2, and Pn waits for P0",
                    OptionC = "Round Robin CPU scheduling on a single core",
                    OptionD = "CPU repeatedly polling an I/O port",
                    CorrectAnswer = "B",
                    Explanation = "Circular wait represents an unresolvable loop of dependencies where every process waits on a resource held by the next process in the cycle."
                },
                #endregion

                #region Deadlock Handling & Deadlock Prevention
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Deadlock Handling",
                    QuestionText = "What are the four primary strategies for handling deadlocks?",
                    OptionA = "Ignore (Ostrich Algorithm), Deadlock Prevention, Deadlock Avoidance, and Deadlock Detection & Recovery",
                    OptionB = "Compile, Link, Load, Execute",
                    OptionC = "First-In First-Out, Shortest Job First, Round Robin, Priority",
                    OptionD = "Encryption, Decryption, Hashing, Salting",
                    CorrectAnswer = "A",
                    Explanation = "Operating systems can ignore the problem (Ostrich algorithm), prevent it structurally, avoid it dynamically via Banker's algorithm, or detect and recover."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Deadlock Handling",
                    QuestionText = "What is the Ostrich Algorithm in deadlock handling?",
                    OptionA = "A bird-inspired genetic algorithm for process scheduling",
                    OptionB = "Sticking one's head in the sand: ignoring the deadlock problem entirely on the assumption that deadlocks occur rarely and prevention is too costly",
                    OptionC = "An algorithm that terminates the longest running process",
                    OptionD = "A distributed consensus mechanism",
                    CorrectAnswer = "B",
                    Explanation = "Most modern general-purpose operating systems (Linux, Windows) use the Ostrich algorithm because the overhead of avoidance/prevention outweighs the rarity of deadlocks."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Deadlock Prevention",
                    QuestionText = "How does Deadlock Prevention differ fundamentally from Deadlock Avoidance?",
                    OptionA = "Prevention requires hardware support; Avoidance is software",
                    OptionB = "Prevention eliminates the possibility of deadlock by structurally ensuring that at least one of the 4 Coffman conditions can NEVER hold; Avoidance dynamically evaluates runtime safety",
                    OptionC = "Prevention is only used on mobile phones",
                    OptionD = "They are identical techniques",
                    CorrectAnswer = "B",
                    Explanation = "Prevention constraints system design to invalidate one of the 4 Coffman conditions; Avoidance uses dynamic runtime knowledge of process claims (e.g. Banker's)."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Deadlock Prevention",
                    QuestionText = "How can the 'Circular Wait' condition be effectively prevented in an operating system?",
                    OptionA = "By imposing a global linear ordering on all resource types and requiring that processes request resources in strictly increasing order",
                    OptionB = "By making all resources shareable",
                    OptionC = "By killing all processes every 10 minutes",
                    OptionD = "By converting all resources to read-only memory",
                    CorrectAnswer = "A",
                    Explanation = "Havender's linear ordering rule: if resources are assigned integer IDs and acquired in strictly ascending order, circular wait is mathematically impossible."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Deadlock Prevention",
                    QuestionText = "How can the 'Hold and Wait' condition be prevented?",
                    OptionA = "By requiring a process to request and be allocated all its necessary resources simultaneously before beginning execution, or release current resources before requesting new ones",
                    OptionB = "By allowing processes to hold unlimited resources",
                    OptionC = "By forcing processes to sleep after every instruction",
                    OptionD = "By disabling multi-programming",
                    CorrectAnswer = "A",
                    Explanation = "Requiring all resources upfront or requiring zero held resources before requesting prevents a process from holding while waiting."
                },
                #endregion

                #region Banker’s Algorithm for Deadlock Avoidance
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Banker’s Algorithm for Deadlock Avoidance",
                    QuestionText = "What is a 'Safe State' in deadlock avoidance?",
                    OptionA = "A state where no process is executing",
                    OptionB = "A state in which there exists at least one safe sequence <P1, P2, ..., Pn> such that every process can satisfy its maximum demand and finish without deadlocking",
                    OptionC = "A state where all resources are allocated simultaneously",
                    OptionD = "A state backed up by an uninterruptible power supply (UPS)",
                    CorrectAnswer = "B",
                    Explanation = "A state is safe if the OS can allocate resources to each process up to its declared maximum claim in some sequence without deadlocking."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Banker’s Algorithm for Deadlock Avoidance",
                    QuestionText = "What is the relationship between an Unsafe State and a Deadlock State?",
                    OptionA = "An unsafe state is always a deadlock state",
                    OptionB = "An unsafe state is NOT necessarily a deadlock state, but it may lead to a deadlock if processes request their maximum resource claims",
                    OptionC = "A deadlock state can occur within a safe state",
                    OptionD = "Unsafe states only occur in distributed databases",
                    CorrectAnswer = "B",
                    Explanation = "Safe states guarantee no deadlock; unsafe states represent risk where a deadlock cannot be prevented if worst-case requests occur."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Banker’s Algorithm for Deadlock Avoidance",
                    QuestionText = "In Dijkstra's Banker's Algorithm, how is the Need Matrix computed?",
                    OptionA = "Need[i, j] = Max[i, j] + Allocation[i, j]",
                    OptionB = "Need[i, j] = Max[i, j] - Allocation[i, j]",
                    OptionC = "Need[i, j] = Allocation[i, j] - Available[j]",
                    OptionD = "Need[i, j] = Max[i, j] * Available[j]",
                    CorrectAnswer = "B",
                    Explanation = "Need represents the remaining resources process i may still request: Need = Max - Allocation."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Banker’s Algorithm for Deadlock Avoidance",
                    QuestionText = "What is the time complexity of the safety algorithm in the Banker's Algorithm with n processes and m resource types?",
                    OptionA = "O(n)",
                    OptionB = "O(m * n^2)",
                    OptionC = "O(n!)",
                    OptionD = "O(m^2 * n)",
                    CorrectAnswer = "B",
                    Explanation = "In the worst case, finding a safe sequence requires checking n processes across n iterations, comparing m resource types: O(m * n^2)."
                },
                #endregion

                #region Detection, Recovery, Starvation & Livelock
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Detection And Recovery",
                    QuestionText = "For single-instance resource systems, which graph algorithm is used for Deadlock Detection?",
                    OptionA = "Kruskal's Minimum Spanning Tree",
                    OptionB = "Wait-For Graph cycle detection algorithm (O(n^2) cycle finding)",
                    OptionC = "Dijkstra's Shortest Path",
                    OptionD = "Floyd-Warshall",
                    CorrectAnswer = "B",
                    Explanation = "A Wait-For graph is created by removing resource nodes from a RAG: a directed cycle in a single-instance system directly indicates deadlock."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Detection And Recovery",
                    QuestionText = "What are the two general methods for Deadlock Recovery once a deadlock is detected?",
                    OptionA = "Process Termination (abort all or abort one-by-one) and Resource Preemption (preempt resource, rollback to checkpoint, select victim)",
                    OptionB = "Rebooting the CPU and formatting the hard drive",
                    OptionC = "Upgrading the RAM and overclocking the processor",
                    OptionD = "Disabling virtual memory and clearing cache",
                    CorrectAnswer = "A",
                    Explanation = "Recovery involves breaking the dependency cycle either by killing processes or preempting resources and rolling back to safe checkpoints."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Starvation, and Livelock",
                    QuestionText = "What is Livelock in concurrent systems, and how does it differ from Deadlock?",
                    OptionA = "In Deadlock, processes are executing at 100% CPU; in Livelock, processes sleep",
                    OptionB = "In Deadlock, processes are blocked waiting in sleep state; in Livelock, processes are actively executing instructions and changing states, but making no functional forward progress",
                    OptionC = "Livelock only occurs in hardware circuits",
                    OptionD = "Livelock is another name for paging thrashing",
                    CorrectAnswer = "B",
                    Explanation = "Livelock processes actively respond to each other (like two polite people trying to step aside in a narrow hallway), consuming CPU but making no progress."
                },
                #endregion

                #region Resource Allocation Graph (RAG) & Free Condition
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Resource Allocation Graph (RAG)",
                    QuestionText = "In a Resource-Allocation Graph (RAG), what does an edge directed from a Process node to a Resource node (P -> R) represent?",
                    OptionA = "Assignment Edge (Resource is allocated to Process)",
                    OptionB = "Request Edge (Process has requested an instance and is waiting)",
                    OptionC = "Claim Edge (Future request)",
                    OptionD = "Parent-Child process relationship",
                    CorrectAnswer = "B",
                    Explanation = "P -> R is a Request Edge; R -> P is an Assignment Edge (resource allocated to process)."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Resource Allocation Graph (RAG)",
                    QuestionText = "If a Resource-Allocation Graph contains a cycle, under what condition does it GUARANTEE that a deadlock exists?",
                    OptionA = "Only if each resource type in the graph has exactly ONE instance",
                    OptionB = "Only if each resource type has multiple instances",
                    OptionC = "A cycle always guarantees deadlock under all circumstances",
                    OptionD = "A cycle never implies deadlock",
                    CorrectAnswer = "A",
                    Explanation = "For single-instance resources, a cycle is both necessary and sufficient for deadlock. With multiple instances, a cycle is necessary but NOT sufficient."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Program for Deadlock free condition",
                    QuestionText = "If a system has m instances of a single resource type shared by n processes, and each process needs at most k instances, what condition guarantees that a deadlock CANNOT occur?",
                    OptionA = "m >= n * (k - 1) + 1",
                    OptionB = "m < n * k",
                    OptionC = "m = n + k",
                    OptionD = "m <= n",
                    CorrectAnswer = "A",
                    Explanation = "Worst-case allocation has each process holding (k-1) instances: total = n*(k-1). With 1 more instance (m >= n*(k-1) + 1), at least one process can finish."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Program for Deadlock free condition",
                    QuestionText = "Suppose 4 processes share a pool of identical magnetic tape drives, and each process requires at most 3 tape drives. What is the minimum number of tape drives required to guarantee the system is deadlock-free?",
                    OptionA = "8",
                    OptionB = "9",
                    OptionC = "12",
                    OptionD = "10",
                    CorrectAnswer = "B",
                    Explanation = "Using m >= n * (k - 1) + 1 with n = 4, k = 3: m >= 4 * (3 - 1) + 1 = 4 * 2 + 1 = 9 tape drives."
                },
                #endregion

                #region Quiz: Deadlock
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Quiz: Deadlock",
                    QuestionText = "A system has 3 processes (P0, P1, P2) and 10 units of a resource. Max needs: P0=7, P1=5, P2=3. Current allocations: P0=3, P1=3, P2=2. Available = 2. Is the system in a safe state?",
                    OptionA = "No, the system is deadlocked",
                    OptionB = "Yes, with safe execution sequence <P2, P1, P0>",
                    OptionC = "No, because no process can finish",
                    OptionD = "Yes, with safe execution sequence <P0, P1, P2>",
                    CorrectAnswer = "B",
                    Explanation = "Available=2. P2 need = 3-2 = 1 <= 2. P2 runs and releases 2, Available becomes 2+2=4. P1 need = 5-3 = 2 <= 4. P1 runs and releases 3, Available becomes 4+3=7. P0 need = 7-3 = 4 <= 7. All finish safely!"
                }
                #endregion
            };
        }
    }
}

