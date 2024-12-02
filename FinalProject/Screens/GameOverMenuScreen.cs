using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using FinalProject.Managers;

namespace FinalProject.Screens
{
    class GameOverMenuScreen : IScreen
    {
        public ScreenType ScreenType => ScreenType.GameOverMenu;
        private Game _game;
        private SpriteBatch _spriteBatch;

        private Vector2 replayButtonPosition;
        private Texture2D replayButtonTexture;
        private Rectangle replayButtonBounds;
        private bool mouseDown = false;

        public GameOverMenuScreen(Game game, SpriteBatch spriteBatch)
        {
            _game = game;
            _spriteBatch = spriteBatch;

            replayButtonTexture = _game.Content.Load<Texture2D>("images/replay");
            replayButtonPosition = new Vector2((Game1.ScreenWidth / 2) - (replayButtonTexture.Width / 2), Game1.ScreenHeight / 3 * 2);
            replayButtonBounds = new Rectangle((int)replayButtonPosition.X, (int)replayButtonPosition.Y, replayButtonTexture.Width, replayButtonTexture.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _spriteBatch.Draw(replayButtonTexture, replayButtonPosition, Color.White);
        }

        public void Update(ScreenManager _screenManager, float delta)
        {
            MouseState mouseState = Mouse.GetState();
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Enter))
            {
                _screenManager.SetScreen(ScreenType.Level1);
                _screenManager.SwitchToNextScreen();
            }
            else if (mouseState.LeftButton == ButtonState.Pressed && !mouseDown)
            {
                if (replayButtonBounds.Contains(mouseState.Position))
                {
                    _screenManager.SetScreen(ScreenType.Level1);
                    _screenManager.SwitchToNextScreen();
                }

                mouseDown = true;
            }
            else if (mouseState.LeftButton != ButtonState.Pressed)
            {
                mouseDown = false;
            }
        }
    }
}
