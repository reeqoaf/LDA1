using System;
using System.Collections.Generic;
using System.Text;

namespace HW7_8
{
    public class Tiger : Animal
    {
        public int CountOfPaws { get; set; } // не константа потому что вдруг тигр инвалид)
        public Tiger(string form, double weight, int age, int countOfPaws = 4) : base(form, weight, age) 
        {
            CountOfPaws = countOfPaws;
        }
        public override void MakeNoise()
        {
            Console.WriteLine("Tiger's Noise");
        }
    }
}
