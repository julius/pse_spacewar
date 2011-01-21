using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtherDuels.Game.Model;
using EtherDuels.Game.View;
using Microsoft.Xna.Framework.Graphics;
using EtherDuels.Config;
using Microsoft.Xna.Framework;

namespace EtherDuels.Game
{
    /// <summary>
    /// Build a new game with a predefined level.
    /// </summary>
    class SimpleGameBuilder: GameBuilder
    {    
        private GameAssets gameAssets = GameAssets.Instance;

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

        /// <summary>
        /// Creates a new SimpleGameBuilder.
        /// </summary>
        /// <param name="configuration">The assigned configuration.</param>
        public SimpleGameBuilder(Configuration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// Creates a new GameModel and its subcomponents.
        /// </summary>
        /// <returns>The created GameModel.</returns>
        public GameModel BuildModel()
        {
            // build game objects
            Planet planet = new Planet();
            planet.Radius = 300;

            // build planet in orbit
            int distance = 700;

            Planet planet2 = new Planet();
            planet2.Radius = 82;
            planet2.IsFlexible = true;
            planet2.Position = new Vector2(distance, 0);
            // calculate velocity needed to circuit in orbit
            int planet2Velocity = (int) Math.Sqrt(planet.Mass * GameAssets.G / distance / (GameAssets.N * 1000));
            planet2.Velocity = new Vector2(0, planet2Velocity);

            Spaceship spaceship1 = new Spaceship();
            Spaceship spaceship2 = new Spaceship();

            Player player1 = new HumanPlayer(1, this.playerHandler, Color.Green, this.configuration.GetKeyboardConfiguration(1));
            Player player2 = new HumanPlayer(2, this.playerHandler, Color.Orange, this.configuration.GetKeyboardConfiguration(2));
            player1.Spaceship = spaceship1;
            player2.Spaceship = spaceship2;

            player1.Spaceship.Position = new Vector2(-1900, 0);
            player2.Spaceship.Position = new Vector2(1900, 0);

            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);

            WorldObject[] worldObjects = {planet, planet2, spaceship1, spaceship2};

            // build ShortLifespanObjectFactory
            ShortLifespanObjectFactory shortLifespanObjectFactory = new SimpleShortLifespanObjectFactory();
            
            // build game model
            World world = new World(worldObjects);
            Physics physics = new SimplePhysicsAlgorithm(this.collisionHandler, world, configuration);
            GameModel gameModel = new GameModel(shortLifespanObjectFactory, physics, players, world);
            return gameModel;
        }

        /// <summary>
        /// Creates a new GameView and its subcomponents.
        /// </summary>
        /// <param name="model">The assigned GameModel.</param>
        /// <returns>The created GameView.</returns>
        public GameView BuildView(GameModel model)
        {
            WorldView worldView = new WorldView(model.World);
            GameView gameView;
            int i = 0; // to count the planets in the list of world objects

            foreach (WorldObject worldObject in model.World.WorldObjects)
            {
                if (worldObject is Spaceship)
                {
                    Player player = GetPlayerOfSpaceship(model, (Spaceship)worldObject);
                    worldView.AddWorldObjectView(new WorldObjectView(gameAssets.GetColoredSpaceship(player.PlayerColor), worldObject));
                    //worldView.AddWorldObjectView(new WorldObjectView(gameAssets.ModelSpaceship, worldObject));
                }
                else if (worldObject is Planet)
                {
                    worldView.AddWorldObjectView(new WorldObjectView(gameAssets.GetModelPlanets()[i], worldObject));
                    i++;
                }
                else if (worldObject is Projectile)
                {
                    worldView.AddWorldObjectView(new WorldObjectView(gameAssets.ModelRocket, worldObject));
                }
            }

            gameView = new GameView(model, worldView);

            return gameView;
        }

        private Player GetPlayerOfSpaceship(GameModel gameModel, Spaceship spaceship)
        {
            foreach (Player player in gameModel.Players)
            {
                if (player.Spaceship == spaceship)
                {
                    return player;
                }
            }
            return null;
        }
    }
}
