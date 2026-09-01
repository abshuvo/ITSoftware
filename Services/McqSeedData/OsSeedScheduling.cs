using ITSoftware.Models;

namespace ITSoftware.Services
{
    public static partial class McqQuestionSeeder
    {
        public static List<McqQuestion> GetOsSchedulingQuestions()
        {
            const string cat = "Operating System";
            const string subCat = "Process Scheduling";
            return new List<McqQuestion>
            {
                #region Process Introduction
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Process Introduction",
                    QuestionText = "What is the fundamental distinction between a Program and a Process?",
                    OptionA = "A program is stored on a flash drive; a process is stored on an optical disc",
                    OptionB = "A program is a passive entity (executable file stored on disk), whereas a process is an active entity with a program counter and allocated resources in execution",
                    OptionC = "A program can execute on multiple cores; a process can execute on only one core",
                    OptionD = "There is no functional distinction; both are identical terms",
                    CorrectAnswer = "B",
                    Explanation = "A program is static code residing on disk; a process is an active instance of a program loaded in RAM with its execution context."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Process Introduction",
                    QuestionText = "Which segment of a process's memory layout contains the compiled machine code instructions?",
                    OptionA = "Stack segment",
                    OptionB = "Heap segment",
                    OptionC = "Text segment (Code segment)",
                    OptionD = "BSS segment",
                    CorrectAnswer = "C",
                    Explanation = "The Text segment contains the read-only executable instructions of the program, preventing accidental modification."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Process Introduction",
                    QuestionText = "What is stored in the Data Segment and BSS Segment of a process?",
                    OptionA = "Local function parameters and return addresses",
                    OptionB = "Initialized global/static variables in Data segment, and uninitialized global/static variables in BSS (Block Started by Symbol)",
                    OptionC = "Dynamic heap allocations requested via malloc()",
                    OptionD = "Kernel system call handlers",
                    CorrectAnswer = "B",
                    Explanation = "Data segment stores initialized global/static variables; BSS stores uninitialized global/static variables initialized to zero by the OS loader."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Process Introduction",
                    QuestionText = "In the memory layout of a process, in which directions do the Stack and the Heap grow toward each other?",
                    OptionA = "Both grow toward higher memory addresses",
                    OptionB = "Heap grows upward toward higher addresses; Stack grows downward toward lower addresses",
                    OptionC = "Stack grows upward; Heap grows downward",
                    OptionD = "Both grow statically without changing size",
                    CorrectAnswer = "B",
                    Explanation = "The heap expands upward from low addresses when memory is dynamically allocated; the stack expands downward from high addresses during function calls."
                },
                #endregion

                #region Process Control Block (PCB) & Process Table
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Process Control Block",
                    QuestionText = "What is a Process Control Block (PCB, also known as Task Descriptor)?",
                    OptionA = "A physical silicon chip on the motherboard that controls CPU buses",
                    OptionB = "A kernel data structure containing all information and metadata associated with a specific active process",
                    OptionC = "A file stored on the root directory containing source code",
                    OptionD = "A network packet containing routing headers",
                    CorrectAnswer = "B",
                    Explanation = "The PCB is the kernel's primary bookkeeping structure for a process, created at process start and deleted upon process termination."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Process Control Block",
                    QuestionText = "Which of the following information is NOT typically stored in the Process Control Block (PCB)?",
                    OptionA = "Process ID (PID) and Process State",
                    OptionB = "CPU Registers (Accumulators, Index registers, Stack Pointer) and Program Counter",
                    OptionC = "Memory management info (base/limit registers, page table pointers)",
                    OptionD = "The source code comments written by the programmer",
                    CorrectAnswer = "D",
                    Explanation = "The PCB contains runtime system metadata needed for scheduling, memory management, and context switching; comments are discarded by compilers."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Process Table",
                    QuestionText = "What is the Process Table in an operating system?",
                    OptionA = "A database table stored on the hard drive",
                    OptionB = "An array or linked list of Process Control Blocks (PCBs) maintained by the kernel representing all active processes in the system",
                    OptionC = "A schedule of employee shifts in an IT department",
                    OptionD = "The CPU interrupt vector table",
                    CorrectAnswer = "B",
                    Explanation = "The Process Table is maintained in kernel space, containing an entry for every process to track its PID, state, and pointers to its resources."
                },
                #endregion

                #region Process Management Introduction
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Process Management Introduction",
                    QuestionText = "What does the `fork()` system call return to the parent process upon successful execution in Unix?",
                    OptionA = "Zero (0)",
                    OptionB = "The Process ID (PID) of the newly created child process",
                    OptionC = "A negative integer (-1)",
                    OptionD = "The parent's own PID",
                    CorrectAnswer = "B",
                    Explanation = "In Unix, `fork()` returns the child's PID to the parent process, returns 0 to the child process, and returns -1 on failure."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Process Management Introduction",
                    QuestionText = "What happens when a process invokes the `exec()` system call family (e.g. `execve`, `execlp`)?",
                    OptionA = "A new child process is spawned concurrently",
                    OptionB = "The current process address space is completely replaced with a new program executable, retaining the original PID",
                    OptionC = "The process enters an infinite sleep state",
                    OptionD = "The process is converted into a kernel thread",
                    CorrectAnswer = "B",
                    Explanation = "`exec()` replaces the text, data, heap, and stack of the calling process with a new binary, but preserves the PID and open file descriptors (unless FD_CLOEXEC)."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Process Management Introduction",
                    QuestionText = "What is a Zombie Process (Defunct Process)?",
                    OptionA = "A process running on a remote botnet",
                    OptionB = "A process that has completed execution via exit(), but still has an entry in the process table because its parent has not yet read its exit status via wait()",
                    OptionC = "A process whose parent was killed, leaving it adopted by init",
                    OptionD = "A process consuming 100% CPU in an infinite loop",
                    CorrectAnswer = "B",
                    Explanation = "A zombie has released its memory and open files, but retains its PID and exit code in the process table until the parent invokes `wait()` to reap it."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Process Management Introduction",
                    QuestionText = "What is an Orphan Process in Unix/Linux?",
                    OptionA = "A process that has no threads",
                    OptionB = "A running child process whose parent process has terminated prematurely, causing it to be automatically adopted by `init` or `systemd` (PID 1)",
                    OptionC = "A process that has lost all network connectivity",
                    OptionD = "A process with UID 0",
                    CorrectAnswer = "B",
                    Explanation = "When a parent exits before its child, the child becomes an orphan; `init` (PID 1) adopts it and regularly calls `wait()` to reap it when it finishes."
                },
                #endregion

                #region Process States
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Process States",
                    QuestionText = "In the standard 5-State Process Model, what are the five canonical process states?",
                    OptionA = "Create, Compile, Link, Load, Execute",
                    OptionB = "New, Ready, Running, Waiting (Blocked), and Terminated",
                    OptionC = "User, Kernel, Guest, Hypervisor, Idle",
                    OptionD = "Draft, Staged, Committed, Pushed, Merged",
                    CorrectAnswer = "B",
                    Explanation = "The 5 canonical states are New (being created), Ready (waiting in RAM for CPU), Running (on CPU), Waiting/Blocked (waiting for I/O), and Terminated (done)."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Process States",
                    QuestionText = "What causes a process to transition from the Running state to the Waiting (Blocked) state?",
                    OptionA = "Expiration of its allocated Round Robin time slice",
                    OptionB = "An I/O request (e.g. reading from disk/keyboard) or waiting for an event/signal",
                    OptionC = "Being preempted by a higher priority process",
                    OptionD = "Normal program completion",
                    CorrectAnswer = "B",
                    Explanation = "A process transitions to Waiting/Blocked voluntarily when it issues an I/O request or waits for an event that cannot be immediately satisfied."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Process States",
                    QuestionText = "What causes a process to transition from the Running state to the Ready state?",
                    OptionA = "The occurrence of a timer interrupt indicating its time slice expired, or preemption by a higher-priority task",
                    OptionB = "Waiting for disk data to arrive",
                    OptionC = "Invoking the `exit()` system call",
                    OptionD = "Power failure on the motherboard",
                    CorrectAnswer = "A",
                    Explanation = "A timer interrupt or arrival of a higher priority process forces the CPU scheduler to preempt the currently running job back to the Ready queue."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Process States",
                    QuestionText = "In the 7-State Process Model, why are the 'Suspend Ready' and 'Suspend Blocked' states introduced?",
                    OptionA = "To handle GPU tasks",
                    OptionB = "To accommodate processes swapped out from main memory (RAM) to secondary disk storage due to insufficient RAM",
                    OptionC = "To manage processes running on battery power",
                    OptionD = "To isolate 32-bit processes from 64-bit processes",
                    CorrectAnswer = "B",
                    Explanation = "When physical RAM is overcommitted, the medium-term scheduler swaps processes out to disk, placing them into suspended states."
                },
                #endregion

                #region Process Scheduler & Dispatcher
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Process Scheduler",
                    QuestionText = "What is the primary role of the Long-Term Scheduler (Job Scheduler)?",
                    OptionA = "Assigning physical CPU registers to instructions",
                    OptionB = "Selecting processes from the disk job pool and loading them into main memory, thereby controlling the Degree of Multiprogramming",
                    OptionC = "Handling network packet collisions",
                    OptionD = "Switching CPU contexts every 10 milliseconds",
                    CorrectAnswer = "B",
                    Explanation = "The Long-Term Scheduler decides which jobs enter the system from disk storage, balancing I/O-bound and CPU-bound processes."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Process Scheduler",
                    QuestionText = "Which scheduler executes most frequently (every few milliseconds) to select which ready process executes on the CPU?",
                    OptionA = "Long-Term Scheduler",
                    OptionB = "Short-Term Scheduler (CPU Scheduler)",
                    OptionC = "Medium-Term Scheduler",
                    OptionD = "I/O Spooler",
                    CorrectAnswer = "B",
                    Explanation = "The Short-Term Scheduler runs frequently (every 10-100 ms) and must be fast to select the next process for the CPU from the Ready queue."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Process Scheduler",
                    QuestionText = "What is the primary responsibility of the Medium-Term Scheduler?",
                    OptionA = "Managing L2 cache hits",
                    OptionB = "Swapping processes out of RAM to disk when memory is exhausted, and swapping them back in later (Swapping)",
                    OptionC = "Generating compiler error messages",
                    OptionD = "Formatting partitions",
                    CorrectAnswer = "B",
                    Explanation = "The Medium-Term Scheduler removes processes temporarily from memory to reduce the degree of multiprogramming and free RAM."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Dispatcher vs scheduler",
                    QuestionText = "What is the fundamental difference between the Scheduler and the Dispatcher?",
                    OptionA = "The Scheduler selects which process should run; the Dispatcher is the mechanism that actually gives control of the CPU to the selected process",
                    OptionB = "The Scheduler is hardware; the Dispatcher is software",
                    OptionC = "The Dispatcher allocates memory; the Scheduler handles I/O",
                    OptionD = "They are synonymous terms for the exact same function",
                    CorrectAnswer = "A",
                    Explanation = "The Scheduler is the decision-maker (algorithm); the Dispatcher carries out the decision (context switch, switching to user mode, jumping to instruction)."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Dispatcher vs scheduler",
                    QuestionText = "What is Dispatch Latency?",
                    OptionA = "The time taken to write a sector to disk",
                    OptionB = "The time required for the dispatcher to stop one process, perform context switching, and start another process running",
                    OptionC = "The delay between typing a keyboard key and seeing it on screen",
                    OptionD = "The time to compile high-level code",
                    CorrectAnswer = "B",
                    Explanation = "Dispatch Latency is pure OS overhead during which no useful application computation is performed."
                },
                #endregion

                #region Preemptive vs Non-Preemptive Scheduling
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Preemptive vs Non-Preemptive",
                    QuestionText = "In Non-Preemptive Scheduling, when can the CPU be taken away from a running process?",
                    OptionA = "At any arbitrary clock cycle via timer interrupt",
                    OptionB = "Only when the process voluntarily releases the CPU (by terminating or requesting I/O)",
                    OptionC = "Whenever a higher priority process enters the ready queue",
                    OptionD = "Every 10 milliseconds automatically",
                    CorrectAnswer = "B",
                    Explanation = "In non-preemptive systems, once the CPU is allocated to a process, it keeps the CPU until it finishes or switches to the waiting state."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Preemptive vs Non-Preemptive",
                    QuestionText = "Which of the following process state transitions represents Preemptive scheduling?",
                    OptionA = "Running -> Waiting state (I/O request)",
                    OptionB = "Running -> Ready state (Timer interrupt expired)",
                    OptionC = "Running -> Terminated state",
                    OptionD = "New -> Ready state",
                    CorrectAnswer = "B",
                    Explanation = "Transitions 1 (Running->Waiting) and 4 (Terminated) are non-preemptive; transition 2 (Running->Ready) is preemptive."
                },
                #endregion

                #region CPU Scheduling Algorithms & Starvation/Aging
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "CPU Scheduling Algorithms",
                    QuestionText = "What is the Convoy Effect observed in First-Come, First-Served (FCFS) scheduling?",
                    OptionA = "All processes terminating simultaneously",
                    OptionB = "Many short, I/O-bound processes being forced to wait a long time behind one large CPU-heavy process at the front of the queue",
                    OptionC = "Memory bus running out of bandwidth",
                    OptionD = "Multiple CPUs competing for the same cache line",
                    CorrectAnswer = "B",
                    Explanation = "The convoy effect results in lower CPU and device utilization when small processes wait behind a massive CPU burst process."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "CPU Scheduling Algorithms",
                    QuestionText = "Which CPU scheduling algorithm is provably optimal in terms of minimizing average waiting time for a static set of processes?",
                    OptionA = "First-Come, First-Served (FCFS)",
                    OptionB = "Shortest Job First (SJF) / Shortest Remaining Time First (SRTF)",
                    OptionC = "Round Robin (RR)",
                    OptionD = "Priority Scheduling",
                    CorrectAnswer = "B",
                    Explanation = "SJF/SRTF achieves the lowest average waiting time because executing shorter bursts first reduces the wait for all subsequent jobs."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "CPU Scheduling Algorithms",
                    QuestionText = "What is the preemptive version of the Shortest Job First (SJF) scheduling algorithm called?",
                    OptionA = "Earliest Deadline First (EDF)",
                    OptionB = "Shortest Remaining Time First (SRTF)",
                    OptionC = "Priority Inheritance",
                    OptionD = "Round Robin with Aging",
                    CorrectAnswer = "B",
                    Explanation = "SRTF preempts the executing process whenever a newly arrived process has a remaining CPU burst shorter than the current process's remaining time."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Starvation and Aging",
                    QuestionText = "What is Starvation (Indefinite Blocking) in Priority Scheduling?",
                    OptionA = "A process running out of RAM",
                    OptionB = "A low-priority process remaining indefinitely in the ready queue because higher-priority processes continuously arrive and monopolize the CPU",
                    OptionC = "A hardware power failure",
                    OptionD = "A deadlock between file locks",
                    CorrectAnswer = "B",
                    Explanation = "Starvation happens when a process ready to run is perpetually bypassed in favor of higher-priority jobs."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Starvation and Aging",
                    QuestionText = "What is Aging in CPU scheduling?",
                    OptionA = "Gradually decreasing the clock frequency of older CPUs",
                    OptionB = "A technique of gradually increasing the scheduling priority of processes that wait in the system for long periods to prevent starvation",
                    OptionC = "Deleting files older than 30 days",
                    OptionD = "Replacing RAM modules after five years",
                    CorrectAnswer = "B",
                    Explanation = "Aging ensures fairness: if an old process waits long enough, its priority steadily climbs until it becomes the highest-priority job."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "CPU Scheduling Algorithms",
                    QuestionText = "In Round Robin (RR) scheduling, what is the consequence of choosing an excessively large Time Quantum?",
                    OptionA = "The algorithm degenerates into First-Come, First-Served (FCFS) behavior",
                    OptionB = "Context-switch overhead overwhelms the CPU",
                    OptionC = "Memory pages are permanently locked",
                    OptionD = "The system enters an immediate deadlock",
                    CorrectAnswer = "A",
                    Explanation = "If the quantum exceeds the longest CPU burst, every process runs to completion on its first turn, behaving identically to FCFS."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "CPU Scheduling Algorithms",
                    QuestionText = "What distinguishes a Multilevel Feedback Queue (MLFQ) from a basic Multilevel Queue?",
                    OptionA = "MLFQ allows processes to dynamically move between priority queues based on their observed CPU burst history (aging and demotion)",
                    OptionB = "MLFQ does not use priority levels",
                    OptionC = "MLFQ is strictly non-preemptive",
                    OptionD = "MLFQ can only execute batch scripts",
                    CorrectAnswer = "A",
                    Explanation = "In basic MLQ, queue assignments are permanent; MLFQ dynamically promotes waiting jobs (aging) and demotes CPU hogs to lower queues."
                },
                #endregion

                #region Quiz: CPU Scheduling
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Quiz: CPU Scheduling",
                    QuestionText = "Consider 3 processes P1 (Burst: 24 ms), P2 (Burst: 3 ms), P3 (Burst: 3 ms) arriving at time 0 in order P1, P2, P3. Under FCFS, what is the average waiting time?",
                    OptionA = "17 ms",
                    OptionB = "27 ms",
                    OptionC = "10 ms",
                    OptionD = "3 ms",
                    CorrectAnswer = "A",
                    Explanation = "P1 wait = 0; P2 wait = 24; P3 wait = 24 + 3 = 27. Total wait = 0 + 24 + 27 = 51. Average wait = 51 / 3 = 17 ms."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Quiz: CPU Scheduling",
                    QuestionText = "For the same processes (P1: 24 ms, P2: 3 ms, P3: 3 ms at time 0), if scheduled in order P2, P3, P1 (SJF order), what is the average waiting time?",
                    OptionA = "17 ms",
                    OptionB = "3 ms",
                    OptionC = "6 ms",
                    OptionD = "9 ms",
                    CorrectAnswer = "B",
                    Explanation = "P2 wait = 0; P3 wait = 3; P1 wait = 3 + 3 = 6. Total wait = 0 + 3 + 6 = 9. Average wait = 9 / 3 = 3 ms (demonstrating SJF optimality)."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Quiz: CPU Scheduling",
                    QuestionText = "How is Turnaround Time mathematically calculated for any process?",
                    OptionA = "Completion Time - Arrival Time",
                    OptionB = "Waiting Time + I/O Time",
                    OptionC = "Burst Time - Waiting Time",
                    OptionD = "Arrival Time + CPU Burst Time",
                    CorrectAnswer = "A",
                    Explanation = "Turnaround Time = Completion Time - Arrival Time = Waiting Time + Burst Time + I/O Time."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Quiz: CPU Scheduling",
                    QuestionText = "In exponential smoothing for predicting the next CPU burst (tau_{n+1} = alpha * t_n + (1 - alpha) * tau_n), what does setting alpha = 1 represent?",
                    OptionA = "The prediction relies entirely on the most recent actual burst t_n, ignoring all historical predictions",
                    OptionB = "The prediction remains fixed at tau_0 forever",
                    OptionC = "The prediction is completely randomized",
                    OptionD = "The algorithm switches to Round Robin",
                    CorrectAnswer = "A",
                    Explanation = "If alpha = 1, tau_{n+1} = t_n: only the most recent actual burst matters, ignoring older history."
                }
                #endregion
            };
        }
    }
}

