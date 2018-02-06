namespace GreedyTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GreedyTimes
    {
        public static void Main()
        {
            var gems = new List<Gem>();
            var money = new List<Cash>();
            List<long> allGold = new List<long>();

            long bagCapacity = long.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split(new[] { ' ', '\n', '\t', '\r' }
            , StringSplitOptions.RemoveEmptyEntries);

            long gemSum = 0;
            long cashSum = 0;
            long goldSum = 0;
            

            for (int i = 0; i < input.Length; i += 2)
            {
                var currentItem = input[i];
                var quantity = long.Parse(input[i + 1]);

                if (currentItem.Length == 3)
                {
                   
                    if (cashSum + quantity <= gemSum
                        && goldSum + cashSum + gemSum + quantity <= bagCapacity)
                    {
                        if (!money.Any(c => c.Name.Equals(currentItem)))
                        {
                            var cash = new Cash(currentItem);
                            money.Add(cash);
                        }
                        var tempCash = money.SingleOrDefault(x => x.Name.Equals(currentItem));
                        tempCash.Quantity += quantity;
                        cashSum += quantity;
                    }
                    continue;
                }
                if (currentItem.ToLower().EndsWith("gem")
                    && currentItem.Length > 3)
                {
                    
                    if (gemSum + quantity <= goldSum
                        && goldSum + cashSum + gemSum + quantity <= bagCapacity)
                    {
                        if (!gems.Any(x => x.Name.Equals(currentItem)))
                        {
                            var gem = new Gem(currentItem);
                            gems.Add(gem);
                        }
                        var tempItem = gems.SingleOrDefault(x => x.Name.Equals(currentItem));

                        tempItem.Quantity += quantity;
                        gemSum += quantity;
                    }
                    continue;
                }
                if (currentItem.ToLower().Equals("gold")
                     && goldSum + quantity <= bagCapacity)
                {
                    goldSum += quantity;
                    allGold.Add(quantity);
                }
            }
            if (allGold.Count != 0)
            {
                Console.WriteLine($"<Gold> ${goldSum}");
                Console.WriteLine($"##Gold - {goldSum}");
            }
            
            if (gems.Count != 0)
            {
                Console.WriteLine($"<Gem> ${gemSum}");
                foreach (var gem in gems
                    .OrderByDescending(x => x.Name)
                    .ThenBy(x => x.Quantity))    
                {
                    Console.WriteLine($"##{gem.Name} - {gem.Quantity}");
                }

            }
            if (money.Count != 0)
            {
                Console.WriteLine($"<Cash> ${cashSum}");
                foreach (var cash in money
                    .OrderByDescending(x => x.Name)
                    .ThenBy(x => x.Quantity))
                {
                    Console.WriteLine($"##{cash.Name} - {cash.Quantity}");
                }
            }
            
        }
    }
    public abstract class Item
    {
        public string Name { get; set; }
        public long Quantity { get; set; }
        public Item(string name)
        {
            this.Name = name;
        }
    }
    public class Gem : Item
    {
        public Gem(string name) : base(name)
        { }
    }
    public class Cash : Item
    {
        public Cash(string name) : base(name)
        { }
        
    }

}
