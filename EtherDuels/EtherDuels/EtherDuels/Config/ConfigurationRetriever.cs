using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtherDuels.Game.Model;

namespace EtherDuels.Config
{   
    /// <summary>
    /// Provides methods to retrieve information of the Configuration.
    /// </summary>
    public interface ConfigurationRetriever
    {   
        /// <summary>
        /// Gets the difficulty of the game.
        /// </summary>
        int Difficulty { get; }

        /// <summary>
        /// Gets the difficulty of the AI Player.
        /// </summary>
        int Difficulty_AI { get; }

        /// <summary>
        /// Gets the KeyboardConfiguration of a player.
        /// The player is defined by its playerID.
        /// </summary>
        /// <param name="playerID">The player's ID.</param>
        /// <returns>The KeyboardConfiguration attached to the playerID.</returns>
        KeyboardConfiguration GetKeyboardConfiguration(int playerID);
    }
}
