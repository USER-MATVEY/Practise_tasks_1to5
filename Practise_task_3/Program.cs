using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Regex chessCoordReg = new Regex(@"[a-h][1-8]");

        string queenPos = Console.ReadLine().ToLower();
        string piecePos = Console.ReadLine().ToLower();

        if (!chessCoordReg.IsMatch(queenPos) || !chessCoordReg.IsMatch(piecePos))
        {
            Console.WriteLine("Введены некорректные координаты!");
            return;
        }

        queenPos = ConvertChessCoordsToNormalCoords(queenPos);
        piecePos = ConvertChessCoordsToNormalCoords(piecePos);

        if (CoordsNotValid(queenPos, piecePos))
        {
            Console.WriteLine("Введены некорректные данные!");
            return;
        }

        if (QueenAtacks(queenPos, piecePos))
        {
            Console.WriteLine("Ферзь может побить фигуру.");
        }
        else
        {
            Console.WriteLine("Ферзь не может побить фигуру.");
        }
    }

    static public Boolean CoordsNotValid(string queenPosition, string otherPiecePosition)
    {
        int queenX = queenPosition[0] - '0';
        int queenY = queenPosition[1] - '0';
        int otherX = otherPiecePosition[0] - '0';
        int otherY = otherPiecePosition[1] - '0';

        if (queenPosition == otherPiecePosition) { return true; }
        if ((queenX < 0 || queenY < 0 || queenX > 8 || queenY > 8) &&
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

    static public Boolean QueenAtacks(string queenPosition, string otherPiecePosition)
    {
        int queenX = Convert.ToInt32(queenPosition[0]);
        int queenY = Convert.ToInt32(queenPosition[1]);
        int otherX = Convert.ToInt32(otherPiecePosition[0]);
        int otherY = Convert.ToInt32(otherPiecePosition[1]);

        if (Math.Abs(queenX - otherX) == Math.Abs(queenY - otherY) || 
            (queenX == otherX || queenY == otherY))
        {
            return true;
        }
        return false;
    }
}