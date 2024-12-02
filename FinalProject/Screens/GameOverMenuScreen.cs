using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace FinalProject.Screens
{
    class GameOverMenuScreen : IScreen
    {
        public ScreenType ScreenType => ScreenType.GameOverMenu;
        private Game _game;
        private SpriteBatch _spriteBatch;

        private Vector2 replayButtonPosition;
        private Texture2D replayButtonTexture;
        private Texture2D backgroundSprite;
        private bool mouseDown = false;

        private float baseYPosition;
        private float bobOffset;
        private float bobSpeed = 3f;
        private float bobHeight = 10f;

        private float time = 0;

        public GameOverMenuScreen(Game game, SpriteBatch spriteBatch)
        {
            _game = game;
            _spriteBatch = spriteBatch;

            replayButtonTexture = _game.Content.Load<Texture2D>("images/replay");
            backgroundSprite = _game.Content.Load<Texture2D>("images/background");
            replayButtonPosition = new Vector2((Game1.ScreenWidth / 2) - (replayButtonTexture.Width / 2), Game1.ScreenHeight / 3 * 2);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _spriteBatch.Draw(backgroundSprite, Vector2.Zero, Color.White);
            _spriteBatch.Draw(replayButtonTexture, replayButtonPosition, Color.White);
        }

        public void Update(float delta)
        {
            MouseState mouseState = Mouse.GetState();
            KeyboardState keyboardState = Keyboard.GetState();

            time += delta;

            bobOffset = (float)Math.Sin(time * bobSpeed) * bobHeight;
            replayButtonPosition.Y = baseYPosition + bobOffset;

            if (keyboardState.IsKeyDown(Keys.Enter))
            {
                Game1 game1 = _game as Game1;
                game1._screenManager.SetScreen(ScreenType.Level1);
                game1._screenManager.SwitchToNextScreen();
            }
            else if (mouseState.LeftButton == ButtonState.Pressed && !mouseDown)
            {
                Rectangle playButtonBound = new Rectangle((int)replayButtonPosition.X, (int)replayButtonPosition.Y, replayButtonTexture.Width, replayButtonTexture.Height);
                if (playButtonBound.Intersects(new Rectangle(mouseState.Position.X, mouseState.Position.Y, 1, 1)))
                {
                    Game1 game1 = _game as Game1;
                    game1._screenManager.SetScreen(ScreenType.Level1);
                    game1._screenManager.SwitchToNextScreen();
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
