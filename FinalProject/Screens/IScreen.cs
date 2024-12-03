using FinalProject.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
