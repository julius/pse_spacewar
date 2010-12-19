using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace EtherDuels.Game.Model
{
    public abstract class Player
    {
        protected int playerId;
        protected PlayerHandler playerHandler;
        protected int points = 0;
        protected Spaceship spaceship;

        /// <summary>
        /// Creates a player.
        /// </summary>
        /// <param name="playerId">The player's ID</param>
        /// <param name="playerHandler">The player's Handler</param>
        public Player(int playerId, PlayerHandler playerHandler)
        {
            this.playerId = playerId;
            this.playerHandler = playerHandler;
        }

        /// <summary>
        /// Gets the ID of the player.
        /// </summary>
        /// <returns>The player's ID</returns>
        public int GetPlayerId()
        {
            return this.playerId;
        }

        /// <summary>
        /// Gets the points of the player.
        /// </summary>
        /// <returns>The player's points</returns>
        public int GetPoints()
        {
            return this.points;
        }

        /// <summary>
        /// Sets the points of the player.
        /// </summary>
        /// <param name="points">The player's points</param>
        public void SetPoints(int points)
        {
            this.points = points;
        }

        /// <summary>
        /// Gets the spaceship of the player.
        /// </summary>
        /// <returns>The player's spaceship.</returns>
        public Spaceship GetSpaceship()
        {
            return this.spaceship;
        }

        /// <summary>
        /// Sets the player's spaceship
        /// </summary>
        /// <param name="spaceship">The player's spaceship</param>
        public void SetSpaceship(Spaceship spaceship)
        {
            this.spaceship = spaceship;
        }

        /// <summary>
        /// Called for every frame of the game.
        /// Updates to the player's behaviour should be implemented in this method.
        /// </summary>
        /// <param name="frameState">frame specific state</param>
        public abstract void Update(FrameState frameState);
    }
}
