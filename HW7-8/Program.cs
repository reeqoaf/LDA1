using System;

namespace HW7_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Aviary[] aviaries = new Aviary[] {
                new Aviary("Cat Aviary", "Here you can see different cats like tiger or other", new Animal[]
                    {
                        new Tiger("Siberian tiger", 80, 5),
                        new Tiger("Bengal tiger", 75, 4),
                        new Tiger("Malayan tiger", 115, 8),
                    }),
                new Aviary("Spiders Aviary", "Here you can see different spiders like black widow or other", new Animal[]
                    {
                        new Spider("Black Widow Spider", 0.09, 14, true, 8),
                        new Spider("Tarantula Spider", 0.17, 10, true, 8),
                        new Spider("Grammostola Spider", 0.15, 16, false, 8),
                    })
            };

            Zoo GrandZoo = new Zoo("Grand Zoo",
                new Aviary[]
                {
                    new Aviary("Cat Aviary", "Here you can see different cats like tiger or other", new Animal[]
                    {
                        new Tiger("Siberian tiger", 80, 5),
                        new Tiger("Bengal tiger", 75, 4),
                        new Tiger("Malayan tiger", 115, 8),
                    }),
                    new Aviary("Spiders Aviary", "Here you can see different spiders like black widow or other", new Animal[]
                    {
                        new Spider("Black Widow Spider", 0.09, 14, true, 8),
                        new Spider("Tarantula Spider", 0.17, 10, true, 8),
                        new Spider("Grammostola Spider", 0.15, 16, false, 8),
                    })
                },
                new Visitor[]
                {
                    new Visitor("Alivia", "Knight", 17, TicketType.Student),
                    new Visitor("Amritpal", "Colon", 26, TicketType.Adult),
                    new Visitor("Fariha", "Owen", 10, TicketType.Child)
                },
                new Employee[]
                {
                    new Employee("Martyn", "Ritter", 43, 140000, Post.Owner, 10),
                    new Employee("Darin", "Hastings", 22, 90000, Post.Administrator, 2),
                    new Employee("Francis", "Solomon", 25, 50000, Post.Caretaker, 3),
                    new Employee("Jensen", "Bailey", 32, 60000, Post.Vet, 7),
                    new Employee("Alicia", "Nicholson", 35, 40000, Post.Cleaner, 5),
                });
            for(int i = 0; i < GrandZoo.Visitors.Length; i++)
            {
                if (i % 2 == 1)
                {
                    continue;
                }
                GrandZoo.Visitors[i].IsInZoo = true;
                GrandZoo.Visitors[i].IncreaseFun();
            }
            bool temp = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to Grand Zoo! Choose what you want:");
                MainMenu();
                switch (GetNumber())
                {
                    case 1:
                        PrintZooInfo(GrandZoo);
                        break;
                    case 2:
                        PrintVisitorsInfo(GrandZoo);
                        break;
                    case 3:
                        PrintEmployeesInfo(GrandZoo);
                        break;
                    case 4:
                        ShowAviary(GrandZoo.Aviaries);
                        break;
                    case 5:
                        temp = false;
                        break;
                    default:
                        Console.WriteLine("Incorrect input");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            } while (temp);
        }
        public static void MainMenu()
        {
            Console.WriteLine("1. Get zoo info");
            Console.WriteLine("2. Get visitors info");
            Console.WriteLine("3. Get employees info");
            Console.WriteLine("4. Get information about aviary");
            Console.WriteLine("5. Exit");
        }
        public static void ShowAviary(Aviary[] aviaries)
        {
            Console.WriteLine("Select aviary:");

            for (int i = 0; i < aviaries.Length; i++)
            {
                Console.WriteLine($"{i + 1} {aviaries[i].Name}");
            }
            int input = GetNumber() - 1;
            if(input < 0 || input >= aviaries.Length)
            {
                Console.WriteLine("There no aviary with that index!");
            }
            else
            {
                PrintAviaryInfo(aviaries[input]);
            }
        }
        public static int GetNumber()
        {
            bool temp = true;
            int input;
            do
            {
                Console.Write("Enter number: ");
                temp = int.TryParse(Console.ReadLine(), out input);
                if(!temp)
                {
                    Console.WriteLine("Incorrect input! Try again!");
                }
                else
                {
                    temp = false;
                }    
            } while (temp);
            return input;
        }

        public static void PrintZooInfo(Zoo zoo)
        {
            Employee owner = zoo.GetOwner();
            Console.WriteLine("Zoo Name: " + zoo.Name);
            Console.WriteLine("Owner: " + owner.FirstName + " " + owner.LastName);
            Console.WriteLine("Number of Aviaries: " + zoo.Aviaries.Length);
            Console.WriteLine("Number of Visitors: " + zoo.Visitors.Length);
            Console.WriteLine("Number of Employees: " + zoo.Employees.Length);
        }
        public static void PrintVisitorsInfo(Zoo zoo)
        {
            Console.WriteLine("Number of Visitors: " + zoo.Visitors.Length);
            foreach(var visitor in zoo.Visitors) 
            {
                string msg = visitor.IsInZoo ? "The visitor is in zoo" : "The visitor is not in zoo";
                Console.WriteLine($"{visitor.FirstName} {visitor.LastName}: Age = {visitor.Age}, {msg}, Ticket type is {visitor.TicketType}, Fun level = {visitor.FunLevel}");
            }
        }
        public static void PrintEmployeesInfo(Zoo zoo)
        {
            Console.WriteLine("Number of Visitors: " + zoo.Visitors.Length);
            foreach (var employee in zoo.Employees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName}: Age = {employee.Age}, Experience = {employee.Experience} years, Post is {employee.Post}, Salary = {employee.Salary}");
            }
        }
        public static void PrintAviaryInfo(Aviary aviary)
        {
            Console.WriteLine("Name: " + aviary.Name);
            Console.WriteLine("Desctription: " + aviary.Description);
            foreach(Animal animal in aviary.Animals)
            {
                PrintAnimalInfo(animal);
            }

        }
        public static void PrintAnimalInfo(Animal animal)
        {
            Console.WriteLine($"Form: {animal.Form}, Age = {animal.Age}, Weight = {animal.Weight}");
        }
    }
}
