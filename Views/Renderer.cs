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

            spriteBatch.Begin();

            // Paddles
            drawPaddle(world.Player);
            drawPaddle(world.Enemy);

            spriteBatch.End();
        }

        private void drawEntity(Entity entity, Texture2D texture)
        {
            spriteBatch.Draw(texture, entity.Bounds, Color.White);
        }

        private void drawPaddle(Paddle paddle)
        {
            Texture2D texture;
            if (paddle.Side == Paddle.Team.Left)
                texture = textures.PaddleRed;
            else // Right
                texture = textures.PaddleBlue;

            drawEntity(paddle, texture);
        }
    }
}
