namespace ReverseNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var inputData = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var elementsToAdd = inputData[0];
            var countPops = inputData[1];
            var elementToCheck = inputData[2];
            var elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var stack = new Stack<int>();
            for (int i = 0; i < elementsToAdd; i++)
            {
                stack.Push(elements[i]);
            }
            for (int i = 0; i < countPops; i++)
            {
                stack.Pop();
            }
            if (stack.Contains(elementToCheck))
            {
                Console.WriteLine(true);
            }
            else 
            {
                bool isEmpty = stack.Count == 0;
                Console.WriteLine(isEmpty ? 0 : stack.Min());
            }
        }
    }
}
