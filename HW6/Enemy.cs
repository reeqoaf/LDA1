using System;
using System.Collections.Generic;
using System.Text;

namespace HW6
{
    class Enemy
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string EnemyView { get; }
        public Enemy(string playerView, int x, int y)
        {
            this.EnemyView = playerView;
            this.X = x;
            this.Y = y;
        }
        public void setPos(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
