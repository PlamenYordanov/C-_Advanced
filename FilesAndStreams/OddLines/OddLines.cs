
namespace OddLines
{
    using System;
    using System.IO;
    public class OddLines
    {
        public static void Main()
        {
            var lines = File.ReadAllLines(@"C..\..\Files\text.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                if(i % 2 == 1)
                {
                    Console.WriteLine(lines[i]);
                }
            }
        }
    }
}
