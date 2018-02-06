namespace DangerousFloor
{
    using System;
    using System.Text;

    public class DangerousFloor
    {
        public static void Main()
        {
            var chessBoard = new char[8, 8];

            for (int i = 0; i < 8; i++)
            {
                var layout = Console.ReadLine()
                    .Split(new[] { ',' }
                    , StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < 8; j++)
                {
                    chessBoard[i, j] = char.Parse(layout[j]);
                }
            }
            string input = string.Empty;
            var sb = new StringBuilder();
            while ((input = Console.ReadLine()) != "END")
            {
                char piece = input[0];
                var currentX = input[1];
                var currentY = input[2];
                var nextX = input[4];
                var nextY = input[5];
                if (chessBoard[currentX, currentY] != piece)
                {
                    Console.WriteLine("There is no such a piece!");
                    continue;
                }
                string moveState = string.Empty;
                bool isValidMove;
                switch (piece)
                {
                    case 'P':
                        moveState = MovePawn
                            (chessBoard, currentX, currentY, nextX, nextY);
                        isValidMove = moveState == string.Empty;
                        sb.Append(isValidMove ? moveState : moveState + Environment.NewLine);
                        break;
                    case 'Q':
                        break;
                    case 'K':
                        break;
                    case 'B':
                        moveState = MoveBishop
                            (chessBoard, currentX, currentY, nextX, nextY);
                        isValidMove = moveState == string.Empty;
                        sb.Append(isValidMove ? moveState : moveState + Environment.NewLine);
                        break;
                    case 'R':
                        break;
                    default:
                        break;
                }
            }
            
            Console.WriteLine();
        }

        private static string MoveBishop
            (char[,] chessBoard, char currentX, char currentY, char nextX, char nextY)
        {
            int colDiff = Math.Abs(currentY - nextY);
            int rowDiff = Math.Abs(currentX - nextX);
            bool isValid = colDiff == rowDiff;
            if(!isValid)
            {
                return "Invalid move!";
            }
            if (nextX > 7 || nextY > 7)
            {
                return "Move go out of board!";
            }
            return string.Empty;
        }

        private static string MovePawn
            (char[,] board, char currentX, char currentY, char nextX, char nextY)
        {
            if (nextX != currentX -1 || nextY != currentY)
            {
                return "Invalid move!";
            }
            if (currentX == 0)
            {
                return "Move go out of board!";
            }
            return string.Empty;
        }

    }
}
