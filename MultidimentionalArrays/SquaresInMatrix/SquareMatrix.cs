namespace SquaresInMatrix
{
    using System;
    using System.Linq;

    public class SquareMatrix
    {
        public static void Main()
        {
            var rowsColumns = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = rowsColumns[0];
            int columns = rowsColumns[1];
            var matrix = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                var rowOfChars = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                AddRowToMatrix(matrix, rowOfChars, i);
            }
            int squareCount = EqualSquareCount(matrix);
            Console.WriteLine(squareCount);
        }
        private static void AddRowToMatrix(int[,] matrix, char[] elements, int row)
        {
            int j = row;
            for (int i = 0; i < elements.Length; i++)
            {
                matrix[j, i] = elements[i];
            }
        }

        private static int EqualSquareCount(int[,] matrix)
        {
            int squareCount = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                squareCount += SquaresInRow(matrix, row);
            }

            return squareCount;
        }

        private static int SquaresInRow(int[,] matrix, int row)
        {
            int squares = 0;
            int col = matrix.GetLength(1);
            for (int i = 0; i < col - 1; i++)
            {
                if (matrix[row, i] == matrix[row, i + 1]
                      && matrix[row, i] == matrix[row + 1, i]
                          && matrix[row, i + 1] == matrix[row + 1, i + 1])
                {
                    squares++;
                }
            }
            return squares;

        }
    }
}


