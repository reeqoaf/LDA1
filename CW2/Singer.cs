using System;
using System.Collections.Generic;
using System.Text;

namespace CW2
{
    public class Singer : Person 
    {
        public Band Band { get; set; }
        public List<Song> Songs { get; set; }
        public List<Album> Albums { get; set; }
    }
}
