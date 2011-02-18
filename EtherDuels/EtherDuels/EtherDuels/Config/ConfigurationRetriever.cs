using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtherDuels.Game.Model;

namespace EtherDuels.Config
{   
    /// <summary>
    /// Provides methods to retrieve information from the configuration.
    /// </summary>
    public interface ConfigurationRetriever
    {   
        /// <summary>
        /// Returns the difficulty of the game.
        /// </summary>
        int Difficulty { get; }

        /// <summary>
        /// Returns the difficulty of the AI Player.
        /// </summary>
        int Difficulty_AI { get; }

        /// <summary>
        /// Returns the realism of the physics engine.
        /// </summary>
        float Realism { get; }

        /// <summary>
        /// Returns the KeyboardConfiguration of a player.
        /// The player is being identified by its playerID.
        /// </summary>
        /// <param name="playerID">The player's ID.</param>
        /// <returns>The KeyboardConfiguration associated with the playerID.</returns>
        KeyboardConfiguration GetKeyboardConfiguration(int playerID);
    }
}
