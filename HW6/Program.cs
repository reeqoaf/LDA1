using System;

namespace HW6
{
    class Program
    {
        static Player player;
        static Enemy[] enemies = new Enemy[3];

        static void Main(string[] args)
        {
            Random rand = new Random();
            Console.ForegroundColor = ConsoleColor.Yellow;

            int[,] field = new int[5, 5];

            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int k = 0; k < field.GetLength(1); k++)
                {
                    field[i, k] = 0;
                }
            }

            player = new Player("\u263A", rand.Next(0, field.GetLength(0)), rand.Next(0, field.GetLength(1)));
            field[player.x, player.y] = Player.playerKey;

            for (int i = 0; i < enemies.Length; i++)
            {
                int x, y;
                do
                {
                    x = rand.Next(0, field.GetLength(0));
                    y = rand.Next(0, field.GetLength(1));
                }
                while (field[x, y] != 0);
                enemies[i] = new Enemy("\u263A", x, y);
                field[x, y] = Enemy.enemyKey;
            }

            while (true)
            {
                Render(field);

                MovePlayer(field, GetDirection());

                foreach (var enemy in enemies)
                {
                    MoveEnemy(field, enemy, rand.Next(0, field.GetLength(0)));
                }
            }
        }

        static void Render(int[,] field)
        {
            Console.Clear();

            string sep = new string('_', field.GetLength(1) * 8 + 1);

            for (int i = 0; i < field.GetLength(0); i++)
            {
                Console.WriteLine(sep);
                for (int k = 0; k < field.GetLength(1); k++)
                {
                    Console.Write("|   ");
                    Console.Write(GetCellView(field[i, k]) + "\t");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine("|");
            }
            Console.WriteLine(sep);
        }

        static string GetCellView(int value)
        {
            switch(value)
            {
                case Player.playerKey:
                    Console.ForegroundColor = ConsoleColor.Green;
                    return player.playerView;
                case Enemy.enemyKey:
                    Console.ForegroundColor = ConsoleColor.Red;
                    return enemies[0].enemyView;
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

        static void MovePlayer(int[,] field, int direct)
        {

            field[player.x, player.y] = 0;

            switch (direct)
            {
                case 0 when player.x > 0 && field[player.x - 1, player.y] == 0: // u
                    player.x--;
                    break;
                case 1 when player.y > 0 && field[player.x, player.y - 1] == 0: // l
                    player.y--;
                    break;
                case 2 when player.x < field.GetLength(0) - 1 && field[player.x + 1, player.y] == 0: // d
                    player.x++;
                    break;
                case 3 when player.y < field.GetLength(1) - 1 && field[player.x, player.y + 1] == 0: // r
                    player.y++;
                    break;
                default:
                    break;
            }

            field[player.x, player.y] = Player.playerKey;
        }
        static void MoveEnemy(int[,] field, Enemy enemy, int direct)
        {
            field[enemy.x, enemy.y] = 0;

            switch (direct)
            {
                case 0 when enemy.x > 0 && field[enemy.x - 1, enemy.y] == 0: // u
                    enemy.x--;
                    break;
                case 1 when enemy.y > 0 && field[enemy.x, enemy.y - 1] == 0: // l
                    enemy.y--;
                    break;
                case 2 when enemy.x < field.GetLength(0) - 1 && field[enemy.x + 1, enemy.y] == 0: // d
                    enemy.x++;
                    break;
                case 3 when enemy.y < field.GetLength(1) - 1 && field[enemy.x, enemy.y + 1] == 0: // r
                    enemy.y++;
                    break;
                default:
                    break;
            }

            field[enemy.x, enemy.y] = Enemy.enemyKey;
        }
    }
}
