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
    /// <summary>
    /// The GameAssets class contains all assets needed for the game itself.
    /// It is a singleton, meaning there can only be one instance of this class.
    /// </summary>
    sealed class GameAssets
    {
        private static readonly GameAssets instance = new GameAssets();

        // private constructor
        private GameAssets() { }

        /// <summary>
        /// Returns the only instance of this class.
        /// </summary>
        public static GameAssets Instance
        {
            get
            {
                return instance;
            }
        }        

        // G: gravitational constant
        public static double G = 6.67428E-11;  // in m^3/kg/s^2
        // N: normalisation factor, to downsize the dimensions of the universe to those of our game
        public static float N = 300000;        // must NOT be 0!!

       public static int leftFieldBoundary = -4000;

        public static int rightFieldBoundary = 4000;

        public static int upperFieldBoundary = -3300;

        public static int lowerFieldBoundary = 2900;


        private Song soundtrack;
        public Song Soundtrack
        {
            get { return soundtrack; }
            set { soundtrack = value; }
        }

        private SoundEffect soundRocket;
        public SoundEffect SoundRocket
        {
            get { return soundRocket; }
            set { soundRocket = value; }
        }

        private SoundEffect soundLaser;
        public SoundEffect SoundLaser
        {
            get { return soundLaser; }
            set { soundLaser = value; }
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

        private List<Microsoft.Xna.Framework.Graphics.Model> modelPlanets = new List<Microsoft.Xna.Framework.Graphics.Model>();
        public void AddModelPlanet(Microsoft.Xna.Framework.Graphics.Model modelPlanet)
        {
            modelPlanets.Add(modelPlanet);
        }

        public Microsoft.Xna.Framework.Graphics.Model[] GetModelPlanets()
        {
            return modelPlanets.ToArray();
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
    }
}
