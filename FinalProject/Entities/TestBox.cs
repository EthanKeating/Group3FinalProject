namespace FinalProject.Entities
{
    public class TestBox : Enemy
    {
        public TestBox(Game game, Vector2 position, int speed) : base(game, position, speed)
        {
            Texture = game.Content.Load<Texture2D>("black_box");
            Width = Texture.Width;
            Height = Texture.Height;
        }

        public void Initialize()
        {
            Hitbox = new Hitbox(this, 0, 0, 0, 0);
            AttackHitbox = new Hitbox(this, 0, 0, 0, 0);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!IsDead)
            {
                spriteBatch.Draw(Texture, Position, Color.White);
            }
        }

        public override void Update(int deltaX)
        {
        }

        protected override void Move()
        {
        }
    }
}
