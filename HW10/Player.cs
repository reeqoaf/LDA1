using System;
using System.Collections.Generic;
using System.Text;

namespace HW10
{
    public class Player
    {
        public Player Enemy { get; set; }
        public Field PlayersField { get; set; }
        public Field EnemiesField { get; set; }
        public Player()
        {
            PlayersField = new Field();
            EnemiesField = new Field();
        }
        public bool StartMove()
        {
            int hitType;
            int[] coords;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Your field:");
                PlayersField.PrintField();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n\nEnemies field:");
                EnemiesField.PrintField();
                coords = Program.EnterCell();
                hitType = Hit(coords[0], coords[1]);
                switch (hitType)
                {
                    case 0:
                        Console.WriteLine("You missed!");
                        Console.WriteLine("Press any key to end move");
                        Console.ReadKey();
                        return true;
                    case 1:
                        Console.WriteLine("You have hit!");
                        break;
                    case 2:
                        Console.WriteLine("You have hit here before! Try again");
                        break;
                }
                if (EnemiesField.CountOfAliveShipCells == 0)
                {
                    Console.WriteLine("You won! Enemy has no alive ships");
                    return false;
                }
                Console.WriteLine("Press any key to continue move");
                Console.ReadKey();
            }
            while (hitType != 0);
            return true;
        }
        public int Hit(int x, int y)
        {
            if (Enemy.PlayersField.PlayField[x, y] == CellType.Empty)
            {
                EnemiesField.PlayField[x, y] = CellType.HittedEmpty;
                Enemy.PlayersField.PlayField[x, y] = CellType.HittedEmpty;
                return 0;
            }
            else if (Enemy.PlayersField.PlayField[x, y] == CellType.Ship || Enemy.PlayersField.PlayField[x,y] == CellType.PartOfShip)
            {
                Enemy.PlayersField.PlayField[x, y] = EnemiesField.PlayField[x, y] = 
                    Enemy.PlayersField.PlayField[x, y] == CellType.Ship ? CellType.BrokenShip : CellType.BrokenPartOfShip;
                Enemy.PlayersField.CountOfAliveShipCells--;
                EnemiesField.CountOfAliveShipCells--;
                return 1;
            }
            else if (Enemy.PlayersField.PlayField[x, y] == CellType.BrokenShip || 
                Enemy.PlayersField.PlayField[x, y] == CellType.BrokenPartOfShip ||
                Enemy.PlayersField.PlayField[x, y] == CellType.HittedEmpty)
            {
                return 2;
            }
            return 0;
        }
    }
}
