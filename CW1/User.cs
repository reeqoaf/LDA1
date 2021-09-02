using System.Collections.Generic;

namespace CW1
{
    public class User
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        List<ISendable> Messages { get; set; }

        public User(string username, string name, int age, List<ISendable> messages)
        {
            Username = username;
            Name = name;
            Age = age;
            Messages = messages;
        }
    }
}