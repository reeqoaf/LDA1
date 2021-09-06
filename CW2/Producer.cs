using System.Collections.Generic;

namespace CW2
{
    public class Producer : Person
    {
        public List<Band> Bands { get; set; }
        public List<Album> Albums { get; set; }
        public List<Song> Singles { get; set; }
    }
}