﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace EtherDuels.Menu
{
    sealed class MenuAssets
    {
        private static readonly MenuAssets instance = new MenuAssets();

        private MenuAssets() { }

        public static MenuAssets Instance
        {
            get
            {
                return instance;
            }
        }      

        private SpriteFont menuFont;
        private Texture2D textureBackground;               

        public SpriteFont MenuFont
        {
            get { return menuFont; }
            set { menuFont = value; }
        }

        public Texture2D TextureBackground
        {
            get { return textureBackground; }
            set { textureBackground = value; }
        } 
        

    }

}