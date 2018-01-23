namespace ReverseNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            int maxElement = 0;
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                ParseInput(stack, input, ref maxElement);
            }
            


        }
        private static void ParseInput(Stack<int> stack, string input, ref int maxElement)
        {
            var elements = input.Split();

            var command = int.Parse(elements[0]);

            switch (command)
            {
                case 1:
                    var element = int.Parse(elements[1]);
                    if (element > maxElement)
                    {
                        maxElement = element;
                    }
                    stack.Push(element);
                    break;
                case 2:
                    element = stack.Pop();
                    if (element == maxElement)
                    {
                        bool isEmpty = stack.Count == 0;
                        maxElement = isEmpty ? 0 : stack.Max();
                    }
                    break;
                case 3:
                    Console.WriteLine(maxElement);
                    break;
                default:
                    break;
            }
        }
    }
}
