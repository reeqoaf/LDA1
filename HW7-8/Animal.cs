﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HW7_8
{
    public abstract class Animal
    {
        public string Form { get; private set; }
        public double Weight { get; set; }
        public int Age { get; set; }
        public Aviary aviary { get; set; }
        public virtual void MakeNoise()
        {
            Console.WriteLine("Default Noise");
        }
        public Animal(string form, double weight, int age)
        {
            Form = form;
            Weight = weight;
            Age = age;
        }
    }
}
