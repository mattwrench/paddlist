using Microsoft.Xna.Framework;
using Paddlist.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paddlist.Controllers
{
    class EnemyController : PaddleController
    {
        private const int SlowDownRange = 30;

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
            // Find nearest ball
            Ball nearestBall = null;
            foreach (Ball ball in world.Balls)
            {
                if (ball.Velocity.X > 0)
                {
                    // Do not compare pos.X if first ball
                    if (nearestBall == null)
                    {
                        nearestBall = ball;
                        continue;
                    }

                    // Save ball with the furthest X value
                    if (ball.Position.X > nearestBall.Position.X)
                        nearestBall = ball;
                }
            }

            // Move towards nearest ball
            paddle.Velocity = new Vector2();
            if (nearestBall != null)
            {
                // Ball is above paddle
                if (nearestBall.Position.Y < paddle.Position.Y)
                    paddle.Velocity.Y -= paddle.TopSpeed;
                // Ball is below paddle
                else if (nearestBall.Position.Y > paddle.Position.Y)
                    paddle.Velocity.Y += paddle.TopSpeed;

                // Slow down if ball and paddle are vertically close together
                float dist = Math.Abs(paddle.Position.Y - nearestBall.Position.Y);
                if (dist < SlowDownRange)
                {
                    paddle.Velocity.Y *= (dist / SlowDownRange);
                }
            }
        }
    }
}
