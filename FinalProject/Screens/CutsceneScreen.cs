using FinalProject.Animations;
using FinalProject.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FinalProject.Screens
{
    internal class CutsceneScreen : IScreen
    {
        public List<string> _cutsceneText = new List<string>();

        public ScreenType ScreenType => ScreenType.Cutscene;
        private Game _game;
        private Game1 _mainGameDirectory;

        public SpriteFont _font;
        public int _cutsceneCount;

        Texture2D crab;
        Texture2D evilCrab;
        Texture2D evilCrabHead;

        Texture2D seaHorse;
        Texture2D textBox;

        Texture2D backgroundSprite;

        CrabIdleAnimation idleCrab;
        EvilCrabIdleAnimation idleEvilCrab;
        EvilCrabTalkingAnimation talkingEvilCrab;

        public Vector2 crabStartPosition = new Vector2(185, 525);

        public Vector2 evilCrabStartPosition = new Vector2(900, 580);
        public Vector2 evilCrabTalkingPosition = new Vector2(275, 50);

        public Vector2 backgroundPosition = new Vector2(0, 0);

        public Vector2 textboxPosition = new Vector2(175, 100);
        public Vector2 textLine1Position = new Vector2(525, 175);
        public Vector2 textLine2Position = new Vector2(525, 200);
        public Vector2 textLine3Position = new Vector2(525, 225);
        public Vector2 textLine4Position = new Vector2(525, 250);


        public CutsceneScreen(Game game, SpriteBatch spriteBatch)
        {
            _game = game;
            Game1 game1 = game as Game1;

            //tracks what cutscene we are on
            _cutsceneCount = 0;
            _font = _game.Content.Load<SpriteFont>("File");

            //cutscene text list
            //It's about MAX 45 characters per line
            _cutsceneText.Add("TEST TEXT: NOT FINAL GAME");
            _cutsceneText.Add("This is the max amount of characters a line has");
            _cutsceneText.Add("I am going to take your shell, once I take it I");
            _cutsceneText.Add("will eat it with my big crab mouth");

            //static sprites
            backgroundSprite = _game.Content.Load<Texture2D>("images/background");
            textBox = _game.Content.Load<Texture2D>("images/textBox");

            //animations
            crab = _game.Content.Load<Texture2D>("images/idle");
            evilCrab = _game.Content.Load<Texture2D>("images/idleEvilCrab");
            evilCrabHead = _game.Content.Load<Texture2D>("images/evilCrabHeadTalking");

            idleCrab = new CrabIdleAnimation(this._game, spriteBatch, crab, crabStartPosition, 10);
            idleEvilCrab = new EvilCrabIdleAnimation(this._game, spriteBatch, evilCrab, evilCrabStartPosition, 10);
            talkingEvilCrab = new EvilCrabTalkingAnimation(this._game, spriteBatch, evilCrabHead, evilCrabTalkingPosition, 10);

            _game.Components.Add(idleCrab);
            _game.Components.Add(idleEvilCrab);
            _game.Components.Add(talkingEvilCrab);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (_cutsceneCount == 0)
            {
                idleCrab.show();
                idleEvilCrab.show();
                talkingEvilCrab.show();

                spriteBatch.Draw(backgroundSprite, backgroundPosition, Color.White);
                spriteBatch.Draw(textBox, textboxPosition, Color.White);

                //spriteBatch.Draw(evilCrab, otherStartPosition, Color.White);

                //spriteBatch.Draw(evilCrab, otherStartPosition, null, Color.White, 0f, Vector2.Zero, 5, SpriteEffects.None, 0f);

                spriteBatch.DrawString(_font, _cutsceneText[0], textLine1Position, Color.Black);
                spriteBatch.DrawString(_font, _cutsceneText[1], textLine2Position, Color.Black);
                spriteBatch.DrawString(_font, _cutsceneText[2], textLine3Position, Color.Black);
                spriteBatch.DrawString(_font, _cutsceneText[3], textLine4Position, Color.Black);

            }

        }


        public void Update(ScreenManager _screenManager, float delta)
        {
        }

        public void Reset()
        {
        }
    }
}

