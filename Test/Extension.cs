using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public static class Extension
    {
        public static void ExtensionMethod(this Employee employee)
        {
            Console.WriteLine("Extension method");
        }
    }
}
