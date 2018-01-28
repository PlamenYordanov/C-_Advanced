using System;

namespace MatrixOfPalindromes
{
    public class Startup
    {
        public static void Main()
        {
            string[] rowsColumns = Console.ReadLine().Split();
            int rows = int.Parse(rowsColumns[0]);
            int columns = int.Parse(rowsColumns[1]);

            for (int r = 0 + 97; r < rows + 97; r++)
            {
                for (int c = r; c < columns + r; c++)
                {
                    Console.Write("{0}{1}{0} ", (char)r, (char)c);
                }
                Console.WriteLine();
            }
        }
    }
}
