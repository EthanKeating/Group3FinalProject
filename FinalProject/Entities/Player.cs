using FinalProject.Animations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject.Entities
{
    internal class Player : BasicEntity
    {
        private const int JUMP_HEIGHT = 25;
        private const int GRAVITY = 1;
        private const int FLOOR_HEIGHT = 70;

        private readonly int animationWidth;
        private readonly int animationHeight;

        private float velocity;
        private bool isJumping;
        private bool isMoving;

        public CrabIdleAnimation IdleAnimation { get; set; }
        public CrabWalkAnimation WalkAnimation { get; set; }
        public CrabAttackAnimation AttackAnimation { get; set; }

        public Player(Game game, SpriteBatch spriteBatch, int speed) : base(new Vector2(20, FLOOR_HEIGHT + 1), speed)
        {
            velocity = 0;
            isJumping = true;

            IdleAnimation = new CrabIdleAnimation(game, spriteBatch, game.Content.Load<Texture2D>("images/idle"), Position, 30);
            game.Components.Add(IdleAnimation);
            WalkAnimation = new CrabWalkAnimation(game, spriteBatch, game.Content.Load<Texture2D>("images/walk"), Position, 10);
            game.Components.Add(WalkAnimation);
            AttackAnimation = new CrabAttackAnimation(game, spriteBatch, game.Content.Load<Texture2D>("images/claw"), Position, 40);
            game.Components.Add(AttackAnimation);

            animationWidth = IdleAnimation.frames[0].Width;
            animationHeight = IdleAnimation.frames[0].Height;
        }

        public void Move()
        {
            KeyboardState keyboardState = Keyboard.GetState();

            isMoving = false;

            // Move player left
            if (keyboardState.IsKeyDown(Keys.A))
            {
                isMoving = true;

                if (Position.X <= 0)
                {
                    Position = new Vector2(0, Position.Y);
                }
                else
                {
                    Position = new Vector2(Position.X - Speed, Position.Y);
                }
            }

            // Move player right
            if (keyboardState.IsKeyDown(Keys.D))
            {
                isMoving = true;

                if (Position.X + animationWidth >= Game1.ScreenWidth)
                {
                    Position = new Vector2(Game1.ScreenWidth - animationWidth, Position.Y);
                }
                else
                {
                    Position = new Vector2(Position.X + Speed, Position.Y);
                }
            }

            // Stop player falling off the bottom of the screen
            if (Position.Y + animationHeight >= Game1.ScreenHeight - FLOOR_HEIGHT)
            {
                Position = new Vector2(Position.X, Game1.ScreenHeight - animationHeight - FLOOR_HEIGHT);
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

        public void Draw()
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
