using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Entities
{
    public class Tile : BasicEntity
    {
        // Going to take out a lot of this useless stuff
        public Texture2D Texture { get; set; }

        public Tile(Game game, Vector2 position) : base(position, 0)
        {
            Position = position;
            Texture = game.Content.Load<Texture2D>("black_box");
            Width = Texture.Width;
            Height = Texture.Height;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Might need to adjust this stuff I just copied it from another class
            spriteBatch.Draw(Texture, Position, Texture.Bounds, Color.White, 0f, Vector2.Zero, 0.4f, SpriteEffects.None, 1f);
        }

        public void Initialize()
        {
            // makes the hitbox a 1 - 1 relation to the object size
            Hitbox = new Hitbox(this, 0, 0, 0, 0);
        }
    }
}
