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

        private Vector2 playButtonPosition;
        private Texture2D playButtonTexture;
        private Texture2D backgroundSprite;
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

            playButtonTexture = _game.Content.Load<Texture2D>("images/play");
            backgroundSprite = _game.Content.Load<Texture2D>("images/background");
            playButtonPosition = new Vector2((Game1.ScreenWidth / 2) - (playButtonTexture.Width / 2), Game1.ScreenHeight / 3 * 2);

            baseYPosition = playButtonPosition.Y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _spriteBatch.Draw(backgroundSprite, Vector2.Zero, Color.White);
            _spriteBatch.Draw(playButtonTexture, playButtonPosition, Color.White);
           
        }

        public void Update(float delta)
        {
            MouseState mouseState = Mouse.GetState();
            KeyboardState keyboardState = Keyboard.GetState();

            time += delta;

            bobOffset = (float)Math.Sin(time * bobSpeed) * bobHeight;
            playButtonPosition.Y = baseYPosition + bobOffset;

            if (keyboardState.IsKeyDown(Keys.Enter))
            {
                Game1 game1 = _game as Game1;
                game1._screenManager.SetScreen(ScreenType.Level1);
                game1._screenManager.SwitchToNextScreen();
            }
            else if (mouseState.LeftButton == ButtonState.Pressed && !mouseDown)
            {
                Rectangle playButtonBound = new Rectangle((int)playButtonPosition.X, (int)playButtonPosition.Y, playButtonTexture.Width, playButtonTexture.Height);
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
