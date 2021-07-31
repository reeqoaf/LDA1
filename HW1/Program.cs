using System;

namespace HW1
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c, d;
            bool s1, s2, s3;
            string result, name;
            Console.Write("Enter your name: ");
            name = Console.ReadLine();
            Console.WriteLine("Hello, " + name);

            Console.WriteLine("Ax^2 + Bx + C = 0");
            Console.Write("Enter A: ");
            s1 = double.TryParse(Console.ReadLine(), out a);
            Console.Write("Enter B: ");
            s2 = double.TryParse(Console.ReadLine(), out b);
            Console.Write("Enter C: ");
            s3 = double.TryParse(Console.ReadLine(), out c);

            if(!s1 && !s2 && !s3)
            {
                Console.WriteLine("Incorrect input");
            }
            else
            {
                if(a == 0)
                {
                    result = "x = " + (-c / b); 
                }
                else
                {
                    d = (b * b - 4 * a * c);
                    if (d < 0) result = "No roots (D < 0)";
                    else if(d == 0)
                    {
                        result = "x = " + (-b / 2 * a);
                    }
                    else
                    {
                        result = "x1 = " + ((-b + Math.Sqrt(d)) / 2 * a);
                        result += "\nx2 = " + ((-b - Math.Sqrt(d)) / 2 * a);
                    }
                }
                Console.WriteLine(result);
            }

            Console.WriteLine("\nEnter sides of triangle");
            Console.Write("Enter side A: ");
            s1 = double.TryParse(Console.ReadLine(), out a);
            Console.Write("Enter side B: ");
            s2 = double.TryParse(Console.ReadLine(), out b);
            if (!s1 && !s2)
            {
                Console.WriteLine("Incorrect input");
            }
            else if(a <= 0 || b <= 0)
            {
                Console.WriteLine("Side cant be less or equals to 0");
            }
            else
            {
                c = Math.Sqrt(a * a + b * b);
                Console.WriteLine("C = " + c);

                Console.WriteLine("\nAngles: 90 " + 
                Math.Round(Math.Asin(b / c) * 180 / Math.PI, 2) + " " + 
                Math.Round(Math.Asin(a / c) * 180 / Math.PI, 2));
            }

            Console.WriteLine("\nPress any key to quit");
            Console.ReadKey();
        }
    }
}
