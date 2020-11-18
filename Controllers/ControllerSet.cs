using Paddlist.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paddlist.Controllers
{
    class ControllerSet
    {
        private PlayerController playerController;

        public ControllerSet(World world)
        {
            playerController = new PlayerController(world);
        }

        public void Update(float dt)
        {
            playerController.Update(dt);
        }
    }
}
