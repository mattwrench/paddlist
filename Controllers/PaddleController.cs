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

        protected override void boundsCheck(Entity entity)
        {
            // TODO
        }
    }
}
