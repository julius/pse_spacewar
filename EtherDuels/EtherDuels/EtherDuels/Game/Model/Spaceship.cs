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

        public Weapon CurrentWeapon
        {
            get { return currentWeapon; }
            set { currentWeapon = value; }
        }
    }
}
