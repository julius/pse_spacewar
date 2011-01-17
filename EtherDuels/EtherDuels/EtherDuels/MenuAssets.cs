using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace EtherDuels
{
    public class MenuAssets
    {
        private SpriteFont menuFont;
        private Texture2D background;

        public SpriteFont MenuFont
        {
            get { return menuFont; }
            set { menuFont = value; }
        }

        public Texture2D Background
        {
            get { return background; }
            set { background = value; }
        }
    }
}
