using System;
using System.Linq;

namespace DiagonalDifference
{
    public class DiagonalDifference
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                var row = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                AddRowToMatrix(matrix, row, i);
            }
            int left = GetLeftDiagonalSum(matrix);
            int right = GetRightDiagonalSum(matrix);
            int absDifference = Math.Abs(left - right);
            Console.WriteLine(absDifference);
        }
        private static int GetLeftDiagonalSum(int[,] matrix)
        {
            int sum = 0;
            int element = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, element];
                element++;
            }
            return sum;
        }
        private static int GetRightDiagonalSum(int[,] matrix)
        {
            int sum = 0;
            int element = matrix.GetLength(0) -1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, element];
                element--;
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
