using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtherDuels.Game.Model;
using Microsoft.Xna.Framework;
using EtherDuels.Config;

namespace EtherDuels.Ruby
{
    /// <summary>
    /// API class for the Ruby scripting environment.
    /// Has methods which help to build a level.
    /// </summary>
    class LevelBuilder
    {
        private List<WorldObject> worldObjectList = new List<WorldObject>();
        private List<Player> players = new List<Player>();
        private PlayerHandler playerHandler;
        private Configuration configuration;

        /// <summary>
        /// Build new LevelBuilder
        /// </summary>
        /// <param name="configuration">Configuration of the Program</param>
        /// <param name="playerHandler">Handler for players</param>
        public LevelBuilder(Configuration configuration, PlayerHandler playerHandler)
        {
            this.configuration = configuration;
            this.playerHandler = playerHandler;
        }

        /// <summary>
        /// List of Players for the Level
        /// </summary>
        public List<Player> Players
        {
            get { return this.players; }
        }


        /// <summary>
        /// Lists of WorldObjects for the level
        /// </summary>
        public WorldObject[] WorldObjects
        {
            get { return this.worldObjectList.ToArray(); }
        }


        /// <summary>
        /// Creates a new Vector2
        /// </summary>
        /// <param name="x">X-Value of the Vector</param>
        /// <param name="y">Y-Value of the Vector</param>
        /// <returns>The requested Vector</returns>
        public Vector2 Vector(float x, float y)
        {
            return new Vector2(x, y);
        }

        /// <summary>
        /// Adds a planet to the level
        /// </summary>
        /// <returns>The added planet</returns>
        public Planet AddPlanet()
        {
            Planet planet = new Planet();
            planet.Mass = 6E24;
            planet.Health = 1000000;
            planet.Attack = 1000;
            planet.Radius = 300;
            this.worldObjectList.Add(planet);

            return planet;
        }

        /// <summary>
        /// Adds a player, with ID 1
        /// </summary>
        /// <returns>The added player</returns>
        public Player AddPlayer1()
        {
            Spaceship spaceship = new Spaceship();
            spaceship.Mass = 8000;
            this.worldObjectList.Add(spaceship);

            Player player = new HumanPlayer(1, this.playerHandler, Color.Green, this.configuration.GetKeyboardConfiguration(1));
            player.Spaceship = spaceship;

            player.Spaceship.Velocity = new Microsoft.Xna.Framework.Vector2(0, 0);
            player.Spaceship.CurrentWeapon = Weapon.Rocket;
            player.Spaceship.Attack = 50;
            player.Spaceship.Radius = 240;
            player.Spaceship.Health = 100;
            player.Spaceship.Position = new Microsoft.Xna.Framework.Vector2(-1900, 200);
            this.players.Add(player);

            return player;
        }

        /// <summary>
        /// Adds a player, with ID 2
        /// </summary>
        /// <returns>The added player</returns>
        public Player AddPlayer2()
        {
            Spaceship spaceship = new Spaceship();
            spaceship.Mass = 8000;
            this.worldObjectList.Add(spaceship);

            Player player = new HumanPlayer(2, this.playerHandler, Color.Orange, this.configuration.GetKeyboardConfiguration(2));
            player.Spaceship = spaceship;

            player.Spaceship.Velocity = new Microsoft.Xna.Framework.Vector2(0, 0);
            player.Spaceship.CurrentWeapon = Weapon.Rocket;
            player.Spaceship.Attack = 50;
            player.Spaceship.Radius = 240;
            player.Spaceship.Health = 100;
            player.Spaceship.Position = new Microsoft.Xna.Framework.Vector2(1900, 200);
            this.players.Add(player);

            return player;
        }
    }
}
