using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace EtherDuels.Game.Model
{
    /// <summary>
    /// Defines an abstract player in the game.
    /// </summary>
    public abstract class Player
    {
        protected PlayerHandler playerHandler;

        protected int playerId;

        /// <summary>
        /// Returns the player's ID.
        /// </summary>
        virtual public int PlayerId
        {
            get { return this.playerId; }
        }

        protected Spaceship spaceship;
        /// <summary>
        /// Returns the player's spaceship.
        /// </summary>
        virtual public Spaceship Spaceship
        {
            get { return this.spaceship; }
            set { this.spaceship = value; }
        }

        protected Color playerColor;
        /// <summary>
        /// Returns the player's color.
        /// </summary>
        public Color PlayerColor
        {
            get { return this.playerColor; }
        }

        /// <summary>
        /// Creates a player.
        /// </summary>
        /// <param name="playerId">The player's ID.</param>
        /// <param name="playerHandler">The player's Handler.</param>
        /// <param name="playerColor">The player's color.</param>
        public Player(int playerId, PlayerHandler playerHandler, Color playerColor)
        {
            this.playerId = playerId;
            this.playerHandler = playerHandler;
            this.playerColor = playerColor;
        }

        public Player() { } //TODO: hier sollte man vllt wenigstens default-werte zuweisen?

        /// <summary>
        /// This method is being called for every frame of the game.
        /// It updates the player's behaviour.
        /// </summary>
        /// <param name="frameState">frame specific state</param>
        public abstract void Update(FrameState frameState);
    }
}
