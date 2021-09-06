using System;
using System.Collections.Generic;
using System.Text;

namespace CW2
{
    public class Instrumentalist : Person
    {
        public Band Band { get; set; }
        public Instrument Instrument { get; set; }
        public List<Album> Albums { get; set; }
        public List<Song> Singles { get; set; }
    }
}
