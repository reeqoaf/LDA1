using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee;
            try
            {
                employee = new Employee(1, "2", 3);
            }
            catch(MyException)
            {
                Console.WriteLine("Exception");
            }
        }
    }
}
