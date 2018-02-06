
namespace CryptoMaster
{
    using System;
    using System.Collections;
    using System.Linq;

    public class CryptoMaster
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] { ' ', ',' }
            , StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
            int maxCount = 0;
            int length = numbers.Length;
            for (int step = 1; step < length; step++)
            {
                for (int j = 0; j < length; j++)
                {
                    int currentCount = 1;
                    int currentIndex = j;
                    int nextIndex = (currentIndex + step) % length;

                    while (numbers[currentIndex] < numbers[nextIndex])
                    {
                        currentCount++;
                        currentIndex = nextIndex;
                        nextIndex = (currentIndex + step) % length;
                    }
                    if (currentCount > maxCount)
                    {
                        maxCount = currentCount;
                    }
                }
            }
            Console.WriteLine(maxCount);
        }
    }
}
