using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace EtherDuels.Game
{
    sealed class GameAssets
    {
        private static readonly GameAssets instance = new GameAssets();

        private GameAssets() { }

        public static GameAssets Instance
        {
            get
            {
                return instance;
            }
        }      
        

        private Texture2D textureHealthBar;
        public Texture2D TextureHealthBar
        {
            get { return textureHealthBar; }
            set { textureHealthBar = value; }
        }

        private Texture2D textureSmoke;
        public Texture2D TextureSmoke
        {
            get { return textureSmoke; }
            set { textureSmoke = value; }
        }

        private Texture2D textureBackground;
        public Texture2D TextureBackground
        {
            get { return textureBackground; }
            set { textureBackground = value; }
        }

        private Microsoft.Xna.Framework.Graphics.Model modelSpaceship;
        public Microsoft.Xna.Framework.Graphics.Model ModelSpaceship
        {
            get { return modelSpaceship; }
            set { modelSpaceship = value; }
        }

        private Microsoft.Xna.Framework.Graphics.Model modelRocket;
        public Microsoft.Xna.Framework.Graphics.Model ModelRocket
        {
            get { return modelRocket; }
            set { modelRocket = value; }
        }

        private Microsoft.Xna.Framework.Graphics.Model modelLaser;
        public Microsoft.Xna.Framework.Graphics.Model ModelLaser
        {
            get { return modelLaser; }
            set { modelLaser = value; }
        }

        private Microsoft.Xna.Framework.Graphics.Model modelExplosion;
        public Microsoft.Xna.Framework.Graphics.Model ModelExplosion
        {
            get { return modelExplosion; }
            set { modelExplosion = value; }
        }

        private Microsoft.Xna.Framework.Graphics.Model modelPlanet;
        public Microsoft.Xna.Framework.Graphics.Model ModelPlanet
        {
            get { return modelPlanet; }
            set { modelPlanet = value; }
        }
    }
}
