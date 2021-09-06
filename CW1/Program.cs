using System;
using System.Collections.Generic;

namespace CW1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>()
            {
                new User("User1", "user1_name", 17),
                new User("User2", "user2_name", 18),
                new User("User3", "user3_name", 19),
            };
            Console.WriteLine(users.Random().Name);
        }
    }
}
