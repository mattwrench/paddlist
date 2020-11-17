using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Paddlist.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paddlist.Views
{
    class Renderer
    {
        private SpriteBatch spriteBatch;
        private GraphicsDevice graphicsDevice;
        private World world;

        public Renderer(GraphicsDeviceManager graphics, World world)
        {
            graphicsDevice = graphics.GraphicsDevice;
            spriteBatch = new SpriteBatch(graphicsDevice);

            // Set window size & title
            graphics.PreferredBackBufferWidth = world.Width;
            graphics.PreferredBackBufferHeight = world.Height;
            graphics.ApplyChanges();
        }

        public void Render()
        {
            graphicsDevice.Clear(Color.White);
        }
    }
}
