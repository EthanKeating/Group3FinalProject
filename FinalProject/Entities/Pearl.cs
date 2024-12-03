using Microsoft.Xna.Framework.Graphics;

namespace FinalProject.Entities
{
    internal class Pearl : BasicEntity
    {
        //public PearlAnimation PearlAnimation { get; set; }
        public bool IsCollected { get; set; } = false;
        public PearlAnimation pearlAnimation { get; set; }
        private Game game;

        public Pearl(Game game, SpriteBatch spriteBatch, Vector2 position) : base(position, 0)
        {
            this.game = game;
            pearlAnimation = new PearlAnimation(game, spriteBatch, game.Content.Load<Texture2D>("images/pearl"), Position, 3);
            game.Components.Add(pearlAnimation);
            // set up PearlAnimation, Width and Height
        }

        public void Initialize()
        {
            Hitbox = new Hitbox(this, 0, 0, 0, 0);
        }

        public void Draw()
        {
            if (IsCollected)
            {
                pearlAnimation.hide();
                game.Components.Remove(pearlAnimation);
                return;
            }

            pearlAnimation.show();
        }
    }
}
