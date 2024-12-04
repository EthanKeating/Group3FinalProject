using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Entities
{
    public class Tile : BasicEntity
    {
        public Texture2D Texture { get; set; }
        public BubbleAnimation BubbleAnimation { get; set; }

        public Tile(Game game, SpriteBatch spriteBatch, Vector2 position) : base(position, 0)
        {
            Position = position;
            Texture = game.Content.Load<Texture2D>("images/bubble");
            BubbleAnimation = new BubbleAnimation(game, spriteBatch, Texture, Position, 20);
            game.Components.Add(BubbleAnimation);
            Width = Texture.Width / 16;
            Height = Texture.Height;
        }

        public void Initialize()
        {
            // makes the hitbox a 1 - 1 relation to the object size
            Hitbox = new Hitbox(this, 0, 0, 0, 0);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            BubbleAnimation.show();
        }

        public void Update(int deltaX)
        {
            Position = new Vector2(Position.X - deltaX, Position.Y);
            BubbleAnimation.UpdatePosition(Position);
        }
    }
}
