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
            // TODO
        }
    }
}
