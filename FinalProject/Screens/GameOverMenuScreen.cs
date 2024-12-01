using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace FinalProject.Screens
{
    class GameOverMenuScreen : IScreen
    {
        public ScreenType ScreenType => ScreenType.GameOverMenu;
        private Game _game;
        private SpriteBatch _spriteBatch;

        private Vector2 replayButtonPosition;
        private Texture2D replayButtonTexture;
        private bool mouseDown = false;

        public GameOverMenuScreen(Game game, SpriteBatch spriteBatch)
        {
            _game = game;
            _spriteBatch = spriteBatch;

            replayButtonTexture = _game.Content.Load<Texture2D>("images/replay");
            replayButtonPosition = new Vector2((Game1.ScreenWidth / 2) - (replayButtonTexture.Width / 2), Game1.ScreenHeight / 3 * 2);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _spriteBatch.Draw(replayButtonTexture, replayButtonPosition, Color.White);
        }

        public void Update(float delta)
        {
            MouseState mouseState = Mouse.GetState();
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Enter))
            {
                // TODO: change screen to level1
            }
            else if (mouseState.LeftButton == ButtonState.Pressed && !mouseDown)
            {
                if (replayButtonTexture.Bounds.Contains(mouseState.Position))
                {
                    // TODO: change screen to level1
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
