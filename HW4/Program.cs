using System;

namespace HW4
{
    class Program
    {
        static void Main(string[] args)
        {
            long[,] arr1, arr2;
            int n;
            bool temp = true;
            ConsoleKeyInfo choice;
            do
            {
                Console.Clear();
                printMenu();
                Console.Write("Введите номер меню: ");
                choice = Console.ReadKey();
                Console.WriteLine();
                switch (choice.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("\n1 Матрица:");
                        arr1 = inputMatrix();
                        Console.WriteLine("\n2 Матрица:");
                        arr2 = inputMatrix();
                        if (arr1.GetLength(0) != arr2.GetLength(0) || arr1.GetLength(1) != arr2.GetLength(1))
                        {
                            Console.WriteLine("Нельзя добавлять матрицы с разным количество строк или столбиков!");
                            break;
                        }
                        Console.WriteLine("\nРезультат:");
                        printMatrix(sumMatrix(arr1, arr2));
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("\nВведите матрицу:\n ");
                        arr1 = inputMatrix();
                        Console.WriteLine();
                        n = inputNumber();
                        printMatrix(multiplyByANumber(arr1, n));
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine("\n1 Матрица:\n");
                        arr1 = inputMatrix();
                        Console.WriteLine("\n2 Матрица:\n");
                        arr2 = inputMatrix();
                        if (arr1.GetLength(1) != arr2.GetLength(0))
                        {
                            Console.WriteLine("Умножение невозможно! Количество столбцов первой матрицы не равно количеству строк второй матрицы.");
                            break;
                        }
                        Console.WriteLine("Результат:");
                        printMatrix(multMatrix(arr1, arr2));
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine("\nВведите матрицу и число");
                        arr1 = inputMatrix();
                        if(arr1.GetLength(0) != arr1.GetLength(1))
                        {
                            Console.WriteLine("Вовзводить в степень можно только квадратные матрицы!");
                            break;
                        }
                        arr2 = arr1;
                        n = inputSize();
                        for(int i = 1; i < n; i++)
                        {
                            arr1 = multMatrix(arr2, arr1);
                        }
                        Console.WriteLine("Результат:");
                        printMatrix(arr1);
                        break;
                    case ConsoleKey.D5:
                        Console.WriteLine("\nВведите матрицу");
                        arr1 = inputMatrix();
                        printMatrix(transpose(arr1));
                        break;
                    case ConsoleKey.D6:
                        temp = false;
                        break;
                    default:
                        Console.WriteLine("Нет такого пункта меню!");
                        break;
                }
                Console.WriteLine("Нажмите любую клавишу чтобы продолжить...");
                Console.ReadKey();
            }
            while (temp);
        }
        static long[,] fillRandom(int n, int m)
        {
            long[,] arr = new long[n, m];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    arr[i, j] = rand.Next(0, 15);
                }
            }
            return arr;
        }
        static long[,] inputMatrix()
        {
            Console.WriteLine("Введите количество строк");
            int n = inputSize();
            Console.WriteLine("Введите количество столбцов");
            int m = inputSize();

            long[,] arr = new long[n, m];
            Console.WriteLine("Введите матрицу: ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"Arr[{i}, {j}] = ");
                    if (!long.TryParse(Console.ReadLine(), out arr[i, j]))
                    {
                        Console.WriteLine("Некорректный ввод!");
                        j--;
                    }
                }
            }
            return arr;
        }
        static int inputSize()
        {
            int n;
            bool temp = false;
            do
            {
                Console.Write("Введите число (2 < числa < 15): ");
                if (!int.TryParse(Console.ReadLine(), out n) || n < 3 || n > 14)
                {
                    Console.WriteLine("Некорректный ввод!");
                }
                else temp = true;
            }
            while (!temp);
            return n;
        }
        static int inputNumber()
        {
            int n;
            bool temp = false;
            do
            {
                Console.Write("Введите целое число ");
                if (!int.TryParse(Console.ReadLine(), out n))
                {
                    Console.WriteLine("Некорректный ввод!");
                }
                else temp = true;
            }
            while (!temp);
            return n;
        }
        static void printMenu()
        {
            Console.WriteLine("1. Добавить 2 матрицы");
            Console.WriteLine("2. Умножение матрицы на число");
            Console.WriteLine("3. Умножение 2 матриц");
            Console.WriteLine("4. Возведение матрицы в степень");
            Console.WriteLine("5. Транспонирование матрицы");
            Console.WriteLine("6. Выход");
        }
        static void printMatrix(long[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static long[,] sumMatrix(long[,] arr1, long[,] arr2)
        {
            long[,] result = new long[arr1.GetLength(0), arr1.GetLength(1)];

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = arr1[i, j] + arr2[i, j];
                }
            }

            return result;
        }
        static long[,] multiplyByANumber(long[,] arr, int n)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] *= n;
                }
            }

            return arr;
        }

        static long[,] multMatrix(long[,] arr1, long[,] arr2)
        {
            long[,] result = new long[arr1.GetLength(0), arr2.GetLength(1)];

            for (int i = 0; i < arr1.GetLength(0); i++)
            {
                for (int j = 0; j < arr2.GetLength(1); j++)
                {
                    result[i, j] = 0;
                    for(int k = 0; k < arr1.GetLength(1); k++)
                    {
                        result[i, j] += arr1[i, k] * arr2[k, j];
                    }
                }
            }

            return result;
        }
        static long[,] transpose(long[,] arr)
        {
            long[,] result = new long[arr.GetLength(1), arr.GetLength(0)];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    result[j, i] = arr[i, j];
                }
            }
            return result;
        }
    }
}

