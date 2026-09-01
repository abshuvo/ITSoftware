using ITSoftware.Models;

namespace ITSoftware.Services
{
    public static partial class McqQuestionSeeder
    {
        public static List<McqQuestion> GetOsBasicsQuestions()
        {
            const string cat = "Operating System";
            const string subCat = "Basics";
            return new List<McqQuestion>
            {
                #region Introduction
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Introduction",
                    QuestionText = "What is the primary definition and role of an Operating System (OS)?",
                    OptionA = "An application software designed for word processing and spreadsheet calculation",
                    OptionB = "A system software that acts as an intermediary between computer hardware and the user/applications, managing hardware resources",
                    OptionC = "A hardware microchip placed on the motherboard to speed up arithmetic operations",
                    OptionD = "A compiler that translates high-level source code into binary machine instructions",
                    CorrectAnswer = "B",
                    Explanation = "An OS is system software that manages computer hardware, software resources, and provides common services for computer programs."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Introduction",
                    QuestionText = "From the system's viewpoint, the Operating System is primarily viewed as a:",
                    OptionA = "Text editor",
                    OptionB = "Resource Allocator and Control Program",
                    OptionC = "Network routing packet analyzer",
                    OptionD = "Database management system",
                    CorrectAnswer = "B",
                    Explanation = "The OS acts as a resource allocator (allocating CPU, memory, I/O devices) and a control program (preventing errors and improper computer use)."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Introduction",
                    QuestionText = "What are the two primary, sometimes conflicting, goals of an Operating System?",
                    OptionA = "High cost and low power consumption",
                    OptionB = "Convenience (User-friendliness) and Efficiency (Optimal hardware utilization)",
                    OptionC = "Large binary footprint and backward compatibility",
                    OptionD = "Network isolation and strict batch processing",
                    CorrectAnswer = "B",
                    Explanation = "Mainframe/server OSs emphasize efficiency and resource utilization, whereas desktop/mobile OSs emphasize convenience and responsiveness."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Introduction",
                    QuestionText = "Which component of an operating system remains resident in main memory (RAM) at all times while the computer is running?",
                    OptionA = "Shell command-line interpreter",
                    OptionB = "Web browser",
                    OptionC = "Kernel",
                    OptionD = "Compilers and linkers",
                    CorrectAnswer = "C",
                    Explanation = "The kernel is the central core of an operating system that loads during boot and permanently resides in RAM to manage system resources."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Introduction",
                    QuestionText = "What is the primary motivation for Dual-Mode operation (User Mode vs Kernel Mode) in modern CPUs?",
                    OptionA = "To enable running two monitors simultaneously",
                    OptionB = "To protect the operating system and other users from errant or malicious programs by restricting direct hardware access",
                    OptionC = "To double the CPU clock frequency dynamically",
                    OptionD = "To allow 32-bit software to execute on 64-bit microprocessors",
                    CorrectAnswer = "B",
                    Explanation = "Dual mode ensures fault tolerance and security: user programs run in user mode with limited rights; the OS executes privileged instructions in kernel mode."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Introduction",
                    QuestionText = "Which hardware mechanism indicates the current execution mode of the processor?",
                    OptionA = "Program Counter (PC)",
                    OptionB = "Mode Bit in the CPU status/flags register (0 for Kernel Mode, 1 for User Mode)",
                    OptionC = "Instruction Register (IR)",
                    OptionD = "Memory Address Register (MAR)",
                    CorrectAnswer = "B",
                    Explanation = "A hardware mode bit indicates the current privilege level: mode bit 0 represents kernel/supervisor mode, and 1 represents user mode."
                },
                #endregion

                #region Types of OS
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Types of OS",
                    QuestionText = "In a Batch Operating System, how are jobs processed?",
                    OptionA = "Users interact directly with the computer in real time using a GUI",
                    OptionB = "Similar jobs with similar requirements are grouped into batches by an operator and executed sequentially without user interaction",
                    OptionC = "Each user receives a 10-millisecond time slice",
                    OptionD = "Jobs are distributed across autonomous networked computers",
                    CorrectAnswer = "B",
                    Explanation = "Batch systems group similar tasks into batches to keep the expensive CPU busy without requiring user interaction during job execution."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Types of OS",
                    QuestionText = "What is the primary objective of a Multiprogramming Operating System?",
                    OptionA = "To allow multiple users to play video games simultaneously",
                    OptionB = "To maximize CPU utilization by keeping multiple jobs in memory so that when one job waits for I/O, the CPU switches to another",
                    OptionC = "To execute a single program on multiple physical motherboards",
                    OptionD = "To eliminate the need for secondary storage",
                    CorrectAnswer = "B",
                    Explanation = "Multiprogramming keeps multiple processes in RAM simultaneously. While process A waits for disk/tape I/O, the OS dispatches process B to the CPU."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Types of OS",
                    QuestionText = "What is a Time-Sharing (Multitasking) Operating System?",
                    OptionA = "An OS where CPU time is divided into small time slices (quanta), switching rapidly among active users to provide interactive response",
                    OptionB = "A batch system running on solar power",
                    OptionC = "An OS that only executes jobs at predetermined hours of the day",
                    OptionD = "A system without any virtual memory",
                    CorrectAnswer = "A",
                    Explanation = "Time-sharing is a logical extension of multiprogramming where the CPU switches between multiple users so quickly that each user perceives dedicated access."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Types of OS",
                    QuestionText = "What distinguishes Multiprocessing from Multiprogramming?",
                    OptionA = "Multiprogramming requires two or more CPUs; multiprocessing requires only one CPU",
                    OptionB = "Multiprocessing uses two or more physical processors (CPUs) working simultaneously; multiprogramming interleaves programs on a single processor",
                    OptionC = "Multiprocessing does not support I/O operations",
                    OptionD = "They are identical concepts with different commercial names",
                    CorrectAnswer = "B",
                    Explanation = "Multiprogramming is interleaved software execution on 1 CPU; Multiprocessing is true physical hardware parallel execution across multiple CPUs/cores."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Types of OS",
                    QuestionText = "What is the defining characteristic of a Real-Time Operating System (RTOS)?",
                    OptionA = "It displays real-time 3D animations at 120 FPS",
                    OptionB = "Deterministic timeliness: strict constraints on the time required to respond to events and complete calculations",
                    OptionC = "It requires connection to an atomic clock server",
                    OptionD = "It has zero memory consumption",
                    CorrectAnswer = "B",
                    Explanation = "An RTOS guarantees processing within precise time boundaries. Correctness depends not only on the logical result, but also on the time it is produced."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Types of OS",
                    QuestionText = "What is the difference between a Hard Real-Time system and a Soft Real-Time system?",
                    OptionA = "Hard RTOS runs on silicon; soft RTOS runs on emulators",
                    OptionB = "In a Hard RTOS, missing a deadline results in total system catastrophe; in a Soft RTOS, missing a deadline only degrades quality of service",
                    OptionC = "Soft RTOS has faster clock speeds than Hard RTOS",
                    OptionD = "Hard RTOS does not support hardware interrupts",
                    CorrectAnswer = "B",
                    Explanation = "Hard RTOS (e.g. aircraft flight control, missile guidance, pacemakers) cannot tolerate missed deadlines. Soft RTOS (e.g. video streaming) tolerates occasional jitter."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Types of OS",
                    QuestionText = "What defines a Distributed Operating System (DOS)?",
                    OptionA = "An OS distributed on multiple floppy disks",
                    OptionB = "An OS managing multiple independent, networked computers such that they appear to users as a single coherent centralized system (loosely coupled)",
                    OptionC = "An OS designed specifically for distributed denial-of-service testing",
                    OptionD = "A peer-to-peer torrent client",
                    CorrectAnswer = "B",
                    Explanation = "In a distributed OS, autonomous computers communicate over communication lines, sharing compute and storage transparently as a single virtual system."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Types of OS",
                    QuestionText = "In Clustered Systems, how do multiple computers differ from general distributed systems?",
                    OptionA = "Clustered systems share physical storage (SAN/NAS) and are closely coupled on a high-speed LAN for high availability and fault tolerance",
                    OptionB = "Clustered computers cannot run Linux",
                    OptionC = "Clustered systems must have identical monitor resolutions",
                    OptionD = "Clustered systems do not use Ethernet",
                    CorrectAnswer = "A",
                    Explanation = "Clustering connects multiple nodes closely over high-speed networks, often sharing storage to provide continuous availability (failover) and parallel computing."
                },
                #endregion

                #region Kernel in OS
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Kernel in OS",
                    QuestionText = "What is a Monolithic Kernel?",
                    OptionA = "A kernel that provides zero abstraction over hardware",
                    OptionB = "An architecture where all major OS services (file system, virtual memory, device drivers, network protocols) run in a unified kernel address space",
                    OptionC = "A kernel that runs exclusively on single-core 8-bit microcontrollers",
                    OptionD = "A kernel divided into thousands of isolated user-space daemons",
                    CorrectAnswer = "B",
                    Explanation = "Monolithic kernels (e.g. traditional Unix, Linux) integrate all core OS components into one large kernel space, yielding high performance via direct function calls."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Kernel in OS",
                    QuestionText = "What is the primary design philosophy of a Microkernel (e.g. Mach, Minix, QNX)?",
                    OptionA = "Packing every conceivable utility into kernel space",
                    OptionB = "Stripping non-essential components from the kernel, running only minimal mechanisms (IPC, low-level memory, scheduling) in kernel mode while services run in user space",
                    OptionC = "Removing all device drivers from the computer completely",
                    OptionD = "Allowing user applications to execute privileged CPU instructions directly",
                    CorrectAnswer = "B",
                    Explanation = "Microkernels keep the kernel tiny for reliability and security. If a driver or file system crashes in user space, the core kernel remains unaffected."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Kernel in OS",
                    QuestionText = "What is the major performance trade-off associated with Microkernels compared to Monolithic kernels?",
                    OptionA = "Microkernels consume 100 times more disk space",
                    OptionB = "Microkernels suffer from performance overhead due to increased context switching and message-passing IPC between user-space servers",
                    OptionC = "Microkernels cannot handle multi-threaded programs",
                    OptionD = "Microkernels require liquid cooling for the CPU",
                    CorrectAnswer = "B",
                    Explanation = "Because OS components reside in separate user-space processes, requesting a file or network packet incurs frequent user-kernel-user context switches and IPC copying."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Kernel in OS",
                    QuestionText = "What is a Hybrid Kernel (as seen in Windows NT and macOS XNU)?",
                    OptionA = "A kernel that switches between Linux and Windows at runtime",
                    OptionB = "An architecture combining the modularity of a microkernel with the performance benefits of a monolithic kernel by running certain critical services in kernel space",
                    OptionC = "A kernel programmed half in Python and half in Assembly",
                    OptionD = "A kernel that executes without an MMU",
                    CorrectAnswer = "B",
                    Explanation = "Hybrid kernels use microkernel message-passing abstractions while keeping performance-critical drivers and graphic subsystems in kernel space."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Kernel in OS",
                    QuestionText = "What is an Exokernel architecture?",
                    OptionA = "A kernel with external USB storage as main memory",
                    OptionB = "A minimalist kernel that eliminates hardware abstractions, providing secure resource allocation and letting application-level Library OSs manage abstractions",
                    OptionC = "A web-based browser operating system",
                    OptionD = "An operating system running on external satellites",
                    CorrectAnswer = "B",
                    Explanation = "Exokernels (e.g. MIT Aegis/Nemesis) separate resource management from protection, enabling domain-specific applications (like databases) to bypass generic OS abstractions."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Kernel in OS",
                    QuestionText = "In a Layered Operating System architecture, how are interactions between layers governed?",
                    OptionA = "Any layer can arbitrarily modify variables in any other layer",
                    OptionB = "Each layer $N$ is built strictly on top of lower layer $N-1$, and can only invoke services and functions offered by lower-level layers",
                    OptionC = "Lower layers invoke methods of higher layers via callbacks exclusively",
                    OptionD = "All layers execute on distinct network nodes",
                    CorrectAnswer = "B",
                    Explanation = "Layered design enforces modularity: layer 0 is hardware, the highest layer is the user interface, and each intermediate layer interacts only with layers directly below it."
                },
                #endregion

                #region System Call
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "System Call",
                    QuestionText = "What is a System Call?",
                    OptionA = "An automated phone call made by the computer during hardware errors",
                    OptionB = "The programmatic interface provided by the OS kernel that allows user applications to request privileged services",
                    OptionC = "A network ping packet sent to a domain server",
                    OptionD = "A compiler optimization instruction",
                    CorrectAnswer = "B",
                    Explanation = "System calls (such as open, read, write, fork) are the bridge between user applications and the kernel's privileged operations."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "System Call",
                    QuestionText = "How does the CPU transition from User Mode to Kernel Mode when an application invokes a system call?",
                    OptionA = "By raising the CPU voltage",
                    OptionB = "Through a software interrupt or Trap instruction (e.g. `syscall`, `sysenter`, or `int 0x80`)",
                    OptionC = "By clearing all CPU registers to zero",
                    OptionD = "By rebooting the CPU pipeline",
                    CorrectAnswer = "B",
                    Explanation = "A trap or software interrupt causes hardware to switch the mode bit to 0 (kernel mode) and jump to the predefined System Call Handler in the kernel."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "System Call",
                    QuestionText = "Which of the following is an example of a Process Control system call in Unix/Linux?",
                    OptionA = "open()",
                    OptionB = "read()",
                    OptionC = "fork()",
                    OptionD = "ioctl()",
                    CorrectAnswer = "C",
                    Explanation = "`fork()`, `exec()`, `exit()`, and `wait()` belong to Process Control; `open()` and `read()` belong to File Management."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "System Call",
                    QuestionText = "How are parameters typically passed from user space to the OS during a system call?",
                    OptionA = "By passing parameters in CPU registers",
                    OptionB = "By storing parameters in a block/table in memory and passing the block's address in a register",
                    OptionC = "By pushing parameters onto the user program's execution stack",
                    OptionD = "All of the above techniques are valid depending on the architecture and parameter size",
                    CorrectAnswer = "D",
                    Explanation = "Registers are fastest for few parameters; memory blocks or stack pushes are used when parameters exceed available CPU registers."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "System Call",
                    QuestionText = "Why do application programmers usually write code using Application Programming Interfaces (APIs like POSIX or Win32) rather than invoking raw system calls directly?",
                    OptionA = "Raw system calls are illegal in open-source software",
                    OptionB = "APIs provide program portability across different OS implementations and simplify programming by wrapping complex low-level system call sequences",
                    OptionC = "APIs execute without requiring any CPU cycles",
                    OptionD = "Raw system calls only accept hexadecimal assembly strings",
                    CorrectAnswer = "B",
                    Explanation = "APIs (like the C standard library libc) provide cross-platform consistency, error handling, and simpler abstractions than raw hardware-dependent system calls."
                },
                #endregion

                #region System Initialization
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "System Initialization",
                    QuestionText = "What is the exact sequence of events that occurs when a computer is powered on?",
                    OptionA = "Kernel loads -> BIOS runs -> MBR reads -> POST tests",
                    OptionB = "Power On -> CPU executes reset vector in ROM -> BIOS/UEFI runs POST -> Bootloader loaded from MBR/EFI partition -> Kernel loaded into RAM -> Init/Systemd started",
                    OptionC = "User logs in -> Shell spawns -> BIOS executes -> Display turns on",
                    OptionD = "Disk partitions formatted -> CPU starts -> OS installs",
                    CorrectAnswer = "B",
                    Explanation = "Booting begins at the hardware reset vector executing BIOS/UEFI, performing POST, loading the bootloader, which loads the kernel, culminating in PID 1 init."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "System Initialization",
                    QuestionText = "What is the function of the Power-On Self-Test (POST) executed by the BIOS/UEFI firmware?",
                    OptionA = "To clean virus files from the hard disk",
                    OptionB = "To verify the integrity and correct operation of critical hardware components (RAM, CPU, motherboard chipset, keyboard, storage devices)",
                    OptionC = "To benchmark the GPU clock speed",
                    OptionD = "To establish an encrypted VPN connection",
                    CorrectAnswer = "B",
                    Explanation = "POST checks hardware health before attempting to boot. If a component (e.g. RAM or GPU) fails, audible beep codes or error codes are emitted."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "System Initialization",
                    QuestionText = "Where is the Master Boot Record (MBR) physically located on a traditional partitioned storage drive?",
                    OptionA = "At the very end of the disk drive",
                    OptionB = "In the very first sector of the drive (Cylinder 0, Head 0, Sector 1), occupying exactly 512 bytes",
                    OptionC = "Inside the CPU L1 cache",
                    OptionD = "In CMOS battery-backed SRAM",
                    CorrectAnswer = "B",
                    Explanation = "The MBR is the 512-byte first sector of a partitioned storage drive, containing bootstrap code (446 bytes) and the partition table (64 bytes)."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "System Initialization",
                    QuestionText = "What role does the Bootstrap Loader (e.g. GRUB, LILO, Windows Boot Manager) play during startup?",
                    OptionA = "It cleans dust from the CPU cooling fan",
                    OptionB = "It locates the OS kernel image on secondary storage, loads it into physical RAM, and transfers CPU control to the kernel entry point",
                    OptionC = "It formats the file system into NTFS",
                    OptionD = "It assigns IP addresses via DHCP",
                    CorrectAnswer = "B",
                    Explanation = "The bootstrap loader initializes minimal hardware, presents OS boot menus if configured, unpacks the kernel into memory, and jumps to kernel execution."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "System Initialization",
                    QuestionText = "In modern Linux systems, what is the first user-space process created by the kernel with Process ID (PID) 1?",
                    OptionA = "bash",
                    OptionB = "systemd (or traditional sysvinit)",
                    OptionC = "kswapd0",
                    OptionD = "cron",
                    CorrectAnswer = "B",
                    Explanation = "The kernel mounts the root filesystem and executes `/sbin/init` (usually symlinked to `systemd`), which adopts all orphaned processes and spawns all background daemons."
                }
                #endregion
            };
        }
    }
}

