namespace FinalProject.Managers
{
    public class ScreenManager
    {

        public IReadOnlyCollection<IScreen> _screens;
        private Game1 _game;
        private IScreen _activeScreen;
        private IScreen _nextScreen;

        public ScreenManager(Game1 game, IReadOnlyCollection<IScreen> screens)
        {
            _game = game;
            _screens = screens;
        }

        public void SetScreen(ScreenType screenType)
        {
            _nextScreen = _screens.First(screen => screen.ScreenType == screenType);
        }
        public void SwitchToNextScreen()
        {
            if (_nextScreen == null) return;

            _activeScreen = _nextScreen;
            _activeScreen.Reset();
        }

        public void SwitchToNextScreenWithoutReset()
        {
            if (_nextScreen == null) return;

            _activeScreen = _nextScreen;
        }

        public Level1Screen GetActiveScreen()
        {
            if (_activeScreen is Level1Screen level1Screen)
            {
                return level1Screen;
            }

            return null;
        }

        public IScreen GetScreenBy(ScreenType screenType)
        {
            return _screens.First(screen => screen.ScreenType == screenType);
        }

        public void Update(float delta)
        {
            _activeScreen.Update(this, delta);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _activeScreen.Draw(spriteBatch);
        }

    }
}
