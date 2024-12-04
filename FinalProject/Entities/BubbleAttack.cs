namespace FinalProject.Entities
{
    public class BubbleAttack : Enemy
    {
        public Vector2 Target { get; set; }
        public BubbleAnimation BubbleAnimation { get; set; }
        public BubblePopAnimation PopAnimation { get; set; }
        public bool IsActive { get; set; } = false;
        public bool IsPopped { get; set; } = false;

        private Rectangle distance;

        public BubbleAttack(Game game, SpriteBatch spriteBatch, Vector2 position, int speed) : base(game, position, speed)
        {
            Texture = game.Content.Load<Texture2D>("images/bubble");
            BubbleAnimation = new BubbleAnimation(game, spriteBatch, Texture, Position, 1);
            game.Components.Add(BubbleAnimation);
            PopAnimation = new BubblePopAnimation(game, spriteBatch, game.Content.Load<Texture2D>("images/pop"), Position, 1);
            game.Components.Add(PopAnimation);
            Width = Texture.Width / 16;
            Height = Texture.Height;
        }

        public void Initialize()
        {
            Hitbox = new Hitbox(this, 10, 10, 10, 10);
            AttackHitbox = new Hitbox(this, 10, 10, 10, 10);
            PopAnimation.bubbleAttack = this;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (IsActive && !IsPopped)
            {
                BubbleAnimation.show();
                PopAnimation.hide();
            }
            else if (IsPopped)
            {
                BubbleAnimation.hide();
                PopAnimation.show();
            }
            else
            {
                BubbleAnimation.hide();
                PopAnimation.hide();
            }
        }

        public override void Update(int deltaX)
        {
            Move();
            BubbleAnimation.UpdatePosition(Position);
            PopAnimation.UpdatePosition(Position);
        }

        protected override void Move()
        {
            if (!IsPopped)
            {
                Position = new Vector2(Position.X - distance.Width / Speed, Position.Y + distance.Height / Speed);

                if (Position.Y > Game1.ScreenHeight || Position.X < 0)
                {
                    IsActive = false;
                    BubbleAnimation.hide();
                }
            }
        }

        public void SetTarget(Vector2 _target)
        {
            Target = _target;
            distance = new Rectangle((int)Target.X, (int)Position.Y, (int)(Position.X - Target.X), (int)(Target.Y - Position.Y));
        }
    }
}
