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

        public Spaceship()
        {
            this.Mass = 8000;
            this.Attack = 100;
            this.Radius = 240;
            this.Health = 100;
            this.Rotation = 0;
            this.CurrentWeapon = Weapon.Rocket;
        }

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
