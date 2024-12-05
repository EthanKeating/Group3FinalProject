global using FinalProject.Entities;
global using FinalProject.Managers;
global using FinalProject.Screens;
global using FinalProject.Animations;
global using FinalProject.Utilities;
global using Microsoft.Xna.Framework;
global using Microsoft.Xna.Framework.Graphics;
global using Microsoft.Xna.Framework.Audio;
global using Microsoft.Xna.Framework.Input;
global using System.Collections.Generic;
global using System;
global using System.Linq;

namespace FinalProject
{
    public class Game1 : Game
    {
        public static int ScreenWidth = 1280;
        public static int ScreenHeight = 720;

        public ScreenManager _screenManager;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            SoundEffect.MasterVolume = 0.5f;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = ScreenWidth;
            _graphics.PreferredBackBufferHeight = ScreenHeight;
            _graphics.ApplyChanges();

            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _screenManager = new ScreenManager(this, new IScreen[]
            {
                new StartMenuScreen(this, _spriteBatch),
                new Level1Screen(this, _spriteBatch),
                new GameOverMenuScreen(this, _spriteBatch),
                new GameWinMenuScreen(this, _spriteBatch),
                new CutsceneScreen(this, _spriteBatch)

            });
            _screenManager.SetScreen(ScreenType.StartMenu);
            _screenManager.SwitchToNextScreen();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Seconds since the last frame.
            float deltaFrameTime = gameTime.ElapsedGameTime.Milliseconds / 1000f;
            _screenManager.Update(deltaFrameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _screenManager.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
