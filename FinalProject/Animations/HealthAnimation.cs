namespace FinalProject.Animations
{
    public class HealthAnimation : DrawableGameComponent
    {
        private SpriteBatch sb;
        private Texture2D tex;
        private Vector2 position;
        private int delay;

        private Vector2 dimension;
        public List<Rectangle> frames;
        public int frameIndex = -1;

        private int delayCounter;

        private const int ROWS = 4;
        private const int COLS = 1;


        public Vector2 Position { get => position; set => position = value; }

        private Game g;

        public HealthAnimation(Game game, SpriteBatch sb,
            Texture2D tex, Vector2 position, int delay) : base(game)
        {
            this.g = game;
            this.sb = sb;
            this.tex = tex;
            this.Position = position;
            this.delay = delay;
            this.dimension = new Vector2(tex.Width / COLS, tex.Height / ROWS);

            createFrames();
            hide();
        }

        private void createFrames()
        {
            frames = new List<Rectangle>();
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLS; j++)
                {
                    int x = j * (int)dimension.X;
                    int y = i * (int)dimension.Y;
                    Rectangle r = new Rectangle(x, y, (int)dimension.X, (int)dimension.Y);
                    frames.Add(r);

                }
            }
        }

        public void hide()
        {
            this.Enabled = false;
            this.Visible = false;
        }

        public void show()
        {
            this.Enabled = true;
            this.Visible = true;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public void UpdatePosition(Vector2 _position)
        {
            Position = _position;
        }

        public override void Draw(GameTime gameTime)
        {
            if (frameIndex >= 0)
            {
                sb.Begin();
                sb.Draw(tex, Position, frames[frameIndex], Color.White, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0);
                sb.End();
            }

            base.Draw(gameTime);
        }
    }
}
