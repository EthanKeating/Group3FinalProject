namespace FinalProject.Entities
{
    public class Crab : Enemy
    {
        public Crab(Game game, Vector2 position, int speed) : base(game, position, speed)
        {
            Texture = game.Content.Load<Texture2D>("images/idleEvilCrab");
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
            
        }

        public override void Move()
        {
            
        }
    }
}
