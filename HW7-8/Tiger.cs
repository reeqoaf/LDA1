using System;
using System.Collections.Generic;
using System.Text;

namespace HW7_8
{
    public class Tiger : Animal
    {
        public Tiger(string form, double weight, int age) : base(form, weight, age) 
        {

        }

        public override void Eat()
        {
            Console.WriteLine("Tiger is eating");
        }

        public override void MakeNoise()
        {
            Console.WriteLine("Tiger's Noise");
        }

        public override void Move()
        {
            Console.WriteLine("Tiger is moving");
        }
    }
}
