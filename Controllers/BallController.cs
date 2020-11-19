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

            for (int i = world.Balls.Count - 1; i >= 0; i--)
            {
                Ball ball = world.Balls[i];
                setPosition(ball, dt);
                ball.SetBounds();
                collisionDetect(ball);
                if (boundsCheck(ball))
                    world.Balls.RemoveAt(i);
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
        // Velocity conditions prevent balls clipping to paddles
        private void collisionDetect(Ball ball)
        {
            // Player
            if (ball.Bounds.Intersects(world.Player.Bounds) && ball.Velocity.X < 0)
            {
                ball.Velocity.X *= -1;
            }

            // Enemy
            else if (ball.Bounds.Intersects(world.Enemy.Bounds) && ball.Velocity.X > 0)
            {
                ball.Velocity.X *= -1;
            }
        }

        protected override bool boundsCheck(Entity entity)
        {
            bool delete = false;

            // Left wall
            if (entity.Bounds.X < 0)
            {
                delete = true;
                world.Enemy.Score += 1;
            }

            // Right wall
            else if (entity.Bounds.X + entity.Bounds.Width > world.Width)
            {
                delete = true;
                world.Player.Score += 1;
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

            return delete;
        }
    }
}
