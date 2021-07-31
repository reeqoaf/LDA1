using System;

namespace HW2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*int temp, number;
            int max = -1, min = 10;
            int n = 0, counter = 0;

            Console.WriteLine("1 task");
            Console.Write("Enter num: ");
            bool s1 = int.TryParse(Console.ReadLine(), out number);
            if(!s1)
            {
                Console.WriteLine("Incorrect input");
                return;
            }
            temp = number;
            while(temp > 0)
            {
                temp /= 10;
                n++;
            }
            int[] arr = new int[n];
            while(number > 0)
            {
                arr[counter++] = number % 10;
                number /= 10;
            }
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine($"{i + 1} цифра числа равна {arr[n - i - 1]}");
                if (arr[i] > max) max = arr[i];
                if (arr[i] < min) min = arr[i];
            }
            Console.WriteLine("\n2 task");
            Console.WriteLine("Наибольшая цифра числа: " + max);
            Console.WriteLine("Наименьшая цифра числа: " + min);*/

            bool s1 = false, s2 = false;
            bool temp = false;
            bool choose = false;
            double number1 = 0, number2 = 0;
            double result = 0;
            ConsoleKeyInfo op;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("3-5 task\nCalculator");

                while (true)
                {
                    if (!choose)
                    {
                        Console.Write("First: ");
                        s1 = double.TryParse(Console.ReadLine(), out number1);
                    }
                    else
                    {
                        Console.WriteLine("First: " + number1);
                    }
                    Console.Write("Second: ");
                    s2 = double.TryParse(Console.ReadLine(), out number2);
                    if (s1 && s2) break;
                    else
                    {
                        Console.WriteLine("Incorrect input! Try again");
                    }
                }

                Console.WriteLine("Choose operation:");
                Console.WriteLine("1. +");
                Console.WriteLine("2. -");
                Console.WriteLine("3. *");
                Console.WriteLine("4. /");
                Console.WriteLine("5. ^");
                Console.WriteLine("6. sqrt");
                while (!temp)
                {
                    op = Console.ReadKey();
                    temp = true;
                    switch (op.Key)
                    {
                        case ConsoleKey.D1:
                            result = number1 + number2;
                            break;
                        case ConsoleKey.D2:
                            result = number1 - number2;
                            break;
                        case ConsoleKey.D3:
                            result = number1 * number2;
                            break;
                        case ConsoleKey.D4:
                            if (number2 == 0)
                            {
                                Console.WriteLine("\nYou cant do this because 2 number is zero. Choose another operation");
                                temp = false;
                            }
                            else result = number1 / number2;
                            break;
                        case ConsoleKey.D5:
                            result = Math.Pow(number1, number2);
                            break;
                        case ConsoleKey.D6:
                            if (number2 == 0)
                            {
                                Console.WriteLine("\nYou cant do this because 2 number is zero. Choose another operation");
                                temp = false;
                            }
                            else result = Math.Pow(number1, 1 / number2);
                            break;
                        default:
                            Console.WriteLine("\nIncorrect operation! Try again");
                            temp = false;
                            break;
                    }
                }
                Console.WriteLine("\nResult: " + result.ToString());
                Console.WriteLine("Choose what to do next:");
                Console.WriteLine("1. Continue with current result");
                Console.WriteLine("2. Continue with new numbers");
                Console.WriteLine("3. Exit");
                while (temp)
                {
                    op = Console.ReadKey();
                    temp = false;
                    switch (op.Key)
                    {
                        case ConsoleKey.D1:
                            number1 = result;
                            choose = true;
                            break;
                        case ConsoleKey.D2:
                            choose = false;
                            break;
                        case ConsoleKey.D3:
                            return;
                        default:
                            Console.WriteLine("\nIncorrect choose");
                            temp = true;
                            break;
                    }
                }
            }
            
        }
    }
}
