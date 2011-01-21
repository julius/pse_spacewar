using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtherDuels.Game.Model
{
    /// <summary>
    /// A spaceship is a world object which can move freely and which contains a weapon to fire.
    /// </summary>
    public class Spaceship : WorldObject
    {
        private Weapon currentWeapon;

        /// <summary>
        /// The constructor of a spaceship which sets a couple of default values.
        /// </summary>
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
        /// Gets and sets the current weapon with which the spaceship can fire.
        /// </summary>
        public Weapon CurrentWeapon
        {
            get { return currentWeapon; }
            set { currentWeapon = value; }
        }
    }
}
