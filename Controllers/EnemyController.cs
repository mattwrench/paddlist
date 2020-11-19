using Paddlist.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paddlist.Controllers
{
    class EnemyController : PaddleController
    {
        public EnemyController(World world) : base(world)
        {
        }

        public override void Update(float dt)
        {
            setVelocity(world.Enemy);
            setPosition(world.Enemy, dt);
            world.Enemy.SetBounds();
            boundsCheck(world.Enemy);
        }

        // Enemy AI
        protected override void setVelocity(Paddle paddle)
        {
            // TODO
        }
    }
}
