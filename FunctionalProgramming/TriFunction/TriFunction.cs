
namespace TriFunction
{
    using System;
    using System.Linq;

    public class TriFunction
    {
        public static void Main()
        {
            int length = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split();
            Func<string, int> charSum = (s) => s.ToCharArray().Sum(c => c);
            Func<string, int, bool> isEqualOrLarger = (s, n) => charSum(s) >= n;
            var name = names.FirstOrDefault(n => isEqualOrLarger(n, length));
            Console.WriteLine(name);

        }
    }
}
