using System;
using System.Linq;

namespace MaximumSum
{
    public class MaximumSum
    {
        public static void Main()
        {
            var rowsColumns = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = rowsColumns[0];
            int columns = rowsColumns[1];

            var maxSquareIndex = new int[2];
            if (rows < 3 || columns < 3)
            {
                return;
            }
            var matrix = new int[rows, columns];
            for (int row = 0; row < rows; row++)
            {
                var numbers = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                AddRowToMatrix(matrix, numbers, row);
            }
            int maxRow = 0;
            int maxCol = 0;
            int maxSum = 0;
            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < columns - 2; col++)
                {
                    int sum = GetSquareSum(matrix, row, col);
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            PrintMaxElements(matrix, maxRow, maxCol);
        }
        private static void PrintMaxElements(int[,] matrix, int maxRow, int maxCol)
        {
            for (int i = maxRow; i < 3 + maxRow; i++)
            {
                for (int j = maxCol; j < 3 + maxCol; j++)
                {
                    Console.Write(string.Format("{0} ", matrix[i, j]));
                }
                Console.WriteLine();
            }
        } 
        private static int GetSquareSum(int[,] matrix, int row, int col)
        {
            int sum = 0;
            for (int i = row; i < 3 + row; i++)
            {
                for (int j = col; j < 3+col; j++)
                {
                    sum += matrix[i, j];
                }
            }
            return sum;
        }

        private static void AddRowToMatrix(int[,] matrix, int[] elements, int row)
        {
            int j = row;
            for (int i = 0; i < elements.Length; i++)
            {
                matrix[j, i] = elements[i];
            }
        }
    }
}
