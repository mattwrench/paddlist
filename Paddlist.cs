using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Paddlist.Controllers;
using Paddlist.Models;
using Paddlist.Views;
using System;

namespace Paddlist
{
    public class Paddlist : Game
    {
        public enum GameState
        {
            Ready, Playing, Paused, GameOver
        }

        private GameState gameState;
        private GraphicsDeviceManager graphics;
        private World world;
        private ControllerSet controllers;
        private Renderer renderer;

        public Paddlist()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            gameState = GameState.Playing;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            world = new World();
            controllers = new ControllerSet(world);
            renderer = new Renderer(graphics, world, Content);
        }

        protected override void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Input.Update();
            setGameState(dt);
            if (gameState == GameState.Playing)
                controllers.Update(dt);
            base.Update(gameTime);
        }

        private void setGameState(float dt)
        {
            // TODO
        }

        protected override void Draw(GameTime gameTime)
        {
            renderer.Render(gameState);
            base.Draw(gameTime);
        }
    }
}
