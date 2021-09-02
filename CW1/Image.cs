using System;
using System.Collections.Generic;
using System.Text;

namespace CW1
{
    public class Image : ISendable, IDownloadable
    {
        public string Text { get; set; }
        public string Id { get; set; }

        public Image(string text, string id)
        {
            Text = text;
            Id = id;
        }

        public void Send(User getUser)
        {
            Console.WriteLine($"Image {Id} with text: {Text}");
        }

        public void Download()
        {
            Console.WriteLine($"Downloading image {Id}");
        }
    }
}
