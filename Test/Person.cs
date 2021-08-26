using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public abstract class Person
    {
        public abstract void AbstractMethod();
        public virtual void VirtualMethod()
        {
            Console.WriteLine("Abstract method");
        }
    }
}
