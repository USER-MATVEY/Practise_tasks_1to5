using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Regex chessCoordReg = new Regex(@"[a-h][1-8]");

        string bishopPos = Console.ReadLine().ToLower();
        string piecePos = Console.ReadLine().ToLower();

        if (!chessCoordReg.IsMatch(bishopPos) || !chessCoordReg.IsMatch(piecePos))
        {
            Console.WriteLine("Введены некорректные координаты!");
            return;
        }

        bishopPos = ConvertChessCoordsToNormalCoords(bishopPos);
        piecePos = ConvertChessCoordsToNormalCoords(piecePos);

        if (CoordsNotValid(bishopPos, piecePos))
        {
            Console.WriteLine("Введены некорректные данные!");
            return;
        }

        if (BishopAtacks(bishopPos, piecePos))
        {
            Console.WriteLine("Слон может побить фигуру.");
        }
        else
        {
            Console.WriteLine("Слон не может побить фигуру.");
        }
    }

    static public Boolean CoordsNotValid(string bishopPosition, string otherPiecePosition)
    {
        int bishopX = bishopPosition[0] - '0';
        int bishopY = bishopPosition[1] - '0';
        int otherX = otherPiecePosition[0] - '0';
        int otherY = otherPiecePosition[1] - '0';

        if (bishopPosition == otherPiecePosition) { return true; }
        if ((bishopX < 0 || bishopY < 0 || bishopX > 8 || bishopY > 8) &&
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

    static public Boolean BishopAtacks(string bishopPosition, string otherPiecePosition)
    {
        int bishopX = Convert.ToInt32(bishopPosition[0]);
        int bishopY = Convert.ToInt32(bishopPosition[1]);
        int otherX = Convert.ToInt32(otherPiecePosition[0]);
        int otherY = Convert.ToInt32(otherPiecePosition[1]);

        if (Math.Abs(bishopX - otherX) == Math.Abs(bishopY - otherY))
        {
            return true;
        }
        return false;
    }
}