namespace ReverseNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var text = new StringBuilder();
            var removedItems = new Stack<string>();
            var addedItems = new Stack<string>();
            var commands = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                var command = int.Parse(input[0]);

                switch (command)
                {
                    case 1:
                        AppendString(text, input, commands, addedItems);
                        break;
                    case 2:
                        EraseLastElements(text, input, removedItems, commands);
                        break;
                    case 3:
                        PrintElementAtIndex(text, input);
                        break;
                    case 4:
                        Undo(text, removedItems, addedItems, commands);
                        break;
                    default:
                        break;
                }
            }

        }

        private static void Undo(StringBuilder text, Stack<string> removedItems, Stack<string> addedItems, Stack<int> commands)
        {
            switch (commands.Pop())
            {
                case 1:
                    var lastAdded = addedItems.Pop();
                    text.Remove(text.Length - lastAdded.Length, lastAdded.Length);
                    break;
                case 2:
                    var lastRemoved = removedItems.Pop();
                    text.Append(lastRemoved);
                    break;
                default:
                    break;
            }
        }

        private static void PrintElementAtIndex(StringBuilder text, string[] input)
        {
            int index = int.Parse(input[1]);
            char elementAtIndex = text.ToString()[index - 1];
            Console.WriteLine(elementAtIndex);
        }

        private static void EraseLastElements(StringBuilder text, string[] input, Stack<string> removedItems, Stack<int> commands)
        {
            int count = int.Parse(input[1]);
            var removedText = text.ToString().Substring(text.Length - count, count);
            removedItems.Push(removedText);
            text.Remove(text.Length - count, count);
            commands.Push(2);
        }

        private static void AppendString(StringBuilder text, string[] input, Stack<int> commands, Stack<string> addedItems)
        {
            var strToAppend = input[1];
            text.Append(strToAppend);
            commands.Push(1);
            addedItems.Push(strToAppend);
        }

        private static char IndexOf(int n, StringBuilder sb)
        {
            return sb.ToString()[n - 1];
        }
    }
}
