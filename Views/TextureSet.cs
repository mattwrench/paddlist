using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paddlist.Views
{
    // Container class for all textures
    class TextureSet
    {
        public Texture2D Background;
        public Texture2D PaddleRed, PaddleBlue;
        public Texture2D Ball;
        public Texture2D TextReady, TextPaused, TextWinner, TextLoser;

        private Texture2D iconPause, iconPauseTrans;
        private Texture2D iconPlay, iconPlayTrans;
        private Texture2D iconRestart, iconRestartTrans;

        public TextureSet(ContentManager content)
        {
            Background = content.Load<Texture2D>("Images/background");
            PaddleRed = content.Load<Texture2D>("Images/paddleRed");
            PaddleBlue = content.Load<Texture2D>("Images/paddleBlue");
            Ball = content.Load<Texture2D>("Images/ball");

            TextReady = content.Load<Texture2D>("Images/textReady");
            TextPaused = content.Load<Texture2D>("Images/textPaused");
            TextWinner = content.Load<Texture2D>("Images/textWinner");
            TextLoser = content.Load<Texture2D>("Images/textLoser");

            iconPause = content.Load<Texture2D>("Images/iconPause");
            iconPauseTrans = content.Load<Texture2D>("Images/iconPauseTranslucent");
            iconPlay = content.Load<Texture2D>("Images/iconPlay");
            iconPlayTrans = content.Load<Texture2D>("Images/iconPlayTranslucent");
            iconRestart = content.Load<Texture2D>("Images/iconRestart");
            iconRestartTrans = content.Load<Texture2D>("Images/iconRestartTranslucent");
        }

        public Texture2D GetIconPause(bool translucent)
        {
            return translucent ? iconPauseTrans : iconPause;
        }

        public Texture2D GetIconPlay(bool translucent)
        {
            return translucent ? iconPlayTrans : iconPlay;
        }

        public Texture2D GetIconRestart(bool translucent)
        {
            return translucent ? iconRestartTrans : iconRestart;
        }
    }
}
