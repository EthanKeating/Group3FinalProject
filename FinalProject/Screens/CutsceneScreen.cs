using FinalProject.Animations;
using FinalProject.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
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

        //Essentials
        public ScreenType ScreenType => ScreenType.Cutscene;
        private Game _game;
        public Game1 game1;
        public SpriteBatch spriteBatch;

        //Text
        public SpriteFont _font;
        public int _cutsceneCount;
        public int _textBoxCount;

        //Delay
        public DateTime _textDelay = DateTime.Now;

        //All images
        Texture2D crab;
        Texture2D crabHead;
        Texture2D shell;

        Texture2D evilCrab;
        Texture2D evilCrabHead;

        Texture2D seaHorseIdle;
        Texture2D horseHead;
        Texture2D bigSeaHorse;

        Texture2D textBox;

        Texture2D backgroundSprite;

        //Animations
        CrabIdleAnimation idleCrab;
        EvilCrabIdleAnimation idleEvilCrab;
        CrabTalkingAnimation talkingCrab;
        EvilCrabTalkingAnimation talkingEvilCrab;
        HorseTalkingAnimation talkingHorse;

        //Main character
        public Vector2 crabStartPosition = new Vector2(185, 525);
        public Vector2 crabTalkingPosition = new Vector2(50, -200);

        //Shell
        public Vector2 shellStartPosition = new Vector2(185, 540);
        public Vector2 shellEndPosition = new Vector2(935, 450);

        //Evil crab
        public Vector2 evilCrabStartPosition = new Vector2(900, 580);
        public Vector2 evilCrabTalkingPosition = new Vector2(275, 50);

        //Horse
        public Vector2 seaHorseStartPosition = new Vector2(900, 450);
        public Vector2 horseTalkingPosition = new Vector2(250, 100);
        public Vector2 bigSeaHorseStartPosition = new Vector2(1050, 100);

        //Background
        public Vector2 backgroundPosition = new Vector2(0, 0);

        //Text
        public Vector2 textboxPosition = new Vector2(175, 100);
        public Vector2 textLinePosition = new Vector2(525, 175);


        public CutsceneScreen(Game game, SpriteBatch spriteBatch)
        {
            //Dependency injections
            _game = game;
            game1 = game as Game1;
            this.spriteBatch = spriteBatch;
            _font = _game.Content.Load<SpriteFont>("File");

            //tracks what cutscene we are on
            _cutsceneCount = 0;

            //tracks what line of text we are on
            _textBoxCount = -1;

            PopulateText();

            //static sprites
            backgroundSprite = _game.Content.Load<Texture2D>("images/background");
            textBox = _game.Content.Load<Texture2D>("images/textBox");
            shell = _game.Content.Load<Texture2D>("images/shell");
            seaHorseIdle = _game.Content.Load<Texture2D>("images/seaHorseIdle");
            bigSeaHorse = _game.Content.Load<Texture2D>("images/seaHorse");

            //animations
            crab = _game.Content.Load<Texture2D>("images/idle");
            crabHead = _game.Content.Load<Texture2D>("images/crabHeadTalking");
            evilCrab = _game.Content.Load<Texture2D>("images/idleEvilCrab");
            evilCrabHead = _game.Content.Load<Texture2D>("images/evilCrabHeadTalking");
            horseHead = _game.Content.Load<Texture2D>("images/horseHeadTalking");

            //initialize animations
            idleCrab = new CrabIdleAnimation(this._game, spriteBatch, crab, crabStartPosition, 10);
            idleEvilCrab = new EvilCrabIdleAnimation(this._game, spriteBatch, evilCrab, evilCrabStartPosition, 10);
            talkingEvilCrab = new EvilCrabTalkingAnimation(this._game, spriteBatch, evilCrabHead, evilCrabTalkingPosition, 10);
            talkingCrab = new CrabTalkingAnimation(this._game, spriteBatch, crabHead, crabTalkingPosition, 10);
            talkingHorse = new HorseTalkingAnimation(this._game, spriteBatch, horseHead, horseTalkingPosition, 10);

            //add animations
            _game.Components.Add(idleCrab);
            _game.Components.Add(idleEvilCrab);
            _game.Components.Add(talkingEvilCrab);
            _game.Components.Add(talkingCrab);
            _game.Components.Add(talkingHorse);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //initial cutscene
            if (_cutsceneCount == 0)
            {
                idleCrab.show();

                spriteBatch.Draw(backgroundSprite, backgroundPosition, Color.White);
                spriteBatch.Draw(textBox, textboxPosition, Color.White);

                spriteBatch.DrawString(_font, _cutsceneText[_textBoxCount + 1], textLinePosition, Color.Black);
                spriteBatch.DrawString(_font, _cutsceneText[_textBoxCount + 2], textLinePosition + new Vector2(0, 25), Color.Black);
                spriteBatch.DrawString(_font, _cutsceneText[_textBoxCount + 3], textLinePosition + new Vector2(0, 50), Color.Black);

                //cutscene 1 talking head visibility
                if (_textBoxCount < 2)
                {
                    talkingCrab.show();
                }
                else if (_textBoxCount < 5)
                {
                    talkingCrab.hide();
                    idleEvilCrab.show();
                    talkingEvilCrab.show();
                }
                else if (_textBoxCount < 8)
                {
                    talkingEvilCrab.hide();
                    talkingCrab.show();
                }
                else if (_textBoxCount < 14)
                {
                    talkingCrab.hide();
                    talkingEvilCrab.show();
                }
                else if (_textBoxCount < 17)
                {
                    idleEvilCrab.hide();
                    talkingEvilCrab.hide();
                    talkingCrab.show();
                }
                else if (_textBoxCount < 20)
                {
                    talkingCrab.hide();
                    talkingHorse.show();
                }
                else if (_textBoxCount < 23)
                {
                    talkingHorse.hide();
                    talkingCrab.show();
                }
                else if (_textBoxCount < 26)
                {
                    talkingCrab.hide();
                    talkingHorse.show();
                }
                else if (_textBoxCount < 29)
                {
                    talkingHorse.hide();
                    talkingCrab.show();
                }
                else if (_textBoxCount < 38)
                {
                    talkingCrab.hide();
                    talkingHorse.show();
                }
                else if (_textBoxCount < 44)
                {
                    talkingHorse.hide();
                    talkingCrab.show();
                }
                else if (_textBoxCount < 47)
                {
                    talkingCrab.hide();
                    talkingHorse.show();
                }

                //cutscene 1 image visibility
                if (_textBoxCount < 3)
                {
                    spriteBatch.Draw(shell, shellStartPosition, Color.White);
                }
                else if (_textBoxCount < 14)
                {
                    spriteBatch.Draw(shell, shellEndPosition, Color.White);
                }
                else if (_textBoxCount < 17)
                {
                }
                else if (_textBoxCount < 47)
                {
                    spriteBatch.Draw(seaHorseIdle, seaHorseStartPosition, Color.White);
                }
            }

            //cutscene number 2
            if (_cutsceneCount == 1)
            {

                spriteBatch.Draw(backgroundSprite, backgroundPosition, Color.White);
                spriteBatch.Draw(textBox, textboxPosition, Color.White);

                spriteBatch.DrawString(_font, _cutsceneText[_textBoxCount + 1], textLinePosition, Color.Black);
                spriteBatch.DrawString(_font, _cutsceneText[_textBoxCount + 2], textLinePosition + new Vector2(0, 25), Color.Black);
                spriteBatch.DrawString(_font, _cutsceneText[_textBoxCount + 3], textLinePosition + new Vector2(0, 50), Color.Black);

                if (_textBoxCount < 2)
                {
                    idleCrab.show();
                    idleEvilCrab.show();
                    talkingEvilCrab.show();
                }
                else if (_textBoxCount < 8)
                {
                    talkingEvilCrab.hide();
                    talkingCrab.show();
                }
                else if (_textBoxCount < 14)
                {
                    talkingCrab.hide();
                    talkingEvilCrab.show();
                }
                else if (_textBoxCount < 17)
                {
                    idleEvilCrab.hide();
                    talkingEvilCrab.hide();
                    talkingHorse.show();
                }
                else if (_textBoxCount < 20)
                {
                    talkingHorse.hide();
                    talkingCrab.show();
                }
                else if (_textBoxCount < 29)
                {
                    talkingCrab.hide();
                    talkingHorse.show();
                }
                else if (_textBoxCount < 32)
                {
                    talkingHorse.hide();
                    talkingCrab.show();
                }
                else if (_textBoxCount < 35)
                {
                    talkingCrab.hide();
                    talkingHorse.show();
                }
                else if (_textBoxCount < 38)
                {
                    talkingHorse.hide();
                    talkingCrab.show();
                }

                if (_textBoxCount < 14)
                {
                }
                else
                {
                    spriteBatch.Draw(bigSeaHorse, bigSeaHorseStartPosition, bigSeaHorse.Bounds, Color.White, 0f, Vector2.Zero, 0.4f, SpriteEffects.None, 1f);
                }
            }
        }

        //Checks for enter button to skip to the next text line
        public void TextUpdate()
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Enter))
            {
                if (_textDelay < DateTime.Now)
                {
                    //Sends you to next screen
                    if (_textBoxCount + 4 > _cutsceneText.Count - 1)
                    {
                        game1._screenManager.SetScreen(ScreenType.Level1);
                        game1._screenManager.SwitchToNextScreen();

                        idleCrab.hide();
                        idleEvilCrab.hide();
                        talkingEvilCrab.hide();
                        talkingCrab.hide();
                        talkingHorse.hide();

                        _cutsceneCount += 1;
                        _textBoxCount = -1;
                    }
                    else
                    {
                        _textBoxCount += 3;
                    }

                    _textDelay = DateTime.Now.AddSeconds(1);
                }
            }
        }

        private void PopulateText()
        {
            _cutsceneText.Clear();

            //Populates _cutsceneText list with appropriate text
            if (_cutsceneCount == 0)
            {
                _cutsceneText.Add("Another beautiful day in the neighbourhood!");
                _cutsceneText.Add("I can't wait to take my shell to some new");
                _cutsceneText.Add("places today, isn't that right shell?");

                _cutsceneText.Add("AHAHAHAHA, what a sweet shell you have little");
                _cutsceneText.Add("man! Hope you don't mind if I steal it with my");
                _cutsceneText.Add("big crab claws!");

                _cutsceneText.Add("Noooo! My shell! How could you...");
                _cutsceneText.Add("I hate you...");
                _cutsceneText.Add("You're a monster!");

                _cutsceneText.Add("That's right, with this I can finally look");
                _cutsceneText.Add("beautiful. I couldn't imagine being in your");
                _cutsceneText.Add("shoes right now, you must feel horrible!");

                _cutsceneText.Add("Sayonara loser, have fun being shell-less");
                _cutsceneText.Add("Ahahahahahahahahaha.");
                _cutsceneText.Add("Hahahahahaha");

                _cutsceneText.Add("My shell...");
                _cutsceneText.Add("I can't believe this happened.");
                _cutsceneText.Add("What am I gonna do...");

                _cutsceneText.Add("My son, what has happpened, something");
                _cutsceneText.Add("looks different about you.");
                _cutsceneText.Add("");

                _cutsceneText.Add("It's gone Master Horse, my shell was");
                _cutsceneText.Add("stolen by this stupid evil crab");
                _cutsceneText.Add("");

                _cutsceneText.Add("Dang dude, sounds like you really");
                _cutsceneText.Add("screwed up this time, welp, there's");
                _cutsceneText.Add("plenty of shells in the sea");

                _cutsceneText.Add("You don't understand! I left the oven");
                _cutsceneText.Add("on in my shell! There's a quiche being");
                _cutsceneText.Add("baked as we speak!");

                _cutsceneText.Add("I see! Well if you've truly learned");
                _cutsceneText.Add("anything from my teachings you must go!");
                _cutsceneText.Add("");

                _cutsceneText.Add("Not a single quiche shall be wasted, not");
                _cutsceneText.Add("as long as I exist in this ocean!");
                _cutsceneText.Add("");

                _cutsceneText.Add("Go.");
                _cutsceneText.Add("Fight crab and his minions!");
                _cutsceneText.Add("Make me proud.");

                _cutsceneText.Add("Yeah... Yeah! You're right!");
                _cutsceneText.Add("I'll get my shell back, even if it");
                _cutsceneText.Add("kills me and I become some crab's");

                _cutsceneText.Add("Dinner,");
                _cutsceneText.Add("thanks master!");
                _cutsceneText.Add("");

                _cutsceneText.Add("");
                _cutsceneText.Add("(Neigh)");
                _cutsceneText.Add("");
            } //Cutscene 1
            if (_cutsceneCount == 1) //Cutscene 2
            {
                _cutsceneText.Add("Aha!");
                _cutsceneText.Add("You've found me! It is I...");
                _cutsceneText.Add("Evil Crab!");

                _cutsceneText.Add("Give it up evil crab, I've");
                _cutsceneText.Add("destroyed all of your minions up");
                _cutsceneText.Add("to this point!");

                _cutsceneText.Add("I've become stronger than you could");
                _cutsceneText.Add("ever imagine. ");
                _cutsceneText.Add("I want my shell back!");

                _cutsceneText.Add("Foolish boy, there is one thing you");
                _cutsceneText.Add("haven't considered...");
                _cutsceneText.Add("");

                _cutsceneText.Add("For it is I...");
                _cutsceneText.Add("");
                _cutsceneText.Add("");

                _cutsceneText.Add("Horse!");
                _cutsceneText.Add("");
                _cutsceneText.Add("The whole time!");

                _cutsceneText.Add("Gasp! How is this possible!");
                _cutsceneText.Add("");
                _cutsceneText.Add("");

                _cutsceneText.Add("Just the smell of your shell's quiche");
                _cutsceneText.Add("alone was enough for me to regain my");
                _cutsceneText.Add("true power back.");

                _cutsceneText.Add("With my real strength I can finally");
                _cutsceneText.Add("rule the ocean!");
                _cutsceneText.Add("");

                _cutsceneText.Add("And besides, you look hidious without");
                _cutsceneText.Add("your shell.");
                _cutsceneText.Add("I think it's funny.");

                _cutsceneText.Add("But you were my master, my mentor!");
                _cutsceneText.Add("You meant everything to me!");
                _cutsceneText.Add("");

                _cutsceneText.Add("Whatever dude, I was too");
                _cutsceneText.Add("cool for you anyway.");
                _cutsceneText.Add("");

                _cutsceneText.Add("I'll destroy you");
                _cutsceneText.Add("");
                _cutsceneText.Add("");
            }
        }

        public void Update(ScreenManager _screenManager, float delta)
        {
            TextUpdate();
        }

        public void Reset()
        {
            _textDelay = DateTime.Now.AddSeconds(1);
        }
    }
}

