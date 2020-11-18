using Microsoft.Xna.Framework;
using Paddlist.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paddlist.Controllers
{
    class PlayerController : PaddleController
    {
        public PlayerController(World world) : base(world)
        {
        }

        public override void Update(float dt)
        {
            setVelocity(world.Player);
            setPosition(world.Player, dt);
            world.Player.SetBounds();
            boundsCheck(world.Player);
        }

        protected override void setVelocity(Paddle paddle)
        {
            paddle.Velocity = new Vector2();
            if (Input.MovingUp)
                paddle.Velocity.Y -= paddle.TopSpeed;
            if (Input.MovingDown)
                paddle.Velocity.Y += paddle.TopSpeed;
        }
    }
}
