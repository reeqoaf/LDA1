using System;

namespace HW3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = enterSize();
            int[,] arr = new int[n, n];
            Random rand = new Random();
            int max = -1, min = 101, average = 0;

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    arr[i, j] = rand.Next(0, 100);
                    if (max < arr[i, j]) max = arr[i, j];
                    if (min > arr[i, j]) min = arr[i, j];
                    average += arr[i, j];
                }
            }
            //1
            Console.WriteLine("Matrix: ");
            printArray(arr);
            Console.WriteLine("Max number = " + max);
            Console.WriteLine("Min number = " + min);
            Console.WriteLine("Average = " + average / 25.0);

            //2
            Console.WriteLine("\nT1");
            arr = fill1(n);
            printArray(arr);
            Console.WriteLine("\nT2");
            arr = fill2(n);
            printArray(arr);
            Console.WriteLine("\nT3");
            arr = fill3(n);
            printArray(arr);
        }
        static int enterSize()
        {
            int n;
            bool temp = false;
            do
            {
                Console.Write("Enter size (2 < size < 15): ");
                if (!int.TryParse(Console.ReadLine(), out n) || n < 3 || n > 14)
                {
                    Console.WriteLine("Incorrect input");
                }
                else temp = true;
            }
            while (!temp);
            return n;
        }
        static int[,] fill0(int n)
        {
            int[,] arr = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = 0;
                }
            }
            return arr;
        }
        static int[,] fill1(int n)
        {
            int[,] arr = fill0(n);
            int counter;
            for (int i = 0; i < n / 2 + 1; i++)
            {
                counter = 1;
                for (int j = i; j < n - i; j++)
                {
                    arr[i, j] = arr[n - i - 1, j] = counter++;
                }
            }
            return arr;
        }
        static int[,] fill2(int n)
        {
            int[,] arr = fill0(n);
            for(int i = 0; i < n; i++)
            {
                arr[i, 0] = 1;
                arr[0, i] = 1;
                arr[n - 1, i] = 1;
                arr[i, n - 1] = 1;
            }
            return arr;
        }
        static int[,] fill3(int n)
        {
            int[,] arr = fill0(n);
            for (int i = 0; i < n; i++)
            {
                arr[i, n - i - 1] = 1;
                arr[i, i] = 1;
            }
            return arr;
        }

        static void printArray(int [,] arr)
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
    }
}
