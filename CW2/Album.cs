using System.Collections.Generic;

namespace CW2
{
    public class Album
    {
        public string Name { get; set; }
        public Band Band { get; set; }
        public List<Song> Songs { get; set; }
        public int Date { get; set; }
        public Producer Producer { get; set; }
    }
}