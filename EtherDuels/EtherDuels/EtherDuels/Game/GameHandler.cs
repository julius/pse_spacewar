using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtherDuels.Game
{   
    /// <summary>
    /// Provides methods to communicate with a higher layer of the game.
    /// </summary>
    public interface GameHandler
    {
        /// <summary>
        /// Defines the behavior of the program if the game was paused.
        /// </summary>
        void OnGamePaused();

        /// <summary>
        /// Defines the behavior of the program if the game has ended. 
        /// </summary>
        /// <param name="playerID">The playerID of the player who won.</param>
        void OnGameEnded(int playerID);
    }
}
