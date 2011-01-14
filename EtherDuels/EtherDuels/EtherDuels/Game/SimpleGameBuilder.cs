using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtherDuels.Game.Model;
using EtherDuels.Game.View;
using Microsoft.Xna.Framework.Graphics;

namespace EtherDuels.Game
{
    class SimpleGameBuilder: GameBuilder
    {
        private Texture2D background;
        public Texture2D Background
        {
            set { this.background = value; }
        }

        private Microsoft.Xna.Framework.Graphics.Model spaceshipModel;
        public Microsoft.Xna.Framework.Graphics.Model SpaceshipModel
        {
            set { this.spaceshipModel = value; }
        }

        private Microsoft.Xna.Framework.Graphics.Model planetModel;
        public Microsoft.Xna.Framework.Graphics.Model PlanetModel
        {
            set { this.planetModel = value; } 
        }

        private CollisionHandler collisionHandler;
        public CollisionHandler CollisionHandler
        {
            set { this.collisionHandler = value; }
        }

        private PlayerHandler playerHandler;
        public PlayerHandler PlayerHandler
        {
            set { this.playerHandler = value; }
        }

        private Configuration configuration;

        public SimpleGameBuilder(Configuration configuration)
        {
            this.configuration = configuration;
        }

        public GameModel BuildModel()
        {
            // build game objects
            Planet planet = new Planet();
            planet.Mass = 100000;

            Spaceship spaceship1 = new Spaceship();
            Spaceship spaceship2 = new Spaceship();
            spaceship1.Mass = 1;
            spaceship2.Mass = 1;

            Player player1 = new HumanPlayer(1, this.playerHandler, this.configuration.GetKeyboardConfiguration(1));
            Player player2 = new HumanPlayer(2, this.playerHandler, this.configuration.GetKeyboardConfiguration(2));
            player1.Spaceship = spaceship1;
            player2.Spaceship = spaceship2;

            player1.Spaceship.Velocity = new Microsoft.Xna.Framework.Vector2(10, 10);
            player2.Spaceship.Velocity = new Microsoft.Xna.Framework.Vector2(10, 10);

            List<Player> players = new List<Player>();      //TODO  edit Claudi: Hab das Array in eine Liste umgewandelt.
            players.Add(player1);
            players.Add(player2);

            WorldObject[] worldObjects = { planet, spaceship1, spaceship2 };

            // build game model
            ShortLifespanObjectFactory shortLifespanObjectFactory = new SimpleShortLifespanObjectFactory();
            World world = new World(worldObjects, planet);
            Physics physics = new SimplePhysicsAlgorithm(this.collisionHandler, world);
            GameModel gameModel = new GameModel(shortLifespanObjectFactory, physics, players, world);
            return gameModel;
        }

        public GameView BuildView(GameModel model)
        {
            WorldView worldView = new WorldView(background, model.World);

            foreach (WorldObject worldObject in model.World.WorldObjects)
            {
                if (worldObject is Spaceship)
                {
                    worldView.AddWorldObjectView(new WorldObjectView(spaceshipModel, worldObject));
                }
                else if (worldObject is Planet)
                {
                    worldView.AddWorldObjectView(new WorldObjectView(planetModel, worldObject));
                }
            }

            return new GameView(model, worldView);
        }
    }
}
