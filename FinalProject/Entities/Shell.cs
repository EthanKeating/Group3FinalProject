namespace FinalProject.Entities
{
    public class Shell : BasicEntity
    {

        private Game _game;
        private Texture2D Texture;

        public Shell(Game game, Vector2 position) : base(position, 0)
        {
            _game = game;
            Texture = game.Content.Load<Texture2D>("images/shell");
            Width = Texture.Width / 2;
            Height = Texture.Height;
        }

        public void Initialize()
        {
            Hitbox = new Hitbox(this, 0, 0, 0, 0);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }

        public void Update(int deltaX)
        {
        }
    }
}
