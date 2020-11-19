using Paddlist.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paddlist.Controllers
{
    class ControllerSet
    {
        private PlayerController playerController;
        private EnemyController enemyController;
        private BallController ballController;

        public ControllerSet(World world)
        {
            playerController = new PlayerController(world);
            enemyController = new EnemyController(world);
            ballController = new BallController(world);
        }

        public void Update(float dt)
        {
            playerController.Update(dt);
            enemyController.Update(dt);
            ballController.Update(dt);
        }
    }
}
