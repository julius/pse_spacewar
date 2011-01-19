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

        public SimpleGameBuilder(Configuration configuration)
        {
            this.configuration = configuration;
        }

        public GameModel BuildModel()
        {
            // build game objects
            Planet planet = new Planet();
            planet.Mass = 6E24;
            planet.Health = 1000000;
            planet.Attack = 1000;
            planet.Radius = 300;            

            Spaceship spaceship1 = new Spaceship();
            Spaceship spaceship2 = new Spaceship();
            spaceship1.Mass = 8000;
            spaceship2.Mass = 8000;

            Player player1 = new HumanPlayer(1, this.playerHandler, Color.Green, this.configuration.GetKeyboardConfiguration(1));
            Player player2 = new HumanPlayer(2, this.playerHandler, Color.Orange, this.configuration.GetKeyboardConfiguration(2));
            player1.Spaceship = spaceship1;
            player2.Spaceship = spaceship2;

            player1.Spaceship.Velocity = new Microsoft.Xna.Framework.Vector2(0, 0);
            player1.Spaceship.CurrentWeapon = Weapon.Rocket;
            player1.Spaceship.Attack = 50;
            player1.Spaceship.Radius = 240;
            player1.Spaceship.Health = 100;
            player1.Spaceship.Position = new Microsoft.Xna.Framework.Vector2(-1900, 200);

            player2.Spaceship.Velocity = new Microsoft.Xna.Framework.Vector2(0, 0);
            player2.Spaceship.CurrentWeapon = Weapon.Rocket;
            player2.Spaceship.Attack = 50;
            player2.Spaceship.Radius = 240;
            player2.Spaceship.Health = 100;
            player2.Spaceship.Position = new Microsoft.Xna.Framework.Vector2(1900, 200);

            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);

            WorldObject[] worldObjects = {  spaceship1, planet, spaceship2};

            // build ShortLifespanObjectFactory
            ShortLifespanObjectFactory shortLifespanObjectFactory = new SimpleShortLifespanObjectFactory();
            shortLifespanObjectFactory.RocketModel = gameAssets.ModelRocket;
            shortLifespanObjectFactory.LaserModel = gameAssets.ModelLaser;
            shortLifespanObjectFactory.ExplosionModel = gameAssets.ModelExplosion;

            // build game model
            World world = new World(worldObjects);
            Physics physics = new SimplePhysicsAlgorithm(this.collisionHandler, world);
            GameModel gameModel = new GameModel(shortLifespanObjectFactory, physics, players, world);
            return gameModel;
        }

        public GameView BuildView(GameModel model)
        {
            WorldView worldView = new WorldView(gameAssets.TextureBackground, model.World);
            GameView gameView;

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
                    worldView.AddWorldObjectView(new WorldObjectView(gameAssets.ModelPlanet, worldObject));
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
