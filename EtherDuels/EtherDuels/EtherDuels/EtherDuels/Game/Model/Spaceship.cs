using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtherDuels.Game.Model
{
    /// <summary>
    /// Defines a spaceship.
    /// </summary>
    public class Spaceship : WorldObject
    {
        Weapon currentWeapon;

        /// <summary>
        /// Gets and sets the current weapon the 
        /// spaceship can fire.
        /// </summary>
        public Weapon CurrentWeapon
        {
            get { return currentWeapon; }
            set { currentWeapon = value; }
        }
    }
}
