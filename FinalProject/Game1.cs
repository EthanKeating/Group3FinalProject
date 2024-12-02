using FinalProject.Entities;
using FinalProject.Managers;
using FinalProject.Screens;
using FinalProject.Animations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace FinalProject
{
    public class Game1 : Game
    {
        public static int ScreenWidth = 1280;
        public static int ScreenHeight = 720;

        public ScreenManager _screenManager;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //private Player player = new Player(6);

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
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


            //player.Texture = Content.Load<Texture2D>("black_box");

            _screenManager = new ScreenManager(new IScreen[]
            {
                new MenuScreen(this, _spriteBatch),
                new Level1Screen(this, _spriteBatch),
                new CutsceneScreen(this, _spriteBatch)
            });
            _screenManager.SetScreen(ScreenType.Cutscene);
            _screenManager.SwitchToNextScreen();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Seconds since the last frame.
            float deltaFrameTime = gameTime.ElapsedGameTime.Milliseconds / 1000f;
            _screenManager.Update(deltaFrameTime);

            //player.Move();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _screenManager.Draw(_spriteBatch);
            //_spriteBatch.Draw(player.Texture, player.Position, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
