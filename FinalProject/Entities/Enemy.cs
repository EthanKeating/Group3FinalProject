namespace FinalProject.Entities
{
    public abstract class Enemy : BasicEntity
    {
        public Texture2D Texture { get; set; }
        public bool IsDead { get; set; } = false;

        public Enemy(Game game, Vector2 position, int speed) : base(position, speed)
        {
        }

        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void Update(int deltaX);
        protected abstract void Move();
    }
}
