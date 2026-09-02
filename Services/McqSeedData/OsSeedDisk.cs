using ITSoftware.Models;

namespace ITSoftware.Services
{
    public static partial class McqQuestionSeeder
    {
        public static List<McqQuestion> GetOsDiskQuestions()
        {
            const string cat = "Operating System";
            const string subCat = "Disk Management";
            return new List<McqQuestion>
            {
                #region File Systems & Unix File System
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "File Systems",
                    QuestionText = "What is a File System in an operating system?",
                    OptionA = "A database of user passwords",
                    OptionB = "A method and data structure that the OS uses to control how data is stored, organized, named, and retrieved from secondary storage",
                    OptionC = "A hardware circuit inside the hard drive",
                    OptionD = "An application software for viewing PDF documents",
                    CorrectAnswer = "B",
                    Explanation = "The file system provides the persistent logical abstraction (files, directories) over raw physical sectors on secondary storage devices."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "File Systems",
                    QuestionText = "What is a File Control Block (FCB)?",
                    OptionA = "A storage hardware circuit",
                    OptionB = "A storage structure associated with a file containing file metadata (permissions, ownership, size, timestamps, and data block locations)",
                    OptionC = "A block containing the file's binary instructions exclusively",
                    OptionD = "The file's desktop icon",
                    CorrectAnswer = "B",
                    Explanation = "In Unix/Linux, the FCB is called an Inode; in Windows NTFS, it is stored in the Master File Table (MFT)."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Unix File System",
                    QuestionText = "What is an Inode (Index Node) in the Unix File System?",
                    OptionA = "A special hardware register in x86 CPUs",
                    OptionB = "A 128- or 256-byte data structure on disk that stores all metadata and data block pointers of a file EXCEPT its filename",
                    OptionC = "The root directory of an external USB drive",
                    OptionD = "A user account identifier",
                    CorrectAnswer = "B",
                    Explanation = "An inode contains permissions, owner, timestamps, file size, and pointers to disk blocks; the filename is maintained in directory entries."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Unix File System",
                    QuestionText = "Why does a Unix Inode NOT contain the filename of the file?",
                    OptionA = "Because Unix only supports numerical file names",
                    OptionB = "To allow multiple directory entries (Hard Links) in different directories to point to the exact same physical inode",
                    OptionC = "To encrypt file names automatically",
                    OptionD = "Because filenames are stored in the BIOS",
                    CorrectAnswer = "B",
                    Explanation = "Decoupling filenames from inodes allows hard links: two different names can point to the same inode without duplicating data blocks."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Unix File System",
                    QuestionText = "In a standard Unix Inode, how are block pointers arranged?",
                    OptionA = "12 Direct block pointers, 1 Single Indirect pointer, 1 Double Indirect pointer, and 1 Triple Indirect pointer",
                    OptionB = "1000 Direct pointers with no indirect blocks",
                    OptionC = "A single doubly-linked list of sectors",
                    OptionD = "A flat hash table of block numbers",
                    CorrectAnswer = "A",
                    Explanation = "Direct pointers provide fast access for small files; single, double, and triple indirect pointers allow files to scale into gigabytes/terabytes."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Unix File System",
                    QuestionText = "What is the difference between a Hard Link and a Symbolic (Soft) Link in Unix?",
                    OptionA = "A hard link is physical copper wire; soft link is wireless",
                    OptionB = "A hard link points directly to the target file's Inode number (cannot span across different file systems); a soft link is an independent file containing the pathname string of target file (can span file systems)",
                    OptionC = "Soft links cannot be deleted",
                    OptionD = "Hard links duplicate file contents on disk",
                    CorrectAnswer = "B",
                    Explanation = "Hard links share the same inode and data blocks; if original name is deleted, data remains. Soft links break (dangling link) if the target path is moved/deleted."
                },
                #endregion

                #region Directory Structures & Path Names
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "File Directory | Path Name",
                    QuestionText = "What distinguishes an Absolute Pathname from a Relative Pathname in a directory tree?",
                    OptionA = "Absolute paths begin at the root directory (/ or C:\\) and specify the complete path; Relative paths are resolved relative to the Current Working Directory (CWD)",
                    OptionB = "Absolute paths only exist on Linux; Relative paths on Windows",
                    OptionC = "Relative paths cannot contain slashes",
                    OptionD = "Absolute paths cannot exceed 10 characters",
                    CorrectAnswer = "A",
                    Explanation = "Absolute path starts from root (e.g. `/home/user/doc.txt`); relative path starts from current location (e.g. `./doc.txt` or `../notes`)."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Structures of Directory",
                    QuestionText = "What is the primary limitation of a Single-Level Directory structure?",
                    OptionA = "It cannot store binary files",
                    OptionB = "All files are in the same single directory, so every file must have a unique name (name collision problem between different users) and searching is slow",
                    OptionC = "It requires 64-bit hardware",
                    OptionD = "It does not support file permissions",
                    CorrectAnswer = "B",
                    Explanation = "In single-level directories, distinct users cannot use the same filename (e.g. `test.c`), making it unsuitable for multi-user systems."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Structures of Directory",
                    QuestionText = "What is an Acyclic-Graph Directory structure, and what capability does it add over a Tree-Structured directory?",
                    OptionA = "It allows directories to share subdirectories and files between different branches without creating cycles/loops (e.g. via links)",
                    OptionB = "It allows infinite circular loops of folders",
                    OptionC = "It eliminates the root directory",
                    OptionD = "It formats directories as binary search trees",
                    CorrectAnswer = "A",
                    Explanation = "Acyclic graphs allow shared files/subdirectories across different paths while forbidding cycles, simplifying traversal and deletion."
                },
                #endregion

                #region File Allocation & Access Methods
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "File Allocation Methods",
                    QuestionText = "What is Contiguous File Allocation?",
                    OptionA = "Files are scattered randomly across different disk platters",
                    OptionB = "Each file occupies a set of contiguous blocks on the disk; simple to implement and fast sequential access, but suffers from severe external fragmentation and difficult file growth",
                    OptionC = "Files are compressed into zip archives",
                    OptionD = "Files are stored in CPU registers",
                    CorrectAnswer = "B",
                    Explanation = "Contiguous allocation needs only starting block and length, providing fast sequential reads, but suffers from external fragmentation."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "File Allocation Methods",
                    QuestionText = "What is the primary disadvantage of Linked File Allocation?",
                    OptionA = "Severe external fragmentation",
                    OptionB = "Extremely slow Direct/Random access, because locating block k requires sequentially traversing k pointers from the beginning of the file",
                    OptionC = "Files cannot exceed 1 MB",
                    OptionD = "Files cannot be deleted",
                    CorrectAnswer = "B",
                    Explanation = "In linked allocation, each block has a pointer to the next block; accessing the middle of a file requires walking the chain block-by-block."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "File Allocation Methods",
                    QuestionText = "How does the File Allocation Table (FAT) improve upon basic linked allocation?",
                    OptionA = "By caching block linkage pointers into a centralized table located at the beginning of the volume, which can be cached in RAM for faster random access",
                    OptionB = "By encrypting sectors using AES",
                    OptionC = "By eliminating the root directory",
                    OptionD = "By formatting sectors into prime numbers",
                    CorrectAnswer = "A",
                    Explanation = "FAT pulls all pointer chains into a centralized table in memory, allowing pointer traversal without reading disk data blocks."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "File Allocation Methods",
                    QuestionText = "What is Indexed File Allocation?",
                    OptionA = "Files are sorted alphabetically on disk",
                    OptionB = "Each file has its own dedicated Index Block containing direct pointers to all the file's data blocks, supporting direct access without external fragmentation",
                    OptionC = "Files must occupy adjacent cylinders",
                    OptionD = "Index blocks are stored in ROM",
                    CorrectAnswer = "B",
                    Explanation = "Indexed allocation supports fast random access with zero external fragmentation, but incurs index block overhead for small files."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "File Access Methods",
                    QuestionText = "What is Direct (Random) File Access compared to Sequential File Access?",
                    OptionA = "Sequential access reads records in fixed order from beginning; Direct access allows reading/writing arbitrary blocks immediately by block number using seek operations",
                    OptionB = "Direct access can only be used on magnetic tape",
                    OptionC = "Sequential access requires no disk hardware",
                    OptionD = "Direct access bypasses the operating system completely",
                    CorrectAnswer = "A",
                    Explanation = "Direct access (essential for databases) allows immediate jumps to record $N$ via `lseek()`, unlike sequential access which reads $1, 2, \\dots, N-1$ first."
                },
                #endregion

                #region Secondary Memory & Hard Disk Drive (HDD)
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Secondary memory",
                    QuestionText = "What are the primary characteristics of Secondary Memory compared to Primary Memory (RAM)?",
                    OptionA = "Secondary memory is non-volatile, has much larger storage capacity, is slower in access time, and retains data when power is turned off",
                    OptionB = "Secondary memory is faster than CPU cache",
                    OptionC = "Secondary memory loses all data on reboot",
                    OptionD = "Secondary memory is placed directly on the CPU die",
                    CorrectAnswer = "A",
                    Explanation = "Secondary storage (HDDs, SSDs, optical drives) provides non-volatile, long-term persistent storage for programs and data."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Secondary memory – Hard disk drive",
                    QuestionText = "What is the physical geometry and anatomy of a Hard Disk Drive (HDD)?",
                    OptionA = "Silicon NAND flash cells organized in pages and blocks",
                    OptionB = "Rigid rotating platters coated with magnetic material, organized into concentric circular Tracks divided into Sectors, read/written by heads on a moving arm across Cylinders",
                    OptionC = "A single spiral optical groove read by an infrared laser",
                    OptionD = "A continuous spool of magnetic tape wound around two reels",
                    CorrectAnswer = "B",
                    Explanation = "HDDs consist of stacked platters spinning on a spindle, with tracks, sectors (typically 512B or 4KB), and cylinders across platter surfaces."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Secondary memory – Hard disk drive",
                    QuestionText = "What is the largest component of disk access latency in traditional mechanical Hard Disk Drives?",
                    OptionA = "Bus transfer time",
                    OptionB = "Seek Time (the mechanical time required to move the read/write head assembly to the desired cylinder/track)",
                    OptionC = "Cache lookup latency",
                    OptionD = "Electrical signal delay across the SATA cable",
                    CorrectAnswer = "B",
                    Explanation = "Seek time involves physical mechanical movement of the head assembly, dominating total access time (often 3 to 10 milliseconds)."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Secondary memory – Hard disk drive",
                    QuestionText = "What is Rotational Latency in an HDD and how is average rotational latency calculated?",
                    OptionA = "The time to spin down when powered off",
                    OptionB = "The time waiting for the desired sector to rotate under the read/write head; on average, it equals the time for half a full disk revolution (1 / (2 * RPS))",
                    OptionC = "The time to move the arm across all tracks",
                    OptionD = "The time to format a cylinder",
                    CorrectAnswer = "B",
                    Explanation = "On average, the target sector is half a rotation away from the head: for 7200 RPM (120 rev/s), average latency is $1 / (2 \\times 120) \\approx 4.17$ ms."
                },
                #endregion

                #region Disk Scheduling Algorithms
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Disk Scheduling Algorithms",
                    QuestionText = "What is the primary objective of Disk Scheduling Algorithms?",
                    OptionA = "To increase the rotational speed of the spindle motor",
                    OptionB = "To minimize total head movement (Seek Time) and maximize disk bandwidth by ordering pending I/O requests efficiently",
                    OptionC = "To compress files during disk writes",
                    OptionD = "To format disk sectors",
                    CorrectAnswer = "B",
                    Explanation = "Disk scheduling algorithms sequence pending I/O requests to minimize head travel distance and avoid starvation."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Disk Scheduling Algorithms",
                    QuestionText = "What is Shortest Seek Time First (SSTF) disk scheduling and what is its main drawback?",
                    OptionA = "Services requests strictly in arrival order; drawback is slow speed",
                    OptionB = "Services the request with the minimum seek time from the current head position; drawback is potential Starvation for requests far away from the head",
                    OptionC = "Sweeps back and forth; drawback is complex math",
                    OptionD = "Services the largest file first; drawback is low throughput",
                    CorrectAnswer = "B",
                    Explanation = "SSTF chooses the closest request, which can cause starvation if new requests near the head continually arrive."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Disk Scheduling Algorithms",
                    QuestionText = "How does the SCAN (Elevator) disk scheduling algorithm work?",
                    OptionA = "Moves the head in one direction servicing requests until it reaches the end of the disk, then reverses direction servicing requests on the way back",
                    OptionB = "Randomly jumps across cylinders",
                    OptionC = "Services requests in FIFO order",
                    OptionD = "Services requests from outer edge to inner edge without reversing",
                    CorrectAnswer = "A",
                    Explanation = "Like an elevator, SCAN travels continuously from one end of the disk to the other, picking up requests along its path."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Disk Scheduling Algorithms",
                    QuestionText = "How does C-SCAN (Circular SCAN) differ from standard SCAN?",
                    OptionA = "C-SCAN travels in both directions equally",
                    OptionB = "C-SCAN moves in one direction only servicing requests; when it reaches the end, it immediately returns to the beginning without servicing requests on the return trip, providing more uniform wait times",
                    OptionC = "C-SCAN only services cylinder 0",
                    OptionD = "C-SCAN is designed exclusively for circular optical media",
                    CorrectAnswer = "B",
                    Explanation = "C-SCAN treats cylinders as a circular list, ensuring cylinders at the edges receive the same uniform wait times as cylinders in the center."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Disk Scheduling Algorithms",
                    QuestionText = "What is the LOOK (and C-LOOK) disk scheduling algorithm?",
                    OptionA = "A version of SCAN that only travels as far as the last actual request in each direction, reversing immediately without going all the way to the physical disk edge",
                    OptionB = "An algorithm that looks up sectors in a hash table",
                    OptionC = "An algorithm that predicts future user file requests using AI",
                    OptionD = "A graphical user interface for disk management",
                    CorrectAnswer = "A",
                    Explanation = "LOOK inspects the request queue and reverses as soon as the last pending request in the current direction is serviced, avoiding wasted arm travel."
                },
                #endregion

                #region Program for SSTF & Spooling vs Buffering
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Program for SSTF disk scheduling algorithm",
                    QuestionText = "Given request queue: [98, 183, 37, 122, 14], current head at 53. Under SSTF, which cylinder request is serviced FIRST?",
                    OptionA = "98",
                    OptionB = "37 (since |53 - 37| = 16 is the minimum seek distance among all pending requests)",
                    OptionC = "14",
                    OptionD = "183",
                    CorrectAnswer = "B",
                    Explanation = "Distances from 53: |53-37|=16, |53-98|=45, |53-122|=69, |53-14|=39, |53-183|=130. Minimum distance is 16, so cylinder 37 is serviced first."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "What exactly Spooling is all about?",
                    QuestionText = "What does Spooling stand for and what is its primary purpose?",
                    OptionA = "Single Peripheral Operating On Line; running single hardware tasks",
                    OptionB = "Simultaneous Peripheral Operations On-Line; using disk storage as a large buffer to overlap the I/O of one job with the computation of other jobs (e.g. print spooler)",
                    OptionC = "Spinning Platters On Optical Lasers; reading optical discs",
                    OptionD = "Swapping Pages On Out-Of-Memory Loads; paging to disk",
                    CorrectAnswer = "B",
                    Explanation = "Spooling buffers I/O data onto disk, preventing fast CPUs from idling while waiting for slow mechanical peripheral devices (like printers)."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Spooling vs Buffering",
                    QuestionText = "What is the primary difference between Spooling and Buffering?",
                    OptionA = "Buffering overlaps the I/O of a job with computation of that SAME job using main memory (RAM); Spooling overlaps the I/O of one job with computation of OTHER jobs using disk storage",
                    OptionB = "Spooling uses RAM; Buffering uses hard disks",
                    OptionC = "Buffering is software; Spooling is hardware",
                    OptionD = "There is no difference between the two",
                    CorrectAnswer = "A",
                    Explanation = "Buffering temporarily stores data in RAM during transfers for 1 job; Spooling stages multiple independent jobs onto disk to decouple devices from CPUs."
                },
                new() {
                    Category = cat,
                    SubCategory = subCat, Tag = "Free space management",
                    QuestionText = "How does the Bit Vector (Bit Map) approach manage free disk blocks?",
                    OptionA = "Each bit represents one disk block (0 = allocated, 1 = free); allows finding the first free block quickly using hardware bit-scan instructions",
                    OptionB = "Stores free block numbers in an Excel spreadsheet",
                    OptionC = "Uses a linked list with one pointer per sector",
                    OptionD = "Allocates blocks randomly",
                    CorrectAnswer = "A",
                    Explanation = "A Bit Vector is compact and fast: for a disk with $N$ blocks, an array of $N$ bits is maintained, allowing $O(1)$ discovery of contiguous free blocks."
                }
                #endregion
            };
        }
    }
}

