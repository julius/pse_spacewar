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
        /// Defines the behaviour of the program if the game was paused.
        /// </summary>
        void OnGamePaused();

        /// <summary>
        /// Defines the behaviour of the program if the game is ended. 
        /// </summary>
        /// <param name="playerID">The playerID of the player who won.</param>
        /// <param name="points">The players points.</param>
        void OnGameEnded(int playerID, int points);
    }
}
