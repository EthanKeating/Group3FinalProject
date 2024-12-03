using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FinalProject.Entities
{
    public class Boss : BasicEntity
    {
        public override Rectangle Hitbox { get { return new Rectangle((int)Position.X + 10, (int)Position.Y + 10, Texture.Width - 10, Texture.Height - 10); } }

        public Boss(Vector2 position, int speed) : base(position, speed)
        {

        }
    }
}
