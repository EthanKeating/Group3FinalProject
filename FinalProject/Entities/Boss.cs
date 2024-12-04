using Microsoft.Xna.Framework.Graphics;
using System;

namespace FinalProject.Entities
{
    public class Boss : BasicEntity
    {
        private float baseYPosition;
        private float bobOffset;
        private float bobSpeed = 3f;
        private float bobHeight = 10f;

        private float time = 0;
        public int health = 3;

        public DateTime nextDamage = DateTime.Now;

        public Texture2D Texture { get; set; }
        public Texture2D HealthTexture { get; set; }

        public HealthAnimation HPAnimation { get; set; }
        public Vector2 HPPosition { get; set; }

        private Game _game;
        public bool IsAttacking { get; set; } = false;
        public BubbleAttack BubbleAttack { get; set; }

        public Boss(Game game, SpriteBatch spriteBatch, Vector2 position, int speed) : base(position, speed)
        {
            _game = game;
            Texture = game.Content.Load<Texture2D>("images/seaHorse");
            HealthTexture = game.Content.Load<Texture2D>("images/health");
            HPAnimation = new HealthAnimation(game, spriteBatch, HealthTexture, position, 10);
            game.Components.Add(HPAnimation);
            HPAnimation.frameIndex = 0;
            BubbleAttack = new BubbleAttack(game, spriteBatch, Position, 3);
            Width = Texture.Width / 2;
            Height = Texture.Height;

            baseYPosition = Position.Y;
            HPPosition = new Vector2(position.X, position.Y - Height - HPAnimation.frames[0].Height * 2);
        }

        public void Initialize()
        {
            Hitbox = new Hitbox(this, 0, 0, 0, 0);
            AttackHitbox = new Hitbox(this, 0, 0, 0, 0);
        }

        public void Update(float delta)
        {
            time += delta;

            bobOffset = (float)Math.Sin(time * bobSpeed) * bobHeight;
            Position = new Vector2(Position.X, baseYPosition + bobOffset);

            if (!isDead())
                HPAnimation.show();
            HPAnimation.frameIndex = 3 - Math.Max(0, health);
            //HPAnimation.frameIndex = 2;
            HPAnimation.UpdatePosition(new Vector2(Position.X, Position.Y - 60));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!isDead())
            {
                if (nextDamage < DateTime.Now)
                    spriteBatch.Draw(Texture, Position, Texture.Bounds, Color.White, 0f, Vector2.Zero, 0.4f, SpriteEffects.None, 1f);
                else
                    spriteBatch.Draw(Texture, Position, Texture.Bounds, Color.Red * 0.5f, 0f, Vector2.Zero, 0.4f, SpriteEffects.None, 1f);
            }
        }

        public void Damage()
        {
            if (nextDamage < DateTime.Now)
            {
                health--;
                nextDamage = DateTime.Now.AddSeconds(1);
            }
            if (isDead())
            {
                HPAnimation.hide();
            }
        }

        public bool isDead()
        {
            return health <= 0;
        }

        public void Attack()
        {
            Game1 game = _game as Game1;
            Player player = game._screenManager.GetActiveScreen().Player;
            
            if (!isDead() && !BubbleAttack.IsDead && Vector2.Distance(Position, player.Position) <= 400)
            {
                BubbleAttack.Position = Position;
                BubbleAttack.Target = new Vector2(player.Position.X + player.Width / 2, player.Position.Y + player.Height / 2);
            }
        }
    }
}
