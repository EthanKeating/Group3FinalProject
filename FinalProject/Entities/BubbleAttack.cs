namespace FinalProject.Entities
{
    public class BubbleAttack : Enemy
    {
        public Vector2 Target { get; set; }
        public BubbleAnimation BubbleAnimation { get; set; }
        public bool IsActive { get; set; } = false;

        public BubbleAttack(Game game, SpriteBatch spriteBatch, Vector2 position, int speed) : base(game, position, speed)
        {
            Texture = game.Content.Load<Texture2D>("images/bubble");
            BubbleAnimation = new BubbleAnimation(game, spriteBatch, Texture, Position, 10);
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
        }

        public override void Update(int deltaX)
        {
            Move();
        }

        protected override void Move()
        {
            //Vector2 distance = Position - Target;
            //Position = new Vector2(distance.X * Speed, distance.Y * Speed);

            //if (Position == Target)
            //{
            //    IsActive = false;
            //    BubbleAnimation.hide();
            //}
        }
    }
}
