using System;
using System.Collections.Generic;
using System.Text;

namespace HW10
{
    public class Ship
    {
        public int Length { get; set; }
        public int AliveParts { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool Orientation { get; set; }
        public Ship(int length, int x, int y, bool orientation)
        {
            Length = length;
            AliveParts = length;
            X = x;
            Y = y;
            Orientation = orientation;
        }
        public bool IsShipAtCoords(int x, int y)
        {
            for(int i = 0; i < Length; i++)
            {
                if(Orientation && X + i == x && Y == y)
                {
                    return true;
                }
                else if(!Orientation && Y + i == y && X == x)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
