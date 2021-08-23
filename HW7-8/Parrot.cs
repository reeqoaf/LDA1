using HW7_8.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW7_8
{
    public class Parrot : Animal, IFlyable, ISpeakable
    {
        public string Color { get; set; }
        public Parrot(string form, double weight, int age, string color) : base(form, weight, age)
        {
            Color = color;
        }
        public override void MakeNoise()
        {
            Console.WriteLine("Parrots noise");
        }

        public void Fly()
        {
            Console.WriteLine("Parrot is flying");
        }

        public override void Move()
        {
            Console.WriteLine("Parrot is moving");
        }

        public void Speak()
        {
            Console.WriteLine("Parrot is speaking");
        }

        public override void Eat()
        {
            Console.WriteLine("Parrot is eating");
        }
    }
}
