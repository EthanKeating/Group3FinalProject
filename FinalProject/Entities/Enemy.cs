using FinalProject.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FinalProject.Entities
{
    public class Enemy : BasicEntity
    {
        public Texture2D Texture { get; set; }

        public bool IsDead { get; set; } = false;

        private int leftBounds;
        private int rightBounds;
        private bool isMovingLeft = true;

        public Enemy(Game game, Vector2 position, int speed) : base(position, speed)
        {
            Texture = game.Content.Load<Texture2D>("images/shark");
            Width = Texture.Width / 2;
            Height = Texture.Height;
            ResetBounds();
        }

        public void Initialize()
        {
            Hitbox = new Hitbox(this, 15, 80, 60, 0);
            AttackHitbox = new Hitbox(this, 20, 80, 80, 0);
        }

        public void Move()
        {
            if (isMovingLeft)
            {
                if (Position.X <= leftBounds)
                {
                    Position = new Vector2(leftBounds, Position.Y);
                    isMovingLeft = false;
                }
                else
                {
                    Position = new Vector2(Position.X - Speed, Position.Y);
                }
            }
            else
            {
                if (Position.X >= rightBounds)
                {
                    Position = new Vector2(rightBounds, Position.Y);
                    isMovingLeft = true;
                }
                else
                {
                    Position = new Vector2(Position.X + Speed, Position.Y);
                }
            }
        }

        public void UpdateBounds(int delta)
        {
            Position = new Vector2(Position.X - delta, Position.Y);
            leftBounds -= delta;
            rightBounds -= delta;
        }

        public void ResetBounds()
        {
            leftBounds = Game1.ScreenWidth / 5 * 3;
            rightBounds = Game1.ScreenWidth / 5 * 4;
        }
    }
}
