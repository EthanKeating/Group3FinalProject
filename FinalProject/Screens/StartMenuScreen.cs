using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject.Screens
{
    class StartMenuScreen : IScreen
    {
        public ScreenType ScreenType => ScreenType.StartMenu;
        private Game _game;
        private SpriteBatch _spriteBatch;

        private Vector2 playButtonPosition;
        private Texture2D playButtonTexture;
        private bool mouseDown = false;

        public StartMenuScreen(Game game, SpriteBatch spriteBatch)
        {
            _game = game;
            _spriteBatch = spriteBatch;

            playButtonTexture = _game.Content.Load<Texture2D>("images/play");
            playButtonPosition = new Vector2((Game1.ScreenWidth / 2) - (playButtonTexture.Width / 2), Game1.ScreenHeight / 3 * 2);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _spriteBatch.Draw(playButtonTexture, playButtonPosition, Color.White);
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
                if (playButtonTexture.Bounds.Contains(mouseState.Position))
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
