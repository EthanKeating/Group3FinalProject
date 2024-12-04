namespace FinalProject.Entities
{
    public class Crab : Enemy
    {
        public EvilCrabIdleAnimation IdleAnimation { get; set; }

        private int leftBounds;
        private int rightBounds;
        private bool isMovingLeft = true;

        public Crab(Game game, SpriteBatch spriteBatch, Vector2 position) : base(game, position, 1)
        {
            Texture = game.Content.Load<Texture2D>("images/idleEvilCrab");
            IdleAnimation = new EvilCrabIdleAnimation(game, spriteBatch, Texture, position, 10);
            game.Components.Add(IdleAnimation);
            Width = Texture.Width / 2;
            Height = Texture.Height;

            ResetBounds();
        }

        public void Initialize()
        {
            Hitbox = new Hitbox(this, 10, 10, 10, 10);
            AttackHitbox = new Hitbox(this, 10, 10, 10, 10);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!IsDead)
            {
                IdleAnimation.show();
            }
            else
            {
                IdleAnimation.hide();
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
            leftBounds = (int)StartingPosition.X - 200;
            rightBounds = (int)StartingPosition.X;
        }

        public override void Update(int deltaX)
        {
            Move();

            IdleAnimation.UpdatePosition(Position);
        }

        protected override void Move()
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
    }
}
