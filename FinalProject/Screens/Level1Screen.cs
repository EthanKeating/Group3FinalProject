using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Screens
{
    class Level1Screen : IScreen
    {
        public ScreenType ScreenType => ScreenType.Level1;
        private Game _game;

        private Texture2D backgroundSprite;

        private Player player;
        private Shark shark1;
        private Shark shark2;

        private List<Enemy> enemies;
        private List<Shark> sharks;

        public Vector2 backgroundPosition = new Vector2(0, 0);
        public Vector2 playerStartingPosition = new Vector2(20, Game1.ScreenHeight - 70);
        public Vector2 shark1StartingPosition = new Vector2(Game1.ScreenWidth / 5 * 4, Game1.ScreenHeight - 200);
        public Vector2 shark2StartingPosition = new Vector2(Game1.ScreenWidth / 5 * 4 + Game1.ScreenWidth, Game1.ScreenHeight - 200);

        public Level1Screen(Game game, SpriteBatch spriteBatch)
        {
            _game = game;

            backgroundSprite = _game.Content.Load<Texture2D>("images/background");

            player = new Player(_game, spriteBatch, playerStartingPosition, 9);
            player.Initialize();

            shark1 = new Shark(_game, shark1StartingPosition, 2);
            shark1.Initialize();

            shark2 = new Shark(_game, shark2StartingPosition, 2);
            shark2.Initialize();

            enemies = [shark1, shark2];
            sharks = [shark1, shark2];
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundSprite, backgroundPosition, Color.White);

            player.Draw();

            foreach (Enemy enemy in enemies)
            {
                if (!enemy.IsDead)
                {
                    enemy.Draw(spriteBatch);
                }
            }

        }

        public void Update(ScreenManager _screenManager, float delta)
        {
            // Calculate how much background moves
            int startX = (int)player.Position.X;
            player.Update();
            int deltaX = (int)player.Position.X - startX;
            
            foreach (Enemy enemy in enemies)
            {
                enemy.Move();
            }

            int rightBound = (int)Game1.ScreenWidth / 4;

            // Move background
            if (player.Position.X > rightBound)
            {
                if (backgroundPosition.X > -backgroundSprite.Width + 1280)
                {
                    player.Position = new Vector2(startX, player.Position.Y);
                    backgroundPosition.X -= deltaX;
                    
                    foreach (Shark shark in sharks)
                    {
                        shark.UpdateBounds(deltaX);
                    }
                }
            }

            // Stop background from moving past end
            if (backgroundPosition.X < -backgroundSprite.Width + 1280)
            {
                backgroundPosition.X = -backgroundSprite.Width + 1280;
            }

            // Move background backwards
            if (player.Position.X < 0)
            {
                player.Position = new Vector2(startX, player.Position.Y);
                backgroundPosition.X -= deltaX;

                if (backgroundPosition.X > 0)
                {
                    backgroundPosition.X = 0;
                }
                else
                {
                    foreach (Shark shark in sharks)
                    {
                        shark.UpdateBounds(deltaX);
                    }
                }
            }

            // Check for player / enemy collisions
            foreach (Enemy enemy in enemies)
            {
                if (!enemy.IsDead && player.Hitbox.Intersects(enemy.AttackHitbox))
                {
                    _screenManager.SetScreen(ScreenType.GameOverMenu);
                    _screenManager.SwitchToNextScreen();
                }
            }

            // Check for player attack collisions
            if (player.IsAttacking)
            {
                foreach (Enemy enemy in enemies)
                {
                    if (!enemy.IsDead && player.AttackHitbox.Intersects(enemy.Hitbox))
                    {
                        enemy.IsDead = true;
                    }
                }
            }
        }

        public void Reset()
        {
            backgroundPosition = Vector2.Zero;
            player.Position = playerStartingPosition;
            shark1.Position = shark1StartingPosition;
            shark1.ResetBounds();
        }
    }
}
