using System;
using System.Collections.Generic;
using System.Text;

namespace CW1
{
    public class Message<T> where T : ISendable
    {
        public T Msg { get; set; }
        public User SendUser { get; set; }
        public User GetUser { get; set; }

        public Message(T msg, User sendUser, User getUser)
        {
            Msg = msg;
            SendUser = sendUser;
            GetUser = getUser;
        }
    }
}
