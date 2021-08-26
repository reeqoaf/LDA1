using System;
using System.Collections.Generic;
using System.Text;

namespace HW10
{
    public class Ship
    {
        public int Length { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool Orientation { get; set; }
        public Ship(int length, int x, int y, bool orientation)
        {
            Length = length;
            X = x;
            Y = y;
            Orientation = orientation;
        }
    }
}
