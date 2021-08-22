using System;
using System.Collections.Generic;
using System.Text;

namespace HW7_8
{

    public class Aviary
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Animal[] Animals { get; private set; } = new Animal[1000];
        public int AnimalsCount { get; private set; }

        public Aviary(string name, string description, params Animal[] animals)
        {
            Name = name;
            Description = description;
            animals.CopyTo(Animals, 0);
            AnimalsCount = animals.Length;
        }
        public void AddAnimal(Animal animal)
        {
            Animals[AnimalsCount++] = animal;
        }
        public bool IsExistsAnimal(Animal animal)
        {
            for(int i = 0; i < AnimalsCount; i++)
            {
                if(Animals[i] == animal)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
