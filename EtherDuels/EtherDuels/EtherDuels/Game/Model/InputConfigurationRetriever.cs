using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace EtherDuels.Game.Model
{  
    /// <summary>
    /// Provides methods to retrieve the current InputConfiguration.
    /// </summary>
    public interface InputConfigurationRetriever
    {
        /// <summary>
        /// Gets the key for forward movement.
        /// </summary>
        Keys ForwardKey
        {
            get;
        }

        /// <summary>
        /// Gets the key for turning left.
        /// </summary>
        Keys LeftKey
        {
            get;
        }

        /// <summary>
        /// Gets the key for turning right.
        /// </summary>
        Keys RightKey
        {
            get;
        }

        /// <summary>
        /// Gets the key for firing a weapon.
        /// </summary>
        Keys FireKey
        {
            get;
        }

        /// <summary>
        /// Gets the key for changing to the next weapon.
        /// </summary>
        Keys NextWeaponKey
        {
            get;
        }

        /// <summary>
        /// Gets the key for changing to the previous weapon.
        /// </summary>
        Keys PrevWeaponKey
        {
            get;
        }

        /// <summary>
        /// Gets the key for backward movement.
        /// </summary>
        Keys BackwardKey
        {
            get;
        }

       
    }
}
