using FinalProject.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Screens
{
    class MenuScreen : IScreen
    {
        public ScreenType ScreenType => ScreenType.Menu;
        private Game _game;

        public MenuScreen(Game game)
        {
            _game = game;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            //spriteBatch.Draw(null, null, null);

            spriteBatch.End();
        }

        public void Update(float delta)
        {
        }
    }
}
