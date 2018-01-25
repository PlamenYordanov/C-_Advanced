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
            var stack = new Stack<long>();
            long a = 0;
            long b = 1;
            long c;
            stack.Push(a);
            stack.Push(b);
            for (int i = 2; i < n + 1; i++)
            {
                c = a + b;
                a = b;
                b = c;
                stack.Push(c);
            }
            Console.WriteLine(stack.Peek());
        }
        
    }
}
