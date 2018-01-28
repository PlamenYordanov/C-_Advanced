using System;
using System.Linq;
using System.Text;

namespace Rubic_sMatrix
{
    public static class RubicsMatrix
    {
        public static void Main()
        {
            var rowsColumns = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = rowsColumns[0];
            int columns = rowsColumns[1];
            int[,] matrix = new int[rows, columns];
            int n = int.Parse(Console.ReadLine());
            FillMatrix(matrix);

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                int rowOrColumn = int.Parse(input[0]);
                string command = input[1];
                int moves = int.Parse(input[2]);
                ParseCommand(matrix, rowOrColumn, command, moves);
            }
            Console.WriteLine(GetResult(matrix));

        }
        private static string GetResult(int[,] matrix)
        {
            var sb = new StringBuilder();
            int number = 1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == number)
                    {
                        sb.AppendLine($"No swap required");
                    }
                    else
                    {
                        var index = CoordinatesOf(matrix, number);
                        var row = index.Item1;
                        var col = index.Item2;
                        sb.AppendLine($"Swap ({i}, {j}) with ({row}, {col})");
                        matrix[row, col] = matrix[i, j]; 
                        matrix[i, j] = number;

                    }
                    number++;
                }

            }
            return sb.ToString().TrimEnd();
        }

        private static void ParseCommand(int[,] matrix, int rowOrColumn, string command, int moves)
        {
            switch (command.ToLower())
            {
                case "up":
                    RotateColUp(matrix, rowOrColumn, moves);
                    break;
                case "down":
                    RotateColDown(matrix, rowOrColumn, moves);
                    break;
                case "right":
                    RotateRight(matrix, rowOrColumn, moves);
                    break;
                case "left":
                    RotateLeft(matrix, rowOrColumn, moves);
                    break;
                default:
                    break;
            }
        }

        private static void RotateLeft(int[,] matrix, int row, int moves)
        {
            int rowLength = matrix.GetLength(1);

            int[] temp = new int[rowLength];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                temp[i] = matrix[row, (moves + i) % rowLength];
            }
            for (int i = 0; i < rowLength; i++)
            {
                matrix[row, i] = temp[i];
            }

        }

        private static void RotateColUp(int[,] matrix, int col, int moves)
        {
            int colLength = matrix.GetLength(0);

            int[] temp = new int[colLength];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                temp[i] = matrix[(moves + i) % colLength, col];
            }
            for (int i = 0; i < colLength; i++)
            {
                matrix[i, col] = temp[i];
            }
        }

        private static void RotateColDown(int[,] matrix, int col, int moves)
        {
            int colLength = matrix.GetLength(0);

            int[] temp = new int[colLength];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                temp[(moves + i) % colLength] = matrix[i, col];
            }
            for (int i = 0; i < colLength; i++)
            {
                matrix[i, col] = temp[i];
            }
        }

        private static void RotateRight(int[,] matrix, int row, int moves)
        {
            int rowLength = matrix.GetLength(1);

            int[] temp = new int[rowLength];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                temp[(moves + i) % rowLength] = matrix[row, i];
            }
            for (int i = 0; i < rowLength; i++)
            {
                matrix[row, i] = temp[i];
            }
        }

        private static void FillMatrix(int[,] matrix)
        {
            int number = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = number + 1;
                    number++;
                }
            }
        }

        private static Tuple<int, int> CoordinatesOf(this int[,] matrix, int value)
        {
            int w = matrix.GetLength(0);
            int h = matrix.GetLength(1);

            for (int row = 0; row < w; ++row)
            {
                for (int col = 0; col < h; ++col)
                {
                    if (matrix[row, col].Equals(value))
                        return Tuple.Create(row, col);
                }
            }
            return Tuple.Create(-1, -1);
        }
    }
}
