using System;
using System.Collections.Generic;
using System.Text;

namespace HW7_8
{
    public class Zoo
    {
        public string Name { get; set; }
        public Aviary[] Aviaries { get; private set; }
        public Visitor[] Visitors { get; private set; }
        public Employee[] Employees { get; private set; }

        public Zoo(string name, Aviary[] aviaries, Visitor[] visitors, Employee[] employees)
        {
            Name = name;
            Aviaries = aviaries;
            Visitors = visitors;
            Employees = employees;
        }
        public Employee GetOwner()
        {
            foreach (var emp in Employees)
            {
                if (emp.Post == Post.Owner) return emp;
            }
            return null;
        }
    }
}
