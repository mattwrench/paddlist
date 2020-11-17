using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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
        private TextureSet textures;

        public Renderer(GraphicsDeviceManager graphics, World world, ContentManager content)
        {
            graphicsDevice = graphics.GraphicsDevice;
            spriteBatch = new SpriteBatch(graphicsDevice);
            textures = new TextureSet(content);

            // Set window size & title
            graphics.PreferredBackBufferWidth = world.Width;
            graphics.PreferredBackBufferHeight = world.Height;
            graphics.ApplyChanges();
        }

        public void Render(World world)
        {
            graphicsDevice.Clear(Color.White);
        }
    }
}
