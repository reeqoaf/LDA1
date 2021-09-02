using System.Collections.Generic;

namespace CW1
{
    public class User
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<ISendable> Messages { get; set; }

        public User(string username, string name, int age)
        {
            Username = username;
            Name = name;
            Age = age;
            Messages = new List<ISendable>();
        }
        public void GetMessage(ISendable message)
        {
            Messages.Add(message);
        }
        public void ShowAllMessages()
        {
        }
    }
}