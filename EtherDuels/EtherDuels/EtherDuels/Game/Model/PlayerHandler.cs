using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtherDuels.Game.Model
{
    interface PlayerHandler
    {
        /// <summary>
        /// Called by Players, when they want to shoot.
        /// </summary>
        /// <param name="shooter">The player's ship.</param>
        void OnFire(Spaceship shooter);
    }
}
