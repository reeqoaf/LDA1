using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public sealed class Employee : Person, ISomething1, ISomething2
    {
        public int Prop1 { get; set; }
        public string Prop2 { get; set; }
        public double Prop3 { get; set; }

        private int myVar1;

        public int MyProperty1
        {
            get { return myVar1; }
        }

        private int myVar2;

        public int MyProperty2
        {
            get { return myVar2; }
            private set { myVar2 = value; }
        }
        public static int CountOfObjects { get; private set; }
        public int property { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Employee(int prop1, string prop2, double prop3)
        {
            if (prop1 == 1)
            {
                throw new MyException();
            }
            this.Prop1 = prop1;
            this.Prop2 = prop2;
            this.Prop3 = prop3;
            CountOfObjects++;
        }

        public void Method1()
        {
            Console.WriteLine("Method1");
        }
        public int Method2(int a, int b)
        {
            return a * b;
        }
        public static void Method3()
        {
            Console.WriteLine("Method3");
        }

        public override void AbstractMethod()
        {
            Console.WriteLine("Overrided abstract method");
        }
        public override void VirtualMethod()
        {
            Console.WriteLine("Overrided virtual method");
        }

        void ISomething1.Method()
        {
            Console.WriteLine("ISomething1.Method");
        }
        void ISomething2.Method()
        {
            Console.WriteLine("ISomething2.Method");
        }
        public override string ToString()
        {
            Console.WriteLine("ToString override");
            return base.ToString();
        }

    }
}
