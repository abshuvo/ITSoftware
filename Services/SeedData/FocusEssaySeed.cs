using ITSoftware.Models;

namespace ITSoftware.Services
{
    public static partial class PreviousYearQuestionSeeder
    {
        #region 10. Focus / Essay / Translation
        private static List<PreviousYearQuestion> GetFocusEssayQuestions()
        {
            const string cat = "Focus / Essay / Translation";
            const int order = 10;
            return new List<PreviousYearQuestion>
            {
                // Bangladesh Bank Exams
                new() { CategoryOrder = order, Category = cat, Year = 2025, ExamOrg = "Bangladesh Bank (DU)", Post = "Assistant Director (ICT)", QuestionText = "Translate Bengali to English:\n(a) শনিবার হতে সে অফিসে আসছে না।\n(b) আপনার ব্যাংক একাউন্ট এর স্থিতি জানার জন্য মোবাইল ব্যাংকিং এপ্লিকেশন এ লগইন করুন।" },
                new() { CategoryOrder = order, Category = cat, Year = 2025, ExamOrg = "Bangladesh Bank (DU)", Post = "Assistant Director (ICT)", QuestionText = "Write a short note on: \"The role of AI and machine learning in mitigating challenges of cyber attacks on the banking system\" (100 to 150 words)." },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "Translation English to Bangla: \"Global economic turbulence is strongly felt in the banking and financial industry throughout the globe. The visible transformations are taking place in terms of embracing the new recovery efforts by adopting newer technology. The business...\"" },
                new() { CategoryOrder = order, Category = cat, Year = 2023, ExamOrg = "Bangladesh Bank (BIBM)", Post = "Assistant Programmer", QuestionText = "Translation Bangla to English: Banking digitalization and customer services." },

                // Combined & Other Banks
                new() { CategoryOrder = order, Category = cat, Year = 2026, ExamOrg = "BSCS AP (BIBM/CTI)", Post = "Assistant Programmer", QuestionText = "Focus Writing in Bangla: বাংলাদেশের ব্যাংকিং খাতে কৃত্রিম বুদ্ধিমত্তার প্রয়োগ কীভাবে কার্যক্রমের দক্ষতা ও নিরাপত্তা বৃদ্ধি করতে পারে? সম্ভাব্য ঝুঁকি ও নৈতিক চ্যালেঞ্জসমূহ বিশ্লেষণ করুন।" },
                new() { CategoryOrder = order, Category = cat, Year = 2026, ExamOrg = "BSCS AP (BIBM/CTI)", Post = "Assistant Programmer", QuestionText = "Focus Writing in English: Why are data privacy and regulatory compliance (AML, KYC, international data-protection standards) vital for the stability and credibility of the banking sector in Bangladesh? Discuss with examples and recommendations." },
                new() { CategoryOrder = order, Category = cat, Year = 2026, ExamOrg = "BSCS AP (BIBM/CTI)", Post = "Assistant Programmer", QuestionText = "Translation Bangla to English: Passage about NEET youth (not in education, employment, or training) and its economic/social impact in Bangladesh." },
                new() { CategoryOrder = order, Category = cat, Year = 2026, ExamOrg = "BSCS AP (BIBM/CTI)", Post = "Assistant Programmer", QuestionText = "Translation English to Bangla: Passage about the ongoing war in Gaza and its humanitarian crisis." },
                new() { CategoryOrder = order, Category = cat, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "Write an Essay in Bangla: দুর্নীতিমুক্ত দেশ গঠনে যুবসমাজের ভূমিকা (Role of youth in building a corruption-free country)." },
                new() { CategoryOrder = order, Category = cat, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "Write an Essay in English: Online Banking." },
                new() { CategoryOrder = order, Category = cat, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "Translate into English: Bangla passage about Google Drive features for office/study use." },
                new() { CategoryOrder = order, Category = cat, Year = 2026, ExamOrg = "BSCS Sonali & Janata Bank", Post = "Assistant Programmer", QuestionText = "Translate into Bangla: English passage about fertilizer crisis for farmers in Bangladesh." },
                new() { CategoryOrder = order, Category = cat, Year = 2021, ExamOrg = "ANE RBL", Post = "Assistant Network Engineer", QuestionText = "Write an essay (Bangla): স্বল্পোন্নত থেকে উন্নয়নশীল দেশে উত্তরণে বাংলাদেশ (Bangladesh's graduation from LDC to developing country)." },
                new() { CategoryOrder = order, Category = cat, Year = 2021, ExamOrg = "ANE RBL", Post = "Assistant Network Engineer", QuestionText = "Write an essay / focus writing (English): Confront rumors on social media." },
                new() { CategoryOrder = order, Category = cat, Year = 2020, ExamOrg = "BSCS Combined 2 Bank (SB&JB)", Post = "Officer IT", QuestionText = "Write a short essay (Bangla): COVID-19 এর ক্ষতিকর প্রভাব মোকাবেলায় তথ্যপ্রযুক্তির প্রয়োগ ও ভূমিকা।" },
                new() { CategoryOrder = order, Category = cat, Year = 2020, ExamOrg = "BSCS Combined 2 Bank (SB&JB)", Post = "Officer IT", QuestionText = "Translate into English: Bangla passage about COVID-19 vaccine procurement (17,000 crore doses needed for 16.5 crore population)." },
                new() { CategoryOrder = order, Category = cat, Year = 2020, ExamOrg = "BSCS Combined 2 Bank (SB&JB)", Post = "Officer IT", QuestionText = "Translate into Bengali: English passage about Nobel Medicine Prize for Hepatitis C discovery (Harvey Alter, Charles Rice, Michael Houghton)." },
                new() { CategoryOrder = order, Category = cat, Year = 2020, ExamOrg = "BSCS Combined 2 Bank (SB&JB)", Post = "Officer IT", QuestionText = "Write a paragraph on \"Post-corona Green Recovery Plans and Progress in Bangladesh\" in English." },
                new() { CategoryOrder = order, Category = cat, Year = 2020, ExamOrg = "ANE JBL", Post = "Assistant Network Engineer", QuestionText = "Write an essay (Bangla): জলবায়ু পরিবর্তন ও বাংলাদেশে এর প্রভাব (Climate change and its impact on Bangladesh)." }
            };
        }
        #endregion
    }
}

