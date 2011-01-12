
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using EtherDuels.Game.Model;
using EtherDuels.Game.View;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace EtherDuels.Game
{   
    /// <summary>
    /// The GameController is responsible for the communication between the GameModel and its GameView.
    /// It creates new worlds and its views via a GameBuilder and can remove and add objects to them.
    /// It also observes, if a game has ended or was paused, so it has to inform its GameHandler.
    /// </summary>
    public class GameController
    {
        private GameBuilder gameBuilder;
        private GameHandler gameHandler;
        private GameModel gameModel;
        private GameView gameView;
        private GameTime gameTime;
        private FrameState frameState;
        


        /// <summary>
        /// Constructor of a GameController object.
        /// </summary>
        /// <param name="gameBuilder">Defines the GameBuilder the Controller uses.</param> 
        /// <param name="gameHandler">Defines the GameHandler the Controller uses.</param> 
        public GameController(GameBuilder gameBuilder, GameHandler gameHandler)
        {
            this.gameBuilder = gameBuilder;
            this.gameHandler = gameHandler;
            gameModel = null;
            gameView = null;
        }

       /// <summary>
       /// Creates a new game using its dedicated GameBuilder.
       /// A game consists of a model and its view.
       /// A new game is just created, when there don't exist one yet.
       /// </summary>
        public void CreateGame()
        {
            Debug.Assert(gameModel == null,"A gamemodel already exists");
            
            gameModel = gameBuilder.BuildModel();

            gameView = gameBuilder.BuildView(gameModel);
            

        }

        /// <summary>
        /// Creates a new world using its dedicated GameBuilder.
        /// A new world can just be created if there exists a gameModel already.
        /// </summary>
        public void CreateWorld()
        {
            Debug.Assert(gameModel != null, "No gamemodel exists");
            
            World newWorld = gameBuilder.BuildWorld();
            gameModel.World = newWorld;

            WorldView worldView = gameBuilder.BuildWorldView(newWorld);
            gameView.WorldView = worldView;
          

        }

        /// <summary>
        /// Draws the gameView and all its subcomponents.
        /// </summary>
        /// <param name="viewPort">Defines the Viewport, which is to use.</param>
        /// <param name="spriteBatch">Defines the SpriteBatch, which is to use.</param>
        public void Draw(Viewport viewPort, SpriteBatch spriteBatch)
        {
            Debug.Assert(gameView != null, "No gameview exists");
            
            gameView.Draw(viewPort, spriteBatch);
            
            
        }

        /// <summary>
        /// Reacts to a collision that happend in the game depending on 
        /// the type of the two assigned WorldObjects.
        /// This method creates an explosion, reduces the health of the WorldObject, if necessary,
        /// and checks, if one of the involved WorldObjects has to be removed from the world.
        /// </summary>
        /// <param name="collisionObject1">The first WorldObject, which was involved in the collision.</param>
        /// <param name="collisionObject2">The second WorldObject, which was involved in the collision.</param>
        public void OnCollision(WorldObject collisionObject1, WorldObject collisionObject2)
        {

            Debug.Assert(gameModel != null);

            Explosion explosion = gameModel.GetFactory().CreateExplosion(gameTime);
            
            // TODO SetPosition
            // TODO SetCreationTime
            // TODO Health abziehen, überprüfen ob das Objekt noch lebensberechtigung hat, evtl gamehandler benachrichtigen
            
            WorldObjectView explosionView = gameModel.GetFactory().CreateExplosionView(explosion);

            gameModel.World.AddWorldObject(explosion);
            gameView.WorldView.AddWorldObjectView(explosionView);
            

        }

        /// <summary>
        /// Creates a projectile an its fitting view. 
        /// </summary>
        /// <param name="shooter">The Spaceship, which fired a projectile.</param>
        public void OnFire(Spaceship shooter)
        { 
            // TODO whole method.
        }

        /// <summary>
        /// Updates the GameModel and its subcomponents.
        /// </summary>
        /// <param name="gameTime">The time, which is passed since the last update.</param>
        public void Update(GameTime gameTime)
        {
            this.gameTime = gameTime;
            Debug.Assert(gameModel != null, "No gamemodel exists");      //TODO Exception verwenden. Update soll nicht aufgerufen werden, wenn GameModel nicht existiert--- Assertions sind besser, da das kein erwartetes Verhalten ist.
            
            gameModel.Update(frameState);
            
        }
    }



}

