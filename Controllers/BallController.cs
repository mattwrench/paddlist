using Paddlist.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paddlist.Controllers
{
    class BallController : EntityController
    {
        private const float SpawnRate = 3.0f;

        private float spawnTimer;
        public BallController(World world) : base(world)
        {
            spawnTimer = SpawnRate; // Spawn first ball immediately
        }

        public override void Update(float dt)
        {
            spawnBalls(dt);

            foreach (Ball ball in world.Balls)
            {
                setPosition(ball, dt);
                ball.SetBounds();
                boundsCheck(ball);
                collisionDetect(ball);
            }
        }

        private void spawnBalls(float dt)
        {
            spawnTimer += dt;

            if (spawnTimer >= SpawnRate)
            {
                spawnTimer -= SpawnRate;
                world.Balls.Add(new Ball(world));
            }
        }

        // Handle collisions between balls and paddles
        private void collisionDetect(Ball ball)
        {
            // TODO
        }

        protected override void boundsCheck(Entity entity)
        {
            // Left wall
            if (entity.Bounds.X < 0)
            {
                entity.Bounds.X = 0;
                entity.Position.X = entity.Bounds.X + entity.Bounds.Width / 2;
                entity.Velocity.X *= -1;
            }

            // Right wall
            else if (entity.Bounds.X + entity.Bounds.Width > world.Width)
            {
                entity.Bounds.X = world.Width - entity.Bounds.Width;
                entity.Position.X = entity.Bounds.X + entity.Bounds.Width / 2;
                entity.Velocity.X *= -1;
            }

            // Top wall
            // Uses if, not else if, since ball can be out of bounds (left || right) && (top || bottom)
            if (entity.Bounds.Y < 0)
            {
                entity.Bounds.Y = 0;
                entity.Position.Y = entity.Bounds.Y + entity.Bounds.Height / 2;
                entity.Velocity.Y *= -1;
            }

            // Bottom wall
            else if (entity.Bounds.Y + entity.Bounds.Height > world.Height)
            {
                entity.Bounds.Y = world.Height - entity.Bounds.Height;
                entity.Position.Y = entity.Bounds.Y + entity.Bounds.Height / 2;
                entity.Velocity.Y *= -1;
            }
        }
    }
}
