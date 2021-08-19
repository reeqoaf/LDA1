using System;
using System.Collections.Generic;
using System.Text;

namespace HW7_8
{
    public class Visitor : Person
    {
        public TicketType TicketType { get; set; }
        public bool IsInZoo { get; set; }
        public int FunLevel { get; set; }
        public Visitor(string firstName, string lastName, int age, TicketType ticketType) : base(firstName, lastName, age)
        {
            TicketType = ticketType;
            FunLevel = 0;
        }
        public void IncreaseFun()
        {
            if (!this.IsInZoo) return;
            switch (TicketType) // ну типо чем старше человек тем меньше удовольствия от зоопарка )
            {
                case TicketType.Child:
                    FunLevel += 15;
                    break;
                case TicketType.Adult:
                    FunLevel += 15;
                    break;
                case TicketType.Student:
                    FunLevel += 10;
                    break;
            }

        }
    }
}
