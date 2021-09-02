using System;
using System.Collections.Generic;
using System.Text;

namespace CW1
{
    public class Video : ISendable, IWatchable, IDownloadable
    {
        public string Text { get; set; }
        public int Id { get; set; }

        public void Send(User getUser)
        {
            Console.WriteLine($"Video {Id} with text: {Text}");
        }

        public void Download()
        {
            Console.WriteLine($"Downloading video {Id}");
        }

        public void Watch()
        {
            Console.WriteLine($"Wathcing video {Id}");
        }
    }
}
