using System;
using System.Collections.Generic;
using System.Text;

namespace Paddlist.Models
{
    // Container class for all other models
    class World
    {
        public readonly int Width = 1280;
        public readonly int Height = 720;

        public Paddle Player, Enemy;
        public List<Ball> Balls;
        public World()
        {
            Player = new Paddle(Paddle.Team.Left, this);
            Enemy = new Paddle(Paddle.Team.Right, this);
            Balls = new List<Ball>();
        }
    }
}
