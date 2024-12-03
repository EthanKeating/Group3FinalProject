namespace FinalProject.Entities
{
    internal class Pearl : BasicEntity
    {
        //public PearlAnimation PearlAnimation { get; set; }
        public bool IsCollected { get; set; } = false;

        public Pearl(Vector2 position) : base(position, 0)
        {
            // set up PearlAnimation, Width and Height
        }

        public void Initialize()
        {
            Hitbox = new Hitbox(this, 0, 0, 0, 0);
        }

        public void Draw()
        {

        }
    }
}
