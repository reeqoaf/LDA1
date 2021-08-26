using System;

namespace HW10
{
    public class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player();
            Player player2 = new Player();
            player1.Enemy = player2;
            player2.Enemy = player1;
            bool gameIsNotOver = true;
            StartGame(player1, player2);
            player1.EnemiesField.CountOfAliveShipCells = player1.PlayersField.CountOfAliveShipCells;
            player2.EnemiesField.CountOfAliveShipCells = player2.PlayersField.CountOfAliveShipCells;

            do
            {
                Console.WriteLine("Player1's move");
                gameIsNotOver = player1.StartMove();
                if(!gameIsNotOver)
                {
                    break;
                }
                Console.WriteLine("Player2's move");
                gameIsNotOver = player2.StartMove();
                
            } while (gameIsNotOver);
            Console.WriteLine();

        }
        public static void StartGame(Player player1, Player player2)
        {
            Console.WriteLine("Welcome to see battle!");
            Console.WriteLine("Player1 is starting with placing ships");
            Console.WriteLine("Press any key to start");
            Console.ReadKey();
            Console.WriteLine();
            Console.ResetColor();
            GeneratePlayerField(player1);
            Console.WriteLine("Okay now player2 is placing his ships");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.WriteLine();
            Console.ResetColor();
            GeneratePlayerField(player2);
            Console.ResetColor();
            Console.Clear();
            Console.WriteLine("Now we start the game, player1 will be first");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.WriteLine();
            Console.Clear();
        }
        public static void GeneratePlayerField(Player player)
        {
            bool check;

            Console.WriteLine("Place your ships (Notice! You choose start field and orientation of your ship)");

            for(int k = 1; k <= 4; k++)
            {
                Console.WriteLine($"Place {5-k} ships with {k} length");
                for (int i = k; i <= 4; i++)
                {
                    player.PlayersField.PrintField();
                    int[] coords = EnterCell();
                    bool orientation = EnterOrienation();
                    check = player.PlayersField.PlaceShip(coords[0], coords[1], k, orientation);
                    if(!check)
                    {
                        i--;
                        Console.WriteLine("You can't place ship here! Press any key to continue");
                        Console.ReadKey();                        Console.WriteLine();                        Console.Clear();                        continue;                    }
                    Console.Clear();
                }
                Console.Clear();
            }
        }
        public static bool EnterOrienation()
        {
            bool result = true;
            bool temp = true;
            ConsoleKeyInfo input;
            do
            {
                Console.WriteLine("Enter orientation: ");
                Console.WriteLine("1 - horizontal");
                Console.WriteLine("2 - vertical");
                input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        result = false;
                        temp = false;
                        break;
                    case ConsoleKey.D2:
                        result = true;
                        temp = false;
                        break;
                    default:
                        Console.WriteLine("\nIncorrect input!");
                        break;
                }

            } while (temp);
            Console.WriteLine();
            return result;
        }
        public static int[] EnterCell()
        {
            bool temp = true;
            string input;
            int x = 0;
            int y = 0;
            Console.WriteLine("Enter cell (for example B2)");
            do
            {
                input = Console.ReadLine();

                if ((input.Length > 3) || (input.Length == 0) ||
                    (input.Length == 3 && input[1].ToString() + input[2].ToString() != "10") ||
                    (Field.Letters.IndexOf(input[0].ToString()) == -1) ||
                    !int.TryParse(input[1].ToString(), out y) ||
                    y == 0
                    )
                {
                    Console.WriteLine("Incorrect input");
                    continue;
                }
                else
                {
                    temp = false;
                }
            } while (temp);
            x = Field.Letters.IndexOf(Char.ToUpper(input[0]).ToString());
            if (input.Length == 3)
            {
                y = 10;
            }
            return new int[] { y - 1, x };
        }

    }
}
