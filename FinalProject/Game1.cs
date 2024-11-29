using FinalProject.Managers;
using FinalProject.Screens;
using FinalProject.Animations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Net.Mime.MediaTypeNames;

namespace FinalProject
{
    public class Game1 : Game
    {
        public static int ScreenWidth = 1280;
        public static int ScreenHeight = 720;

        public ScreenManager _screenManager;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D crabWalkTexture;
        private CrabWalkAnimation crabWalkAnimation;

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

            _screenManager = new ScreenManager(new IScreen[]
            {
                new MenuScreen(this, _spriteBatch),
            });
            _screenManager.SetScreen(ScreenType.Menu);
            _screenManager.SwitchToNextScreen();


            //Crab walking test
            crabWalkTexture = this.Content.Load<Texture2D>("images/walk");
            crabWalkAnimation = new CrabWalkAnimation(this, _spriteBatch, crabWalkTexture, Vector2.Zero, 3);
            this.Components.Add(crabWalkAnimation);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Seconds since the last frame.
            float deltaFrameTime = gameTime.ElapsedGameTime.Milliseconds / 1000f;
            _screenManager.Update(deltaFrameTime);

            //Crab walking test
            MouseState ms = Mouse.GetState();
            if (ms.LeftButton == ButtonState.Pressed)
            {
                Vector2 pos = new Vector2(ms.X, ms.Y);
                //explosion.Position = pos;
                //explosion.show();

                CrabWalkAnimation crabFrame = new CrabWalkAnimation(this, _spriteBatch, crabWalkTexture,
                    pos, 10);
                crabFrame.show();
                this.Components.Add(crabFrame);


            }

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
