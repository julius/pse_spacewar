using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace EtherDuels.Game.Model
{
    /// <summary>
    /// Defines the GameModel.
    /// </summary>
    public class GameModel
    {
        private ShortLifespanObjectFactory factory;
        private Physics physics;
        private List<Player> players;
        private World world;
        
        /// <summary>
        /// Returns an array of the assigned players.
        /// </summary>
        /// <returns>The assigned players</returns>
        public Player[] Players
        {
            get { return players.ToArray<Player>(); }
        }

        /// <summary>
        /// Creates a new GameModel object.
        /// </summary>
        /// <param name="factory">The assigned ShortLifespanFactory to create new WorldObjects.</param>
        /// <param name="physics">The assigned Physics to calculate new positions.</param>
        /// <param name="players">An array of all players.</param>
        /// <param name="world">The assigned World.</param>
        public GameModel(ShortLifespanObjectFactory factory, Physics physics, List<Player> players, World world)
        {
            this.factory = factory;
            this.physics = physics;
            this.players = players;
            this.world = world;
        }

        /// <summary>
        /// Returns the assigned ShortLifespanFactory.
        /// </summary>
        /// <returns>The assigned ShortLifespanFactory.</returns>
        public ShortLifespanObjectFactory GetFactory()
        {
            return factory;
        }

        public void RemovePlayer(Player player)
        {
            players.Remove(player);
        }

        /// <summary>
        /// Updates the Physics and all Players.
        /// </summary>
        /// <param name="frameState">A state object, which contains how much time is passed since the last update.</param>
        public void Update(FrameState frameState)
        {
            foreach (Player player in players)
            {
                player.Update(frameState);
            }

            physics.Update(frameState.GameTime);
        }

        /// <summary>
        /// Gets and sets the World.
        /// </summary>
        public World World
        {
            get { return world; }
            set { world = value; }
        }
    }
}
