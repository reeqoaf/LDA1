using System;
using System.Collections.Generic;
using System.Text;

namespace HW7_8
{
    public class Aviary
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Animal[] Animals { get; private set; }

        public Aviary(string name, string description, params Animal[] animals)
        {
            Name = name;
            Description = description;
            Animals = animals;
        }
    }
}
