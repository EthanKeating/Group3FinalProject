namespace FinalProject.Screens
{
    public interface IScreen
    {
        ScreenType ScreenType { get; }

        void Update(ScreenManager _screenManager, float delta);
        void Draw(SpriteBatch spriteBatch);
        void Reset();
    }
}
