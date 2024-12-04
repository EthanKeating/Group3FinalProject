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
        public Texture2D HealthTexture { get; set; }

        public HealthAnimation HPAnimation { get; set; }
        public Vector2 HPPosition { get; set; }

        public Boss(Game game, SpriteBatch spriteBatch, Vector2 position, int speed) : base(position, speed)
        {
            Texture = game.Content.Load<Texture2D>("images/seaHorse");
            HealthTexture = game.Content.Load<Texture2D>("images/health");
            HPAnimation = new HealthAnimation(game, spriteBatch, HealthTexture, position, 10);
            game.Components.Add(HPAnimation);
            HPAnimation.frameIndex = 0;
            Width = Texture.Width / 2;
            Height = Texture.Height;

            baseYPosition = Position.Y;
            HPPosition = new Vector2(position.X, position.Y - Height - HPAnimation.frames[0].Height * 2);
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

            HPAnimation.show();
            HPAnimation.UpdatePosition(new Vector2(Position.X, Position.Y - 60));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Texture.Bounds, Color.White, 0f, Vector2.Zero, 0.4f, SpriteEffects.None, 1f);
        }
    }
}
