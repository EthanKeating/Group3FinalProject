namespace FinalProject.Entities
{
    public class Shark : Enemy
    {
        public bool IsHoming { get; set; }

        public Shark(Game game, Vector2 position, int speed) : base(game, position, speed)
        {
            Texture = game.Content.Load<Texture2D>("images/shark");
            Width = Texture.Width / 2;
            Height = Texture.Height;
        }

        public void Initialize()
        {
            Hitbox = new Hitbox(this, 15, 80, 60, 0);
            AttackHitbox = new Hitbox(this, 20, 80, 80, 0);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Texture.Bounds, Color.White, 0f, Vector2.Zero, 0.4f, SpriteEffects.None, 1f);
        }

        public override void Move()
        {
            var distance = 0;
        }
    }
}
