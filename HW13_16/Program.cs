using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace HW13_16
{
    class Program
    {
        struct User
        {
            public string name;
            public int age;
            public User(string name, int age)
            {
                this.name = name;
                this.age = age;
            }
        }
        static void Main(string[] args)
        {
            List<string> names = new List<string>
            {
                "Jamie", "Annice", "Hal", "Ione", "Miles", "Jaxton", "Alexa", "Julian", "Charisse", "Rebecca", "Alexina"
            };
            GenerateFile(names);
            List<User> users = ReadFile();
            foreach(User user in users)
            {
                Console.WriteLine(user.name + " " + user.age);
            }
            var groupedUsers = users.GroupBy(user => user.age)
                .ToDictionary(x => x.First().age, y => y.Count())
                .OrderByDescending(x => x.Value);
            Console.WriteLine("----------------------------------------");
            foreach(var x in groupedUsers)
            {
                Console.WriteLine(x.Key + " " + x.Value);
            }
            using(var file = new StreamWriter("newdata.txt", false))
            {
                file.WriteLine("Most common age: " + groupedUsers.First().Key);
                file.WriteLine("The rarest age: " + groupedUsers.Last().Key);
                file.WriteLine("Average age: " + users.Average(x => x.age));
                file.WriteLine("Count of users which age less than 14 and more than 79: " + groupedUsers.Where(x => x.Key > 79 || x.Key < 14).Sum(x => x.Value));
            }
            SaveOnLocalServer(users.Where(user => user.age > 14 && user.age < 79).ToList());
        }
        static void GenerateFile(List<string> names)
        {
            Random rand = new Random();
            using (var file = new StreamWriter("data.txt", false))
            {
                for (int i = 0; i < 100; i++)
                {
                    file.WriteLine(names[rand.Next(0, names.Count)] + " " + rand.Next(1, 100));
                }
            }
        }
        static List<User> ReadFile()
        {
            List<User> users = new List<User>();
            using (var file = new StreamReader("data.txt"))
            {
                for (int i = 0; i < 100; i++)
                {
                    var line = file.ReadLine().Split(" ");
                    users.Add(new User(line[0], int.Parse(line[1])));
                }
            }
            return users;
        }
        static void SaveOnLocalServer(List<User> users)
        {
            HttpClient httpClient = new HttpClient();
            users
                .GroupBy(x => x.name)
                .Select(y => y.First())
                .ToList()
                .ForEach(async user => await httpClient.GetStringAsync($"http://localhost:5000/user/add?username={user.name}"));
        }
    }
}
