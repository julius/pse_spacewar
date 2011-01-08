using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtherDuels.Game.Model;
using EtherDuels.Game.View;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace EtherDuels.Game
{
    public class GameController
    {
        private GameBuilder gameBuilder;
        private GameHandler gameHandler;
        private GameModel gameModel;
        private GameView gameView;
        private GameTime gameTime;
        private FrameState frameState;

        /* The constructor of GameController */
        public GameController(GameBuilder gameBuilder, GameHandler gameHandler)
        {
            this.gameBuilder = gameBuilder;
            this.gameHandler = gameHandler;
            gameModel = null;
            gameView = null;
        }

        /* Creates a new Game together with a fitting GameView */
        public void CreateGame()
        {
            if (gameModel == null)
            {
                gameModel = gameBuilder.BuildModel();

                gameView = gameBuilder.BuildView(gameModel);
            }

        }

        /* Creates a new World together with a fitting WorldView*/
        public void CreateWorld()
        {
            if (gameModel != null)
            {
                World newWorld = gameBuilder.BuildWorld();
                gameModel.World = newWorld;

                WorldView worldView = gameBuilder.BuildWorldView(newWorld);
                gameView.SetWorldView(worldView);
            }
            /* TODO Soll hier ein else Zweig hin, der dann CreateGame aufruft oder nicht? */

        }

        /* Draws its subcomponents */
        public void Draw(Viewport viewPort, SpriteBatch spriteBatch)
        {
            if (gameView != null)
            {
                gameView.Draw(viewPort, spriteBatch);
            }
            /* TODO Soll hier ein else Zweig hin, der dann CreateGame aufruft oder nicht? */
        }

        /*  */
        public void OnCollision(WorldObject collisionObject1, WorldObject collisionObject2)
        {
            if (gameModel != null)
            {
                Explosion explosion = gameModel.GetFactory().CreateExplosion(gameTime);

                // TODO SetPosition
                // TODO SetCreationTime

                WorldObjectView explosionView = gameModel.GetFactory().CreateExplosionView(explosion);

                gameModel.World.AddWorldObject(explosion);
                gameView.GetWorldView().AddWorldObjectView(explosionView);
            }

        }

        /* Creates a projectile and its fitting view */
        public void OnFire(Spaceship shooter)
        { 


        }

        /* Updates the GameModel */
        public void Update(GameTime gameTime)
        {
            this.gameTime = gameTime;
            if (gameModel != null)      //TODO Exception verwenden. Update soll nicht aufgerufen werden, wenn GameModel nicht existiert
            {
                gameModel.Update(frameState);
            }
        }
    }



}

