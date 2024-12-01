using FinalProject.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject.Managers
{
    public class ScreenManager
    {

        private IReadOnlyCollection<IScreen> _screens;
        private IScreen _activeScreen;
        private IScreen _nextScreen;

        public ScreenManager(IReadOnlyCollection<IScreen> screens)
        {
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
        }

        public void Update(float delta)
        {
            _activeScreen.Update(delta);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _activeScreen.Draw(spriteBatch);
        }

    }
}
