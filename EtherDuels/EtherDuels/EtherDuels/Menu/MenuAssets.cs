using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace EtherDuels.Menu
{
    /// <summary>
    /// The MenuAssets class contains all assets needed for the menu.
    /// It is a singleton, meaning there can only be one instance of this class.
    /// </summary>
    sealed class MenuAssets
    {
        private static readonly MenuAssets instance = new MenuAssets();

        // private constructor
        private MenuAssets() { }

        /// <summary>
        /// Returns the only instance of this class.
        /// </summary>
        public static MenuAssets Instance
        {
            get
            {
                return instance;
            }
        }

        private SoundEffect soundMenuClick;
        public SoundEffect SoundMenuClick
        {
            get { return soundMenuClick; }
            set { soundMenuClick = value; }
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
