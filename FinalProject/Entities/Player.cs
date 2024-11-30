using FinalProject.Animations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject.Entities
{
    internal class Player : BasicEntity
    {
        public bool LockedToCenter { get; set; }

        private const int JUMP_HEIGHT = 35;
        private const int GRAVITY = 2;
        private const int FLOOR_HEIGHT = 70;

        private float velocity;
        private bool isJumping;
        private bool isMoving;

        public Texture2D IdleTexture { get; set; }
        public Texture2D WalkTexture { get; set; }
        public Texture2D ClawTexture { get; set; }
        public CrabIdleAnimation IdleAnimation { get; set; }
        public CrabWalkAnimation WalkAnimation { get; set; }
        public CrabAttackAnimation AttackAnimation { get; set; }

        public Player(int speed) : base(new Vector2(20, FLOOR_HEIGHT + 1), speed)
        {
            velocity = 0;
            isJumping = true;
            LockedToCenter = false;
        }

        public void Move()
        {
            KeyboardState keyboardState = Keyboard.GetState();

            isMoving = false;

            // Move player left
            if (keyboardState.IsKeyDown(Keys.A))
            {
                isMoving = true;

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
                isMoving = true;

                if (LockedToCenter)
                {
                    // TODO: Move background right
                }
                else
                {
                    if (Position.X + IdleAnimation.frames[0].Width >= Game1.ScreenWidth)
                    {
                        Position = new Vector2(Game1.ScreenWidth - IdleAnimation.frames[0].Width, Position.Y);
                    }
                    else
                    {
                        Position = new Vector2(Position.X + Speed, Position.Y);
                    }
                }
            }

            // Stop player falling off the bottom of the screen
            if (Position.Y + IdleAnimation.frames[0].Height >= Game1.ScreenHeight - FLOOR_HEIGHT)
            {
                Position = new Vector2(Position.X, Game1.ScreenHeight - IdleAnimation.frames[0].Height - FLOOR_HEIGHT);
                isJumping = false;
            }

            // Begin jumping
            if (!isJumping && keyboardState.IsKeyDown(Keys.Space))
            {
                isMoving = true;
                isJumping = true;
                velocity = JUMP_HEIGHT;
            }

            // Move player vertically
            if (isJumping)
            {
                isMoving = true;
                Position = new Vector2(Position.X, Position.Y - velocity);
                velocity -= GRAVITY;
            }
        }

        public void Update()
        {
            Move();
            IdleAnimation.UpdatePosition(Position);
            WalkAnimation.UpdatePosition(Position);
        }

        public void Draw(GameTime gameTime)
        {
            if (isMoving)
            {
                IdleAnimation.hide();
                WalkAnimation.show();
            }
            else
            {
                WalkAnimation.hide();
                IdleAnimation.show();
            }
        }
    }
}
