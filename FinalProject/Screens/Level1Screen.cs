using FinalProject.Animations;
using FinalProject.Entities;
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

        private Texture2D backgroundSprite;

        private Player player;
        private Enemy shark;

        public Vector2 backgroundPosition = new Vector2(0, 0);

        public Level1Screen(Game game, SpriteBatch spriteBatch)
        {
            _game = game;

            backgroundSprite = _game.Content.Load<Texture2D>("images/background");

            player = new Player(_game, spriteBatch, 9);
            shark = new Enemy(2);

            shark.Texture = _game.Content.Load<Texture2D>("images/shark");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundSprite, backgroundPosition, Color.White);

            player.Draw();

            spriteBatch.Draw(shark.Texture, shark.Position, shark.Texture.Bounds, Color.White, 0f, Vector2.Zero, 0.4f, SpriteEffects.None, 1f);
        }

        public void Update(float delta)
        {

            int startX = (int)player.Position.X;
            player.Update();
            int deltaX = (int)player.Position.X - startX;
            shark.Move();

            int rightBound = (int)Game1.ScreenWidth / 4;

            if (player.Position.X + player.Hitbox.Width * 2 > rightBound)
            {
                player.Position = new Vector2(startX, player.Position.Y);
                backgroundPosition.X -= deltaX;
                shark.UpdateBounds(deltaX);
            }
            if (backgroundPosition.X < -backgroundSprite.Width + 1280)
            {
                backgroundPosition.X = -backgroundSprite.Width + 1280;
                player.Position = new Vector2(startX, player.Position.Y);
            }

            if (player.Position.X < 0)
            {
                player.Position = new Vector2(startX, player.Position.Y);
                backgroundPosition.X -= deltaX;

                if (backgroundPosition.X > 0)
                {
                    backgroundPosition.X = 0;
                }
                else
                {
                    shark.UpdateBounds(deltaX);
                }
            }
        }
    }
}
