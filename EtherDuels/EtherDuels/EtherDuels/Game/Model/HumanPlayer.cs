using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace EtherDuels.Game.Model
{
    public class HumanPlayer: Player
    {
        private InputConfigurationRetriever inputConfigurationRetriever;

        /// <summary>
        /// Creates a Human Player
        /// </summary>
        /// <param name="playerId">The player's ID</param>
        /// <param name="playerHandler">The player's Handler</param>
        /// <param name="inputConfigurationRetriever">The input configuration for the player</param>
        public HumanPlayer(int playerId, PlayerHandler playerHandler, InputConfigurationRetriever inputConfigurationRetriever): base(playerId, playerHandler)
        {
            this.inputConfigurationRetriever = inputConfigurationRetriever;
        }

        /// <summary>
        /// Called for every frame of the game.
        /// Computes keyboard input and moves, shoots... accordingly.
        /// </summary>
        /// <param name="frameState">frame specific state</param>
        public override void Update(FrameState frameState)
        {
            // TODO
        }
    }
}
