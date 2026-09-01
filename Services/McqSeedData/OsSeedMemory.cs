using ITSoftware.Models;

namespace ITSoftware.Services
{
    public static partial class McqQuestionSeeder
    {
        public static List<McqQuestion> GetOsMemoryQuestions()
        {
            const string cat = "Operating System";
            const string subCat = "Memory Management";
            return new List<McqQuestion>
            {
                #region 1. Basics
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "1. Basics",
                    QuestionText = "How are standard computer memory units ordered from smallest to largest capacity?",
                    OptionA = "Bit -> Byte (8 bits) -> Kilobyte (KB) -> Megabyte (MB) -> Gigabyte (GB) -> Terabyte (TB) -> Petabyte (PB)",
                    OptionB = "Byte -> Bit -> Megabyte -> Kilobyte -> Terabyte",
                    OptionC = "Word -> Nibble -> Byte -> Bit",
                    OptionD = "Kilobyte -> Gigabyte -> Megabyte -> Terabyte",
                    CorrectAnswer = "A",
                    Explanation = "1 Byte = 8 bits, 1 KB = 1024 bytes (2^10), 1 MB = 1024 KB (2^20), 1 GB = 1024 MB (2^30), 1 TB = 1024 GB (2^40), 1 PB = 1024 TB (2^50)."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "1. Basics",
                    QuestionText = "What are the primary responsibilities of Memory Management in an operating system?",
                    OptionA = "Formatting hard drives and creating partitions",
                    OptionB = "Tracking allocated and free memory spaces, mapping logical addresses to physical RAM, managing swapping/paging, and ensuring process memory protection",
                    OptionC = "Calculating 3D graphics polygons",
                    OptionD = "Filtering incoming network packets on firewall ports",
                    CorrectAnswer = "B",
                    Explanation = "Memory management handles allocation, deallocation, address translation, isolation, and virtual memory extensions."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "1. Basics",
                    QuestionText = "What is the fundamental difference between a Logical (Virtual) Address and a Physical Address?",
                    OptionA = "Logical address is emitted by the CPU during program execution; Physical address is the actual hardware address loaded onto the memory bus to access RAM chips",
                    OptionB = "Logical address is 32-bit; physical address is 64-bit",
                    OptionC = "Logical address is stored on disk; physical address in registers",
                    OptionD = "There is no difference in modern hardware",
                    CorrectAnswer = "A",
                    Explanation = "The CPU generates logical addresses relative to a program's address space; the Memory Management Unit (MMU) translates them into physical RAM locations."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "1. Basics",
                    QuestionText = "What hardware component is responsible for translating logical/virtual addresses into physical memory addresses at runtime?",
                    OptionA = "Arithmetic Logic Unit (ALU)",
                    OptionB = "Memory Management Unit (MMU)",
                    OptionC = "Direct Memory Access (DMA) Controller",
                    OptionD = "Southbridge Chipset",
                    CorrectAnswer = "B",
                    Explanation = "The MMU contains the base/relocation registers and page tables that translate CPU addresses to bus addresses on every instruction."
                },
                #endregion

                #region 2. Contiguous Allocation
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "2. Contiguous Allocation",
                    QuestionText = "What is Internal Fragmentation?",
                    OptionA = "Free memory holes scattered across RAM that are too small to satisfy any request",
                    OptionB = "Unused memory space left inside a fixed-size allocated block or partition when the requested process size is smaller than the allocated partition size",
                    OptionC = "Bad sectors inside a hard disk platter",
                    OptionD = "Cache line corruption due to overheating",
                    CorrectAnswer = "B",
                    Explanation = "Internal fragmentation is wasted space within an allocated block (e.g. allocating a 4 KB page to a process requesting only 1 KB leaves 3 KB internal fragment)."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "2. Contiguous Allocation",
                    QuestionText = "What is External Fragmentation?",
                    OptionA = "Unused memory inside an allocated page frame",
                    OptionB = "Total free physical memory exists to satisfy a request, but it is broken up into many small non-contiguous holes, making it impossible to satisfy a contiguous allocation request",
                    OptionC = "Damaged external USB storage drives",
                    OptionD = "Memory stored in cloud servers",
                    CorrectAnswer = "B",
                    Explanation = "External fragmentation occurs in variable-partition systems when free memory becomes fragmented into dispersed slices."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "2. Contiguous Allocation",
                    QuestionText = "What is the Next Fit memory allocation algorithm?",
                    OptionA = "Always allocates the smallest hole",
                    OptionB = "Similar to First Fit, but instead of searching from the beginning of memory, it begins searching from the location of the last allocated block",
                    OptionC = "Allocates the largest available hole",
                    OptionD = "Allocates memory randomly",
                    CorrectAnswer = "B",
                    Explanation = "Next Fit continues scanning from where it left off, distributing allocations throughout memory, but often breaks up large holes at the end of memory."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "2. Contiguous Allocation",
                    QuestionText = "How does the Buddy System allocate memory?",
                    OptionA = "Allocates blocks in consecutive prime numbers",
                    OptionB = "Partitions memory into block sizes that are powers of 2 (e.g. 4KB, 8KB, 16KB); divides larger blocks into 'buddies' and coalesces adjacent free buddies upon deallocation",
                    OptionC = "Assigns memory based on process priority",
                    OptionD = "Stores all data in CPU registers",
                    CorrectAnswer = "B",
                    Explanation = "The Buddy System enables fast allocation and coalescing via power-of-two division, minimizing external fragmentation while accepting modest internal fragmentation."
                },
                #endregion

                #region 3. Non-Contiguous Allocation
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "3. Non-Contiguous Allocation",
                    QuestionText = "How does Paging eliminate External Fragmentation?",
                    OptionA = "By requiring all memory requests to be prime numbers",
                    OptionB = "By dividing logical memory into fixed-size Pages and physical memory into identical fixed-size Frames, allowing any logical page to be placed in ANY free physical frame",
                    OptionC = "By storing all processes on high-speed NVMe drives",
                    OptionD = "By disabling dynamic heap allocation",
                    CorrectAnswer = "B",
                    Explanation = "Because any frame can be assigned to any page regardless of physical contiguity, external fragmentation is completely eliminated."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "3. Non-Contiguous Allocation",
                    QuestionText = "A logical address in a paging architecture is split into which two components?",
                    OptionA = "Base address and Limit register",
                    OptionB = "Page Number (p) and Page Offset (d)",
                    OptionC = "Network ID and Host ID",
                    OptionD = "Cylinder and Sector",
                    CorrectAnswer = "B",
                    Explanation = "The high-order bits specify the Page Number ($p$) indexing the page table; the low-order bits specify the byte Offset ($d$) within that page."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "3. Non-Contiguous Allocation",
                    QuestionText = "Which flags/bits are typically found in a Page Table Entry (PTE)?",
                    OptionA = "Frame Number, Valid/Invalid bit, Protection/Permission bits (R/W/X), Reference bit, and Dirty (Modify) bit",
                    OptionB = "Process ID, user password, IP address",
                    OptionC = "Disk sector number, cylinder index, head number",
                    OptionD = "Cache tag, set index, coherence flag",
                    CorrectAnswer = "A",
                    Explanation = "A PTE stores the physical frame address alongside status bits (Valid=in RAM, Dirty=modified, Reference=accessed, Protection=permissions)."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "3. Non-Contiguous Allocation",
                    QuestionText = "What distinguishes Memory Segmentation from Paging?",
                    OptionA = "Paging is visible to the programmer; Segmentation is not",
                    OptionB = "Paging divides memory into fixed-size blocks (hardware-centric view); Segmentation divides memory into variable-sized logical units (user/programmer view like functions, arrays, stack)",
                    OptionC = "Segmentation requires an Inverted Page Table",
                    OptionD = "Paging does not use the MMU",
                    CorrectAnswer = "B",
                    Explanation = "Segmentation reflects the modular structure of programs (code, stack, heap, symbols), each having distinct logical lengths and permissions."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "3. Non-Contiguous Allocation",
                    QuestionText = "How do modern architectures (like Intel x86) implement Segmentation with Paging?",
                    OptionA = "Odd memory accesses use segmentation; even memory accesses use paging",
                    OptionB = "Logical addresses pass through segmentation unit producing a linear address, which then passes through paging unit producing the final physical address in RAM",
                    OptionC = "Segmentation is used for disk; Paging is used for RAM",
                    OptionD = "By running in 16-bit real mode",
                    CorrectAnswer = "B",
                    Explanation = "x86 translates: Logical Address (selector, offset) -> Linear Address (via Segment Descriptor) -> Physical Address (via Page Table)."
                },
                #endregion

                #region 4. Advanced Memory Concepts
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "4. Advanced Memory Concepts",
                    QuestionText = "What was the concept of Overlays in early memory management prior to virtual memory?",
                    OptionA = "Displaying text on top of graphical windows",
                    OptionB = "A manual programming technique where only the instructions and data needed at any given time were kept in memory, overwriting unused routines as execution progressed",
                    OptionC = "Dual-layer optical disc recording",
                    OptionD = "Swapping kernel threads into CPU registers",
                    CorrectAnswer = "B",
                    Explanation = "Overlays required programmers to manually structure large programs so that mutually exclusive modules loaded over each other in limited RAM."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "4. Advanced Memory Concepts",
                    QuestionText = "What is Virtual Memory?",
                    OptionA = "Memory provided by cloud hypervisors over the internet",
                    OptionB = "A memory management technique that creates an illusion of a very large address space, allowing processes to execute without being fully resident in physical RAM",
                    OptionC = "A software simulation of video GPU memory",
                    OptionD = "Read-Only Memory (ROM)",
                    CorrectAnswer = "B",
                    Explanation = "Virtual memory separates user logical memory from physical storage, enabling execution of programs larger than physical memory."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "4. Advanced Memory Concepts",
                    QuestionText = "What is Demand Paging?",
                    OptionA = "Loading all pages of a program into RAM before execution begins",
                    OptionB = "Loading a page into physical memory only when an instruction actually references it during execution (lazy evaluation)",
                    OptionC = "Writing all memory pages to disk every minute",
                    OptionD = "Paging memory across network routers",
                    CorrectAnswer = "B",
                    Explanation = "Demand paging brings pages into physical RAM on demand; pages never accessed are never loaded from backing store."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "4. Advanced Memory Concepts",
                    QuestionText = "What occurs when an executing program references a page marked as Invalid (Page Fault)?",
                    OptionA = "The CPU shuts down immediately",
                    OptionB = "The MMU raises a hardware trap to the OS; the OS validates the request, finds a free frame, reads the page from disk into RAM, updates the PTE to valid, and restarts the instruction",
                    OptionC = "The process is terminated by the compiler",
                    OptionD = "The instruction is skipped and execution proceeds",
                    CorrectAnswer = "B",
                    Explanation = "The OS handles the page fault transparently to the application: the trapped instruction is suspended, the missing page is fetched, and the instruction restarts."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "4. Advanced Memory Concepts",
                    QuestionText = "What is Swap Space on secondary storage?",
                    OptionA = "A dedicated disk partition or file used as an extension of physical RAM to hold pages evicted by the virtual memory manager",
                    OptionB = "A staging directory for web browser cookies",
                    OptionC = "A backup copy of the BIOS",
                    OptionD = "An unallocated partition table sector",
                    CorrectAnswer = "A",
                    Explanation = "Swap space provides backing storage for dirty or inactive virtual pages when physical memory demand exceeds installed RAM."
                },
                #endregion

                #region 5. Page Replacement & Thrashing
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "5. Page Replacement & Thrashing",
                    QuestionText = "What is Belady's Anomaly in page replacement algorithms?",
                    OptionA = "Page faults decreasing when memory size decreases",
                    OptionB = "The phenomenon where increasing the number of physical page frames results in an INCREASE in the number of page faults for certain algorithms (notably FIFO)",
                    OptionC = "A memory bus deadlock",
                    OptionD = "CPU cache overflowing into swap space",
                    CorrectAnswer = "B",
                    Explanation = "Discovered by Laszlo Belady (1966), FIFO can experience more page faults with more frames because it does not satisfy the inclusion property of Stack Algorithms."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "5. Page Replacement & Thrashing",
                    QuestionText = "Which page replacement algorithms are Stack Algorithms that are mathematically immune to Belady's Anomaly?",
                    OptionA = "First-In, First-Out (FIFO) and Random",
                    OptionB = "Least Recently Used (LRU) and Optimal (OPT / MIN)",
                    OptionC = "Second-Chance and Clock",
                    OptionD = "Most Frequently Used (MFU) and FIFO",
                    CorrectAnswer = "B",
                    Explanation = "For stack algorithms, the set of pages in $n$ frames is always a strict subset of pages in $n+1$ frames, making Belady's anomaly impossible."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "5. Page Replacement & Thrashing",
                    QuestionText = "How does the Second-Chance (Clock) Page Replacement Algorithm operate?",
                    OptionA = "It evicts pages based on the real-time wall clock hour",
                    OptionB = "It maintains a circular queue with a hand: inspects the Reference Bit; if 0, evicts page; if 1, clears bit to 0 and advances hand to give the page a second chance",
                    OptionC = "It replaces the oldest page regardless of reference bits",
                    OptionD = "It evicts all pages every 60 seconds",
                    CorrectAnswer = "B",
                    Explanation = "The Clock algorithm is a practical, low-overhead approximation of LRU using a single reference bit per frame in a circular buffer."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "5. Page Replacement & Thrashing",
                    QuestionText = "What is Thrashing in an operating system?",
                    OptionA = "A process running complex arithmetic at 100% CPU utilization",
                    OptionB = "A condition where the system spends more time servicing page faults and swapping pages in and out than executing useful application instructions, collapsing CPU utilization",
                    OptionC = "A continuous series of hardware bus parity errors",
                    OptionD = "Physical hard disk head collision",
                    CorrectAnswer = "B",
                    Explanation = "Thrashing occurs when the sum of all processes' active working sets exceeds physical RAM, causing constant page faulting and zero progress."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "5. Page Replacement & Thrashing",
                    QuestionText = "How does the Working Set Model based on Locality of Reference prevent Thrashing?",
                    OptionA = "By killing the process with the smallest PID",
                    OptionB = "By defining a working set window $\\Delta$ of recent page references; if the sum of all working sets exceeds total physical memory, the OS suspends a process to prevent thrashing",
                    OptionC = "By disabling demand paging",
                    OptionD = "By doubling the page size dynamically",
                    CorrectAnswer = "B",
                    Explanation = "Peter Denning's working set model allocates each process enough frames to satisfy its locality; if total demand exceeds capacity, a process is swapped out."
                },
                #endregion

                #region 6. Kernel & System-Level Concepts
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "6. Kernel & System-Level Concepts",
                    QuestionText = "What is the difference between the Buddy System and the Slab Allocator for allocating kernel memory?",
                    OptionA = "Buddy system is used on Windows; Slab allocator on macOS",
                    OptionB = "Buddy system allocates memory in powers of 2 (causing internal fragmentation for small objects); Slab allocator uses caches of pre-allocated, object-sized memory chunks, eliminating internal fragmentation",
                    OptionC = "Slab allocator only allocates memory for user space",
                    OptionD = "Buddy system does not support deallocation",
                    CorrectAnswer = "B",
                    Explanation = "The Slab allocator pre-allocates pools of frequently used kernel data structures (PCBs, file descriptors, semaphores), avoiding buddy-system rounding waste."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "6. Kernel & System-Level Concepts",
                    QuestionText = "What is Memory Interleaving in computer architecture?",
                    OptionA = "Storing half of a program on hard disk and half in RAM",
                    OptionB = "Dividing physical memory into independent memory banks accessed in parallel so that consecutive memory addresses are stored in different banks, increasing bus throughput",
                    OptionC = "Compressing memory using zlib",
                    OptionD = "Encrypting alternate memory bytes with AES",
                    CorrectAnswer = "B",
                    Explanation = "Low-order memory interleaving spreads contiguous addresses across multiple memory modules, allowing simultaneous parallel reads/writes."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "6. Kernel & System-Level Concepts",
                    QuestionText = "What is Operating System-Based Virtualization (Containerization, e.g. Docker, LXC)?",
                    OptionA = "Simulating physical motherboard hardware using hypervisors",
                    OptionB = "A virtualization method where the kernel allows multiple isolated user-space instances (containers) sharing the same host kernel via namespaces and cgroups",
                    OptionC = "Running Windows software inside an emulator without a CPU",
                    OptionD = "Executing code directly on a GPU",
                    CorrectAnswer = "B",
                    Explanation = "Containers share the host kernel while isolating processes, network, and file systems using Linux namespaces and control groups (cgroups), with near-zero overhead."
                },
                #endregion

                #region Quiz: Memory Management
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Quiz: Memory Management",
                    QuestionText = "If a 32-bit system has a page size of 4 KB (2^12 bytes), how many bits are used for the Page Offset (d) and how many bits for the Page Number (p)?",
                    OptionA = "Offset: 12 bits, Page Number: 20 bits",
                    OptionB = "Offset: 10 bits, Page Number: 22 bits",
                    OptionC = "Offset: 16 bits, Page Number: 16 bits",
                    OptionD = "Offset: 8 bits, Page Number: 24 bits",
                    CorrectAnswer = "A",
                    Explanation = "Page size 4 KB = 2^12 bytes -> 12 bits for offset. Remaining bits for page number = 32 - 12 = 20 bits (mapping 2^20 = 1,048,576 pages)."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Quiz: Memory Management",
                    QuestionText = "A system has a TLB access time of 20 ns and a main memory access time of 100 ns. If the TLB hit ratio is 80%, what is the Effective Memory Access Time (EMAT)?",
                    OptionA = "120 ns",
                    OptionB = "140 ns",
                    OptionC = "160 ns",
                    OptionD = "100 ns",
                    CorrectAnswer = "B",
                    Explanation = "TLB Hit: TLB + RAM = 20 + 100 = 120 ns. TLB Miss: TLB + 2*RAM = 20 + 200 = 220 ns. EMAT = 0.80 * 120 + 0.20 * 220 = 96 + 44 = 140 ns."
                }
                #endregion
            };
        }
    }
}

