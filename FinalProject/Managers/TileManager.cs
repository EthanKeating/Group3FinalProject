using FinalProject.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject.Managers
{
    public class TileManager
    {

        private Game1 _game;
        private SpriteBatch _spriteBatch;

        public TileManager(Game1 game, SpriteBatch _spriteBatch)
        {
            _game = game;
            _spriteBatch = _spriteBatch;
        }

        public List<Tile> Populate()
        {
            Texture2D TileTexture = _game.Content.Load<Texture2D>("images/bubble");

            return new List<Tile>([
                new Tile(_game, _spriteBatch, new Vector2(1000, 440)),
                new Tile(_game, _spriteBatch, new Vector2(1000 + TileTexture.Width / 16, 440)),
                new Tile(_game, _spriteBatch, new Vector2(1000 + (TileTexture.Width / 16 * 2), 440)),
                new Tile(_game, _spriteBatch, new Vector2(1000 + (TileTexture.Width / 16 * 3), 440)),

                new Tile(_game, _spriteBatch, new Vector2(1200, 230)),
                new Tile(_game, _spriteBatch, new Vector2(1200 + TileTexture.Width / 16, 230)),
                new Tile(_game, _spriteBatch, new Vector2(1200 + (TileTexture.Width / 16 * 2), 230)),
                new Tile(_game, _spriteBatch, new Vector2(1200 + (TileTexture.Width / 16 * 3), 230)),

                new Tile(_game, _spriteBatch, new Vector2(2000, 440)),
                new Tile(_game, _spriteBatch, new Vector2(2000 + TileTexture.Width / 16, 440)),
                new Tile(_game, _spriteBatch, new Vector2(2000 + (TileTexture.Width / 16 * 2), 440)),
                new Tile(_game, _spriteBatch, new Vector2(2000 + (TileTexture.Width / 16 * 3), 440)),

                new Tile(_game, _spriteBatch, new Vector2(2200, 230)),
                new Tile(_game, _spriteBatch, new Vector2(2200 + TileTexture.Width / 16, 230)),
                new Tile(_game, _spriteBatch, new Vector2(2200 + (TileTexture.Width / 16 * 2), 230)),
                new Tile(_game, _spriteBatch, new Vector2(2200 + (TileTexture.Width / 16 * 3), 230)),

                new Tile(_game, _spriteBatch, new Vector2(3200, 440)),
                new Tile(_game, _spriteBatch, new Vector2(3200 + TileTexture.Width / 16, 440)),
                new Tile(_game, _spriteBatch, new Vector2(3200 + (TileTexture.Width / 16 * 2), 440)),
                new Tile(_game, _spriteBatch, new Vector2(3200 + (TileTexture.Width / 16 * 3), 440)),

                new Tile(_game, _spriteBatch, new Vector2(3600, 300)),
                new Tile(_game, _spriteBatch, new Vector2(3600 + TileTexture.Width / 16, 300)),
                new Tile(_game, _spriteBatch, new Vector2(3600 + (TileTexture.Width / 16 * 2), 300)),
                new Tile(_game, _spriteBatch, new Vector2(3600 + (TileTexture.Width / 16 * 3), 300)),

                new Tile(_game, _spriteBatch, new Vector2(3000, 230)),
                new Tile(_game, _spriteBatch, new Vector2(3000 + TileTexture.Width / 16, 230)),
                new Tile(_game, _spriteBatch, new Vector2(3000 + (TileTexture.Width / 16 * 2), 230)),
                new Tile(_game, _spriteBatch, new Vector2(3000 + (TileTexture.Width / 16 * 3), 230)),

                new Tile(_game, _spriteBatch, new Vector2(4000, 440)),
                new Tile(_game, _spriteBatch, new Vector2(4000 + TileTexture.Width / 16, 440)),
                new Tile(_game, _spriteBatch, new Vector2(4000 + (TileTexture.Width / 16 * 2), 440)),
                new Tile(_game, _spriteBatch, new Vector2(4000 + (TileTexture.Width / 16 * 3), 440)),

                new Tile(_game, _spriteBatch, new Vector2(4200, 230)),
                new Tile(_game, _spriteBatch, new Vector2(4200 + TileTexture.Width / 16, 230)),
                new Tile(_game, _spriteBatch, new Vector2(4200 + (TileTexture.Width / 16 * 2), 230)),
                new Tile(_game, _spriteBatch, new Vector2(4200 + (TileTexture.Width / 16 * 3), 230)),

                new Tile(_game, _spriteBatch, new Vector2(5600, 500)),
                new Tile(_game, _spriteBatch, new Vector2(5600 + TileTexture.Width / 16, 500)),
                new Tile(_game, _spriteBatch, new Vector2(5600 + (TileTexture.Width / 16 * 2), 500)),
                new Tile(_game, _spriteBatch, new Vector2(5600 + (TileTexture.Width / 16 * 3), 500)),

                new Tile(_game, _spriteBatch, new Vector2(5900, 280)),
                new Tile(_game, _spriteBatch, new Vector2(5900 + TileTexture.Width / 16, 280)),
                new Tile(_game, _spriteBatch, new Vector2(5900 + TileTexture.Width / 16 * 2, 280)),

                new Tile(_game, _spriteBatch, new Vector2(4700, 230)),
                new Tile(_game, _spriteBatch, new Vector2(4700 + TileTexture.Width / 16, 230)),

                new Tile(_game, _spriteBatch, new Vector2(5200, 230)),
                new Tile(_game, _spriteBatch, new Vector2(5200 + TileTexture.Width / 16, 230)),
                new Tile(_game, _spriteBatch, new Vector2(5200 + (TileTexture.Width / 16 * 2), 230)),
                new Tile(_game, _spriteBatch, new Vector2(5200 + (TileTexture.Width / 16 * 3), 230)),
                new Tile(_game, _spriteBatch, new Vector2(5200 + (TileTexture.Width / 16 * 4), 230)),
                new Tile(_game, _spriteBatch, new Vector2(5200 + (TileTexture.Width / 16 * 5), 230)),
                new Tile(_game, _spriteBatch, new Vector2(5200 + (TileTexture.Width / 16 * 6), 230)),
                new Tile(_game, _spriteBatch, new Vector2(5200 + (TileTexture.Width / 16 * 7), 230)),
                new Tile(_game, _spriteBatch, new Vector2(5200 + (TileTexture.Width / 16 * 8), 230)),

                new Tile(_game, _spriteBatch, new Vector2(6400, 280)),
                new Tile(_game, _spriteBatch, new Vector2(6400 + (TileTexture.Width / 16), 280)),
                new Tile(_game, _spriteBatch, new Vector2(6400 + (TileTexture.Width / 16 * 2), 280)),

                new Tile(_game, _spriteBatch, new Vector2(7000, 440)),
                new Tile(_game, _spriteBatch, new Vector2(7000 + TileTexture.Width / 16, 440)),
                new Tile(_game, _spriteBatch, new Vector2(7000 + (TileTexture.Width / 16 * 2), 440)),
                new Tile(_game, _spriteBatch, new Vector2(7000 + (TileTexture.Width / 16 * 3), 440)),

                new Tile(_game, _spriteBatch, new Vector2(7200, 230)),
                new Tile(_game, _spriteBatch, new Vector2(7200 + TileTexture.Width / 16, 230)),
                new Tile(_game, _spriteBatch, new Vector2(7200 + (TileTexture.Width / 16 * 2), 230)),
                new Tile(_game, _spriteBatch, new Vector2(7200 + (TileTexture.Width / 16 * 3), 230)),

                new Tile(_game, _spriteBatch, new Vector2(7800, 440)),
                new Tile(_game, _spriteBatch, new Vector2(7800 + TileTexture.Width / 16, 440)),
                new Tile(_game, _spriteBatch, new Vector2(7800 + (TileTexture.Width / 16 * 2), 440)),
                new Tile(_game, _spriteBatch, new Vector2(7800 + (TileTexture.Width / 16 * 3), 440)),

                new Tile(_game, _spriteBatch, new Vector2(8000, 230)),
                new Tile(_game, _spriteBatch, new Vector2(8000 + TileTexture.Width / 16, 230)),
                new Tile(_game, _spriteBatch, new Vector2(8000 + (TileTexture.Width / 16 * 2), 230)),
                new Tile(_game, _spriteBatch, new Vector2(8000 + (TileTexture.Width / 16 * 3), 230)),

                new Tile(_game, _spriteBatch, new Vector2(8300, 440)),
                new Tile(_game, _spriteBatch, new Vector2(8300 + TileTexture.Width / 16, 440)),
                new Tile(_game, _spriteBatch, new Vector2(8300 + (TileTexture.Width / 16 * 2), 440)),
                new Tile(_game, _spriteBatch, new Vector2(8300 + (TileTexture.Width / 16 * 3), 440)),

                new Tile(_game, _spriteBatch, new Vector2(8800, 300)),
                new Tile(_game, _spriteBatch, new Vector2(8800 + TileTexture.Width / 16, 300)),
                new Tile(_game, _spriteBatch, new Vector2(8800 + (TileTexture.Width / 16 * 2), 300)),
                new Tile(_game, _spriteBatch, new Vector2(8800 + (TileTexture.Width / 16 * 3), 300)),

                new Tile(_game, _spriteBatch, new Vector2(9000, 230)),
                new Tile(_game, _spriteBatch, new Vector2(9000 + TileTexture.Width / 16, 230)),
                new Tile(_game, _spriteBatch, new Vector2(9000 + (TileTexture.Width / 16 * 2), 230)),
                new Tile(_game, _spriteBatch, new Vector2(9000 + (TileTexture.Width / 16 * 3), 230)),

                new Tile(_game, _spriteBatch, new Vector2(9000, 440)),
                new Tile(_game, _spriteBatch, new Vector2(9000 + TileTexture.Width / 16, 440)),
                new Tile(_game, _spriteBatch, new Vector2(9000 + (TileTexture.Width / 16 * 2), 440)),
                new Tile(_game, _spriteBatch, new Vector2(9000 + (TileTexture.Width / 16 * 3), 440))]
                );
        }

    }
}