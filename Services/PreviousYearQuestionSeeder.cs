using ITSoftware.Data;
using ITSoftware.Models;
using ITSoftware.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ITSoftware.Services
{
    public static class PreviousYearQuestionSeeder
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ExamPrepDbContext>();

            try
            {
                // Ensure database and schema are ready
                await context.Database.EnsureCreatedAsync();

                if (!await context.PreviousYearQuestions.AnyAsync())
                {
                    var allQuestions = GetAllQuestions();
                    await context.PreviousYearQuestions.AddRangeAsync(allQuestions);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Log or handle gracefully
                Console.WriteLine($"Seeding error: {ex.Message}");
            }
        }

        public static List<TopicCategorySummary> GetCategoryMetadata(List<PreviousYearQuestion> allQuestions)
        {
            var meta = new List<(int Order, string Category, string Priority, int Stars, string Icon, string Pct)>
            {
                (1, "Networking & Data Communication", "Critical", 5, "bi-wifi", "23.2%"),
                (2, "Programming & Algorithms", "Critical", 5, "bi-code-slash", "13.5%"),
                (3, "Hardware & Digital Logic", "Critical", 5, "bi-cpu", "13.3%"),
                (4, "Database & SQL", "Critical", 5, "bi-database", "12.1%"),
                (5, "Cybersecurity", "High", 4, "bi-shield-lock", "8.9%"),
                (6, "Software Engineering", "High", 4, "bi-diagram-2", "5.8%"),
                (7, "Data Structures", "Medium", 3, "bi-diagram-3", "5.3%"),
                (8, "Operating Systems", "Medium", 3, "bi-pc-display", "4.3%"),
                (9, "Banking & Digital Finance", "Medium", 3, "bi-bank", "3.6%"),
                (10, "Focus / Essay / Translation", "Low", 2, "bi-pencil-square", "3.6%"),
                (11, "OOP Concepts", "Low", 2, "bi-boxes", "2.9%"),
                (12, "Cloud & Virtualization", "Low", 2, "bi-cloud", "2.2%"),
                (13, "Math & Number Systems", "Low", 2, "bi-calculator", "0.7%"),
                (14, "General Knowledge", "Low", 2, "bi-globe", "0.5%")
            };

            var list = new List<TopicCategorySummary>();
            foreach (var m in meta)
            {
                var catQuestions = allQuestions.Where(q => q.Category == m.Category).ToList();
                list.Add(new TopicCategorySummary
                {
                    Order = m.Order,
                    Category = m.Category,
                    TotalQuestions = catQuestions.Count > 0 ? catQuestions.Count : 0,
                    SolvedQuestions = catQuestions.Count(q => q.IsSolved),
                    Priority = m.Priority,
                    StarRating = m.Stars,
                    Icon = m.Icon,
                    Percentage = m.Pct
                });
            }

            return list;
        }

        public static List<PreviousYearQuestion> GetAllQuestions()
        {
            var list = new List<PreviousYearQuestion>();
            list.AddRange(GetNetworkingQuestions());
            list.AddRange(GetProgrammingQuestions());
            list.AddRange(GetHardwareQuestions());
            list.AddRange(GetDatabaseQuestions());
            list.AddRange(GetCybersecurityQuestions());
            list.AddRange(GetSoftwareEngineeringQuestions());
            list.AddRange(GetDataStructuresQuestions());
            list.AddRange(GetOperatingSystemsQuestions());
            list.AddRange(GetBankingQuestions());
            list.AddRange(GetFocusEssayQuestions());
            list.AddRange(GetOopQuestions());
            list.AddRange(GetCloudQuestions());
            list.AddRange(GetMathQuestions());
            list.AddRange(GetGkQuestions());
            return list;
        }

        #region 1. Networking & Data Communication (96 Questions)
        private static List<PreviousYearQuestion> GetNetworkingQuestions()
        {
            const string cat = "Networking & Data Communication";
            const int order = 1;
            return new List<PreviousYearQuestion>
            {
                new() { CategoryOrder = order, Category = cat, QuestionNo = 1, Year = 2020, ExamOrg = "Combined Bank Officer IT (SB&JB)", Post = "Officer IT", QuestionText = "Which transmission medium is usually used in a LAN? What is its maximum length and highest bit rate? Write the name of data at each layer of the TCP/IP model." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 2, Year = 2020, ExamOrg = "Combined Bank Officer IT (SB&JB)", Post = "Officer IT", QuestionText = "A signal has a frequency range of 300 Hz to 3400 Hz. A PCM system is used to digitize it. Max quantization error ±1% of full scale, voltage −1 V to +1 V. Determine (i) number of bits per sample (n) and (ii) bit rate of the PCM system." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 3, Year = 2020, ExamOrg = "BSCS Combined 2 Bank (SB&JB)", Post = "Officer IT", QuestionText = "RFID has huge applications in business, especially in supply chain management and toll collection. Show the basic working principle of RFID in brief." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 4, Year = 2020, ExamOrg = "BSCS Combined 2 Bank (SB&JB)", Post = "Officer IT", QuestionText = "Make a list of LTE Network elements." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 5, Year = 2020, ExamOrg = "BSCS Combined 2 Bank (SB&JB)", Post = "Officer IT", QuestionText = "What are the functions performed by TCP to make a network more reliable? (TCP turns unreliable network into reliable one free from lost and duplicate packets.)" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 6, Year = 2020, ExamOrg = "Combined 3 Banks (SBL/BDBL)", Post = "Senior Officer IT", QuestionText = "What is the difference between Packet Sniffing (Snooping) and Packet Spoofing? [classified here as networking concept]" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 7, Year = 2020, ExamOrg = "Combined 3 Banks (SBL/BDBL)", Post = "Senior Officer IT", QuestionText = "ARP is used in TCP/IP for performing some operations. Write the functions of ARP." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 8, Year = 2020, ExamOrg = "Combined 3 Banks (SBL/BDBL)", Post = "Senior Officer IT", QuestionText = "What is GGSN? Write the main function of GGSN." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 9, Year = 2020, ExamOrg = "Combined 3 Banks (SBL/BDBL)", Post = "Senior Officer IT", QuestionText = "Describe Internet Exchange (IX) national and international level data communication function." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 10, Year = 2020, ExamOrg = "ANE JBL", Post = "Assistant Network Engineer", QuestionText = "Synchronous TDM: the figure shows 4 inputs at 1 Mbps each with 1-bit data unit. Analyze the output MUX frames." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 11, Year = 2020, ExamOrg = "ANE JBL", Post = "Assistant Network Engineer", QuestionText = "IP subnetting: IP 172.18.10.20/24 needs 32 subnets. (i) Subnet mask for max hosts? (ii) Hosts per subnet? (iii) First and last addresses of subnet 1 and subnet 32?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 12, Year = 2020, ExamOrg = "Combined 3 Banks (SBL/JBL/Rakub)", Post = "SO Written", QuestionText = "True/False: (i) For a web page with text + 3 images, client sends 1 request and receives 4 responses. (ii) Two distinct web pages can be sent over the same persistent connection. (iii) With non-persistent connections, a single TCP segment can carry two distinct HTTP messages. (iv) HTTP response messages never have an empty message body." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 13, Year = 2021, ExamOrg = "ANE RBL", Post = "Assistant Network Engineer", QuestionText = "Write about 5G disadvantages: (i) Initial cost (ii) Battery drainage." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 14, Year = 2021, ExamOrg = "ANE RBL", Post = "Assistant Network Engineer", QuestionText = "Given IP 172.16.0.0, create 4 subnets with 4000, 2000, 4000 and 8000 hosts. Find subnet mask, first IP, last IP, and broadcast address of all 4 subnets." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 15, Year = 2021, ExamOrg = "ASA JBL", Post = "Assistant System Administrator", QuestionText = "Network address 172.68.16.5/25. (i) What is the subnet mask? (ii) What is the number of hosts?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 16, Year = 2021, ExamOrg = "ASA JBL", Post = "Assistant System Administrator", QuestionText = "Which broadcast address is used for network 10.31.70.0/3?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 17, Year = 2021, ExamOrg = "Security Printing Corp Bangladesh", Post = "Assistant Maintenance Engineer", QuestionText = "Define the line coding techniques and mention their categories." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 18, Year = 2021, ExamOrg = "Security Printing Corp Bangladesh", Post = "Assistant Maintenance Engineer", QuestionText = "Compare and contrast between the OSI model and the TCP/IP model." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 19, Year = 2021, ExamOrg = "Security Printing Corp Bangladesh", Post = "Assistant Maintenance Engineer", QuestionText = "What is Multiplexing? Describe multiplexing techniques with examples. Explain Time Division Multiplexing." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 20, Year = 2021, ExamOrg = "BSCA Sonali Bank", Post = "Officer IT", QuestionText = "What is Web Caching? Why use caching?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 21, Year = 2021, ExamOrg = "BSCA Sonali Bank", Post = "Officer IT", QuestionText = "What is VPN? Write some advantages of using VPN." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 22, Year = 2021, ExamOrg = "BSCA Sonali Bank", Post = "Officer IT", QuestionText = "Difference between distance vector routing and link-state routing algorithm." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 23, Year = 2021, ExamOrg = "BSCA Sonali Bank", Post = "Officer IT", QuestionText = "An analog signal has a bit rate of 8000 bps and a baud rate of 1000 baud. How many data elements are carried by each signal element? How many signal elements are needed?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 24, Year = 2021, ExamOrg = "BSCA Sonali Bank", Post = "Officer IT", QuestionText = "Explain Three-Way Handshaking in TCP Protocol." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 25, Year = 2021, ExamOrg = "AHE SBL/JBL/RBL", Post = "Assistant Hardware Engineer", QuestionText = "IP address 105.38.89.234/20: (i) Network ID and host ID? (ii) Network address and broadcast address? (iii) Size of the network? (iv) Class if classful addressing used?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 26, Year = 2021, ExamOrg = "AHE SBL/JBL/RBL", Post = "Assistant Hardware Engineer", QuestionText = "What is NAT? Why is NAT used and how does NAT translate IP addresses?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 27, Year = 2021, ExamOrg = "AHE SBL/JBL/RBL", Post = "Assistant Hardware Engineer", QuestionText = "How long to send a file of 500,000 bits from host A to B over circuit-switched network: all links 1.536 Mbps, TDM with 32 slots/sec, 800 ms to establish circuit?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 28, Year = 2022, ExamOrg = "Security Printing Corp Bangladesh", Post = "Sub-Asst Maintenance Engineer", QuestionText = "What is OSI model? Describe briefly the OSI model layers. Difference between OSI and TCP/IP layer." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 29, Year = 2022, ExamOrg = "Security Printing Corp Bangladesh", Post = "Sub-Asst Maintenance Engineer", QuestionText = "What is subnet mask and Localhost IP address?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 30, Year = 2022, ExamOrg = "Security Printing Corp Bangladesh", Post = "Sub-Asst Maintenance Engineer", QuestionText = "Difference between TCP and UDP, HTTP and HTTPS." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 31, Year = 2022, ExamOrg = "Security Printing Corp Bangladesh", Post = "Sub-Asst Maintenance Engineer", QuestionText = "Write short note: NAT, Ransomware, and Firewall." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 32, Year = 2022, ExamOrg = "Security Printing Corp Bangladesh", Post = "Sub-Asst Maintenance Engineer", QuestionText = "What is IPv6? Why is IPv6 needed?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 33, Year = 2022, ExamOrg = "Security Printing Corp Bangladesh", Post = "Sub-Asst Maintenance Engineer", QuestionText = "What is multiplexing? Describe different types of multiplexing." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 34, Year = 2022, ExamOrg = "Security Printing Corp Bangladesh", Post = "Sub-Asst Maintenance Engineer", QuestionText = "Write connection types: (i) Router to Router (ii) Router to Switch (iii) Computer to Computer (iv) Hub to Switch (v) Computer console port to Switch." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 35, Year = 2022, ExamOrg = "Security Printing Corp Bangladesh", Post = "Sub-Asst Maintenance Engineer", QuestionText = "Hosts A and B connected via Ethernet. Ping attempts unsuccessful. What can be done to provide connectivity? Write reasons and solutions." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 36, Year = 2022, ExamOrg = "ANE JBL", Post = "Assistant Network Engineer", QuestionText = "Find the shortest path from A to all nodes using the Dijkstra algorithm (graph given in exam)." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 37, Year = 2022, ExamOrg = "ANE JBL", Post = "Assistant Network Engineer", QuestionText = "Differences between Hub, Switch, and Router." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 38, Year = 2022, ExamOrg = "ANE JBL", Post = "Assistant Network Engineer", QuestionText = "IP 202.11.2.0 with Class C subnet mask needs 30 subnets. (i) Subnet mask for max hosts? (ii) Hosts per subnet? (iii) 3rd host on 2nd subnet?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 39, Year = 2022, ExamOrg = "ANE JBL", Post = "Assistant Network Engineer", QuestionText = "Satellite microwave link (10 Mbps), propagation speed 1.4×10⁸ m/s. (a) Propagation delay? (b) Bandwidth-delay product? (c) Minimum packet size x for continuously transmitting?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 40, Year = 2022, ExamOrg = "ANE JBL", Post = "Assistant Network Engineer", QuestionText = "Explain the different data transferring modes used on the internet with practical examples." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 41, Year = 2022, ExamOrg = "ANE JBL", Post = "Assistant Network Engineer", QuestionText = "Explain: Framing, Flow control, Error control, Reliability — and mention their layer." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 42, Year = 2022, ExamOrg = "ANA JBL", Post = "Assistant Network Administrator", QuestionText = "Company A in Dhaka (IP 202.50.14.3) tries video conference with Company B in Chittagong (IP 192.168.40.3). Is communication possible? Explain your answer." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 43, Year = 2022, ExamOrg = "ANA JBL", Post = "Assistant Network Administrator", QuestionText = "Host A sends data (3,9,7,12,4) in 8-bit binary to host B using checksum. What is the actual data sent?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 44, Year = 2022, ExamOrg = "ANA JBL", Post = "Assistant Network Administrator", QuestionText = "Commands: (i) Check localhost connectivity and verify interface status (ii) Show packet path from your location to www.google.com (iii) Show DNS-related info for www.google.com" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 45, Year = 2022, ExamOrg = "ANA JBL", Post = "Assistant Network Administrator", QuestionText = "Difference between link-state and distance vector routing using: message complexity, convergence, robustness." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 46, Year = 2022, ExamOrg = "ANA JBL", Post = "Assistant Network Administrator", QuestionText = "AMPS uses two bands: 824–849 MHz (sending), 869–894 MHz (receiving). Each user has 30 kHz bandwidth in each direction. How many people can use cell phones simultaneously?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 47, Year = 2022, ExamOrg = "ANA JBL", Post = "Assistant Network Administrator", QuestionText = "Explain additive increase and multiplicative decrease methods used in TCP for congestion control." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 48, Year = 2022, ExamOrg = "SBL/BDBL", Post = "Senior Officer IT", QuestionText = "How HTTP works? How many HTTP requests would be needed for a given situation?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 49, Year = 2022, ExamOrg = "SBL/BDBL", Post = "Senior Officer IT", QuestionText = "What is web caching? Is it available for every user request? Why or why not?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 50, Year = 2022, ExamOrg = "SBL/BDBL", Post = "Senior Officer IT", QuestionText = "Organization with IP 15.13.0.0/8 wants 32 subnets. What are the first and last IP addresses of the last subnet?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 51, Year = 2022, ExamOrg = "SBL/BDBL", Post = "Senior Officer IT", QuestionText = "How many 8-bit characters can be transmitted per second over a 9600 baud serial link using asynchronous mode with 1 start bit, 8 data bits, 2 stop bits, 1 parity bit?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 52, Year = 2022, ExamOrg = "SBL/BDBL", Post = "Senior Officer IT", QuestionText = "How is Stop-and-Wait ARQ used for reliable data transfer?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 53, Year = 2023, ExamOrg = "Combined 5 Bank (BIBM)", Post = "Officer IT", QuestionText = "CRC with generator 11101010111. What is the probability of detecting a burst error of length 10?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 54, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Maintenance Engineer", QuestionText = "Explain parity method for error detection. Write down the bit strings of \"Delta\" using ASCII." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 55, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Maintenance Engineer", QuestionText = "Digitized TV: 480×500 pixels, each pixel 32 intensity values, 30 pictures/sec. Find the source rate R (bps)." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 56, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Maintenance Engineer", QuestionText = "Packet of P bytes with 5 bytes header. Source encoded at 128 kbps. Determine packetization delay for L=1500 bytes (max Ethernet packet size)." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 57, Year = 2023, ExamOrg = "Combined Bank (BIBM)", Post = "Officer IT", QuestionText = "Difference between TCP and UDP, CAT5 and CAT6, FAT32 and NTFS." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 58, Year = 2023, ExamOrg = "Combined 4 Bank (BIBM)", Post = "SO IT", QuestionText = "Differentiate among TDM, FDM, and WDM. How does synchronous TDM work?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 59, Year = 2023, ExamOrg = "Combined 4 Bank (BIBM)", Post = "SO IT", QuestionText = "What is topology in data communication? Differences between bus, ring, tree, and star topology. How does IEEE 802 work?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 60, Year = 2023, ExamOrg = "Combined 4 Bank (BIBM)", Post = "SO IT", QuestionText = "Difference between OSI and TCP/IP model. Write about OSI layer Packet, Frame, Bit, Segment with protocol names." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 61, Year = 2023, ExamOrg = "RAKUB (BIBM)", Post = "ANSE", QuestionText = "What is Packet Switching, Circuit Switching? Differentiate between them. Which is better? Give real-life examples." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 62, Year = 2023, ExamOrg = "RAKUB (BIBM)", Post = "ANSE", QuestionText = "What is CRC, Parity bit? Which is better for error detection?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 63, Year = 2023, ExamOrg = "RAKUB (BIBM)", Post = "ANSE", QuestionText = "What is Optical cable, Satellite transmission? Differentiate between them. Bangladesh submarine cable name?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 64, Year = 2023, ExamOrg = "RAKUB (BIBM)", Post = "ANSE", QuestionText = "Write difference between Router and Bridge." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 65, Year = 2023, ExamOrg = "RAKUB (BIBM)", Post = "ANSE", QuestionText = "Write difference between Synchronous and Asynchronous transmission." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 66, Year = 2023, ExamOrg = "RAKUB (BIBM)", Post = "ANSE", QuestionText = "What is NAT? How does it work?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 67, Year = 2023, ExamOrg = "RAKUB (BIBM)", Post = "ANSE", QuestionText = "What is the OSI Layer? Write about OSI layer Packet, Frame, Bit, Segment with protocol names. Difference between OSI and TCP/IP layer." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 68, Year = 2023, ExamOrg = "RAKUB (BIBM)", Post = "ANSE", QuestionText = "What is SMTP, SNMP, HTTP, and HTTPS?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 69, Year = 2023, ExamOrg = "RAKUB (BIBM)", Post = "ANSE", QuestionText = "What is VLAN, Types of VLAN (static and dynamic)? Draw VLAN. Write Difference between IPv4 and IPv6." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 70, Year = 2023, ExamOrg = "RAKUB (BIBM)", Post = "ANSE", QuestionText = "What is TDM, FDM, and WDM? Difference among them. Write about synchronous and statistical TDM." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 71, Year = 2023, ExamOrg = "Rupali Bank (BIBM)", Post = "ANA", QuestionText = "What is Network Topology? Distinguish between Bus, Ring, Tree, and Star topology. Discuss how Bus topology works." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 72, Year = 2023, ExamOrg = "Rupali Bank (BIBM)", Post = "ANA", QuestionText = "What is the main benefit of broadband transmission system compared to baseband?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 73, Year = 2023, ExamOrg = "Rupali Bank (BIBM)", Post = "ANA", QuestionText = "What is attenuation of transmission media? Distinguish between twisted pair, co-axial cable, and fiber optics in tabular form." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 74, Year = 2023, ExamOrg = "Rupali Bank (BIBM)", Post = "ANA", QuestionText = "Differentiate between OSI and TCP/IP Model. Draw diagram of 4-layer TCP/IP Model with main function of each layer and related protocols. List basic functions performed at MAC layer." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 75, Year = 2023, ExamOrg = "Rupali Bank (BIBM)", Post = "ANA", QuestionText = "Write the basic difference of: (i) Public vs Private IP address (ii) L2 vs L3 Switch" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 76, Year = 2023, ExamOrg = "Rupali Bank (BIBM)", Post = "ANA", QuestionText = "Differentiate between Domain and Broadcast Domain. What is the function of DNS and DHCP?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 77, Year = 2023, ExamOrg = "Rupali Bank (BIBM)", Post = "ANA", QuestionText = "Prefer packet switching vs circuit switching? If yes, why? How does packet switching work step by step? What applications use packet switching?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 78, Year = 2023, ExamOrg = "Rupali Bank (BIBM)", Post = "ANA", QuestionText = "What is a subnet and subnet mask? Network 172.10.0.0/19 — how many subnets and hosts? What is the function of OSPF?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 79, Year = 2023, ExamOrg = "Rupali Bank (BIBM)", Post = "ANA", QuestionText = "Convert decimal IP 192.18.101.5 to binary. Fill table: Address Class, First Octet Decimal range, Example IP, Network ID, Host ID for Class A, B, C." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 80, Year = 2023, ExamOrg = "Combined Bank (BIBM)", Post = "Senior Officer AHE/AME", QuestionText = "What is multiplexing in data communication? Mention types of multiplexing and describe one type in detail." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 81, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "ADA", QuestionText = "What is the primary motivation for moving from classful IP addressing to classless IP addressing (CIDR)?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 82, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "AME/AE IT", QuestionText = "Tabular representation of TCP/IP model: function of each layer, protocols related to each layer, devices and software. Different types of network firewalls. Advantages of NGFW over traditional firewall." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 83, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "Senior Officer IT", QuestionText = "What is Active Directory? Office with 3 departments × 50–70 employees on Windows — do you need Active Directory? Briefly explain its use." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 84, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "Senior Officer IT", QuestionText = "What is a subnet? What benefits will you get using subnets for this office?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 85, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "Senior Officer IT", QuestionText = "Briefly describe: Repeater, Hub, Bridge, Switch, and Router." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 86, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "Senior Officer IT", QuestionText = "What are the different types of transmission media used for data communication? Explain their advantages and disadvantages." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 87, Year = 2024, ExamOrg = "Combined 2 Bank (BIBM)", Post = "Officer IT", QuestionText = "Explain difference between flow-control and congestion control. Discuss the impact of stable end-to-end latency." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 88, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "Senior Officer IT", QuestionText = "How many types of modes are used in data transferring through networks? Briefly explain. Differentiate TCP vs UDP." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 89, Year = 2025, ExamOrg = "Combined Bank (BIBM)", Post = "Officer IT", QuestionText = "Why does DNS primarily use UDP instead of TCP? Describe the sequence of events during DNS name resolution when user enters www.companybd.com into a browser." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 90, Year = 2025, ExamOrg = "Combined Bank (BIBM)", Post = "Officer IT", QuestionText = "What are SOAP and RESTful APIs in web services? State one main difference between SOAP and REST in terms of how they exchange data." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 91, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "Mention the layers of the OSI Model and the function of each layer." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 92, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "Compare TCP and UDP protocols with examples." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 93, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "Apply IP addressing and routing to explain how packets are delivered across networks using OSPF at the network layer." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 94, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "Explain the logic of a \"Checksum\". How is it used to verify data integrity during file transfer?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 95, Year = 2026, ExamOrg = "Sonali Bank PLC", Post = "ADA", QuestionText = "Given IP 192.168.1.0, divide into 4 subnets of equal size. (A) Find the new subnet mask (CIDR). (B) Find the first usable host address of each subnet." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 96, Year = 2026, ExamOrg = "Sonali Bank PLC", Post = "ADA", QuestionText = "What is DNS? How does DNS work?" }
            };
        }
        #endregion

        #region 2. Programming & Algorithms (56 Questions)
        private static List<PreviousYearQuestion> GetProgrammingQuestions()
        {
            const string cat = "Programming & Algorithms";
            const int order = 2;
            return new List<PreviousYearQuestion>
            {
                new() { CategoryOrder = order, Category = cat, QuestionNo = 1, Year = 2020, ExamOrg = "Combined Bank Officer IT (SB&JB)", Post = "Officer IT", QuestionText = "Write a JavaScript function to validate an email address." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 2, Year = 2020, ExamOrg = "BSCS Combined 2 Bank (SB&JB)", Post = "Officer IT", QuestionText = "Describe the algorithm complexity factors (efficiency and complexity factors)." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 3, Year = 2020, ExamOrg = "BSCS Combined 2 Bank (SB&JB)", Post = "Officer IT", QuestionText = "Write a program that takes hourly wage, total regular hours, and total overtime hours as input and prints an employee's total weekly pay. (Overtime = 1.5× hourly rate)" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 4, Year = 2020, ExamOrg = "BSCS Combined 2 Bank (SB&JB)", Post = "Officer IT", QuestionText = "Write a recursive algorithm to find the factorial of a number." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 5, Year = 2020, ExamOrg = "BSCS Combined 2 Bank (SB&JB)", Post = "Officer IT", QuestionText = "Write a program to sort some given numbers using insertion sort algorithm." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 6, Year = 2020, ExamOrg = "Combined 3 Banks (SBL/BDBL)", Post = "Senior Officer IT", QuestionText = "Discuss Complexity factor of algorithm." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 7, Year = 2020, ExamOrg = "Combined 3 Banks (SBL/BDBL)", Post = "Senior Officer IT", QuestionText = "Write a program that checks if a number is Armstrong or not." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 8, Year = 2020, ExamOrg = "Combined 3 Banks (SBL/BDBL)", Post = "Senior Officer IT", QuestionText = "Linear Search implementation program: find whether a given number is present in an array and if so, at what location (using any programming language)." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 9, Year = 2020, ExamOrg = "ANE JBL", Post = "Assistant Network Engineer", QuestionText = "Write a C/C++ program to check balanced parentheses in an expression." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 10, Year = 2020, ExamOrg = "Combined 3 Banks (SBL/JBL/Rakub)", Post = "SO Written", QuestionText = "Find the sum of digits of a number until reduced to a single digit. Sample input: 12345 → Sample output: 6" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 11, Year = 2020, ExamOrg = "ADA SBL", Post = "Assistant Database Admin", QuestionText = "Find output of: (i) Integer a=new Integer(33); b=new Integer(33); if(a==b) ... (ii) int i=7; for(;i!=0;i--) printf(...i--) (iii) int j=1; while(j++<50) print(j) (iv) unsigned int a=1, b=2; printf(\"%d\", a<<a+b)" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 12, Year = 2020, ExamOrg = "ADA SBL", Post = "Assistant Database Admin", QuestionText = "Write a pseudocode to merge two sorted arrays into a new sorted array." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 13, Year = 2020, ExamOrg = "ADA SBL", Post = "Assistant Database Admin", QuestionText = "Write a program for the nth Catalan number using Dynamic Programming." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 14, Year = 2021, ExamOrg = "ANE RBL", Post = "Assistant Network Engineer", QuestionText = "Write a procedure sumNodes(*root) to find the summation of all nodes of a binary tree." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 15, Year = 2021, ExamOrg = "ANE RBL", Post = "Assistant Network Engineer", QuestionText = "Given an IPv4 address string, write C/C++/Java code to show the class the IP address belongs to. Sample Input: 192.168.0.1" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 16, Year = 2021, ExamOrg = "ASA JBL", Post = "Assistant System Administrator", QuestionText = "G=(V,E) is an undirected graph. Write an algorithm to find the minimum-cost spanning tree in G." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 17, Year = 2021, ExamOrg = "BSCA Sonali Bank", Post = "Officer IT", QuestionText = "Write a program to find summation for a number until it becomes a single digit." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 18, Year = 2021, ExamOrg = "BSCA Sonali Bank", Post = "Officer IT", QuestionText = "Find the Shortest Spanning Tree using Kruskal's Algorithm from a given graph." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 19, Year = 2021, ExamOrg = "AHE SBL/JBL/RBL", Post = "Assistant Hardware Engineer", QuestionText = "Given sorted arrays X (n elements) and Y (m elements), write merge(int n, int m) to produce sorted array Z of (n+m) elements. Cannot sort after merge." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 20, Year = 2021, ExamOrg = "ASA JBL", Post = "Assistant System Administrator", QuestionText = "Write a Java program for a cricket player. Accept: player runs, no. of innings played, no. of times not out. Display average runs of a single player." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 21, Year = 2022, ExamOrg = "Security Printing Corp Bangladesh", Post = "Sub-Assistant Engineer", QuestionText = "What is the difference between exception and Error in Java?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 22, Year = 2022, ExamOrg = "Security Printing Corp Bangladesh", Post = "Sub-Assistant Engineer", QuestionText = "What is exception handling? Write with an example." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 23, Year = 2022, ExamOrg = "Security Printing Corp Bangladesh", Post = "Sub-Assistant Engineer", QuestionText = "Describe Dynamic memory allocation in programming in C." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 24, Year = 2022, ExamOrg = "Security Printing Corp Bangladesh", Post = "Sub-Assistant Engineer", QuestionText = "Difference between High level language and Low level languages with examples." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 25, Year = 2022, ExamOrg = "Security Printing Corp Bangladesh", Post = "Sub-Assistant Engineer", QuestionText = "What is nested structure in C programming? Explain with example." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 26, Year = 2022, ExamOrg = "ANE JBL", Post = "Assistant Network Engineer", QuestionText = "Write C/C++/Java program to reverse digits in a number. Sample input: 220 → Sample output: 022" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 27, Year = 2022, ExamOrg = "ANE JBL", Post = "Assistant Network Engineer", QuestionText = "Find the minimum spanning tree of the given graph using Prim's algorithm." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 28, Year = 2022, ExamOrg = "ANA JBL", Post = "Assistant Network Administrator", QuestionText = "Compare divide-and-conquer and dynamic programming. When is each preferable? Explain using merge sort and Fibonacci." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 29, Year = 2022, ExamOrg = "ANA JBL", Post = "Assistant Network Administrator", QuestionText = "Write C/C++/Java program to identify the class of an IP address." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 30, Year = 2022, ExamOrg = "SBL/BDBL", Post = "Senior Officer IT", QuestionText = "Write a recursive function that returns Boolean after taking a string as parameter to check if it's a palindrome." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 31, Year = 2022, ExamOrg = "SBL/BDBL", Post = "Senior Officer IT", QuestionText = "Determine the time complexity of a nested loop function: for(i=1; i<n/2; i++) { for(j=1; j<n; j++) { // code } }" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 32, Year = 2022, ExamOrg = "ADA SBL/JBL", Post = "Assistant Database Administrator", QuestionText = "Is Bellman-Ford a greedy algorithm? Can all-pair shortest paths (with negative cycles) be done in O(V³)?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 33, Year = 2022, ExamOrg = "ADA SBL/JBL", Post = "Assistant Database Administrator", QuestionText = "Write a function to reverse a string without using extra memory (reverse in-place)." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 34, Year = 2023, ExamOrg = "Combined 5 Bank (BIBM)", Post = "Officer IT", QuestionText = "Write a function to find the smallest value in an array. The array is passed as a parameter." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 35, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "Write a program to compute LCM of two integers A and B given as input." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 36, Year = 2023, ExamOrg = "Combined Bank (BIBM)", Post = "Officer IT", QuestionText = "Find complexity and output of recursive Fibonacci: F(n) = F(n-2)+F(n-1), called with F(5)." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 37, Year = 2023, ExamOrg = "Combined Bank (BIBM)", Post = "Officer IT", QuestionText = "Write a paragraph for sequence 1,2,2,3,3,3,...,100 (100 times) and analyze the complexity of the program." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 38, Year = 2023, ExamOrg = "Combined 4 Bank (BIBM)", Post = "SO IT", QuestionText = "Write a program that takes two matrices A and B as input (handle different dimensions): (a) Find matrix C = A×B (b) Average from matrix (c) Max from matrix C." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 39, Year = 2023, ExamOrg = "RAKUB (BIBM)", Post = "ANSE", QuestionText = "Given a Python code, find its output with complexity." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 40, Year = 2023, ExamOrg = "Rupali Bank (BIBM)", Post = "ANA", QuestionText = "Find output, analyze time and space complexity of a Fibonacci/sequence C++ program (int main with first/second/next pattern)." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 41, Year = 2024, ExamOrg = "Combined 5 Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "Write a C/Java program that shows prime numbers between 1 to n (user input)." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 42, Year = 2024, ExamOrg = "Combined 5 Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "Write a C/Java program that calculates the sum of series: 1+2+4+7+11+…+nth term." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 43, Year = 2024, ExamOrg = "Combined 5 Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "Write a C/Java program to print Floyd's Triangle for n=5 (alternating 0/1 pattern)." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 44, Year = 2024, ExamOrg = "Combined 5 Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "Find the output of the C program: fun(i) { if(i<=0) return; printf(\"%d\", i--); fun(--i); printf(\"%d\", i); } called with fun(5)." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 45, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "ADA", QuestionText = "Write a program for the series: e^x = 1 + x/1 + x²/2! + x³/3! + …" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 46, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "ADA", QuestionText = "Write a client program in any language that uses a database and allows login with ID and password." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 47, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "Senior Officer IT", QuestionText = "Write a program to find the sum of rows and columns of an m×n matrix, user provides m and n. Show row sums in same row, totals at bottom." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 48, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "Senior Officer IT", QuestionText = "Write a program to find prime numbers between 1 to n (n from user). Sample: n=20 → 2,3,5,7,11,13,17,19." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 49, Year = 2024, ExamOrg = "Combined 2 Bank (BIBM)", Post = "Officer IT", QuestionText = "What is the worst-case time and space complexity of quicksort? Explain how worst-case behavior can occur." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 50, Year = 2024, ExamOrg = "Combined 2 Bank (BIBM)", Post = "Officer IT", QuestionText = "Write a function that receives an array of integers as parameter and prints numbers divisible by 3." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 51, Year = 2025, ExamOrg = "Combined Bank (BIBM)", Post = "Officer IT", QuestionText = "Explain the Quick Sort algorithm with a suitable example. Under what conditions does Quick Sort exhibit worst-case time complexity and why?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 52, Year = 2025, ExamOrg = "Combined Bank (BIBM)", Post = "Officer IT", QuestionText = "Write a structured program (C or Python) that takes integer input n and prints the sum of all even numbers from 1 to n." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 53, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "Explain the difference between compiler and interpreter." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 54, Year = 2026, ExamOrg = "Sonali Bank PLC", Post = "ADA", QuestionText = "What is Dynamic Programming? Describe the properties of dynamic programming." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 55, Year = 2026, ExamOrg = "Sonali Bank PLC", Post = "ADA", QuestionText = "What is programming? Give 4 examples of programming languages. Difference between structured and OOP programming." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 56, Year = 2026, ExamOrg = "Sonali Bank PLC", Post = "ADA", QuestionText = "ATM PIN code flowchart — user input defined, decision taken (successful/failure)." }
            };
        }
        #endregion

        #region 3. Hardware & Digital Logic (55 Questions)
        private static List<PreviousYearQuestion> GetHardwareQuestions()
        {
            const string cat = "Hardware & Digital Logic";
            const int order = 3;
            return new List<PreviousYearQuestion>
            {
                new() { CategoryOrder = order, Category = cat, QuestionNo = 1, Year = 2020, ExamOrg = "Combined 3 Banks (SBL/BDBL)", Post = "Senior Officer IT", QuestionText = "Why is Heterogeneous Multicore Processor (HMP) gaining more popularity?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 2, Year = 2020, ExamOrg = "Combined 3 Banks (SBL/BDBL)", Post = "Senior Officer IT", QuestionText = "What is block and page? Draw a simple block and page diagram in SSD (Solid State Drive)." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 3, Year = 2020, ExamOrg = "Combined 3 Banks (SBL/BDBL)", Post = "Senior Officer IT", QuestionText = "Write the parameters used to evaluate the performance of memory." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 4, Year = 2020, ExamOrg = "Combined 3 Banks (SBL/BDBL)", Post = "Senior Officer IT", QuestionText = "Ergonomics is the study of characteristics of iteration. How to measure quality of sitting good chair (ergonomics)?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 5, Year = 2020, ExamOrg = "Combined 3 Banks (SBL/BDBL)", Post = "Senior Officer IT", QuestionText = "Draw a Full Adder circuit using two half adders." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 6, Year = 2020, ExamOrg = "ANE JBL", Post = "Assistant Network Engineer", QuestionText = "Simplify the Boolean function using K-map and draw the logic circuit: F = A'B'C' + AB'C' + AB'C + A'BC + ABC" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 7, Year = 2020, ExamOrg = "Combined 3 Banks (SBL/JBL/Rakub)", Post = "SO Written", QuestionText = "Draw 16×8 RAM using 16×4 RAM." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 8, Year = 2020, ExamOrg = "Combined 3 Banks (SBL/JBL/Rakub)", Post = "SO Written", QuestionText = "Find the Vout of the Op-Amp (1=5V, 0=0V)." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 9, Year = 2020, ExamOrg = "Combined 3 Banks (SBL/JBL/Rakub)", Post = "SO Written", QuestionText = "Draw and write the output equation for an 8×1 multiplexer (truth table with E, S2, S1, S0 given)." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 10, Year = 2020, ExamOrg = "Combined 3 Banks (SBL/JBL/Rakub)", Post = "SO Written", QuestionText = "7-segment display: BCD code ABCD, segment is ON for digits 2,3,5,6,7,8,9. Write Boolean expression in SOP form and simplify with K-map." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 11, Year = 2021, ExamOrg = "ANE RBL", Post = "Assistant Network Engineer", QuestionText = "Disk pack specifications: 16 surfaces, 128 tracks/surface, 256 sectors/track, 512 bytes/sector. (i) Capacity of disk pack? (ii) Capacity again (iii) If format overhead is 32 bytes/sector, what is formatted disk space?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 12, Year = 2021, ExamOrg = "ANE RBL", Post = "Assistant Network Engineer", QuestionText = "Design a 7-segment display decoder to find logic expression of sum of products for 2-bit binary input." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 13, Year = 2021, ExamOrg = "ANE RBL", Post = "Assistant Network Engineer", QuestionText = "Draw a logic circuit for a 2-to-4 De-multiplexer." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 14, Year = 2021, ExamOrg = "ASA JBL", Post = "Assistant System Administrator", QuestionText = "Disk pack: 32 surfaces, 128 tracks/surface, 256 sectors/track, 512 bytes/sector. Format overhead = 64 bytes/sector. What is the formatted disk space?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 15, Year = 2021, ExamOrg = "Security Printing Corp Bangladesh", Post = "Assistant Maintenance Engineer", QuestionText = "Write difference between microprocessor and microcontroller." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 16, Year = 2021, ExamOrg = "Security Printing Corp Bangladesh", Post = "Assistant Maintenance Engineer", QuestionText = "Write the difference between analog and digital circuits." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 17, Year = 2021, ExamOrg = "Security Printing Corp Bangladesh", Post = "Assistant Maintenance Engineer", QuestionText = "What is Universal gate? Draw NAND as a universal gate." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 18, Year = 2021, ExamOrg = "Security Printing Corp Bangladesh", Post = "Assistant Maintenance Engineer", QuestionText = "Write short note about (a) circuit breaker, (b) Relay." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 19, Year = 2021, ExamOrg = "AHE SBL/JBL/RBL", Post = "Assistant Hardware Engineer", QuestionText = "Simplify Boolean function using K-map: F(A,B,C,D) = Σm(3,4,5,7,9,13,14,15)" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 20, Year = 2021, ExamOrg = "AHE SBL/JBL/RBL", Post = "Assistant Hardware Engineer", QuestionText = "Difference between Impact and Non-Impact Printers." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 21, Year = 2021, ExamOrg = "AHE SBL/JBL/RBL", Post = "Assistant Hardware Engineer", QuestionText = "Paging with SSD: RAM access = 20 ns, SSD access = 10 ns per instruction, hit ratio = 75%. What is the total access time?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 22, Year = 2022, ExamOrg = "Security Printing Corp Bangladesh", Post = "Sub-Assistant Engineer", QuestionText = "Difference between data and information?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 23, Year = 2022, ExamOrg = "Security Printing Corp Bangladesh", Post = "Sub-Asst Maintenance Engineer", QuestionText = "An administrator installed a utility but it does not open automatically on startup. What is the solution?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 24, Year = 2022, ExamOrg = "ANA JBL", Post = "Assistant Network Administrator", QuestionText = "Explain the effect of increasing RAM, CPU cache memory, and BUS width on system performance." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 25, Year = 2022, ExamOrg = "SBL/BDBL", Post = "Senior Officer IT", QuestionText = "Disk pack: 16 surfaces, 128 tracks/surface, 256 sectors/track, 512 bytes/sector. (a) Capacity? (b) Bits required to address a sector? (c) Formatted space with 32 bytes/sector overhead? (d) Memory lost with 64 bytes/sector overhead?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 26, Year = 2022, ExamOrg = "SBL/BDBL", Post = "Senior Officer IT", QuestionText = "Minimize Boolean expression using K-map: F = A'B'CA'BC + A'BC'D + ABC'D + ABCD' + AB'C'D'" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 27, Year = 2022, ExamOrg = "ADA SBL/JBL", Post = "Assistant Database Administrator", QuestionText = "RAID related question (describe different RAID levels)." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 28, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Maintenance Engineer", QuestionText = "16 KB of data in a direct-mapped cache with 4 blocks. Determine the size of tag, index, and offset fields in a 32-bit architecture." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 29, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Maintenance Engineer", QuestionText = "Describe cut-off, saturation and active region of operation of a transistor with diagram. Explain working principle of an n-channel JFET with various values of V_gs and V_ds." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 30, Year = 2023, ExamOrg = "Combined 4 Bank (BIBM)", Post = "SO IT", QuestionText = "Differentiate between 32-bit and 64-bit microprocessors. Difference between Core i3, i5, i7. Write the configuration of the latest laptop. Why is SSD better than HDD?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 31, Year = 2023, ExamOrg = "Combined 4 Bank (BIBM)", Post = "SO IT", QuestionText = "Difference in CPU Register, Cache Memory, Main Memory, and Secondary Memory. What does 2.4 GHz microprocessor mean?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 32, Year = 2023, ExamOrg = "RAKUB (BIBM)", Post = "ANSE", QuestionText = "What is BIOS?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 33, Year = 2023, ExamOrg = "Rupali Bank (BIBM)", Post = "ANA", QuestionText = "What are the primary differences between data replication and data backup? Provide real-world examples." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 34, Year = 2023, ExamOrg = "Rupali Bank (BIBM)", Post = "ANA", QuestionText = "What are the key hardware components of a typical server and how do they contribute to performance and functionality?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 35, Year = 2023, ExamOrg = "Rupali Bank (BIBM)", Post = "ANA", QuestionText = "Discuss server maintenance best practices: clearing, monitoring, applying security patches. How do these practices contribute to server longevity and performance?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 36, Year = 2023, ExamOrg = "Rupali Bank (BIBM)", Post = "ANA", QuestionText = "Discuss the factors that affect the speed of CPU." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 37, Year = 2023, ExamOrg = "Combined Bank (BIBM)", Post = "Senior Officer AHE/AME", QuestionText = "Describe the important characteristics of digital ICs (Integrated Circuits)." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 38, Year = 2023, ExamOrg = "Combined Bank (BIBM)", Post = "Senior Officer AHE/AME", QuestionText = "What is memory organization? What are the physical and operational differences between SRAM and DRAM?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 39, Year = 2023, ExamOrg = "Combined Bank (BIBM)", Post = "Senior Officer AHE/AME", QuestionText = "How can disk redundancy and RAID technology help prevent data loss in banking applications? What are the different RAID levels/configurations?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 40, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "ADA", QuestionText = "Logic circuit of Boolean algebra: Q = C + AB + BC(B+C); where (A,B,C)=(0,0,1). Find Q." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 41, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "ADA", QuestionText = "What should be checked before buying servers?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 42, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "ADA", QuestionText = "During critical banking transactions, which RAID level is best and why?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 43, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "ADA", QuestionText = "Difference between incremental backup and differential backup. Which is more suitable for the banking system?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 44, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "ADA", QuestionText = "Justify \"Invention of Transistor changed the world.\"" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 45, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "AME/AE IT", QuestionText = "Difference between Multi-computer system and Multi-computer processor. What is pipelining? Explain 4 stages of the pipeline. Describe PPI." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 46, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "AME/AE IT", QuestionText = "Draw logic circuit for Boolean Expression Q=(A'B + BC(B+C)') and find Q when (A,B,C)=(1,0,1)." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 47, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "Senior Officer IT", QuestionText = "What is a microcontroller? What distinguishes it from a microprocessor? Differences between RISC and CISC microprocessors." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 48, Year = 2024, ExamOrg = "Combined 2 Bank (BIBM)", Post = "Officer IT", QuestionText = "Convert a 32-bit digital number to analogue voltage over range 0 to 3.3V using DAC. What is the resolution of the analogue output?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 49, Year = 2024, ExamOrg = "Combined 2 Bank (BIBM)", Post = "Officer IT", QuestionText = "How many total bits are required for a Direct-Mapped cache with 16 KB of data and 4-word blocks, assuming 32-bit address (word addressable) and 32-bit words?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 50, Year = 2025, ExamOrg = "Combined Bank (BIBM)", Post = "Officer IT", QuestionText = "Explain the difference between direct, immediate, and register addressing modes in the 8086/x86 microprocessor." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 51, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "Construct a Truth Table for a system that triggers Alarm (Output 1) if (Motion Detected AND Night Time) OR (Panic Button Pressed)." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 52, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "You have 4 Hard Drives of 2TB each. Calculate usable storage for RAID 0, RAID 5, and RAID 10." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 53, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "Arrange in correct chronological order of computer boot process: OS Kernel Load, BIOS/UEFI POST, MSR/GPT Lookup, User Login, Driver Initialization." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 54, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "What is a Universal Gate? Prove that the NAND Gate is a Universal Gate." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 55, Year = 2026, ExamOrg = "Sonali Bank PLC", Post = "ADA", QuestionText = "Your friend's device is slow. What steps should you take in Task Manager to investigate?" }
            };
        }
        #endregion

        #region 4. Database & SQL (50 Questions)
        private static List<PreviousYearQuestion> GetDatabaseQuestions()
        {
            const string cat = "Database & SQL";
            const int order = 4;
            return new List<PreviousYearQuestion>
            {
                new() { CategoryOrder = order, Category = cat, QuestionNo = 1, Year = 2020, ExamOrg = "BSCS Combined 2 Bank (SB&JB)", Post = "Officer IT", QuestionText = "A transaction consists of a sequence of query/update statements. List SQL statements required to end a transaction and write their functions." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 2, Year = 2020, ExamOrg = "BSCS Combined 2 Bank (SB&JB)", Post = "Officer IT", QuestionText = "Main components of SQL are DDL, DML, and DCL. Give examples of DDL, DML, and DCL commands." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 3, Year = 2020, ExamOrg = "Combined 3 Banks (SBL/BDBL)", Post = "Senior Officer IT", QuestionText = "When does a Deadlock occur and how do you prevent it in a database?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 4, Year = 2020, ExamOrg = "Combined 3 Banks (SBL/BDBL)", Post = "Senior Officer IT", QuestionText = "Classify the failure of Database Management." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 5, Year = 2020, ExamOrg = "ANE JBL", Post = "Assistant Network Engineer", QuestionText = "Design an ER diagram for a soccer club application capturing: Teams (ID, name, stadium, city), Players (number, name, DOB, start year, shirt number), Matches (host/guest, date, result), Player stats (goals, yellow/red cards). Ensure cardinalities and primary keys are clear." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 6, Year = 2020, ExamOrg = "ANE JBL", Post = "Assistant Network Engineer", QuestionText = "SQL queries on tables: Employee(emp_id, emp_name, street, emp_city, join_date), Works(emp_id, comp_name, leaves, salary, dept, man_id), Company(comp_id, comp_name, comp_city), Manager(man_id, emp_id, man_name). (i) Employees with salary between 5000–8000 (ii) Employees earning more than department average (iii) Leave count per employee (iv) Managers and employee counts." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 7, Year = 2020, ExamOrg = "Combined 3 Banks (SBL/JBL/Rakub)", Post = "SO Written", QuestionText = "SQL queries on Employees(ename,street,city), Works(ename,cname,salary,joindate), Company(cname,city), Manages(ename,mname): (i) Name/street/city working for \"First Corporation Bank\" earning >3000 (ii) Employees living in same city as their company (iii) Give First Corporation Bank employees 10% raise (iv) Companies with payroll < 100,000" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 8, Year = 2020, ExamOrg = "ADA SBL", Post = "Assistant Database Admin", QuestionText = "Design an ER diagram for a soccer club with teams, players, matches, substitutions, and exactly three referees per match (one main, two assistant). Include substitution time, referee details (ID, name, DOB, experience). Cardinalities and PKs must be clear." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 9, Year = 2021, ExamOrg = "ANE RBL", Post = "Assistant Network Engineer", QuestionText = "Draw an ER diagram for a football club: name, stadium, team of players (one club each), manager (buys players), matches (each club plays every other, date/venue/score)." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 10, Year = 2021, ExamOrg = "ANE RBL", Post = "Assistant Network Engineer", QuestionText = "SQL on Employee(employee_id, name, salary, department), Leave(employee_id, date, reason), Holiday(date, description). (i) Mapping cardinality between Employee and Holiday. (ii) Query to show all employees' leave count." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 11, Year = 2021, ExamOrg = "Security Printing Corp Bangladesh", Post = "Assistant Maintenance Engineer", QuestionText = "DBMS definition and why normalization in database?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 12, Year = 2021, ExamOrg = "Security Printing Corp Bangladesh", Post = "Assistant Maintenance Engineer", QuestionText = "Define primary key, foreign key, and unique key." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 13, Year = 2021, ExamOrg = "BSCA Sonali Bank", Post = "Officer IT", QuestionText = "Comparison and Contrast between SQL and NoSQL Database." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 14, Year = 2021, ExamOrg = "BSCA Sonali Bank", Post = "Officer IT", QuestionText = "Draw an E-R Diagram for a Railway Reservation System with passengers, Terminal, Train, Seat schemas and different attributes." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 15, Year = 2021, ExamOrg = "BSCA Sonali Bank", Post = "Officer IT", QuestionText = "Write a query to find the publisher name which location is 'Dhaka' and which book is published after 1980." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 16, Year = 2021, ExamOrg = "BSCA Sonali Bank", Post = "Officer IT", QuestionText = "Write a query to change the type of Book name 'Science' to 'Computer Science' which branch name is 'Dhaka' city." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 17, Year = 2021, ExamOrg = "ASA JBL", Post = "Assistant System Administrator", QuestionText = "SQL: Employee(Empid,Lastname,Firstname,street,city), Works(Empid,deptName,company,salary), Manager(manid,name,deptName). (i) Number of employees in each department. (ii) Give 15% salary increase to employees with salary > 20,000." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 18, Year = 2021, ExamOrg = "AHE SBL/JBL/RBL", Post = "Assistant Hardware Engineer", QuestionText = "Convert the given ER diagram (Lot, ProductionUnits, RawMaterials) into a relational database schema maintaining primary keys properly." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 19, Year = 2022, ExamOrg = "Security Printing Corp Bangladesh", Post = "Sub-Assistant Engineer", QuestionText = "What is DBMS? Write short note on Virtual memory and Cache memory." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 20, Year = 2022, ExamOrg = "ANE JBL", Post = "Assistant Network Engineer", QuestionText = "Create an ER Diagram using: TV channel, reality show, user, producer, user eating." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 21, Year = 2022, ExamOrg = "ANE JBL", Post = "Assistant Network Engineer", QuestionText = "SQL on Actor(actor_id,name,age), Play(play_id,writer), Role(play_id,actor_id). (i) Count actors who played role 3+ times written by \"Shakespeare\". (ii) Show actors who played Chekhov but never Shakespeare." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 22, Year = 2022, ExamOrg = "ANA JBL", Post = "Assistant Network Administrator", QuestionText = "DDL query to create PH_Employee table with reference keys from Employee and City tables. Also write query to get employee_id, last_name, city of employees who reported to someone one or more times." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 23, Year = 2022, ExamOrg = "SBL/BDBL", Post = "Senior Officer IT", QuestionText = "SQL queries on Worker(worker-id,worker-name,hourly-rate,skill-type,supervisor-id), Assignment(worker-id,building-id,start-date,num-days), Building(building-id,address,building-type): (a) Skill types of workers assigned to B02 (b) Workers assigned to warehouse buildings (c) No. of workers per building where >5 workers (d) Give 5% hourly wage increment to workers in hospital buildings." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 24, Year = 2022, ExamOrg = "ADA SBL/JBL", Post = "Assistant Database Administrator", QuestionText = "Draw an ER diagram of BPL (Team, Player, Game, Captain)." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 25, Year = 2022, ExamOrg = "ADA SBL/JBL", Post = "Assistant Database Administrator", QuestionText = "What is a trigger? When is it used? Write down some advantages of triggers." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 26, Year = 2022, ExamOrg = "ADA SBL/JBL", Post = "Assistant Database Administrator", QuestionText = "Write short notes on ACID properties of a database." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 27, Year = 2022, ExamOrg = "ADA SBL/JBL", Post = "Assistant Database Administrator", QuestionText = "What is a distributed database system? What are the responsibilities of a database administrator?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 28, Year = 2022, ExamOrg = "ADA SBL/JBL", Post = "Assistant Database Administrator", QuestionText = "MARKS(id, mark) table: write query to show grades (F,A,C etc.) according to marks, and another query to show number of students who got a particular grade." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 29, Year = 2022, ExamOrg = "ADA SBL/JBL", Post = "Assistant Database Administrator", QuestionText = "BCNF related question (normalize a relation to BCNF)." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 30, Year = 2022, ExamOrg = "ADA SBL/JBL", Post = "Assistant Database Administrator", QuestionText = "Weak entity type vs. strong entity type — show example in an ER diagram." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 31, Year = 2023, ExamOrg = "Combined 5 Bank (BIBM)", Post = "Officer IT", QuestionText = "Relational DB: S(sid,A), T(tid,B), U(uid,C), R(sid,tid,D), Q(tid,uid,E). R = many-to-many S–T, Q = many-to-many T–U. Write SQL query returning all (Sid, uid) records related through R and Q. Use SELECT not SELECT DISTINCT." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 32, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "SQL on Movies(mid,title,year), People(pid,name), Genres(gid,genre), ActsIn(pid,mid), HasRole(pid,mid,role), HasGenre(gid,mid). Write a query returning the number of movies which are romantic comedies." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 33, Year = 2023, ExamOrg = "Combined Bank (BIBM)", Post = "Officer IT", QuestionText = "Analyze the following SQL code: SELECT department-name, AVG(salary) FROM employees e JOIN department d ON e.department-id=d.department-id WHERE salary > (SELECT AVG(salary) FROM employees) GROUP BY department-name HAVING COUNT(*)>2 ORDER BY average-salary DESC." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 34, Year = 2023, ExamOrg = "Combined 4 Bank (BIBM)", Post = "SO IT", QuestionText = "Difference between database, data warehouse, and data mining with real-world examples." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 35, Year = 2023, ExamOrg = "RAKUB (BIBM)", Post = "ANSE", QuestionText = "Given a SQL query, write what the question (purpose) of this query is." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 36, Year = 2023, ExamOrg = "Rupali Bank (BIBM)", Post = "ANA", QuestionText = "Analyze output of SQL: SELECT department_name, AVG(salary) FROM employee e JOIN department d … WHERE salary > (SELECT AVG(salary) FROM employee WHERE department_id=d.department_id) GROUP BY department_name HAVING COUNT()>2 ORDER BY average_salary DESC." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 37, Year = 2024, ExamOrg = "Combined 5 Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "SQL on Department(DeptCode,DeptName,Location) and Employee(EmpCode,EmpFname,Salary,Commission,DeptCode): (a) Select EmpFname with total salary (salary+commission) (b) Select EmpFname, Location with salary > avg, ordered by EmpFname (c) Select EmpFname and count employees ordered ascending." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 38, Year = 2024, ExamOrg = "Combined 5 Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "Describe different types of relationships in DBMS." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 39, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "ADA", QuestionText = "Database Data Loss case study — identify and resolve using appropriate strategy." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 40, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "ADA", QuestionText = "Normalize a database, use containers if needed, draw an ERD Diagram for: Proj_Budget, Proj_Code, Proj_Manager, Emp_Code, Emp_Name, Dept_Code, Dept_Name, Salary." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 41, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "ADA", QuestionText = "Difference between MS Access and MS FoxPro in SQL or Oracle." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 42, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "ADA", QuestionText = "Case study about Database problem solved by ACID Properties." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 43, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "ADA", QuestionText = "SQL program to find interest rate from a database: if first two letters of account in the rate table match, assign same rate in EMP table. (EMP table: id, Acc, Name, Salary, AccRate)" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 44, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "Senior Officer IT", QuestionText = "Database has two tables: Customers and Orders. Explain Inner, Left, Right, and Full join. Show result sets. (Customers: 1-Rahim, 2-Karim, 3-Belal, 4-Rony, 5-Helal)" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 45, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "Senior Officer IT", QuestionText = "Briefly describe primary key, foreign key, and index in relational DB. Does database indexing always make applications faster? Explain." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 46, Year = 2024, ExamOrg = "Combined 2 Bank (BIBM)", Post = "Officer IT", QuestionText = "Pet society DB: Animals(ID,Name,PrevOwner,DateAdmitted,Type), Adopter(PSIN,Name,Address,OtherAnimals), Adoption(AnimalID,PSIN,AdoptDate,chipNo). Write SQL to list total adoptions on June 30, 2024 for each animal type." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 47, Year = 2025, ExamOrg = "Combined Bank (BIBM)", Post = "Officer IT", QuestionText = "Sales(sales_id, salesman, region, sale_amount, sale_date). Write SQL to display region, average sale amount, total number of sales for each region where average sale amount > BDT 50,183 and total sales in that region ≥ 5." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 48, Year = 2025, ExamOrg = "Combined Bank (BIBM)", Post = "Officer IT", QuestionText = "Explain ACID properties in a database transaction: Atomicity, Consistency, Isolation, Durability — how each ensures reliability and integrity." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 49, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "EMPLOYEES(ID,Name,DeptID) and DEPARTMENTS(Dept,DeptName). Write pseudo-SQL to get Employee Names who work in \"IT\"." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 50, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "You are designing a database for a Library. Explain the relationship between a \"Book\" table and a \"Borrower\" table. Is it 1-to-1, 1-to-Many, or Many-to-Many? Justify your answer." }
            };
        }
        #endregion

        #region 5. Cybersecurity (37 Questions)
        private static List<PreviousYearQuestion> GetCybersecurityQuestions()
        {
            const string cat = "Cybersecurity";
            const int order = 5;
            return new List<PreviousYearQuestion>
            {
                new() { CategoryOrder = order, Category = cat, QuestionNo = 1, Year = 2020, ExamOrg = "Combined 3 Banks (SBL/BDBL)", Post = "Senior Officer IT", QuestionText = "What is the difference between packet sniffing (Snooping) and Packet spoofing?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 2, Year = 2020, ExamOrg = "ANE JBL", Post = "Assistant Network Engineer", QuestionText = "Encrypt the message \"THIS IS A\" using a shift cipher with key = 20. Ignore spaces. Then decrypt the message to get original plaintext." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 3, Year = 2021, ExamOrg = "ASA JBL", Post = "Assistant System Administrator", QuestionText = "What is SQL injection? Give two examples of SQL injection attack. How to prevent SQL injection attacks?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 4, Year = 2021, ExamOrg = "Security Printing Corp Bangladesh", Post = "Assistant Maintenance Engineer", QuestionText = "Short note: (a) Ransomware, (b) Trojan Horse, (c) Worm" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 5, Year = 2021, ExamOrg = "BSCA Sonali Bank", Post = "Officer IT", QuestionText = "Write down firewalls role and browser cookies role." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 6, Year = 2021, ExamOrg = "BSCA Sonali Bank", Post = "Officer IT", QuestionText = "Explain DDoS and SQL injection attack." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 7, Year = 2022, ExamOrg = "Security Printing Corp Bangladesh", Post = "Sub-Assistant Engineer", QuestionText = "What is Blacklist and Whitelist? Write the difference between Blacklist and Whitelist." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 8, Year = 2022, ExamOrg = "Security Printing Corp Bangladesh", Post = "Sub-Assistant Engineer", QuestionText = "What is SQL injection? How to prevent it?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 9, Year = 2022, ExamOrg = "Security Printing Corp Bangladesh", Post = "Sub-Assistant Engineer", QuestionText = "What is Cross-Site Scripting (XSS) and how can you fix it?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 10, Year = 2022, ExamOrg = "ANA JBL", Post = "Assistant Network Administrator", QuestionText = "What are the properties of a firewall? Show diagram where firewall should be placed." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 11, Year = 2022, ExamOrg = "ANA JBL", Post = "Assistant Network Administrator", QuestionText = "In network security, define: Confidentiality, Non-repudiation, Authenticity, Integrity, Availability." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 12, Year = 2022, ExamOrg = "SBL/BDBL", Post = "Senior Officer IT", QuestionText = "Explain the problems with possible solutions: Session hijacking and SQL injection." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 13, Year = 2023, ExamOrg = "Combined 5 Bank (BIBM)", Post = "Officer IT", QuestionText = "An attacker steals the private key of a website using TLS and remains undetected. What can the attacker do using the private key?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 14, Year = 2023, ExamOrg = "Combined 5 Bank (BIBM)", Post = "Officer IT", QuestionText = "Browsers A and B from different origins. Why is it reasonable security policy to allow A to navigate B only when A's display area contains B's display? Also: LRU page replacement with reference string 12342341211314, 3 frames — find page faults." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 15, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "CIA question: end-to-end encryption — which OSI layer is suitable considering development time, software maintainability, and development cost?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 16, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "Describe a Man-in-the-Middle attack on Diffie-Hellman key exchange protocol in which the adversary generates two public key pairs." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 17, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Maintenance Engineer", QuestionText = "A bank has two payment gateway service providers. Mr. X is hired to audit based on risk and threat detection. Which possible scenarios will Mr. X face?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 18, Year = 2023, ExamOrg = "Combined Bank (BIBM)", Post = "Officer IT", QuestionText = "Write down the 10 most common cyber-attacks." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 19, Year = 2023, ExamOrg = "Combined 4 Bank (BIBM)", Post = "SO IT", QuestionText = "What is Cryptography? Difference between Symmetric and Asymmetric encryption. Draw a diagram for e-commerce online transactions using Symmetric (Public Key) Encryption." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 20, Year = 2023, ExamOrg = "RAKUB (BIBM)", Post = "ANSE", QuestionText = "What is digital signature? Write about CIA. Draw a diagram of public key encryption (asymmetric)." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 21, Year = 2023, ExamOrg = "Rupali Bank (BIBM)", Post = "ANA", QuestionText = "Draw a diagram of LAN including network Firewall. Why is firewall important in network security? List major types of firewalls. Difference between Traditional Firewall and Next-Generation Firewall." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 22, Year = 2023, ExamOrg = "Rupali Bank (BIBM)", Post = "ANA", QuestionText = "Distinguish between Symmetric and Asymmetric Encryption. Give encryption algorithm examples. What are the different types of ciphers in cryptography? Factors to consider for cryptographic strength?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 23, Year = 2023, ExamOrg = "Combined Bank (BIBM)", Post = "Senior Officer AHE/AME", QuestionText = "Describe the importance of DMZ in computer networking, especially for hosting a digital banking system." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 24, Year = 2023, ExamOrg = "Combined Bank (BIBM)", Post = "Senior Officer AHE/AME", QuestionText = "How are encryption and decryption related to cybersecurity? Describe the RSA algorithm for public key encryption and the math behind RSA. (Hint: p=13, q=17, public key=35 → find private key)" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 25, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "ADA", QuestionText = "How to ensure secure communication between a client application and the database server." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 26, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "AME/AE IT", QuestionText = "Your bank wants to secure an e-banking online system and configure a web server in your data center. What tools and technology do you use?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 27, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "Senior Officer IT", QuestionText = "You procure a microfinance application and host it in your data center. What cyber-security threats should you be aware of and how to mitigate them?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 28, Year = 2025, ExamOrg = "Combined Bank (BIBM)", Post = "Officer IT", QuestionText = "Describe how CIA principles (Confidentiality, Integrity, Availability) work together to protect organizational data. Provide one real-world example of a security breach." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 29, Year = 2025, ExamOrg = "Combined Bank (BIBM)", Post = "Officer IT", QuestionText = "A banking app requires a 4-digit PIN for login. Explain how to test this input field (valid 4-digit only, reject invalid). Mention test cases and explain why such testing is important." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 30, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "What is authentication and authorization? What is the CIA triad in cyber security?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 31, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "What is social engineering? What is hashing? How is it different from encryption? What is vulnerability assessment?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 32, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "A new employee joins the bank. Describe the process of creating a new user account focusing on security best practices (e.g., password policies)." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 33, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "User X belongs to Group A and Group B. Folder grants \"Read\" to Group A, \"Explicit Deny Write\" to Group B, \"Write\" to User X individually. Can User X write to Folder? Explain Explicit Deny vs Explicit Allow precedence logic." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 34, Year = 2026, ExamOrg = "Sonali Bank PLC", Post = "ADA", QuestionText = "Your workstation is affected by a ransomware attack. What five steps do you take to mitigate this problem?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 35, Year = 2026, ExamOrg = "Sonali Bank PLC", Post = "ADA", QuestionText = "What is Phishing? Describe different types of phishing attacks." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 36, Year = 2026, ExamOrg = "Sonali Bank PLC", Post = "ADA", QuestionText = "What is a firewall? Difference between stateful inspection and Next-Generation Firewall (NGFW)." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 37, Year = 2026, ExamOrg = "Sonali Bank PLC", Post = "ADA", QuestionText = "Firewall rules: Rule 1=port 89, Rule 2=port<443, Rule 3=port 443. When a packet comes from port 443, is it accepted or rejected? Explain \"First inspection rules\"." }
            };
        }
        #endregion

        #region 6. Software Engineering (24 Questions)
        private static List<PreviousYearQuestion> GetSoftwareEngineeringQuestions()
        {
            const string cat = "Software Engineering";
            const int order = 6;
            return new List<PreviousYearQuestion>
            {
                new() { CategoryOrder = order, Category = cat, QuestionNo = 1, Year = 2020, ExamOrg = "BSCS Combined 2 Bank (SB&JB)", Post = "Officer IT", QuestionText = "Testing is an activity performed to verify correct behavior of a program. Describe different types of tests conducted in the implementation stage." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 2, Year = 2020, ExamOrg = "Combined 3 Banks (SBL/BDBL)", Post = "Senior Officer IT", QuestionText = "Write the different approaches of debugging a code." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 3, Year = 2021, ExamOrg = "ASA JBL", Post = "Assistant System Administrator", QuestionText = "Draw a DFA diagram to identify all valid file names. A file name is a non-empty string starting with underscore or alphanumeric only." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 4, Year = 2022, ExamOrg = "ANE JBL", Post = "Assistant Network Engineer", QuestionText = "Difference between Waterfall model and Spiral model. Which model is preferable in software development and why?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 5, Year = 2022, ExamOrg = "ANE JBL", Post = "Assistant Network Engineer", QuestionText = "Construct FA on {0,1} which accepts even number of 1's and even number of 0's." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 6, Year = 2022, ExamOrg = "SBL/BDBL", Post = "Senior Officer IT", QuestionText = "Draw DFA of a string with at least two b's." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 7, Year = 2023, ExamOrg = "Combined 5 Bank (BIBM)", Post = "Officer IT", QuestionText = "Software project: UFP=180, value-added factor=0.87, performance factor=4. Find required effort in person-months." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 8, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Maintenance Engineer", QuestionText = "Verification and validation are two process areas at CMMI level 3. Provide (a) definition (b) description of how to fulfill these areas in software testing activities." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 9, Year = 2023, ExamOrg = "Combined Bank (BIBM)", Post = "Officer IT", QuestionText = "Which SDLC do you prefer between Agile and Waterfall? Explain with an example." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 10, Year = 2023, ExamOrg = "Combined 4 Bank (BIBM)", Post = "SO IT", QuestionText = "What is project management? If you are a project manager, what are the approaches to complete a project?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 11, Year = 2023, ExamOrg = "Combined 4 Bank (BIBM)", Post = "SO IT", QuestionText = "What is platform-independent software? Give an example." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 12, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "Senior Officer IT", QuestionText = "What is Software Quality Assurance (SQA)? As an SQA team leader purchasing a software system, what aspects will you look into for quality software?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 13, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "Senior Officer IT", QuestionText = "Lead a team to develop and deploy software fast. Between Waterfall and Incremental approach, which do you choose? Explain." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 14, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "Senior Officer IT", QuestionText = "What is machine learning? Difference between supervised, unsupervised, and reinforcement learning." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 15, Year = 2024, ExamOrg = "Combined 2 Bank (BIBM)", Post = "Officer IT", QuestionText = "Consider a \"buy a product\" use case (browse, select, checkout, shipping, payment, authorization, confirmation). Draw a use case diagram." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 16, Year = 2025, ExamOrg = "Combined Bank (BIBM)", Post = "Officer IT", QuestionText = "Explain Reinforcement Learning (RL), Deep Learning (DL), and Federated Learning (FL). Describe how each differs in learning mechanism, data usage, and real-world applications." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 17, Year = 2025, ExamOrg = "Combined Bank (BIBM)", Post = "Officer IT", QuestionText = "A government agency is developing an AI-based citizen service chatbot. Explain how Generative AI can power it, and how Explainable AI (XAI) ensures transparent, reliable, accountable responses." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 18, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "What is the difference between functional and non-functional requirements? What is requirement validation?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 19, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "Critically analyze the limitations of the Waterfall model and explain how Agile methodologies address those limitations." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 20, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "Explain the Software Development Life Cycle (SDLC) and describe its main phases." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 21, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "What is Version Control (e.g., Git)? Explain the specific difference between \"Committing\" code and \"Pushing\" code." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 22, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "Construct a logical argument explaining why a heuristic (like A* search) might be faster than a blind search (like BFS), even if it doesn't guarantee the absolute perfect path in all cases." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 23, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "Compare and contrast the three fundamental paradigms of Machine Learning: Supervised Learning, Unsupervised Learning, and Reinforcement Learning." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 24, Year = 2026, ExamOrg = "Sonali Bank PLC", Post = "ADA", QuestionText = "Define software testing levels: unit, integration, system, and user acceptance testing. How are these complementary to each other?" }
            };
        }
        #endregion

        #region 7. Data Structures (22 Questions)
        private static List<PreviousYearQuestion> GetDataStructuresQuestions()
        {
            const string cat = "Data Structures";
            const int order = 7;
            return new List<PreviousYearQuestion>
            {
                new() { CategoryOrder = order, Category = cat, QuestionNo = 1, Year = 2020, ExamOrg = "BSCS Combined 2 Bank (SB&JB)", Post = "Officer IT", QuestionText = "Queue is an abstract data structure. Write the steps of the Enqueue operation of Queue." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 2, Year = 2020, ExamOrg = "Combined 3 Banks (SBL/BDBL)", Post = "Senior Officer IT", QuestionText = "Explain operation of Binary Search Tree (BST)." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 3, Year = 2020, ExamOrg = "ANE JBL", Post = "Assistant Network Engineer", QuestionText = "Given In-order: 10,20,40,50,60,70,90,100 and Pre-order: 50,20,10,40,70,60,90,100. (i) Construct BST. (ii) Write pseudocode for the sum of all nodes." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 4, Year = 2020, ExamOrg = "ADA SBL", Post = "Assistant Database Admin", QuestionText = "Construct Binary Search Tree (BST) for: 4, 7, 5, 1, 3, 9, 10, 8, 12. Show all steps." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 5, Year = 2021, ExamOrg = "ANE RBL", Post = "Assistant Network Engineer", QuestionText = "Construct a binary tree from In-order: 4,2,1,7,5,8,3,6 and Pre-order: 1,2,4,3,5,7,8,6." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 6, Year = 2022, ExamOrg = "Security Printing Corp Bangladesh", Post = "Sub-Assistant Engineer", QuestionText = "Difference between LIFO and FIFO in data structure." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 7, Year = 2022, ExamOrg = "ANA JBL", Post = "Assistant Network Administrator", QuestionText = "Write adjacency matrix and adjacency list for a given graph. Calculate in-degree and out-degrees of all vertices." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 8, Year = 2022, ExamOrg = "SBL/BDBL", Post = "Senior Officer IT", QuestionText = "Construct a binary tree from Preorder: {1,2,4,5,3,6,8,9,7} and Postorder: {4,5,2,8,9,6,7,3,1}." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 9, Year = 2022, ExamOrg = "ADA SBL/JBL", Post = "Assistant Database Administrator", QuestionText = "How is hashing done for a set of numbers using f(x)=x mod 10? Show the process in diagrams and the resulting hash table." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 10, Year = 2023, ExamOrg = "Combined 5 Bank (BIBM)", Post = "Officer IT", QuestionText = "Max Heap operations [a–j] showing after each: Insert 5, Insert 6, Insert 8, Extract-Root, Insert 4, Insert 11, Extract-Root, Insert 7, Extract-Root, Extract-Root. Show which value is returned when root is extracted each time." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 11, Year = 2023, ExamOrg = "Combined 5 Bank (BIBM)", Post = "Officer IT", QuestionText = "Consider two representations of a directed graph. Which problem is solved more efficiently by adjacency list vs. adjacency matrix?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 12, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "Hash table of size 13, h(k)=k mod 13. Insert keys 10,3,5,6,16,17,19 using linear probing to resolve collisions. Show all work." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 13, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "Give an adjacency-list representation for a complete binary tree on 7 vertices. Give equivalent adjacency-matrix representation. Vertices numbered 1–7 as in a binary heap." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 14, Year = 2024, ExamOrg = "Combined 5 Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "Difference between stack and queue. Write two uses for each." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 15, Year = 2024, ExamOrg = "Combined 2 Bank (BIBM)", Post = "Officer IT", QuestionText = "Convert infix expression P = 12/(7-3)+2 to postfix and evaluate it." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 16, Year = 2024, ExamOrg = "Combined 2 Bank (BIBM)", Post = "Officer IT", QuestionText = "Explain the difference between a singly linked list and a doubly linked list." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 17, Year = 2024, ExamOrg = "Combined 2 Bank (BIBM)", Post = "Officer IT", QuestionText = "Describe and estimate the costs of inserting a new item into an existing binary max heap." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 18, Year = 2025, ExamOrg = "Combined Bank (BIBM)", Post = "Officer IT", QuestionText = "Determine whether the following pair of graphs are isomorphic and justify your answer in one sentence." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 19, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "Describe step-by-step how Binary Search locates a target value in a sorted array. Why does it fail if the array is unsorted?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 20, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "You have two stacks. Explain the logic required to implement a Queue (FIFO) using only these two stacks." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 21, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "Explain the logic of Bubble Sort. Why is it considered inefficient for large datasets compared to Merge Sort?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 22, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "Draw or describe a Flowchart to determine the largest of three distinct numbers A, B, C." }
            };
        }
        #endregion

        #region 8. Operating Systems (18 Questions)
        private static List<PreviousYearQuestion> GetOperatingSystemsQuestions()
        {
            const string cat = "Operating Systems";
            const int order = 8;
            return new List<PreviousYearQuestion>
            {
                new() { CategoryOrder = order, Category = cat, QuestionNo = 1, Year = 2020, ExamOrg = "BSCS Combined 2 Bank (SB&JB)", Post = "Officer IT", QuestionText = "List and briefly define the major types of OS scheduling (OS scheduling is the key concept of multiprogramming)." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 2, Year = 2021, ExamOrg = "ANE RBL", Post = "Assistant Network Engineer", QuestionText = "Processes: A(arr=0,exec=10), B(arr=3,exec=7), C(arr=5,exec=3), D(arr=8,exec=5). Find average waiting time for FCFS, Preemptive SJF, and Round Robin (quantum=3)." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 3, Year = 2021, ExamOrg = "ASA JBL", Post = "Assistant System Administrator", QuestionText = "What is Deadlock? Explain two deadlock situations with system resources." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 4, Year = 2021, ExamOrg = "ASA JBL", Post = "Assistant System Administrator", QuestionText = "A system has 4 periodic events with periods 50,100,200,250 ms requiring 35,20,10,x ms of CPU. What is the largest value of x for which the system is schedulable?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 5, Year = 2021, ExamOrg = "ASA JBL", Post = "Assistant System Administrator", QuestionText = "5 processes: A(arr=3,exec=1), B(arr=1,exec=4), C(arr=4,exec=2), D(arr=0,exec=6), E(arr=2,exec=3). CPU scheduling is SJF. Calculate average waiting time." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 6, Year = 2021, ExamOrg = "ASA JBL", Post = "Assistant System Administrator", QuestionText = "Shell script: (i) Create folder \"A\" with read-only permission. (ii) Copy contents of folder \"P\" to a directory of a subfolder with the same name as the current folder." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 7, Year = 2021, ExamOrg = "ASA JBL", Post = "Assistant System Administrator", QuestionText = "Memory partitions: 100,500,200,300,600 KB. First-fit and best-fit for processes 212,417,112,426 KB. Which algorithm makes most efficient use of memory?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 8, Year = 2021, ExamOrg = "AHE SBL/JBL/RBL", Post = "Assistant Hardware Engineer", QuestionText = "CPU scheduling Round Robin (quantum=3): given arrival and burst times. Calculate average waiting time." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 9, Year = 2021, ExamOrg = "AHE SBL/JBL/RBL", Post = "Assistant Hardware Engineer", QuestionText = "How do swapping and virtual memory help in memory management system?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 10, Year = 2022, ExamOrg = "Security Printing Corp Bangladesh", Post = "Sub-Assistant Engineer", QuestionText = "What is kernel? Write down objectives of kernel." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 11, Year = 2022, ExamOrg = "ADA SBL/JBL", Post = "Assistant Database Administrator", QuestionText = "UNIX CLI: how to show hidden files in a directory." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 12, Year = 2023, ExamOrg = "Combined Bank (BIBM)", Post = "Senior Officer AHE/AME", QuestionText = "Differentiate between physical memory and virtual memory; also describe advantages and disadvantages of virtual memory." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 13, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "AME/AE IT", QuestionText = "Define: socket, kernel, process, program, multiprogramming, context switching. Discuss LRU and NRU Page Replacement Algorithms. Illustrate Preemptive Priority scheduling." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 14, Year = 2024, ExamOrg = "Combined 2 Bank (BIBM)", Post = "Officer IT", QuestionText = "Give the necessary condition for deadlock. Is it possible to have deadlock involving only a single process? Explain." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 15, Year = 2025, ExamOrg = "Combined Bank (BIBM)", Post = "Officer IT", QuestionText = "Logical address space of 512 pages, 2-KB page size, mapped onto 128 frames. (a) Bits required in logical address? (b) Bits required in physical address?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 16, Year = 2025, ExamOrg = "Combined Bank (BIBM)", Post = "Officer IT", QuestionText = "Explain the concept of thrashing in an OS: how it occurs in a demand-paged virtual memory system and how it impacts CPU utilization and system performance." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 17, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "Explain the fundamental difference between a Process and a Thread. Provide two distinct advantages of using threads over processes." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 18, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "Explain the \"Producer-Consumer\" problem in operating systems. What specific synchronization issue must be solved?" }
            };
        }
        #endregion

        #region 9. Banking & Digital Finance (15 Questions)
        private static List<PreviousYearQuestion> GetBankingQuestions()
        {
            const string cat = "Banking & Digital Finance";
            const int order = 9;
            return new List<PreviousYearQuestion>
            {
                new() { CategoryOrder = order, Category = cat, QuestionNo = 1, Year = 2020, ExamOrg = "BSCS Combined 2 Bank (SB&JB)", Post = "Officer IT", QuestionText = "Make a list of banking software used in Bangladesh. List the essential features for successful Banking Software and Apps." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 2, Year = 2020, ExamOrg = "ANE JBL", Post = "Assistant Network Engineer", QuestionText = "Write about the Role of Information Technology (IT) in the Banking Sector." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 3, Year = 2021, ExamOrg = "ASA JBL", Post = "Assistant System Administrator", QuestionText = "Write down the role of System Administrator." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 4, Year = 2021, ExamOrg = "AHE SBL/JBL/RBL", Post = "Assistant Hardware Engineer", QuestionText = "Write down the different types of e-commerce." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 5, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "Write about the growing use of technology in the Financial Service Industry." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 6, Year = 2023, ExamOrg = "Combined Bank (BIBM)", Post = "Officer IT", QuestionText = "Scenario-based question: server-related problems — how do you handle them for your company?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 7, Year = 2023, ExamOrg = "Combined 4 Bank (BIBM)", Post = "SO IT", QuestionText = "What is blockchain? How it works, benefits of blockchain, usage of blockchain." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 8, Year = 2023, ExamOrg = "Combined 4 Bank (BIBM)", Post = "SO IT", QuestionText = "Difference between Digital Banking System and Traditional Banking System." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 9, Year = 2023, ExamOrg = "Combined Bank (BIBM)", Post = "Senior Officer AHE/AME", QuestionText = "What is digital banking and how does it differ from traditional banking? How can digital banking promote financial inclusion?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 10, Year = 2023, ExamOrg = "Combined Bank (BIBM)", Post = "Senior Officer AHE/AME", QuestionText = "Describe the typical web application deployment architecture and explain how components interact during deployment." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 11, Year = 2023, ExamOrg = "Combined Bank (BIBM)", Post = "Senior Officer AHE/AME", QuestionText = "For a digital banking solution, describe the steps to comply with information system audit and control policies." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 12, Year = 2024, ExamOrg = "Combined 5 Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "About a real-life software project you built. What problems/challenges did you face and how did you solve them?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 13, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "AME/AE IT", QuestionText = "Describe the transformative power of ICT with ten innovative applications for the online banking system." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 14, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "AME/AE IT", QuestionText = "What is policy, guideline, and procedure? Why should the auditor maintain control as policy? Explain different types of audit risks." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 15, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "Senior Officer IT", QuestionText = "What is an IT disaster recovery plan? Describe your approach to disaster recovery and business continuity planning for the data center." }
            };
        }
        #endregion

        #region 10. Focus / Essay / Translation (15 Questions)
        private static List<PreviousYearQuestion> GetFocusEssayQuestions()
        {
            const string cat = "Focus / Essay / Translation";
            const int order = 10;
            return new List<PreviousYearQuestion>
            {
                new() { CategoryOrder = order, Category = cat, QuestionNo = 1, Year = 2020, ExamOrg = "BSCS Combined 2 Bank (SB&JB)", Post = "Officer IT", QuestionText = "Write a short essay (Bangla): COVID-19 এর ক্ষতিকর প্রভাব মোকাবেলায় তথ্যপ্রযুক্তির প্রয়োগ ও ভূমিকা।" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 2, Year = 2020, ExamOrg = "BSCS Combined 2 Bank (SB&JB)", Post = "Officer IT", QuestionText = "Translate into English: Bangla passage about COVID-19 vaccine procurement (17,000 crore doses needed for 16.5 crore population)." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 3, Year = 2020, ExamOrg = "BSCS Combined 2 Bank (SB&JB)", Post = "Officer IT", QuestionText = "Translate into Bengali: English passage about Nobel Medicine Prize for Hepatitis C discovery (Harvey Alter, Charles Rice, Michael Houghton)." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 4, Year = 2020, ExamOrg = "BSCS Combined 2 Bank (SB&JB)", Post = "Officer IT", QuestionText = "Write a paragraph on \"Post-corona Green Recovery Plans and Progress in Bangladesh\" in English." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 5, Year = 2020, ExamOrg = "ANE JBL", Post = "Assistant Network Engineer", QuestionText = "Write an essay (Bangla): জলবায়ু পরিবর্তন ও বাংলাদেশে এর প্রভাব (Climate change and its impact on Bangladesh)." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 6, Year = 2021, ExamOrg = "ANE RBL", Post = "Assistant Network Engineer", QuestionText = "Write an essay (Bangla): স্বল্পোন্নত থেকে উন্নয়নশীল দেশে উত্তরণে বাংলাদেশ (Bangladesh's graduation from LDC to developing country)." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 7, Year = 2021, ExamOrg = "ANE RBL", Post = "Assistant Network Engineer", QuestionText = "Write an essay / focus writing (English): Confront rumors on social media." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 8, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "Write an Essay in Bangla: দুর্নীতিমুক্ত দেশ গঠনে যুবসমাজের ভূমিকা (Role of youth in building a corruption-free country)." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 9, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "Write an Essay in English: Online Banking." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 10, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "Translate into English: Bangla passage about Google Drive features for office/study use." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 11, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "Translate into Bangla: English passage about fertilizer crisis for farmers in Bangladesh." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 12, Year = 2026, ExamOrg = "BSCS AP (BIBM/CTI)", Post = "Assistant Programmer", QuestionText = "Focus Writing in Bangla: বাংলাদেশের ব্যাংকিং খাতে কৃত্রিম বুদ্ধিমত্তার প্রয়োগ কীভাবে কার্যক্রমের দক্ষতা ও নিরাপত্তা বৃদ্ধি করতে পারে? সম্ভাব্য ঝুঁকি ও নৈতিক চ্যালেঞ্জসমূহ বিশ্লেষণ করুন।" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 13, Year = 2026, ExamOrg = "BSCS AP (BIBM/CTI)", Post = "Assistant Programmer", QuestionText = "Focus Writing in English: Why are data privacy and regulatory compliance (AML, KYC, international data-protection standards) vital for the stability and credibility of the banking sector in Bangladesh? Discuss with examples and recommendations." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 14, Year = 2026, ExamOrg = "BSCS AP (BIBM/CTI)", Post = "Assistant Programmer", QuestionText = "Translation Bangla to English: Passage about NEET youth (not in education, employment, or training) and its economic/social impact in Bangladesh." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 15, Year = 2026, ExamOrg = "BSCS AP (BIBM/CTI)", Post = "Assistant Programmer", QuestionText = "Translation English to Bangla: Passage about the ongoing war in Gaza and its humanitarian crisis." }
            };
        }
        #endregion

        #region 11. OOP Concepts (12 Questions)
        private static List<PreviousYearQuestion> GetOopQuestions()
        {
            const string cat = "OOP Concepts";
            const int order = 11;
            return new List<PreviousYearQuestion>
            {
                new() { CategoryOrder = order, Category = cat, QuestionNo = 1, Year = 2020, ExamOrg = "BSCS Combined 2 Bank (SB&JB)", Post = "Officer IT", QuestionText = "Inheritance is one of the important issues for OOP. Explain in brief different types of inheritance." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 2, Year = 2021, ExamOrg = "AHE SBL/JBL/RBL", Post = "Assistant Hardware Engineer", QuestionText = "Difference between Object Oriented Programming and Procedural Oriented Programming." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 3, Year = 2021, ExamOrg = "AHE SBL/JBL/RBL", Post = "Assistant Hardware Engineer", QuestionText = "Explain method overloading and method overriding." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 4, Year = 2022, ExamOrg = "ANE JBL", Post = "Assistant Network Engineer", QuestionText = "Explain OOP concepts with proper examples." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 5, Year = 2023, ExamOrg = "Combined 5 Bank (BIBM)", Post = "Officer IT", QuestionText = "Draw a class diagram for a Book: composed of parts → chapters → sections. Book has publisher, publication date, ISBN. Part has title and number. Chapter has title, number, abstract. Section has title and number." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 6, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "Draw a class diagram for a token-ring LAN: nodes (workstations, servers, printers), packets (originator, destination, content), circular configuration." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 7, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "Determine overloading method, overridden method, and hidden super class method from given Java code (class A and class B extends A)." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 8, Year = 2024, ExamOrg = "Combined 5 Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "What is polymorphism? Describe different types of polymorphism." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 9, Year = 2024, ExamOrg = "Combined 2 Bank (BIBM)", Post = "Officer IT", QuestionText = "Explain how encapsulation and inheritance are advantageous in OOP." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 10, Year = 2024, ExamOrg = "Combined 2 Bank (BIBM)", Post = "Officer IT", QuestionText = "Design a Circle class that: is translatable from its origin, gives perimeter and area. Identify data and method requirements and give data flow of the translation method." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 11, Year = 2025, ExamOrg = "Combined Bank (BIBM)", Post = "Officer IT", QuestionText = "Write a program using OOP (C++/Java/Python) representing a Bank Account with: data members (account holder name, account number, balance), methods (deposit, withdraw ensuring sufficient balance, display). Demonstrate encapsulation." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 12, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "Explain the concept of inheritance in OOP. Name and briefly describe three common types of inheritance." }
            };
        }
        #endregion

        #region 12. Cloud & Virtualization (9 Questions)
        private static List<PreviousYearQuestion> GetCloudQuestions()
        {
            const string cat = "Cloud & Virtualization";
            const int order = 12;
            return new List<PreviousYearQuestion>
            {
                new() { CategoryOrder = order, Category = cat, QuestionNo = 1, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Maintenance Engineer", QuestionText = "Explain IaaS, PaaS, and SaaS with respect to cloud computing." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 2, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Maintenance Engineer", QuestionText = "Define a virtual machine with a neat diagram. Explain the working of VM. What are the benefits of a VM?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 3, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Maintenance Engineer", QuestionText = "What are the challenges in optimizing energy efficiency of data centers? Explain." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 4, Year = 2023, ExamOrg = "RAKUB (BIBM)", Post = "ANSE", QuestionText = "Write about Hypervisor." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 5, Year = 2023, ExamOrg = "Combined Bank (BIBM)", Post = "Senior Officer AHE/AME", QuestionText = "You want to host a new banking solution in a data center. Describe the most important factors for purchasing decisions for the data center." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 6, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "AME/AE IT", QuestionText = "Your bank wants to transform the full data center into a cloud. Sketch your strategy and plan to implement this procedure." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 7, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "Senior Officer IT", QuestionText = "What is SaaS and multi-tenant architecture? How are they related? Advantages and disadvantages of multi-tenancy? For a multi-vendor e-commerce app, single DB vs separate DB per vendor — which to choose and why?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 8, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "What is cloud computing? Mention its service models (IaaS, PaaS, SaaS)." },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 9, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "Define Virtualization. Explain the role of the Hypervisor and the difference between a Virtual Machine (VM) and a container." }
            };
        }
        #endregion

        #region 13. Math & Number Systems (3 Questions)
        private static List<PreviousYearQuestion> GetMathQuestions()
        {
            const string cat = "Math & Number Systems";
            const int order = 13;
            return new List<PreviousYearQuestion>
            {
                new() { CategoryOrder = order, Category = cat, QuestionNo = 1, Year = 2020, ExamOrg = "BSCS Combined 2 Bank (SB&JB)", Post = "Officer IT", QuestionText = "Number system conversions: (i) Convert (10010.101)₂ = (?)₁₀ (ii) Convert (543)₁₀ = (?)₁₆" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 2, Year = 2024, ExamOrg = "Combined 2 Bank (BIBM)", Post = "Officer IT", QuestionText = "Find sets X and Y if XUY={1,2,3,5,6,8,9,10}, X∩Y={1,5}, Y−X={2,6,9,10}" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 3, Year = 2024, ExamOrg = "Combined 2 Bank (BIBM)", Post = "Officer IT", QuestionText = "If you throw two unbiased dice together, what is the probability that the sum of upward faces is 7? Explain." }
            };
        }
        #endregion

        #region 14. General Knowledge (2 Questions)
        private static List<PreviousYearQuestion> GetGkQuestions()
        {
            const string cat = "General Knowledge";
            const int order = 14;
            return new List<PreviousYearQuestion>
            {
                new() { CategoryOrder = order, Category = cat, QuestionNo = 1, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "GK: (i) First earthquake observation centre in Bangladesh (ii) Full form of WIPO (iii) Year VAT introduced in Bangladesh (iv) First bank owned by Bengali Entrepreneurs (v) CIRDAP location (vi) Who invented dynamite? (vii) Men's singles ITTF world championship 2025 winner's country (viii) Number of OSI layers (ix) Meaning of \"Terracotta\" (x) Which org offered GSP+?" },
                new() { CategoryOrder = order, Category = cat, QuestionNo = 2, Year = 2026, ExamOrg = "BSCS AP (BIBM/CTI)", Post = "Assistant Programmer", QuestionText = "Evaluate the challenges and prospects of managing the Rohingya refugee crisis in Bangladesh. How important is international cooperation, and what reforms should be prioritized?" }
            };
        }
        #endregion
    }
}

