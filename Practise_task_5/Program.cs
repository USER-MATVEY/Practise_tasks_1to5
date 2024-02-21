using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Regex chessCoordReg = new Regex(@"[a-h][1-8]");

        string knightPos = Console.ReadLine().ToLower();
        string piecePos = Console.ReadLine().ToLower();

        if (!chessCoordReg.IsMatch(knightPos) || !chessCoordReg.IsMatch(piecePos))
        {
            Console.WriteLine("Введены некорректные координаты!");
            return;
        }

        knightPos = ConvertChessCoordsToNormalCoords(knightPos);
        piecePos = ConvertChessCoordsToNormalCoords(piecePos);

        if (CoordsNotValid(knightPos, piecePos))
        {
            Console.WriteLine("Введены некорректные данные!");
            return;
        }

        if (KnightAtacks(knightPos, piecePos))
        {
            Console.WriteLine("Король может побить фигуру.");
        }
        else
        {
            Console.WriteLine("Король не может побить фигуру.");
        }
    }

    static public Boolean CoordsNotValid(string knightPosition, string otherPiecePosition)
    {
        int knightX = knightPosition[0] - '0';
        int knightY = knightPosition[1] - '0';
        int otherX = otherPiecePosition[0] - '0';
        int otherY = otherPiecePosition[1] - '0';

        if (knightPosition == otherPiecePosition) { return true; }
        if ((knightX < 0 || knightY < 0 || knightX > 8 || knightY > 8) &&
            (otherX < 0 || otherY < 0 || otherX > 8 || otherY > 8))
        { return true; }

        return false;
    }

    static public string ConvertChessCoordsToNormalCoords(string chessCoords)
    {
        int xCoord = chessCoords[0] - 'a' + 1;
        int yCoord = int.Parse(chessCoords[1].ToString());

        return new string(xCoord.ToString() + yCoord.ToString());
    }

    static public Boolean KnightAtacks(string kingPosition, string otherPiecePosition)
    {
        int knightX = Convert.ToInt32(kingPosition[0]);
        int knightY = Convert.ToInt32(kingPosition[1]);
        int otherX = Convert.ToInt32(otherPiecePosition[0]);
        int otherY = Convert.ToInt32(otherPiecePosition[1]);

        int dX = Math.Abs(knightX - otherX);
        int dY = Math.Abs(knightY - otherY);

        if ((dX == 2 && dY == 1) || (dX == 1 && dY == 2))
        {
            return true;
        }
        return false;
    }
}