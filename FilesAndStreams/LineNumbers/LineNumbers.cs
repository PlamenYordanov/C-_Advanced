
namespace LineNumbers
{
    using System;
    using System.IO;

    public class LineNumbers
    {
        public static void Main()
        {
            var file = File.ReadAllLines(@"..\OddLines\Files\text.txt");
            int count = 1;
            foreach (var line in file)
            {
                Console.WriteLine($"Line {count}: {line}");
            }
        }
    }
}
