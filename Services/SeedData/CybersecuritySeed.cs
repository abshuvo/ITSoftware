using ITSoftware.Models;

namespace ITSoftware.Services
{
    public static partial class PreviousYearQuestionSeeder
    {
        #region 5. Cybersecurity
        private static List<PreviousYearQuestion> GetCybersecurityQuestions()
        {
            const string cat = "Cybersecurity";
            const int order = 5;
            return new List<PreviousYearQuestion>
            {
                // Bangladesh Bank Exams
                new() { CategoryOrder = order, Category = cat, Year = 2025, ExamOrg = "Bangladesh Bank (DU)", Post = "Assistant Director (ICT)", QuestionText = "[MCQ] Which algorithm is used in email security?\n(a) AES (b) RSA (c) SHA (d) All of the above\nAns: (d) All of the above" },
                new() { CategoryOrder = order, Category = cat, Year = 2025, ExamOrg = "Bangladesh Bank (DU)", Post = "Assistant Director (ICT)", QuestionText = "[MCQ] What kind of encryption is used for securing emails in transit?\n(a) Symmetric Encryption (b) Asymmetric Encryption (c) TLS (Transport Layer Security) (d) Hashing\nAns: (c) TLS (Transport Layer Security)" },
                new() { CategoryOrder = order, Category = cat, Year = 2025, ExamOrg = "Bangladesh Bank (DU)", Post = "Assistant Director (ICT)", QuestionText = "[MCQ] Digital Signature uses which algorithm?\n(a) AES (b) RSA (c) DES (d) Diffie-Hellman\nAns: (b) RSA" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Maintenance Engineer", QuestionText = "A bank has association with two different service providers as their payment gateways. The bank hires Mr. X to audit the payment gateway based on risk and threat detection. Which possible scenarios will Mr. X face?" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "Describe a Man-in-the-Middle attack on the Diffie-Hellman key exchange protocol in which the adversary generates two public key pairs for the attack." },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "Preserving confidentiality, integrity and availability of data is a restatement of the concern over falsification, interception, masquerade and denial of service. Explain how the first three concepts relate to the last four." },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "In order to prevent attacks, the company decided to add end-to-end encryption techniques. Which layer of the OSI model is suitable considering parameters like development time, software maintainability and development cost? Give reasons for your concepts." },
                new() { CategoryOrder = order, Category = cat, Year = 2019, ExamOrg = "Bangladesh Bank (BUET)", Post = "Assistant Maintenance Engineer", QuestionText = "What is the difference among threat, vulnerability and risk? Explain SSL and TLS." },
                new() { CategoryOrder = order, Category = cat, Year = 2019, ExamOrg = "Bangladesh Bank (DU)", Post = "Assistant Programmer", QuestionText = "What protection do you provide for your computer from malware?" },
                new() { CategoryOrder = order, Category = cat, Year = 2019, ExamOrg = "Bangladesh Bank (DU)", Post = "Assistant Programmer", QuestionText = "What is firewall? Explain its work. Draw a LAN network and a firewall where firewall will be situated." },
                new() { CategoryOrder = order, Category = cat, Year = 2017, ExamOrg = "Bangladesh Bank", Post = "Assistant Maintenance Engineer", QuestionText = "What is session hijacking and how to encrypt username and password in PHP?" },
                new() { CategoryOrder = order, Category = cat, Year = 2017, ExamOrg = "Bangladesh Bank", Post = "Assistant Maintenance Engineer", QuestionText = "What are the important steps to secure a web server?" },
                new() { CategoryOrder = order, Category = cat, Year = 2011, ExamOrg = "Bangladesh Bank", Post = "Assistant Maintenance Engineer", QuestionText = "[MCQ] Computer virus is a:\n(a) Animal (b) Hardware (c) Program (d) Machine\nAns: (c) Program" },

                // Combined & Other Banks
                new() { CategoryOrder = order, Category = cat, Year = 2026, ExamOrg = "Sonali Bank PLC", Post = "ADA", QuestionText = "Your workstation is affected by a ransomware attack. What five steps do you take to mitigate this problem?" },
                new() { CategoryOrder = order, Category = cat, Year = 2026, ExamOrg = "Sonali Bank PLC", Post = "ADA", QuestionText = "What is Phishing? Describe different types of phishing attacks." },
                new() { CategoryOrder = order, Category = cat, Year = 2026, ExamOrg = "Sonali Bank PLC", Post = "ADA", QuestionText = "What is a firewall? Difference between stateful inspection and Next-Generation Firewall (NGFW)." },
                new() { CategoryOrder = order, Category = cat, Year = 2026, ExamOrg = "Sonali Bank PLC", Post = "ADA", QuestionText = "Firewall rules: Rule 1=port 89, Rule 2=port<443, Rule 3=port 443. When a packet comes from port 443, is it accepted or rejected? Explain \"First inspection rules\"." },
                new() { CategoryOrder = order, Category = cat, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "What is authentication and authorization? What is the CIA triad in cyber security?" },
                new() { CategoryOrder = order, Category = cat, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "What is social engineering? What is hashing? How is it different from encryption? What is vulnerability assessment?" },
                new() { CategoryOrder = order, Category = cat, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "A new employee joins the bank. Describe the process of creating a new user account focusing on security best practices (e.g., password policies)." },
                new() { CategoryOrder = order, Category = cat, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "User X belongs to Group A and Group B. Folder grants \"Read\" to Group A, \"Explicit Deny Write\" to Group B, \"Write\" to User X individually. Can User X write to Folder? Explain Explicit Deny vs Explicit Allow precedence logic." },
                new() { CategoryOrder = order, Category = cat, Year = 2025, ExamOrg = "Combined Bank (BIBM)", Post = "Officer IT", QuestionText = "Describe how CIA principles (Confidentiality, Integrity, Availability) work together to protect organizational data. Provide one real-world example of a security breach." },
                new() { CategoryOrder = order, Category = cat, Year = 2025, ExamOrg = "Combined Bank (BIBM)", Post = "Officer IT", QuestionText = "A banking app requires a 4-digit PIN for login. Explain how to test this input field (valid 4-digit only, reject invalid). Mention test cases and explain why such testing is important." },
                new() { CategoryOrder = order, Category = cat, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "ADA", QuestionText = "How to ensure secure communication between a client application and the database server." },
                new() { CategoryOrder = order, Category = cat, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "AME/AE IT", QuestionText = "Your bank wants to secure an e-banking online system and configure a web server in your data center. What tools and technology do you use?" },
                new() { CategoryOrder = order, Category = cat, Year = 2024, ExamOrg = "Combined 3 Bank (BIBM)", Post = "Senior Officer IT", QuestionText = "You procure a microfinance application and host it in your data center. What cyber-security threats should you be aware of and how to mitigate them?" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Combined 5 Bank (BIBM)", Post = "Officer IT", QuestionText = "An attacker steals the private key of a website using TLS and remains undetected. What can the attacker do using the private key?" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Combined 5 Bank (BIBM)", Post = "Officer IT", QuestionText = "Browsers A and B from different origins. Why is it reasonable security policy to allow A to navigate B only when A's display area contains B's display? Also: LRU page replacement with reference string 12342341211314, 3 frames — find page faults." },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Combined Bank (BIBM)", Post = "Officer IT", QuestionText = "Write down the 10 most common cyber-attacks." },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Combined 4 Bank (BIBM)", Post = "SO IT", QuestionText = "What is Cryptography? Difference between Symmetric and Asymmetric encryption. Draw a diagram for e-commerce online transactions using Symmetric (Public Key) Encryption." },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "RAKUB (BIBM)", Post = "ANSE", QuestionText = "What is digital signature? Write about CIA. Draw a diagram of public key encryption (asymmetric)." },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Rupali Bank (BIBM)", Post = "ANA", QuestionText = "Draw a diagram of LAN including network Firewall. Why is firewall important in network security? List major types of firewalls. Difference between Traditional Firewall and Next-Generation Firewall." },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Rupali Bank (BIBM)", Post = "ANA", QuestionText = "Distinguish between Symmetric and Asymmetric Encryption. Give encryption algorithm examples. What are the different types of ciphers in cryptography? Factors to consider for cryptographic strength?" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Combined Bank (BIBM)", Post = "Senior Officer AHE/AME", QuestionText = "Describe the importance of DMZ in computer networking, especially for hosting a digital banking system." },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Combined Bank (BIBM)", Post = "Senior Officer AHE/AME", QuestionText = "How are encryption and decryption related to cybersecurity? Describe the RSA algorithm for public key encryption and the math behind RSA. (Hint: p=13, q=17, public key=35 → find private key)" },
                new() { CategoryOrder = order, Category = cat, Year = 2022, ExamOrg = "Security Printing Corp Bangladesh", Post = "Sub-Assistant Engineer", QuestionText = "What is Blacklist and Whitelist? Write the difference between Blacklist and Whitelist." },
                new() { CategoryOrder = order, Category = cat, Year = 2022, ExamOrg = "Security Printing Corp Bangladesh", Post = "Sub-Assistant Engineer", QuestionText = "What is SQL injection? How to prevent it?" },
                new() { CategoryOrder = order, Category = cat, Year = 2022, ExamOrg = "Security Printing Corp Bangladesh", Post = "Sub-Assistant Engineer", QuestionText = "What is Cross-Site Scripting (XSS) and how can you fix it?" },
                new() { CategoryOrder = order, Category = cat, Year = 2022, ExamOrg = "ANA JBL", Post = "Assistant Network Administrator", QuestionText = "What are the properties of a firewall? Show diagram where firewall should be placed." },
                new() { CategoryOrder = order, Category = cat, Year = 2022, ExamOrg = "ANA JBL", Post = "Assistant Network Administrator", QuestionText = "In network security, define: Confidentiality, Non-repudiation, Authenticity, Integrity, Availability." },
                new() { CategoryOrder = order, Category = cat, Year = 2022, ExamOrg = "SBL/BDBL", Post = "Senior Officer IT", QuestionText = "Explain the problems with possible solutions: Session hijacking and SQL injection." },
                new() { CategoryOrder = order, Category = cat, Year = 2021, ExamOrg = "ASA JBL", Post = "Assistant System Administrator", QuestionText = "What is SQL injection? Give two examples of SQL injection attack. How to prevent SQL injection attacks?" },
                new() { CategoryOrder = order, Category = cat, Year = 2021, ExamOrg = "Security Printing Corp Bangladesh", Post = "Assistant Maintenance Engineer", QuestionText = "Short note: (a) Ransomware, (b) Trojan Horse, (c) Worm" },
                new() { CategoryOrder = order, Category = cat, Year = 2021, ExamOrg = "BSCA Sonali Bank", Post = "Officer IT", QuestionText = "Write down firewalls role and browser cookies role." },
                new() { CategoryOrder = order, Category = cat, Year = 2021, ExamOrg = "BSCA Sonali Bank", Post = "Officer IT", QuestionText = "Explain DDoS and SQL injection attack." },
                new() { CategoryOrder = order, Category = cat, Year = 2020, ExamOrg = "Combined 3 Banks (SBL/BDBL)", Post = "Senior Officer IT", QuestionText = "What is the difference between packet sniffing (Snooping) and Packet spoofing?" },
                new() { CategoryOrder = order, Category = cat, Year = 2020, ExamOrg = "ANE JBL", Post = "Assistant Network Engineer", QuestionText = "Encrypt the message \"THIS IS A\" using a shift cipher with key = 20. Ignore spaces. Then decrypt the message to get original plaintext." }
            };
        }
        #endregion
    }
}

