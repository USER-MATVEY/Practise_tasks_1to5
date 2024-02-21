using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Regex chessCoordReg = new Regex(@"[a-h][1-8]");

        string kingPos = Console.ReadLine().ToLower();
        string piecePos = Console.ReadLine().ToLower();

        if (!chessCoordReg.IsMatch(kingPos) || !chessCoordReg.IsMatch(piecePos))
        {
            Console.WriteLine("Введены некорректные координаты!");
            return;
        }

        kingPos = ConvertChessCoordsToNormalCoords(kingPos);
        piecePos = ConvertChessCoordsToNormalCoords(piecePos);

        if (CoordsNotValid(kingPos, piecePos))
        {
            Console.WriteLine("Введены некорректные данные!");
            return;
        }

        if (KingAtacks(kingPos, piecePos))
        {
            Console.WriteLine("Король может побить фигуру.");
        }
        else
        {
            Console.WriteLine("Король не может побить фигуру.");
        }
    }

    static public Boolean CoordsNotValid(string kingPosition, string otherPiecePosition)
    {
        int kingX = kingPosition[0] - '0';
        int kingY = kingPosition[1] - '0';
        int otherX = otherPiecePosition[0] - '0';
        int otherY = otherPiecePosition[1] - '0';

        if (kingPosition == otherPiecePosition) { return true; }
        if ((kingX < 0 || kingY < 0 || kingX > 8 || kingY > 8) &&
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

    static public Boolean KingAtacks(string kingPosition, string otherPiecePosition)
    {
        int kingX = Convert.ToInt32(kingPosition[0]);
        int kingY = Convert.ToInt32(kingPosition[1]);
        int otherX = Convert.ToInt32(otherPiecePosition[0]);
        int otherY = Convert.ToInt32(otherPiecePosition[1]);

        if (Math.Abs(kingX - otherX) == 1 || Math.Abs(kingY - otherY) == 1)
        {
            return true;
        }
        return false;
    }
}