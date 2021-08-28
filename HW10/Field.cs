using System;
using System.Collections.Generic;
using System.Text;

namespace HW10
{
    public class Field
    {
        public static string Letters { get; } = "ABCDEFGHIJ";
        public List<Ship> Ships { get; set; }
        public CellType[,] PlayField { get; set; }
        public int CountOfAliveShipCells { get; set; }
        public Field()
        {
            PlayField = new CellType[10, 10];
            Ships = new List<Ship>();
        }
        public void PrintField()
        {
            Console.ResetColor();
            Console.WriteLine("\tA\tB\tC\tD\tE\tF\tG\tH\tI\tJ");
            for(int i = 0; i < PlayField.GetLength(0); i++)
            {
                Console.ResetColor();
                Console.Write($"{i + 1}\t");
                for (int j = 0; j < PlayField.GetLength(1); j++)
                {
                    Console.Write(GetCell(PlayField[i, j]) + "\t");
                }
                Console.WriteLine();
            }
        }
        private string GetCell(CellType cell)
        {
            switch (cell)
            {
                case CellType.Empty:
                    Console.ForegroundColor = ConsoleColor.White;
                    return "-";
                case CellType.HittedEmpty:
                    Console.ForegroundColor = ConsoleColor.Green;
                    return "-";
                case CellType.Ship:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    return "+";
                case CellType.PartOfShip:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    return "+";
                case CellType.BrokenShip:
                    Console.ForegroundColor = ConsoleColor.Red;
                    return "x";
                case CellType.BrokenPartOfShip:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    return "x";
                default:
                    return "";
            }
        }
        public bool PlaceShip(int x, int y, int shipsize, bool orientation)
        {
            if(x < 0 || y < 0 || x >= PlayField.GetLength(0) || y > PlayField.GetLength(1))
            {
                return false;
            }
            if((orientation && x + shipsize - 1 >= PlayField.GetLength(0)) ||
                (!orientation && y + shipsize - 1 >= PlayField.GetLength(1)))
            {
                return false;
            }
            for (int i = 0; i < shipsize; i++)
            {
                if((orientation && PlayField[x + i, y] != CellType.Empty) ||
                    (!orientation && PlayField[x, y + i] != CellType.Empty))
                {
                    return false;
                }
            }
            CountOfAliveShipCells += shipsize;
            Ships.Add(new Ship(shipsize, x, y, orientation));
            if (shipsize == 1)
            {
                PlayField[x, y] = CellType.Ship;
                return true;
            }
            while (shipsize > 0)
            {
                PlayField[x, y] = CellType.PartOfShip;
                shipsize--;
                if(orientation)
                {
                    x++;
                }
                else
                {
                    y++;
                }
            }
            return true;
        }

    }
}
