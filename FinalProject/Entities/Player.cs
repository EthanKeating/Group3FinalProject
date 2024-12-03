using FinalProject.Animations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject.Entities
{
    public class Player : BasicEntity
    {
        public CrabIdleAnimation IdleAnimation { get; set; }
        public CrabWalkAnimation WalkAnimation { get; set; }
        public CrabAttackAnimation AttackAnimation { get; set; }

        public bool IsAttacking { get; set; }

        public override Rectangle Hitbox { get { return new Rectangle((int)Position.X, (int)Position.Y + 10, animationWidth - 10, animationHeight); } }
        public Rectangle AttackHitbox { get { return new Rectangle((int)Position.X + animationWidth / 2, (int)Position.Y, animationWidth / 2 + 5, animationHeight); } }

        private const int JUMP_HEIGHT = 25;
        private const int GRAVITY = 1;
        private const int FLOOR_HEIGHT = 70;
        private const int IDLE_ANIM_SPEED = 30;
        private const int WALK_ANIM_SPEED = 5;
        private const int ATTACK_ANIM_SPEED = 10;
        private const int ATTACK_ = 20;

        private readonly int animationWidth;
        private readonly int animationHeight;
        private readonly int floorHeight = Game1.ScreenHeight - FLOOR_HEIGHT;

        private float velocity;
        private bool isJumping;
        private bool isMoving;

        public Player(Game game, SpriteBatch spriteBatch, int speed) : base(new Vector2(20, Game1.ScreenHeight - FLOOR_HEIGHT), speed)
        {
            velocity = 0;
            isJumping = false;

            IdleAnimation = new CrabIdleAnimation(game, spriteBatch, game.Content.Load<Texture2D>("images/idle"), Position, IDLE_ANIM_SPEED);
            game.Components.Add(IdleAnimation);
            WalkAnimation = new CrabWalkAnimation(game, spriteBatch, game.Content.Load<Texture2D>("images/walk"), Position, WALK_ANIM_SPEED);
            game.Components.Add(WalkAnimation);
            AttackAnimation = new CrabAttackAnimation(game, spriteBatch, game.Content.Load<Texture2D>("images/attack"), Position, ATTACK_ANIM_SPEED);
            game.Components.Add(AttackAnimation);

            animationWidth = IdleAnimation.frames[0].Width;
            animationHeight = IdleAnimation.frames[0].Height;
        }

        public void Initialize()
        {
            AttackAnimation.Player = this;
        }

        public void Update()
        {
            IdleAnimation.UpdatePosition(Position);
            WalkAnimation.UpdatePosition(Position);
            AttackAnimation.UpdatePosition(Position);

            Move();
            Attack();
        }

        public void Draw()
        {
            if (IsAttacking)
            {
                // AttackAnimation.show();
                WalkAnimation.hide();
                IdleAnimation.hide();
            }
            else if (isMoving)
            {
                AttackAnimation.hide();
                WalkAnimation.show();
                IdleAnimation.hide();
            }
            else
            {
                AttackAnimation.hide();
                WalkAnimation.hide();
                IdleAnimation.show();
            }
        }

        private void Move()
        {
            KeyboardState keyboardState = Keyboard.GetState();

            isMoving = false;

            // Move player left
            if (keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left))
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
            if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right))
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
            if (Position.Y + animationHeight >= floorHeight)
            {
                Position = new Vector2(Position.X, floorHeight - animationHeight);
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

        private void Attack()
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.F) && !IsAttacking)
            {
                IsAttacking = true;
                AttackAnimation.show();
            }
        }
    }
}
