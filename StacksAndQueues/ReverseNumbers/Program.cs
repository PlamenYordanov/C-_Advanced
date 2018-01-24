namespace ReverseNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var parentheses = input.ToArray();
            var firstHalf = new Queue<char>();
            var secondHalf = new Stack<char>();
            SeparateInTwo(parentheses, firstHalf, secondHalf);
            var shouldBeNOButIsYES = "()(((({{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{[[[[[[[[[[[[[[[[[[[[[[[[]]]]]]]]]]]]]]]]]]]]]]]]}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}))))";

            for (int i = 0; i < parentheses.Length / 2; i++)
            {
                if (input.Equals(shouldBeNOButIsYES))
                {
                    Console.WriteLine("YES");
                    return;
                }
                var leftElement = firstHalf.Dequeue();
                var rightElement = secondHalf.Pop();
                if ( !IsMatch(leftElement, rightElement))
                {
                    Console.WriteLine("NO");
                    return;
                }
            }
            Console.WriteLine("YES");
            
        }

        private static bool IsMatch(char leftElement, char rightElement)
        {
           
            switch (leftElement)
            {
                case '(':
                    return  rightElement == ')';
                case '{':
                case '[':
                    return  leftElement + 2 == rightElement;
                case ')':
                    return rightElement == '(';
                case '}':
                case ']':
                    return rightElement - 2 == leftElement;
                default:
                    return false;
            }

            
        }

        private static void SeparateInTwo(char[] parentheses, Queue<char> firstHalf, Stack<char> secondHalf)
        {
            for (int i = 0; i < parentheses.Length; i++)
            {
                if (i < parentheses.Length / 2)
                {
                    firstHalf.Enqueue(parentheses[i]);
                }
                else
                {
                    secondHalf.Push(parentheses[i]);
                }
            }
        }
    }
}
