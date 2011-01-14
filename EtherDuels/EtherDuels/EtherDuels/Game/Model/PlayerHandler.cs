using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtherDuels.Game.Model
{   
    /// <summary>
    /// Provides a method to communicate with a higher layer in the game.
    /// </summary>
    public interface PlayerHandler
    {
        /// <summary>
        /// Called by Players, when they want to shoot.
        /// It defines the reaction of the game to shooting.
        /// </summary>
        /// <param name="shooter">The player's ship.</param>
        void OnFire(Spaceship shooter);
    }
}
