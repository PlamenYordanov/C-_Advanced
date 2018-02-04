namespace ActionPrint
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ActionPrint
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            var input = string.Empty;
            Func<int, int> arithmeticFunc = null;
            while ((input = Console.ReadLine()) != "end")
            {
                switch (input)
                {
                    case "add":
                        arithmeticFunc = n => n + 1;
                        break;
                    case "multiply":
                        arithmeticFunc = n => n * 2;
                        break;
                    case "subtract":
                        arithmeticFunc = n => n - 1;
                        break;
                    case "print":
                        Console.WriteLine(string.Join(" ", numbers));
                        continue;
                    default:
                        break;
                }
                ApplyArithmetics(numbers, arithmeticFunc);
            }
        }
        static void ApplyArithmetics(List<int> numbers, Func<int, int> func)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i] = func(numbers[i]);
            }
        }
    }
}
