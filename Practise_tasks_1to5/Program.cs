using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Regex chessCoordReg = new Regex(@"[a-h][1-8]");

        string rookPos = Console.ReadLine().ToLower();
        string piecePos = Console.ReadLine().ToLower();

        if (!chessCoordReg.IsMatch(rookPos) || !chessCoordReg.IsMatch(piecePos)) 
        {
            Console.WriteLine("Введены некорректные координаты!");
            return; 
        }

        rookPos = ConvertChessCoordsToNormalCoords(rookPos);
        piecePos = ConvertChessCoordsToNormalCoords(piecePos);

        if (CoordsNotValid(rookPos, piecePos)) 
        { 
            Console.WriteLine("Введены некорректные данные!");
            return; 
        }

        if (RookAtacks(rookPos, piecePos))
        {
            Console.WriteLine("Лодья может побить фигуру.");
        }
        else
        {
            Console.WriteLine("Лодья не может побить фигуру.");
        }
    }

    static public Boolean CoordsNotValid(string rookPosition, string otherPiecePosition)
    {
        int rookX = rookPosition[0] - '0';
        int rookY = rookPosition[1] - '0';
        int otherX = otherPiecePosition[0] - '0';
        int otherY = otherPiecePosition[1] - '0';   

        if (rookPosition == otherPiecePosition) { return true; }
        if ((rookX < 0 || rookY < 0 || rookX > 8 || rookY > 8) && 
            (otherX < 0 || otherY < 0 || otherX > 8 || otherY > 8))
        { return true; }

        return false;
    }

    static public string ConvertChessCoordsToNormalCoords(string chessCoords)
    {
        int xCoord = chessCoords[0] - 'a' + 1;
        int yCoord = int.Parse(chessCoords[1].ToString());

        return new string (xCoord.ToString() + yCoord.ToString());
    }

    static public Boolean RookAtacks(string rookPosition, string otherPiecePosition)
    {
        int rookX = Convert.ToInt32(rookPosition[0]);
        int rookY = Convert.ToInt32(rookPosition[1]);
        int otherX = Convert.ToInt32(otherPiecePosition[0]);
        int otherY = Convert.ToInt32(otherPiecePosition[1]);

        if (rookX == otherX || rookY == otherY)
        {
            return true;
        }
        return false;
    }
}