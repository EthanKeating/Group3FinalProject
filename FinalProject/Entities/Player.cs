using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace FinalProject.Entities
{
    internal class Player : BasicEntity
    {
        public bool LockedToCenter { get; set; }

        private const int JUMP_HEIGHT = 30;
        private const int GRAVITY = 2;

        private float velocity;
        private bool isJumping;

        public Player (int speed) : base(new Vector2(20, Game1.ScreenHeight / 5 * 4), speed)
        {
            velocity = 0;
            isJumping = true;
            LockedToCenter = false;
        }

        public void Move()
        {
            KeyboardState keyboardState = Keyboard.GetState();

            // Move player left
            if (keyboardState.IsKeyDown(Keys.A))
            {
                if (LockedToCenter)
                {
                    // TODO: Move background left
                }
                else
                {
                    if (Position.X <= 0)
                    {
                        Position = new Vector2(0, Position.Y);
                    }
                    else
                    {
                        Position = new Vector2(Position.X - Speed, Position.Y);
                    }
                }
            }

            // Move player right
            if (keyboardState.IsKeyDown(Keys.D))
            {
                if (LockedToCenter)
                {
                    // TODO: Move background right
                }
                else
                {
                    if (Position.X + Texture.Width >= Game1.ScreenWidth)
                    {
                        Position = new Vector2(Game1.ScreenWidth - Texture.Width, Position.Y);
                    }
                    else
                    {
                        Position = new Vector2(Position.X + Speed, Position.Y);
                    }
                }
            }

            // Temporary fix to stop player falling off the bottom of the screen
            if (Position.Y + Texture.Height >= Game1.ScreenHeight)
            {
                Position = new Vector2(Position.X, Game1.ScreenHeight -  Texture.Height);
                isJumping = false;
            }

            // Begin jumping if pressing space
            if (!isJumping && keyboardState.IsKeyDown(Keys.Space))
            {
                isJumping = true;
                velocity = JUMP_HEIGHT;
            }

            // Move player vertically according to velocity
            if (isJumping)
            {
                Position = new Vector2(Position.X, Position.Y - velocity);
                velocity -= GRAVITY;
            }
        }
    }
}
