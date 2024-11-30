﻿using FinalProject.Animations;
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

        public Vector2 backgroundPosition = new Vector2(0, 0);

        public Level1Screen(Game game, SpriteBatch spriteBatch)
        {
            _game = game;

            backgroundSprite = _game.Content.Load<Texture2D>("images/background");

            player = new Player(6);

            player.IdleTexture = _game.Content.Load<Texture2D>("images/idle");
            player.WalkTexture = _game.Content.Load<Texture2D>("images/walk");

            player.IdleAnimation = new CrabIdleAnimation(_game, spriteBatch, player.IdleTexture, player.Position, 30);
            _game.Components.Add(player.IdleAnimation);
            player.WalkAnimation = new CrabWalkAnimation(_game, spriteBatch, player.WalkTexture, player.Position, 10);
            _game.Components.Add(player.WalkAnimation);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(backgroundSprite, backgroundPosition, Color.White);

            player.Draw(gameTime);

            //spriteBatch.Draw(null, null, null);
        }

        public void Update(float delta)
        {//Temporary scroll speed (20 units per second)

            int startX = (int)player.Position.X;
            player.Update();
            int deltaX = (int)player.Position.X - startX;

            int rightBound = (int)Game1.ScreenWidth / 4;

            if (player.Position.X + player.Hitbox.Width * 2 > rightBound)
            {
                player.Position = new Vector2(startX, player.Position.Y);
                backgroundPosition.X -= deltaX;
                //player.LockedToCenter = true;
            }

            if (player.Position.X < 0)
            {
                player.Position = new Vector2(startX, player.Position.Y);
                backgroundPosition.X -= deltaX;

                if (backgroundPosition.X > 0)
                {
                    backgroundPosition.X = 0;
                }
            }
        }
    }
}
