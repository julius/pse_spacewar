using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace EtherDuels.Game.Model
{
    public interface InputConfigurationRetriever
    {
        /// <summary>
        /// Gets key for backward movement.
        /// </summary>
        /// <returns>The requested key.</returns>
        Keys GetBackwardKey();

        /// <summary>
        /// Gets key for forward movement.
        /// </summary>
        /// <returns>The requested key.</returns>
        Keys GetForwardKey();

        /// <summary>
        /// Gets key for turning left.
        /// </summary>
        /// <returns>The requested key.</returns>
        Keys GetLeftKey();

        /// <summary>
        /// Gets key for turning right.
        /// </summary>
        /// <returns>The requested key.</returns>
        Keys GetRightKey();

        /// <summary>
        /// Gets key to fire weapon.
        /// </summary>
        /// <returns>The requested key.</returns>
        Keys GetFireKey();

        /// <summary>
        /// Gets key for selecting the next weapon.
        /// </summary>
        /// <returns>The requested key.</returns>
        Keys GetNextWeaponKey();

        /// <summary>
        /// Gets key for selecting the previous weapon.
        /// </summary>
        /// <returns>The requested key.</returns>
        Keys GetPrevWeaponKey();
    }
}
