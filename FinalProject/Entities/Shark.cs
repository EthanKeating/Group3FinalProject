namespace FinalProject.Entities
{
    public class Shark : Enemy
    {
        public bool IsHoming { get; set; }

        private Game _game;
        private const int HOMING_DISTANCE = 700;

        public Shark(Game game, Vector2 position, int speed) : base(game, position, speed)
        {
            _game = game;
            Texture = game.Content.Load<Texture2D>("images/shark");
            Width = (int)(Texture.Width * 0.4);
            Height = (int)(Texture.Height * 0.4);
        }

        public void Initialize()
        {
            Hitbox = new Hitbox(this, 20, 80, 10, 40);
            AttackHitbox = new Hitbox(this, 20, 80, 10, 40);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!IsDead)
            {
                spriteBatch.Draw(Texture, Position, Texture.Bounds, Color.White, 0f, Vector2.Zero, 0.4f, SpriteEffects.None, 1f);
            }
        }

        public override void Update(int deltaX)
        {
            Move();
        }

        protected override void Move()
        {
            Game1 game = _game as Game1;
            Vector2 playerPosition = game._screenManager.GetActiveScreen().Player.Position;
            var distance = Vector2.Distance(Position, playerPosition);

            if (distance < HOMING_DISTANCE && playerPosition.X < Position.X)
            {
                Position = new Vector2(Position.X - Speed, Position.Y);
            }
        }
    }
}
