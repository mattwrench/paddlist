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
        private const int ScoreY = 18;
        private const int DigitWidth = 37;
        private const int DigitSpacing = 22;

        private World world;
        private SpriteBatch spriteBatch;
        private GraphicsDevice graphicsDevice;
        private TextureSet textures;

        public Renderer(GraphicsDeviceManager graphics, World world, ContentManager content)
        {
            this.world = world;
            graphicsDevice = graphics.GraphicsDevice;
            spriteBatch = new SpriteBatch(graphicsDevice);
            textures = new TextureSet(content);

            // Set window size & title
            graphics.PreferredBackBufferWidth = world.Width;
            graphics.PreferredBackBufferHeight = world.Height;
            graphics.ApplyChanges();
        }

        public void Render(Paddlist.GameState gameState)
        {
            bool translucent = false;

            graphicsDevice.Clear(Color.White);

            spriteBatch.Begin();

            // Background
            spriteBatch.Draw(textures.Background, new Rectangle(0, 0, world.Width, world.Height), Color.White);

            // Paddles
            drawPaddle(world.Player);
            drawPaddle(world.Enemy);

            // Balls
            foreach (Ball ball in world.Balls)
            {
                drawEntity(ball, textures.Ball);
            }


            drawScore(world.Player.Score, world.Player.Side, translucent);
            drawScore(world.Enemy.Score, world.Enemy.Side, translucent);

            drawIcons(translucent);

            drawText(gameState);

            spriteBatch.End();
        }

        private void drawText(Paddlist.GameState gameState)
        {
            // Ready
            if (gameState == Paddlist.GameState.Ready)
                drawAtCenter(textures.TextReady);
        }

        // Renders texture in the middle of the screen
        private void drawAtCenter(Texture2D texture)
        {
            Rectangle dest = new Rectangle(
                world.Width / 2 - texture.Width / 2,
                world.Height / 2 - texture.Height / 2,
                texture.Width,
                texture.Height);
            spriteBatch.Draw(texture, dest, Color.White);
        }

        private void drawIcons(bool translucent)
        {
            // Pause/play
            spriteBatch.Draw(textures.GetIconPause(translucent), UI.PauseBounds, Color.White);

            // Restart
            spriteBatch.Draw(textures.GetIconRestart(translucent), UI.RestartBounds, Color.White);

        }

        private void drawScore(int score, Paddle.Team side, bool translucent)
        {
            // Single digit
            if (score < 10)
            {
                Rectangle source = new Rectangle(score * DigitWidth, 0, DigitWidth, textures.GetNumbers(translucent).Height);
                Rectangle dest = new Rectangle(0, ScoreY, DigitWidth, textures.GetNumbers(translucent).Height);
                if (side == Paddle.Team.Left)
                    dest.X = world.Width / 4;
                else // right
                    dest.X = world.Width / 4 * 3;
                spriteBatch.Draw(textures.GetNumbers(translucent), dest, source, Color.White);
            }

            // Double digit
            else
            {
                Rectangle source = new Rectangle((score / 10) * DigitWidth, 0, DigitWidth, textures.GetNumbers(translucent).Height);
                Rectangle dest = new Rectangle(0, ScoreY, DigitWidth, textures.GetNumbers(translucent).Height);
                if (side == Paddle.Team.Left)
                    dest.X = world.Width / 4;
                else // right
                    dest.X = world.Width / 4 * 3;
                dest.X -= DigitSpacing;
                spriteBatch.Draw(textures.GetNumbers(translucent), dest, source, Color.White);

                source = new Rectangle((score % 10) * DigitWidth, 0, DigitWidth, textures.GetNumbers(translucent).Height);
                dest.X += DigitSpacing * 2;
                spriteBatch.Draw(textures.GetNumbers(translucent), dest, source, Color.White);
            }
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
