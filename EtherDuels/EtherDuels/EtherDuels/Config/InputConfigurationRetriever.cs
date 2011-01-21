using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace EtherDuels.Config
{  
    /// <summary>
    /// Provides methods to retrieve the current input configuration.
    /// </summary>
    public interface InputConfigurationRetriever
    {
        /// <summary>
        /// Returns the key for forward movement.
        /// </summary>
        Keys Forward
        {
            get;
        }

        /// <summary>
        /// Returns the key for turning left.
        /// </summary>
        Keys Left
        {
            get;
        }

        /// <summary>
        /// Returns the key for turning right.
        /// </summary>
        Keys Right
        {
            get;
        }

        /// <summary>
        /// Returns the key for firing a weapon.
        /// </summary>
        Keys Fire
        {
            get;
        }

        /// <summary>
        /// Returns the key for changing to the next weapon.
        /// </summary>
        Keys NextWeapon
        {
            get;
        }

        /// <summary>
        /// Returns the key for changing to the previous weapon.
        /// </summary>
        Keys PrevWeapon
        {
            get;
        }

        /// <summary>
        /// Returns the key for backward movement.
        /// </summary>
        Keys Backward
        {
            get;
        }
    }
}
