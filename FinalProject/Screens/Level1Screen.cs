using FinalProject.Entities;
using System;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Screens
{
    public class Level1Screen : IScreen
    {
        public ScreenType ScreenType => ScreenType.Level1;
        private Game _game;

        private Texture2D backgroundSprite;

        public Player Player { get; set; }

        private Shark shark1;
        private Shark shark2;
        private Crab crab1;
        private Crab crab2;

        private Boss seaHorseBoss;

        private List<Enemy> enemies;
        private List<Shark> sharks;
        private List<Crab> crabs;
        private List<Boss> bosses;

        private Tile platform1;
        private Tile platform2;
        private Tile platform3;
        private Tile platform4;
        private List<Tile> platforms;

        private Pearl pearl1;
        private Pearl pearl2;
        private Pearl pearl3;
        private Pearl pearl4;
        private Pearl pearl5;

        private List<Pearl> pearls;

        public Vector2 backgroundPosition = new Vector2(0, 0);
        public Vector2 playerStartingPosition = new Vector2(20, Game1.ScreenHeight - 70);
        public Vector2 shark1StartingPosition = new Vector2(Game1.ScreenWidth / 5 * 4, Game1.ScreenHeight - 200);
        public Vector2 shark2StartingPosition = new Vector2(Game1.ScreenWidth / 5 * 4 + Game1.ScreenWidth, Game1.ScreenHeight - 200);
        public Vector2 seaHorseStartingPosition = new Vector2(Game1.ScreenWidth / 5 * 4 - 100, Game1.ScreenHeight - 600);

        public Level1Screen(Game game, SpriteBatch spriteBatch)
        {
            _game = game;

            backgroundSprite = _game.Content.Load<Texture2D>("images/background");

            Player = new Player(_game, spriteBatch, playerStartingPosition, 9);
            Player.Initialize();

            seaHorseBoss = new Boss(_game, spriteBatch, seaHorseStartingPosition, 9);
            seaHorseBoss.Initialize();

            shark1 = new Shark(_game, shark1StartingPosition, 2);
            shark1.Initialize();
            shark2 = new Shark(_game, shark2StartingPosition, 2);
            shark2.Initialize();

            crab1 = new Crab(_game, spriteBatch, new Vector2(1700, 600));
            crab1.Initialize();
            crab2 = new Crab(_game, spriteBatch, new Vector2(2000, 600));
            crab2.Initialize();

            platform1 = new Tile(_game, spriteBatch, new Vector2(200, 400));
            platform1.Initialize();
            platform2 = new Tile(_game, spriteBatch, new Vector2(200 + platform1.Width, 400));
            platform2.Initialize();
            platform3 = new Tile(_game, spriteBatch, new Vector2(200 + (platform2.Width * 2), 400));
            platform3.Initialize();
            platform4 = new Tile(_game, spriteBatch, new Vector2(200 + (platform3.Width * 3), 400));
            platform4.Initialize();

            enemies = [shark1, shark2, crab1, crab2];
            sharks = [shark1, shark2];
            crabs = [crab1, crab2];
            bosses = [seaHorseBoss];
            platforms = [platform1, platform2, platform3, platform4];

            pearl1 = new Pearl(_game, spriteBatch, new Vector2(300, 600));
            pearl1.Initialize();
            pearl2 = new Pearl(_game, spriteBatch, new Vector2(500, 600));
            pearl2.Initialize();
            pearl3 = new Pearl(_game, spriteBatch, new Vector2(3000, 600));
            pearl3.Initialize();
            pearl4 = new Pearl(_game, spriteBatch, new Vector2(4500, 600));
            pearl4.Initialize();
            pearl5 = new Pearl(_game, spriteBatch, new Vector2(6000, 600));
            pearl5.Initialize();

            pearls = [pearl1, pearl2, pearl3, pearl4, pearl5];
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundSprite, backgroundPosition, Color.White);

            Player.Draw();

            foreach (Enemy enemy in enemies)
            {
                enemy.Draw(spriteBatch);
            }

            foreach(Boss boss in bosses)
            {
                boss.Draw(spriteBatch);
            }

            foreach (Pearl pearl in pearls)
            {
                pearl.Draw();
            }

            foreach (Tile tile in platforms)
            {
                tile.Draw(spriteBatch);
            }
        }

        public void Update(ScreenManager _screenManager, float delta)
        {
            // Calculate how much background moves
            int startX = (int)Player.Position.X;
            Player.Update();
            int deltaX = (int)Player.Position.X - startX;
            
            foreach (Enemy enemy in enemies)
            {
                enemy.Update(deltaX);
            }

            foreach(Boss boss in bosses)
            {
                boss.Update(delta);
            }

            int rightBound = (int)Game1.ScreenWidth / 4;

            // Move background
            if (Player.Position.X > rightBound)
            {
                if (backgroundPosition.X > -backgroundSprite.Width + 1280)
                {
                    Player.Position = new Vector2(startX, Player.Position.Y);
                    backgroundPosition.X -= deltaX;

                    foreach (Boss boss in bosses)
                    {
                        boss.Position = new Vector2(boss.Position.X - deltaX, boss.Position.Y);
                    }

                    foreach (Shark shark in sharks)
                    {
                        shark.Position = new Vector2(shark.Position.X - deltaX, shark.Position.Y);
                    }

                    foreach (Crab crab in crabs)
                    {
                        crab.UpdateBounds(deltaX);
                    }

                    foreach (Pearl pearl in pearls)
                    {
                        pearl.Position = new Vector2(pearl.Position.X - deltaX, pearl.Position.Y);
                    }

                    foreach(Tile tile in platforms)
                    {
                        tile.Update(deltaX);
                    }
                }
            }

            // Stop background from moving past end
            if (backgroundPosition.X < -backgroundSprite.Width + 1280)
            {
                backgroundPosition.X = -backgroundSprite.Width + 1280;
            }

            // Move background backwards
            if (Player.Position.X < 0)
            {
                Player.Position = new Vector2(startX, Player.Position.Y);
                backgroundPosition.X -= deltaX;

                if (backgroundPosition.X > 0)
                {
                    backgroundPosition.X = 0;
                }
                else
                {
                    foreach (Boss boss in bosses)
                    {
                        boss.Position = new Vector2(boss.Position.X - deltaX, boss.Position.Y);
                    }

                    foreach (Shark shark in sharks)
                    {
                        shark.Position = new Vector2(shark.Position.X - deltaX, shark.Position.Y);
                    }

                    foreach (Crab crab in crabs)
                    {
                        crab.UpdateBounds(deltaX);
                    }

                    foreach (Pearl pearl in pearls)
                    {
                        pearl.Position = new Vector2(pearl.Position.X - deltaX, pearl.Position.Y);
                    }

                    foreach (Tile tile in platforms)
                    {
                        tile.Update(deltaX);
                    }
                }
            }

            // Player / platform collisions
            bool didCollide = false;
            foreach (Tile tile in platforms)
            {
                if (Player.Hitbox.Intersects(tile.Hitbox))
                {
                    Player.Position = new Vector2(Player.Position.X, tile.Position.Y - Player.Height);
                    Player.velocity = 0;
                    didCollide = true;
                }
            }
            if (didCollide)
                Player.isJumping = false;

            // Check for player / enemy collisions
            foreach (Enemy enemy in enemies)
            {
                if (!enemy.IsDead && Player.Hitbox.Intersects(enemy.AttackHitbox))
                {
                    _screenManager.SetScreen(ScreenType.GameOverMenu);
                    _screenManager.SwitchToNextScreen();
                }
            }
            foreach (Boss boss in bosses)
            {
                if (!boss.isDead() && Player.Hitbox.Intersects(boss.AttackHitbox))
                {
                    _screenManager.SetScreen(ScreenType.GameOverMenu);
                    _screenManager.SwitchToNextScreen();
                }
            }

            // Check for player attack collisions
            if (Player.IsAttacking)
            {
                foreach(Boss boss in bosses)
                {
                    if (Player.AttackHitbox.Intersects(boss.Hitbox))
                    {
                        boss.Damage();
                    }
                }
                foreach (Enemy enemy in enemies)
                {
                    if (!enemy.IsDead && Player.AttackHitbox.Intersects(enemy.Hitbox))
                    {
                        enemy.IsDead = true;
                    }
                }
            }

            // Check for pearl collisions
            foreach (Pearl pearl in pearls)
            {
                if (Player.Hitbox.Intersects(pearl.Hitbox))
                {
                    pearl.IsCollected = true;
                }
            }

            
        }

        public void Reset()
        {
            backgroundPosition = Vector2.Zero;
            Player.Position = playerStartingPosition;

            foreach (Enemy enemy in enemies)
            {
                enemy.Position = enemy.StartingPosition;
            }

            foreach (Crab crab in crabs)
            {
                crab.ResetBounds();
            }

            foreach(Pearl pearl in pearls)
            {
                pearl.Position = pearl.StartingPosition;
            }
            foreach (Boss boss in bosses)
            {
                boss.Position = boss.StartingPosition;
            }
            Player.AttackAnimation.hide();
            Player.IdleAnimation.hide();
            Player.WalkAnimation.hide();
            seaHorseBoss.HPAnimation.hide();

            foreach (Tile tile in platforms)
            {
                tile.Position = tile.StartingPosition;
            }
        }
    }
}
