using System;
using System.Collections.Generic;
using System.Text;

namespace Paddlist.Models
{
    class Paddle : Entity
    {
        public enum Team
        {
            Left, Right
        }

        private const int OffWall = 50;

        public Team Side;
        public int Score;

        public Paddle(Team team, World world)
        {
            // Class attributes
            Bounds.Width = 32;
            Bounds.Height = 157;
            TopSpeed = 550;

            Side = team;
            Score = 0;

            // Set position
            if (team == Team.Left)
                Position.X = OffWall;
            else // Right
                Position.X = world.Width - OffWall;
            Position.Y = world.Height / 2;

            SetBounds();
        }
    }
}
