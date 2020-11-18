using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Paddlist.Controllers;
using Paddlist.Models;
using Paddlist.Views;

namespace Paddlist
{
    public class Paddlist : Game
    {
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
            controllers.Update(dt);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            renderer.Render(world);
            base.Draw(gameTime);
        }
    }
}
