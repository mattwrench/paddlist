using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paddlist.Controllers
{
    static class Input
    {
        private static KeyboardState keyboardState, lastKeyboardState;
        
        public static void Update()
        {
            lastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();
        }

        public static bool MovingUp
        {
            get
            {
                return keyboardState.IsKeyDown(Keys.Up) || keyboardState.IsKeyDown(Keys.W);
            }
        }

        public static bool MovingDown
        {
            get
            {
                return keyboardState.IsKeyDown(Keys.Down) || keyboardState.IsKeyDown(Keys.S);
            }
        }
    }
}
