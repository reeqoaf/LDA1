using System;
using System.Collections.Generic;
using System.Text;

namespace CW2
{
    public class Song
    {
        public string Name { get; set; }
        public int Date { get; set; }
        public double Duration { get; set; }
        public Album Album { get; set; }
        public bool IsSingle { get; set; }
        public Producer Producer { get; set; }

        public Song(string name, int date, double duration, Album album = null)
        {
            Name = name;
            Date = date;
            Album = album;
            Duration = duration;
            if (album == null)
            {
                IsSingle = true;
            }
            else
            {
                IsSingle = false;
            }
            Duration = duration;
        }
    }
}
