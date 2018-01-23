namespace ReverseNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split();
            var stack = new Stack<string>();

            foreach (var number in numbers)
            {
                stack.Push(number);
            }
            Console.WriteLine(string.Join(" ", stack));
        }
    }
}
