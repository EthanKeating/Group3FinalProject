namespace FinalProject.Entities
{
    public class Boss : BasicEntity
    {
        public Texture2D Texture { get; set; }

        public Boss(Vector2 position, int speed) : base(position, speed)
        {

        }
    }
}
