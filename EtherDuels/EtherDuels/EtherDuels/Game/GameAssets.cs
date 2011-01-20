using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;

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

        private Song soundtrack;
        public Song Soundtrack
        {
            get { return soundtrack; }
            set { soundtrack = value; }
        }

        private SoundEffect soundExplosion;
        public SoundEffect SoundExplosion
        {
            get { return soundExplosion; }
            set { soundExplosion = value; }
        }

        private SpriteFont hudFont;
        public SpriteFont HudFont
        {
            get { return hudFont; }
            set { hudFont = value; }
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

        private Dictionary<Color, Microsoft.Xna.Framework.Graphics.Model> modelsSpaceship = new Dictionary<Color, Microsoft.Xna.Framework.Graphics.Model>();
        public Microsoft.Xna.Framework.Graphics.Model GetColoredSpaceship(Color color)
        {
            Microsoft.Xna.Framework.Graphics.Model model;
            modelsSpaceship.TryGetValue(color, out model);
            return model;
        }
        public void SetColoredSpaceship(Color color, Microsoft.Xna.Framework.Graphics.Model model)
        {
            modelsSpaceship.Add(color, model);
        }

        //private Microsoft.Xna.Framework.Graphics.Model modelSpaceship;
        //public Microsoft.Xna.Framework.Graphics.Model ModelSpaceship
        //{
        //    get { return modelSpaceship; }
        //    set { modelSpaceship = value; }
        //}

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
