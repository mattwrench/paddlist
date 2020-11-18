using Microsoft.Xna.Framework;
using Paddlist.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paddlist.Controllers
{
    // Base class for all controllers
    abstract class EntityController
    {
        protected World world;

        public EntityController(World world)
        {
            this.world = world;
        }

        public abstract void Update(float dt);
        protected abstract void boundsCheck(Entity entity); // Keep entities inside screen

        // Add velocity * dt to position
        protected void setPosition(Entity entity, float dt)
        {
            entity.Position = Vector2.Add(entity.Position, Vector2.Multiply(entity.Velocity, dt));
        }
    }
}
