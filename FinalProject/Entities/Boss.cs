using Microsoft.Xna.Framework.Graphics;
using System;

namespace FinalProject.Entities
{
    public class Boss : BasicEntity
    {
        private float baseYPosition;
        private float bobOffset;
        private float bobSpeed = 3f;
        private float bobHeight = 10f;

        private float time = 0;

        public Texture2D Texture { get; set; }

        public Boss(Game game, Vector2 position, int speed) : base(position, speed)
        {
            Texture = game.Content.Load<Texture2D>("images/seaHorse");
            Width = Texture.Width / 2;
            Height = Texture.Height;

            baseYPosition = Position.Y;
        }

        public void Initialize()
        {
            Hitbox = new Hitbox(this, 15, 80, 60, 0);
            AttackHitbox = new Hitbox(this, 20, 80, 80, 0);
        }

        public void Update(float delta)
        {
            time += delta;


            bobOffset = (float)Math.Sin(time * bobSpeed) * bobHeight;
            Position = new Vector2(Position.X, baseYPosition + bobOffset);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Texture.Bounds, Color.White, 0f, Vector2.Zero, 0.4f, SpriteEffects.None, 1f);
        }
    }
}
