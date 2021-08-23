using HW7_8.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW7_8
{
    public abstract class Person : ISpeakable, IMovable, IEating
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public void Eat()
        {
            Console.WriteLine("Person is eating");
        }
        public void Move()
        {
            Console.WriteLine("Person is moving");
        }
        public void Speak()
        {
            Console.WriteLine("Person is speaking");
        }
    }
}
