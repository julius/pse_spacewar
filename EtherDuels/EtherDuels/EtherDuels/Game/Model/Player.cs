using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace EtherDuels.Game.Model
{
    /// <summary>
    /// Defines a player in the game.
    /// </summary>
    public abstract class Player
    {
        protected PlayerHandler playerHandler;

        protected int playerId;
        /// <summary>
        /// Gets the player's ID.
        /// </summary>
        public int PlayerId
        {
            get { return this.playerId; }
        }

        protected int points = 0;
        /// <summary>
        /// Gets the player's points.
        /// </summary>
        public int Points
        {
            get { return this.points; }
            set { this.points = value; }
        }

        protected Spaceship spaceship;
        /// <summary>
        /// Gets the player's Spaceship.
        /// </summary>
        public Spaceship Spaceship
        {
            get { return this.spaceship; }
            set { this.spaceship = value; }
        }

        /// <summary>
        /// Creates a player.
        /// </summary>
        /// <param name="playerId">The player's ID.</param>
        /// <param name="playerHandler">The player's Handler.</param>
        public Player(int playerId, PlayerHandler playerHandler)
        {
            this.playerId = playerId;
            this.playerHandler = playerHandler;
        }

        /// <summary>
        /// Called for every frame of the game.
        /// Updates to the player's behaviour should be implemented in this method.
        /// </summary>
        /// <param name="frameState">frame specific state</param>
        public abstract void Update(FrameState frameState);
    }
}
