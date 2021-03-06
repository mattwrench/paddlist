﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Paddlist.Audio;
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

        private const float ReadyLength = 3.0f;
        private const int ScoreToWin = 50;

        private GameState gameState;
        private float timer;
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
            gameState = GameState.Ready;
            Input.Initialize();
            timer = -ReadyLength; // Game starts at 0
            world = new World();
            controllers = new ControllerSet(world);
            renderer = new Renderer(graphics, world, Content);
            AudioHandler.Load(Content);
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
            // Update timers
            if (gameState == GameState.Ready || gameState == GameState.Playing)
                timer += dt;

            // Ready to Playing
            if (gameState == GameState.Ready && timer >= 0)
                gameState = GameState.Playing;

            // Ready || Playing to Paused
            else if (gameState == GameState.Ready || gameState == GameState.Playing)
            {
                if (Input.Pause)
                {
                    gameState = GameState.Paused;
                    AudioHandler.Pause.Play();
                }
            }

            // Paused to Ready || Playing
            else if (gameState == GameState.Paused && !Input.Pause)
            {
                if (timer < 0)
                    gameState = GameState.Ready;
                else
                    gameState = GameState.Playing;
            }

            // Game over
            if (gameState != GameState.GameOver) // Prevents firing sound effects continuosly
            {
                if (world.Player.Score >= ScoreToWin || world.Enemy.Score >= ScoreToWin)
                {
                    gameState = GameState.GameOver;
                    if (world.Player.Score >= world.Enemy.Score)
                        AudioHandler.Win.Play();
                    else
                        AudioHandler.Lose.Play();
                }
            }

            // Restart
            if (Input.Restart)
                LoadContent();
        }

        protected override void Draw(GameTime gameTime)
        {
            renderer.Render(gameState);
            {
                base.Draw(gameTime);
            }
        }
    }
}
