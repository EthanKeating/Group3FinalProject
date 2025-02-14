﻿namespace FinalProject.Animations
{
    public class BubblePopAnimation : DrawableGameComponent
    {
        public BubbleAttack bubbleAttack;

        private SpriteBatch sb;
        private Texture2D tex;
        private Vector2 position;
        private int delay;

        private Vector2 dimension;
        public List<Rectangle> frames;
        private int frameIndex = 0;

        private SoundEffect popSound;

        private int delayCounter;

        private const int ROWS = 1;
        private const int COLS = 10;


        public Vector2 Position { get => position; set => position = value; }

        private Game g;

        public BubblePopAnimation(Game game, SpriteBatch sb,
            Texture2D tex, Vector2 position, int delay) : base(game)
        {
            this.g = game;
            this.sb = sb;
            this.tex = tex;
            this.Position = position;
            this.delay = delay;
            this.dimension = new Vector2(tex.Width / COLS, tex.Height / ROWS);

            popSound = game.Content.Load<SoundEffect>("soundEffects/pop");

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
            delayCounter++;
            if (delayCounter > delay)
            {
                frameIndex++;

                if (frameIndex == 0) popSound.Play();

                if (frameIndex >= ROWS * COLS)
                {
                    frameIndex = 0;
                    bubbleAttack.IsActive = false;
                    bubbleAttack.IsPopped = false;
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
                sb.Draw(tex, Position, frames[frameIndex], Color.White);
                sb.End();
            }

            base.Draw(gameTime);
        }
    }
}
