using FinalProject.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace FinalProject.Screens
{
    class StartMenuScreen : IScreen
    {
        public ScreenType ScreenType => ScreenType.StartMenu;
        private Game _game;
        private SpriteBatch _spriteBatch;

        private Vector2 logoPosition;
        private Texture2D logoTexture;

        private Vector2 playButtonPosition;
        private Texture2D playButtonTexture;
        private Texture2D backgroundSprite;
        private Rectangle playButtonBounds;
        private bool mouseDown = false;

        private float baseYPosition;
        private float bobOffset;
        private float bobSpeed = 3f;
        private float bobHeight = 10f;

        private float time = 0;

        public StartMenuScreen(Game game, SpriteBatch spriteBatch)
        {

            _game = game;
            _spriteBatch = spriteBatch;

            logoTexture = _game.Content.Load<Texture2D>("images/DarkShellsTitle");
            logoPosition = new Vector2((Game1.ScreenWidth / 2) - (logoTexture.Width / 2), 0);

            playButtonTexture = _game.Content.Load<Texture2D>("images/play");
            backgroundSprite = _game.Content.Load<Texture2D>("images/background");
            playButtonPosition = new Vector2((Game1.ScreenWidth / 2) - (playButtonTexture.Width / 2), Game1.ScreenHeight / 5 * 4);
            playButtonBounds = new Rectangle((int)playButtonPosition.X, (int)playButtonPosition.Y, playButtonTexture.Width, playButtonTexture.Height);

            baseYPosition = playButtonPosition.Y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _spriteBatch.Draw(backgroundSprite, Vector2.Zero, Color.White);
            _spriteBatch.Draw(playButtonTexture, playButtonPosition, Color.White);
            _spriteBatch.Draw(logoTexture, logoPosition, Color.White);
        }

        public void Update(ScreenManager _screenManager, float delta)
        {
            MouseState mouseState = Mouse.GetState();
            KeyboardState keyboardState = Keyboard.GetState();

            time += delta;

            bobOffset = (float)Math.Sin(time * bobSpeed) * bobHeight;
            playButtonPosition.Y = baseYPosition + bobOffset;

            if (keyboardState.IsKeyDown(Keys.Enter))
            {
                CutsceneScreen screen = _screenManager.GetScreenBy(ScreenType.Cutscene) as CutsceneScreen;
                screen._cutsceneCount = 0;
                _screenManager.SetScreen(ScreenType.Cutscene);
                _screenManager.SwitchToNextScreen();

            }
            
            if (mouseState.LeftButton == ButtonState.Pressed && !mouseDown)
            {
                if (playButtonBounds.Contains(mouseState.Position))
                {
                    CutsceneScreen screen = _screenManager.GetScreenBy(ScreenType.Cutscene) as CutsceneScreen;
                    screen._cutsceneCount = 0;

                    _screenManager.SetScreen(ScreenType.Cutscene);
                    _screenManager.SwitchToNextScreen();
                }

                mouseDown = true;
            }
            else if (mouseState.LeftButton != ButtonState.Pressed)
            {
                mouseDown = false;
            }
        }

        public void Reset()
        {
        }
    }
}
