namespace FinalProject.Utilities
{
    public class Hitbox
    {
        private BasicEntity entity;
        private int leftOffset;
        private int topOffset;
        private int rightOffset;
        private int bottomOffset;

        public Rectangle Bounds
        {
            get
            {
                return new Rectangle
                (
                    (int)entity.Position.X + leftOffset,
                    (int)entity.Position.Y + topOffset,
                    entity.Width - leftOffset - rightOffset,
                    entity.Height - topOffset - bottomOffset
                );
            }
        }

        public Hitbox(BasicEntity _entitiy, int _leftOffset, int _topOffset, int _rightOffset, int _bottomOffset)
        {
            entity = _entitiy;
            leftOffset = _leftOffset;
            rightOffset = _rightOffset;
            topOffset = _topOffset;
            bottomOffset = _bottomOffset;
        }

        public bool Intersects(Hitbox otherHitbox)
        {
            return Bounds.Intersects(otherHitbox.Bounds);
        }
    }
}
