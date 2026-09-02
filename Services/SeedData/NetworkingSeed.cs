using ITSoftware.Models;

namespace ITSoftware.Services
{
    public static partial class PreviousYearQuestionSeeder
    {
        #region 1. Networking & Data Communication
        private static List<PreviousYearQuestion> GetNetworkingQuestions()
        {
            const string cat = "Networking & Data Communication";
            const int order = 1;
            return new List<PreviousYearQuestion>
            {
                // ── 1. BB AD (ICT) 2025: Web Server vs Scripting Language ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2025, ExamOrg = "Bangladesh Bank (DU)", Post = "Assistant Director (ICT)", 
                    QuestionText = "[MCQ] Which of the following is not a web server?\n(a) Apache tomcat (b) PHP (c) Jetty (d) Tornado\nAns: (b) PHP",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
সহজ উপমা:
একটি রেস্তোরাঁর কথা চিন্তা করুন—
• Web Server হলো রেস্তোরাঁর 'ওয়েটার/ম্যানেজার'। কাস্টমার (ব্রাউজার) যখন কোনো মেন্যু (HTML পেজ) দেখতে চায়, ওয়েটার কিচেন থেকে খাবার এনে কাস্টমারের টেবিলে পরিবেশন (Serve) করে। যেমন: Apache Tomcat, Jetty, Nginx, Tornado।
• PHP হলো কিচেনের 'বাবুর্চি বা রান্নার রেসিপি' (Programming/Scripting Language)। সে খাবার তৈরি করে, কিন্তু সরাসরি টেবিল পর্যন্ত নিয়ে যাওয়ার কাজ ওয়েটারের (Web Server-এর)।
অতএব, PHP কোনো ওয়েব সার্ভার নয়; এটি একটি সার্ভার-সাইড প্রোগ্রামিং ল্যাঙ্গুয়েজ।

🇬🇧 English Exam Answer:
• Answer: (b) PHP
• Explanation: 
  - Apache Tomcat and Jetty are Java-based HTTP web servers and servlet containers.
  - Tornado is a Python-based asynchronous web server and networking framework.
  - PHP (Hypertext Preprocessor) is a server-side scripting language, not a web server. It requires an HTTP server (e.g., Apache, Nginx) to execute scripts and serve responses."
                },

                // ── 2. BB AD (ICT) 2025: HTTP Status Codes ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2025, ExamOrg = "Bangladesh Bank (DU)", Post = "Assistant Director (ICT)", 
                    QuestionText = "[MCQ] What does HTTP Status Code 500 indicate?\n(a) Bad Request (b) Unauthorized Access (c) Internal Server Error (d) Not Found\nAns: (c) Internal Server Error",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
মনে রাখার সহজ ট্রিক:
• 1xx (তথ্যমূলক / Info): 'দাঁড়ান, আপনার রিকোয়েস্ট নিয়ে কাজ করছি।'
• 2xx (সফল / Success): যেমন `200 OK` — 'সব ঠিক আছে, এই নিন আপনার পেজ।'
• 3xx (পুনর্নির্দেশ / Redirect): যেমন `301 Moved` — 'দোকান অন্য ঠিকানায় স্থানান্তরিত হয়েছে।'
• 4xx (ইউজারের ভুল / Client Error): যেমন `404 Not Found` — আপনি ভুল লিংকে গেছেন, পেজটি নেই; `401 Unauthorized` — লগইন না করে ঢোকার চেষ্টা।
• 5xx (সার্ভারের সমস্যা / Server Error): যেমন `500 Internal Server Error` — ইউজারের কোনো দোষ নেই, কিন্তু সার্ভারের ভেতরের কোড ক্র্যাশ করেছে বা ডাটাবেজ ফেইল করেছে।

🇬🇧 English Exam Answer:
• Answer: (c) Internal Server Error
• Explanation:
  - 1xx: Informational (e.g., 100 Continue)
  - 2xx: Success (e.g., 200 OK)
  - 3xx: Redirection (e.g., 301 Moved Permanently)
  - 4xx: Client-Side Errors (e.g., 400 Bad Request, 401 Unauthorized, 404 Not Found)
  - 5xx: Server-Side Errors (e.g., 500 Internal Server Error indicating an unexpected condition preventing the server from fulfilling the request, 502 Bad Gateway, 503 Service Unavailable)."
                },

                // ── 3. BB AD (ICT) 2025: Total Network Latency Calculation ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2025, ExamOrg = "Bangladesh Bank (DU)", Post = "Assistant Director (ICT)", 
                    QuestionText = "What is Total Latency for a 3-kbyte message (an e-mail) if the bandwidth of the network is 1Gbps? Assume that the distance between the sender and the receiver is 300 km and that light travels at 2 x 10^8 m/s. Round Trip Time 50ms, Queuing Time 5ms.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Step-by-Step):
নেটওয়ার্ক লেটেন্সি মানে ডাটা প্রেরক থেকে প্রাপকের কাছে পৌঁছাতে মোট কত সময় লাগে। এটি মূলত ৪টি সময়ের যোগফল:
Total Delay = Transmission Delay + Propagation Delay + Queuing Delay + Processing Delay

সহজ উপমা:
একটি পণ্য ট্রাকে তুলে অন্য শহরে পাঠানো:
১. ট্রাকে মালামাল তুলতে যে সময় লাগে = Transmission Delay (ডাটার সাইজ / ইন্টারনেটের স্পিড)
   - ডাটা সাইজ = 3 KB = $3 \times 8 \times 1024 = 24,576\text{ bits}$
   - স্পিড (Bandwidth) = 1 Gbps = $10^9\text{ bps}$
   - $D_{trans} = \frac{24576}{10^9} = 0.000024576\text{ s} = \mathbf{0.0246\text{ ms}}$
২. ট্রাকের এক শহর থেকে অন্য শহরে যেতে রাস্তার সময় = Propagation Delay (দূরত্ব / আলোর গতি)
   - দূরত্ব = $300\text{ km} = 300,000\text{ m}$
   - আলোর গতি = $2 \times 10^8\text{ m/s}$
   - $D_{prop} = \frac{300000}{2 \times 10^8} = 0.0015\text{ s} = \mathbf{1.5\text{ ms}}$
৩. টোল প্লাজার জ্যামে অপেক্ষার সময় = Queuing Delay = $\mathbf{5\text{ ms}}$ (দেওয়া আছে)

অতএব, মোট একমুখী লেটেন্সি = $0.0246\text{ ms} + 1.5\text{ ms} + 5\text{ ms} = \mathbf{6.5246\text{ ms}}$।
(যদি RTT অর্থাৎ কানেকশন শুরুর ৫০ ms সহ ধরা হয়, তবে মোট সময় = $50 + 6.5246 = \mathbf{56.5246\text{ ms}}$)।

🇬🇧 English Exam Answer:
• Given Parameters:
  - Message Size ($L$) = $3\text{ KB} = 3 \times 1024 \times 8\text{ bits} = 24,576\text{ bits}$
  - Bandwidth ($B$) = $1\text{ Gbps} = 10^9\text{ bps}$
  - Distance ($d$) = $300\text{ km} = 3 \times 10^5\text{ m}$
  - Propagation Speed ($v$) = $2 \times 10^8\text{ m/s}$
  - Queuing Delay ($D_{queue}$) = $5\text{ ms}$

• Formula: $\text{Total One-Way Latency} = D_{trans} + D_{prop} + D_{queue} + D_{proc}$

• Step 1: Transmission Delay ($D_{trans}$)
  $$D_{trans} = \frac{L}{B} = \frac{24576}{10^9} = 2.4576 \times 10^{-5}\text{ sec} = \mathbf{0.0246\text{ ms}}$$

• Step 2: Propagation Delay ($D_{prop}$)
  $$D_{prop} = \frac{d}{v} = \frac{3 \times 10^5}{2 \times 10^8} = 1.5 \times 10^{-3}\text{ sec} = \mathbf{1.5\text{ ms}}$$

• Step 3: Total One-Way Latency
  $$\text{Total Latency} = 0.0246\text{ ms} + 1.5\text{ ms} + 5.0\text{ ms} = \mathbf{6.5246\text{ ms}}$$
  *(If including initial connection setup RTT of 50 ms, Total Latency = $\mathbf{56.5246\text{ ms}}$)*"
                },

                // ── 4. BB AD (ICT) 2025: Email Protocols & Transfer Flow ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2025, ExamOrg = "Bangladesh Bank (DU)", Post = "Assistant Director (ICT)", 
                    QuestionText = "Afsana and Sinthia have 2 mail addresses: www.example.bb.org and www.example.org.uk (unknown DNS).\n(a) Application Layer Protocols and Transport Layer Protocols.\n(b) Write down the steps of Mail transfer from Afsana to Sinthia.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
সহজ উপমা:
ইমেইল পাঠানো চিঠিপত্র পাঠানোর মতোই—
১. আপনি চিঠি লিখে লোকাল ডাকঘরে ফেললেন (SMTP Push)।
২. ডাকপিয়ন প্রাপকের শহরের পোস্টকোড/ঠিকানা বের করল (DNS Lookup)।
৩. এক ডাকঘর থেকে অন্য ডাকঘরে চিঠি পাঠানো হলো (Server-to-Server SMTP Relay)।
৪. প্রাপক ডাকঘর থেকে চিঠিটি নিজের বাসায় এনে পড়ল (IMAP/POP3 Pull)।

(a) কোন কোন প্রোটোকল কাজ করে:
• Application Layer:
  - SMTP: চিঠি বা মেইল পাঠানোর জন্য (Push Protocol)।
  - DNS: প্রাপকের ডোমেইন ও মেইল সার্ভারের আইপি (MX Record) খোঁজার জন্য।
  - IMAP / POP3: প্রাপক তার সার্ভার থেকে মেইল নিজের ডিভাইসে ডাউনলোড করে পড়ার জন্য (Pull Protocol)।
• Transport Layer:
  - TCP (Port 25, 587, 993): মেইল যেন হারিয়ে না যায়, তাই নির্ভরযোগ্য কানেকশন তৈরিতে TCP ব্যবহৃত হয়।
  - UDP (Port 53): দ্রুত DNS অনুসন্ধানের জন্য ব্যবহৃত হয়।

(b) মেইল যাওয়ার ৫টি ধাপ:
1. Afsana তার কম্পিউটার থেকে মেইল পাঠালে তা SMTP দিয়ে তার নিজস্ব মেইল সার্ভারে যায়।
2. Afsana-র সার্ভার DNS-এ জিজ্ঞাসা করে: '`example.org.uk` এর মেইল সার্ভারের আইপি কত?'
3. আইপি পাওয়ার পর Afsana-র সার্ভার সরাসরি Sinthia-র সার্ভারের সাথে TCP কানেকশন করে SMTP দিয়ে মেইলটি পাঠিয়ে দেয়।
4. Sinthia-র সার্ভার মেইলটি রিসিভ করে Sinthia-র ইনবক্সে নিরাপদে রেখে দেয়।
5. Sinthia যখন অ্যাপ ওপেন করে, IMAP প্রোটোকল ব্যবহার করে মেইলটি পড়ে।

🇬🇧 English Exam Answer:
(a) Protocols Used:
• Application Layer Protocols:
  - SMTP (Simple Mail Transfer Protocol): For mail submission (client-to-server) and inter-server relay.
  - DNS (Domain Name System): To resolve recipient domain's MX (Mail Exchange) record to an IP address.
  - IMAP / POP3: For client mail retrieval from the mailbox server.
• Transport Layer Protocols:
  - TCP: Reliable connection-oriented protocol for SMTP (Ports 25/587) and IMAPS (Port 993).
  - UDP: Lightweight connectionless protocol for DNS queries (Port 53).

(b) Steps of Mail Transfer from Afsana to Sinthia:
1. Mail Submission: Afsana composes the email on her Mail User Agent (MUA) and sends it to her local Mail Transfer Agent (MTA, `example.bb.org`) via SMTP.
2. DNS MX Lookup: Sender MTA queries DNS for the MX record of `example.org.uk`.
3. Server-to-Server SMTP Relay: Sender MTA initiates a TCP 3-way handshake on port 25 with recipient MTA and transmits the email payload via SMTP.
4. Mailbox Delivery: Recipient MTA delivers the message to Sinthia's mailbox storage via Mail Delivery Agent (MDA).
5. User Retrieval: Sinthia logs into her email client and fetches the message from her server using IMAP/POP3."
                },

                // ── 5. BB AD (ICT) 2025: Mail/DNS/Web Access Architecture ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2025, ExamOrg = "Bangladesh Bank (DU)", Post = "Assistant Director (ICT)", 
                    QuestionText = "Mail Server, DNS Server, and Public Website access architecture & communication flow.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
একটি এন্টারপ্রাইজে মূলত ৩টি মূল সার্ভার কাজ করে:
১. DNS Server (ফোনবুক): ডোমেইনের নামকে আইপিতে রূপান্তর করে (Web এর জন্য `A Record`, Mail এর জন্য `MX Record`)।
২. Web Server (দোকানঘর): পোর্ট ৮০ (HTTP) ও ৪৪৩ (HTTPS) এ ক্লায়েন্টের ব্রাউজার রিকোয়েস্টে ওয়েবসাইট দেখায়।
৩. Mail Server (ডাকঘর): পোর্ট ২৫/৫৮৭ (SMTP) দিয়ে মেইল গ্রহণ ও পাঠায় এবং পোর্ট ৯৯৩ (IMAP) দিয়ে ইনবক্স ম্যানেজ করে।

কমিউনিকেশন ফ্লো (Workflow):
• ওয়েবসাইট ভিজিট: ব্রাউজার $\rightarrow$ DNS থেকে ওয়েবসাইট আইপি নেয় $\rightarrow$ HTTPS দিয়ে ওয়েব সার্ভার থেকে পেজ লোড করে।
• ইমেইল পাঠানো: প্রেরক $\rightarrow$ DNS থেকে MX রেকর্ড বের করে $\rightarrow$ SMTP দিয়ে সরাসরি মেইল সার্ভারে মেইল ডেলিভারি করে।

🇬🇧 English Exam Answer:
• Architecture Core Components:
  1. DNS Server: Resolves domain names to IP addresses (A record for Web servers, MX record for Mail servers).
  2. Web Server: Listens on HTTP (Port 80) and HTTPS (Port 443) to serve HTML/CSS/JS and web applications.
  3. Mail Server: Handles email queuing and delivery via SMTP (Port 25/587) and user mailbox access via IMAP (Port 993).

• Communication Flow:
```
[ User Browser ] ──(1) DNS Query (www.bank.gov.bd)──> [ DNS Server ]
                 <──(2) Returns Web Server IP (A)────┘
[ User Browser ] ──(3) HTTPS GET (Port 443)─────────> [ Web Server ]
                 <──(4) Returns Webpage HTML/Assets───┘
[ External MTA ] ──(5) DNS MX Query (bank.gov.bd)────> [ DNS Server ]
[ External MTA ] ──(6) SMTP Relay (Port 25)─────────> [ Mail Server ]
```
  - Step 1–4 (Web Access): Browser resolves domain IP via DNS `A` record, performs TCP 3-way handshake + TLS handshake, and fetches the webpage.
  - Step 5–6 (Email Delivery): Sender MTA queries DNS `MX` record, establishes TCP connection to the Mail Server on Port 25, and delivers the message via SMTP."
                },

                // ── 6. BB AME 2023: Intra-Domain Routing Protocols ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Maintenance Engineer", 
                    QuestionText = "[MCQ] Which of the following pairs is an example of Intra-domain routing protocols?\n(a) ALOHA, RIP (b) OSPF, RIP (c) RIP, FTP (d) BGP, SMTP\nAns: (b) OSPF, RIP",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
সহজ উপমা:
• Intra-Domain (ঘরের ভেতরের রাস্তা): একটি একক ব্যাংকের বা প্রতিষ্ঠানের ভেতরের নিজস্ব রাউটারগুলোর মধ্যে যোগাযোগের নিয়ম। এদের বলে IGP (Interior Gateway Protocol)। যেমন: **RIP** ও **OSPF**।
• Inter-Domain (এক দেশের সাথে অন্য দেশের হাইওয়ে): দুটি আলাদা ইন্টারনেট সার্ভিস প্রোভাইডার (ISP) বা Autonomous System-এর মধ্যে যোগাযোগের নিয়ম। একে বলে EGP (Exterior Gateway Protocol)। প্রধান উদাহরণ: **BGP**।

🇬🇧 English Exam Answer:
• Answer: (b) OSPF, RIP
• Classification:
  - Interior Gateway Protocols (IGP / Intra-domain): Operate within a single Autonomous System (AS). Examples: **OSPF** (Link-State) and **RIP** (Distance-Vector).
  - Exterior Gateway Protocols (EGP / Inter-domain): Operate between different Autonomous Systems across the global internet. Primary example: **BGP** (Border Gateway Protocol)."
                },

                // ── 7. BB AME 2023: Public vs Private IP Range ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Maintenance Engineer", 
                    QuestionText = "[MCQ] Which of the following cannot be used as a public IP address?\n(a) 17.0.0.1 (b) 168.172.19.34 (c) 172.15.29.63 (d) 192.168.13.18\nAns: (d) 192.168.13.18",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
সহজ উপমা:
• পাবলিক আইপি হলো আপনার বাড়ির আসল পোস্টাল ঠিকানা—যা দিয়ে সারাবিশ্বের যে কেউ আপনাকে চিঠি পাঠাতে পারে।
• প্রাইভেট আইপি হলো বাড়ির ভেতরের রুম নম্বর (রুম ১, রুম ২)—যা বাইরে থেকে সরাসরি দেখা যায় না।

RFC 1918 অনুযায়ী সংরক্ষিত ৩টি প্রাইভেট রেঞ্জ (যা ইন্টারনেটে রাউট হয় না):
1. Class A: `10.0.0.0` থেকে `10.255.255.255`
2. Class B: `172.16.0.0` থেকে `172.31.255.255` (মনে রাখবেন: `172.15.x.x` কিন্তু পাবলিক!)
3. Class C: `192.168.0.0` থেকে `192.168.255.255`

যেহেতু `192.168.13.18` Class C প্রাইভেট রেঞ্জের ভেতরে, এটি পাবলিক আইপি হিসেবে ব্যবহার করা যাবে না।

🇬🇧 English Exam Answer:
• Answer: (d) 192.168.13.18
• Explanation:
  - RFC 1918 Private IP Ranges:
    * Class A: `10.0.0.0/8` (`10.0.0.0` – `10.255.255.255`)
    * Class B: `172.16.0.0/12` (`172.16.0.0` – `172.31.255.255`)
    * Class C: `192.168.0.0/16` (`192.168.0.0` – `192.168.255.255`)
  - Since `192.168.13.18` belongs to the Class C private block, it cannot be routed on the public internet."
                },

                // ── 8. BB AME 2023: Cisco IOS Upgrade Command ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Maintenance Engineer", 
                    QuestionText = "[MCQ] Which command loads a new version of the Cisco IOS into a router?\n(a) copy flash ftp (b) copy ftp flash (c) copy flash tftp (d) copy tftp flash\nAns: (d) copy tftp flash",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
Cisco CLI-তে যেকোনো ফাইল কপি করার সাধারণ নিয়ম:
`copy <কোথা থেকে কপি করবেন> <কোথায় রাখবেন>`
`copy <SOURCE> <DESTINATION>`

নতুন IOS অপারেটিং সিস্টেম সাধারণত নেটওয়ার্কের TFTP সার্ভারে রাখা থাকে। TFTP (Source) থেকে রাউটারের ফ্ল্যাশ মেমরিতে (Destination) ফাইল আনার জন্য কমান্ড হবে: `copy tftp: flash:`।

🇬🇧 English Exam Answer:
• Answer: (d) copy tftp flash
• Explanation: Cisco IOS syntax follows `copy <source> <destination>`. To load a new router operating system image from a remote TFTP server into the local flash storage, the command is `Router# copy tftp: flash:`."
                },

                // ── 9. BB AME 2023: Router Forwarding Decisions ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Maintenance Engineer", 
                    QuestionText = "[MCQ] When a host on network A sends a message to a host on network B, which address does the router look at?\n(a) Port (b) IP (c) Physical (d) Subnet mask\nAns: (b) IP",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
• Switch কাজ করে Layer 2 (Data Link)-এ $\rightarrow$ সুইচ দেখে **MAC Address (Physical Address)**।
• Router কাজ করে Layer 3 (Network)-এ $\rightarrow$ রাউটার দেখে **IP Address (Logical Address)**।
যখন নেটওয়ার্ক A থেকে নেটওয়ার্ক B-তে ডাটা পাঠাতে হয়, রাউটার ডাটা প্যাকেটের ভেতরের **Destination IP Address** পড়ে এবং নিজের রাউটিং টেবিল দেখে পরবর্তী গন্তব্যে পাঠায়।

🇬🇧 English Exam Answer:
• Answer: (b) IP
• Explanation: A router is an OSI Layer 3 (Network Layer) device. When routing packets between distinct IP subnets, it strips the Layer 2 frame header and examines the **Destination IP Address** to determine the next-hop forwarding path from its Routing Table."
                },

                // ── 10. BB AME 2023: Parity Check & ASCII Encoding ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Maintenance Engineer", 
                    QuestionText = "Explain parity method for error detection. Write down the bit strings of \"Delta\" using ASCII.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
১. Parity Method কী?
ডাটা ট্রান্সমিশনের সময় ১-বিট উল্টে গেছে কিনা (0 হয়ে গেছে 1, বা 1 হয়ে গেছে 0) তা ধরার সবচেয়ে সহজ উপায়। ৭-বিট ডাটার সাথে ১টি অতিরিক্ত বিট (Parity Bit) যোগ করা হয়:
• Even Parity (জোড়): ডাটাতে মোট '1' এর সংখ্যা যেন জোড় হয়।
• Odd Parity (বিজোড়): ডাটাতে মোট '1' এর সংখ্যা যেন বিজোড় হয়।

২. 'Delta' শব্দের ৮-বিট ASCII কোডিং (Even Parity সহ):
• 'D' (ASCII 68): 7-bit binary = `1000100` (এখানে দুটি '1' আছে, যা জোড়) $\rightarrow$ Parity Bit = 0 $\rightarrow$ বাইট: `01000100`
• 'e' (ASCII 101): 7-bit binary = `1100101` (চারটি '1', জোড়) $\rightarrow$ Parity Bit = 0 $\rightarrow$ বাইট: `01100101`
• 'l' (ASCII 108): 7-bit binary = `1101100` (চারটি '1', জোড়) $\rightarrow$ Parity Bit = 0 $\rightarrow$ বাইট: `01101100`
• 't' (ASCII 116): 7-bit binary = `1110100` (চারটি '1', জোড়) $\rightarrow$ Parity Bit = 0 $\rightarrow$ বাইট: `01110100`
• 'a' (ASCII 97): 7-bit binary = `1100001` (তিনটি '1', বিজোড়) $\rightarrow$ জোড় বানাতে Parity Bit = 1 $\rightarrow$ বাইট: `11100001`

চূড়ান্ত বিট স্ট্রিং: `01000100 01100101 01101100 01110100 11100001`

🇬🇧 English Exam Answer:
1. Parity Method for Error Detection:
The Parity Check appends a single redundant bit (Parity Bit) to a data byte to detect single-bit transmission errors.
• Even Parity: Parity bit is set to `0` or `1` so that the total count of 1s in the byte is even.
• Odd Parity: Parity bit is set so that the total count of 1s is odd.

2. ASCII Bit Strings for 'Delta' (MSB Even Parity):
| Char | ASCII (Dec) | 7-bit ASCII | Count of 1s | Even Parity (MSB) | 8-bit Transmitted Byte |
| :---: | :---: | :---: | :---: | :---: | :---: |
| **D** | 68 | `1000100` | 2 (Even) | **0** | `01000100` |
| **e** | 101 | `1100101` | 4 (Even) | **0** | `01100101` |
| **l** | 108 | `1101100` | 4 (Even) | **0** | `01101100` |
| **t** | 116 | `1110100` | 4 (Even) | **0** | `01110100` |
| **a** | 97 | `1100001` | 3 (Odd) | **1** | `11100001` |

Transmitted Stream: **01000100 01100101 01101100 01110100 11100001**"
                },

                // ── 11. BB AME 2023: Digitized Video Source Bit Rate ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Maintenance Engineer", 
                    QuestionText = "Suppose that a digitized TV picture is to be transmitted from a source that uses a matrix of 480 times 500 picture elements (pixels), where each pixel can take on one of 32 intensity values. Assume that 30 pictures are sent per second. Find the source rate R (bps).",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Step-by-Step):
ভিডিও ট্রান্সমিশনের বিট রেট হিসাব করার নিয়ম:
মোট স্পিড = (প্রতি ছবিতে মোট পিক্সেল) $\times$ (প্রতি পিক্সেলে বিট) $\times$ (প্রতি সেকেন্ডে ছবির সংখ্যা)

১. প্রতি পিক্সেলে কত বিট লাগবে?
৩২টি কালার বা ইনটেনসিটি লেভেল বোঝাতে $2^b = 32 \implies b = 5\text{ bits}$ প্রয়োজন।
২. প্রতি ফ্রেমে মোট পিক্সেল:
$480 \times 500 = 240,000\text{ pixels}$।
৩. প্রতি ফ্রেমে মোট বিট:
$240,000 \times 5 = 1,200,000\text{ bits/frame}$।
৪. প্রতি সেকেন্ডে ৩০টি ছবি পাঠানো হয়:
Source Rate ($R$) = $1,200,000 \times 30 = 36,000,000\text{ bps} = \mathbf{36\text{ Mbps}}$।

🇬🇧 English Exam Answer:
• Given:
  - Resolution = 480 × 500 pixels/frame
  - Intensity levels per pixel ($M$) = 32
  - Frame rate ($F$) = 30 frames/sec

• Step 1: Bits per pixel ($b$)
  $$b = \log_2(M) = \log_2(32) = 5\text{ bits/pixel}$$

• Step 2: Total bits per frame ($B_f$)
  $$B_f = 480 \times 500 \times 5 = 1,200,000\text{ bits/frame}$$

• Step 3: Source Bit Rate ($R$)
  $$R = B_f \times F = 1,200,000 \times 30 = 36,000,000\text{ bps} = \mathbf{36\text{ Mbps}}$$ (or $3.6 \times 10^7\text{ bps}$)."
                },

                // ── 12. BB AME 2023: Packetization Delay ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Maintenance Engineer", 
                    QuestionText = "One of the drawbacks of a small packet size is that a large fraction of link bandwidth is consumed by overhead bytes. To this end, suppose that the packet consists of P bytes and 5 bytes of header. Consider sending a digitally encoded voice source directly encoded at 128 kbps. Determine the packetization delay for length L = 1500 bytes (max Ethernet packet).",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Step-by-Step):
Packetization Delay কী?
ডিজিটাল ভয়েস কল করার সময় মাইক্রোফোন থেকে কথা রেকর্ড করে একটি পূর্ণাঙ্গ প্যাকেট (১৫০০ বাইট) ভর্তি করতে যে সময়টুকু অপেক্ষা করতে হয়।

১. প্যাকেট সাইজ = 1500 bytes, হেডার = 5 bytes
   - ডাটার মূল অংশ (Payload, $P$) = $1500 - 5 = 1495\text{ bytes} = 1495 \times 8 = 11,960\text{ bits}$।
২. ভয়েস এনকোডিং স্পিড = $128\text{ kbps} = 128,000\text{ bps}$।
৩. প্যাকেটাইজেশন ডিলে:
   $$D_{pack} = \frac{\text{Payload in bits}}{\text{Encoding Rate}} = \frac{11960}{128000} \approx 0.0934375\text{ s} = \mathbf{93.44\text{ ms}}$$
(যদি পুরো ১৫০০ বাইট ডাটা ধরা হয়, তবে $\frac{1500 \times 8}{128000} = \mathbf{93.75\text{ ms}}$)।

🇬🇧 English Exam Answer:
• Given:
  - Total Packet Length ($L$) = 1500 bytes
  - Header = 5 bytes $\implies$ Payload ($P$) = $1500 - 5 = 1495\text{ bytes} = 11,960\text{ bits}$
  - Encoding Bit Rate ($R$) = $128\text{ kbps} = 128,000\text{ bps}$

• Formula:
  $$\text{Packetization Delay } (D_{pack}) = \frac{\text{Payload Bits}}{\text{Encoding Rate}} = \frac{P \times 8}{R}$$

• Calculation:
  $$D_{pack} = \frac{1495 \times 8}{128000} = \frac{11960}{128000} = 0.0934375\text{ sec} \approx \mathbf{93.44\text{ ms}}$$
  *(Or $93.75\text{ ms}$ if calculated on full $1500\text{ bytes}$ frame)*"
                },

                // ── 13. BB AP 2023: CIDR Subnet Addresses ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Programmer", 
                    QuestionText = "[MCQ] How many addresses are there in 200.10.10.10/20?\n(a) 4096 (b) 1024 (c) 2048 (d) 1022\nAns: (a) 4096",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
IPv4 এড্রেসে মোট ৩২টি বিট থাকে।
• প্রিফিক্স `/20` মানে প্রথম ২০টি বিট নেটওয়ার্কের জন্য ফিক্সড।
• বাকি হোস্ট বিট ($h$) = $32 - 20 = 12$ টি বিট।
• মোট আইপি এড্রেস সংখ্যা = $2^{12} = \mathbf{4096}$ টি।
(যদি 'ব্যবহারযোগ্য হোস্ট' জানতে চাইতো, উত্তর হতো $4096 - 2 = 4094$ টি)।

🇬🇧 English Exam Answer:
• Answer: (a) 4096
• Explanation:
  - Total IPv4 bits = 32
  - Host bits ($h$) = $32 - 20 = 12$
  - Total IP Addresses = $2^h = 2^{12} = \mathbf{4096}$ (Usable hosts = $4096 - 2 = 4094$)."
                },

                // ── 14. BB AP 2023: Subnet Mask for 200 Hosts ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Programmer", 
                    QuestionText = "[MCQ] Which is suitable subnet mask for 200 hosts?\n(a) 255.255.0.200 (b) 255.255.255.0 (c) 255.0.0.0 (d) 255.255.200.0\nAns: (b) 255.255.255.0",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
২০০টি হোস্ট ফিট করতে কত বিট লাগবে?
• $2^7 - 2 = 126$ (২০০ এর চেয়ে কম, হবে না)
• $2^8 - 2 = 254$ (২০০ জন সহজে থাকতে পারবে, ৮ বিট হোস্ট লাগবে)
৮টি হোস্ট বিট রাখলে নেটওয়ার্ক প্রিফিক্স হবে $32 - 8 = /24$।
/24 এর সাবনেট মাস্ক = **255.255.255.0**।

🇬🇧 English Exam Answer:
• Answer: (b) 255.255.255.0
• Explanation:
  - Required usable hosts $\ge 200$
  - Using formula $2^h - 2 \ge 200 \implies h = 8$ bits ($2^8 - 2 = 254$ hosts).
  - Subnet prefix = $32 - 8 = /24$, which gives standard subnet mask `255.255.255.0`."
                },

                // ── 15. BB AP 2023: IPv4 over IPv6 Transition ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Programmer", 
                    QuestionText = "[MCQ] The IPv4 is encapsulated to IPv6 which is known as:\n(a) Tunneling (b) hashing (c) NAT (d) Traversing\nAns: (a) Tunneling",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
সহজ উপমা:
একটি ছোট গাড়িকে (IPv4 প্যাকেট) বড় ফেরির (IPv6 হেডার) ভেতর ঢুকিয়ে নদী পার করা।
যখন কোনো পুরাতন IPv4 নেটওয়ার্কের ডাটাকে আধুনিক IPv6 নেটওয়ার্কের মধ্য দিয়ে পার করার জন্য IPv6 হেডার দিয়ে ক্যাপসুল বানিয়ে পাঠানো হয়, তাকে **Tunneling** (যেমন: 6to4, Teredo) বলে।

🇬🇧 English Exam Answer:
• Answer: (a) Tunneling
• Explanation: Tunneling is an IP transition strategy where an IPv4 packet is encapsulated inside an IPv6 header (or vice versa) to traverse a transit network supporting the other protocol version."
                },

                // ── 16. BB BUET 2019: Node, Backbone, Router, Gateway ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2019, ExamOrg = "Bangladesh Bank (BUET)", Post = "Assistant Maintenance Engineer", 
                    QuestionText = "Write short note on: Node, Backbone, Router and Gateway.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
• Node (নোড): নেটওয়ার্কে যুক্ত যেকোনো সক্রিয় ডিভাইস যা ডাটা পাঠাতে বা গ্রহণ করতে পারে (কম্পিউটার, প্রিন্টার, সার্ভার, ক্যামেরা)।
• Backbone (ব্যাকবোন): প্রধান হাই-স্পিড ক্যাবল বা চ্যানেল—যেমন মেরুদণ্ড সমস্ত অঙ্গকে ধরে রাখে, তেমনি ব্যাকবোন ক্যাবল ভবনের সব ফ্লোর ও সাবনেটকে সেন্ট্রাল সার্ভারের সাথে যুক্ত করে।
• Router (রাউটার): ট্রাফিক পুলিশের মতো—IP Address দেখে ভিন্ন ভিন্ন নেটওয়ার্কের মধ্যে সবচেয়ে কম দূরত্বের রাস্তা দিয়ে প্যাকেট পৌঁছে দেয় (Layer 3)।
• Gateway (গেটওয়ে): অনুবাদক বা প্রটোকল রূপান্তরকারী—দুটি সম্পূর্ণ ভিন্ন নিয়মের নেটওয়ার্ককে (যেমন: ব্যাংকের মেইনফ্রেম ও লোকাল LAN) একসাথে যুক্ত করে।

🇬🇧 English Exam Answer:
• Node: Any active physical or virtual network-addressable device connected to a network capable of sending, receiving, or processing data (e.g., PC, server, network printer).
• Backbone: A high-capacity central transmission artery that interconnects multiple local area networks (LANs) and subnets across an enterprise.
• Router: An OSI Layer 3 device that inspects Destination IP addresses and routes packets across distinct subnets using dynamic routing tables (OSPF, BGP).
• Gateway: A multi-layer network translator that joins two distinct networks operating on completely different communication protocols and architectures."
                },

                // ── 17. BB DU 2019: Flow Control in OSI Layers ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2019, ExamOrg = "Bangladesh Bank (DU)", Post = "Assistant Programmer", 
                    QuestionText = "Two OSI layers are known for \"Flow Control\" — which are those? Write them and explain.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
Flow Control মানে ফাস্ট সেন্ডার যাতে এত দ্রুত ডাটা না পাঠায় যে স্লো রিসিভারের মেমোরি উপচে পড়ে (Buffer Overflow)।
এটি OSI-র ২টি লেয়ারে ঘটে:
১. Data Link Layer (Layer 2) — পাশাপাশি দুটি নোডের মধ্যে (Hop-to-Hop):
   - তারের দুই প্রান্তে সরাসরি যুক্ত পিসি ও সুইচের মধ্যে গতি সামলানো (মেকানিজম: Stop-and-Wait, Pause Frames)।
২. Transport Layer (Layer 4) — পুরো শুরু থেকে শেষ প্রান্তের মধ্যে (End-to-End):
   - আসল সেন্ডার অ্যাপ এবং আসল রিসিভার অ্যাপের মধ্যে গতি সামলানো (মেকানিজম: TCP Sliding Window, `rwnd`)।

🇬🇧 English Exam Answer:
• The two OSI layers responsible for Flow Control are:
  1. Data Link Layer (Layer 2) — Hop-by-Hop / Node-to-Node Flow Control:
     - Regulates transmission between two directly adjacent physical nodes to prevent buffer overrun over a single link (e.g., Stop-and-Wait, IEEE 802.3x Ethernet Pause frames).
  2. Transport Layer (Layer 4) — End-to-End / Process-to-Process Flow Control:
     - Regulates transmission rate between the original source application and the destination application across multiple intermediate routers (e.g., TCP Sliding Window using Advertised Window `rwnd`)."
                },

                // ── 18. BB 2017: Subnetting 172.20.0.0/27 ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2017, ExamOrg = "Bangladesh Bank", Post = "Assistant Maintenance Engineer", 
                    QuestionText = "How many subnets and hosts per subnet can you get from the network 172.20.0.0/27?",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Step-by-Step):
১. 172.20.0.0 হলো একটি Class B নেটওয়ার্ক (ডিফল্ট নেটওয়ার্ক বিট = /16)।
২. নতুন প্রিফিক্স দেওয়া আছে = /27।
৩. ধার করা সাবনেট বিট ($s$) = $27 - 16 = 11$ টি।
   - মোট সাবনেট সংখ্যা = $2^{11} = \mathbf{2048}$ টি।
৪. অবশিষ্ট হোস্ট বিট ($h$) = $32 - 27 = 5$ টি।
   - প্রতি সাবনেটে মোট আইপি = $2^5 = 32$ টি।
   - প্রতি সাবনেটে ব্যবহারযোগ্য হোস্ট = $2^5 - 2 = \mathbf{30}$ টি।

🇬🇧 English Exam Answer:
• Given: Network `172.20.0.0/27` (Default Class B prefix = `/16`).
• Subnet Bits Borrowed ($s$): $27 - 16 = 11\text{ bits}$
  $$\text{Number of Subnets} = 2^{11} = \mathbf{2048}$$
• Remaining Host Bits ($h$): $32 - 27 = 5\text{ bits}$
  $$\text{Total Addresses per Subnet} = 2^5 = 32$$
  $$\text{Usable Hosts per Subnet} = 2^5 - 2 = \mathbf{30\text{ hosts}}$$"
                },

                // ── 19. BB 2017: DHCP and SMTP ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2017, ExamOrg = "Bangladesh Bank", Post = "Assistant Maintenance Engineer", 
                    QuestionText = "Write short notes on DHCP and SMTP.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
• DHCP (Dynamic Host Configuration Protocol):
  - আপনি যখন মোবাইল বা ল্যাপটপে Wi-Fi অন করেন, কোনো ঝামেলা ছাড়াই স্বয়ংক্রিয়ভাবে একটি IP address, Subnet Mask, Gateway এবং DNS আইপি পেয়ে যান—এই কাজটি করে DHCP সার্ভার (DORA প্রসেস: Discover, Offer, Request, Acknowledge; UDP Port 67/68)।
• SMTP (Simple Mail Transfer Protocol):
  - এটি ইমেইল প্রেরণের স্ট্যান্ডার্ড প্রোটোকল। ক্লায়েন্ট থেকে সার্ভারে এবং এক সার্ভার থেকে অন্য সার্ভারে মেইল পুশ করতে TCP Port 25 ও 587 ব্যবহার করে।

🇬🇧 English Exam Answer:
• DHCP (Dynamic Host Configuration Protocol):
  - An application layer network protocol that automatically allocates dynamic IP addresses, default gateways, subnet masks, and DNS servers to client devices.
  - Operates over UDP ports 67 (server) and 68 (client) using the 4-step **DORA** cycle (Discover, Offer, Request, Acknowledge).
• SMTP (Simple Mail Transfer Protocol):
  - A connection-oriented, text-based protocol used to push and relay emails from sender clients to mail servers and between intermediate mail servers.
  - Operates over TCP port 25 (server relay), port 587 (authenticated client submission), and port 465 (SMTPS)."
                },

                // ── 20. BB AD (IT) 2016: LAN Data Transfer Rates ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2016, ExamOrg = "Bangladesh Bank", Post = "Assistant Director (IT)", 
                    QuestionText = "[MCQ] Typical data transfer rates in LAN are of the order of:\n(a) Bits per sec (b) Kilobits per sec (c) Megabits per sec (d) None of them\nAns: (c) Megabits per sec",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
লোকাল এরিয়া নেটওয়ার্কে (LAN) ক্যাবলের মাধ্যমে খুব দ্রুত গতিতে ডাটা ট্রান্সমিশন হয়। সাধারণত LAN-এর গতি Megabits per second (Mbps) বা Gigabits per second (Gbps) অর্ডারে থাকে (যেমন: 100 Mbps Fast Ethernet, 1 Gbps Gigabit Ethernet)।

🇬🇧 English Exam Answer:
• Answer: (c) Megabits per sec (Mbps)
• Explanation: Typical Local Area Networks operate at speeds of 100 Mbps (Fast Ethernet), 1000 Mbps / 1 Gbps (Gigabit Ethernet), or up to 10 Gbps in high-performance enterprise LANs."
                },

                // ── 21. BB AD (IT) 2016: Information Interchange Computer Code ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2016, ExamOrg = "Bangladesh Bank", Post = "Assistant Director (IT)", 
                    QuestionText = "[MCQ] The computer code for interchange of information between terminals is:\n(a) ASCII (b) BCD (c) EBCDIC (d) All of them\nAns: (a) ASCII",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
সহজ উপমা:
কম্পিউটার ও টার্মিনালগুলো ভেতরের দিক থেকে শুধুই '0' এবং '1' ছাড়া কিছুই চেনে না। আপনি যখন কীবোর্ডে 'A' চাপেন, তারের মধ্য দিয়ে কী যাবে? সেই সঙ্কেতলিপি ঠিক করার জন্যই তৈরি হয়েছে কোডিং স্ট্যান্ডার্ড।
• **ASCII** (American Standard Code for Information Interchange): এটি টার্মিনাল, পিসি ও ইন্টারনেটের বিশ্বজনীন স্ট্যান্ডার্ড ভাষা (যেমন: 'A' = 65 = `1000001`)। ৭-বিটে ১২৮টি এবং ৮-বিট এক্সটেন্ডেড ASCII-তে ২৫৬টি ক্যারেক্টার থাকে।
• BCD (Binary Coded Decimal): এটি কেবল ০ থেকে ৯ সংখ্যাগুলোকে ৪ বিটে কোড করতে ব্যবহৃত হয় (আলফাবেট সাপোর্ট করে না)।
• EBCDIC: এটি মূলত পুরাতন IBM মেইনফ্রেম কম্পিউটারে ব্যবহৃত হতো, টার্মিনালগুলোর মধ্যে সাধারণ ডাটা বিনিময়ের স্ট্যান্ডার্ড নয়।
সুতরাং টার্মিনালগুলোর মধ্যে সার্বজনীন ডাটা বিনিময়ের মূল কোড হলো **ASCII**।

🇬🇧 English Exam Answer:
• Answer: (a) ASCII
• Explanation:
  - **ASCII** (American Standard Code for Information Interchange) is the internationally recognized character encoding standard designed specifically for communication between terminals, teletypes, and computer systems. Standard ASCII uses 7 bits (128 characters: A-Z, a-z, 0-9, punctuation, control characters), and Extended ASCII uses 8 bits (256 characters).
  - **BCD** (Binary Coded Decimal) encodes only decimal digits (0–9) using 4 bits.
  - **EBCDIC** (Extended BCD Interchange Code) is a proprietary 8-bit character encoding used primarily on legacy IBM mainframe architectures."
                },

                // ── 22. BB AP 2016: Data Link Layer Functions ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2016, ExamOrg = "Bangladesh Bank", Post = "Assistant Programmer", 
                    QuestionText = "[MCQ] Which is not work of Data link layer?\n(a) Error control (b) Adding MAC address (c) Cabling (d) None\nAns: (c) Cabling",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
সহজ উপমা:
রেলগাড়ির লাইনের কথা ভাবুন—
• Physical Layer (Layer 1): রেললাইন বসানো, লোহার স্লিপার পাতা এবং বিদ্যুৎ সঞ্চালন তার (Cabling, Connectors, Pinouts, Voltage)।
• Data Link Layer (Layer 2): ট্রেনের কামরাগুলোকে যুক্ত করা, বগি নম্বর (MAC Address) লাগানো, এবং কোনো বগি লাইনচ্যুত হলো কিনা বা ধাক্কা খেল কিনা তা চেক করা (Framing, CRC Error Control, Flow Control)।
সুতরাং ফিজিক্যাল ক্যাবলিং বা তার টানার কাজ ডাটা লিংক লেয়ারের নয়, এটি ১০০% ফিজিক্যাল লেয়ারের (Layer 1) দায়িত্ব।

🇬🇧 English Exam Answer:
• Answer: (c) Cabling
• Explanation:
  - **Physical Layer (Layer 1)**: Responsible for physical transmission media, physical cabling (UTP, Fiber, Coaxial), connectors (RJ-45), electrical voltages, and bit-level transmission.
  - **Data Link Layer (Layer 2)**: Responsible for node-to-node frame delivery, hardware physical addressing (MAC address encapsulation), error detection & correction (CRC checksums), and flow control (Stop-and-Wait, Sliding Window). Cabling is not a function of Layer 2."
                },

                // ── 23. BB AP 2016: Network Topologies & Single Point of Failure ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2016, ExamOrg = "Bangladesh Bank", Post = "Assistant Programmer", 
                    QuestionText = "[MCQ] Whole network will break if node is defect in which network topology?\n(a) Star (b) Bus (c) Mesh (d) Hybrid\nAns: (b) Bus",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
সহজ উপমা:
• **Bus Topology**: একটি একক পানির মেইন পাইপের মতো, যার দুই মাথায় স্টপার (Terminator) থাকে এবং সব বাড়ি ওই একটি পাইপ থেকেই টি-কানেক্টর দিয়ে পানি নেয়। যদি ব্যাকবোন ক্যাবলের কোনো জায়গায় ফাটল ধরে বা কোনো ড্রপ কেবল সিগন্যাল শর্ট করে দেয়, তবে সিগন্যাল প্রতিফলিত (Signal Reflection) হয়ে পুরো নেটওয়ার্ক সাথে সাথে বন্ধ হয়ে যায়।
• Star Topology: মাঝখানে একটি সেন্ট্রাল সুইচ থাকে। যেকোনো একটি পিসির তার ছিঁড়ে গেলেও অন্য সব পিসির নেটওয়ার্ক সম্পূর্ণ সচল থাকে।
• Mesh Topology: প্রতিটি নোডের সাথে প্রতিটি নোডের ডেডিকেটেড তার থাকে। একটি তার ছিঁড়লেও বিকল্প পথে ডাটা চলাচল করে।

🇬🇧 English Exam Answer:
• Answer: (b) Bus (Also Ring in single-ring architectures)
• Explanation:
  - **Bus Topology**: All nodes share a single common communication backbone cable terminated with resistors. If the backbone cable breaks or a terminating node shorts the line, impedance mismatch causes severe signal reflections, collapsing communication across the entire bus.
  - **Star Topology**: Point-to-point links connect to a central hub/switch; a failure of a single host node has no impact on other nodes.
  - **Mesh Topology**: Full redundancy provides alternate paths, preventing network-wide failure upon a single node defect."
                },

                // ── 24. BB AP 2016: Server Machine Connectivity ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2016, ExamOrg = "Bangladesh Bank", Post = "Assistant Programmer", 
                    QuestionText = "[MCQ] Server machine is connected to:\n(a) Network (b) Client (c) supercomputer (d) Host\nAns: (a) Network",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
সহজ উপমা:
একটি ব্যাংক বা পোস্ট অফিস যদি কোনো একক গ্রাহকের বেডরুমে বসে কাজ করে, তবে বাকি সাধারণ জনগণ সেবা পাবে না। সেবাদাতা বা সার্ভার সবসময় পাবলিক বা লোকাল সড়কের মোড়ে (Network) কানেক্টেড থাকে, যাতে যেকোনো ক্লায়েন্ট রিকোয়েস্ট পাঠালে সার্ভার তার উত্তর দিতে পারে।
সার্ভার কোনো একক ক্লায়েন্টের অধীন নয়, এটি সার্বজনীন নেটওয়ার্কের সাথে যুক্ত থাকে।

🇬🇧 English Exam Answer:
• Answer: (a) Network
• Explanation: A server is a centralized computational resource designed to listen for and respond to incoming requests from multiple heterogeneous clients simultaneously. Therefore, a server connects directly to the shared **Network** infrastructure rather than being tethered to an individual client or host."
                },

                // ── 25. BB AME 2016: Intranet vs Extranet ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2016, ExamOrg = "Bangladesh Bank", Post = "Assistant Maintenance Engineer", 
                    QuestionText = "Differentiate between Intranet and Extranet.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
সহজ উপমা (একটি ব্যাংকের ভবনের উদাহরণ):
১. **Intranet (ব্যাংকের ভেতরের স্টাফ রুম / ভল্ট)**:
   - এটি ব্যাংকের নিজস্ব অভ্যন্তরীণ প্রাইভেট নেটওয়ার্ক।
   - শুধুমাত্র ব্যাংকের নিজস্ব নিয়োগপ্রাপ্ত কর্মকর্তা-কর্মচারীরা তাদের অফিস পিসি দিয়ে লগইন করতে পারেন (যেমন: Core Banking Software, ছুটির আবেদন পোর্টাল)। বাইরের সাধারণ জনগণ বা অন্য কেউ এখানে প্রবেশ করতে পারে না।
২. **Extranet (ব্যাংকের রেজিস্টার্ড কর্পোরেট ক্লায়েন্ট / ভেন্ডর লাউঞ্জ)**:
   - এটিও একটি সিকিউরড প্রাইভেট নেটওয়ার্ক, তবে এর পরিধি কিছুটা বর্ধিত।
   - ব্যাংকের অনুমোদিত বহিরাগত অংশীদার, যেমন অডিট ফার্ম, আইটি ভেন্ডর, এটিএম বুথ রক্ষণাবেক্ষণকারী টিম বা বড় কর্পোরেট গ্রাহকদের নির্দিষ্ট ডাটা দেখার অনুমতি দেওয়া হয় (VPN এবং মাল্টি-ফ্যাক্টর অথেনটিকেশনের মাধ্যমে)।
৩. Internet (পাবলিক রাস্তা): যে কেউ পৃথিবীর যেকোনো প্রান্ত থেকে ব্যাংকের ওয়েবসাইট দেখতে পারে।

🇬🇧 English Exam Answer:
• Comprehensive Comparison:
| Parameter | Intranet | Extranet |
| :--- | :--- | :--- |
| **Definition** | A strictly private network restricted solely to internal organization members. | A controlled private network opened to authorized external business partners and stakeholders. |
| **Accessibility** | Internal employees only (Local LAN or secure internal VPN). | Internal employees + trusted external vendors, suppliers, customers, and corporate partners. |
| **Security** | Protected behind corporate internal firewalls. | Protected via Public Key Infrastructure, VPN tunnels, and strict Role-Based Access Control (RBAC). |
| **Primary Purpose** | Sharing internal HR portals, CBS databases, corporate policies, and workflow management. | Business-to-Business (B2B) transactions, supply chain tracking, EDI, joint project collaboration. |
| **Example** | Bangladesh Bank internal CBS/Leave Management portal. | Bangladesh Bank BACPS / BEFTN portal accessed by scheduled commercial banks."
                },

                // ── 26. BB AME 2016: URL, VoIP, Broadband ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2016, ExamOrg = "Bangladesh Bank", Post = "Assistant Maintenance Engineer", 
                    QuestionText = "Explain URL, VOIP and Broadband.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
১. **URL (Uniform Resource Locator)**:
   - উপমা: আপনি কাউকে চিঠি পাঠাতে গেলে যেমন ঠিকানা লেখেন 'বাড়ি ৫, রোড ২, ঢাকা', ইন্টারনেটের সাগরে কোটি কোটি পেজ ও ছবির মধ্যে নির্দিষ্ট ফাইলের ইউনিক ঠিকানাই হলো URL।
   - গঠন: `https://` (প্রোটোকল) + `www.bb.org.bd` (ডোমেইন নেইম) + `:443` (পোর্ট) + `/notice/exam.pdf` (ফাইলের নির্দিষ্ট পাথ)।
২. **VoIP (Voice over Internet Protocol)**:
   - উপমা: আগে টেলিফোনে কথা বললে তামার তারে অ্যানালগ সিগন্যালে কথা যেত এবং মিনিটের পর মিনিট বিল উঠত। VoIP প্রযুক্তিতে মানুষের কণ্ঠস্বরকে মাইক্রোফোন ডিজিটাল বিটে (0 ও 1) রূপান্তর করে ইন্টারনেটের সাধারণ ডাটা প্যাকেট বানিয়ে পাঠিয়ে দেয় (যেমন: WhatsApp Call, Skype, Google Meet, IP Telephony)। প্রোটোকল: SIP ও RTP।
৩. **Broadband (ব্রডব্যান্ড)**:
   - উপমা: পুরনো ডায়াল-আপ ইন্টারনেট ছিল সরু এক গলির পথ—যেখান দিয়ে একবারে মাত্র একটি গাড়ি খুব আস্তে চলত। ব্রডব্যান্ড হলো একটি প্রশস্ত ৪-লেনের হাইওয়ে—যেখানে একাধিক ফ্রিকোয়েন্সি ব্যান্ড ব্যবহার করে একই সাথে উচ্চগতিতে (কমপক্ষে 10–100 Mbps) ডাটা, ভয়েস ও ভিডিও স্ট্রিম চলতে পারে।

🇬🇧 English Exam Answer:
• 1. URL (Uniform Resource Locator):
  - A standardized character string reference used to uniquely locate and address resources (web pages, images, PDFs) across the World Wide Web.
  - Standard Syntax: `protocol://hostname:port/path?query_string#fragment`
  - Example: `https://www.bb.org.bd/en/index.php`

• 2. VoIP (Voice over Internet Protocol):
  - A methodology and suite of protocols enabling voice audio and multimedia streaming to be digitized, compressed into IP packets, and transmitted across packet-switched IP networks rather than traditional circuit-switched PSTN lines.
  - Core Protocols: Session Initiation Protocol (SIP for call setup/teardown) and Real-Time Transport Protocol (RTP for low-latency media payload transfer).

• 3. Broadband:
  - High-speed, high-bandwidth data transmission capability that simultaneously transmits multiple signals and traffic types across wide multiplexed frequency bands over fiber optics, coaxial, or DSL media.
  - Characteristics: High data rates (typically $\ge 25\text{ Mbps}$ download), always-on connectivity, and low latency."
                },

                // ── 27. BB AP 2016: Domain vs Workgroup ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2016, ExamOrg = "Bangladesh Bank", Post = "Assistant Programmer", 
                    QuestionText = "What is the main difference between Domain and Workgroup?",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
সহজ উপমা:
• **Workgroup (ছাত্রাবাস বা মেস বাড়ি)**:
  - প্রতিটি রুমের আলাদা আলাদা তালা-চাবি। কার রুমে কে ঢুকবে তা সেই রুমের মালিক ঠিক করে। কোনো সেন্ট্রাল ম্যানেজার নেই (Peer-to-Peer মডেল)।
  - আপনার অফিসে ৫টি কম্পিউটার থাকলে, ইউজারকে ৫টি পিসিতেই আলাদা আলাদা ৫ বার ইউজারনেম ও পাসওয়ার্ড বানাতে হবে। ৫–১০টি কম্পিউটারের ছোট দোকানের জন্য ঠিক আছে, কিন্তু বড় অফিসে এটা নিয়ন্ত্রণ করা অসম্ভব।
• **Domain (ফাইভ স্টার হোটেল বা কর্পোরেট অফিস)**:
  - রিসেপশনে একজন সেন্ট্রাল ম্যানেজার আছেন—যাকে বলা হয় **Active Directory Domain Controller (DC)**।
  - সেন্ট্রাল সার্ভারে ইউজারের ১টি মাত্র ইউজার একাউন্ট তৈরি করা হয়। ইউজার অফিসের যেকোনো ফ্লোরের যেকোনো অনুমোদিত পিসিতে গিয়ে নিজের ইউজার-পাসওয়ার্ড দিয়ে লগইন (Single Sign-On) করতে পারে। আইটি অ্যাডমিন সেন্ট্রাল সার্ভার থেকে এক ক্লিকেই সব পিসির সিকিউরিটি পলিসি নির্ধারণ করে দিতে পারেন।

🇬🇧 English Exam Answer:
• Comparison between Workgroup and Domain:
| Feature | Workgroup (Peer-to-Peer) | Domain (Client-Server) |
| :--- | :--- | :--- |
| **Architecture** | Decentralized Peer-to-Peer network model. | Centralized Client-Server hierarchical model. |
| **Authentication** | Each workstation maintains its own local **SAM** (Security Accounts Manager) database. | Authenticated centrally by an **Active Directory Domain Controller (DC)**. |
| **User Accounts** | User must have an account configured on every physical machine they use. | A single domain account allows logon to any authorized machine on the network (SSO). |
| **Security & Policies**| Managed individually on each computer; no central Group Policy. | Centralized administration using **Group Policy Objects (GPO)** across thousands of endpoints. |
| **Scalability** | Best suited for small networks ($\le 10$ computers). | Enterprise scalable to hundreds of thousands of computers and users. |
| **Infrastructure** | No dedicated server operating system required. | Requires Windows Server running Active Directory Domain Services (AD DS)."
                },

                // ── 28. BB AME 2013: Transport Layer End-to-End Delivery ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2013, ExamOrg = "Bangladesh Bank", Post = "Assistant Maintenance Engineer", 
                    QuestionText = "[MCQ] The end-to-end delivery of the entire message is the responsibility of the:\n(a) Network layer (b) Transport layer (c) Session layer (d) Presentation layer\nAns: (b) Transport layer",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
মনে রাখার চমৎকার ট্রিক:
• **Network Layer (Layer 3)**: ডাকপিয়নের মতো—সে আপনার চিঠিটি প্রাপকের অফিসের মেইন গেট পর্যন্ত পৌঁছে দেয় (Host-to-Host Delivery)। কিন্তু অফিসের ভেতরে কোন নির্দিষ্ট কর্মকর্তা (কোন অ্যাপ/প্রসেস) চিঠিটি পড়বে তা Network Layer জানে না।
• **Transport Layer (Layer 4)**: খাম খুলে ভেতরের পোর্ট নম্বর (Port Address) দেখে সরাসরি নির্দিষ্ট সফটওয়্যারের হাতে (Process-to-Process) সম্পূর্ণ মেসেজটি অক্ষত অবস্থায় তুলে দেয় এবং সব প্যকেট ঠিকমতো পৌঁছেছে কিনা নিশ্চিত করে (End-to-End Delivery)।
সুতরাং সম্পূর্ণ মেসেজের এন্ড-টু-এন্ড ডেলিভারির মূল দায়িত্ব **Transport Layer**-এর।

🇬🇧 English Exam Answer:
• Answer: (b) Transport layer
• Explanation:
  - **Transport Layer (Layer 4)** is explicitly designed for **End-to-End (Process-to-Process)** communication. It takes the entire message from the source application, fragments it into segments, assigns source and destination port numbers, reassembles them at the receiving endpoint, and verifies delivery reliability through error detection and ACKs (TCP).
  - Network Layer (Layer 3) only handles **Host-to-Host** packet delivery between IP endpoints across routers."
                },

                // ── 29. BB AME 2013: Digital Modulation Techniques ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2013, ExamOrg = "Bangladesh Bank", Post = "Assistant Maintenance Engineer", 
                    QuestionText = "[MCQ] Which of the following is a digital modulation technique?\n(a) DM (b) PCM (c) PSK (d) All\nAns: (d) All",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
ডিজিটাল মডুলেশন মানে ডিজিটাল ডাটা (0 ও 1) সিগন্যালে রূপান্তর করা:
১. **DM (Delta Modulation)**: এটি ১-বিট বিশিষ্ট ডিজিটাল মডুলেশন পদ্ধতি। বর্তমান সিগন্যাল আগের স্যাম্পলের চেয়ে একটু বাড়লে পাঠায় '1', আর কমলে পাঠায় '0'।
২. **PCM (Pulse Code Modulation)**: মানুষের অ্যানালগ কণ্ঠস্বরকে ডিজিটাল কম্পিউটারে ঢোকানোর সবচেয়ে জনপ্রিয় পদ্ধতি। ৩টি ধাপে কাজ করে: স্যাম্পলিং (Sampling), কোয়ান্টাইজেশন (Quantization), এবং বাইনারি কোডিং (Encoding)। অডিও সিডি এবং টেলিফোনে এটি ব্যবহৃত হয়।
৩. **PSK (Phase Shift Keying)**: ডিজিটাল 0 বা 1 বোঝাতে ক্যারিয়ার তরঙ্গের ফেজ বা দশা কোণ (যেমন 0° ও 180°) পরিবর্তন করে ডাটা পাঠানো হয়। আধুনিক Wi-Fi, 4G ও স্যাটেলাইটে PSK ব্যবহৃত হয়।
যেহেতু তিনটিই ডিজিটাল মডুলেশন টেকনিক, সঠিক উত্তর **(d) All**।

🇬🇧 English Exam Answer:
• Answer: (d) All
• Explanation:
  - **DM (Delta Modulation)**: A 1-bit differential analog-to-digital pulse modulation technique that encodes whether the current signal sample is higher or lower than the previous sample.
  - **PCM (Pulse Code Modulation)**: The fundamental method used to digitally represent sampled analog signals through Sampling, Quantization, and Binary Encoding (standard for digital telephony and uncompressed audio).
  - **PSK (Phase Shift Keying)**: A digital bandpass modulation technique that conveys digital binary data by modulating the phase of a constant-frequency reference carrier wave (BPSK, QPSK)."
                },

                // ── 30. BB AME 2013: 3 Components of Communication System ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2013, ExamOrg = "Bangladesh Bank", Post = "Assistant Maintenance Engineer", 
                    QuestionText = "[MCQ] The three major components of a communication system are:\n(a) Source, data rate and response time (b) Source, Link and receiver (c) Transmitter, link and receiver (d) Source, link and detector\nAns: (c) Transmitter, link and receiver",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
সহজ উপমা:
দুজন মানুষের কথোপকথনের কথা চিন্তা করুন—
১. কথা যে বলছে তার মুখ = **Transmitter (প্রেরক যন্ত্র)**: শব্দ বা তথ্য তৈরি করে প্রেরণ উপযোগী সিগন্যালে রূপান্তর করে।
২. বাতাস যার মধ্য দিয়ে শব্দ ভেসে যায় = **Transmission Link / Channel (যোগাযোগ মাধ্যম)**: ফাইবার অপটিক তার, কপার তার বা ওয়্যারলেস বেতার তরঙ্গ।
৩. যে শুনছে তার কান = **Receiver (গ্রাহক যন্ত্র)**: সিগন্যাল গ্রহণ করে পুনরায় মানুষের পাঠযোগ্য বা কম্পিউটারের ব্যবহারযোগ্য মূল তথ্যে রূপান্তর করে।
এই তিনটি ছাড়া কোনো যোগাযোগ সম্ভব নয়: Transmitter $\rightarrow$ Medium/Link $\rightarrow$ Receiver।

🇬🇧 English Exam Answer:
• Answer: (c) Transmitter, link and receiver
• Explanation:
  - Telecommunication and information theory defines the physical triad of every communication system as:
    1. **Transmitter (Sender)**: Converts the input message/information into an appropriate electromagnetic, optical, or electrical signal.
    2. **Transmission Medium / Channel (Link)**: The physical path (guided cable or unguided wireless spectrum) over which the signal travels from source to destination.
    3. **Receiver**: Intercepts the transmitted signal from the channel, decodes/demodulates it, and reconstructs the original message for the destination."
                },

                // ── 31. Sonali Bank 2026: Subnetting 192.168.1.0 into 4 Equal Subnets ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2026, ExamOrg = "Sonali Bank PLC", Post = "ADA", 
                    QuestionText = "Given IP 192.168.1.0, divide into 4 subnets of equal size. (A) Find the new subnet mask (CIDR). (B) Find the first usable host address of each subnet.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Step-by-Step):
সহজ উপমা:
একটি ৬৪ কাঠার বড় জমিকে ৪ জন ভাইয়ের মধ্যে সমান ৪ ভাগে ভাগ করে দেওয়া।
দেওয়া আছে: `192.168.1.0` (ডিফল্ট Class C প্রিফিক্স = `/24`)।

১. কয়টি সাবনেট বিট ধার করতে হবে?
৪টি সমান সাবনেট তৈরি করতে ফর্মুলা: $2^s \ge 4 \implies s = 2$ বিট ধার করতে হবে।
• নতুন সাবনেট প্রিফিক্স = $24 + 2 = \mathbf{/26}$।
• সাবনেট মাস্ক: প্রথম ২৬টি বিট '1' এবং বাকি ৬টি বিট '0'।
  `11111111.11111111.11111111.11000000` = **255.255.255.192**
• ব্লক সাইজ (Magic Number) = $256 - 192 = \mathbf{64}$। অর্থাৎ প্রতি সাবনেটে মোট ৬৪টি করে আইপি থাকবে।

২. প্রতি সাবনেটের ১ম ব্যবহারযোগ্য আইপি বের করার নিয়ম:
প্রতি সাবনেটের নেটওয়ার্ক আইপির সাথে ১ যোগ করলেই ১ম ব্যবহারযোগ্য আইপি পাওয়া যায় (First Usable = Network IP + 1):
• Subnet 1 (ব্লক 0 – 63):
  - নেটওয়ার্ক আইপি: `192.168.1.0`
  - ১ম ব্যবহারযোগ্য আইপি: **192.168.1.1** (লাস্ট: 192.168.1.62, ব্রডকাস্ট: 192.168.1.63)
• Subnet 2 (ব্লক 64 – 127):
  - নেটওয়ার্ক আইপি: `192.168.1.64`
  - ১ম ব্যবহারযোগ্য আইপি: **192.168.1.65** (লাস্ট: 192.168.1.126, ব্রডকাস্ট: 192.168.1.127)
• Subnet 3 (ব্লক 128 – 191):
  - নেটওয়ার্ক আইপি: `192.168.1.128`
  - ১ম ব্যবহারযোগ্য আইপি: **192.168.1.129** (লাস্ট: 192.168.1.190, ব্রডকাস্ট: 192.168.1.191)
• Subnet 4 (ব্লক 192 – 255):
  - নেটওয়ার্ক আইপি: `192.168.1.192`
  - ১ম ব্যবহারযোগ্য আইপি: **192.168.1.193** (লাস্ট: 192.168.1.254, ব্রডকাস্ট: 192.168.1.255)

🇬🇧 English Exam Answer:
• Given: Network `192.168.1.0/24`. We must partition it into 4 equal subnets.
• Formula: $2^s \ge N \implies 2^s \ge 4 \implies s = 2\text{ subnet bits borrowed}$.

(A) New Subnet Mask (CIDR):
• New CIDR Prefix = $24 + 2 = \mathbf{/26}$
• Binary Subnet Mask = `11111111.11111111.11111111.11000000`
• Dotted Decimal Subnet Mask = **255.255.255.192**
• Block Size / Interval = $256 - 192 = 64$

(B) First Usable Host Address of each subnet:
| Subnet # | Network ID | Usable Host Range | Broadcast ID | First Usable Host |
| :---: | :---: | :---: | :---: | :---: |
| **Subnet 1** | `192.168.1.0/26` | 192.168.1.1 – 192.168.1.62 | 192.168.1.63 | **192.168.1.1** |
| **Subnet 2** | `192.168.1.64/26` | 192.168.1.65 – 192.168.1.126 | 192.168.1.127 | **192.168.1.65** |
| **Subnet 3** | `192.168.1.128/26`| 192.168.1.129 – 192.168.1.190 | 192.168.1.191 | **192.168.1.129** |
| **Subnet 4** | `192.168.1.192/26`| 192.168.1.193 – 192.168.1.254 | 192.168.1.255 | **192.168.1.193** |"
                },

                // ── 32. Sonali Bank 2026: DNS Working Mechanism ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2026, ExamOrg = "Sonali Bank PLC", Post = "ADA", 
                    QuestionText = "What is DNS? How does DNS work?",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
১. DNS কী?
সহজ উপমা:
আপনার মোবাইলের 'কন্টাক্ট লিস্ট' বা ফোনবুকের কথা ভাবুন। আপনি নাম মনে রাখেন (যেমন: 'বাবা', 'বন্ধু রহিম'), কিন্তু ডায়াল করার সময় ফোন কল যায় ১০ ডিজিটের ফোন নম্বরে। 
মানুষের জন্য কোটি কোটি জটিল আইপি এড্রেস (যেমন: `142.250.190.46`) মনে রাখা অসম্ভব, কিন্তু নাম মনে রাখা সহজ (`google.com`)। ইন্টারনেটে নামকে আইপিতে রূপান্তরকারী বিশ্বব্যাপী ডেটাবেস সিস্টেমই হলো **DNS (Domain Name System)**।

২. DNS কীভাবে ধাপে ধাপে কাজ করে?
ধরা যাক আপনি ব্রাউজারে লিখলেন `www.sonalibank.com.bd`:
১. **Local Cache**: ব্রাউজার প্রথমে নিজের মেমরি ও উইন্ডোজের ক্যাশ চেক করে—আগে কখনো এই পেজে যাওয়া হয়েছিল কিনা।
২. **Recursive Resolver (ISP DNS)**: ক্যাশে না পেলে রিকোয়েস্ট যায় আপনার ইন্টারনেটের লোকাল ডিএনএস সার্ভারে।
৩. **Root DNS Server (.)**: লোকাল সার্ভার রুট সার্ভারকে জিজ্ঞাসা করে। রুট সার্ভার `.bd` ও `.com.bd` কান্ট্রি কোড TLD সার্ভারের ঠিকানা দেয়।
৪. **TLD DNS Server**: TLD সার্ভার `sonalibank.com.bd` এর মূল মালিকের **Authoritative Name Server** এর ঠিকানা দেয়।
৫. **Authoritative DNS Server**: এই সার্ভারে সোনালী ব্যাংকের আসল আইপিটি সেভ করা আছে (A Record)। সে মূল আইপিটি লোকাল সার্ভারকে দেয়।
৬. ব্রাউজার আইপিটি পেয়ে সরাসরি ব্যাংকের ওয়েব সার্ভারে কানেক্ট হয়ে পেজটি স্ক্রিনে তুলে ধরে।

🇬🇧 English Exam Answer:
• 1. Definition:
  DNS (Domain Name System) is a globally distributed, hierarchical, and decentralized naming database service that translates human-readable hostnames (e.g., `www.sonalibank.com.bd`) into machine-routable numerical IP addresses (e.g., `103.48.16.5`). It operates on UDP/TCP port 53.

• 2. DNS Resolution Workflow:
```
[Client Browser] ──(1) Query──> [ISP Recursive Resolver]
                                      │   ▲
                     (2) Query Root   │   │ (3) Refer to TLD Server (.)
                                      ▼   │
                                [Root DNS Servers]
                                      │   ▲
                     (4) Query TLD    │   │ (5) Refer to Authoritative (.bd)
                                      ▼   │
                                [TLD DNS Servers]
                                      │   ▲
               (6) Query Exact Domain │   │ (7) Return Web Server IP (A Record)
                                      ▼   │
                           [Authoritative DNS Server]
```
  1. **Client Cache Check**: Checks local browser, OS resolver cache, and `hosts` file.
  2. **Recursive Resolver Lookup**: If not cached, query is forwarded to the ISP Recursive Resolver.
  3. **Root Name Server Query**: Resolver contacts Root Server (`.`), receiving the address of the corresponding Top-Level Domain (TLD) server.
  4. **TLD Name Server Query**: Resolver contacts TLD server (e.g., `.com` or `.bd`), receiving the Authoritative Name Server reference.
  5. **Authoritative Name Server Query**: Contacts the domain's authoritative server, which holds the official Resource Records (`A`, `AAAA`, `CNAME`, `MX`).
  6. **Caching & Connection**: Resolver caches the record, passes the IP back to the browser, and client establishes an HTTP/HTTPS TCP session."
                },

                // ── 33. BSCS Sonali & Janata 2026: OSI Model Layers & Functions ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", 
                    QuestionText = "Mention the layers of the OSI Model and the function of each layer.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
মনে রাখার চমৎকার শর্টকাট (নিচ থেকে উপরে):
**P**lease **D**o **N**ot **T**ouch **S**teve's **P**et **A**lligator
1. **Physical** (লেয়ার ১):
   - কাজ: তার, ফাইবার অপটিক বা রেডিও ওয়েভের মধ্য দিয়ে 0 ও 1 এর ভোল্টেজ বা আলোর স্পন্দন পাঠানো (PDU: Bits)।
2. **Data Link** (লেয়ার ২):
   - কাজ: সরাসরি তারে যুক্ত দুটি পিসির মধ্যে ফ্রেম পাঠানো, MAC Address লাগানো এবং ত্রুটি ধরা (PDU: Frames)। ডিভাইস: Switch।
3. **Network** (লেয়ার ৩):
   - কাজ: IP Address দেখে ভিন্ন ভিন্ন নেটওয়ার্কের মধ্যে সবচেয়ে কম দূরত্বের রাস্তা দিয়ে প্যাকেট পাঠানো (PDU: Packets)। ডিভাইস: Router।
4. **Transport** (লেয়ার ৪):
   - কাজ: সম্পূর্ণ মেসেজটি অক্ষত অবস্থায় পৌঁছানো, স্পিড সামলানো (Flow Control) এবং পোর্ট নম্বরে ডেলিভারি (PDU: Segments)। প্রোটোকল: TCP, UDP।
5. **Session** (লেয়ার ৫):
   - কাজ: দুটি কম্পিউটারের সফটওয়্যারের মধ্যে ডায়ালগ/কথোপকথন শুরু করা, চালু রাখা ও শেষ করা (Session Synchronization & Checkpoints)।
6. **Presentation** (লেয়ার ৬):
   - কাজ: অনুবাদক ও সিকিউরিটি গার্ড—ডাটাকে ফরম্যাট করা (ASCII, JPEG), এনক্রিপশন/ডিক্রিপশন (SSL/TLS) এবং সাইজ ছোট করা (Compression)।
7. **Application** (লেয়ার ৭):
   - কাজ: ইউজারের হাতের কাছের সফটওয়্যারগুলোর জন্য নেটওয়ার্ক সার্ভিস দেওয়া (HTTP ব্রাউজার, SMTP ইমেইল, FTP ফাইল ট্রান্সফার)।

🇬🇧 English Exam Answer:
• The 7 Layers of the OSI (Open Systems Interconnection) Reference Model:
| Layer # | Layer Name | Protocol Data Unit (PDU) | Primary Responsibilities | Key Protocols & Devices |
| :---: | :--- | :--- | :--- | :--- |
| **7** | **Application** | Data | Direct user interface to network services; semantic application protocols. | HTTP, HTTPS, SMTP, DNS, FTP |
| **6** | **Presentation** | Data | Data syntax translation, character code conversion, encryption/decryption (TLS), data compression. | SSL/TLS, JPEG, MPEG, ASCII |
| **5** | **Session** | Data | Establishes, manages, synchronizes checkpoints, and terminates dialogs between application processes. | NetBIOS, RPC, PPTP, Sockets |
| **4** | **Transport** | Segment | End-to-end process delivery, port addressing, connection multiplexing, flow control, error recovery. | TCP, UDP (Ports) |
| **3** | **Network** | Packet | Logical addressing (IPv4/IPv6), subnet routing, path determination, and packet fragmentation. | IP, ICMP, OSPF, BGP, Routers |
| **2** | **Data Link** | Frame | Hop-to-hop physical frame delivery, MAC addressing, link flow control, media access control (CSMA/CD), error detection (CRC). | Ethernet, ARP, Switches, Bridges |
| **1** | **Physical** | Bit | Transmission of raw unstructured bit streams over physical transmission media, electrical/optical signaling. | Cables (Cat6, Fiber), Hubs, RJ-45 |"
                },

                // ── 34. BSCS Sonali & Janata 2026: TCP vs UDP Comparison ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", 
                    QuestionText = "Compare TCP and UDP protocols with examples.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
সহজ বাস্তব জীবনের উপমা:
• **TCP (ফোন কল বা রেজিস্টার্ড সরকারি চিঠি)**:
  - আপনি ফোন করে আগে নিশ্চিত হন অপর প্রান্তের লোক হ্যালো বলেছে কিনা (3-way Handshake)।
  - যদি লাইনে কোনো কথা কেটে যায়, আপনি পুনরায় বলেন—'শুনতে পাওনি? আমি আবার বলছি' (Retransmission)।
  - ব্যবহারের জায়গা: যেখানে ১টি অক্ষর বা ১ টাকার হিসাবও ভুল হওয়া চলবে না (যেমন: ব্যাংকিং লেনদেন, ওয়েবসাইট ব্রাউজিং HTTP/HTTPS, ইমেইল SMTP)।
• **UDP (লাইভ ক্রিকেট খেলার ধারাভাষ্য বা ড্রোন ভিডিও)**:
  - স্পিকার কথা বলে যাচ্ছে, শ্রোতা ১ সেকেন্ড শুনতে না পেলেও ধারাভাষ্যকার অতীতের কথা আবার বলে বর্তমান খেলা থামিয়ে রাখবে না!
  - কোনো হ্যান্ডশেক বা নিশ্চিতকরণ স্লিপ নেই, ফলে গতি অনেক বেশি।
  - ব্যবহারের জায়গা: যেখানে সামান্য ডাটা হারালেও ক্ষতি নেই কিন্তু গতি রিয়েল-টাইম হতে হবে (যেমন: লাইভ ভিডিও স্ট্রিমিং, অনলাইন ভিডিও গেম, VoIP ভয়েস কল, DNS কুয়েরি)।

🇬🇧 English Exam Answer:
• Comparison between TCP and UDP:
| Criteria | TCP (Transmission Control Protocol) | UDP (User Datagram Protocol) |
| :--- | :--- | :--- |
| **Connection Nature** | Connection-Oriented (Requires 3-Way Handshake: SYN, SYN-ACK, ACK). | Connectionless (No handshake; transmits data immediately). |
| **Reliability** | Highly Reliable (Guarantees delivery via Sequence numbers, ACKs, and Retransmission of lost segments). | Unreliable / Best-Effort (No acknowledgments, no automatic retransmission). |
| **Data Flow Ordering** | Guaranteed in-order delivery; segments are sequenced and reassembled correctly. | Out-of-order delivery possible; segments treated as independent datagrams. |
| **Header Size** | 20 to 60 Bytes (Variable due to options). | Fixed 8 Bytes (Source port, Dest port, Length, Checksum). |
| **Speed & Overhead** | Slower due to handshake, acknowledgments, and congestion control mechanisms. | Very Fast, low-latency, and minimal protocol overhead. |
| **Flow & Congestion Control**| Implements Sliding Window Flow Control and Congestion Avoidance algorithms. | No flow control or congestion control mechanism. |
| **Transmission Type** | Point-to-point Unicast only. | Supports Unicast, Multicast, and Broadcast. |
| **Real-World Applications** | Web (HTTP/HTTPS), Email (SMTP, IMAP), File Transfer (FTP), Remote Shell (SSH). | Video Streaming (YouTube Live, Zoom), VoIP, Online Gaming, DNS (Port 53), DHCP. |"
                },

                // ── 35. BSCS Sonali & Janata 2026: OSPF Packet Delivery ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", 
                    QuestionText = "Apply IP addressing and routing to explain how packets are delivered across networks using OSPF at the network layer.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
সহজ উপমা:
OSPF (Open Shortest Path First) হলো নেটওয়ার্কের জন্য **গুগল ম্যাপস (Google Maps)** এর মতো!
• ওএসপিএফ রাউটারগুলো একে অপরের কাছে 'হ্যালো' পাঠিয়ে বন্ধুত্ব করে এবং আশেপাশের রাস্তার স্পিড ও দূরত্ব (LSA - Link State Advertisement) শেয়ার করে।
• এরপর প্রতিটি রাউটার নিজের মেমরিতে পুরো দেশের সম্পূর্ণ রোড ম্যাপ (LSDB) তৈরি করে।
• রোড ম্যাপ তৈরি হলে বিখ্যাত **Dijkstra's Algorithm** চালিয়ে নিজের বাড়ি থেকে প্রতিটি গন্তব্যে যাওয়ার সবচেয়ে দ্রুত ও শর্টকাট পথ বের করে রাউটিং টেবিলে লিখে রাখে।
• যখনই কোনো পিসি ডাটা প্যাকেট পাঠায়, রাউটার প্যাকেটের Destination IP দেখে ম্যাপের শর্টকাট পোর্ট দিয়ে প্যাকেট বের করে দেয়।

🇬🇧 English Exam Answer:
• 1. Overview of OSPF:
  OSPF (Open Shortest Path First) is an Interior Gateway Protocol (IGP) based on Link-State routing technology that operates directly over IP (Protocol number 89) at the Network Layer.

• 2. Packet Delivery and Routing Mechanism:
  1. **Neighbor Discovery & Adjacency**: Routers send periodic `Hello` packets to multicast address `224.0.0.5` to discover neighbors, negotiate parameters, and elect a Designated Router (DR) and Backup DR (BDR) on multi-access networks.
  2. **LSA Flooding & Database Synchronization**: Each router generates Link-State Advertisements (LSAs) containing the status, IP prefixes, and metrics of its directly connected interfaces. LSAs are flooded throughout the OSPF area to build an identical Link-State Database (LSDB) in all routers.
  3. **Shortest Path Calculation (Dijkstra's SPF)**: Each router runs the Shortest Path First (SPF) algorithm treating itself as the root of the tree, calculating the loop-free lowest cumulative metric (Cost = $10^8 / \text{Bandwidth in bps}$) path to every destination subnet.
  4. **Populating the IP Routing Table**: The best computed routes are installed into the router's active IP Forwarding Information Base (FIB).
  5. **Data Packet Forwarding**: When an incoming IP packet arrives:
     - The router decapsulates the Layer 2 frame and reads the **Destination IP Address**.
     - It performs a longest-prefix match against the OSPF routes in its routing table.
     - The packet is re-encapsulated with the Layer 2 MAC address of the next-hop router and forwarded out the optimal egress interface."
                },

                // ── 36. BSCS Sonali & Janata 2026: Checksum Data Integrity ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", 
                    QuestionText = "Explain the logic of a \"Checksum\". How is it used to verify data integrity during file transfer?",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
সহজ উপমা:
মুদি দোকান থেকে মালামাল কেনার পর ক্যাশমেমোর নিচের 'টোটাল বিল' এর কথা ভাবুন।
আপনি যদি বাড়ি ফিরে ব্যাগের সব পণ্যের দাম যোগ করে দেখেন ক্যাশমেমোর টোটাল বিলের সাথে হুবহু মিলে গেছে, তার মানে কোনো পণ্য বাদ পড়েনি বা দামের হেরফের হয়নি। এটিই হলো **Checksum**।

ইন্টারনেটে চেকসাম যেভাবে কাজ করে (১'স কমপ্লিমেন্ট মেথড):
১. **প্রেরক প্রান্তে (Sender Side)**:
   - মূল ডাটাকে সমান মাপের ছোট ছোট টুকরায় (যেমন ১৬-বিট ওয়ার্ড) ভাগ করা হয়।
   - সব টুকরাকে বাইনারি 1's Complement পদ্ধতিতে যোগ করা হয় (যোগের পর কোনো অতিরিক্ত ক্যারি বিট থাকলে তা আবার নিচে এনে যোগ করা হয়—যাকে বলে End-Around Carry)।
   - সবশেষে মোট যোগফলকে উল্টে দেওয়া হয় (0 কে 1, আর 1 কে 0)—একে বলে **Checksum**। এই চেকসাম ডাটার সাথে পাঠিয়ে দেওয়া হয়।
২. **গ্রাহক প্রান্তে (Receiver Side)**:
   - রিসিভার সব ডাটা টুকরা এবং সাথে আসা চেকসামকে একসাথে পুনরায় 1's Complement এ যোগ করে।
   - **ম্যাজিক ভেরিফিকেশন**: যদি তারের মধ্যে কোনো বিট নষ্ট না হয়, তবে যোগফলের প্রতিটি বিট অবশ্যই **'1'** (সবগুলো 1 মানে 1's কমপ্লিমেন্টে 0) আসবে! যদি কোনো একটি বিটও 0 হয়, রিসিভার নিশ্চিত বুঝে যায় ফাইলে ত্রুটি ঘটেছে এবং ফাইলটি রিজেক্ট করে দেয়।

🇬🇧 English Exam Answer:
• 1. Logic of Checksum:
  A Checksum is an algorithmic redundancy check value computed from the contents of a data block to detect errors introduced during storage or network transmission. In Internet protocols (IP, TCP, UDP), it uses 16-bit 1's Complement addition.

• 2. Verification Mechanism during File/Packet Transfer:
  1. **Sender-Side Generation**:
     - The file or message buffer is segmented into equal $k$-bit words (typically 16 bits).
     - All 16-bit words are summed using 1's complement arithmetic (any carry out of the most significant bit is wrapped around and added to the least significant bit: End-Around Carry).
     - The 1's complement (bitwise NOT / inversion) of the accumulated sum is taken to generate the **Checksum field**.
     - The checksum is attached to the transmitted header/payload.
  2. **Receiver-Side Verification**:
     - The recipient receives the file payload along with the transmitted checksum.
     - The receiver sums all received 16-bit data words **plus the checksum** using identical 1's complement arithmetic.
  3. **Integrity Validation**:
     - If the transmission is error-free, the resulting sum evaluates to all 1s (i.e., `0xFFFF` in hexadecimal, which represents zero in 1's complement).
     - If any bit flipped during transmission, the sum contains at least one `0`, indicating file corruption. The receiver discards the damaged segment and requests retransmission."
                },

                // ── 37. Combined Bank 2025: DNS UDP vs TCP ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2025, ExamOrg = "Combined Bank (BIBM)", Post = "Officer IT", 
                    QuestionText = "Why does DNS primarily use UDP instead of TCP? Describe the sequence of events during DNS name resolution when user enters www.companybd.com into a browser.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
১. DNS কেন TCP বাদ দিয়ে UDP ব্যবহার করে?
• **গতি ও লেটেন্সি (Speed)**: ব্রাউজারের প্রশ্ন মাত্র ১ লাইনের: '`companybd.com` এর আইপি কত?' এবং উত্তরও ১ লাইনের: 'এই নিন আইপি: `103.4.5.6`'। এর জন্য TCP-র মতো ৩ বার হাত মেলানো (SYN, SYN-ACK, ACK) এবং ৩ বার কানেকশন ক্লোজ করা মানে অহেতুক ডাবল সময় নষ্ট। UDP-তে কোনো অপেক্ষা ছাড়াই ১ প্যাকেটে প্রশ্ন যায় এবং ১ প্যাকেটে উত্তর চলে আসে।
• **সার্ভারের লোড কম রাখা**: একটি বড় DNS সার্ভারকে প্রতি সেকেন্ডে লাখ লাখ ইউজারের রিকোয়েস্ট হ্যান্ডেল করতে হয়। TCP ব্যবহার করলে সার্ভার মেমরিতে লাখ লাখ কানেকশন স্টেট মনে রাখতে গিয়ে ক্র্যাশ করত।
*(ব্যতিক্রম: যখন রেসপন্স ৫১২ বাইটের চেয়ে বড় হয় বা দুটি ডিএনএস সার্ভারের মধ্যে সম্পূর্ণ জোন ফাইল কপি (Zone Transfer) করতে হয়, তখন DNS নির্ভরযোগ্যতার জন্য TCP ব্যবহার করে)।*

২. `www.companybd.com` টাইপ করলে কী কী ঘটে?
১. ব্রাউজার প্রথমে নিজের মেমোরি ও লোকাল অপারেটিং সিস্টেমে আইপি খোঁজে।
২. না পেলে লোকাল ISP Recursive Resolver-কে জিজ্ঞাসা করে।
৩. রিজলভার গ্লোবাল Root Server (`.`)-কে জিজ্ঞাসা করে; রুট সার্ভার `.com` TLD সার্ভারের ঠিকানা দেয়।
৪. রিজলভার `.com` সার্ভারকে জিজ্ঞাসা করে; সে `companybd.com` এর Authoritative DNS সার্ভারের ঠিকানা দেয়।
৫. রিজলভার Authoritative সার্ভার থেকে মূল আইপি (A Record) সংগ্রহ করে ব্রাউজারকে দেয়।
৬. ব্রাউজার আইপিতে সরাসরি কানেক্ট হয়ে ওয়েবসাইট লোড করে।

🇬🇧 English Exam Answer:
• 1. Why DNS Primarily Uses UDP:
  1. **Low Latency & High Speed**: A standard DNS lookup consists of a single request and a single response. UDP eliminates the Round-Trip Time (RTT) penalty of the TCP 3-way handshake and connection teardown.
  2. **Stateless Server Scalability**: UDP requires no connection states or transmission control blocks (TCBs), allowing busy DNS root and TLD servers to service hundreds of thousands of concurrent client queries without running out of socket memory.
  *(Exception: DNS fails over to TCP on port 53 when the response payload exceeds 512 bytes or during DNS Zone Transfers - AXFR/IXFR - between Primary and Secondary name servers).*

• 2. Resolution Sequence for `www.companybd.com`:
  1. **Client Cache Inspection**: Browser checks its internal DNS cache; if not found, it queries the OS DNS resolver cache and `hosts` file.
  2. **Recursive Resolver Forwarding**: If uncached locally, the client forwards a recursive DNS query to the ISP Recursive DNS Resolver.
  3. **Root Server Query**: The Recursive Resolver queries one of the 13 Root DNS servers (`.`) for `.com`.
  4. **TLD Referral**: The Root server responds with a referral to the `.com` Top-Level Domain (TLD) name servers.
  5. **TLD Server Query**: The resolver queries the `.com` TLD server, which responds with the IP of the Authoritative Name Server responsible for `companybd.com`.
  6. **Authoritative Lookup**: The resolver queries the Authoritative DNS server for the `A` record of `www.companybd.com`.
  7. **Answer & Caching**: The authoritative server returns the IP; the recursive resolver caches the record according to its TTL and returns the IP to the browser.
  8. **HTTP/HTTPS Connection**: Browser initiates a TCP 3-way handshake on Port 443 with the returned IP address."
                },

                // ── 38. Combined Bank 2025: SOAP vs REST ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2025, ExamOrg = "Combined Bank (BIBM)", Post = "Officer IT", 
                    QuestionText = "What are SOAP and RESTful APIs in web services? State one main difference between SOAP and REST in terms of how they exchange data.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
সহজ উপমা:
• **SOAP (সরকারি সিলমোহরযুক্ত চিঠি)**:
  - এটি একটি অত্যন্ত কঠোর ও ফর্মাল প্রোটোকল। ডাটাকে অবশ্যই একটি নির্দিষ্ট নিয়মের খামের (XML Envelope) ভেতর ঢুকিয়ে পাঠাতে হয়।
  - এতে বিল্ট-ইন উচ্চপর্যায়ের নিরাপত্তা (WS-Security) ও কঠোর ব্যাংকিং ট্রানজাকশন গ্যারান্টি (ACID compliance) থাকে। তাই বাংলাদেশ ব্যাংক, ভিসা/মাস্টারকার্ড এবং বড় পেমেন্ট গেটওয়েতে আজও SOAP ব্যাপকভাবে ব্যবহৃত হয়।
• **REST (আধুনিক স্মার্ট মেসেজিং / পোস্টকার্ড)**:
  - এটি কোনো কঠিন প্রোটোকল নয়, এটি একটি আর্কিটেকচারাল স্টাইল।
  - অত্যন্ত হালকা ও দ্রুত। ডাটা পাঠানোর জন্য কোনো ভারী খাম লাগে না; সাধারণ HTTP মেথড (GET, POST, PUT, DELETE) এবং হালকা ফরম্যাট **JSON** ব্যবহার করে। আধুনিক মোবাইল অ্যাপ ও সিঙ্গেল পেজ ওয়েবসাইটে REST সবচেয়ে বেশি জনপ্রিয়।

মূল পার্থক্য:
ডাটা আদান-প্রদানে SOAP কঠোরভাবে কেবল **XML** ফরম্যাট সাপোর্ট করে; পক্ষান্তরে REST বহুল ব্যবহৃত লাইটওয়েট **JSON** ছাড়াও XML, Text ও HTML সহ একাধিক ফরম্যাট সহজে ব্যবহার করতে পারে।

🇬🇧 English Exam Answer:
• 1. Definitions:
  - **SOAP (Simple Object Access Protocol)**: A rigid, standardized W3C communication protocol designed for exchanging structured, typed information in web services using XML envelopes, supporting enterprise-grade security (WS-Security) and ACID transactional reliability.
  - **REST (Representational State Transfer)**: An architectural design style for distributed hypermedia systems that leverages native HTTP standards (URLs, GET, POST, PUT, DELETE methods, status codes) to manipulate stateless resources.

• 2. Primary Difference in Data Exchange:
  - **SOAP is strictly XML-only**: Every message must be encapsulated in an XML envelope containing an optional `<Header>` and a mandatory `<Body>`, resulting in substantial payload overhead and slower parsing.
  - **REST is multi-format and JSON-centric**: REST primarily exchanges data in lightweight **JSON** (JavaScript Object Notation), but can also serialize data as XML, YAML, HTML, or Plain Text. JSON produces significantly smaller payloads, minimizes network bandwidth, and parses natively in web browsers and mobile apps."
                },

                // ── 39. Combined 3 Bank 2024: Classful to Classless (CIDR) Motivation ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "ADA", 
                    QuestionText = "What is the primary motivation for moving from classful IP addressing to classless IP addressing (CIDR)?",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
সহজ উপমা (রেডিমেড কাপড় বনাম টেইলারের দোকান):
১. **Classful IP এর সমস্যা (পুরনো রেডিমেড পোশাক)**:
   - আগে কেবল ৩ সাইজের নেটওয়ার্ক বরাদ্দ দেওয়া হতো:
     * Class C: মাত্র ২৫৪টি আইপি (খুব ছোট)।
     * Class B: ৬৫,৫৩৪টি আইপি (বিশাল বড়)।
     * Class A: ১ কোটি ৬৭ লাখ আইপি (অতিকায়)।
   - এখন একটি ব্যাংকের যদি ৫০০টি আইপি প্রয়োজন হতো, তাকে Class C দিলে হতো না (কারণ ২৫৪ জনের বেশি ধরে না)। বাধ্য হয়ে তাকে একটি পুরো Class B বরাদ্দ দেওয়া হতো! ফলে ৫০০টি আইপি ব্যবহারের পর বাকি ৬৫,০০০ আইপি চিরদিনের জন্য অপচয় হতো। এ কারণে নব্বইয়ের দশকে ইন্টারনেটের আইপি খুব দ্রুত শেষ হতে শুরু করে (IPv4 Address Depletion)।
২. **CIDR বা Classless এর সমাধান (টেইলারের মাপমতো পোশাক)**:
   - CIDR (Classless Inter-Domain Routing) এই ক্লাস প্রথা তুলে দেয় এবং স্ল্যাশ নোটেশন (`/23`, `/26`, `/29`) চালু করে। কারো ৫০০ আইপি লাগলে তাকে ঠিক `/23` (৫১২টি আইপি) দেওয়া হয়—অপচয় শূন্য!
৩. **রাউটিং টেবিল ছোট রাখা (Supernetting / Route Aggregation)**:
   - লাখ লাখ ছোট ছোট রুটকে সামারাইজ করে একটি সিঙ্গেল লাইনে পরিণত করা হয়, ফলে গ্লোবাল ইন্টারনেটের মূল রাউটারগুলোর মেমরি ক্র্যাশ হওয়া থেকে রক্ষা পায়।

🇬🇧 English Exam Answer:
• Primary Motivations for Transitioning from Classful Addressing to CIDR:
  1. **Mitigating IPv4 Address Exhaustion**:
     - In classful addressing, fixed boundaries (Class A: `/8`, Class B: `/16`, Class C: `/24`) caused severe address wastage. An organization requiring 500 host addresses could not fit into a Class C (254 hosts) and was forced to obtain a Class B block (65,534 hosts), wasting over 65,000 valid public IPs.
     - CIDR introduces arbitrary bit-length subnet masks (VLSM), allowing ISPs to allocate exact prefix lengths (e.g., `/23` for 510 usable hosts) perfectly matching organizational demand.
  2. **Preventing Global Routing Table Explosion (Route Aggregation / Supernetting)**:
     - Under classful routing, every individual network ID had to be explicitly advertised, causing router routing tables across the internet core to grow exponentially toward hardware memory exhaustion.
     - CIDR allows contiguous network blocks to be aggregated into a single summarized prefix advertisement (e.g., four contiguous `/24` networks combined into a single `/22` route), vastly decreasing routing table sizes and routing protocol convergence times."
                },

                // ── 41. Combined 3 Bank 2024: Active Directory in Office Environment ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "Senior Officer IT", 
                    QuestionText = "What is Active Directory? Office with 3 departments × 50–70 employees on Windows — do you need Active Directory? Briefly explain its use.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
১. Active Directory (AD) কী?
সহজ উপমা:
একটি বিশাল ভবনের 'সেন্ট্রাল সিকিউরিটি ও আইডি কার্ড কন্ট্রোল রুম'। মাইক্রোসফট উইন্ডোজ সার্ভারের এমন একটি ডিরেক্টরি সার্ভিস যা পুরো প্রতিষ্ঠানের সমস্ত কম্পিউটার, প্রিন্টার, ইউজার একাউন্ট ও পারমিশন এক জায়গা থেকে নিয়ন্ত্রণ করে।

২. ১৫০–২১০ জন কর্মীর (৩টি ডিপার্টমেন্ট × ৫০–৭০ জন) অফিসে কি Active Directory প্রয়োজন?
**হ্যাঁ, অবশ্যই অত্যন্ত প্রয়োজন (Critically Required)।**
কারণ:
যদি AD না থাকে (Workgroup মডেল), তবে আইটি অফিসারকে:
- ২১টি আলাদা পিসিতে গিয়ে ম্যানুয়ালি ইউজারনেম ও পাসওয়ার্ড বানাতে হবে।
- কোনো কর্মী চাকরি ছাড়লে প্রতিটি পিসিতে গিয়ে একাউন্ট ডিলিট করতে হবে।
- কারও পাসওয়ার্ড রিসেট করতে তার টেবিলে দৌড়াতে হবে। এটি পুরোপুরি বিশৃঙ্খলা সৃষ্টি করবে।

৩. এই অফিসে Active Directory-র মূল সুবিধাসমূহ:
• **Centralized User Management**: মাত্র একজন আইটি অ্যাডমিন সার্ভার রুমে বসেই ২০০+ কর্মীর আইডি তৈরি, পাসওয়ার্ড পলিসি এবং ডিপার্টমেন্টাল পারমিশন নিয়ন্ত্রণ করতে পারবেন।
• **Group Policy Objects (GPO)**: এক ক্লিকেই অ্যাকাউন্টস ডিপার্টমেন্টের ৫০টি পিসিতে পেনড্রাইভ/ইউএসবি ব্লক করা, সফটওয়্যার ইন্সটল বা অটোমেটিক উইন্ডোজ আপডেট পুশ করা সম্ভব।
• **Single Sign-On (SSO)**: কর্মী অফিসে যে পিসিতেই বসুক না কেন, তার নিজস্ব ইউজারনেম-পাসওয়ার্ড দিয়ে লগইন করলেই তার পারসোনাল ডেস্কটপ ফাইল ও পারমিশন চলে আসবে।
• **Role-Based Security**: এইচআর কর্মীরা ফাইন্যান্সের সার্ভার দেখতে পারবে না, আবার ফাইন্যান্সের কর্মীরা আইটির সিকিউরিটি ফাইলে ঢুকতে পারবে না।

🇬🇧 English Exam Answer:
• 1. Definition of Active Directory (AD):
  Active Directory Domain Services (AD DS) is Microsoft's centralized directory service and Identity and Access Management (IAM) architecture for Windows domain networks. It stores information about network objects (users, groups, computers, printers, shares) in a secure, hierarchical database and manages authentication and authorization.

• 2. Necessity for the Given Office (3 Departments × 50–70 Employees = 150 to 210 Users):
  **Yes, Active Directory is essential.** 
  A decentralized Workgroup model becomes completely unmanageable beyond 10–15 computers. Managing 150–210 separate local SAM databases would lead to severe administrative overhead, credential sprawl, and critical security vulnerabilities.

• 3. Key Benefits and Uses in this Office:
  1. **Centralized Identity & Access Management (IAM)**: System administrators provision, suspend, or modify all 200+ user credentials and access permissions from a single domain controller console.
  2. **Group Policy Objects (GPO)**: Enables automated enforcement of enterprise security baselines (e.g., enforcing password complexity, restricting USB flash drives for the Accounts department, automating software deployment and OS security patches across all client endpoints).
  3. **Single Sign-On (SSO)**: Employees use a single corporate set of credentials to authenticate seamlessly to workstations, departmental file shares, network printers, and internal enterprise applications.
  4. **Departmental Organizational Units (OUs)**: Logical grouping of objects into OUs (`OU=Accounts`, `OU=HR`, `OU=Marketing`) allows delegated administration and targeted access control policies."
                },

                // ── 42. Combined 3 Bank 2024: Subnet Benefits ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "Senior Officer IT", 
                    QuestionText = "What is a subnet? What benefits will you get using subnets for this office?",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
সহজ উপমা:
একটি বিশাল বড় খোলা হলরুমে যদি ২০০ জন মানুষ বসে একসাথে কথা বলে, তবে কেউ কারো কথা স্পষ্ট শুনতে পাবে না—চারিদিকে শুধু কোলাহল ও বিশৃঙ্খলা তৈরি হবে (একে নেটওয়ার্কের ভাষায় বলে Broadcast Storm)। কিন্তু সেই বড় হলরুমটিকে যদি ৩টি কাঁচের পার্টিশন দিয়ে ৩টি আলাদা রুম বানিয়ে দেওয়া হয় (যেমন: Accounts রুম, HR রুম, IT রুম), তবে সবাই শান্তিতে কাজ করতে পারবে। এই পার্টিশন দেওয়ার প্রযুক্তিটিই হলো **Subnetting**।

১. Subnet কী?
একটি বড় একক আইপি নেটওয়ার্ককে (যেমন: `192.168.1.0/24`) লজিক্যালি ভেঙে একাধিক ছোট, স্বাধীন ও স্বয়ংসম্পূর্ণ সাব-নেটওয়ার্কে বিভক্ত করাই হলো সাবনেট (Subnet)।

২. এই অফিসে সাবনেট ব্যবহারের ৪টি প্রধান সুবিধা:
• **ব্রডকাস্ট ট্রাফিক নিয়ন্ত্রণ (Reduced Network Congestion)**: যখন কোনো পিসি নেটওয়ার্কে ব্রডকাস্ট পাঠায় (যেমন: ARP কুয়েরি), তা কেবল সেই সাবনেটের মধ্যেই সীমাবদ্ধ থাকে। অন্য ডিপার্টমেন্টের কম্পিউটারে গিয়ে অহেতুক জ্যাম ও ধীরগতি তৈরি করে না।
• **নিরাপত্তা ও এক্সেস কন্ট্রোল (Enhanced Security)**: সাবনেট করার ফলে রাউটার বা ফায়ারওয়ালে অ্যাক্সেস কন্ট্রোল লিস্ট (ACL) বসিয়ে এক ডিপার্টমেন্টের ডাটা অন্য ডিপার্টমেন্ট থেকে লক করা যায় (যেমন: সাধারণ কর্মচারীরা Accounts এর সার্ভারে ঢুকতে পারবে না)।
• **আইপি ঠিকানার অপচয় রোধ (Efficient IP Allocation)**: VLSM ব্যবহার করে যে ডিপার্টমেন্টে যতগুলো পিসি আছে ঠিক ততগুলো আইপি বরাদ্দ দেওয়া যায়।
• **সহজ ট্রাবলশুটিং (Simplified Troubleshooting)**: নেটওয়ার্কে কোনো ভাইরাস আক্রমণ বা কেবল নষ্ট হলে সাথে সাথে চিহ্নিত করা যায় কোন ডিপার্টমেন্টের সাবনেটে সমস্যা হয়েছে, পুরো অফিস ডাউন হয় না।

🇬🇧 English Exam Answer:
• 1. Definition of Subnet:
  A Subnet (Subnetwork) is a logical, segmented subdivision of an IP network. Subnetting partitions a single large broadcast domain into multiple smaller, administratively isolated network segments by borrowing host bits for network addressing.

• 2. Key Benefits of Subnets for the Office Environment:
  1. **Containment of Broadcast Traffic**: High volumes of broadcast and multicast frames (e.g., ARP requests) are confined within departmental subnet boundaries, eliminating broadcast storms and preserving overall switch backplane bandwidth.
  2. **Enhanced Security & Access Control**: Enables enforcement of Layer 3 security policies via Access Control Lists (ACLs) and firewalls between subnets, restricting unauthorized lateral movement between departments (e.g., isolating Financial/Accounts data from General Staff).
  3. **Optimized IP Address Allocation (VLSM)**: Prevents IP wastage by provisioning exact subnet sizes (`/26`, `/27`) aligned with departmental headcount.
  4. **Isolated Fault Tolerance & Easier Troubleshooting**: Network failures, IP conflicts, or malware infections are contained within a single subnet without impacting the operational stability of the entire enterprise."
                },

                // ── 43. Combined 3 Bank 2024: Repeater, Hub, Bridge, Switch, Router ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "Senior Officer IT", 
                    QuestionText = "Briefly describe: Repeater, Hub, Bridge, Switch, and Router.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
বাস্তব জীবনের চমৎকার উপমা দিয়ে মনে রাখুন:
১. **Repeater (মাইক্রোফোন বা লাউডস্পিকার)**:
   - অনেক দূরের তারে চলতে চলতে সিগন্যাল যখন দুর্বল (Attenuated) হয়ে যায়, রিপিটার সেই দুর্বল সিগন্যালটিকে রি-জেনারেট ও অ্যামপ্লিফাই করে আবার নতুনের মতো শক্তিশালী করে দেয়। (OSI Layer 1: Physical)।
২. **Hub (বোকা পিয়ন)**:
   - চিঠির খামের উপরে যার নামই লেখা থাকুক না কেন, সে ক্লাসরুমে ঢুকে চিৎকার করে সবার হাতে এক কপি করে চিঠি বিলিয়ে দেয়! কে প্রাপক তা সে বুঝতে পারে না। ফলে সব পিসি একসাথে ডাটা পাঠালে সংঘর্ষ (Collision) হয়। (OSI Layer 1: Physical, Shared Collision Domain)।
৩. **Bridge (ট্রাফিক কনস্টেবল)**:
   - রাস্তার দুই পাশের ভিড় আলাদা করার জন্য মাঝখানে দাঁড়ানো কনস্টেবল। এটি হার্ডওয়্যার MAC Address পড়তে পারে। এক পাশের গাড়ি অপ্রয়োজনে অন্য পাশে যেতে দেয় না। (OSI Layer 2: Data Link)।
৪. **Switch (বুদ্ধিমান ও বিচক্ষণ ডাকপিয়ন)**:
   - এটি একটি মাল্টি-পোর্ট ইন্টেলিজেন্ট ব্রিজ। প্রতিটি পোর্টের সাথে কোন পিসির MAC Address যুক্ত তা সে নিজের 'MAC Table' এ মুখস্থ রাখে। কোনো চিঠি আসলে সে নির্বিচারে সবাইকে না পাঠিয়ে সরাসরি নির্দিষ্ট প্রাপকের টেবিলে গিয়ে পৌঁছে দেয়। (OSI Layer 2/3: Dedicated Collision Domain per port)।
৫. **Router (আন্তর্জাতিক বিমানবন্দর কাস্টমস ও কন্ট্রোল রুম)**:
   - এটি পাসপোর্ট দেখে দেশ চেনার মতো লজিক্যাল IP Address চেনে। ঢাকা থেকে চট্টগ্রাম বা আমেরিকার ভিন্ন ভিন্ন নেটওয়ার্কের মধ্যে ইন্টারনেটের কোটি কোটি রাস্তার মধ্য থেকে সবচেয়ে দ্রুততম পথ (Shortest Path) বের করে প্যাকেট পৌঁছে দেয়। (OSI Layer 3: Network, Separates Broadcast Domains)।

🇬🇧 English Exam Answer:
• Structured Comparison of Key Networking Devices:
| Device | OSI Layer | Operating Address | Collision Domain | Broadcast Domain | Primary Function |
| :--- | :---: | :---: | :---: | :---: | :--- |
| **Repeater** | Layer 1 | None (Bits) | Single shared | Single shared | Regenerates and amplifies attenuated electrical/optical signals to extend cable reach. |
| **Hub** | Layer 1 | None (Bits) | Single shared (High collisions) | Single shared | Multiport repeater that blindly broadcasts incoming signals to all connected ports. |
| **Bridge** | Layer 2 | Physical (MAC) | 2 separate collision domains | Single shared | Connects two LAN segments; filters traffic based on MAC address tables. |
| **Switch** | Layer 2 (or 3) | MAC (or IP) | Separate dedicated domain per port | Single shared (unless partitioned by VLANs) | Multiport intelligent bridge that forwards frames exclusively to destination ports via CAM/MAC table. |
| **Router** | Layer 3 | Logical (IP) | Separate domain per interface | **Separates broadcast domains** | Routes packets across disparate networks using routing tables (OSPF, BGP) and determines best paths. |"
                },

                // ── 44. Combined 3 Bank 2024: Transmission Media ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "Senior Officer IT", 
                    QuestionText = "What are the different types of transmission media used for data communication? Explain their advantages and disadvantages.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
ডাটা চলাচলের মাধ্যমকে প্রধানত ২টি ভাগে ভাগ করা যায়:
১. **Guided Media (তারযুক্ত বা আবদ্ধ মাধ্যম)**:
   - উপমা: পাইপলাইনের মধ্য দিয়ে পানি পাঠানো। ডাটা নির্দিষ্ট তারের ভেতর সীমাবদ্ধ থাকে।
   • **Twisted Pair Cable (UTP/STP)**: আমাদের ল্যানের চেনা নীল তার। দুই জোড়া তার একে অপরের সাথে প্যাঁচানো থাকে যাতে নয়েজ কমে।
     - সুবিধা: অত্যন্ত সস্তা, নমনীয় এবং সহজে ইন্সটল করা যায়।
     - অসুবিধা: দূরত্ব সর্বোচ্চ ১০০ মিটার; উচ্চ গতিতে নয়েজের প্রভাব পড়ে।
   • **Coaxial Cable (ডিশের তার)**: সেন্ট্রাল কপার তার এবং চারপাশে জালের মতো মেটাল শিল্ড।
     - সুবিধা: ভালো শিল্ডিং ও নয়েজ প্রতিরোধ ক্ষমতা।
     - অসুবিধা: ভারী, তার বাঁকানো কঠিন এবং আধুনিক ল্যানে অচল।
   • **Fiber Optic Cable (কাঁচের পাইপে আলোর নাচ)**: সম্পূর্ণ কাঁচ বা প্লাস্টিকের তন্তুর ভেতর দিয়ে আলোর পূর্ণ অভ্যন্তরীণ প্রতিফলনে (Total Internal Reflection) ডাটা চলে।
     - সুবিধা: অবিশ্বাস্য গতি (100+ Gbps), দূরপাল্লার সংযোগ (কিলোমিটারের পর কিলোমিটার) এবং কোনো তড়িৎ-চৌম্বক নয়েজ (EMI) ধরে না।
     - অসুবিধা: তার ও যন্ত্রপাতির দাম বেশি এবং জোড়া লাগানো (Splicing) অত্যন্ত জটিল।

২. **Unguided Media (তারবিহীন বা উন্মুক্ত মাধ্যম)**:
   - উপমা: খোলা বাতাসে মাইকে কথা বলা।
   • **Radio Waves**: সর্বমুখী (Omnidirectional)। দেয়াল ভেদ করতে পারে (Wi-Fi, সেলুলার নেটওয়ার্ক, এফএম রেডিও)।
   • **Microwaves**: একমুখী (Unidirectional - Line of Sight)। পাহাড় বা টাওয়ারের এক অ্যান্টেনা সরাসরি অন্য অ্যান্টেনার মুখোমুখি থাকতে হয় (মোবাইল টাওয়ার ব্যাকহোল, স্যাটেলাইট)।
   • **Infrared**: স্বল্প দূরত্বের আলো যা দেয়াল ভেদ করতে পারে না (টিভি রিমোট, নাইট ভিশন ক্যামেরা)।

🇬🇧 English Exam Answer:
• Classification of Transmission Media:
```
                   Transmission Media
                  /                  \
        Guided (Wired)            Unguided (Wireless)
       /       |      \           /        |        \
Twisted-Pair Coaxial Fiber-Optic Radio-Wave Microwave Infrared
```
• Comparative Analysis:
| Media Type | Bandwidth / Speed | Maximum Distance | Advantages | Disadvantages |
| :--- | :--- | :--- | :--- | :--- |
| **Twisted Pair (Cat6/Cat6a)** | Up to 10 Gbps | 100 meters | Inexpensive, easy installation, flexible. | Susceptible to EMI/RFI, limited transmission range. |
| **Coaxial Cable** | 10 – 100 Mbps | 200 – 500 meters | Moderate noise immunity, sturdy. | Bulky, rigid, costly termination, outdated for LANs. |
| **Fiber Optic (SMF/MMF)** | 100 Gbps – Terabits | Tens of kilometers | Immune to EMI, enormous bandwidth, lowest attenuation. | Expensive hardware, fragile glass core, complex splicing. |
| **Radio Waves** | Megabits – Gbps | Varies (Local/City) | Omnidirectional, penetrates walls, high mobility (Wi-Fi). | Prone to multipath fading and radio frequency interference. |
| **Terrestrial Microwave**| Hundreds of Mbps | Up to 50 km | High capacity, ideal for rugged terrains without cabling. | Requires strict Line-of-Sight (LoS); weather attenuation. |"
                },

                // ── 45. Combined 2 Bank 2024: Flow Control vs Congestion Control ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2024, ExamOrg = "Combined 2 Bank (BIBM)", Post = "Officer IT", 
                    QuestionText = "Explain difference between flow-control and congestion control. Discuss the impact of stable end-to-end latency.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
১. Flow Control vs Congestion Control এর পার্থক্য:
সহজ উপমা:
• **Flow Control (খাওয়ানোর গতি নিয়ন্ত্রণ)**:
  - মা ছোট বাচ্চাকে চামচ দিয়ে খাইয়ে দিচ্ছেন। বাচ্চা গিলতে না পারলে মা আর চামচ মুখে দেয় না। এটি হলো সেন্ডার এবং রিসিভারের পারস্পরিক গতি নিয়ন্ত্রণ। সেন্ডার খুব ফাস্ট ডাটা পাঠালে স্লো রিসিভারের মেমরি ওভারফ্লো হয়ে ডাটা ড্রপ যেন না হয়, সেজন্য রিসিভার `rwnd` (Receiver Window) সাইজ জানিয়ে সেন্ডারকে নিয়ন্ত্রণ করে (Point-to-Point)।
• **Congestion Control (রাস্তার ট্রাফিক জ্যাম সামলানো)**:
  - শহরের সব গাড়ি যদি একসাথে রাস্তায় নেমে পড়ে, তবে পুরো শহর জ্যামে অচল হয়ে যায়। তখন ট্রাফিক সিগন্যালে গাড়ি ছাড়া নিয়ন্ত্রণ করা হয়। এটি পুরো নেটওয়ার্কের রাউটার ও সুইচগুলোর জ্যাম সামলানো। সেন্ডার ও রিসিভার উভয়েই সুপারফাস্ট হতে পারে, কিন্তু মাঝের রাউটার যদি লোড নিতে না পারে তখন সেন্ডার নিজের স্পিড `cwnd` (Congestion Window) কমিয়ে দেয় (Network-Wide)।

২. Stable End-to-End Latency এর গুরুত্ব:
ব্যাংকিং অনলাইন ট্রানজাকশন বা কার্ড পেমেন্টে লেটেন্সি ওঠানামা (Jitter) করলে:
- রিকোয়েস্ট টাইমআউট হয়ে একাউন্ট থেকে দুইবার টাকা কেটে যেতে পারে।
- ভিপিএন ও কোর ব্যাংকিং সেশন ডিসকানেক্ট হয়ে ক্যাশিয়ারের সিস্টেম হ্যাং করতে পারে।
লেটেন্সি স্থির (Stable) থাকলে প্রিডিক্টেবল পারফরম্যান্স ও নিরাপদ লেনদেন নিশ্চিত হয়।

🇬🇧 English Exam Answer:
• 1. Flow Control vs Congestion Control:
| Parameter | Flow Control | Congestion Control |
| :--- | :--- | :--- |
| **Objective** | Prevents a fast sender from overwhelming a slow receiver's buffer. | Prevents intermediate network switches/routers from overflowing due to excessive aggregate traffic. |
| **Scope** | Point-to-Point (End-to-End between sender and receiver). | Network-Wide (Aggregate traffic across shared network infrastructure). |
| **Control Parameter** | Advertised Receiver Window (`rwnd`) sent in TCP header. | Calculated Congestion Window (`cwnd`) maintained by sender. |
| **Feedback Mechanism**| Explicit feedback in TCP ACKs from receiver. | Implicit or explicit loss signals (Timeout, 3 Duplicate ACKs, ECN). |
| **Governing Law** | $\text{Transmission Window} = \min(cwnd, rwnd)$. | Governed by AIMD, Slow Start, and Congestion Avoidance algorithms. |

• 2. Impact of Stable End-to-End Latency:
  1. **Elimination of Packet Jitter**: Critical for real-time interactive banking operations (ATM switching, POS gateways, and live financial teleconferencing).
  2. **Accurate Retransmission Timeouts (RTO)**: Stable RTT enables TCP to compute accurate timeouts, eliminating spurious duplicate retransmissions.
  3. **High Transaction Throughput**: Guarantees deterministic SLA adherence and eliminates session drops in mission-critical database synchronizations."
                },

                // ── 46. Combined 5 Bank 2023: CRC Error Detection Probability ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Combined 5 Bank (BIBM)", Post = "Officer IT", 
                    QuestionText = "CRC with generator 11101010111. What is the probability of detecting a burst error of length 10?",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept & Step-by-Step Math):
সহজ উপমা:
তালার চাবির দাঁত এবং খাঁজের কথা চিন্তা করুন। চাবির খাঁজের মাপ যদি ১০টি দাঁতের হয়, তবে ১০টি দাঁত বা তার চেয়ে ছোট যেকোনো বিকৃতি এই তালা দিয়ে ১০০% নিশ্চিত ধরা পড়বে।

দেওয়া আছে:
• জেনারেটর পলিনোমিয়াল ($G$) = `11101010111`
• জেনারেটরে মোট বিট সংখ্যা ($k$) = ১১টি।
• জেনারেটরের ডিগ্রি ($r$) = $\text{বিট সংখ্যা} - 1 = 11 - 1 = \mathbf{10}$।

CRC এর স্বর্ণালী নিয়ম (CRC Burst Error Theorems):
১. যদি কোনো Burst Error এর দৈর্ঘ্য ($L$) জেনারেটরের ডিগ্রির ($r$) সমান বা ছোট হয় ($L \le r$), তবে CRC **১০০% নিশ্চয়তার সাথে (Probability = 1.0 বা 100%)** সেই ত্রুটি শনাক্ত করতে পারে!
২. এখানে Burst Error এর দৈর্ঘ্য $L = 10$, এবং জেনারেটরের ডিগ্রিও $r = 10$ ($L = r$)।
৩. সুতরাং এই ১০ দৈর্ঘ্যের বার্স্ট এররটি **১০০% নিশ্চিতভাবে ডিটেক্ট হবে**।

গাণিতিক উত্তর:
• Probability of Detection = **1.0 (বা 100%)**।
*(উল্লেখ্য: যদি এররের দৈর্ঘ্য $L = r+1 = 11$ হতো, তবে না ধরার সম্ভাবনা থাকত $1/2^{r-1} = 1/2^9$ বা ডিটেকশন রেট ৯৯.৮%)।*

🇬🇧 English Exam Answer:
• 1. Mathematical Analysis:
  - Given Generator Bit String: $G = 11101010111$
  - Number of bits in Generator ($k$) = $11$ bits.
  - Degree of Generator Polynomial ($r$) = $k - 1 = 11 - 1 = 10$.
  - Given Burst Error Length ($L$) = $10$.

• 2. Theoretical Foundations of CRC Error Detection:
  According to standard cyclic code theory (Peterson & Brown):
  - Any burst error of length $L \le r$ (where $r$ is the degree of the generator polynomial) is **guaranteed to be detected with 100% probability**.
  - A burst error of length $L$ can be expressed as $E(x) = x^i \cdot B(x)$, where $B(x)$ is a polynomial of degree $(L - 1)$ with the highest and lowest coefficients equal to 1.
  - Since $L = 10$, the degree of $B(x)$ is $10 - 1 = 9$.
  - The generator polynomial $G(x)$ has degree $r = 10$.
  - Since the degree of $B(x)$ is strictly less than the degree of $G(x)$, $B(x)$ can never be divisible by $G(x)$ unless $B(x) = 0$.
  - Consequently, the error polynomial $E(x)$ will always yield a non-zero remainder when divided by $G(x)$.

• 3. Conclusion:
  - **Probability of detecting the burst error of length 10 = 1.0 (or 100%)**."
                },

                // ── 47. Combined Bank 2023: TCP vs UDP, CAT5 vs CAT6, FAT32 vs NTFS ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Combined Bank (BIBM)", Post = "Officer IT", 
                    QuestionText = "Difference between TCP and UDP, CAT5 and CAT6, FAT32 and NTFS.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
৩টি গুরুত্বপূর্ণ তুলনার সহজ উপমা:

১. **TCP vs UDP**:
   - TCP (রেজিস্টার্ড সরকারি চিঠি): চিঠি পাওয়ার পর রিসিভারকে সই দিতে হয়। না পেলে আবার পাঠায় (Reliable, Handshake, Banking, Email)।
   - UDP (লাইভ ভিডিও ব্রডকাস্ট): ভিডিওর ১টি ফ্রেম মিস হলেও আগের ফ্রেম আবার পাঠিয়ে বর্তমান ভিডিও থামিয়ে রাখা যাবে না—গতিই আসল (Fast, Stateless, Live Cricket, DNS)।

২. **CAT5e vs CAT6**:
   - CAT5e (২-লেনের সাধারণ পাকা রাস্তা): সর্বোচ্চ 1 Gbps গতি এবং 100 MHz ফ্রিকোয়েন্সি।
   - CAT6 (৮-লেনের এক্সপ্রেসওয়ে): সর্বোচ্চ 10 Gbps গতি এবং 250 MHz ফ্রিকোয়েন্সি। তারের ভেতর ৪ জোড়া তারকে আলাদা রাখার জন্য একটি শক্ত প্লাস্টিকের প্লাস চিহ্নের মতো স্প্লাইন (Cross-Spline) থাকে, যাতে ভেতরের তারগুলোর নিজেদের মধ্যে সিগন্যাল ধাক্কাধাক্কি (Crosstalk) না হয়।

৩. **FAT32 vs NTFS**:
   - FAT32 (পুরনো কাঠের আলমারি): যেকোনো একক ফাইলের সাইজ সর্বোচ্চ ৪ জিবি (4 GB) হতে পারে। এর বড় কোনো ভিডিও বা ডাটাবেস ফাইল এতে সেভ করা যায় না। এতে কোনো পাসওয়ার্ড, পারমিশন বা বিদ্যুৎ চলে গেলে ডাটা রিকভার করার জার্নালিং নেই (পেনড্রাইভে চলে)।
   - NTFS (আধুনিক ডিজিটাল ব্যাংক লকার): ১৬ টেরাবাইট পর্যন্ত ফাইল সেভ করা যায়। ফাইল এনক্রিপশন (EFS), ইউজারভিত্তিক পারমিশন এবং বিদ্যুৎ চলে গেলে ক্র্যাশ রিকভারির জন্য জার্নালিং (Journaling) সাপোর্ট করে (উইন্ডোজ ও সার্ভার ওএসে ডিফল্ট)।

🇬🇧 English Exam Answer:
• Part 1: TCP vs UDP
| Feature | TCP (Transmission Control Protocol) | UDP (User Datagram Protocol) |
| :--- | :--- | :--- |
| **Connection Mode** | Connection-Oriented (3-way handshake) | Connectionless (No handshake) |
| **Reliability** | Guaranteed delivery (ACKs + Retransmission) | Best-effort / Unreliable (No retransmission) |
| **Header Size** | 20 – 60 Bytes | Fixed 8 Bytes |
| **Transmission Speed**| Slower due to congestion and flow control | Extremely fast, minimal latency |
| **Protocols** | HTTP/HTTPS, FTP, SMTP, SSH | DNS, DHCP, VoIP, Live Video Streaming |

• Part 2: CAT5 / CAT5e vs CAT6
| Parameter | CAT5 / CAT5e | CAT6 |
| :--- | :--- | :--- |
| **Max Data Rate** | Up to 1 Gbps (1000BASE-T) | Up to 10 Gbps (10GBASE-T up to 55m) |
| **Operating Frequency**| 100 MHz | 250 MHz |
| **Internal Construction**| Standard twisted pairs without separator | Internal longitudinal separator (spline) isolating pairs |
| **Crosstalk Immunity**| Moderate Near-End Crosstalk (NEXT) | Highly reduced crosstalk due to tighter twists & spline |

• Part 3: FAT32 vs NTFS
| Parameter | FAT32 | NTFS (New Technology File System) |
| :--- | :--- | :--- |
| **Max Single File Size**| Limited strictly to **4 GB** | Up to **16 TB** (theoretical 16 EB) |
| **Max Volume Size** | 2 TB (or 32 GB native Windows format) | Up to 256 TB |
| **Fault Recovery** | No journaling; prone to corruption on crash | Full **Journaling** file system with self-healing |
| **File Security & IAM** | No native file permissions or access control | Granular NTFS file/folder permissions (ACLs) |
| **Data Protection** | No native file compression or encryption | Supports Encrypting File System (EFS) and compression |"
                },

                // ── 48. Combined 4 Bank 2023: TDM, FDM, WDM ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Combined 4 Bank (BIBM)", Post = "SO IT", 
                    QuestionText = "Differentiate among TDM, FDM, and WDM. How does synchronous TDM work?",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
১. FDM, WDM ও TDM এর সহজ উপমা:
• **FDM (ফ্রিকোয়েন্সি ভাগ - রেডিও চ্যানেল)**:
  - একই বাতাসে রেডিও ফুর্তি (৮৮.০), রেডিও টুডে (৮৯.৬) ও বাংলাদেশ বেতার (১০০.০) একসাথে গান বাজাচ্ছে। বাতাস একটিই মাধ্যম, কিন্তু ফ্রিকোয়েন্সি আলাদা হওয়ায় কেউ কারো সাথে মেশে না।
• **WDM (আলোর রং বা তরঙ্গদৈর্ঘ্য ভাগ - ফাইবার অপটিক্স)**:
  - ফাইবার অপটিক কাঁচের তারের ভেতর দিয়ে লাল আলো, সবুজ আলো এবং নীল আলোর লেজার লাইট একসাথে পাঠানো। মাধ্যমের ভেতরে বিভিন্ন আলোর তরঙ্গদৈর্ঘ্য (Wavelength $\lambda$) আলাদা আলাদা ডাটা বহন করে।
• **TDM (সময় ভাগ করে নেওয়া - ডাক্তারের চেম্বার)**:
  - ডাক্তার একজন (কমিউনিকেশন চ্যানেল), কিন্তু ৪ জন রোগীকে পর্যায়ক্রমে ২ মিনিট করে ঘড়ি দেখে সময় দেওয়া। ডিজিটাল ডাটাকে সময়ের স্লটে (Time Slots) ভাগ করে পাঠানোই হলো TDM।

২. Synchronous TDM কীভাবে কাজ করে?
• **কাজের নিয়ম**: প্রতিটি ইনপুট চ্যানেলের জন্য একটি নির্দিষ্ট ও সমান সময়ের স্লট (Time Slot) বরাদ্দ থাকে। 
• ধরা যাক ৩টি কম্পিউটার A, B, C। রাউন্ড-রবিন নিয়মে স্লট সাজানো হবে: $[A_1, B_1, C_1] \rightarrow [A_2, B_2, C_2]$।
• **বড় অসুবিধা (Bandwidth Wastage)**: যদি কম্পিউটার B-এর কোনো ডাটা পাঠানোর না থাকে, তবুও তার জন্য নির্ধারিত স্লটটি খালি (Empty Slot) রেখেই ফ্রেম পাঠানো হবে। স্লট অন্য কাউকে দেওয়া যাবে না। (এই অপচয় দূর করতেই পরে Statistical TDM তৈরি হয়)।

🇬🇧 English Exam Answer:
• 1. Comparison of Multiplexing Techniques:
| Parameter | FDM (Frequency Division) | WDM (Wavelength Division) | TDM (Time Division) |
| :--- | :--- | :--- | :--- |
| **Signal Domain** | Analog Signals | Optical Signals (Light) | Digital Signals |
| **Multiplexing Basis** | Divides available bandwidth into non-overlapping frequency bands. | Divides optical spectrum into distinct optical wavelengths ($\lambda$). | Divides channel transmission time into discrete time slots. |
| **Transmission Medium**| Coaxial cables, Radio spectrum | Optical Fiber cables only | Twisted pair, Digital copper links |
| **Guard Requirements** | Requires Guard Bands between channels. | Requires Guard Bands in optical frequency spectrum. | Requires Synchronization bits/framing overhead. |
| **Standard Uses** | AM/FM Radio, Cable TV, FDM DSL | Dense WDM (DWDM) Submarine Cables | T1/E1 lines, PCM digital telephony, SONET |

• 2. Working Principle of Synchronous TDM:
```
Inputs:
Channel A: [A1] [A2] ──┐
Channel B: [B1] [  ] ──┼─> [ Multiplexer ] ───> Frame: [ A1 | B1 | C1 ] [ A2 |  _ | C2 ]
Channel C: [C1] [C2] ──┘
```
  1. **Fixed Slot Assignment**: The transmission multiplexer allocates a dedicated, fixed-duration time slot to every connected input source in round-robin order.
  2. **Frame Construction**: One cycle of time slots across all $N$ input channels forms a **TDM Frame**. A framing bit is added for synchronization.
  3. **Data Independence**: If a connected terminal has no data to transmit (idle state), its allotted time slot travels empty across the link, resulting in channel bandwidth underutilization."
                },

                // ── 49. Combined 4 Bank 2023: Network Topologies & IEEE 802 ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Combined 4 Bank (BIBM)", Post = "SO IT", 
                    QuestionText = "What is topology in data communication? Differences between bus, ring, tree, and star topology. How does IEEE 802 work?",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
১. নেটওয়ার্ক টপোলজি কী?
একটি নেটওয়ার্কের কম্পিউটার, কেবল এবং অন্যান্য ডিভাইসগুলো ভৌগোলিকভাবে এবং লজিক্যালি কীভাবে পরস্পরের সাথে সংযুক্ত থাকে তার নকশাকেই **Network Topology** বলে।

২. টপোলজিসমূহের তুলনামূলক বৈশিষ্ট্য:
• **Bus Topology**: একটি মাত্র লম্বা ব্যাকবোন তার থাকে। তারের যেকোনো এক জায়গায় কাটলে পুরো নেটওয়ার্ক ধ্বংস।
• **Star Topology (সবচেয়ে জনপ্রিয়)**: সেন্ট্রাল সুইচ বা হাব থাকে এবং সেখান থেকে প্রতি পিসিতে আলাদা তার যায়। একটি পিসির তার কাটলেও অন্য সবাই সচল থাকে।
• **Ring Topology**: বৃত্তাকার লুপ। টোকেন ঘুরতে থাকে। এক পিসির ত্রুটিতে পুরো রিং থেমে যেতে পারে।
• **Tree Topology**: হায়ারারকিক্যাল স্টার—কয়েকটি স্টার টপোলজি মিলে একটি বড় গাছের মতো কাঠামো তৈরি করে (বড় ব্যাংকের ভবনে বিভিন্ন ফ্লোরে ব্যবহৃত)।

৩. IEEE 802 কীভাবে কাজ করে?
IEEE 802 হলো লোকাল এরিয়া নেটওয়ার্কের (LAN) বিশ্বজনীন স্ট্যান্ডার্ড। এটি ওএসআই মডেলের Data Link Layer-কে ২টি স্বাধীন সাব-লেয়ারে ভাগ করে কাজ করে:
১. **LLC (Logical Link Control - 802.2)**: ওপরের নেটওয়ার্ক লেয়ারের সাথে যোগাযোগ, ফ্লো ও এরর কন্ট্রোল করে।
২. **MAC (Media Access Control)**: তারের ফিজিক্যাল অ্যাক্সেস ও হার্ডওয়্যার MAC এড্রেসিং নিয়ন্ত্রণ করে (যেমন: 802.3 হলো তারযুক্ত Ethernet এবং 802.11 হলো তারবিহীন Wi-Fi)।

🇬🇧 English Exam Answer:
• 1. Definition of Network Topology:
  Network topology is the structural arrangement (physical layout or logical signaling path) of computing nodes, connecting links, and networking devices within a communication network.

• 2. Comparison of Topologies:
| Topology | Cabling Architecture | Fault Tolerance | Installation Cost | Troubleshooting |
| :--- | :--- | :--- | :--- | :--- |
| **Bus** | Single shared coaxial/twisted backbone with terminators. | Very Low (Backbone break halts entire network). | Lowest | Difficult (Hard to isolate break point). |
| **Star** | All nodes connect individually to a central switch/hub. | High (Single cable failure impacts only that node). | Moderate | Very Easy (Isolated to switch port/cable). |
| **Ring** | Nodes connected in a closed unidirectional/bidirectional loop. | Low (Single node break halts token ring). | Low | Moderate |
| **Tree** | Hierarchical star clusters linked to a root backbone bus/switch. | High (Failure of a leaf hub isolates only that branch). | High | Structured and scalable. |

• 3. Architecture of IEEE 802 Standard:
  The IEEE 802 LAN/MAN standard splits the OSI Data Link Layer (Layer 2) into two distinct sub-layers:
  1. **LLC (Logical Link Control - IEEE 802.2)**:
     - Acts as an interface between upper Network Layer protocols (IPv4, IPv6) and the underlying physical media. Handles multiplexing, flow control, and error recovery.
  2. **MAC (Medium Access Control)**:
     - Manages physical device addressing (48-bit MAC) and arbitrates shared channel access protocols (e.g., CSMA/CD in IEEE 802.3 Ethernet, CSMA/CA in IEEE 802.11 Wi-Fi)."
                },

                // ── 50. Combined 4 Bank 2023: OSI vs TCP/IP Layers & PDUs ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Combined 4 Bank (BIBM)", Post = "SO IT", 
                    QuestionText = "Difference between OSI and TCP/IP model. Write about OSI layer Packet, Frame, Bit, Segment with protocol names.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
১. OSI বনাম TCP/IP মডেল:
• **OSI Model**: ৭টি লেয়ারের একটি তাত্ত্বিক বা রেফারেন্স মডেল। এটি কোনো বাস্তব সফটওয়্যার স্যুট নয়, নেটওয়ার্ক শেখার জন্য বইয়ের স্ট্যান্ডার্ড।
• **TCP/IP Model**: ৪টি বা ৫টি লেয়ারের একটি বাস্তব প্রয়োগিক মডেল, যার উপর ভিত্তি করে আজকের গোটা গ্লোবাল ইন্টারনেট চালু আছে।

২. PDU (Protocol Data Unit) মনে রাখার সহজ ট্রিক:
প্রতিটি লেয়ারে ডাটার নাম বদলে যায়:
• **Layer 4 (Transport Layer) $\rightarrow$ Segment**:
  - ডাটাকে ছোট ছোট টুকরো করে পোর্ট নাম্বার লাগানো হয়। প্রোটোকল: **TCP, UDP**।
• **Layer 3 (Network Layer) $\rightarrow$ Packet**:
  - সেগমেন্টের গায়ে প্রেরক ও প্রাপকের IP Address সিল মারা হয়। প্রোটোকল: **IPv4, IPv6, ICMP, OSPF, BGP**।
• **Layer 2 (Data Link Layer) $\rightarrow$ Frame**:
  - প্যাকেটের গায়ে ফিজিক্যাল MAC Address ও এরর চেক করার জন্য CRC টেইলর লাগানো হয়। প্রোটোকল: **Ethernet (IEEE 802.3), PPP, ARP**।
• **Layer 1 (Physical Layer) $\rightarrow$ Bits / Bitstream**:
  - ফ্রেমকে 0 এবং 1 এর ভোল্টেজ বা আলোর স্পন্দনে রূপান্তর করে তারে পাঠানো হয়। প্রোটোকল/স্ট্যান্ডার্ড: **1000BASE-T, RS-232, DSL**।

🇬🇧 English Exam Answer:
• 1. Difference between OSI and TCP/IP Model:
| Criteria | OSI Model | TCP/IP Model |
| :--- | :--- | :--- |
| **Number of Layers** | 7 Layers (Application, Presentation, Session, Transport, Network, Data Link, Physical). | 4 Layers (Application, Transport, Internet, Network Access). |
| **Nature** | Theoretical Reference Model (Protocol-independent). | Practical Implementation Suite (Protocol-oriented). |
| **Session / Presentation** | Explicitly separated into Layers 5 and 6. | Combined directly into the Application Layer. |
| **Transport Reliability** | Supports both connection-oriented & connectionless. | Explicitly separates TCP (connection) & UDP (connectionless). |

• 2. Protocol Data Units (PDUs) and Associated Protocols:
| PDU | OSI Layer | Encapsulation Role | Associated Protocols |
| :--- | :---: | :--- | :--- |
| **Segment** | **Transport (L4)** | End-to-end payload chunk tagged with Source & Destination Port addresses. | TCP, UDP |
| **Packet** | **Network (L3)** | Segment encapsulated with Source & Destination IP addresses and TTL. | IPv4, IPv6, ICMP, IGMP |
| **Frame** | **Data Link (L2)** | Packet encapsulated with Source/Destination MAC addresses and CRC checksum (FCS). | Ethernet (802.3), Wi-Fi (802.11), PPP, ARP |
| **Bit / Bitstream**| **Physical (L1)** | Unstructured serialized binary electrical, optical, or radio pulses on the wire. | Manchester, 100BASE-TX, NRZ |"
                },

                // ── 51. RAKUB 2023: Packet vs Circuit Switching ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "RAKUB (BIBM)", Post = "ANSE", 
                    QuestionText = "What is Packet Switching, Circuit Switching? Differentiate between them. Which is better? Give real-life examples.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
সহজ উপমা:
• **Circuit Switching (রেললাইন ব্লক করে ট্রেন চালানো)**:
  - ট্রেন চলার আগে পুরো লাইন লক করে ডেডিকেটেড পাথ বানিয়ে দেওয়া হয়। যতক্ষণ না ট্রেন গন্তব্যে পৌঁছায়, অন্য কোনো ট্রেন সেই লাইনে ঢুকতে পারবে না। যদি ট্রেনে মাত্র ১ জন যাত্রীও থাকে, তবুও পুরো লাইন অপচয় হবে।
  - বাস্তব উদাহরণ: পুরনো ল্যান্ডফোন (PSTN)। আপনি ফোন তুলে হ্যালো বলার আগেই একটি ফিজিক্যাল সার্কিট কানেক্ট হয়, কথা না বলে চুপ থাকলেও লাইনটি অন্য কেউ ব্যবহার করতে পারে না।
• **Packet Switching (পাবলিক হাইওয়েতে কুরিয়ার পার্সেল)**:
  - কোনো রাস্তা একা কারো জন্য বুক থাকে না। মূল ডাটাকে ছোট ছোট প্যাকেটে ভাগ করে বিভিন্ন গাড়িতে তুলে দেওয়া হয়। রাস্তায় জ্যাম থাকলে প্যাকেটগুলো ভিন্ন ভিন্ন শর্টকাট গলি দিয়ে গিয়ে রিসিভারের কাছে পুনরায় ক্রমানুসারে সাজিয়ে নেওয়া হয়।
  - বাস্তব উদাহরণ: ইন্টারনেট, ইমেইল, ওয়েব ব্রাউজিং।
• **কোনটি শ্রেষ্ঠ?** আধুনিক ডাটা নেটওয়ার্কের জন্য **Packet Switching** বহুগুণ শ্রেষ্ঠ—কারণ এতে ব্যান্ডউইডথের কোনো অপচয় হয় না এবং হাজার হাজার মানুষ একযোগে লাইন শেয়ার করতে পারে।

🇬🇧 English Exam Answer:
• 1. Definitions:
  - **Circuit Switching**: A communication method that establishes a dedicated, continuous physical transmission path between sender and receiver for the entire duration of the session before data transfer begins.
  - **Packet Switching**: A method where data is segmented into independently addressed packets that traverse shared physical paths dynamically, routed via store-and-forward mechanisms.

• 2. Comparison Table:
| Parameter | Circuit Switching | Packet Switching |
| :--- | :--- | :--- |
| **Path Reservation** | Dedicated physical path reserved in advance. | Dynamic, shared path; no advance reservation. |
| **Call Setup Delay** | High initial connection setup delay. | Zero setup delay (immediate transmission). |
| **Bandwidth Utilization**| Inefficient; idle time wastes channel capacity. | Highly efficient via statistical multiplexing. |
| **Route Congestion** | Call blocked if capacity full (busy tone). | Packets experience queuing delay or packet drop. |
| **Charging Model** | Charged based on connection time/distance. | Charged based on data volume consumed. |
| **Real-Life Examples** | Traditional PSTN Landline, GSM Voice Calls. | The Internet (IP), Email, Streaming, VoIP. |

• 3. Which is Better?
  **Packet Switching is vastly superior** for computer data communication due to high bandwidth efficiency, fault tolerance (dynamic rerouting around failed links), and scalable concurrent utilization."
                },

                // ── 52. RAKUB 2023: CRC vs Parity Bit ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "RAKUB (BIBM)", Post = "ANSE", 
                    QuestionText = "What is CRC, Parity bit? Which is better for error detection?",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
সহজ উপমা:
• **Parity Bit (১ টাকার খুচরা কয়েন গোনা)**:
  - শুধু দেখে মোট কয়েন জোড় না বিজোড় (Even বা Odd)। যদি পথে অসাবধানে ১টি কয়েন হারিয়ে যায়, তবে সে ধরে ফেলবে। কিন্তু যদি একসাথে ২টি কয়েন চুরি হয়ে যায়, তবে সে আর ধরতে পারবে না (অন্ধ হয়ে যায়)!
• **CRC (ব্যাংকের চেক ও টাকার ইউনিক ডিজিটাল সিলমোহর)**:
  - এটি উচ্চমানের বাইনারি ভাগশেষ অ্যালগরিদম (Modulo-2 polynomial division)। ডাটার যেকোনো জায়গায় ১টি বিট, ২টি বিট কিংবা বড় বড় ঝাঁকে ঝাঁকে বিট নষ্ট হলেও (Burst Error) এটি ৯৯.৯৯৯% নির্ভুলভাবে ধরে ফেলে।
• **কোনটি শ্রেষ্ঠ?** ত্রুটি শনাক্তকরণে **CRC (Cyclic Redundancy Check)** নিঃসন্দেহে লক্ষ গুণ শ্রেষ্ঠ এবং আধুনিক ইথারনেট ও ওয়াই-ফাইয়ের ডিফল্ট স্ট্যান্ডার্ড।

🇬🇧 English Exam Answer:
• 1. Definitions:
  - **Parity Bit**: A simple error-detection scheme that appends a single redundant bit to a binary block to ensure the total count of 1-bits is either even (Even Parity) or odd (Odd Parity).
  - **CRC (Cyclic Redundancy Check)**: A powerful polynomial-based checksum technique where a data bitstream is divided by a predetermined generator polynomial using modulo-2 arithmetic, appending the resulting remainder (FCS) to the payload.

• 2. Direct Comparison:
| Evaluation Criteria | Parity Check | CRC (Cyclic Redundancy Check) |
| :--- | :--- | :--- |
| **Computational Complexity** | Extremely simple (XOR chain). | Moderate (Hardware shift registers/XOR). |
| **Redundancy Overhead** | Single bit per byte/frame. | 16-bit to 32-bit Frame Check Sequence (FCS). |
| **Single-Bit Error Detection** | 100% Guaranteed. | 100% Guaranteed. |
| **Double-Bit / Even Errors** | **Fails completely (0% detection)**. | Guaranteed detection. |
| **Burst Error Detection** | Fails on even burst lengths. | Detects burst errors up to generator degree with 100% probability. |
| **Standards Implementation** | Asynchronous Serial UART. | Ethernet (CRC-32), Wi-Fi, HDLC, SATA, ZIP. |

• 3. Conclusion:
  **CRC is exponentially superior** for data communication networks because real-world transmission noise produces multi-bit burst errors that completely bypass parity checks."
                },

                // ── 53. RAKUB 2023: Optical Fiber vs Satellite & Submarine Cables ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "RAKUB (BIBM)", Post = "ANSE", 
                    QuestionText = "What is Optical cable, Satellite transmission? Differentiate between them. Bangladesh submarine cable name?",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
১. Optical Fiber vs Satellite এর সহজ উপমা:
• **Optical Fiber (মাটির তলার এক্সপ্রেস হাইওয়ে)**:
  - কাঁচের সরু পাইপের ভেতর আলোর প্রতিফলনে ডাটা চলে। গতি প্রায় আলোর সমান, ব্যান্ডউইডথ প্রায় অসীম এবং লেটেন্সি অত্যন্ত কম (<10 মিলি-সেকেন্ড)।
• **Satellite Transmission (মহাকাশের রিমোট রেডিও টাওয়ার)**:
  - পৃথিবী থেকে ৩৬,০০০ কিমি ওপরে মহাকাশের স্যাটেলাইটে সিগন্যাল পাঠিয়ে আবার পৃথিবীতে ফিরিয়ে আনা। দূরত্ব এত বেশি হওয়ায় সিগন্যাল যেতে-আসতে আধা সেকেন্ড সময় লেগে যায় (High Latency ~500 ms)। তবে পাহাড়ি বা দুর্গম চরাঞ্চলে যেখানে তার টানা অসম্ভব, সেখানে স্যাটেলাইটই একমাত্র ভরসা।

২. বাংলাদেশের সাবমেরিন ক্যাবলসমূহ:
বাংলাদেশ আন্তর্জাতিক ইন্টারনেটে যুক্ত হতে ৩টি কনসোর্টিয়াম সাবমেরিন ক্যাবলের সদস্য:
১. **SEA-ME-WE 4** (১ম সাবমেরিন ক্যাবল): ল্যান্ডিং স্টেশন—ঝিলংজা, কক্সবাজার (২০০৬ সালে চালু)।
২. **SEA-ME-WE 5** (২য় সাবমেরিন ক্যাবল): ল্যান্ডিং স্টেশন—কুয়াকাটা, পটুয়াখালী (২০১৭ সালে চালু)।
৩. **SEA-ME-WE 6** (৩য় সাবমেরিন ক্যাবল): ল্যান্ডিং স্টেশন—কক্সবাজার (আসন্ন ২০২৫-২৬)।

🇬🇧 English Exam Answer:
• 1. Definitions & Comparison:
| Parameter | Optical Fiber Cable | Satellite Transmission |
| :--- | :--- | :--- |
| **Medium Type** | Guided physical glass/silica core. | Unguided wireless microwave spectrum. |
| **Propagation Latency**| Extremely Low (< 5 – 10 ms across cities). | High Latency (~500 – 600 ms round-trip for GEO). |
| **Bandwidth Capacity** | Massive (Terabits per second per fiber pair). | Moderate (Gigabits per transponder). |
| **Environmental Impact**| Immune to weather, rain fade, and EMI. | Highly vulnerable to atmospheric rain fade and solar storms. |
| **Installation Cost** | High initial civil trenching and laying cost. | Immense spacecraft launch and maintenance cost. |
| **Geographic Reach** | Point-to-point along physical cable routes. | Vast global broadcast footprint across oceans/remote areas. |

• 2. Bangladesh Submarine Cables:
  1. **SEA-ME-WE 4** (South East Asia–Middle East–Western Europe 4):
     - Landing Station: Cox's Bazar (Operational since 2006).
  2. **SEA-ME-WE 5**:
     - Landing Station: Kuakata, Patuakhali (Operational since 2017).
  3. **SEA-ME-WE 6**:
     - Landing Station: Cox's Bazar (Under deployment/commissioning)."
                },

                // ── 54. RAKUB 2023: Router vs Bridge ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "RAKUB (BIBM)", Post = "ANSE", 
                    QuestionText = "Write difference between Router and Bridge.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
সহজ উপমা:
• **Bridge (একই পাড়ার দুটি গলির গেট)**:
  - পাড়ার ভেতরে বাম গলি ও ডান গলির মাঝে একটি গেট। সে বাড়ির হোল্ডিং নম্বর (MAC Address) চেনে। কিন্তু পাড়ার ভেতর কেউ মাইক বাজালে (Broadcast) সেই গেট আওয়াজ থামাতে পারে না। (OSI Layer 2)।
• **Router (আন্তর্জাতিক কাস্টমস ও হাইওয়ে কন্ট্রোল পোস্ট)**:
  - এটি এক শহরের সাথে অন্য শহর বা এক দেশের সাথে অন্য দেশকে যুক্ত করে। সে পাসপোর্ট ও জাতীয় পরিচয়পত্রের নম্বর (IP Address) চেনে। কোনো পাড়ার মাইকের আওয়াজ (Broadcast) এই চেকপোস্ট পার হয়ে অন্য শহরে যেতে পারে না—অর্থাৎ ব্রডকাস্ট ঝড় আটকে দেয়। (OSI Layer 3)।

🇬🇧 English Exam Answer:
• Comparison between Router and Bridge:
| Feature | Bridge | Router |
| :--- | :--- | :--- |
| **OSI Layer** | Data Link Layer (Layer 2) | Network Layer (Layer 3) |
| **Addressing Used** | Hardware Physical MAC Address | Logical IP Address (IPv4 / IPv6) |
| **Broadcast Domains** | **Cannot separate broadcast domains** (passes all broadcasts). | **Separates broadcast domains** (blocks Layer 2 broadcasts). |
| **Collision Domains** | Divides network into 2 collision domains. | Divides network into separate collision domains per interface. |
| **Routing Intelligence**| Reads MAC frame headers; no routing protocols. | Runs dynamic routing protocols (OSPF, BGP, RIP) to select optimal paths. |
| **Network Types** | Connects identical LAN segments (e.g., Ethernet to Ethernet). | Connects disparate network architectures (e.g., LAN to WAN). |"
                },

                // ── 55. RAKUB 2023: Synchronous vs Asynchronous Transmission ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "RAKUB (BIBM)", Post = "ANSE", 
                    QuestionText = "Write difference between Synchronous and Asynchronous transmission.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
সহজ উপমা:
• **Asynchronous (কীবোর্ডে টাইপ করা)**:
  - আপনি কীবোর্ডে টাইপ করার সময় 'A' চাপলেন, তারপর ৫ সেকেন্ড চা খেলেন, তারপর 'B' চাপলেন। প্রেরক ও প্রাপকের ঘড়ির কাঁটা মেলানোর দরকার নেই। প্রতি অক্ষরের শুরুতে ১টি **Start Bit (0)** এবং শেষে ১ বা ২টি **Stop Bit (1)** দিয়ে রিসিভারকে বোঝানো হয় ক্যারেক্টার শুরু ও শেষ হয়েছে।
• **Synchronous (ট্রেনের একটার পর একটা বগি চলা)**:
  - এখানে কোনো স্টার্ট বা স্টপ বিট দিয়ে সময় নষ্ট করা হয় না। হাজার হাজার বাইটের ডাটা ব্লক (Frame) একটানা ছুটে চলে। প্রেরক ও প্রাপক উভয়েই একটি কমন সেন্ট্রাল মাস্টার ক্লকের (Clock Pulse) তালে তালে синхronized হয়ে ডাটা গ্রহণ করে।

🇬🇧 English Exam Answer:
• Comparison between Synchronous and Asynchronous Transmission:
| Parameter | Asynchronous Transmission | Synchronous Transmission |
| :--- | :--- | :--- |
| **Data Unit** | Character-by-character (1 byte at a time). | Continuous large blocks / frames of data. |
| **Framing Bits** | Requires **Start bit** (0) and **Stop bit(s)** (1) per byte. | Uses framing header/trailer flags (e.g., `01111110`). |
| **Clock Synchronization**| No common clock synchronization between endpoints. | Sender and receiver share synchronized system clock pulses. |
| **Inter-character Gap**| Unequal, variable idle gaps permitted. | Constant, synchronized time intervals (No gaps). |
| **Transmission Speed** | Slower due to 20–30% framing overhead. | High-speed, high efficiency with minimal overhead. |
| **Examples** | Keyboard, Mouse, Serial RS-232, Legacy modems. | High-speed Ethernet, Optical carrier, T1/E1, WAN links. |"
                },

                // ── 56. RAKUB 2023: NAT (Network Address Translation) ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "RAKUB (BIBM)", Post = "ANSE", 
                    QuestionText = "What is NAT? How does it work?",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
সহজ উপমা:
একটি ব্যাংকের হেড অফিসের প্রধান ল্যান্ডফোন নম্বর এবং ভেতরের এক্সটেনশন নম্বরের কথা ভাবুন।
বাইরের পৃথিবী কেবল ব্যাংকের ১টি পাবলিক নম্বর জানে (`০২-৯৮৮৮৮৮৮`)। কিন্তু ভেতরে ২০০ জন কর্মকর্তার আলাদা আলাদা ডেস্কে এক্সটেনশন নম্বর (`১০১`, `১০২`) থাকে। কেউ বাইরে কল করলে বা বাইরে থেকে কল আসলে রিসেপশন বোর্ড (NAT) এক্সটেনশন মিলিয়ে সঠিক ডেস্কে লাইন ধরিয়ে দেয়।

১. NAT কী?
NAT (Network Address Translation) হলো রাউটারের এমন একটি প্রযুক্তি যা লোকাল ল্যানের একাধিক আন-রাউটেবল প্রাইভেট আইপিকে (`192.168.x.x`) মাত্র ১টি গ্লোবালি রাউটেবল পাবলিক আইপিতে রূপান্তর করে ইন্টারনেটে পাঠায়।

২. NAT কীভাবে কাজ করে (PAT / NAT Overload)?
১. যখন ল্যানের পিসি (`192.168.1.10`) গুগলে রিকোয়েস্ট পাঠায়, প্যাকেটটি ওয়াইফাই রাউটারে যায়।
২. রাউটার প্যাকেটের প্রাইভেট আইপি মুছে দিয়ে নিজের পাবলিক আইপি এবং একটি ইউনিক সোর্স পোর্ট নম্বর (`Port 50001`) বসিয়ে দেয়।
৩. রাউটার তার মেমরিতে একটি **NAT Translation Table** সেভ করে: `192.168.1.10:8080 <-> Public_IP:50001`।
৪. গুগল যখন রেসপন্স পাঠায়, রাউটার পোর্ট `50001` দেখে নিশ্চিত চিনে ফেলে এটি পিসি ১০ এর ডাটা এবং তার কাছে পৌঁছে দেয়।

🇬🇧 English Exam Answer:
• 1. Definition of NAT:
  Network Address Translation (NAT, RFC 3022) is an Internet engineering standard configured on border routers that remaps an entire private IP address space (RFC 1918) into one or more valid public IP addresses before routing packets to the public Internet.

• 2. Types of NAT:
  1. **Static NAT**: One-to-one permanent mapping of a private IP to a public IP (used for hosting internal web/mail servers).
  2. **Dynamic NAT**: Many-to-many mapping from a pool of available public IP addresses.
  3. **PAT (Port Address Translation / NAT Overload)**: Many-to-one mapping where thousands of internal hosts share a single public IP distinguished by unique Layer 4 source port numbers.

• 3. Working Mechanism of PAT:
```
[Private Host]                 [NAT Border Router]                  [Public Web Server]
192.168.1.5:4500 ──(Packet)──> [Translates Source to: ] ──(Packet)──> 142.250.190.46:80
                               [203.0.113.10:61001   ]
                               [Logs in NAT Table    ]
192.168.1.5:4500 <──(Packet)── [Reverses translation ] <──(Response) 142.250.190.46:80
```
  - Step 1: Internal host initiates outbound packet with private source IP and port.
  - Step 2: Router intercepts packet, replaces source IP with router's public IP, assigns a unique ephemeral port, and records mapping in the NAT translation state table.
  - Step 3: Destination server responds back to the router's public IP and translated port.
  - Step 4: Router inspects its NAT table, restores internal private IP/port, and delivers packet."
                },

                // ── 57. RAKUB 2023: Application Protocols (SMTP, SNMP, HTTP, HTTPS) ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "RAKUB (BIBM)", Post = "ANSE", 
                    QuestionText = "What is SMTP, SNMP, HTTP, and HTTPS?",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
১. **SMTP (Simple Mail Transfer Protocol - Port 25, 587)**:
   - উপমা: পোস্ট অফিসের হলুদ ডাকবাক্স। আপনি যখন চিঠি ডাকবাক্সে ফেলে আসেন বা এক পোস্ট অফিস অন্য পোস্ট অফিসে চিঠি ফরোয়ার্ড করে—এই প্রেরণের কাজ করে SMTP (Push Protocol)। ইমেইল ইনবক্স থেকে পড়তে POP3 বা IMAP লাগে।
২. **SNMP (Simple Network Management Protocol - Port 161)**:
   - উপমা: আইসিইউর মেডিকেল মনিটর। নেটওয়ার্ক ইঞ্জিনিয়ার এক জায়গায় বসে অফিসের সব রাউটার, সুইচ ও সার্ভারের তাপমাত্রা, সিপিইউ ব্যবহার, পোর্ট আপ/ডাউন ও ব্যান্ডউইডথ জ্যাম স্বয়ংক্রিয়ভাবে মনিটর করতে SNMP ব্যবহার করেন।
৩. **HTTP (Hypertext Transfer Protocol - Port 80)**:
   - উপমা: সাধারণ পোস্টকার্ডে লেখা চিঠি। ইন্টারনেটে ওয়েবসাইট ব্রাউজ করার মূল ভিত্তি। কিন্তু ডাটা প্লেইনটেক্সট হিসেবে যায়—মাঝের হ্যাকাররা পাসওয়ার্ড দেখে ফেলতে পারে।
৪. **HTTPS (HTTP Secure - Port 443)**:
   - উপমা: সিলগালা করা লোহার বাক্সে চিঠি। HTTP এর সাথে SSL/TLS ক্রিপ্টোগ্রাফি যুক্ত থাকে। সমস্ত তথ্য ব্যাংকিং গ্রেড এনক্রিপশনে যাতায়াত করে, হ্যাকাররা ডাটা চুরি করতে পারে না।

🇬🇧 English Exam Answer:
• Summary Table of Key Application Protocols:
| Protocol | Full Name | Default Port & Transport | Security Layer | Primary Purpose |
| :--- | :--- | :---: | :---: | :--- |
| **SMTP** | Simple Mail Transfer Protocol | Port 25 / 587 (TCP) | Optional (STARTTLS) | Used for pushing/transmitting outbound emails between mail clients and Mail Transfer Agents (MTAs). |
| **SNMP** | Simple Network Management Protocol | Port 161 / 162 (UDP) | SNMPv3 (Auth/Priv) | Network monitoring framework for querying hardware health metrics (CPU, RAM, bandwidth) on routers/switches. |
| **HTTP** | Hypertext Transfer Protocol | Port 80 (TCP) | None (Plaintext) | Stateless client-server protocol for fetching HTML web resources; unencrypted. |
| **HTTPS** | Hypertext Transfer Protocol Secure | Port 443 (TCP) | **SSL / TLS** | Encrypted web communication securing sensitive user credentials and transactions via asymmetric/symmetric cryptography. |"
                },

                // ── 58. RAKUB 2023: VLAN (Virtual LAN) & Types ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "RAKUB (BIBM)", Post = "ANSE", 
                    QuestionText = "What is VLAN, Types of VLAN (static and dynamic)? Draw VLAN. Write Difference between IPv4 and IPv6.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
১. VLAN (Virtual LAN) কী?
সহজ উপমা:
একটি ফিজিক্যাল সুইচে ২৪টি পোর্ট আছে। স্বাভাবিকভাবে সব পোর্ট একই ল্যানের অংশ। কিন্তু সফটওয়্যার কনফিগারেশনের মাধ্যমে সুইচের ভেতর লজিক্যাল কাঁচের দেয়াল তুলে দেওয়া—যাতে ১-৮ পোর্ট হবে HR, ৯-১৬ পোর্ট হবে Accounts। একই সুইচে তার লাগানো সত্ত্বেও HR ও Accounts কেউ কারো ব্রডকাস্ট ফ্রেম দেখতে পাবে না।

২. VLAN এর প্রকারভেদ:
• **Static VLAN (Port-based)**: নেটওয়ার্ক অ্যাডমিন ম্যানুয়ালি সুইচের ১ নম্বর পোর্টকে VLAN 10 এ এসাইন করেন। ওই পোর্টে যে পিসিই লাগানো হোক সে VLAN 10 পাবে (সবচেয়ে নিরাপদ ও বহুল ব্যবহৃত)।
• **Dynamic VLAN (MAC-based)**: পিসির ফিজিক্যাল MAC এড্রেস অনুযায়ী VMPS (VLAN Management Policy Server) সার্ভার স্বয়ংক্রিয়ভাবে পিসিটির VLAN নির্ধারণ করে।

৩. IPv4 বনাম IPv6 এর সহজ পার্থক্য:
• IPv4: ৩২-বিট লম্বা, দশমিকে লেখা হয় (`192.168.1.1`), মোট আইপি সংখ্যা ৪৩০ কোটি (যা ইতিমধ্যে শেষ হয়ে গেছে)।
• IPv6: ১২৮-বিট লম্বা, হেক্সাডেসিমেলে লেখা হয় (`2001:0db8::1`), আইপি সংখ্যা $3.4 \times 10^{38}$ টি (পৃথিবীর প্রতি ধূলিকণার জন্যও কোটি কোটি আইপি বরাদ্দ সম্ভব)।

🇬🇧 English Exam Answer:
• 1. Definition of VLAN:
  A Virtual Local Area Network (VLAN, IEEE 802.1Q) is a logical grouping of network devices and switch ports that behave as a distinct broadcast domain regardless of physical switch topology.

• 2. Static vs Dynamic VLAN:
  - **Static VLAN**: Switch ports are manually and statically assigned to specific VLAN IDs by the network administrator (Port-centric).
  - **Dynamic VLAN**: Port membership is automatically assigned based on endpoint MAC address, 802.1X user credentials, or IP subnet via a centralized VMPS/RADIUS server.

• 3. Difference between IPv4 and IPv6:
| Feature | IPv4 | IPv6 |
| :--- | :--- | :--- |
| **Address Length** | 32 Bits (4 Bytes) | 128 Bits (16 Bytes) |
| **Total Address Space**| $2^{32} \approx 4.29 \times 10^9$ addresses | $2^{128} \approx 3.4 \times 10^{38}$ addresses |
| **Notation Format** | Dotted Decimal (e.g., `192.168.1.1`) | Hexadecimal with colons (e.g., `2001:db8::1`) |
| **Header Size** | Variable (20 to 60 Bytes) | Fixed 40 Bytes (faster hardware parsing) |
| **Security Support** | IPsec is an optional add-on | IPsec built-in native design requirement |
| **Configuration** | Manual or DHCP | Stateless Address Autoconfiguration (SLAAC) or DHCPv6 |"
                },

                // ── 61. Rupali Bank 2023: Public vs Private IP & L2 vs L3 Switch ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Rupali Bank (BIBM)", Post = "ANA", 
                    QuestionText = "Distinguish between public and private IP address. Differentiate between Layer 2 switch and Layer 3 switch.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
১. Public IP vs Private IP:
সহজ উপমা:
• **Public IP (আন্তর্জাতিক পাসপোর্ট নম্বর)**: সারা বিশ্বে এটি সম্পূর্ণ ইউনিক। সরাসরি ইন্টারনেটে রাউটেবল। ICANN ও ISP-র কাছ থেকে টাকা দিয়ে কিনতে হয়।
• **Private IP (অফিসের অভ্যন্তরীণ আইডি কার্ড)**: অফিসের ভেতরে এটি ইউনিক, কিন্তু বাইরে অচল। ইন্টারনেটে সরাসরি রাউট হয় না। RFC 1918 অনুযায়ী বিনামূল্যে যে কেউ ল্যানে ব্যবহার করতে পারে (`10.x.x.x`, `172.16.x.x`, `192.168.x.x`)।

২. Layer 2 Switch vs Layer 3 Switch:
• **Layer 2 Switch (সাধারণ সুইচ)**: শুধুমাত্র হার্ডওয়্যার MAC Address দেখে একই VLAN বা সাবনেটের মধ্যে ফ্রেম পাস করে। এক সাবনেট থেকে অন্য সাবনেটে ডাটা পাঠাতে পারে না।
• **Layer 3 Switch (সুইচের গতির সাথে রাউটারের বুদ্ধি)**: এটি MAC সুইচিংয়ের পাশাপাশি IP Address পড়ে বিভিন্ন VLAN-এর মধ্যে ইন্টার-VLAN রাউটিং করতে পারে। সাধারণ রাউটারের চেয়ে অনেক দ্রুত হার্ডওয়্যার চিপ (ASIC) দিয়ে তারের গতিতে (Wire-speed) প্যাকেট রাউট করে।

🇬🇧 English Exam Answer:
• Part 1: Public vs Private IP Address
| Feature | Public IP Address | Private IP Address (RFC 1918) |
| :--- | :--- | :--- |
| **Global Uniqueness** | Globally unique across the worldwide Internet. | Unique only within local enterprise LAN. |
| **Internet Routability**| Direct routable across global Internet core routers. | Non-routable on the Internet; dropped by ISPs. |
| **Acquisition & Cost** | Allocated by IANA/RIRs via ISPs for a recurring fee. | Freely usable by anyone without registration. |
| **Standard Ranges** | All valid public IPv4 addresses outside RFC 1918. | Class A: `10.0.0.0/8`, Class B: `172.16.0.0/12`, Class C: `192.168.0.0/16`. |

• Part 2: Layer 2 Switch vs Layer 3 Switch
| Parameter | Layer 2 Switch | Layer 3 Switch |
| :--- | :--- | :--- |
| **Operating Layer** | Data Link Layer (Layer 2) | Data Link + Network Layer (Layer 2 & Layer 3) |
| **Forwarding Table**| MAC Address Table (CAM Table) | CAM Table (MAC) + FIB / Routing Table (IP) |
| **Inter-VLAN Routing**| Cannot route between VLANs (requires external router).| Performs wire-speed Inter-VLAN routing natively using ASICs. |
| **Routing Protocols**| None | Runs OSPF, EIGRP, RIP, and Static Routing |
| **Deployment Role** | Access layer LAN distribution to end-user PCs. | Core and Distribution layers of enterprise campus networks. |"
                },

                // ── 62. Rupali Bank 2023: Collision Domain vs Broadcast Domain ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Rupali Bank (BIBM)", Post = "ANA", 
                    QuestionText = "Distinguish between domain and broadcast domain in a network.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
সহজ উপমা:
• **Collision Domain (রাস্তায় মুখোমুখি গাড়ি সংঘর্ষের এলাকা)**:
  - এমন একটি রাস্তা যেখানে দুটি গাড়ি একসাথে ঢুকলে ধাক্কা লাগার ঝুঁকি থাকে। হাব (Hub) এর ক্ষেত্রে সব পোর্ট মিলে ১টি রাস্তা, তাই যে কেউ একসাথে ডাটা পাঠালে ধাক্কা (Collision) লাগে। কিন্তু আধুনিক সুইচের প্রতিটি পোর্ট সম্পূর্ণ আলাদা রাস্তা (Dedicated Collision Domain)।
• **Broadcast Domain (মসজিদের মাইকের আজান শোনার এলাকা)**:
  - মাইকে কোনো ঘোষণা দিলে যতদূর পর্যন্ত মানুষ শুনতে পায়, সেটাই তার ব্রডকাস্ট এলাকা। সুইচে কোনো পিসি ব্রডকাস্ট ফ্রেম (`FF:FF:FF:FF:FF:FF`) পাঠালে সুইচের সব পোর্টের কম্পিউটার তা শুনতে পায় (১টি ব্রডকাস্ট ডোমেইন)। একমাত্র **Router** অথবা **VLAN** এই এলাকাকে মাঝখান দিয়ে কেটে আলাদা করে দিতে পারে।

🇬🇧 English Exam Answer:
• Comparison between Collision Domain and Broadcast Domain:
| Evaluation Criteria | Collision Domain | Broadcast Domain |
| :--- | :--- | :--- |
| **Definition** | Network segment where simultaneous packet transmissions cause frame collisions. | Logical network segment where a broadcast frame is received by every connected host. |
| **OSI Layer** | Physical Layer (Layer 1) | Data Link / Network Layer (Layer 2 & Layer 3) |
| **Impact of Hub** | All hub ports form **one single collision domain**. | Passes broadcasts; forms one broadcast domain. |
| **Impact of Switch** | **Divides collision domains** (each switch port is an isolated collision domain). | Switch with default configuration forms **one single broadcast domain**. |
| **Boundary Device** | Switches, Bridges, and Routers break collision domains. | **Routers and VLANs break broadcast domains**. |
| **Mitigation Impact** | Full-duplex Ethernet eliminates collisions completely. | Subnetting and VLANs isolate broadcasts to eliminate broadcast storms. |"
                },

                // ── 63. Combined 5 Bank 2023: Subnetting 172.10.0.0/19 & OSPF ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Combined 5 Bank (BIBM)", Post = "Officer IT", 
                    QuestionText = "Network 172.10.0.0/19: (i) How many subnets are there? (ii) How many hosts per subnet? (iii) What is the function of OSPF?",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা ও গাণিতিক সমাধান:
দেওয়া আছে: `172.10.0.0/19`
১. আইপিটি কোন ক্লাসের?
• প্রথম অক্টেট ১৭২ হওয়ায় এটি **Class B** নেটওয়ার্ক (ডিফল্ট প্রিফিক্স `/16`)।

২. (i) সাবনেট সংখ্যা নির্ণয়:
• ধার করা সাবনেট বিট ($s$) = নতুন প্রিফিক্স – ডিফল্ট প্রিফিক্স = $19 - 16 = \mathbf{3}$ টি।
• সাবনেট সংখ্যা = $2^s = 2^3 = \mathbf{8}$ টি সাবনেট।

৩. (ii) প্রতি সাবনেটে হোস্ট সংখ্যা নির্ণয়:
• মোট আইপি বিট = ৩২।
• হোস্ট বিট সংখ্যা ($h$) = $32 - 19 = \mathbf{13}$ টি।
• প্রতি সাবনেটে মোট আইপি = $2^{13} = \mathbf{8192}$ টি।
• প্রতি সাবনেটে ব্যবহারযোগ্য হোস্ট আইপি = $2^{13} - 2 = \mathbf{8190}$ টি (নেটওয়ার্ক ও ব্রডকাস্ট আইপি বাদে)।

৪. (iii) OSPF এর কাজ কী?
• OSPF (Open Shortest Path First) একটি ডায়নামিক লিংক-স্টেট ইন্টেরিয়র রাউটিং প্রোটোকল।
• এটি Dijkstra's SPF অ্যালগরিদম ব্যবহার করে রাউটারগুলোর মধ্যে সবচেয়ে কম দূরত্বের ও দ্রুততম পাথ গণনা করে এবং রাউটিং টেবিল স্বয়ংক্রিয়ভাবে আপডেট রাখে।

🇬🇧 English Exam Answer:
• 1. Subnetting Analysis for `172.10.0.0/19`:
  - Default Class B mask = `/16` (`255.255.0.0`).
  - Allocated CIDR prefix = `/19` (`255.255.224.0`).
  - Borrowed Subnet Bits ($s$) = $19 - 16 = 3$ bits.
  - Remaining Host Bits ($h$) = $32 - 19 = 13$ bits.

  - **(i) Number of Subnets**:
    $$\text{Subnets} = 2^s = 2^3 = \mathbf{8}\text{ subnets}$$
  - **(ii) Number of Hosts per Subnet**:
    $$\text{Total Addresses per Subnet} = 2^h = 2^{13} = \mathbf{8192}\text{ addresses}$$
    $$\text{Usable Hosts per Subnet} = 2^{13} - 2 = \mathbf{8190}\text{ valid host addresses}$$

• 2. (iii) Primary Functions of OSPF (Open Shortest Path First):
  1. **Dynamic Link-State Topology Mapping**: Floods Link-State Advertisements (LSAs) to build an identical, synchronized Link-State Database (LSDB) across all area routers.
  2. **Shortest Path Computation (Dijkstra's SPF)**: Computes the loop-free lowest-cost metric path based on link bandwidth.
  3. **Fast Network Convergence & Hierarchy**: Rapidly updates routing tables upon topology changes without routing loops, utilizing a 2-tier hierarchical area design (Backbone Area 0)."
                },

                // ── 64. Sonali Bank 2023: IP Decimal to Binary & Class Table ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Sonali Bank (BIBM)", Post = "Assistant Programmer", 
                    QuestionText = "Convert decimal IP 192.18.101.5 to binary form. Write tabular representation of classful IP addressing with leading bits, network ID bits, host ID bits, number of networks, and addresses per network.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা ও সমাধান:
১. দশমিক থেকে বাইনারি রূপান্তর (192.18.101.5):
• 192 = $128 + 64$ = `11000000`
• 18  = $16 + 2$    = `00010010`
• 101 = $64 + 32 + 4 + 1$ = `01100101`
• 5   = $4 + 1$     = `00000101`
• সম্পূর্ণ বাইনারি IP = **11000000.00010010.01100101.00000101**

২. Classful IP এড্রেসিং ছক:
| Class | Leading Bits | IP Range | Net Bits | Host Bits | Number of Networks | Addresses per Network |
| :---: | :---: | :--- | :---: | :---: | :---: | :---: |
| **A** | `0` | 1.0.0.0 – 126.0.0.0 | 8 (7 usable) | 24 | $2^7 = \mathbf{128}$ | $2^{24} = \mathbf{16,777,216}$ |
| **B** | `10` | 128.0.0.0 – 191.255.0.0 | 16 (14 usable) | 16 | $2^{14} = \mathbf{16,384}$ | $2^{16} = \mathbf{65,536}$ |
| **C** | `110` | 192.0.0.0 – 223.255.255.0 | 24 (21 usable) | 8 | $2^{21} = \mathbf{2,097,152}$ | $2^8 = \mathbf{256}$ |
| **D** | `1110`| 224.0.0.0 – 239.255.255.255| N/A | N/A | Multicast Groups | Multicast Stream |
| **E** | `1111`| 240.0.0.0 – 255.255.255.255| N/A | N/A | Experimental / Research | Reserved |

🇬🇧 English Exam Answer:
• 1. Decimal to Binary Conversion of `192.18.101.5`:
  - 1st Octet: $192 = 128 + 64 = \mathbf{11000000}_2$
  - 2nd Octet: $18  = 16 + 2 = \mathbf{00010010}_2$
  - 3rd Octet: $101 = 64 + 32 + 4 + 1 = \mathbf{01100101}_2$
  - 4th Octet: $5   = 4 + 1 = \mathbf{00000101}_2$
  - **Resultant Binary Representation**: `11000000.00010010.01100101.00000101`

• 2. Tabular Representation of Classful IP Architecture:
| Class | Leading Bits | Starting / Ending Range | Network Bits | Host Bits | Total Networks | Total Addresses per Net |
| :---: | :---: | :--- | :---: | :---: | :---: | :---: |
| **Class A** | `0` | 1.0.0.0 to 126.0.0.0 | 8 | 24 | $2^7 = 128$ | $2^{24} = 16,777,216$ |
| **Class B** | `10` | 128.0.0.0 to 191.255.0.0 | 16 | 16 | $2^{14} = 16,384$ | $2^{16} = 65,536$ |
| **Class C** | `110` | 192.0.0.0 to 223.255.255.0 | 24 | 8 | $2^{21} = 2,097,152$ | $2^8 = 256$ |
| **Class D** | `1110`| 224.0.0.0 to 239.255.255.255| N/A | N/A | Reserved for Multicast | N/A |
| **Class E** | `1111`| 240.0.0.0 to 255.255.255.255| N/A | N/A | Reserved for Research/Gov | N/A |"
                },

                // ── 65. Sonali Bank 2023: Multiplexing Types ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Sonali Bank (BIBM)", Post = "Assistant Programmer", 
                    QuestionText = "What is multiplexing? Describe different types of multiplexing with examples.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
সহজ উপমা:
একটি ৪-লেনের হাইওয়ের কথা ভাবুন। রাস্তা একটিই, কিন্তু একসাথে ৪টি গাড়ি পাশাপাশি চলতে পারে। 
টেলিকমিউনিকেশনে একটি একক ফিজিক্যাল তার বা মিডিয়ামের ভেতর দিয়ে একই সময়ে একাধিক স্বাধীন সিগন্যাল পাঠানোর প্রযুক্তিকে বলে **Multiplexing**।

প্রধান ৩টি প্রকারভেদ:
১. **FDM (Frequency Division Multiplexing - অ্যানালগ)**:
   - পুরো ফ্রিকোয়েন্সি ব্যান্ডউইডথকে কয়েকটি ছোট ছোট সাব-চ্যানেলে ভাগ করে নেওয়া হয়।
   - উদাহরণ: রেডিও ও ডিশের কেবল টিভি (প্রতি চ্যানেলের ফ্রিকোয়েন্সি আলাদা)।
২. **WDM (Wavelength Division Multiplexing - অপটিক্যাল ফাইবার)**:
   - কাঁচের ফাইবার অপটিক তারের ভেতর দিয়ে ভিন্ন ভিন্ন তরঙ্গদৈর্ঘ্যের (রঙের) লেজার লাইট একসাথে পাঠানো।
   - উদাহরণ: সাবমেরিন অপটিক্যাল ক্যাবল (DWDM)।
৩. **TDM (Time Division Multiplexing - ডিজিটাল)**:
   - সমস্ত ফ্রিকোয়েন্সি ১ জনের হাতে থাকে, কিন্তু সময়কে মাইক্রো-সেকেন্ড স্লটে ভাগ করে সবাইকে পর্যায়ক্রমে সুযোগ দেওয়া হয়।
   - প্রকারভেদ: Synchronous TDM (ফিক্সড স্লট) ও Statistical TDM (যার ডাটা আছে শুধু তাকেই স্লট দেওয়া হয়)।
   - উদাহরণ: ডিজিটাল টেলিফোন ও মোবাইল সেলুলার নেটওয়ার্ক।

🇬🇧 English Exam Answer:
• 1. Definition of Multiplexing:
  Multiplexing is a telecommunication transmission technique that combines multiple independent analog or digital message streams simultaneously across a single shared physical transmission medium via a Multiplexer (MUX), separated back into original streams at the receiver via a Demultiplexer (DEMUX).

• 2. Types of Multiplexing:
  1. **FDM (Frequency Division Multiplexing)**:
     - Divides available channel bandwidth into distinct non-overlapping frequency sub-bands separated by guard bands.
     - *Type*: Analog signals.
     - *Applications*: AM/FM Radio broadcast, Cable Television (CATV).
  2. **WDM (Wavelength Division Multiplexing)**:
     - Multiplexes multiple optical carrier signals onto a single optical fiber strand by using different wavelengths (colors) of laser light.
     - *Type*: Optical signals.
     - *Applications*: Dense Wavelength Division Multiplexing (DWDM) in undersea submarine telecommunication backbones.
  3. **TDM (Time Division Multiplexing)**:
     - Interleaves discrete digital data streams by assigning synchronized, sequential time slots to each communication channel.
     - *Sub-types*: Synchronous TDM (fixed round-robin slots) and Asynchronous / Statistical TDM (dynamic allocation on demand).
     - *Applications*: T1/E1 digital carrier systems, GSM cellular telephony."
                },

                // ── 66. SBL/JBL/BDBL 2023: Subnet Mask & Localhost IP ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "SBL/JBL/BDBL (BIBM)", Post = "Senior Officer IT", 
                    QuestionText = "What is a Subnet Mask? What is the IP address of localhost?",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
১. Subnet Mask কী?
সহজ উপমা:
একটি আইপি এড্রেস দেখতে ৪টি সংখ্যার মতো হলেও তার ভেতর দুটি অংশ লুকিয়ে থাকে: (১) কোন নেটওয়ার্কের সদস্য এবং (২) ওই নেটওয়ার্কের কোন নির্দিষ্ট পিসি। 
Subnet Mask হলো ৩২-বিটের এমন একটি ছাঁচ বা ফিল্টার—যেখানে সব '1' বিটগুলো নেটওয়ার্ক অংশকে ঢেকে রাখে আর সব '0' বিটগুলো হোস্ট অংশকে নির্দেশ করে। কম্পিউটার এই মাস্ক দিয়ে বিটওয়াইজ AND অপারেশন চালিয়ে তাৎক্ষণিক বুঝতে পারে অপর পিসিটি তার নিজের লোকাল ল্যানে আছে নাকি বাইরের ইন্টারনেটের রাউটারে প্যাকেট পাঠাতে হবে।

২. Localhost এর আইপি এড্রেস কত?
• IPv4-এ Localhost আইপি: **127.0.0.1** (সম্পূর্ণ `127.0.0.0/8` ব্লক লুপব্যাকের জন্য সংরক্ষিত)।
• IPv6-এ Localhost আইপি: **`::1`**
• কাজ: তার বা ওয়াইফাই বন্ধ থাকলেও নিজের পিসির TCP/IP নেটওয়ার্ক সফটওয়্যার স্ট্যাক ঠিক আছে কিনা টেস্ট করা এবং ডেভেলপারদের লোকাল ওয়েব সার্ভার রান করা।

🇬🇧 English Exam Answer:
• 1. Definition and Purpose of a Subnet Mask:
  A Subnet Mask is a 32-bit binary number configured alongside an IPv4 address that demarcates which portion of the IP belongs to the **Network/Subnet Identifier** (consecutive binary 1s) and which portion represents the **Host Identifier** (consecutive binary 0s).
  - *Mechanism*: A host performs a bitwise logical `AND` operation between its IP address and its Subnet Mask to determine whether the destination IP resides on the same local subnet or must be forwarded to the Default Gateway router.
  - *Example*: In `192.168.1.50` with mask `255.255.255.0` (`/24`), `192.168.1` is the Network portion and `.50` is the Host portion.

• 2. IP Address of Localhost:
  - **IPv4 Address**: **`127.0.0.1`** (Reserved within the `127.0.0.0/8` Loopback block, RFC 1122).
  - **IPv6 Address**: **`::1`**
  - *Function*: Routes network traffic directly back into the local operating system's internal TCP/IP network protocol stack without traversing physical Network Interface Cards (NIC) or transmitting signals over the wire. Widely used for local server testing and IPC."
                },

                // ── 67. SBL/JBL/BDBL 2023: HTTP vs HTTPS ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "SBL/JBL/BDBL (BIBM)", Post = "Senior Officer IT", 
                    QuestionText = "Difference between HTTP and HTTPS.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
সহজ উপমা:
• **HTTP (সাধারণ পোস্টকার্ডে লেখা চিঠি)**:
  - আপনি পোস্টকার্ডে ব্যাংকের ইউজার আইডি ও পাসওয়ার্ড লিখে পাঠালেন। পোস্টম্যান বা পথের যে কেউ তা অনায়াসে পড়ে ফেলতে পারে (Man-in-the-Middle Attack)। এটি চলে ডিফল্ট পোর্ট ৮০ তে।
• **HTTPS (লক করা লোহার বক্সে চিঠি)**:
  - পোস্টকার্ডটিকে একটি মজবুত ডিজিটাল লোহার বাক্সে তালা মেরে পাঠানো হয়। এই বাক্সের চাবি শুধুমাত্র অপর প্রান্তের ব্যাংকের অফিসিয়াল সার্ভারের কাছে থাকে। হ্যাকাররা মাঝখান থেকে ডাটা ধরলেও শুধু হিজিবিজি সাংকেতিক কোড দেখবে, কিছুই বুঝতে পারবে না। এটি চলে ডিফল্ট পোর্ট ৪৪৩ এ।

🇬🇧 English Exam Answer:
• Comparison between HTTP and HTTPS:
| Feature | HTTP (Hypertext Transfer Protocol) | HTTPS (HTTP Secure) |
| :--- | :--- | :--- |
| **Security Layer** | Unencrypted plaintext communication. | Encrypted via **SSL / TLS** cryptographic protocols. |
| **Default Port** | Port **80** (TCP) | Port **443** (TCP) |
| **OSI Layer** | Application Layer (Layer 7) | Application Layer operating over TLS (Layer 6/7) |
| **Data Integrity** | Vulnerable to packet sniffing and tampering. | Cryptographic hashing guarantees data integrity. |
| **Digital Certificate**| No certificate required. | Requires valid SSL/TLS certificate signed by a trusted CA. |
| **Vulnerability** | Vulnerable to Man-in-the-Middle (MitM) and eavesdropping. | Immune to eavesdropping and data interception. |
| **Ideal Use-Case** | Public non-sensitive informational blogs. | Online banking, eCommerce checkout, user authentication. |"
                },

                // ── 68. SBL/JBL/BDBL 2023: NAT, Ransomware, Firewall ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "SBL/JBL/BDBL (BIBM)", Post = "Senior Officer IT", 
                    QuestionText = "What is NAT, Ransomware, and Firewall?",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
সহজ উপমা:
১. **NAT (অফিসের সেন্ট্রাল ফোনবোর্ড ও এক্সটেনশন নম্বর)**:
   - ব্যাংকের ভেতরে ৫০০ কর্মীর ৫০০টি কম্পিউটার আছে। কিন্তু ইন্টারনেটের পাবলিক আইপি দামি ও সীমিত। রাউটার NAT প্রযুক্তির মাধ্যমে ভেতরের ৫০০টি প্রাইভেট আইপিকে মাত্র ১টি পাবলিক আইপিতে রূপান্তর করে ইন্টারনেটে পাঠায়। ফলে আইপি সাশ্রয় হয় এবং ভেতরের কম্পিউটারগুলো সরাসরি সাইবার হামলা থেকে বাঁচে।
২. **Ransomware (ডিজিটাল কিডন্যাপার ও মুক্তিপণ শিকারি)**:
   - এটি একটি মারাত্মক ক্ষতিকারক ম্যালওয়্যার। আপনার অজান্তে পিসিতে ঢুকে মুহূর্তের মধ্যে আপনার সমস্ত ব্যাংকিং ফাইল, ডাটাবেস ও ছবিকে মিলিটারি-গ্রেড ক্রিপ্টোগ্রাফি দিয়ে লক (এনক্রিপ্ট) করে দেয়। এরপর স্ক্রিনে মেসেজ দিয়ে বলে—'টাকা ফেরত পেতে হলে অমুক বিটকয়েন ওয়ালেটে ৫ লাখ টাকা মুক্তিপণ (Ransom) দিন, নইলে ফাইল কোনোদিন খুলবে না!'
৩. **Firewall (ভবনের মেইন গেটের সশস্ত্র সিকিউরিটি গার্ড)**:
   - নেটওয়ার্কের প্রবেশমুখে বসানো ট্রাফিক ফিল্টার। পূর্বনির্ধারিত সিকিউরিটি রুলস দেখে সে প্রতিটি ইনকামিং ও আউটগোয়িং প্যাকেট তল্লাশি করে। অনুমোদিত ভালো প্যাকেটকে ঢুকতে দেয়, আর কোনো সন্দেহজনক হ্যাকিং বা ক্ষতিকর ট্রাফিক দেখলে সাথে সাথে গুলি করে (ড্রপ) তাড়িয়ে দেয়।

🇬🇧 English Exam Answer:
• 1. NAT (Network Address Translation):
  - An Internet standard (RFC 3022) operating on border routers that translates private, unroutable IPv4 addresses (RFC 1918) within a local area network into globally unique public IP addresses before forwarding packets across the Internet.
  - Conserves scarce IPv4 address space and acts as an implicit security barrier shielding internal network topology from external scanning.

• 2. Ransomware:
  - A form of extortionist malware that employs robust asymmetric cryptographic algorithms (e.g., AES-256 + RSA-4096) to silently encrypt victim data and system drives.
  - Denies access to system assets and demands financial ransom—typically payable in untraceable cryptocurrencies—in exchange for a decryption key (e.g., WannaCry, LockBit).

• 3. Firewall:
  - A foundational network security perimeter device (hardware, software, or cloud-based) that continuously inspects, monitors, and filters inbound and outbound network traffic based on configured security rulesets.
  - Evaluates packets by source/destination IP, port numbers, protocols (Packet-Filtering Firewall), session state tables (Stateful Inspection Firewall), or application payload content (Next-Generation Firewall - NGFW)."
                },

                // ── 69. SBL/JBL/BDBL 2023: Cable Connection Types (Crossover vs Straight-Through) ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "SBL/JBL/BDBL (BIBM)", Post = "Senior Officer IT", 
                    QuestionText = "Identify cable/connection types: (a) Router to Router (b) Router to Switch (c) PC to PC (d) Hub to Switch (e) Router to PC console.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
মনে রাখার স্বর্ণালী নিয়ম (Golden Rule):
• **সমজাতীয় দুটি ডিভাইস (Like Devices)** $\rightarrow$ **Crossover Cable** (কারণ উভয়েরই ডাটা ট্রান্সমিট পিন একই জায়গায় থাকে, সোজা তার দিলে কথা মুখোমুখি ধাক্কা খাবে)।
  *(ব্যতিক্রম মনে রাখবেন: PC এবং Router এর অভ্যন্তরীণ আর্কিটেকচার সমজাতীয়)*
• **ভিন্ন দুটি ডিভাইস (Unlike Devices)** $\rightarrow$ **Straight-Through Cable** (একজনের ট্রান্সমিট পিন সোজা গিয়ে অন্যজনের রিসিভ পিনে ঢুকবে)।
• **রাউটার কনফিগারেশন পোর্ট** $\rightarrow$ **Rollover Cable (Console Cable)**।

উত্তরসমূহ:
• (a) Router to Router (সমজাতীয়): **Crossover Cable** (বা দূরপাল্লায় Serial DTE/DCE V.35 Cable)
• (b) Router to Switch (ভিন্ন জাতের): **Straight-Through Cable**
• (c) PC to PC (সমজাতীয়): **Crossover Cable**
• (d) Hub to Switch (সমজাতীয় L1/L2 হাব-সুইচ): **Crossover Cable**
• (e) Router to PC Console: **Rollover Cable (RJ45-to-DB9/USB Console Cable)**

🇬🇧 English Exam Answer:
• Rules of Ethernet Cabling (TIA/EIA-568A and TIA/EIA-568B):
  - **Straight-Through Cable**: Uses identical pinouts (568B to 568B) on both ends; connects dissimilar network layer devices.
  - **Crossover Cable**: Uses 568A on one end and 568B on the other, crossing Pin 1 (Tx+) to Pin 3 (Rx+) and Pin 2 (Tx-) to Pin 6 (Rx-); connects similar network devices.
  - **Rollover (Console) Cable**: Reverses all pins (Pin 1 to Pin 8); connects a terminal serial COM port to a router/switch management console.

• Answers to Specific Scenarios:
| Connection Scenario | Device Layers Comparison | Required Cable Type |
| :--- | :--- | :--- |
| **(a) Router to Router** | Layer 3 to Layer 3 (Like devices) | **Crossover Cable** (or Serial Cable for WAN) |
| **(b) Router to Switch** | Layer 3 to Layer 2 (Unlike devices) | **Straight-Through Cable** |
| **(c) PC to PC** | Host to Host (Like devices) | **Crossover Cable** |
| **(d) Hub to Switch** | Layer 1 to Layer 2 (Infrastructure like) | **Crossover Cable** (unless using MDI-X auto-uplink) |
| **(e) Router to PC Console**| Terminal to Serial Auxiliary Interface | **Rollover Cable (Console Cable)** |"
                },

                // ── 70. SBL/JBL/BDBL 2023: Ping Failure Troubleshooting ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "SBL/JBL/BDBL (BIBM)", Post = "Senior Officer IT", 
                    QuestionText = "Ping command gives unsuccessful response. State possible reasons and solutions.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
সহজ উপমা:
আপনি কাউকে দরজায় কড়া নেড়ে ডাকলেন (`Ping`), কিন্তু ভেতর থেকে কোনো সাড়া এলো না। 
এর ৪টি স্বাভাবিক কারণ ও সমাধান:
১. **পথের তার কাটা বা পোর্ট বন্ধ (Physical Layer Down)**:
   - কারণ: ল্যান কেবল খোলা, সুইচ বন্ধ বা নেটওয়ার্ক কার্ড নষ্ট।
   - সমাধান: তারের ক্লিপ ঠিকমতো লাগানো আছে কিনা এবং পিসির NIC পোর্টে সবুজ বাতি জ্বলছে কিনা দেখা।
২. **টার্গেট পিসির ফায়ারওয়াল ICMP ব্লক করছে (Firewall Blocking)**:
   - কারণ: উইন্ডোজ ডিফেন্ডার বা অ্যান্টিভাইরাস ফায়ারওয়াল পিং রিকোয়েস্ট (ICMP Echo) রিজেক্ট করে দেয়।
   - সমাধান: রিমোট পিসির ফায়ারওয়ালে 'File and Printer Sharing (Echo Request - ICMPv4-In)' রুলটি চালু করা।
৩. **ভুল আইপি বা সাবনেট মাস্ক কনফিগারেশন (IP Configuration Error)**:
   - কারণ: আইপি এড্রেসে ভুল টাইপ হওয়া বা ডিফল্ট গেটওয়ে ভুল থাকা।
   - সমাধান: `ipconfig /all` দেখে লোকাল আইপি, সাবনেট মাস্ক ও গেটওয়ে ঠিক করা।
৪. **রাউটারে ট্রাফিক ড্রপ বা রাউটিং লুপ (Routing Failure)**:
   - কারণ: মাঝের রাউটার গন্তব্যের রাস্তা চেনে না (Destination Host Unreachable)।
   - সমাধান: `tracert <target_ip>` চালিয়ে কোন রাউটারে প্যাকেট ড্রপ হচ্ছে তা খুঁজে রাউটিং টেবিল ফিক্স করা।

🇬🇧 English Exam Answer:
• 1. Diagnostic Meaning of Ping Failure:
  The `ping` utility sends ICMP Echo Request packets (Type 8) expecting ICMP Echo Replies (Type 0). Unsuccessful responses (e.g., *Request Timed Out*, *Destination Host Unreachable*) indicate network breakdown along the path.

• 2. Root Causes and Systemic Solutions:
| Failure Mode / Error | Root Cause | Engineering Solution |
| :--- | :--- | :--- |
| **Request Timed Out** | Destination machine's firewall or intermediate IPS is silently dropping incoming ICMP Echo packets. | Inspect host firewall rules (Windows Firewall / iptables); explicitly enable inbound ICMP Echo Request rule. |
| **Request Timed Out** | Physical media disconnect or faulty link (Layer 1/2 failure). | Verify physical RJ-45 seating, cable continuity, NIC link LED activity, and switch port status. |
| **Destination Host Unreachable** | Local Default Gateway or intermediate router lacks a valid route to the target subnet in its routing table. | Verify Default Gateway configuration via `ipconfig`; audit router routing tables (OSPF/Static routes). |
| **Transmit Failed (General Failure)**| Local IP stack misconfiguration or corrupted TCP/IP stack. | Reinstall NIC drivers; execute `netsh int ip reset` and restart operating system. |
| **TTL Expired in Transit** | Packets caught in an infinite routing loop between intermediate routers. | Execute `tracert` / `traceroute` to isolate oscillating router hops; resolve routing loops and update routing protocols. |"
                },

                // ── 71. SBL/JBL/BDBL 2023: Dijkstra Shortest Path Algorithm ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "SBL/JBL/BDBL (BIBM)", Post = "Senior Officer IT", 
                    QuestionText = "Find shortest path from node A using Dijkstra's algorithm for given network topology.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
সহজ উপমা:
Dijkstra হলো নেটওয়ার্কের জন্য **গুগল ম্যাপস**! এটি একটি লোভেী (Greedy) অ্যালগরিদম যা সোর্স নোড থেকে শুরু করে ধাপে ধাপে প্রতিটি শহরের সবচেয়ে শর্টকাট পথ বের করে।

অ্যালগরিদমের সহজ ৩টি ধাপ:
১. **প্রারম্ভিক মান (Initialization)**:
   - শুরু নোড A-এর দূরত্ব = **0**।
   - বাকি সকল অচেনা নোডের দূরত্ব = $\mathbf{\infty}$ (অসীম)।
২. **সর্বনিম্ন দূরত্বের নোড নির্বাচন (Greedy Pick)**:
   - এখনও ভিজিট করা হয়নি এমন নোডগুলোর মধ্যে যেটির দূরত্ব সবচেয়ে কম, সেটিকে সিলেক্ট করো (Current Node = $u$)।
৩. **প্রতিবেশীদের দূরত্ব আপডেট (Relaxation Step)**:
   - $u$-এর সাথে যুক্ত প্রতিটি প্রতিবেশী $v$-এর ক্ষেত্রে হিসাব করো:
     যদি $A \rightarrow u \rightarrow v$ দিয়ে গেলে দূরত্ব আগের চেয়ে কম হয়, তবে $v$-এর দূরত্ব কমিয়ে দাও:
     $$\text{If } dist[u] + cost(u, v) < dist[v] \implies dist[v] = dist[u] + cost(u, v)$$
   - নোড $u$-কে স্থায়ী (Visited) মার্ক করো এবং সব নোড শেষ না হওয়া পর্যন্ত ২ ও ৩ নম্বর ধাপ পুনরাবৃত্তি করো।
*(নেটওয়ার্কিংয়ে OSPF রাউটিং প্রোটোকল এই ডাইকস্ট্রা অ্যালগরিদমের উপর ভিত্তি করেই ইন্টারনেটের দ্রুততম পাথ বের করে)*।

🇬🇧 English Exam Answer:
• 1. Overview of Dijkstra's Algorithm:
  Dijkstra's Algorithm is a single-source shortest path algorithm that operates on weighted directed/undirected graphs with non-negative edge weights. It is the mathematical engine underpinning the OSPF (Open Shortest Path First) and IS-IS Link-State routing protocols.

• 2. Algorithmic Execution Steps:
  1. **Initialization**:
     - Maintain an unvisited set $Q$ containing all vertices $V$.
     - Set distance $dist[Source] = 0$; set $dist[v] = \infty$ for all other vertices $v \in V \setminus \{Source\}$.
     - Initialize predecessor array $prev[v] = \text{undefined}$.
  2. **Vertex Selection**:
     - While $Q$ is not empty, extract vertex $u \in Q$ with the minimum tentative distance $dist[u]$.
     - Remove $u$ from $Q$ (mark as permanently visited).
  3. **Edge Relaxation**:
     - For each unvisited neighbor $v$ of $u$:
       $$\text{alt} = dist[u] + \text{weight}(u, v)$$
       $$\text{If } \text{alt} < dist[v] \implies dist[v] = \text{alt}, \quad prev[v] = u$$
  4. **Termination**:
     - Process terminates when $Q = \emptyset$. The algorithm yields the Shortest Path Tree (SPT) from root node A to all reachable destinations in the topology.

• 3. Computational Complexity:
  - Using Min-Priority Queue (Binary Heap): $\mathcal{O}((V + E) \log V)$, where $V$ is the number of routers and $E$ is the number of connecting links."
                },

                // ── 72. SBL/JBL/BDBL 2023: Subnetting Class C for 30 Subnets ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "SBL/JBL/BDBL (BIBM)", Post = "Senior Officer IT", 
                    QuestionText = "Company network 202.11.2.0 (Class C). Create 30 subnets. Find: (i) Subnet mask (ii) Total IP/subnet (iii) Usable hosts/subnet (iv) Network & Broadcast of 1st and 30th subnet.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা ও গাণিতিক সমাধান:
দেওয়া আছে: `202.11.2.0` (Class C ডিফল্ট প্রিফিক্স = `/24`)।
আমাদের ৩০টি সাবনেট তৈরি করতে হবে।

১. কয়টি সাবনেট বিট ধার করতে হবে?
ফর্মুলা: $2^s \ge N \implies 2^s \ge 30 \implies s = \mathbf{5}$ বিট ($2^5 = 32$ সাবনেট)।
অবশিষ্ট হোস্ট বিট ($h$) = $8 - 5 = \mathbf{3}$ বিট।

২. (i) Subnet Mask নির্ণয়:
• নতুন প্রিফিক্স = $24 + 5 = \mathbf{/29}$
• বাইনারি মাস্ক: `11111111.11111111.11111111.11111000`
• সাবনেট মাস্ক = **255.255.255.248**
• ম্যাজিক নাম্বার (ব্লক সাইজ) = $256 - 248 = \mathbf{8}$

৩. (ii) প্রতি সাবনেটে মোট আইপি:
• Total IP = $2^h = 2^3 = \mathbf{8}$ টি আইপি।

৪. (iii) প্রতি সাবনেটে ব্যবহারযোগ্য হোস্ট আইপি:
• Usable Hosts = $2^h - 2 = 8 - 2 = \mathbf{6}$ টি হোস্ট।

৫. (iv) ১ম এবং ৩০তম সাবনেটের ঠিকানা:
• **1st Subnet (Index 0)**:
  - Network ID: **202.11.2.0**
  - First Usable: 202.11.2.1
  - Last Usable: 202.11.2.6
  - Broadcast ID: **202.11.2.7**
• **30th Subnet (Index 29, $29 \times 8 = 232$)**:
  - Network ID: **202.11.2.232**
  - First Usable: 202.11.2.233
  - Last Usable: 202.11.2.238
  - Broadcast ID: **202.11.2.239**

🇬🇧 English Exam Answer:
• Given: Class C Base Network `202.11.2.0/24`. Requirement: Minimum 30 subnets.
• Mathematical Derivation:
  - Formula: $2^s \ge 30 \implies s = 5\text{ bits borrowed}$.
  - Remaining Host bits ($h$) = $32 - (24 + 5) = 3\text{ bits}$.

• (i) Subnet Mask:
  - New CIDR Prefix = $24 + 5 = \mathbf{/29}$
  - Binary Subnet Mask = `11111111.11111111.11111111.11111000`
  - Dotted Decimal Subnet Mask = **255.255.255.248**
  - Block Size (Increment) = $256 - 248 = 8$

• (ii) Total IP Addresses per Subnet:
  $$\text{Total IPs} = 2^h = 2^3 = \mathbf{8}\text{ addresses}$$

• (iii) Usable Host Addresses per Subnet:
  $$\text{Usable Hosts} = 2^h - 2 = 8 - 2 = \mathbf{6}\text{ hosts}$$

• (iv) Addressing for 1st and 30th Subnet:
| Subnet Order | Subnet Index | Network Address | Usable Host Range | Broadcast Address |
| :---: | :---: | :---: | :---: | :---: |
| **1st Subnet** | 0 ($0 \times 8$) | **202.11.2.0** | 202.11.2.1 – 202.11.2.6 | **202.11.2.7** |
| **30th Subnet**| 29 ($29 \times 8$) | **202.11.2.232** | 202.11.2.233 – 202.11.2.238 | **202.11.2.239** |"
                },

                // ── 73. SBL/JBL/BDBL 2023: Satellite Link Delay Math ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "SBL/JBL/BDBL (BIBM)", Post = "Senior Officer IT", 
                    QuestionText = "Geostationary satellite at altitude 36000 km, speed of light 3×10^8 m/s, bandwidth 10 Mbps. Compute: (i) Propagation delay (ii) Bandwidth-delay product.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept & Step-by-Step Math):
সহজ উপমা:
পৃথিবীর মাটি থেকে মহাকাশে থাকা স্যাটেলাইটে সিগন্যাল পাঠিয়ে আবার মাটিতে ফেরত আনা।
• ব্যান্ডউইডথ-ডিলে প্রোডাক্ট (BDP) হলো এমন—যেন একটি লম্বা পাইপের ধারণক্ষমতা। পাইপটি দিয়ে ডাটা যাওয়ার সময় বাতাসে প্রতি মুহূর্তে কত বিট ডাটা পাইপের ভেতর ভাসমান অবস্থায় জমা থাকে!

দেওয়া আছে:
• দূরত্ব ($d$) = ৩৬,০০০ কিমি = $36,000 \times 10^3\text{ m} = 36 \times 10^6\text{ m}$
• আলোর গতি ($c$) = $3 \times 10^8\text{ m/s}$
• ব্যান্ডউইডথ ($B$) = $10\text{ Mbps} = 10 \times 10^6\text{ bps} = 10^7\text{ bps}$

১. (i) Propagation Delay ($D_{prop}$) নির্ণয়:
• একমুখী (One-way: Ground-to-Satellite):
  $$D_{prop} = \frac{d}{c} = \frac{36 \times 10^6\text{ m}}{3 \times 10^8\text{ m/s}} = 0.12\text{ সেকেন্ড} = \mathbf{120\text{ ms}}$$
• *(গ্রাউন্ড স্টেশন থেকে স্যাটেলাইট হয়ে অপর গ্রাউন্ড স্টেশন হলে আপলিংক + ডাউনলিংক = $2 \times 120 = \mathbf{240\text{ ms}}$)*।

২. (ii) Bandwidth-Delay Product (BDP) নির্ণয়:
$$\text{BDP} = \text{Bandwidth} \times D_{prop}$$
$$\text{BDP} = 10^7\text{ bps} \times 0.12\text{ s} = 1,200,000\text{ bits} = \mathbf{1.2 \times 10^6\text{ bits}}$$
• বাইটে রূপান্তর করলে: $\frac{1,200,000}{8} = 150,000\text{ Bytes} = \mathbf{150\text{ KB}}$।
(রাউন্ড ট্রিপ ২৪০ ms বিবেচনায় BDP = $2.4 \times 10^6\text{ bits} = 300\text{ KB}$)।

🇬🇧 English Exam Answer:
• 1. Given Parameters:
  - Altitude / Distance ($d$) = $36,000\text{ km} = 3.6 \times 10^7\text{ meters}$
  - Speed of Electromagnetic Waves ($c$) = $3 \times 10^8\text{ m/s}$
  - Channel Bandwidth ($R$) = $10\text{ Mbps} = 10 \times 10^6\text{ bits/second}$

• 2. (i) Computation of Propagation Delay:
  - One-Way Uplink Propagation Delay ($T_p$):
    $$T_p = \frac{d}{c} = \frac{3.6 \times 10^7\text{ m}}{3 \times 10^8\text{ m/s}} = 0.12\text{ seconds} = \mathbf{120\text{ ms}}$$
  - Total One-Way Ground-to-Ground Hop (Uplink + Downlink):
    $$T_{hop} = 2 \times T_p = 2 \times 0.12 = \mathbf{0.24\text{ seconds (240 ms)}}$$

• 3. (ii) Computation of Bandwidth-Delay Product (BDP):
  The Bandwidth-Delay Product represents the maximum volume of data in transit on the transmission link at any given instant:
  - For one-way delay ($T_p = 0.12\text{ s}$):
    $$\text{BDP} = \text{Bandwidth} \times T_p = (10 \times 10^6\text{ bps}) \times 0.12\text{ s} = \mathbf{1.2 \times 10^6\text{ bits}} \quad (\mathbf{150\text{ KB}})$$
  - For full Round-Trip Time (RTT $\approx 480\text{ ms}$ ground-satellite-ground):
    $$\text{BDP}_{RTT} = 10^7\text{ bps} \times 0.48\text{ s} = \mathbf{4.8 \times 10^6\text{ bits}} \quad (\mathbf{600\text{ KB}})$$
  *(TCP sender requires a minimum window size of 600 KB to fully saturate the satellite pipe without stalling).* "
                },

                // ── 74. SBL/JBL/BDBL 2023: Framing, Flow, Error, Reliability Layers ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "SBL/JBL/BDBL (BIBM)", Post = "Senior Officer IT", 
                    QuestionText = "Which OSI layer is responsible for: (i) Framing (ii) Flow control (iii) Error control (iv) Reliable process-to-process delivery?",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
মনে রাখার সহজ বিশ্লেষণ:
• **(i) Framing**: **Data Link Layer (Layer 2)**
  - কাঁচা বিটস্ট্রিমের গায়ে হেডার (MAC) ও ট্রেইলার (FCS) লাগিয়ে ফ্রেম তৈরি করা ডাটা লিংক লেয়ারের কাজ।
• **(ii) Flow Control**: **Data Link Layer (Layer 2)** এবং **Transport Layer (Layer 4)**
  - সরাসরি যুক্ত দুটি ডিভাইসের মাঝে স্পিড কন্ট্রোল করে L2 (Stop-and-Wait / Sliding Window)। আর দুই প্রান্তের সফটওয়্যারের মাঝে এন্ড-টু-এন্ড স্পিড কন্ট্রোল করে L4 (TCP Sliding Window)।
• **(iii) Error Control**: **Data Link Layer (Layer 2)** এবং **Transport Layer (Layer 4)**
  - তারের মধ্যবর্তী ফিজিক্যাল ত্রুটি ধরে L2 (CRC32 দিয়ে ফ্রেম ফেলে দেওয়া)। আর সম্পূর্ণ ডাটা হারানো বা বিকৃত হলে রিট্রান্সমিট করে নিশ্চিত করে L4 (TCP Checksum & ACK)।
• **(iv) Reliable process-to-process delivery**: **Transport Layer (Layer 4)**
  - নির্দিষ্ট অ্যাপ্লিকেশনের পোর্ট নম্বর ধরে ধরে নির্ভরযোগ্যভাবে এন্ড-টু-এন্ড মেসেজ পৌঁছে দেওয়া এককভাবে ট্রান্সপোর্ট লেয়ারের (TCP) মৌলিক দায়িত্ব।

🇬🇧 English Exam Answer:
• OSI Layer Responsibility Matrix:
| Network Function | Responsible OSI Layer(s) | Operational Mechanism & Scope | Protocols / Standards |
| :--- | :--- | :--- | :--- |
| **(i) Framing** | **Data Link Layer (Layer 2)** | Encapsulates Network packets into discrete physical frames with header flags, MAC addressing, and Frame Check Sequence (FCS). | Ethernet (IEEE 802.3), HDLC, PPP |
| **(ii) Flow Control** | **Data Link Layer (L2)** & **Transport Layer (L4)** | - **L2**: Hop-to-hop link flow control preventing adjacent receiver buffer overflow.<br>- **L4**: End-to-end flow control via dynamic Sliding Window (`rwnd`). | - L2: IEEE 802.3x PAUSE<br>- L4: TCP Sliding Window |
| **(iii) Error Control** | **Data Link Layer (L2)** & **Transport Layer (L4)** | - **L2**: Detects physical transmission errors via CRC/FCS; discards damaged frames.<br>- **L4**: Detects corruption via 16-bit 1's complement Checksum and recovers missing segments via ARQ. | - L2: CRC-32<br>- L4: TCP Checksum & ACK |
| **(iv) Reliable Process Delivery**| **Transport Layer (Layer 4)** | Binds communication to specific application processes using **Port Numbers** and guarantees end-to-end ordered, duplicate-free delivery. | **TCP (Transmission Control Protocol)** |"
                },

                // ── 75. SBL/JBL/BDBL 2023: Public vs Private Inter-Branch Communication ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "SBL/JBL/BDBL (BIBM)", Post = "Senior Officer IT", 
                    QuestionText = "Company A in Dhaka has IP 202.50.14.3 (Public). Company B in Chittagong has IP 192.168.40.3 (Private). Can they communicate directly? Explain why/why not and provide a solution.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
১. তারা কি সরাসরি যোগাযোগ করতে পারবে?
**না, সরাসরি কখনোই যোগাযোগ করতে পারবে না (Direct Communication is Impossible)।**
কারণ:
চিটাগাং অফিসের আইপি `192.168.40.3` হলো একটি RFC 1918 **Private IP Address**। গ্লোবাল ইন্টারনেটের সমস্ত পাবলিক রাউটার প্রাইভেট আইপির প্যাকেট দেখা মাত্র সাথে সাথে ড্রপ (বাতিল) করে দেয়। ঢাকা অফিস থেকে ইন্টারনেটের মধ্য দিয়ে এই প্রাইভেট আইপিতে কোনো প্যাকেট পৌঁছানো সম্ভব নয়।

২. ব্যাংকিং সমাধানের ২টি উপায়:
• **সমাধান ১: Site-to-Site IPsec VPN Tunnel (ব্যাংকের জন্য শ্রেষ্ঠ)**:
  - ঢাকা ও চিটাগাং উভয় অফিসের এজ রাউটারের মধ্যে পাবলিক ইন্টারনেটের ওপর দিয়ে একটি ভার্চুয়াল এনক্রিপ্টেড টানেল (IPsec VPN) তৈরি করা হয়। ফলে উভয় প্রান্তের প্রাইভেট আইপি একে অপরের সাথে সরাসরি কথা বলতে পারে যেন তারা একই অফিসের লোকাল ল্যানে আছে।
• **সমাধান ২: NAT / Port Forwarding**:
  - চিটাগাং প্রান্তে ISP থেকে একটি পাবলিক আইপি নিয়ে রাউটারে NAT/Port Forwarding কনফিগার করতে হবে। ঢাকা অফিস চিটাগাংয়ের পাবলিক আইপি ও নির্দিষ্ট পোর্টে রিকোয়েস্ট পাঠালে রাউটার তা ভেতরের প্রাইভেট পিসিতে ফরোয়ার্ড করবে।

🇬🇧 English Exam Answer:
• 1. Feasibility Assessment:
  **No, direct communication between the two endpoints is fundamentally impossible across the public Internet.**

• 2. Architectural Reason:
  - The Chittagong host IP `192.168.40.3` falls strictly within the **RFC 1918 Private Address Space** (`192.168.0.0/16`).
  - RFC 1812 and RFC 1918 mandate that all Internet Service Provider (ISP) transit and core routers must filter and silently drop packets destined for or originating from private IP ranges to prevent routing loop chaos.
  - While Dhaka possesses a globally routable public IPv4 address (`202.50.14.3`), Dhaka cannot address or route return packets to an unadvertised private destination across the Internet WAN.

• 3. Recommended Enterprise Solutions:
  1. **Site-to-Site IPsec VPN Tunnel (Industry Standard)**:
     - Provision a public IP on Chittagong's border gateway router.
     - Establish an encrypted IPsec (IKEv2 + AES-256) tunnel between Dhaka and Chittagong gateways.
     - Internal private subnets communicate transparently and securely across the public Internet through encapsulation.
  2. **NAT & Destination Port Forwarding**:
     - Assign a public IP to Chittagong's router and configure Port Address Translation (PAT / Static NAT). Dhaka initiates traffic to Chittagong's public IP on a dedicated port, which the router translates to `192.168.40.3`."
                },

                // ── 76. SBL/JBL/BDBL 2023: Checksum Calculation for Array ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "SBL/JBL/BDBL (BIBM)", Post = "Senior Officer IT", 
                    QuestionText = "Data array [3, 9, 7, 12, 4] using 8-bit checksum. Compute sender checksum and show receiver verification.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Step-by-Step Math):
সহজ উপমা:
মুদি দোকানের হিসাব মেলানো। প্রেরক তার ৫টি পণ্যের দাম যোগ করে খাতার নিচে 'মোট যোগফল' লিখে পাঠাবে। প্রাপক সব দাম ও চেকসাম একসাথে যোগ করে দেখবে ফলাফল শূন্য (সবগুলো ১) আসে কিনা।

দেওয়া আছে ডাটা: $[3, 9, 7, 12, 4]$ (৮-বিট যোগ)।

ধাপ ১: প্রেরক প্রান্তে যোগফল ও চেকসাম তৈরি (Sender Side):
• সাধারণ যোগফল ($Sum$) = $3 + 9 + 7 + 12 + 4 = \mathbf{35}$
• ৩৫ এর ৮-বিট বাইনারি রূপ:
  $$35 = 32 + 2 + 1 = \mathbf{00100011}_2$$
• **Checksum** হলো এই যোগফলের ১'স কমপ্লিমেন্ট (সব বিট উল্টে দেওয়া: 0 কে 1, 1 কে 0):
  $$\text{Checksum} = \text{NOT}(00100011) = \mathbf{11011100}_2 \quad (\text{দশমিকে } 255 - 35 = \mathbf{220})$$
• তার দিয়ে প্রেরিত সম্পূর্ণ ডাটা ব্লক: $[3, 9, 7, 12, 4, \text{Checksum}=220]$।

ধাপ ২: গ্রাহক প্রান্তে ত্রুটি যাচাই (Receiver Side Verification):
• রিসিভার প্রাপ্ত সব ডাটা এবং সাথে আসা চেকসাম একসাথে যোগ করে:
  $$\text{Total Sum} = 3 + 9 + 7 + 12 + 4 + 220 = \mathbf{255}$$
• ২৫৫ এর ৮-বিট বাইনারি রূপ:
  $$\text{Total Sum} = \mathbf{11111111}_2$$
• এখন এই Total Sum-এর ১'স কমপ্লিমেন্ট নেওয়া হয়:
  $$\text{Verification} = \text{NOT}(11111111) = \mathbf{00000000}_2 \quad (\text{ফলাফল } \mathbf{0})$$
• **সিদ্ধান্ত**: যেহেতু ১'স কমপ্লিমেন্টের ফলাফল **0** এসেছে, তাই **ডাটা নির্ভুলভাবে রিসিভ হয়েছে (No Error Detected)**।

🇬🇧 English Exam Answer:
• Given Data Array: $[3, 9, 7, 12, 4]$. System: 8-Bit Checksum.

• 1. Sender-Side Checksum Generation:
  - Compute the sum of all 8-bit data items:
    $$\text{Sum} = 3 + 9 + 7 + 12 + 4 = 35$$
  - Binary representation of Sum ($35_{10}$):
    $$\text{Sum} = \mathbf{00100011}_2$$
  - The 8-bit Checksum is the 1's Complement (Bitwise Inversion) of the Sum:
    $$\text{Checksum} = \sim(00100011)_2 = \mathbf{11011100}_2 \quad (220_{10})$$
  - The transmitted data frame is: $[3, 9, 7, 12, 4, \mathbf{220}]$.

• 2. Receiver-Side Integrity Verification:
  - Add all received data words along with the transmitted checksum:
    $$\text{Total Received Sum} = 3 + 9 + 7 + 12 + 4 + 220 = 255_{10}$$
  - Binary representation:
    $$\text{Total Received Sum} = \mathbf{11111111}_2$$
  - Take the 1's Complement of the accumulated sum:
    $$\text{Result} = \sim(11111111)_2 = \mathbf{00000000}_2 \quad (0_{10})$$

• 3. Conclusion:
  - Since the inverted total sum evaluates to **all zeros (0)**, the data has been verified as **uncorrupted (No Transmission Error)**."
                },

                // ── 77. SBL/JBL/BDBL 2023: Network Diagnostic CLI Commands ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "SBL/JBL/BDBL (BIBM)", Post = "Senior Officer IT", 
                    QuestionText = "State the purpose of CLI commands: ping, tracert/traceroute, nslookup, ipconfig/ifconfig, netstat, arp.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
নেটওয়ার্ক ইঞ্জিনিয়ারের ৬টি জাদুকরী কমান্ডের সহজ পরিচিতি:
১. **ping**: 'তুমি কি বেঁচে আছো?'—আইসিএমপি প্যাকেট পাঠিয়ে রিমোট সার্ভার সচল আছে কিনা এবং যেতে কত মিলি-সেকেন্ড লাগে (Latency) তা পরীক্ষা করে।
২. **tracert / traceroute**: সোর্স থেকে ডেস্টিনেশনে যাওয়ার পথে মাঝের কোন কোন রাউটার হয়ে গাড়ি যাচ্ছে এবং কোন মোড়ে গিয়ে জ্যাম লাগছে তা প্রতিটি হপ ধরে ধরে বের করে দেয়।
৩. **nslookup**: ডিএনএস গোয়েন্দা—ডোমেইনের আসল আইপি এড্রেস এবং মেইল সার্ভার রেকর্ড (MX) চেক করে।
৪. **ipconfig / ifconfig**: পিসির আয়না—নিজের কম্পিউটারের IP, Subnet Mask, Gateway ও DNS কনফিগারেশন এক নজরে স্ক্রিনে দেখায়।
৫. **netstat**: পিসির ওপেন উইন্ডোজ—এই মুহূর্তে আপনার কম্পিউটার কোন কোন ওয়েবসাইটের সাথে যুক্ত এবং কোন কোন পোর্ট ওপেন আছে তার তালিকা দেয়।
৬. **arp -a**: চিনে রাখার ডায়েরি—কোন আইপি এড্রেসের বিপরীতে কোন পিসির হার্ডওয়্যার MAC Address পাওয়া গেছে তার ক্যাশ টেবিল দেখায়।

🇬🇧 English Exam Answer:
• Summary of Essential Network Diagnostic CLI Commands:
| CLI Command | Layer & Underlying Protocol | Primary Purpose & Diagnostic Utility | Example Usage |
| :--- | :---: | :--- | :--- |
| **ping** | Layer 3 (ICMP) | Tests end-to-end reachability of a host and measures round-trip time (RTT) and packet loss percentage. | `ping 8.8.8.8` |
| **tracert** (Win) / **traceroute** (Linux)| Layer 3 (ICMP / UDP TTL) | Traces the hop-by-hop layer-3 route to a destination, isolating exact router bottlenecks by incrementing IP TTL. | `tracert google.com` |
| **nslookup** | Layer 7 (DNS Port 53) | Queries DNS name servers to resolve domain names to IP addresses (`A`/`AAAA`) and inspect MX/TXT records. | `nslookup mail.bank.com` |
| **ipconfig** (Win) / **ifconfig** (Linux)| OS Network Stack | Displays all active network adapter interfaces, IP addresses, subnet masks, default gateways, and DHCP leases. | `ipconfig /all` |
| **netstat** | Layer 4 (TCP/UDP) | Displays active network sockets, incoming/outgoing TCP connections, routing tables, and listening ports. | `netstat -ano` |
| **arp** | Layer 2/3 (ARP) | Views and modifies the local Address Resolution Protocol (ARP) cache mapping IPv4 addresses to physical MACs. | `arp -a` |"
                },

                // ── 78. SBL/JBL/BDBL 2023: Link-State vs Distance Vector ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "SBL/JBL/BDBL (BIBM)", Post = "Senior Officer IT", 
                    QuestionText = "Compare Link-State and Distance-Vector routing algorithms in terms of: (i) Message complexity (ii) Speed of convergence (iii) Robustness against faulty nodes.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
সহজ উপমা:
• **Distance Vector (RIP - প্রতিবেশীর মুখস্থ কথা)**:
  - আপনি রাস্তা চেনেন না, পাশের জনকে জিজ্ঞাসা করলেন—'মতিঝিল কোন দিকে?' সে বলল—'ডানে ৩ কিলোমিটার'। আপনি নিজের চোখে ম্যাপ দেখেননি, শুধুই প্রতিবেশীর কথায় ভরসা করেছেন (Routing by Rumor)।
• **Link-State (OSPF - গুগল স্যাটেলাইট ম্যাপ)**:
  - প্রতিটি রাউটার পুরো দেশের সম্পূর্ণ রোড ম্যাপ নিজের মেমরিতে জমা রাখে। সে নিজের চোখে সব রাস্তা দেখে Dijkstra অ্যালগরিদম দিয়ে শর্টকাট পথ বেছে নেয়।

৩টি প্রধান তুলনামূলক বিষয়:
১. **Message Complexity (মেসেজের সংখ্যা)**:
   - Distance Vector: কম—শুধু সরাসরি প্রতিবেশীকে নিজের টেবিল কপি করে দেয় ($O(\text{neighbors})$)।
   - Link State: বেশি—পুরো নেটওয়ার্কের সবাইকে লিংক স্ট্যাটাস LSA ফ্লাডিং করে জানাতে হয় ($O(N \cdot E)$)।
২. **Speed of Convergence (কত দ্রুত পুরো নেটওয়ার্ক আপডেট হয়)**:
   - Distance Vector: ধীরগতি (Slow)—রাউটিং লুপ ও Count-to-Infinity সমস্যা হতে পারে।
   - Link State: সুপার ফাস্ট (Fast)—কোনো তার কাটলে পলকের মধ্যে Dijkstra চালিয়ে নতুন রাস্তা বের করে ফেলে।
৩. **Robustness (ত্রুটিপূর্ণ নোডের বিরুদ্ধে টিকে থাকার ক্ষমতা)**:
   - Distance Vector: দুর্বল—একটি রাউটার ভুল দূরত্ব জানালে পুরো নেটওয়ার্ক অন্ধ হয়ে যাবে।
   - Link State: অত্যন্ত মজবুত—একটি রাউটার মিথ্যা বললেও সে শুধু নিজের সরাসরি লিংকের কথা বলতে পারে, অন্যের ম্যাপ নষ্ট করতে পারে না।

🇬🇧 English Exam Answer:
• Comparison between Distance-Vector and Link-State Routing:
| Comparison Dimension | Distance-Vector (e.g., RIP, Bellman-Ford) | Link-State (e.g., OSPF, Dijkstra SPF) |
| :--- | :--- | :--- |
| **(i) Message Complexity** | **Lower Message Overhead**: Nodes periodically exchange routing tables exclusively with directly connected neighbors. Complexity is $\mathcal{O}(\text{degree})$. | **Higher Message Overhead**: When link states change, LSAs are flooded to *all* nodes across the entire OSPF area. Complexity is $\mathcal{O}(N \cdot E)$. |
| **(ii) Speed of Convergence** | **Slow Convergence**: Propagates routing updates step-by-step; prone to routing loops and the **Count-to-Infinity** problem. | **Very Fast Convergence**: Flooded LSAs trigger immediate local recomputation of Dijkstra's Shortest Path Tree without transient loops. |
| **(iii) Robustness against Faults**| **Low Robustness**: A malfunctioning or misconfigured node advertises incorrect lowest-cost paths to neighbors, poisoning the entire global routing table (Routing by Rumor). | **High Robustness**: Routers broadcast only the state of their *directly attached* links. Each router computes its own independent forwarding table from the synchronized LSDB. |"
                },

                // ── 79. SBL/JBL/BDBL 2023: AMPS Cellular Bandwidth Channels ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "SBL/JBL/BDBL (BIBM)", Post = "Senior Officer IT", 
                    QuestionText = "AMPS cellular system has 20 MHz total bandwidth. Each simplex voice channel is 30 kHz. 42 channels are reserved for control. Compute: (i) Number of duplex voice channels (ii) Channels available per cell for 7-cell reuse system.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা ও গাণিতিক সমাধান:
দেওয়া আছে:
• মোট ব্যান্ডউইডথ = ২০ MHz = $20,000\text{ kHz}$
• প্রতিটি সিমপ্লেক্স চ্যানেলের ব্যান্ডউইডথ = $30\text{ kHz}$
• টেলিফোনে কথা বলতে একই সাথে বলা ও শোনার জন্য ২টি সিমপ্লেক্স চ্যানেল মিলে ১টি **Duplex Channel** (Uplink + Downlink) তৈরি হয়।
• সুতরাং ১টি Duplex Channel এর ব্যান্ডউইডথ = $30\text{ kHz} \times 2 = \mathbf{60\text{ kHz}}$।
• কন্ট্রোল চ্যানেল সংখ্যা = ৪২টি।

১. (i) মোট ভয়েস চ্যানেল সংখ্যা নির্ণয়:
• মোট ডুপ্লেক্স চ্যানেল = $\frac{\text{মোট ব্যান্ডউইডথ}}{\text{প্রতি ডুপ্লেক্স চ্যানেলের ব্যান্ডউইডথ}} = \frac{20,000\text{ kHz}}{60\text{ kHz}} \approx \mathbf{333}$ টি।
• যেহেতু ৪২টি চ্যানেল কন্ট্রোল কাজের জন্য সংরক্ষিত:
  $$\text{Duplex Voice Channels} = 333 - 42 = \mathbf{291}\text{ টি}$$
*(বা যদি কন্ট্রোল চ্যানেল আলাদা সিস্টেমে থাকে তবে মোট চ্যানেল ৩৩৩ টি)*।

২. (ii) ৭-সেল রিইউজ সিস্টেমে ($N = 7$) প্রতি সেলে চ্যানেল সংখ্যা:
• প্রতি সেলে মোট বরাদ্দ চ্যানেল = $\frac{\text{মোট চ্যানেল সংখ্যা}}{N} = \frac{333}{7} \approx \mathbf{47.57} \implies \mathbf{47}$ টি চ্যানেল (বা ভয়েস চ্যানেল নিলে $\frac{291}{7} \approx \mathbf{41}$ টি চ্যানেল)।

🇬🇧 English Exam Answer:
• 1. System Parameters:
  - Total Allocated Bandwidth = $20\text{ MHz} = 20,000\text{ kHz}$
  - Simplex Channel Bandwidth = $30\text{ kHz}$
  - Duplex Channel Bandwidth (Forward + Reverse link) = $30\text{ kHz} \times 2 = 60\text{ kHz}$
  - Reserved Control Channels = $42$ channels
  - Cluster Reuse Factor ($N$) = $7$

• 2. (i) Number of Duplex Voice Channels:
  - Total Available Duplex Channels:
    $$\text{Total Duplex Channels} = \left\lfloor \frac{20,000\text{ kHz}}{60\text{ kHz}} \right\rfloor = \mathbf{333}\text{ channels}$$
  - Number of Usable Duplex Voice Channels:
    $$\text{Voice Channels} = 333 - 42 = \mathbf{291}\text{ duplex voice channels}$$

• 3. (ii) Channels Available per Cell for 7-Cell Reuse Pattern ($N = 7$):
  - Total Channels per Cell:
    $$\text{Channels per Cell} = \left\lfloor \frac{333}{7} \right\rfloor = \mathbf{47}\text{ channels/cell}$$
  - Voice Channels per Cell:
    $$\text{Voice Channels per Cell} = \left\lfloor \frac{291}{7} \right\rfloor = \mathbf{41}\text{ voice channels/cell} \quad (\text{plus } 6\text{ control channels})$$"
                },

                // ── 80. SBL/JBL/BDBL 2023: TCP Congestion Control (AIMD) ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "SBL/JBL/BDBL (BIBM)", Post = "Senior Officer IT", 
                    QuestionText = "Explain TCP AIMD (Additive Increase Multiplicative Decrease) congestion control mechanism with graph.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
সহজ উপমা:
অন্ধকার রুমে আপনি দেয়াল স্পর্শ করার জন্য সাবধানে পা টিপে টিপে ১ কদম ১ কদম করে সামনে এগোচ্ছেন (Additive Increase)। হঠাৎ দেয়ালে ধাক্কা লাগলে (প্যাকেট লস) ভয়ে দ্রুত লাফ দিয়ে অর্ধেক দূরত্ব পেছনে চলে আসেন (Multiplicative Decrease)! 

TCP-র স্ট্যাবিলিটির মূল ভিত্তি AIMD:
১. **Additive Increase (লিনিয়ার বৃদ্ধি)**:
   - প্রতি রাউন্ড ট্রিপ টাইমে (RTT) যদি কোনো প্যাকেট লস না হয়, TCP তার কনজেশন উইন্ডো ($cwnd$) ধীরে ধীরে মাত্র ১টি MSS বাড়ায়:
     $$cwnd = cwnd + 1\text{ MSS}$$
   - এটি গ্রাফে সরলরেখার মতো খাড়া ঊর্ধ্বমুখী ঢাল তৈরি করে।
২. **Multiplicative Decrease (গুণোত্তর হ্রাস)**:
   - ট্রাফিকের ভিড়ে যখনই কোনো প্যাকেট ড্রপ হয় (3 Duplicate ACK বা Timeout), TCP বোঝে নেটওয়ার্কে জ্যাম লেগেছে। সে সাথে সাথে তার গতি এক নিমেষে অর্ধেক কেটে ফেলে:
     $$cwnd = \frac{cwnd}{2}$$
৩. গ্রাফের চেহারা:
   - এটি দেখতে করাত বা করাতের দাঁতের মতো (Sawtooth Pattern)। এর ফলেই ইন্টারনেটে শত শত ব্যবহারকারী সমানভাবে ও নিরাপদে ব্যান্ডউইডথ শেয়ার করতে পারে।

🇬🇧 English Exam Answer:
• 1. Principles of TCP AIMD:
  AIMD (Additive Increase Multiplicative Decrease) is the core closed-loop feedback congestion avoidance algorithm designed to maintain network stability and ensure fair bandwidth allocation across competitive TCP flows.

• 2. Mathematical State Transitions:
  1. **Additive Increase**:
     - Operates during the Congestion Avoidance phase when $cwnd \ge ssthresh$.
     - For every Round-Trip Time (RTT) completed without packet loss, the sender increases $cwnd$ by $1\text{ MSS}$ (Maximum Segment Size):
       $$cwnd \leftarrow cwnd + \frac{1}{cwnd} \quad (\text{per ACK}) \implies cwnd \leftarrow cwnd + 1\text{ MSS per RTT}$$
  2. **Multiplicative Decrease**:
     - Upon detecting packet loss (via triple duplicate ACKs or RTO timer expiry), TCP halves the congestion window and updates the slow start threshold ($ssthresh$):
       $$ssthresh \leftarrow \max\left(\frac{cwnd}{2}, 2\text{ MSS}\right), \quad cwnd \leftarrow \frac{cwnd}{2}\text{ (TCP Reno)}$$

• 3. Graphical Representation (The Sawtooth Curve):
```
 Congestion Window (cwnd)
      ▲
      │       /│      /│      /│
      │      / │     / │     / │
      │     /  │    /  │    /  │
      │    /   │   /   │   /   │   <── Multiplicative Decrease (halved)
      │   /    │  /    │  /    │
      │  /     │ /     │ /     │   <── Additive Increase (linear slope)
      └──┴─────┴─┴─────┴─┴─────┴─────► Time
```
• 4. Fairness and Stability:
  Chiu & Jain's mathematical vector analysis proves that AIMD converges asymptotically to the optimal operating point of maximum network efficiency and fair bandwidth sharing among concurrent flows."
                },

                // ── 81. SBL/JBL/BDBL 2023: HTTP Persistent vs Non-Persistent & Web Caching ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "SBL/JBL/BDBL (BIBM)", Post = "Senior Officer IT", 
                    QuestionText = "Compare persistent and non-persistent HTTP. How does Web Caching (Proxy Server) reduce response time and bandwidth usage?",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
১. Persistent বনাম Non-Persistent HTTP:
সহজ উপমা:
• **Non-Persistent (HTTP/1.0 - বারবার দোকানদারকে ফোন করা)**:
  - আপনি একটি ওয়েব পেজ লোড করছেন যেখানে লেখা ও ৩টি ছবি আছে (মোট ৪টি জিনিস)। Non-persistent নিয়মে লেখার জন্য একবার ফোন দিয়ে ৩-বার হাত মিলিয়ে (TCP handshake) লেখা আনা হয় এবং ফোন কেটে দেওয়া হয়। এরপর ১ম ছবির জন্য আবার নতুন করে ফোন, ৩-বার হাত মেলানো, ছবি আনা ও ফোন কাটা। এভাবে ৪ বার হ্যান্ডশেক করে প্রচুর সময় নষ্ট হয় (2 RTT per object)।
• **Persistent (HTTP/1.1 - একবার ফোন করে সব আনা)**:
  - একবার মাত্র TCP কানেকশন খুলে সেই একই পাইপলাইন দিয়ে লেখা এবং ৩টি ছবি একটানা সুপার ফাস্ট গতিতে এনে তারপর কানেকশন বন্ধ করা হয় (1 RTT per object)।

২. Web Caching (Proxy Server) কীভাবে গতি বাড়ায় ও ব্যান্ডউইডথ সাশ্রয় করে?
সহজ উপমা:
আপনার বাসার পাশের মুদি দোকানে প্রতিদিনের ডিম-দুধ মজুদ রাখা। 
ব্যাংকের প্রক্সি সার্ভার জনপ্রিয় ওয়েবসাইটগুলোর কপি নিজের লোকাল ডিস্কে সেভ রাখে। পরবর্তীতে কোনো কর্মী ওই পেজে ঢুকতে চাইলে আন্তর্জাতিক সাবমেরিন ক্যাবল পার হয়ে মূল সার্ভারে যেতে হয় না—লোকাল ল্যানের প্রক্সি সার্ভার থেকে পলকের মধ্যে (১ মিলি-সেকেন্ডে) পেজ ওপেন হয়ে যায়। ফলে মূল্যবান ইন্টারনেট ব্যান্ডউইডথ সাশ্রয় হয়।

🇬🇧 English Exam Answer:
• 1. Comparison: Persistent vs Non-Persistent HTTP:
| Criteria | Non-Persistent HTTP (HTTP/1.0) | Persistent HTTP (HTTP/1.1) |
| :--- | :--- | :--- |
| **TCP Connection Lifetime** | Single TCP connection per individual object; closed immediately upon delivery. | Single TCP connection remains open across multiple object requests. |
| **Round-Trip Time (RTT)** | $2\text{ RTT} + \text{Transfer Time}$ per object ($1\text{ RTT}$ setup $+ 1\text{ RTT}$ request). | $1\text{ RTT}$ per object (or pipelined concurrently in a single RTT). |
| **Server Overhead** | High OS overhead creating and destroying TCP buffers and sockets repeatedly. | Low server CPU and socket table memory consumption. |
| **Slow-Start Penalty** | Every request suffers from the initial TCP Slow-Start latency penalty. | TCP window ramps up once and sustains optimal throughput across transfers. |

• 2. Mechanisms of Web Caching (Proxy Server):
  1. **Substantial Latency Reduction**: Cached static assets (HTML, JS, CSS, images) are served directly across the high-speed LAN interface ($\le 1\text{ ms}$ response), bypassing WAN propagation delays.
  2. **Bandwidth Conservation & Cost Reduction**: Eliminates redundant downstream traffic across costly ISP WAN uplinks by serving multiple identical requests locally.
  3. **Origin Server Offloading**: Shields the origin web server from traffic surges and flash crowds by handling up to 70–80% of aggregate client request volume locally."
                },

                // ── 82. SBL/BDBL 2022: Subnetting 15.13.0.0/8 for 32 Subnets ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2022, ExamOrg = "SBL/BDBL", Post = "Senior Officer IT", 
                    QuestionText = "Network 15.13.0.0/8 (Class A). Create 32 subnets. Find: (i) Subnet mask (ii) Total IP/subnet (iii) Usable hosts/subnet (iv) Network & Broadcast of 1st and 32nd subnet.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা ও গাণিতিক সমাধান:
দেওয়া আছে: Class A নেটওয়ার্ক `15.0.0.0/8` (এখানে দেওয়া 15.13.0.0)।
আমাদের ৩২টি সমান সাবনেট তৈরি করতে হবে।

১. কয়টি সাবনেট বিট ধার করতে হবে?
ফর্মুলা: $2^s \ge 32 \implies s = \mathbf{5}$ বিট ধার করতে হবে।
মোট প্রিফিক্স = $8 + 5 = \mathbf{/13}$।
অবশিষ্ট হোস্ট বিট ($h$) = $32 - 13 = \mathbf{19}$ বিট।

২. (i) Subnet Mask নির্ণয়:
• প্রিফিক্স `/13` এর বাইনারি মাস্ক:
  `11111111.11111000.00000000.00000000` = **255.248.0.0**
• ২য় অক্টেটে ব্লক সাইজ (Magic Number) = $256 - 248 = \mathbf{8}$।

৩. (ii) প্রতি সাবনেটে মোট আইপি:
$$\text{Total IPs} = 2^h = 2^{19} = \mathbf{524,288}\text{ টি}$$

৪. (iii) প্রতি সাবনেটে ব্যবহারযোগ্য হোস্ট আইপি:
$$\text{Usable Hosts} = 2^{19} - 2 = 524,288 - 2 = \mathbf{524,286}\text{ টি}$$

৫. (iv) ১ম এবং ৩২তম সাবনেটের ঠিকানা:
• **1st Subnet (Index 0)**:
  - Network ID: **15.0.0.0**
  - First Usable: 15.0.0.1
  - Last Usable: 15.7.255.254
  - Broadcast ID: **15.7.255.255**
• **32nd Subnet (Index 31, ২য় অক্টেটে $31 \times 8 = 248$)**:
  - Network ID: **15.248.0.0**
  - First Usable: 15.248.0.1
  - Last Usable: 15.255.255.254
  - Broadcast ID: **15.255.255.255**

🇬🇧 English Exam Answer:
• Given: Class A Network Address `15.0.0.0/8`. Subnets Required: $N = 32$.
• Mathematical Derivation:
  - Subnet bits borrowed: $2^s \ge 32 \implies s = 5$ bits borrowed from the 2nd octet.
  - Remaining host bits: $h = 32 - 13 = 19$ bits.

• (i) Subnet Mask:
  - New CIDR Prefix = $/13$
  - Binary Mask = `11111111.11111000.00000000.00000000`
  - Dotted Decimal Mask = **255.248.0.0**
  - 2nd Octet Block Size Increment = $256 - 248 = 8$

• (ii) Total IP Addresses per Subnet:
  $$\text{Total Addresses} = 2^{19} = \mathbf{524,288}\text{ IPs}$$

• (iii) Usable Host Addresses per Subnet:
  $$\text{Usable Hosts} = 2^{19} - 2 = \mathbf{524,286}\text{ valid hosts}$$

• (iv) Addressing for 1st and 32nd Subnet:
| Subnet Order | Index | Network Address | Usable Host Range | Broadcast Address |
| :---: | :---: | :---: | :---: | :---: |
| **1st Subnet** | 0 ($0 \times 8$) | **15.0.0.0** | 15.0.0.1 – 15.7.255.254 | **15.7.255.255** |
| **32nd Subnet**| 31 ($31 \times 8$) | **15.248.0.0** | 15.248.0.1 – 15.255.255.254 | **15.255.255.255** |"
                },

                // ── 83. SBL/BDBL 2022: Serial Asynchronous Transmission Math ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2022, ExamOrg = "SBL/BDBL", Post = "Senior Officer IT", 
                    QuestionText = "Serial asynchronous transmission at 9600 baud. Each character has 1 start bit, 8 data bits, 1 parity bit, and 2 stop bits. Compute: (i) Total bits per character (ii) Number of characters transmitted per second (iii) Effective data rate in bps.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা ও গাণিতিক সমাধান:
দেওয়া আছে:
• Baud Rate = ৯৬০০ (বাইনারি সিস্টেমে ১ বড = ১ বিট/সেকেন্ড $\implies 9600\text{ bps}$)।
• প্রতি ক্যারেক্টারের কাঠামো:
  - ১টি Start Bit
  - ৮টি Data Bits
  - ১টি Parity Bit
  - ২টি Stop Bits

১. (i) প্রতি ক্যারেক্টারে মোট বিট সংখ্যা:
$$\text{Total Bits} = 1 + 8 + 1 + 2 = \mathbf{12\text{ bits/character}}$$

২. (ii) প্রতি সেকেন্ডে প্রেরিত ক্যারেক্টারের সংখ্যা:
$$\text{Characters per Second} = \frac{\text{Baud Rate (Gross Bit Rate)}}{\text{Total Bits per Character}} = \frac{9600}{12} = \mathbf{800\text{ characters/second}}$$

৩. (iii) কার্যকর ডেটা রেট (Effective Data Rate / Pure Payload):
• কার্যকর ডেটা কেবল ৮টি মূল ডাটা বিট থেকে আসে (বাকি ৪ বিট হলো ওভারহেড):
$$\text{Effective Data Rate} = 800\text{ characters/sec} \times 8\text{ data bits} = \mathbf{6400\text{ bps}}$$
*(এফিসিয়েন্সি = $\frac{6400}{9600} = 66.67\%$)*।

🇬🇧 English Exam Answer:
• 1. Given Parameters:
  - Signaling Rate = $9600\text{ Baud}$ (equivalent to $9600\text{ bps}$ for binary line coding).
  - Character Frame = $1\text{ Start bit} + 8\text{ Data bits} + 1\text{ Parity bit} + 2\text{ Stop bits}$.

• 2. Mathematical Computations:
  - **(i) Total Bits per Character**:
    $$\text{Total Bits} = 1 + 8 + 1 + 2 = \mathbf{12\text{ bits/character}}$$
  - **(ii) Number of Characters Transmitted per Second**:
    $$\text{Throughput} = \frac{\text{Transmission Line Speed (bps)}}{\text{Bits per Character Frame}} = \frac{9600\text{ bps}}{12\text{ bits/char}} = \mathbf{800\text{ characters/sec}}$$
  - **(iii) Effective Data Rate (Net Payload Throughput)**:
    $$\text{Effective Bit Rate} = 800\text{ characters/sec} \times 8\text{ information data bits} = \mathbf{6400\text{ bps (6.4 kbps)}}$$
  - *Channel Efficiency Ratio*: $\frac{8\text{ data bits}}{12\text{ total bits}} \times 100\% = 66.67\%$, with $33.33\%$ framing overhead."
                },

                // ── 84. SBL/BDBL 2022: Stop-and-Wait ARQ ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2022, ExamOrg = "SBL/BDBL", Post = "Senior Officer IT", 
                    QuestionText = "How is Stop-and-Wait ARQ used for reliable data transfer?",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
সহজ উপমা:
এক ভদ্রলোক কাউকে চিঠি পাঠাচ্ছেন। তিনি ১টি চিঠি ডাকবাক্সে ফেলে চেয়ারে বসে অপেক্ষা করেন। অপর প্রান্ত থেকে প্রাপকের 'চিঠি পেয়েছি' স্লিপ (ACK) না আসা পর্যন্ত তিনি ২য় চিঠি স্পর্শও করবেন না!

Stop-and-Wait ARQ (Automatic Repeat reQuest) যেভাবে কাজ করে:
১. **প্রেরণ ও টাইমার চালু (Send & Timer)**:
   - সেন্ডার ১টি ফ্রেম পাঠায় এবং সাথে সাথে একটি ঘড়ি (Retransmission Timer) চালু করে।
২. **স্বীকৃতি পেলে পরবর্তী ফ্রেম (ACK Received)**:
   - রিসিভার ফ্রেমটি নির্ভুল পেলে একটি **ACK** পাঠায়। ACK পেলেই কেবল সেন্ডার পরবর্তী ফ্রেম পাঠায়।
৩. **টাইমআউট হলে রিট্রান্সমিশন (Timeout & Resend)**:
   - যদি তারের মাঝে ফ্রেম নষ্ট হয়ে যায় বা হারিয়ে যায়, রিসিভার কোনো ACK পাঠায় না। সেন্ডারের ঘড়ির সময় শেষ (Timeout) হয়ে গেলে সেন্ডার স্বয়ংক্রিয়ভাবে আগের একই ফ্রেম পুনরায় পাঠিয়ে দেয়।
৪. **ডুপ্লিকেট প্রতিরোধে অল্টারনেট বিট ($0$ এবং $1$)**:
   - ফ্রেমের গায়ে অল্টারনেট করে $0$ এবং $1$ নম্বর বসানো থাকে, যাতে একই ফ্রেম দুইবার চলে গেলে রিসিভার ডুপ্লিকেট ফেলে দিতে পারে।

🇬🇧 English Exam Answer:
• 1. Operational Logic of Stop-and-Wait ARQ:
  Stop-and-Wait ARQ is a fundamental Data Link / Transport layer flow and error control protocol that guarantees strictly ordered, loss-free data transmission over unreliable physical links using 1-bit sequence numbers (0 and 1) and positive acknowledgments.

• 2. Protocol Workflow:
```
   Sender                                  Receiver
     │─────── Frame 0 (Start Timer) ───────>│
     │<────────── ACK 1 ────────────────────│ (Frame 0 OK)
     │─────── Frame 1 (Start Timer) ───────>│
     │                 X (Frame Lost)       │
     │ (Timer Expires: Timeout!)            │
     │─────── Frame 1 Retransmitted ───────>│
     │<────────── ACK 0 ────────────────────│
```
  1. **Transmission**: Sender transmits Frame $S_n$ and starts an internal Retransmission Timer.
  2. **Wait State**: Sender buffers the transmitted frame and halts further transmission until an acknowledgment arrives.
  3. **Positive ACK**: Upon uncorrupted receipt, receiver returns an ACK specifying the next expected sequence number ($S_{n+1}$).
  4. **Timeout Retransmission**: If an ACK is not received prior to timer expiration (due to frame loss, corruption, or lost ACK), the sender automatically retransmits Frame $S_n$.
  5. **Duplicate Discarding**: Sequence numbering prevents duplicate acceptance at the receiver if an ACK was delayed."
                },

                // ── 85. ANE RBL 2021: 5G Network Disadvantages ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2021, ExamOrg = "ANE RBL", Post = "Assistant Network Engineer", 
                    QuestionText = "Write about 5G disadvantages: (i) Initial cost (ii) Battery drainage.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
১. **(i) Initial Cost (বিপুল প্রাথমিক পরিকাঠামো খরচ)**:
   - সহজ উপমা: 4G এর একটি বড় টাওয়ারের সিগন্যাল ৫-১০ কিলোমিটার পর্যন্ত চলে যায়। কিন্তু 5G এর আল্ট্রা-স্পিড মিলিমিটার ওয়েভ (mmWave) ফ্রিকোয়েন্সি এত বেশি যে তা ২০০ মিটারের বেশি যেতে পারে না এবং দেয়াল, বৃষ্টি বা গাছের পাতা ভেদ করতে পারে না!
   - ফলে পুরো শহর কভার করতে প্রতি ১০০-২০০ মিটারে ল্যাম্পপোস্টে ল্যাম্পপোস্টে লাখ লাখ **Small Cell** টাওয়ার বসাতে হয় এবং প্রতিটি টাওয়ারে ফাইবার অপটিক ক্যাবল টানতে টেলিকম কোম্পানিগুলোর হাজার হাজার কোটি টাকা খরচ হয়।

২. **(ii) Battery Drainage (স্মার্টফোনের দ্রুত ব্যাটারি শেষ হওয়া)**:
   - সহজ উপমা: একটি সাধারণ ফ্যান চালানোর চেয়ে একসাথে ৮টি এয়ারকন্ডিশনার চালালে বিদ্যুতের মিটার যেমন বনবন করে ঘোরে!
   - 5G ফোনে একসাথে অনেকগুলো অ্যান্টেনা (Massive MIMO) সারাক্ষণ একাধিক ফ্রিকোয়েন্সি ট্র্যাক করে এবং গিগাবিট স্পিডে প্রসেসর দিয়ে ডাটা ডিকোড করে। ফলে ফোন দ্রুত গরম হয় এবং চোখের পলকে ব্যাটারির চার্জ শেষ হয়ে যায়।

🇬🇧 English Exam Answer:
• 1. (i) High Initial Infrastructure and Deployment Costs:
  - **Propagation Physics of mmWave**: High-frequency 5G spectrum (FR2 millimeter waves: 24 GHz to 40 GHz) suffers from severe atmospheric attenuation, high path loss, and near-zero penetration through building walls and foliage.
  - **Extreme Small Cell Densification**: Overcoming limited propagation radius requires dense deployment of microcells/pico-cells every 100 to 250 meters.
  - **Massive Capital Expenditure (CapEx)**: Telecom operators must install millions of new Small Cell base stations and upgrade entire municipal backhauls with ultra-high-capacity fiber-optic cables and standalone (5G SA) cloud-native cores.

• 2. (ii) Increased Battery Drainage on End-User Devices:
  - **Complex RF Front-End**: 5G smart devices incorporate multi-element antenna arrays supporting Massive MIMO and beamforming, consuming substantial power during continuous beam tracking.
  - **Dual Connectivity Overhead**: In early Non-Standalone (5G NSA) deployments, the smartphone must maintain concurrent active radio connections to both a 4G LTE anchor cell and a 5G data channel.
  - **Intense Thermal & Baseband Processing**: Decoding multi-gigabit data streams drastically increases CPU and baseband DSP clock cycles, accelerating battery discharge."
                },

                // ── 86. ANE RBL 2021: VLSM Subnetting for 4000, 2000, 4000, 8000 Hosts ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2021, ExamOrg = "ANE RBL", Post = "Assistant Network Engineer", 
                    QuestionText = "Given IP 172.16.0.0, create 4 subnets with 4000, 2000, 4000 and 8000 hosts. Find subnet mask, first IP, last IP, and broadcast address of all 4 subnets.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Step-by-Step VLSM):
স্বর্ণালী নিয়ম (Golden Rule):
VLSM সমাধান করার সময় সব সময় **সবচেয়ে বড় চাহিদা থেকে ছোট চাহিদার ক্রমানুসারে (Descending Order)** সাজাতে হয়!
চাহিদার ক্রম: **৮০০০ হোস্ট $\rightarrow$ ৪০০০ হোস্ট $\rightarrow$ ৪০০০ হোস্ট $\rightarrow$ ২০০০ হোস্ট**।
বেস আইপি: `172.16.0.0`।

১. সাবনেট ১ (৮০০০ হোস্টের জন্য):
• ফর্মুলা: $2^h - 2 \ge 8000 \implies 2^{13} - 2 = 8190 \implies h = 13$ হোস্ট বিট।
• প্রিফিক্স = $32 - 13 = \mathbf{/19}$ (মাস্ক: **255.255.224.0**, ৩য় অক্টেটে ব্লক সাইজ ৩২)।
• নেটওয়ার্ক আইপি: **172.16.0.0/19**
• ১ম ব্যবহারযোগ্য: **172.16.0.1** | শেষ ব্যবহারযোগ্য: **172.16.31.254** | ব্রডকাস্ট: **172.16.31.255**

২. সাবনেট ২ (৪০০০ হোস্টের জন্য):
• পরবর্তী শুরু আইপি = `172.16.32.0`।
• ফর্মুলা: $2^{12} - 2 = 4094 \ge 4000 \implies h = 12$ হোস্ট বিট।
• প্রিফিক্স = $32 - 12 = \mathbf{/20}$ (মাস্ক: **255.255.240.0**, ৩য় অক্টেটে ব্লক সাইজ ১৬)।
• নেটওয়ার্ক আইপি: **172.16.32.0/20**
• ১ম ব্যবহারযোগ্য: **172.16.32.1** | শেষ ব্যবহারযোগ্য: **172.16.47.254** | ব্রডকাস্ট: **172.16.47.255**

৩. সাবনেট ৩ (৪০০০ হোস্টের জন্য):
• পরবর্তী শুরু আইপি = `172.16.48.0`।
• প্রিফিক্স = $\mathbf{/20}$ (মাস্ক: **255.255.240.0**, ব্লক সাইজ ১৬)।
• নেটওয়ার্ক আইপি: **172.16.48.0/20**
• ১ম ব্যবহারযোগ্য: **172.16.48.1** | শেষ ব্যবহারযোগ্য: **172.16.63.254** | ব্রডকাস্ট: **172.16.63.255**

৪. সাবনেট ৪ (২০০০ হোস্টের জন্য):
• পরবর্তী শুরু আইপি = `172.16.64.0`।
• ফর্মুলা: $2^{11} - 2 = 2046 \ge 2000 \implies h = 11$ হোস্ট বিট।
• প্রিফিক্স = $32 - 11 = \mathbf{/21}$ (মাস্ক: **255.255.248.0**, ৩য় অক্টেটে ব্লক সাইজ ৮)।
• নেটওয়ার্ক আইপি: **172.16.64.0/21**
• ১ম ব্যবহারযোগ্য: **172.16.64.1** | শেষ ব্যবহারযোগ্য: **172.16.71.254** | ব্রডকাস্ট: **172.16.71.255**

🇬🇧 English Exam Answer:
• Base Network: `172.16.0.0`. Allocation sorted in descending host requirements:
  $$8000 \text{ hosts} \longrightarrow 4000 \text{ hosts} \longrightarrow 4000 \text{ hosts} \longrightarrow 2000 \text{ hosts}$$

• Comprehensive VLSM Allocation Table:
| Subnet Order | Required Hosts | Host Bits ($h$) | Assigned Prefix | Subnet Mask | Network Address | Usable Host Range | Broadcast Address |
| :--- | :---: | :---: | :---: | :---: | :--- | :--- | :--- |
| **Subnet 1** | 8000 | 13 ($2^{13}-2=8190$) | **/19** | `255.255.224.0` | **172.16.0.0** | 172.16.0.1 – 172.16.31.254 | **172.16.31.255** |
| **Subnet 2** | 4000 | 12 ($2^{12}-2=4094$) | **/20** | `255.255.240.0` | **172.16.32.0** | 172.16.32.1 – 172.16.47.254 | **172.16.47.255** |
| **Subnet 3** | 4000 | 12 ($2^{12}-2=4094$) | **/20** | `255.255.240.0` | **172.16.48.0** | 172.16.48.1 – 172.16.63.254 | **172.16.63.255** |
| **Subnet 4** | 2000 | 11 ($2^{11}-2=2046$) | **/21** | `255.255.248.0` | **172.16.64.0** | 172.16.64.1 – 172.16.71.254 | **172.16.71.255** |"
                },

                // ── 87. Security Printing 2021: Line Coding Techniques ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2021, ExamOrg = "Security Printing Corp Bangladesh", Post = "Assistant Maintenance Engineer", 
                    QuestionText = "Define the line coding techniques and mention their categories.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
১. Line Coding কী?
সহজ উপমা:
কম্পিউটার ভেতরে ডাটা চেনে শুধুই 0 এবং 1। কিন্তু ফিজিক্যাল তামার তারের মধ্য দিয়ে 0 এবং 1 সরাসরি হেঁটে যেতে পারে না! তারের মধ্য দিয়ে পাঠানোর জন্য 0 এবং 1 কে নির্দিষ্ট ভোল্টেজের স্পন্দন বা পালসে (যেমন: +5V, -5V, 0V) রূপান্তর করতে হয়। ডিজিটাল বিটকে ফিজিক্যাল তারে চলার উপযোগী ডিজিটাল সিগন্যালে রূপান্তর করার এই প্রক্রিয়াকেই বলে **Line Coding**।

২. প্রধান ৪টি ক্যাটাগরি ও তাদের স্কিম:
১. **Unipolar (একমুখী)**:
   - শুধুমাত্র ১টি পোলারিটি ভোল্টেজ ব্যবহার করে (যেমন: 1 হলে +5V, আর 0 হলে 0V)। উদাহরণ: NRZ (Non-Return to Zero)।
২. **Polar (দ্বিমুখী)**:
   - পজিটিভ ও নেগেটিভ উভয় ভোল্টেজ ব্যবহার করে।
   - স্কিমসমূহ: NRZ-L (লেভেল), NRZ-I (ইনভার্ট), RZ (Return to Zero), **Manchester** (প্রতিটি বিটের মাঝখানে ট্রানজিশন থাকে, ইথারনেটে ব্যবহৃত) এবং Differential Manchester।
৩. **Bipolar (বহুমুখী)**:
   - তিনটি ভোল্টেজ লেভেল (+V, 0V, -V) ব্যবহার করে।
   - স্কিম: AMI (Alternate Mark Inversion - পরপর আসা 1 গুলো অল্টারনেট পজিটিভ ও নেগেটিভ ভোল্টেজ নেয়) এবং Pseudoternary।
৪. **Multilevel / Multi-transition**:
   - একাধিক বিটকে এক ভোল্টেজ স্তরে প্রকাশ করে (যেমন: 2B1Q, 8B6T, MLT-3)।

🇬🇧 English Exam Answer:
• 1. Definition of Line Coding:
  Line Coding is the physical layer process of converting a digital binary bitstream ($0\text{s}$ and $1\text{s}$) into a discrete baseband digital signal (a sequence of voltage pulses) optimized for transmission across a physical transmission medium.

• 2. Taxonomy and Categories of Line Coding Techniques:
```
                         Line Coding Schemes
         ┌───────────────┼───────────────┬───────────────┐
      Unipolar         Polar          Bipolar        Multilevel
         │           ┌───┴───┐           │               │
        NRZ        NRZ      RZ          AMI            2B1Q
                 (L & I)     │      Pseudoternary     MLT-3
                         Manchester
```
  1. **Unipolar Scheme**:
     - Uses only a single non-zero voltage level and zero voltage (e.g., Unipolar NRZ). High DC component; poor synchronization.
  2. **Polar Schemes**:
     - Utilizes two symmetric non-zero voltage levels (positive and negative):
       * **NRZ-L (Non-Return to Zero-Level)**: Voltage depends on the bit value.
       * **NRZ-I (Non-Return to Zero-Invert)**: Inversion occurs if bit is 1.
       * **RZ (Return to Zero)**: Signal drops to zero volts halfway through the bit interval.
       * **Manchester Encoding**: Mid-bit transition ($Low \rightarrow High$ for 1, $High \rightarrow Low$ for 0); provides built-in clock synchronization (Standard Ethernet IEEE 802.3).
  3. **Bipolar Schemes (Multilevel Binary)**:
     - Uses three voltage levels ($+V, 0, -V$):
       * **AMI (Alternate Mark Inversion)**: Binary 0 is represented by zero voltage; binary 1s alternate between positive and negative voltages, eliminating the DC component.
  4. **Multi-transition Schemes**:
     - Advances bandwidth efficiency (e.g., MLT-3 used in Fast Ethernet 100BASE-TX)."
                },

                // ── 88. BSCA Sonali Bank 2021: TCP 3-Way Handshake ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2021, ExamOrg = "BSCA Sonali Bank", Post = "Officer IT", 
                    QuestionText = "Explain Three-Way Handshaking in TCP Protocol.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
সহজ উপমা:
দুজন মানুষের অত্যন্ত ভদ্র ও আনুষ্ঠানিক টেলিফোন আলাপের কথা ভাবুন:
১. **ধাপ ১ (SYN)**: ক্লায়েন্ট ফোন করে বলল—'হ্যালো সোনালী ব্যাংক! আমি আপনার সাথে একটি অ্যাকাউন্ট ট্রানজাকশন কানেকশন শুরু করতে চাই। আমার প্রারম্ভিক কোড নম্বর $X$ (SYN)'।
২. **ধাপ ২ (SYN + ACK)**: ব্যাংক রিসিভ করে বলল—'হ্যাঁ ক্লায়েন্ট, আমি আপনার $X$ নম্বর কোড পেয়েছি, তাই পরবর্তী $X+1$ স্বীকার করছি (ACK)। আমিও আপনার সাথে কথা বলতে চাই এবং আমার নিজের প্রারম্ভিক কোড নম্বর $Y$ (SYN)'।
৩. **ধাপ ৩ (ACK)**: ক্লায়েন্ট উত্তর দিল—'ধন্যবাদ ব্যাংক, আমি আপনার কোড $Y$ পেয়েছি এবং পরবর্তী $Y+1$ কনফার্ম করছি (ACK)। আমাদের হ্যান্ডশেক সম্পন্ন, এখন টাকা ট্রান্সফারের মূল ডাটা লেনদেন শুরু করা যাক!'

🇬🇧 English Exam Answer:
• 1. Purpose of the TCP 3-Way Handshake:
  The Three-Way Handshake establishes a reliable, bidirectional, full-duplex virtual connection between a client and server before application payload transfer begins. It synchronizes Initial Sequence Numbers (ISNs) and allocates buffer resources.

• 2. Sequence of Events and Packet Flow:
```
Client (Port 51234)                               Server (Port 443/80)
   │                                                     │
   │─── 1. SYN [Seq = x] ───────────────────────────────>│ (State: SYN-RCVD)
   │    (Client initiates connection)                    │
   │                                                     │
   │<── 2. SYN-ACK [Seq = y, Ack = x + 1] ───────────────│
   │    (Server acknowledges client & sends its ISN)     │
   │                                                     │
   │─── 3. ACK [Seq = x + 1, Ack = y + 1] ──────────────>│
   │    (Client confirms server ISN)                     │
   ▼                                                     ▼
(ESTABLISHED)                                      (ESTABLISHED)
```
  - **Step 1: SYN (Synchronize)**:
    Client generates a randomized Initial Sequence Number ($Seq = x$), sets the `SYN` control flag in the TCP header, and sends the segment. Client enters `SYN-SENT` state.
  - **Step 2: SYN-ACK (Synchronize-Acknowledgment)**:
    Server accepts connection, generates its own independent random ISN ($Seq = y$), sets the `SYN` and `ACK` flags, and acknowledges the client by setting $Ack = x + 1$. Server enters `SYN-RCVD` state.
  - **Step 3: ACK (Acknowledgment)**:
    Client confirms the server's sequence number by replying with an `ACK` packet containing $Seq = x + 1$ and $Ack = y + 1$. Connection transitions to `ESTABLISHED` on both sides."
                },

                // ── 89. AHE 2021: Subnetting 105.38.89.234/20 Analysis ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2021, ExamOrg = "AHE SBL/JBL/RBL", Post = "Assistant Hardware Engineer", 
                    QuestionText = "IP address 105.38.89.234/20: (i) Network ID and host ID? (ii) Network address and broadcast address? (iii) Size of the network? (iv) Class if classful addressing used?",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা ও স্টেপ-বাই-স্টেপ সমাধান:
দেওয়া আছে IP: `105.38.89.234/20`
প্রিফিক্স `/20` মানে প্রথম ২০টি বিট '1' এবং বাকি ১২টি বিট '0'।
• সাবনেট মাস্ক: `11111111.11111111.11110000.00000000` = **255.255.240.0**
• ৩য় অক্টেটে ব্লক সাইজ (Magic Number) = $256 - 240 = \mathbf{16}$।

১. নেটওয়ার্ক বাউন্ডারি বের করার হিসাব:
• ৩য় অক্টেটে আইপি মান হলো ৮৯।
• ১৬ এর গুণিতকগুলো: $0, 16, 32, 48, 64, \mathbf{80}, 96$।
• সুতরাং ৮৯ সংখ্যাটি **৮০ থেকে ৯৫** ব্লকের ভেতরে অবস্থিত!
• (ii) Network Address = **105.38.80.0**
• (ii) Broadcast Address = **105.38.95.255**
• (i) Network ID অংশ = **105.38.80.0/20** | Host ID অংশ = **0.0.9.234** (যেহেতু $89 - 80 = 9$)

২. (iii) Size of the network (নেটওয়ার্কের আকার):
• হোস্ট বিট সংখ্যা ($h$) = $32 - 20 = 12$ টি বিট।
• মোট আইপি সংখ্যা = $2^{12} = \mathbf{4096}$ টি addresses।
• ব্যবহারযোগ্য হোস্ট সংখ্যা = $4096 - 2 = \mathbf{4094}$ টি hosts।

৩. (iv) Classful নিয়ম অনুযায়ী এটি কোন ক্লাসের?
• প্রথম অক্টেট হলো **১০৫**।
• যেহেতু Class A এর রেঞ্জ ১ থেকে ১২৬, তাই Classful এড্রেসিং অনুযায়ী এটি **Class A** আইপি।

🇬🇧 English Exam Answer:
• Given: IP Address `105.38.89.234` with prefix `/20`.
• Subnet Mask = `255.255.240.0` (Binary: `11111111.11111111.11110000.00000000`).
• Block Size in 3rd Octet = $256 - 240 = 16$.
• Since $89 \div 16 = 5$ with remainder $9$, the 3rd octet base is $5 \times 16 = 80$.

• Exact Numerical Answers:
  1. **(i) Network ID and Host ID**:
     - Network ID = **105.38.80.0/20**
     - Host ID portion = **0.0.9.234**
  2. **(ii) Network Address and Broadcast Address**:
     - Network Address = **105.38.80.0**
     - Broadcast Address = **105.38.95.255** (Valid host range: 105.38.80.1 to 105.38.95.254)
  3. **(iii) Size of the Network**:
     - Host bits ($h$) = $32 - 20 = 12$ bits.
     - Total IP Addresses = $2^{12} = \mathbf{4096}\text{ addresses}$ ($\mathbf{4094}\text{ usable hosts}$).
  4. **(iv) Class under Classful Addressing Architecture**:
     - The first octet value is $105$, which falls strictly within the range $1 \le \text{Octet}_1 \le 126$.
     - Therefore, it belongs to **Class A**."
                },

                // ── 90. Combined 2 Bank 2020: PCM Digitization Math (300 - 3400 Hz) ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2020, ExamOrg = "Combined Bank Officer IT (SB&JB)", Post = "Officer IT", 
                    QuestionText = "A signal has a frequency range of 300 Hz to 3400 Hz. A PCM system is used to digitize it. Max quantization error ±1% of full scale, voltage −1 V to +1 V. Determine (i) number of bits per sample (n) and (ii) bit rate of the PCM system.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept & Step-by-Step Math):
সহজ উপমা:
মানুষের কণ্ঠস্বরের এনালগ সিগন্যালকে ডিজিটাল কম্পিউটারে ঢোকানোর আন্তর্জাতিক পদ্ধতি (Pulse Code Modulation - PCM)।

দেওয়া আছে:
• ফ্রিকোয়েন্সি রেঞ্জ = ৩০০ Hz থেকে ৩৪০০ Hz ($f_{max} = 3400\text{ Hz}$)।
• ফুল স্কেল ভোল্টেজ = $-1\text{ V}$ থেকে $+1\text{ V} \implies \text{Full Scale Voltage Range } (V_{pp}) = 1 - (-1) = \mathbf{2\text{ V}}$।
• সর্বোচ্চ কোয়ান্টাইজেশন এরর ($Q_e$) = ফুল স্কেলের $\pm 1\% = 0.01$।

১. (i) প্রতি স্যাম্পলে বিট সংখ্যা ($n$) নির্ণয়:
• স্টেপ সাইজ $\Delta = \frac{V_{pp}}{L} = \frac{2}{L}$ (যেখানে $L$ হলো কোয়ান্টাইজেশন লেভেল)।
• ফর্মুলা: সর্বোচ্চ কোয়ান্টাইজেশন এরর $Q_e = \frac{\Delta}{2} \le 1\% \times V_{pp}$
  $$\frac{\Delta}{2} \le 0.01 \times 2 \implies \Delta \le 0.04\text{ V}$$
• লেভেল সংখ্যা $L$:
  $$\frac{2}{L} \le 0.04 \implies L \ge \frac{2}{0.04} = 50 \implies L \ge 50\text{ levels}$$
  *(বা $Q_e \le 1\% \text{ of } \Delta$ হিসেবে ধরলে $L \ge 100$ লেভেল)*।
• বিট সংখ্যা ($n$):
  $$n = \lceil \log_2(50) \rceil \implies \mathbf{6\text{ bits/sample}} \quad (\text{যদি } L \ge 100 \text{ ধরা হয় তবে } n = \lceil \log_2(100) \rceil = \mathbf{7\text{ bits/sample}})$$
  *পরীক্ষায় স্ট্যান্ডার্ড উত্তর: **$n = 7\text{ bits/sample}$** (টেলিফোনে ৮ বিট)।*

২. (ii) PCM সিস্টেমের বিট রেট ($R$) নির্ণয়:
• Nyquist থিওরেম অনুযায়ী স্যাম্পলিং রেট ($f_s$):
  $$f_s = 2 \times f_{max} = 2 \times 3400 = \mathbf{6800\text{ samples/second}}$$
• Bit Rate ($R$):
  $$R = f_s \times n = 6800 \times 7 = \mathbf{47,600\text{ bps}} = \mathbf{47.6\text{ kbps}}$$
  *(টেলিফোন স্ট্যান্ডার্ড স্যাম্পলিং ৮০০০ স্যাম্পল/সে ধরলে: $R = 8000 \times 7 = \mathbf{56\text{ kbps}}$ বা $8000 \times 8 = 64\text{ kbps}$)*।

🇬🇧 English Exam Answer:
• 1. Given Parameters:
  - Bandwidth: $f_{min} = 300\text{ Hz}$, $f_{max} = 3400\text{ Hz}$
  - Peak-to-Peak Voltage ($V_{pp}$): From $-1\text{ V}$ to $+1\text{ V} \implies V_{pp} = 2\text{ V}$
  - Maximum Quantization Error ($Q_e$): $\le \pm 1\%$ of full-scale range $= 0.01 \times 2\text{ V} = 0.02\text{ V}$

• 2. (i) Number of Bits per Sample ($n$):
  - Maximum quantization error relation:
    $$Q_e = \frac{\Delta}{2} \le 0.02\text{ V} \implies \Delta \le 0.04\text{ V}$$
  - Step size with $L$ quantization levels:
    $$\Delta = \frac{V_{pp}}{L} = \frac{2}{L} \le 0.04 \implies L \ge \frac{2}{0.04} = 50$$
  - If error is relative to full dynamic range peak-to-peak:
    $$L \ge \frac{1}{2 \times 0.01} = 50 \implies n = \lceil \log_2(50) \rceil = 6\text{ bits}$$
  - Under symmetric percent quantization threshold ($\frac{\Delta}{2} \le \frac{1}{100} \implies L \ge 100$):
    $$n = \lceil \log_2(100) \rceil = \mathbf{7\text{ bits/sample}}$$

• 3. (ii) Bit Rate ($R$) of the PCM System:
  - Nyquist Minimum Sampling Rate ($f_s$):
    $$f_s = 2 \times f_{max} = 2 \times 3400\text{ Hz} = \mathbf{6800\text{ samples/sec}}$$
  - PCM Bit Rate ($R$):
    $$R = f_s \times n = 6800\text{ samples/sec} \times 7\text{ bits/sample} = \mathbf{47.6\text{ kbps}}$$
  *(Note: Standard commercial telephony samples at $8000\text{ samples/sec}$, yielding $R = 8000 \times 7 = 56\text{ kbps}$ or $8000 \times 8 = 64\text{ kbps}$).* "
                },

                // ── 91. BSCS 2020: RFID Working Principle & LTE Network Elements ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2020, ExamOrg = "BSCS Combined 2 Bank (SB&JB)", Post = "Officer IT", 
                    QuestionText = "RFID working principle in brief. List of LTE Network elements.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept):
১. RFID (Radio Frequency Identification) কীভাবে কাজ করে?
সহজ উপমা:
পদ্মা সেতুর টোল প্লাজার ফাস্ট-ট্র্যাক লেন বা ব্যাংকের কর্মীর আইডি কার্ডের পাঞ্চ।
• RFID সিস্টেমে ২টি জিনিস থাকে:
  ১. **RFID Tag (ট্যাগ)**: গাড়ির কাঁচে বা আইডি কার্ডে থাকা ছোট্ট একটি মাইক্রোচিপ ও অ্যান্টেনা কয়েল। এতে কোনো ব্যাটারি থাকে না (Passive Tag)!
  ২. **RFID Reader (রিডার)**: গেটে থাকা স্ক্যানার যা প্রতিনিয়ত রেডিও তরঙ্গ ছড়ায়।
• **ম্যাজিক কার্যপ্রণালী**: রিডারের রেডিও তরঙ্গ যখন ট্যাগের কয়েলে আঘাত হানে, তড়িৎ-চৌম্বক আবেশের (Electromagnetic Induction) মাধ্যমে বাতাসে থাকা রেডিও তরঙ্গ থেকে ট্যাগটি নিজে বিদ্যুৎ তৈরি করে জেগে ওঠে! চিপটি চার্জ পেয়ে সাথে সাথে তার মেমরিতে থাকা গোপন আইডি কোড রেডিও তরঙ্গে ব্যাক-স্ক্যাটার করে রিডারের কাছে পাঠিয়ে দেয়।

২. LTE (4G) মোবাইল নেটওয়ার্কের মূল ৫টি উপাদান:
• **eNodeB (Evolved Node B)**: আমাদের দেখা মোবাইল টাওয়ার—যা স্মার্টফোনের সাথে সরাসরি 4G রেডিও সিগন্যালে যুক্ত হয়।
• **MME (Mobility Management Entity)**: কন্ট্রোল রুম—ইউজার এক টাওয়ার থেকে অন্য টাওয়ারে গেলে হ্যান্ডওভার, সিকিউরিটি অথেনটিকেশন ও পেজিং নিয়ন্ত্রণ করে।
• **SGW (Serving Gateway)**: লোকাল রাউটার—ইউজারের ইন্টারনেট ডাটা প্যাকেট এক টাওয়ার থেকে অন্য টাওয়ারে রাউট করে।
• **PGW (PDN Gateway)**: ইন্টারনেট গেটওয়ে—স্মার্টফোনকে মূল ইন্টারনেট ও গুগল/ফেসবুকের সাথে যুক্ত করে আইপি বরাদ্দ দেয়।
• **HSS (Home Subscriber Server)**: সেন্ট্রাল ডাটাবেস—সিমের প্রোফাইল, ফোন নম্বর ও রোমিং তথ্য জমা রাখে।

🇬🇧 English Exam Answer:
• 1. Working Principle of RFID (Radio Frequency Identification):
  - An RFID system comprises an **RFID Tag** (microchip bonded to an antenna) and an **RFID Interrogator/Reader**.
  - **Operating Mechanism (Passive RFID)**:
    1. The RFID reader continuously emits electromagnetic radio frequency waves via its antenna.
    2. When a passive tag enters the RF field, the tag's antenna coil harvests energy via **Electromagnetic Induction (Near-field)** or **Radiative Backscatter (Far-field)**, powering up the integrated circuit without an internal battery.
    3. The microchip modulates its stored unique Electronic Product Code (EPC) onto the reflected RF carrier wave back to the reader.
    4. The reader demodulates, decodes the bitstream, and relays the asset ID to enterprise backend databases.

• 2. Architectural Elements of LTE (Long Term Evolution - 4G E-UTRAN and EPC):
  1. **eNodeB (Evolved Node B)**: LTE radio access base station managing radio resource management, ciphering, and air-interface transmission directly with User Equipment (UE).
  2. **MME (Mobility Management Entity)**: The core signaling and control-plane node responsible for UE authentication, tracking area management, bearer setup, and roaming.
  3. **SGW (Serving Gateway)**: The local data-plane anchor that routes and forwards user data packets between the eNodeB and the core network.
  4. **PGW (Packet Data Network Gateway)**: The perimeter anchor node providing connectivity between the mobile LTE core and external packet data networks (Internet); handles IP allocation, QoS enforcement, and deep packet inspection.
  5. **HSS (Home Subscriber Server)**: A centralized master subscriber database storing user SIM credentials, cryptographic keys, and subscription profiles."
                },

                // ── 92. Combined 3 Bank 2020: HTTP True/False Concepts ──
                new() 
                { 
                    CategoryOrder = order, Category = cat, Year = 2020, ExamOrg = "Combined 3 Bank (SBL/JBL/Rakub)", Post = "SO Written", 
                    QuestionText = "True/False: (i) For a web page with text + 3 images, client sends 1 request and receives 4 responses. (ii) Two distinct web pages can be sent over the same persistent connection. (iii) With non-persistent connections, a single TCP segment can carry two distinct HTTP messages. (iv) HTTP response messages never have an empty message body.",
                    UserNotes = @"🇧🇩 বাংলা ব্যাখ্যা (Beginner-Friendly Concept & Technical Reason):
১. **(i) For a web page with text + 3 images, client sends 1 request and receives 4 responses $\rightarrow$ [ FALSE ]**:
   - কারণ: HTTP হলো একটি কঠোর Request-Response প্রোটোকল। ক্লায়েন্টকে মূল HTML ফাইলের জন্য ১টি রিকোয়েস্ট এবং ৩টি ছবির জন্য ৩টি আলাদা রিকোয়েস্ট—অর্থাৎ মোট **৪টি আলাদা রিকোয়েস্ট** পাঠাতে হয় এবং বিপরীতে ৪টি রেসপন্স আসে। ১টি রিকোয়েস্টে সার্ভার নিজ থেকে ৪টি রেসপন্স পুশ করতে পারে না (HTTP/1.1 তে)।
২. **(ii) Two distinct web pages can be sent over the same persistent connection $\rightarrow$ [ TRUE ]**:
   - কারণ: Persistent Connection (HTTP/1.1) তৈরিই করা হয়েছে যাতে একটি একক দীর্ঘস্থায়ী TCP কানেকশন খোলা রেখে তার ভেতর দিয়ে একাধিক আলাদা ওয়েব পেজ ও রিসোর্স আদান-প্রদান করা যায়।
৩. **(iii) With non-persistent connections, a single TCP segment can carry two distinct HTTP messages $\rightarrow$ [ FALSE ]**:
   - কারণ: Non-persistent কানেকশনের নিয়মানুযায়ী প্রতিবার মাত্র ১টি HTTP রিকোয়েস্ট বা রেসপন্স পাঠানো শেষ হওয়ামাত্র সেই TCP কানেকশন ক্লোজ (FIN) করে দেওয়া হয়। একটি সেগমেন্টে দুটি ভিন্ন মেসেজ বহন করা অসম্ভব।
৪. **(iv) HTTP response messages never have an empty message body $\rightarrow$ [ FALSE ]**:
   - কারণ: HTTP রেসপন্সের বডি ফাঁকা হওয়া খুবই স্বাভাবিক ব্যাপার! যেমন: স্ট্যাটাস কোড **`204 No Content`** অথবা ব্রাউজার ক্যাশ চেক করার **`304 Not Modified`** রেসপন্সে কেবল হেডার থাকে, কোনো মেসেজ বডি থাকে না (বডি সম্পূর্ণ শূন্য)।

🇬🇧 English Exam Answer:
• Comprehensive True / False Technical Evaluation:
| Statement | Verdict | In-Depth Technical Justification |
| :--- | :---: | :--- |
| **(i)** For a web page with text + 3 images, client sends 1 request and receives 4 responses. | **FALSE** | Under standard HTTP/1.x architecture, the client must explicitly issue **4 distinct HTTP GET requests** (1 for the base HTML text and 3 separate requests for the referenced image objects) to receive 4 distinct responses. |
| **(ii)** Two distinct web pages can be sent over the same persistent connection. | **TRUE** | Persistent connections (`Connection: keep-alive` in HTTP/1.1) maintain an open TCP session across multiple sequential or pipelined requests for entirely distinct URLs/web pages from the same host. |
| **(iii)** With non-persistent connections, a single TCP segment can carry two distinct HTTP messages. | **FALSE** | In non-persistent HTTP (HTTP/1.0), the connection closes immediately after a single request/response exchange is transmitted; bundling distinct messages into a single segment violates connection closure semantics. |
| **(iv)** HTTP response messages never have an empty message body. | **FALSE** | Multiple valid HTTP responses mandate or permit an empty entity body, including **`204 No Content`**, **`304 Not Modified`** (cache revalidation), and any response to an **`HTTP HEAD`** request."
                }
            };
        }
        #endregion
    }
}
