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

        public void AddAnimal(params Animal[] animals)
        {
            Animal[] _animals = new Animal[animals.Length + Animals.Length];
            Animals.CopyTo(_animals, 0);
            animals.CopyTo(_animals, 0);
            Animals = _animals;
        }
        public bool RemoveAnimal(Animal animal)
        {
            if (!Exists(animal)) return false;
            Animal[] _animals = new Animal[Animals.Length - 1];

            for(int i = 0; i < Animals.Length; i++)
            {
                if (Animals[i] != animal) _animals[i] = Animals[i];
            }
            return true;
        }
        public bool Exists(Animal animal)
        {
            foreach(Animal an in Animals)
            {
                if (an == animal) return true;
            }
            return false;
        }
    }
}
