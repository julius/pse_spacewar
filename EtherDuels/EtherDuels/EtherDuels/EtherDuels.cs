using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using EtherDuels.Game.View;
using EtherDuels.Game.Model;
using EtherDuels.Menu;
using EtherDuels.Game;
using EtherDuels.Menu.Model;
using EtherDuels.Menu.View;
using System.Runtime.Serialization.Formatters.Binary;
using EtherDuels.Config;
using EtherDuels.Ruby;

namespace EtherDuels
{
    /// <summary>
    /// This is the main class for the game. It defines the highest layer in the class structure.
    /// </summary>
    public class EtherDuels : Microsoft.Xna.Framework.Game, MenuHandler, GameHandler
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private MenuController menuController;
        private GameController gameController;
        private ProgramState programState;

        /// <summary>
        /// Creates a new instance of EtherDuels. Only one is needed for the game.
        /// </summary>
        public EtherDuels()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content. Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();

            Window.Title = "EtherDuels";

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and it loads all the content needed for the game.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            
            // (Not production code !)
            ContentManager content = new ContentManager(Services, "Assets");

            // Fonts
            SpriteFont menuFont = content.Load<SpriteFont>("NiceFont");

            // Textures
            Texture2D textureStars = content.Load<Texture2D>("texture_space");
            Texture2D textureHealthBar = content.Load<Texture2D>("texture_healthbar");
            Texture2D textureSmoke = content.Load<Texture2D>("texture_smoke");

            // Models
            Model modelSpaceshipGreen = content.Load<Model>("spaceship_green");
            Model modelSpaceshipOrange = content.Load<Model>("spaceship_orange"); 
            Model modelMoon = content.Load<Model>("moon");
            Model modelEarth = content.Load<Model>("earth");
            Model modelRocket = content.Load<Model>("rocket");
            Model modelLaser = content.Load<Model>("laser_blast");
            Model modelExplosion = content.Load<Model>("explosion");
            Model modelMars = content.Load<Model>("mars");

            // Sound effects
            SoundEffect soundExplosion = content.Load<SoundEffect>("sound_explosion");
            SoundEffect soundLaser = content.Load<SoundEffect>("sound_laser");
            SoundEffect soundRocket = content.Load<SoundEffect>("sound_rocket");
            SoundEffect soundMenuClick = content.Load<SoundEffect>("sound_menuClick");
            Song soundtrack = content.Load<Song>("soundtrack_libellaSwing");

            SoundEffect.MasterVolume = 1.0f;
            

            // Build Asset classes
            MenuAssets menuAssets = MenuAssets.Instance;
            GameAssets gameAssets = GameAssets.Instance;

            // Load content into the asset classes
            menuAssets.MenuFont = menuFont;
            menuAssets.TextureBackground = textureStars;
            menuAssets.SoundMenuClick = soundMenuClick;

            gameAssets.TextureHealthBar = textureHealthBar;
            gameAssets.TextureSmoke = textureSmoke;
            gameAssets.TextureBackground = textureStars;
            gameAssets.SetColoredSpaceship(Color.Green, modelSpaceshipGreen);
            gameAssets.SetColoredSpaceship(Color.Orange, modelSpaceshipOrange);
            gameAssets.ModelRocket = modelRocket;
            gameAssets.ModelLaser = modelLaser;
            gameAssets.ModelExplosion = modelExplosion;
            gameAssets.SoundExplosion = soundExplosion;
            gameAssets.SoundLaser = soundLaser;
            gameAssets.SoundRocket = soundRocket;
            gameAssets.Soundtrack = soundtrack;
            gameAssets.HudFont = menuFont;
            // change this to try out different planet models
            gameAssets.AddModelPlanet(modelEarth);
            gameAssets.AddModelPlanet(modelMoon);
            gameAssets.AddModelPlanet(modelMars);
            
            ConfigurationReader configurationReader = new ConfigurationReader(new BinaryFormatter(), null);
            Configuration configuration = configurationReader.read("config.cfg");

            // Build MenuBuilder, MenuModel, MenuView and MenuController
            MenuBuilder menuBuilder = new SimpleMenuBuilder(this, configuration);
            MenuModel menuModel = menuBuilder.BuildModel();
            MenuView menuView = menuBuilder.BuildView(menuModel);
            this.menuController = new MenuController(this, menuModel, menuView);
            // set the main menu active. This is where the game starts.
            this.menuController.SetMainMenu();

            // Build GameBuilder and GameController
            //GameBuilder gameBuilder = new SimpleGameBuilder(configuration);
            /* this code can be used to build levels from files:
             * you may replace it with the code line above.
             * */
            GameBuilder gameBuilder = new RubyGameBuilder("level.rb", configuration);

            this.gameController = new GameController(gameBuilder, this);

            // Build Programstate
            this.programState = new ProgramState();
            programState.GameState = GameState.NoGame;
            programState.MenuState = MenuState.InMenu;

            // play background music
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(soundtrack);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            FrameState frameState = new FrameState(gameTime, Keyboard.GetState());
            
            if (this.programState.GameState == GameState.InGame)
            {
                this.gameController.Update(frameState);
            }

            // Update MenuController if necessary
            if (this.programState.MenuState == MenuState.InMenu)
            {
                this.menuController.Update(frameState);
            }

            if (this.programState.GameState == GameState.GameEnded)
            {
                if (this.programState.GameEndTime == TimeSpan.Zero)
                {
                    this.programState.GameEndTime = gameTime.TotalGameTime;
                }
                else
                {
                    if (gameTime.TotalGameTime.TotalMilliseconds - this.programState.GameEndTime.TotalMilliseconds > 1000)
                    {
                        this.programState.GameEndTime = TimeSpan.Zero;
                        this.programState.GameState = GameState.NoGame;
                        this.programState.MenuState = MenuState.InMenu;
                    }
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This method is called when the game is supposed to draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
                      
            // Draw GameController if necessary
            if (this.programState.GameState == GameState.InGame || this.programState.GameState == GameState.GameEnded)
            {
                this.gameController.Draw(this.GraphicsDevice.Viewport, this.spriteBatch, gameTime);
            }

            // Draw MenuController if necessary
            if (this.programState.MenuState == MenuState.InMenu)
            {
                this.menuController.Draw(this.GraphicsDevice.Viewport, this.spriteBatch);
            }

            base.Draw(gameTime);
        }


        /* === MenuHandler Methods === */

        /// <summary>
        /// Creates a new game.
        /// </summary>
        public void OnNewGame()
        {
            this.gameController.CreateGame();
            this.programState.GameState = GameState.InGame;
            this.programState.MenuState = MenuState.NoMenu;
        }

        /// <summary>
        /// Quits the program.
        /// </summary>
        public void OnQuitProgram()
        {
            this.Exit();
        }

        /// <summary>
        /// Resumes the current game.
        /// </summary>
        public void OnResumeGame()
        {
            this.programState.GameState = GameState.InGame;
            this.programState.MenuState = MenuState.NoMenu;
        }


        /* === GameHandler Methods === */

        /// <summary>
        /// Returns to the pause menu and pauses the game.
        /// </summary>
        public void OnGamePaused()
        {
            this.menuController.SetPauseMenu();
            this.programState.GameState = GameState.GamePaused;
            this.programState.MenuState = MenuState.InMenu;
        }

        /// <summary>
        /// Returns to the main menu and ends the current game.
        /// </summary>
        /// <param name="playerID">The ID of the winning player.</param>
        public void OnGameEnded(int playerID)
        {
            this.menuController.SetGameEndedMenu(playerID);
            this.programState.GameState = GameState.GameEnded;
            this.programState.MenuState = MenuState.NoMenu;
        }
    }
}
