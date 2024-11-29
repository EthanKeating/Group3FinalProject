using FinalProject.Animations;
using FinalProject.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Screens
{
    class Level1Screen : IScreen
    {
        public ScreenType ScreenType => ScreenType.Level1;
        private Game _game;

        Texture2D backgroundSprite;
        Texture2D crab;

        CrabIdleAnimation idleCrab;

        public Vector2 backgroundPosition = new Vector2(0, 0);

        public Level1Screen(Game game, SpriteBatch spriteBatch)
        {
            _game = game;

            backgroundSprite = _game.Content.Load<Texture2D>("images/background");
            crab = _game.Content.Load<Texture2D>("images/idle");

            idleCrab = new CrabIdleAnimation(this._game, spriteBatch, crab, new Vector2(400, 400), 10);
            _game.Components.Add(idleCrab);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundSprite, backgroundPosition, Color.White);

            idleCrab.show();

            //spriteBatch.Draw(null, null, null);
        }

        public void Update(float delta)
        {
            backgroundPosition.X -= delta * 20; //Temporary scroll speed (20 units per second)
        }
    }
}
