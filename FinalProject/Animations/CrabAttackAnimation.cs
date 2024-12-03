namespace FinalProject.Animations
{
    public class CrabAttackAnimation : DrawableGameComponent
    {
        public Player Player { get; set; }
        public Vector2 Position { get => position; set => position = value; }

        private const int ROWS = 1;
        private const int COLS = 2;

        private SpriteBatch sb;
        private Texture2D tex;
        private Vector2 position;
        private int delay;

        private SoundEffect attackSound;

        private Vector2 dimension;
        public List<Rectangle> frames;
        private int frameIndex = -1;

        private int delayCounter;

        private Game g;

        public CrabAttackAnimation(Game game, SpriteBatch sb,
            Texture2D tex, Vector2 position, int delay) : base(game)
        {
            this.g = game;
            this.sb = sb;
            this.tex = tex;
            this.Position = position;
            this.delay = delay;
            this.dimension = new Vector2(tex.Width / COLS, tex.Height / ROWS);

            attackSound = game.Content.Load<SoundEffect>("soundEffects/snap");

            createFrames();
            this.Enabled = false;
            this.Visible = false;
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
            Player.IsAttacking = false;
        }

        public void show()
        {
            this.Enabled = true;
            this.Visible = true;
            frameIndex = 0;
        }

        public override void Update(GameTime gameTime)
        {
            delayCounter++;

            if (delayCounter > delay)
            {
                frameIndex++;

                if (frameIndex % 2 == 1)
                {
                    attackSound.Play();
                }

                if (frameIndex >= ROWS * COLS)
                {
                    frameIndex = 0;

                    hide();
                }
                delayCounter = 0;
            }

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
                sb.Draw(tex, Position, frames[frameIndex % 2], Color.White);
                sb.End();
            }

            base.Draw(gameTime);
        }
    }
}
