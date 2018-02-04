namespace ActionPrint
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ActionPrint
    {

        public static void Main()
        {
            int upperRange = int.Parse(Console.ReadLine());

            var dividers = Console.ReadLine().Split(new char[] { ' ' }
            , StringSplitOptions.RemoveEmptyEntries)
            .Distinct()
            .Select(int.Parse)
            .ToList();
            var filters = dividers.Select(d => (Func<int, bool>)(n => n % d == 0)).ToList();
            var dividends = new List<int>();
            for (int i = 1; i <= upperRange; i++)
            {
                bool approved = true;
                foreach (var filter in filters)
                {
                    if (!filter(i))
                    {
                        approved = false;
                        break ;
                    }
                }
                if (approved)
                {
                    dividends.Add(i);

                }

            }
            Console.WriteLine(string.Join(" ", dividends));
        }
    }
}
