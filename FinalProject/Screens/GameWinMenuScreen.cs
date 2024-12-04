namespace FinalProject.Screens
{
    public class GameWinMenuScreen : IScreen
    {
        public ScreenType ScreenType => ScreenType.GameWinMenu;

        private Game game;
        private SpriteBatch spriteBatch;

        private Texture2D gameOverSprite;
        private Vector2 gameOverPosition;

        private Vector2 replayButtonPosition;
        private Texture2D replayButtonTexture;
        private Texture2D backgroundSprite;
        private Rectangle replayButtonBounds;
        private bool mouseDown = false;

        private float replayButtonBaseYPosition;
        private float gameOverBaseYPosition;
        private float bobOffset;
        private float bobSpeed = 3f;
        private float bobHeight = 10f;

        private float time = 0;

        public GameWinMenuScreen(Game _game, SpriteBatch _spriteBatch)
        {
            game = _game;
            spriteBatch = _spriteBatch;

            backgroundSprite = game.Content.Load<Texture2D>("images/background");
            replayButtonTexture = game.Content.Load<Texture2D>("images/replay");
            gameOverSprite = game.Content.Load<Texture2D>("images/youwon");

            replayButtonPosition = new Vector2((Game1.ScreenWidth / 2) - (replayButtonTexture.Width / 2), Game1.ScreenHeight / 3 * 2);
            gameOverPosition = new Vector2((Game1.ScreenWidth / 2) - (gameOverSprite.Width / 2), 100);
            replayButtonBounds = new Rectangle((int)replayButtonPosition.X, (int)replayButtonPosition.Y, replayButtonTexture.Width, replayButtonTexture.Height);

            replayButtonBaseYPosition = replayButtonPosition.Y;
            gameOverBaseYPosition = gameOverPosition.Y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundSprite, Vector2.Zero, Color.White);
            spriteBatch.Draw(gameOverSprite, gameOverPosition, Color.White);
            spriteBatch.Draw(replayButtonTexture, replayButtonPosition, Color.White);
        }

        public void Reset()
        {
        }

        public void Update(ScreenManager _screenManager, float delta)
        {
            MouseState mouseState = Mouse.GetState();
            KeyboardState keyboardState = Keyboard.GetState();

            time += delta;

            bobOffset = (float)Math.Sin(time * bobSpeed) * bobHeight;
            replayButtonPosition.Y = replayButtonBaseYPosition + bobOffset;
            gameOverPosition.Y = gameOverBaseYPosition + bobOffset;

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
