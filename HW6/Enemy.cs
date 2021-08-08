using System;
using System.Collections.Generic;
using System.Text;

namespace HW6
{
    class Enemy
    {
        public int x { get; set; }
        public int y { get; set; }
        public const int enemyKey = 12;
        public string enemyView { get; }
        public Enemy(string playerView, int x, int y)
        {
            this.enemyView = playerView;
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
