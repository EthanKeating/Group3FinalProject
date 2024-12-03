namespace FinalProject.Entities
{
    public class BasicEntity
    {
        public Vector2 StartingPosition { get; set; }
        public Vector2 Position { get; set; }
        public Hitbox Hitbox { get; set; }
        public Hitbox AttackHitbox { get; set; }
        public int Speed { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public BasicEntity(Vector2 position, int speed)
        {
            Position = position;
            StartingPosition = position;
            Speed = speed;
        }
    }
}
