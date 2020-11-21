using Microsoft.Xna.Framework.Input;
using Paddlist.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paddlist.Controllers
{
    static class Input
    {
        public static bool Pause = false;
        public static bool Restart = false;

        private static KeyboardState keyboardState, lastKeyboardState;
        private static MouseState mouseState, lastMouseState;
        
        public static void Update()
        {
            lastKeyboardState = keyboardState;
            lastMouseState = mouseState;

            keyboardState = Keyboard.GetState();
            mouseState = Mouse.GetState();

            // Look for pause
            if (keyboardState.IsKeyDown(Keys.Space) && !lastKeyboardState.IsKeyDown(Keys.Space))
                Pause = !Pause;

            // Look for restart
            if (keyboardState.IsKeyDown(Keys.Escape) && !lastKeyboardState.IsKeyDown(Keys.Escape))
                Restart = true;

            // Mouse press
            if (mouseState.LeftButton == ButtonState.Pressed && lastMouseState.LeftButton != ButtonState.Pressed)
            {
                if (UI.PauseBounds.Contains(mouseState.X, mouseState.Y))
                    Pause = !Pause;
                else if (UI.RestartBounds.Contains(mouseState.X, mouseState.Y))
                    Restart = true;
            }
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
