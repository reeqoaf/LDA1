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
                        new Spider("Black Widow Spider", 0.09, 14, true),
                        new Spider("Tarantula Spider", 0.17, 10, true),
                        new Spider("Grammostola Spider", 0.15, 16, false),
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
                        new Spider("Black Widow Spider", 0.09, 14, true),
                        new Spider("Tarantula Spider", 0.17, 10, true),
                        new Spider("Grammostola Spider", 0.15, 16, false),
                    }),
                    new Aviary("Parrots Aviary", "Here you can see different parrots", new Animal[]
                    {
                        new Parrot("African grey parrot", 2, 3, "grey"),
                        new Parrot("Budgie parrot", 0.25, 7, "red"),
                        new Parrot("Cocktiel parrot", 0.35, 4, "yellow"),
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
            for(int i = 0; i < GrandZoo.VisitorsCount; i++)
            {
                if (i % 2 == 1)
                {
                    continue;
                }
                GrandZoo.Visitors[i].IsInZoo = true;
                GrandZoo.Visitors[i].IncreaseFun();
            }
            #region task7_8
            /*bool temp = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to Grand Zoo! Choose what you want:");
                MainMenu();
                switch (GetNumber("number"))
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
                        ShowAviary(GrandZoo);
                        int input = GetNumber("number") - 1;
                        if (input < 0 || input >= GrandZoo.Aviaries.Length)
                        {
                            Console.WriteLine("There no aviary with that index!");
                        }
                        else
                        {
                            PrintAviaryInfo(GrandZoo.Aviaries[input]);
                        }
                        break;
                    case 5:
                        string firstName = GetString("first name");
                        string lastName = GetString("last name");
                        int age = GetNumber("age");
                        int salary = GetNumber("salary");
                        int experience = GetNumber("experience");
                        Post post = GetPost();
                        Employee employee = new Employee(firstName, lastName, age, salary, post, experience);
                        GrandZoo.AddEmployee(employee);
                        break;
                    case 6:
                        firstName = GetString("first name");
                        lastName = GetString("last name");
                        age = GetNumber("age");
                        TicketType ticket = GetTicketType();
                        Visitor visitor = new Visitor(firstName, lastName, age, ticket);
                        int isInZoo;
                        Console.WriteLine("Is visitor in zoo?(enter 1 or 0)");
                        do
                        {
                            isInZoo = GetNumber("number");
                        } while (isInZoo != 0 && isInZoo != 1);
                        visitor.IsInZoo = isInZoo == 1 ? true : false;
                        GrandZoo.AddVisitor(visitor);
                        break;
                    case 0:
                        temp = false;
                        break;
                    default:
                        Console.WriteLine("Incorrect input");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            } while (true);*/
            #endregion
            // использование интерфейсов //
            Console.WriteLine("Person: ");
            GrandZoo.Visitors[0].Move();
            GrandZoo.Visitors[0].Speak();
            GrandZoo.Visitors[0].Eat();
            Console.WriteLine("Animals: ");
            GrandZoo.Aviaries[0].Animals[0].Move();
            GrandZoo.Aviaries[0].Animals[0].Eat(); 

            GrandZoo.Aviaries[1].Animals[0].Move();
            GrandZoo.Aviaries[1].Animals[0].Eat();

            ((Parrot)GrandZoo.Aviaries[2].Animals[0]).Eat();
            ((Parrot)GrandZoo.Aviaries[2].Animals[0]).Speak();
            ((Parrot)GrandZoo.Aviaries[2].Animals[0]).Fly();
            ((Parrot)GrandZoo.Aviaries[2].Animals[0]).Move();
        }
        public static void MainMenu()
        {
            Console.WriteLine("1. Get zoo info");
            Console.WriteLine("2. Get visitors info");
            Console.WriteLine("3. Get employees info");
            Console.WriteLine("4. Get information about aviary");
            Console.WriteLine("5. Add new employee");
            Console.WriteLine("6. Add new visitor");
            Console.WriteLine("0. Exit");
        }
        public static Post GetPost()
        {
            Post output = Post.Cleaner;
            for(int i = 0; i < Enum.GetValues(typeof(Post)).Length - 1; i++)
            {
                Console.WriteLine($"{i+1}. {(Post)i}");
            }
            int temp;
            do
            {
                temp = GetNumber("number of the post");
            } while (temp < 1 || temp >= Enum.GetValues(typeof(Post)).Length);
            output = (Post)(temp - 1);
            return output;
        }
        public static TicketType GetTicketType()
        {
            TicketType output = TicketType.Adult;
            for (int i = 0; i < Enum.GetValues(typeof(TicketType)).Length; i++)
            {
                Console.WriteLine($"{i + 1}. {(TicketType)i}");
            }
            int temp;
            do
            {
                temp = GetNumber("number of the ticket");
            } while (temp < 1 || temp - 1 >= Enum.GetValues(typeof(TicketType)).Length);
            output = (TicketType)(temp - 1);
            return output;
        }
        public static void ShowAviary(Zoo zoo)
        {
            Console.WriteLine("Select aviary:");

            for (int i = 0; i < zoo.AviariesCount; i++)
            {
                Console.WriteLine($"{i + 1} {zoo.Aviaries[i].Name}");
            }
        }
        public static string GetString(string msg)
        {
            Console.Write($"Enter {msg}: ");
            string input = Console.ReadLine();
            return input;
        }
        public static int GetNumber(string msg)
        {
            bool temp = true;
            int input;
            do
            {
                Console.Write($"Enter {msg}: ");
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
            for (int i = 0; i < zoo.VisitorsCount; i++)
            {
                string msg = zoo.Visitors[i].IsInZoo ? "The visitor is in zoo" : "The visitor is not in zoo";
                Console.WriteLine($"{i+1}. {zoo.Visitors[i].FirstName} {zoo.Visitors[i].LastName}: Age = {zoo.Visitors[i].Age}, {msg}, Ticket type is {zoo.Visitors[i].TicketType}, Fun level = {zoo.Visitors[i].FunLevel}");
            }
        }
        public static void PrintEmployeesInfo(Zoo zoo)
        {
            Console.WriteLine("Number of Visitors: " + zoo.Visitors.Length);
            for(int i = 0; i < zoo.EmployeesCount; i++)
            {
                Console.WriteLine($"{i+1}. {zoo.Employees[i].FirstName} {zoo.Employees[i].LastName}: Age = {zoo.Employees[i].Age}, Experience = {zoo.Employees[i].Experience} years, Post is {zoo.Employees[i].Post}, Salary = {zoo.Employees[i].Salary}");
            }
        }
        public static void PrintAviaryInfo(Aviary aviary)
        {
            Console.WriteLine("Name: " + aviary.Name);
            Console.WriteLine("Desctription: " + aviary.Description);
            for(int i = 0; i < aviary.AnimalsCount; i++)
            {
                PrintAnimalInfo(aviary.Animals[i]);
            }

        }
        public static void PrintAnimalInfo(Animal animal)
        {
            Console.WriteLine($"Form: {animal.Form}, Age = {animal.Age}, Weight = {animal.Weight}");
        }
    }
}
