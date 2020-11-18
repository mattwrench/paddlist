using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paddlist.Models
{
    class Ball : Entity
    {
        public Ball(World world)
        {
            // Class attributes
            Bounds.Width = 32;
            Bounds.Height = 32;
            TopSpeed = 400;

            Random rand = new Random();

            // Set position
            // y-position is randomized
            Position.X = world.Width / 2;
            Position.Y = (float)(Bounds.Height / 2 + (world.Height - Bounds.Height) * rand.NextDouble());

            // Set random velocity
            Velocity.X = TopSpeed;
            float angleRadians = (float)(rand.NextDouble() * MathHelper.TwoPi);
            Velocity = Vector2.Transform(Velocity, Matrix.CreateRotationZ(angleRadians));

            SetBounds();
        }
    }
}
