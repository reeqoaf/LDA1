using System;
using System.Collections.Generic;
using System.Text;

namespace HW7_8
{
    public class Employee : Person
    {
        public int Salary { get; set; }
        public Post Post { get; set; }
        public int Experience { get; set; }
        public Employee(string firstName, string lastName, int age, int salary, Post post, int experience) : base(firstName, lastName, age)
        {
            Salary = salary;
            Post = post;
            Experience = experience;
        }
    }
}
