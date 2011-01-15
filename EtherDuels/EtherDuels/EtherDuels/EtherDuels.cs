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

namespace EtherDuels
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class EtherDuels : Microsoft.Xna.Framework.Game, MenuHandler, GameHandler
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private MenuController menuController;
        private GameController gameController;
        private ProgramState programState;

        GameView gameView; // TODO <- remove this one later
        private Game.Model.InputConfigurationRetriever inputConfigurationRetriever;

        public EtherDuels()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Sample code to draw some models and stuff
            // (Not production code !)
            ContentManager content = new ContentManager(Services, "Assets");
            SpriteFont font = content.Load<SpriteFont>("NiceFont");
            Texture2D textureStars = content.Load<Texture2D>("texture_stars");
            Model modelShip = content.Load<Model>("player_ship");
            Model modelPlanet = content.Load<Model>("planet");

            // Spaceship ship = new Spaceship();
            // WorldObjectView shipView = new WorldObjectView(modelShip, ship);

            //this.gameView = new GameView();
            //this.gameView.WorldView = new WorldView(textureStars, null);
            //this.gameView.WorldView.AddWorldObjectView(shipView);

            ConfigurationReader configurationReader = new ConfigurationReader(new BinaryFormatter(), null);
            Configuration configuration = configurationReader.read("config.cfg");

            // Build MenuController
            MenuBuilder menuBuilder = new SimpleMenuBuilder(this, font);
            MenuModel menuModel = menuBuilder.BuildModel();
            MenuView menuView = menuBuilder.BuildView(menuModel);
            this.menuController = new MenuController(this, menuModel, menuView);
            this.menuController.SetMainMenu();

            // TODO: Build GameController
            GameBuilder gameBuilder = new SimpleGameBuilder(configuration);
            gameBuilder.Background = textureStars;
            gameBuilder.SpaceshipModel = modelShip;
            gameBuilder.PlanetModel = modelPlanet;

            this.gameController = new GameController(gameBuilder, this);

            // Build Programstate
            this.programState = new ProgramState();
            programState.GameState = GameState.NoGame;
            programState.MenuState = MenuState.InMenu;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
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


            /* TODO: edit claudi: bei gamePaused soll der doch nicht mehr den GameController updaten?
             * sonst kriegen wir vor allem probleme mit den Keyboard-Abfragen. Bei Menü-Eintrag hoch
             * würd sich dann das eine Raumschiff bewegen. */

            // Update GameController if necessary
            /*if (this.programState.GameState != GameState.NoGame)
            {
                this.gameController.Update(frameState);
            }*/
            if (this.programState.GameState == GameState.InGame)
            {
                this.gameController.Update(frameState);
            }

            // Update MenuController if necessary
            if (this.programState.MenuState == MenuState.InMenu)
            {
                this.menuController.Update(frameState);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //this.gameView.Draw(this.GraphicsDevice.Viewport, this.spriteBatch);

            // Draw GameController if necessary
            if (this.programState.GameState != GameState.NoGame)
            {
                this.gameController.Draw(this.GraphicsDevice.Viewport, this.spriteBatch);
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
        /// 
        /// </summary>
        public void OnResumeGame()
        {
            throw new NotImplementedException();
        }


        /* === GameHandler Methods === */

        public void OnGamePaused()
        {
            this.programState.GameState = GameState.GamePaused;
            this.programState.MenuState = MenuState.InMenu;
        }

        public void OnGameEnded(int playerID, int points)
        {
            throw new NotImplementedException();
        }
    }
}
