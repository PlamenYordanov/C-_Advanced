
namespace PartyReservationFilterModule
{
    using System;
    using System.Collections.Generic;

    public class PartySomethingSomething
    {
        public static void Main()
        {
            Func<int, bool> func = null;
            func += i => i > 10;
            func -= i => i > 10;
            
            Console.WriteLine();
        }
    }
}
