using System;
using System.Collections.Generic;
using System.Text;

namespace CW2
{
    public class Band
    {
        public string Name { get; set; }
        public Producer Producer { get; set; }
        public List<Instrumentalist> Instrumentalists { get; set; }
        public Singer Singer { get; set; }
        public List<Album> Albums { get; set; }
        public List<Song> Singles { get; set; }
    }
}
