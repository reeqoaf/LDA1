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
        public void AddAviary(Aviary aviary)
        {
            Aviary[] newAviaries = new Aviary[Aviaries.Length + 1];
            Aviaries.CopyTo(newAviaries, 0);
            newAviaries[newAviaries.Length - 2] = aviary;
            Aviaries = newAviaries;
        }
        public void AddEmployee(Employee employee)
        {
            Employee[] newEmployees = new Employee[Employees.Length + 1];
            Employees.CopyTo(newEmployees, 0);
            newEmployees[newEmployees.Length - 2] = employee;
            Employees = newEmployees;
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
