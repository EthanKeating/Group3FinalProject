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

        Texture2D backgroundSprite;

        Player player;
        Enemy shark;

        public Vector2 backgroundPosition = new Vector2(0, 0);

        public Level1Screen(Game game, SpriteBatch spriteBatch)
        {
            _game = game;

            backgroundSprite = _game.Content.Load<Texture2D>("images/background");

            player = new Player(9);
            shark = new Enemy(2);

            player.IdleTexture = _game.Content.Load<Texture2D>("images/idle");
            player.WalkTexture = _game.Content.Load<Texture2D>("images/walk");
            player.ClawTexture = _game.Content.Load<Texture2D>("images/shark");

            player.IdleAnimation = new CrabIdleAnimation(_game, spriteBatch, player.IdleTexture, player.Position, 30);
            _game.Components.Add(player.IdleAnimation);
            player.WalkAnimation = new CrabWalkAnimation(_game, spriteBatch, player.WalkTexture, player.Position, 10);
            _game.Components.Add(player.WalkAnimation);

            shark.Texture = _game.Content.Load<Texture2D>("images/shark");
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(backgroundSprite, backgroundPosition, Color.White);

            player.Draw(gameTime);

            spriteBatch.Draw(shark.Texture, shark.Position, shark.Texture.Bounds, Color.White, 0f, Vector2.Zero, 0.4f, SpriteEffects.None, 1f);

            //spriteBatch.Draw(null, null, null);
        }

        public void Update(float delta)
        {//Temporary scroll speed (20 units per second)

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
                //player.LockedToCenter = true;
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
