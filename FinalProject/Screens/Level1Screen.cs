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
    class Level1Screen : IScreen
    {
        public ScreenType ScreenType => ScreenType.Menu;
        private Game _game;

        public Level1Screen(Game game)
        {
            _game = game;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            //spriteBatch.Draw(null, null, null);
        }

        public void Update(float delta)
        {
        }
    }
}
