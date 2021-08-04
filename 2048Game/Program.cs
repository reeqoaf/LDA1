using System;

namespace LDA1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] field = new int[4, 4];
            int score = 0;
            bool canMove = true;
            bool gameOver = false;
            generateField(field);
            updateField(field);
            while (!gameOver)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nPress w, a, s or d");
                score = getKey(field, score, out canMove);
                if(canMove) score = placeNewNumber(field, score);
                gameOver = isGameOver(field);
                updateField(field);
            }
            Console.WriteLine("Game Over! Your score: " + score);
            Console.ReadLine();

        }

        static void updateField(int[,] field)
        {
            Console.Clear();
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    changeColor(field[i, j]);
                    Console.Write(field[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        static void changeColor(int value)
        {
            switch (value)
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 8:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case 16:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case 32:
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;
                case 64:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 128:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case 256:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 512:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case 1024:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 2048:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                default:
                    Console.ResetColor();
                    break;
            }
        }
        static void generateField(int[,] field)
        {
            Random rand = new Random();
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = 0;
                }
            }
            int number = (rand.Next(0, 2) == 0 ? 2 : 4);
            field[rand.Next(0, field.GetLength(1)), rand.Next(0, field.GetLength(0))] = number;

            number = (rand.Next(0, 2) == 0 ? 2 : 4);
            field[rand.Next(0, field.GetLength(1)), rand.Next(0, field.GetLength(0))] = number;
        }
        static bool isGameOver(int[,] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] == 0) return false;
                }
            }
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (j + 1 != field.GetLength(1) && field[i, j] == field[i, j + 1]) return false;
                    if (j - 1 != -1 && field[i, j] == field[i, j - 1]) return false;
                    if (i + 1 != field.GetLength(0) && field[i + 1, j] == field[i, j]) return false;
                    if (i - 1 != -1 && field[i - 1, j] == field[i, j]) return false;
                }
            }

            return true;
        }

        static int placeNewNumber(int[,] field, int score)
        {
            Random rand = new Random();
            int x, y;
            int number = (rand.Next(0, 2) == 0 ? 2 : 4);
            score += number;
            bool temp = true;
            do
            {
                x = rand.Next(0, 4);
                y = rand.Next(0, 4);
                if (field[x, y] == 0)
                {
                    field[x, y] = number;
                    temp = false;
                }
            }
            while (temp);
            return score;
        }
        static int getKey(int[,] field, int score, out bool canMove)
        {
            canMove = false;
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.W:
                    moveTop(field, score, out canMove);
                    break;
                case ConsoleKey.A:
                    moveLeft(field, score, out canMove);
                    break;
                case ConsoleKey.S:
                    moveBottom(field, score, out canMove);
                    break;
                case ConsoleKey.D:
                    moveRight(field, score, out canMove);
                    break;
                default:
                    break;
            }
            return score;
        }
        static void moveLeft(int[,] field, int score, out bool canMove)
        {
            canMove = false;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < field.GetLength(1); j++)
                {
                    while (field[i, j] != 0 && field[i, j - 1] == 0)
                    {
                        field[i, j - 1] = field[i, j];
                        field[i, j] = 0;
                        if (j > 1) j--;
                        canMove = true;
                    }
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < field.GetLength(1) - 1; j++)
                {
                    if (field[i, j] != 0 && field[i, j + 1] == field[i, j])
                    {
                        field[i, j] += field[i, j + 1];
                        score += field[i, j + 1];
                        field[i, j + 1] = 0;
                        canMove = true;

                    }
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < field.GetLength(1); j++)
                {
                    while (field[i, j] != 0 && field[i, j - 1] == 0)
                    {
                        field[i, j - 1] = field[i, j];
                        field[i, j] = 0;
                        if (j > 1) j--;
                    }
                }
            }
        }
        static void moveRight(int[,] field, int score, out bool canMove)
        {
            canMove = false;
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = field.GetLength(1) - 2; j >= 0; j--)
                {
                    while (field[i, j] != 0 && field[i, j + 1] == 0)
                    {
                        field[i, j + 1] = field[i, j];
                        field[i, j] = 0;
                        if (j < 2) j++;
                        canMove = true;
                    }
                }
            }
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = field.GetLength(1) - 1; j > 0; j--)
                {
                    if (field[i, j] != 0 && field[i, j - 1] == field[i, j])
                    {
                        field[i, j] += field[i, j - 1];
                        score += field[i, j - 1];
                        field[i, j - 1] = 0;
                        canMove = true;
                    }
                }
            }
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = field.GetLength(1) - 2; j >= 0; j--)
                {
                    while (field[i, j] != 0 && field[i, j + 1] == 0)
                    {
                        field[i, j + 1] = field[i, j];
                        field[i, j] = 0;
                        if (j < 2)
                            j++;
                    }
                }
            }
        }


        static void moveTop(int[,] field, int score, out bool canMove)
        {
            canMove = false;
            for (int i = 1; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    while (field[i, j] != 0 && field[i - 1, j] == 0)
                    {
                        field[i - 1, j] = field[i, j];
                        field[i, j] = 0;
                        if (i > 1) i--;
                        canMove = true;
                    }
                }
            }
            for (int i = 0; i < field.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] != 0 && field[i + 1, j] == field[i, j])
                    {
                        field[i, j] += field[i + 1, j];
                        score += field[i + 1, j];
                        field[i + 1, j] = 0;
                        canMove = true;
                    }
                }
            }
            for (int i = 1; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    while (field[i, j] != 0 && field[i - 1, j] == 0)
                    {
                        field[i - 1, j] = field[i, j];
                        field[i, j] = 0;
                        if (i > 1) i--;
                    }
                }
            }
        }
        static void moveBottom(int[,] field, int score, out bool canMove)
        {
            canMove = false;
            for (int i = field.GetLength(1) - 2; i >= 0; i--)
            {
                for (int j = 0; j < 4; j++)
                {
                    while (field[i, j] != 0 && field[i + 1, j] == 0)
                    {
                        field[i + 1, j] = field[i, j];
                        field[i, j] = 0;
                        if (i < 2) i++;
                        canMove = true;
                    }
                }
            }
            for (int i = field.GetLength(0) - 1; i > 0; i--)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] != 0 && field[i - 1, j] == field[i, j])
                    {
                        field[i, j] += field[i - 1, j];
                        score += field[i - 1, j];
                        field[i - 1, j] = 0;
                        canMove = true;
                    }
                }
            }
            for (int i = field.GetLength(0) - 2; i >= 0; i--)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    while (field[i, j] != 0 && field[i + 1, j] == 0)
                    {
                        field[i + 1, j] = field[i, j];
                        field[i, j] = 0;
                        if (i < 2) i++;
                    }
                }
            }
        }
    }
}
