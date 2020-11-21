using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paddlist.Audio
{
    static class AudioHandler
    {
        public static SoundEffect Blip, Pause, Win, Lose;

        public static void Load(ContentManager content)
        {
            Blip = content.Load<SoundEffect>("Sounds/blip");
            Pause = content.Load<SoundEffect>("Sounds/pause");
            Win = content.Load<SoundEffect>("Sounds/win");
            Lose = content.Load<SoundEffect>("Sounds/lose");
        }
    }
}
