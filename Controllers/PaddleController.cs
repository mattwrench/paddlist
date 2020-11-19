using Paddlist.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paddlist.Controllers
{
    abstract class PaddleController : EntityController
    {
        public PaddleController(World world) : base(world)
        {
        }

        protected abstract void setVelocity(Paddle paddle);

        protected override bool boundsCheck(Entity entity)
        {
            // Top wall
            if (entity.Bounds.Y < 0)
            {
                entity.Bounds.Y = 0;
                entity.Position.Y = entity.Bounds.Y + entity.Bounds.Height / 2;
            }

            // Bottom wall
            else if (entity.Bounds.Y + entity.Bounds.Height > world.Height)
            {
                entity.Bounds.Y = world.Height - entity.Bounds.Height;
                entity.Position.Y = entity.Bounds.Y + entity.Bounds.Height / 2;
            }

            return false; // Paddles cannot be deleted
        }
    }
}
