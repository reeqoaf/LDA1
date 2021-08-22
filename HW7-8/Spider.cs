using System;
using System.Collections.Generic;
using System.Text;

namespace HW7_8
{
    public class Spider : Animal
    {
        public bool IsPoisonous { get; set; }

        public Spider(string form, double weight, int age, bool isPoisonous) : base(form, weight, age)
        {
            IsPoisonous = isPoisonous;
        }
        public override void MakeNoise()
        {
            Console.WriteLine("Spider's Noise");
        }
    }
}
