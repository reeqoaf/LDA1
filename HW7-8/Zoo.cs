using System;
using System.Collections.Generic;
using System.Text;

namespace HW7_8
{
    public class Zoo
    {
        public string Name { get; set; }
        public Aviary[] Aviaries { get; private set; } = new Aviary[1000];
        public Visitor[] Visitors { get; private set; } = new Visitor[10000];
        public Employee[] Employees { get; private set; } = new Employee[1000];
        public int EmployeesCount { get; private set; }
        public int AviariesCount { get; private set; }
        public int VisitorsCount { get; private set; }

        public Zoo(string name, Aviary[] aviaries, Visitor[] visitors, Employee[] employees)
        {
            Name = name;
            aviaries.CopyTo(Aviaries, 0);
            visitors.CopyTo(Visitors, 0);
            employees.CopyTo(Employees, 0);
            AviariesCount = aviaries.Length;
            EmployeesCount = employees.Length;
            VisitorsCount = visitors.Length;
        }
        public Employee GetOwner()
        {
            for(int i = 0; i < EmployeesCount; i++)
            {
                if (Employees[i].Post == Post.Owner) return Employees[i];
            }
            return null;
        }
        public void AddEmployee(Employee employee)
        {
            Employees[EmployeesCount++] = employee;
        }
        public void AddVisitor(Visitor visitor)
        {
            Visitors[VisitorsCount++] = visitor;
        }
        public void AddAviary(Aviary aviary)
        {
            Aviaries[AviariesCount++] = aviary;
        }
    }
}
