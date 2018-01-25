namespace ReverseNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var fibMemory = EmptyMemory();
            
            Console.WriteLine(Fib(n, fibMemory));
        }
        private static int Fib(int n, int[] fibMemory)
        {
            if (n <= 1)
            {
                return n;
            }
            if (fibMemory[n] != -1)
            {
                return fibMemory[n];
            }
            fibMemory[n] = Fib(n - 1, fibMemory) + Fib(n - 2, fibMemory);
            return fibMemory[n];
        }
        private static int[] EmptyMemory()
        {
            int[] memory = new int[51];
            for (int i = 0; i < 51; i++)
            {
                memory[i] = -1;
            }
            return memory; 
        }
    }
}
