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

        private Texture2D smoke;
        public Texture2D Smoke
        {
            set { smoke = value; }
        }

        private Texture2D healthBar;
        public Texture2D HealthBar
        {
            set { healthBar = value; }
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

        private Microsoft.Xna.Framework.Graphics.Model rocketModel;
        public Microsoft.Xna.Framework.Graphics.Model RocketModel
        {
            set { rocketModel = value; }
        }

        private Microsoft.Xna.Framework.Graphics.Model explosionModel;
        public Microsoft.Xna.Framework.Graphics.Model ExplosionModel
        {
            set { explosionModel = value; }
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
            planet.Health = 1000000;
            planet.Attack = 1000;

            Spaceship spaceship1 = new Spaceship();
            Spaceship spaceship2 = new Spaceship();
            spaceship1.Mass = 1;
            spaceship2.Mass = 1;

            Player player1 = new HumanPlayer(1, this.playerHandler, this.configuration.GetKeyboardConfiguration(1));
            Player player2 = new HumanPlayer(2, this.playerHandler, this.configuration.GetKeyboardConfiguration(2));
            player1.Spaceship = spaceship1;
            player2.Spaceship = spaceship2;

            player1.Spaceship.Velocity = new Microsoft.Xna.Framework.Vector2(0, 0);
            player1.Spaceship.CurrentWeapon = Weapon.Rocket;
            player1.Spaceship.Attack = 50;
            player1.Spaceship.Radius = 240;
            player1.Spaceship.Health = 100;
            player1.Spaceship.Rotation = 180;
            player1.Spaceship.Position = new Microsoft.Xna.Framework.Vector2(1000, 1000);

            player2.Spaceship.Velocity = new Microsoft.Xna.Framework.Vector2(0, 0);
            player2.Spaceship.CurrentWeapon = Weapon.Rocket;
            player2.Spaceship.Attack = 50;
            player2.Spaceship.Radius = 240;
            player2.Spaceship.Health = 100;
            player2.Spaceship.Position = new Microsoft.Xna.Framework.Vector2(2000, 1000);

            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);

            WorldObject[] worldObjects = { planet, spaceship1, spaceship2 };

            // build ShortLifespanObjectFactory
            ShortLifespanObjectFactory shortLifespanObjectFactory = new SimpleShortLifespanObjectFactory();
            shortLifespanObjectFactory.RocketModel = rocketModel;
            shortLifespanObjectFactory.ExplosionModel = explosionModel;

            // build game model
            World world = new World(worldObjects, planet);
            Physics physics = new SimplePhysicsAlgorithm(this.collisionHandler, world);
            GameModel gameModel = new GameModel(shortLifespanObjectFactory, physics, players, world);
            return gameModel;
        }

        public GameView BuildView(GameModel model)
        {
            WorldView worldView = new WorldView(background, model.World);
            worldView.Smoke = smoke;
            GameView gameView;

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
                else if (worldObject is Projectile)
                {
                    worldView.AddWorldObjectView(new WorldObjectView(rocketModel, worldObject));
                }
            }

            gameView = new GameView(model, worldView);
            gameView.HealthBar = healthBar;

            return gameView;
        }
    }
}
