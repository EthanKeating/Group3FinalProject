using FinalProject.Entities;
using System;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;

namespace FinalProject.Screens
{
    public class Level1Screen : IScreen
    {
        public ScreenType ScreenType => ScreenType.Level1;
        private Game1 _game;

        private Texture2D backgroundSprite;

        public Player Player { get; set; }

        private Shark shark1;
        private Shark shark2;
        private Crab crab1;
        private Crab crab2;

        private Boss seaHorseBoss;
        public bool bossCutsceneTriggered = false;

        private List<Enemy> enemies;
        private List<Shark> sharks;
        private List<Crab> crabs;
        private List<Boss> bosses;

        private List<Tile> platforms;

        private Shell winShell;

        private List<Pearl> pearls;
        public SpriteFont _font;

        public Vector2 backgroundPosition = Vector2.Zero;

        public Level1Screen(Game game, SpriteBatch spriteBatch)
        {
            _game = game as Game1;

            backgroundSprite = _game.Content.Load<Texture2D>("images/background");
            _font = _game.Content.Load<SpriteFont>("PearlFont");

            Player = new Player(_game, spriteBatch, new Vector2(20, Game1.ScreenHeight - 70), 9);
            Player.Initialize();

            //winShell = new Shell(_game, new Vector2(backgroundSprite.Width - 500, Game1.ScreenHeight - 200));
            winShell = new Shell(_game, new Vector2(backgroundSprite.Width - 100, Game1.ScreenHeight - 200));
            winShell.Initialize();

            seaHorseBoss = new Boss(_game, spriteBatch, new Vector2(backgroundSprite.Width - 1000, Game1.ScreenHeight - 600), 9);
            seaHorseBoss.Initialize();

            shark1 = new Shark(_game, new Vector2(Game1.ScreenWidth / 5 * 4, Game1.ScreenHeight - 200), 3);
            shark1.Initialize();
            shark2 = new Shark(_game, new Vector2(Game1.ScreenWidth * 2, Game1.ScreenHeight - 200), 3);
            shark2.Initialize();

            crab1 = new Crab(_game, spriteBatch, new Vector2(1700, 600));
            crab1.Initialize();
            crab2 = new Crab(_game, spriteBatch, new Vector2(2000, 600));
            crab2.Initialize();


            enemies = [shark1, shark2, crab1, crab2];
            sharks = [shark1, shark2];
            crabs = [crab1, crab2];
            bosses = [seaHorseBoss];

            
            Texture2D TileTexture = game.Content.Load<Texture2D>("images/bubble");
            platforms = [

                new Tile(_game, spriteBatch, new Vector2(1000, 440)),
                new Tile(_game, spriteBatch, new Vector2(1000 + TileTexture.Width / 16, 440)),
                new Tile(_game, spriteBatch, new Vector2(1000 + (TileTexture.Width / 16 * 2), 440)),
                new Tile(_game, spriteBatch, new Vector2(1000 + (TileTexture.Width / 16 * 3), 440)),

                new Tile(_game, spriteBatch, new Vector2(1200, 230)),
                new Tile(_game, spriteBatch, new Vector2(1200 + TileTexture.Width / 16, 230)),
                new Tile(_game, spriteBatch, new Vector2(1200 + (TileTexture.Width / 16 * 2), 230)),
                new Tile(_game, spriteBatch, new Vector2(1200 + (TileTexture.Width / 16 * 3), 230)),

                new Tile(_game, spriteBatch, new Vector2(2000, 440)),
                new Tile(_game, spriteBatch, new Vector2(2000 + TileTexture.Width / 16, 440)),
                new Tile(_game, spriteBatch, new Vector2(2000 + (TileTexture.Width / 16 * 2), 440)),
                new Tile(_game, spriteBatch, new Vector2(2000 + (TileTexture.Width / 16 * 3), 440)),

                new Tile(_game, spriteBatch, new Vector2(2200, 230)),
                new Tile(_game, spriteBatch, new Vector2(2200 + TileTexture.Width / 16, 230)),
                new Tile(_game, spriteBatch, new Vector2(2200 + (TileTexture.Width / 16 * 2), 230)),
                new Tile(_game, spriteBatch, new Vector2(2200 + (TileTexture.Width / 16 * 3), 230)),

                new Tile(_game, spriteBatch, new Vector2(3200, 440)),
                new Tile(_game, spriteBatch, new Vector2(3200 + TileTexture.Width / 16, 440)),
                new Tile(_game, spriteBatch, new Vector2(3200 + (TileTexture.Width / 16 * 2), 440)),
                new Tile(_game, spriteBatch, new Vector2(3200 + (TileTexture.Width / 16 * 3), 440)),

                new Tile(_game, spriteBatch, new Vector2(3000, 230)),
                new Tile(_game, spriteBatch, new Vector2(3000 + TileTexture.Width / 16, 230)),
                new Tile(_game, spriteBatch, new Vector2(3000 + (TileTexture.Width / 16 * 2), 230)),
                new Tile(_game, spriteBatch, new Vector2(3000 + (TileTexture.Width / 16 * 3), 230)),

                new Tile(_game, spriteBatch, new Vector2(4000, 440)),
                new Tile(_game, spriteBatch, new Vector2(4000 + TileTexture.Width / 16, 440)),
                new Tile(_game, spriteBatch, new Vector2(4000 + (TileTexture.Width / 16 * 2), 440)),
                new Tile(_game, spriteBatch, new Vector2(4000 + (TileTexture.Width / 16 * 3), 440)),

                new Tile(_game, spriteBatch, new Vector2(4200, 230)),
                new Tile(_game, spriteBatch, new Vector2(4200 + TileTexture.Width / 16, 230)),
                new Tile(_game, spriteBatch, new Vector2(4200 + (TileTexture.Width / 16 * 2), 230)),
                new Tile(_game, spriteBatch, new Vector2(4200 + (TileTexture.Width / 16 * 3), 230)),

                new Tile(_game, spriteBatch, new Vector2(5600, 500)),
                new Tile(_game, spriteBatch, new Vector2(5600 + TileTexture.Width / 16, 500)),
                new Tile(_game, spriteBatch, new Vector2(5600 + (TileTexture.Width / 16 * 2), 500)),
                new Tile(_game, spriteBatch, new Vector2(5600 + (TileTexture.Width / 16 * 3), 500)),

                new Tile(_game, spriteBatch, new Vector2(5900, 280)),
                new Tile(_game, spriteBatch, new Vector2(5900 + TileTexture.Width / 16, 280)),

                new Tile(_game, spriteBatch, new Vector2(5200, 230)),
                new Tile(_game, spriteBatch, new Vector2(5200 + TileTexture.Width / 16, 230)),
                new Tile(_game, spriteBatch, new Vector2(5200 + (TileTexture.Width / 16 * 2), 230)),
                new Tile(_game, spriteBatch, new Vector2(5200 + (TileTexture.Width / 16 * 3), 230)),
                new Tile(_game, spriteBatch, new Vector2(5200 + (TileTexture.Width / 16 * 4), 230)),
                new Tile(_game, spriteBatch, new Vector2(5200 + (TileTexture.Width / 16 * 5), 230)),
                new Tile(_game, spriteBatch, new Vector2(5200 + (TileTexture.Width / 16 * 6), 230)),
                new Tile(_game, spriteBatch, new Vector2(5200 + (TileTexture.Width / 16 * 7), 230)),
                new Tile(_game, spriteBatch, new Vector2(5200 + (TileTexture.Width / 16 * 8), 230)),
                ];
            platforms.ForEach(p => p.Initialize());

            pearls = [new Pearl(_game, spriteBatch, new Vector2(300, 600)),
                new Pearl(_game, spriteBatch, new Vector2(500, 600)),
                new Pearl(_game, spriteBatch, new Vector2(2270, 180)),
                new Pearl(_game, spriteBatch, new Vector2(2270, 500)),
                new Pearl(_game, spriteBatch, new Vector2(3000, 600)),
                new Pearl(_game, spriteBatch, new Vector2(4500, 600)),
                new Pearl(_game, spriteBatch, new Vector2(6000, 600)),

                new Pearl(_game, spriteBatch, new Vector2(5250, 180)),
                new Pearl(_game, spriteBatch, new Vector2(5250 + TileTexture.Width / 8 * 1, 180)),
                new Pearl(_game, spriteBatch, new Vector2(5250 + TileTexture.Width / 8 * 2, 180)),
                new Pearl(_game, spriteBatch, new Vector2(5250 + TileTexture.Width / 8 * 3, 180)),
                ];
            pearls.ForEach(p => p.Initialize());
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundSprite, backgroundPosition, Color.White);
            spriteBatch.DrawString(_font, "Pearls Collected: " + pearls.Count(pearl => pearl.IsCollected), Vector2.Zero, Color.WhiteSmoke, 0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0f);

            Player.Draw();
            winShell.Draw(spriteBatch);

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

            winShell.Position = new Vector2(backgroundPosition.X + backgroundSprite.Width - 100, Game1.ScreenHeight - 200);

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
                        boss.BubbleAttack.Position = new Vector2(boss.BubbleAttack.Position.X - deltaX, boss.BubbleAttack.Position.Y);
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
                        boss.BubbleAttack.Position = new Vector2(boss.BubbleAttack.Position.X - deltaX, boss.BubbleAttack.Position.Y);
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
            Player.isJumping = !didCollide;

            foreach (Pearl pearl in pearls)
            {
                if (!pearl.IsCollected)
                {
                    pearl.pearlAnimation.show();
                    pearl.pearlAnimation.playedSound = false;
                }
            }


            if (Player.Hitbox.Intersects(winShell.Hitbox))
            {
                Reset();
                _screenManager.SetScreen(ScreenType.GameWinMenu);
                _screenManager.SwitchToNextScreen();
            }

            // Check for player / enemy collisions
            foreach (Enemy enemy in enemies)
            {
                if (!enemy.IsDead && Player.Hitbox.Intersects(enemy.AttackHitbox))
                {
                    Reset();
                    _screenManager.SetScreen(ScreenType.GameOverMenu);
                    _screenManager.SwitchToNextScreen();
                }
            }
            foreach (Boss boss in bosses)
            {
                if (!boss.isDead() && Player.Hitbox.Intersects(boss.AttackHitbox))
                {
                    Reset();
                    _screenManager.SetScreen(ScreenType.GameOverMenu);
                    _screenManager.SwitchToNextScreen();
                }

                if (!boss.isDead() && !boss.BubbleAttack.IsPopped && Player.Hitbox.Intersects(boss.BubbleAttack.AttackHitbox))
                {
                    Reset();
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
                    if (Player.AttackHitbox.Intersects(boss.BubbleAttack.Hitbox))
                    {
                        boss.BubbleAttack.IsPopped = true;
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
            if (Vector2.Distance(Player.Position, seaHorseBoss.Position) < 800)
            {
                if (!bossCutsceneTriggered)
                {
                    _game._screenManager.SetScreen(ScreenType.Cutscene);
                    _game._screenManager.SwitchToNextScreenWithoutReset();
                }
                bossCutsceneTriggered = true;
            }
        }

        public void Reset()
        {
            backgroundPosition = Vector2.Zero;
            Player.Position = Player.StartingPosition;
            winShell.Position = winShell.StartingPosition;

            foreach (Enemy enemy in enemies)
            {
                enemy.IsDead = false;
                enemy.Position = enemy.StartingPosition;
            }

            foreach (Crab crab in crabs)
            {
                crab.ResetBounds();
                crab.IdleAnimation.hide();
            }

            foreach(Pearl pearl in pearls)
            {
                pearl.IsCollected = false;
                pearl.Position = pearl.StartingPosition;
                pearl.pearlAnimation.hide();
            }

            foreach (Boss boss in bosses)
            {
                boss.health = 3;
                boss.Position = boss.StartingPosition;
                boss.BubbleAttack.IsActive = false;
                boss.BubbleAttack.IsPopped = false;
                boss.BubbleAttack.Position = boss.BubbleAttack.StartingPosition;
                boss.BubbleAttack.BubbleAnimation.hide();
            }

            foreach (Tile tile in platforms)
            {
                tile.Position = tile.StartingPosition;
                tile.Update(0);
            }

            Player.AttackAnimation.hide();
            Player.IdleAnimation.hide();
            Player.WalkAnimation.hide();
            seaHorseBoss.HPAnimation.hide();
        }
    }
}
