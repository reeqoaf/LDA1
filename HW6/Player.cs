using System;
using System.Collections.Generic;
using System.Text;

namespace HW6
{
    public class Player
    {
        public int x { get; set; }
        public int y { get; set; }
        public const int playerKey = 10;
        public string playerView { get; }
        public Player(string playerView, int x, int y)
        {
            this.playerView = playerView;
            this.x = x;
            this.y = y;
        }
        public void setPos(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

    }
}
