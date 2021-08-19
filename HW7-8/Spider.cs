using System;
using System.Collections.Generic;
using System.Text;

namespace HW7_8
{
    public class Spider : Animal
    {
        public bool IsPoisonous { get; set; }
        public int CountOfPaws { get; set; }

        public Spider(string form, double weight, int age, bool isPoisonous, int countOfPaws) : base(form, weight, age)
        {
            IsPoisonous = isPoisonous;
            CountOfPaws = countOfPaws;
        }
        public override void MakeNoise()
        {
            Console.WriteLine("Spider's Noise");
        }
    }
}
