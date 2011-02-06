using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtherDuels.Menu
{
    /// <summary>
    /// Provides methods to communicate with a higher layer of the game.
    /// </summary>
    public interface MenuHandler
    {
        /// <summary>
        /// Creates a new game.
        /// </summary>
        void OnNewGame();

        /// <summary>
        /// Quits the program.
        /// </summary>
        void OnQuitProgram();

        /// <summary>
        /// Resumes the game.
        /// </summary>
        void OnResumeGame();
    }
}
