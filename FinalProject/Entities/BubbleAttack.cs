namespace FinalProject.Entities
{
    public class BubbleAttack : Enemy
    {
        public Vector2 Target { get; set; }
        public BubbleAnimation BubbleAnimation { get; set; }
        public BubblePopAnimation PopAnimation { get; set; }
        public bool IsActive { get; set; } = false;
        private Rectangle distance;

        public BubbleAttack(Game game, SpriteBatch spriteBatch, Vector2 position, int speed) : base(game, position, speed)
        {
            Texture = game.Content.Load<Texture2D>("images/bubble");
            BubbleAnimation = new BubbleAnimation(game, spriteBatch, Texture, Position, 10);
            PopAnimation = new BubblePopAnimation(game, spriteBatch, game.Content.Load<Texture2D>("images/pop"), Position, 10);
            game.Components.Add(BubbleAnimation);
            Width = Texture.Width / 16;
            Height = Texture.Height;
        }

        public void Initialize()
        {
            Hitbox = new Hitbox(this, 0, 0, 0, 0);
            AttackHitbox = new Hitbox(this, 0, 0, 0, 0);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (IsActive)
            {
                BubbleAnimation.show();
            }
            else
            {
                BubbleAnimation.hide();
            }
        }

        public override void Update(int deltaX)
        {
            Move();
            BubbleAnimation.UpdatePosition(Position);
        }

        protected override void Move()
        {
            Position = new Vector2(Position.X - distance.Width / Speed, Position.Y + distance.Height / Speed);

            if (Position.Y > Game1.ScreenHeight)
            {
                IsActive = false;
                BubbleAnimation.hide();
            }
        }

        public void SetTarget(Vector2 _target)
        {
            Target = _target;
            distance = new Rectangle((int)Target.X, (int)Position.Y, (int)(Position.X - Target.X), (int)(Target.Y - Position.Y));
        }
    }
}
