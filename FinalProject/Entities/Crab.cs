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
            Width = Texture.Width / 2;
            Height = Texture.Height;

            ResetBounds();
        }

        public void Initialize()
        {
            Hitbox = new Hitbox(this, 15, 80, 60, 0);
            AttackHitbox = new Hitbox(this, 20, 80, 80, 0);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            IdleAnimation.show();
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

        public override void Move()
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
