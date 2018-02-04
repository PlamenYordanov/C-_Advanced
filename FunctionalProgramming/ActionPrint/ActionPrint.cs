namespace ActionPrint
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ActionPrint
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string evenOrOdd = Console.ReadLine();

            Predicate<int> evenOrOddFinder = (i) => { return i % 2 == 0; };
            if (evenOrOdd.Equals("odd"))
            {
                evenOrOddFinder = (i) => { return i % 2 != 0; };
            }

            var result = GetEvenOrOddElements(numbers, evenOrOddFinder);
            Console.WriteLine(string.Join(" ", result));
        }
        static IEnumerable<int> GetEvenOrOddElements(int[] numbers, Predicate<int> getEvenOrOdd)
        {
            int lowerEnd = numbers[0];
            int upperEnd = numbers[1];

            for (int i = lowerEnd; i <= upperEnd; i++)
            {
                if (getEvenOrOdd(i))
                {
                    yield return i;
                }
            }
        }
    }
}
