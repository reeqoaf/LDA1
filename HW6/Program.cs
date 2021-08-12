using System;

namespace HW6
{
    class Program
    {
        static Player player;
        static Enemy[] enemies = new Enemy[2];
        static int resources = 0;

        static void Main(string[] args)
        {
            Random rand = new Random();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Cell[,] field = new Cell[5, 5];


            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int k = 0; k < field.GetLength(1); k++)
                {
                    field[i, k] = new Cell(CellType.FreeCell);
                }
            }

            player = new Player("\u263A", rand.Next(0, field.GetLength(0)), rand.Next(0, field.GetLength(1)));
            field[player.x, player.y].CellType = CellType.PlayerCell;

            for (int i = 0; i < enemies.Length; i++)
            {
                int x, y;
                do
                {
                    x = rand.Next(0, field.GetLength(0));
                    y = rand.Next(0, field.GetLength(1));
                }
                while (field[x, y].CellType != CellType.FreeCell);
                enemies[i] = new Enemy("\u263A", x, y);
                field[x, y].CellType = CellType.EnemyCell;
            }

            while (true)
            {
                Render(field);

                Console.WriteLine("\nCount of resources = " + resources + "\n");

                MovePlayer(field, GetDirection());

                foreach (var enemy in enemies)
                {
                    MoveEnemy(field, enemy, rand.Next(0, field.GetLength(0)));
                }
                if (rand.Next(0, 5) == 0) addResource(field);
            }
        }

        static void addResource(Cell[,] field)
        {
            Random rand = new Random();
            int x, y;
            do
            {
                x = rand.Next(0, field.GetLength(0));
                y = rand.Next(0, field.GetLength(1));
            }
            while (field[x, y].CellType != CellType.FreeCell);
            field[x, y].CellType = CellType.ResourceCell;
        }
        static void checkCollisionWithResources(Cell[,] field, int direct)
        {
            switch(direct)
            {
                case 0 when field[player.x - 1, player.y].CellType == CellType.ResourceCell:
                    resources++;
                    break;
                case 1 when field[player.x, player.y - 1].CellType == CellType.ResourceCell:
                    resources++;
                    break;
                case 2 when field[player.x + 1, player.y].CellType == CellType.ResourceCell:
                    resources++;
                    break;
                case 3 when field[player.x, player.y + 1].CellType == CellType.ResourceCell:
                    resources++;
                    break;

            }
        }

        static void Render(Cell[,] field)
        {
            Console.Clear();

            string sep = new string('_', field.GetLength(1) * 8 + 1);

            for (int i = 0; i < field.GetLength(0); i++)
            {
                Console.WriteLine(sep);
                for (int k = 0; k < field.GetLength(1); k++)
                {
                    Console.Write("|   ");
                    Console.Write(GetCellView(field[i, k].CellType) + "\t");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine("|");
            }
            Console.WriteLine(sep);
        }

        static string GetCellView(CellType value)
        {
            switch(value)
            {
                case CellType.PlayerCell:
                    Console.ForegroundColor = ConsoleColor.Green;
                    return player.playerView;
                case CellType.EnemyCell:
                    Console.ForegroundColor = ConsoleColor.Red;
                    return enemies[0].EnemyView;
                case CellType.ResourceCell:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    return "+";
                default:
                    return "";
            }
        }

        // w - 0, a - 1, s - 2, d - 3

        static int GetDirection()
        {
            ConsoleKey[] possibleKeys = { ConsoleKey.W, ConsoleKey.A, ConsoleKey.S, ConsoleKey.D };
            do
            {
                Console.Write("Input direction: ");
                ConsoleKeyInfo input = Console.ReadKey();
                Console.WriteLine();

                for (int i = 0; i < possibleKeys.Length; i++)
                {
                    if (input.Key == possibleKeys[i])
                    {
                        return i;
                    }
                }

                Console.WriteLine("Wrong input.");
            }
            while (true);
        }

        static void MovePlayer(Cell[,] field, int direct)
        {

            field[player.x, player.y].CellType = CellType.FreeCell;

            switch (direct)
            {
                case 0 when player.x > 0 && field[player.x - 1, player.y].CellType != CellType.EnemyCell: // u
                    checkCollisionWithResources(field, direct);
                    player.x--;
                    break;
                case 1 when player.y > 0 && field[player.x, player.y - 1].CellType != CellType.EnemyCell: // l
                    checkCollisionWithResources(field, direct);
                    player.y--;
                    break;
                case 2 when player.x < field.GetLength(0) - 1 && field[player.x + 1, player.y].CellType != CellType.EnemyCell: // d
                    checkCollisionWithResources(field, direct);
                    player.x++;
                    break;
                case 3 when player.y < field.GetLength(1) - 1 && field[player.x, player.y + 1].CellType != CellType.EnemyCell: // r
                    checkCollisionWithResources(field, direct);
                    player.y++;
                    break;
                default:
                    break;
            }

            field[player.x, player.y].CellType = CellType.PlayerCell;
        }
        static void MoveEnemy(Cell[,] field, Enemy enemy, int direct)
        {
            field[enemy.X, enemy.Y].CellType = CellType.FreeCell;

            switch (direct)
            {
                case 0 when enemy.X > 0 && field[enemy.X - 1, enemy.Y].CellType == CellType.FreeCell: // u
                    enemy.X--;
                    break;
                case 1 when enemy.Y > 0 && field[enemy.X, enemy.Y - 1].CellType == CellType.FreeCell: // l
                    enemy.Y--;
                    break;
                case 2 when enemy.X < field.GetLength(0) - 1 && field[enemy.X + 1, enemy.Y].CellType == CellType.FreeCell: // d
                    enemy.X++;
                    break;
                case 3 when enemy.Y < field.GetLength(1) - 1 && field[enemy.X, enemy.Y + 1].CellType == CellType.FreeCell: // r
                    enemy.Y++;
                    break;
                default:
                    break;
            }

            field[enemy.X, enemy.Y].CellType = CellType.EnemyCell;
        }
    }
}
