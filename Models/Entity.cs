using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paddlist.Models
{
    // Base class for all sprites
    abstract class Entity
    {
        public Vector2 Position; // X/Y is at center of sprite
        public Vector2 Velocity;
        public float TopSpeed;
        public Rectangle Bounds; // X/Y is at top-left of sprite; used for collisions and drawing

        public Entity()
        {
            // Default values will be overwritten in child constructors
            Position = new Vector2();
            Velocity = new Vector2();
            Bounds = new Rectangle();
        }
    }
}
