namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class WordCount
    {
        public static void Main()
        {
            string textPath = @"..\OddLines\Files\text.txt";
            string wordsPath = @"..\OddLines\Files\words.txt";
            string writePath = @"..\OddLines\Files\result.txt";
            var wordsInfoList = new List<WordInfo>();

            var file = File.ReadAllText(textPath).ToLower()
                .Split(new char[] {' ', '.', ',', '-', '!', '?','\r', '\n'}
            ,StringSplitOptions.RemoveEmptyEntries);

            var reader = new StreamReader(wordsPath);
            var writer = new StreamWriter(writePath);
            using (reader)
            using (writer)
            {
                string word = string.Empty;

                while ((word = reader.ReadLine()) != null)
                {
                    int count = file.Where(w => w.Equals(word.ToLower())).Count();
                    var wordInfo = new WordInfo(word, count);
                    wordsInfoList.Add(wordInfo);
                }
            
                foreach (var wordInfo in wordsInfoList.OrderByDescending(x => x.Count))
                {
                    writer.WriteLine(wordInfo);
                }
            }
        }
    }
    public class WordInfo
    {
        public string Word { get; set; }
        public int Count { get; set; }
        public WordInfo(string word, int count)
        {
            this.Word = word;
            this.Count = count;
        }
        public override string ToString()
        {
            return $"{this.Word} - {this.Count}";
        }
    }
}
