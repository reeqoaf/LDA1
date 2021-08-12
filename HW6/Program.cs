using System;

namespace HW6
{
    class Program
    {
        static Player player;
        static Enemy[] enemies = new Enemy[2];
        static int resources = 0;
        const int resourceKey = 15;

        static void Main(string[] args)
        {
            Random rand = new Random();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Cell[,] field = new Cell[5, 5];


            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int k = 0; k < field.GetLength(1); k++)
                {
                    field[i, k] = new Cell(Cell.Type.FreeCell);
                }
            }

            player = new Player("\u263A", rand.Next(0, field.GetLength(0)), rand.Next(0, field.GetLength(1)));
            field[player.x, player.y].CellType = Cell.Type.PlayerCell;

            for (int i = 0; i < enemies.Length; i++)
            {
                int x, y;
                do
                {
                    x = rand.Next(0, field.GetLength(0));
                    y = rand.Next(0, field.GetLength(1));
                }
                while (field[x, y].CellType != Cell.Type.FreeCell);
                enemies[i] = new Enemy("\u263A", x, y);
                field[x, y].CellType = Cell.Type.EnemyCell;
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
            while (field[x, y].CellType != Cell.Type.FreeCell);
            field[x, y].CellType = Cell.Type.ResourceCell;
        }
        static void checkCollisionWithResources(Cell[,] field, int direct)
        {
            switch(direct)
            {
                case 0 when field[player.x - 1, player.y].CellType == Cell.Type.ResourceCell:
                    resources++;
                    break;
                case 1 when field[player.x, player.y - 1].CellType == Cell.Type.ResourceCell:
                    resources++;
                    break;
                case 2 when field[player.x + 1, player.y].CellType == Cell.Type.ResourceCell:
                    resources++;
                    break;
                case 3 when field[player.x, player.y + 1].CellType == Cell.Type.ResourceCell:
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

        static string GetCellView(Cell.Type value)
        {
            switch(value)
            {
                case Cell.Type.PlayerCell:
                    Console.ForegroundColor = ConsoleColor.Green;
                    return player.playerView;
                case Cell.Type.EnemyCell:
                    Console.ForegroundColor = ConsoleColor.Red;
                    return enemies[0].enemyView;
                case Cell.Type.ResourceCell:
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

            field[player.x, player.y].CellType = Cell.Type.FreeCell;

            switch (direct)
            {
                case 0 when player.x > 0 && field[player.x - 1, player.y].CellType != Cell.Type.EnemyCell: // u
                    checkCollisionWithResources(field, direct);
                    player.x--;
                    break;
                case 1 when player.y > 0 && field[player.x, player.y - 1].CellType != Cell.Type.EnemyCell: // l
                    checkCollisionWithResources(field, direct);
                    player.y--;
                    break;
                case 2 when player.x < field.GetLength(0) - 1 && field[player.x + 1, player.y].CellType != Cell.Type.EnemyCell: // d
                    checkCollisionWithResources(field, direct);
                    player.x++;
                    break;
                case 3 when player.y < field.GetLength(1) - 1 && field[player.x, player.y + 1].CellType != Cell.Type.EnemyCell: // r
                    checkCollisionWithResources(field, direct);
                    player.y++;
                    break;
                default:
                    break;
            }

            field[player.x, player.y].CellType = Cell.Type.PlayerCell;
        }
        static void MoveEnemy(Cell[,] field, Enemy enemy, int direct)
        {
            field[enemy.x, enemy.y].CellType = Cell.Type.FreeCell;

            switch (direct)
            {
                case 0 when enemy.x > 0 && field[enemy.x - 1, enemy.y].CellType == Cell.Type.FreeCell: // u
                    enemy.x--;
                    break;
                case 1 when enemy.y > 0 && field[enemy.x, enemy.y - 1].CellType == Cell.Type.FreeCell: // l
                    enemy.y--;
                    break;
                case 2 when enemy.x < field.GetLength(0) - 1 && field[enemy.x + 1, enemy.y].CellType == Cell.Type.FreeCell: // d
                    enemy.x++;
                    break;
                case 3 when enemy.y < field.GetLength(1) - 1 && field[enemy.x, enemy.y + 1].CellType == Cell.Type.FreeCell: // r
                    enemy.y++;
                    break;
                default:
                    break;
            }

            field[enemy.x, enemy.y].CellType = Cell.Type.EnemyCell;
        }
    }
}
