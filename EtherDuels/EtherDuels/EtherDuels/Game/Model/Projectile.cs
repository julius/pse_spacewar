using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace EtherDuels.Game.Model
{
    /// <summary>
    /// A projectile is a world object which belongs to a weapon and a shooter.
    /// Its attack value and its velocity depend on the respective weapon.
    /// </summary>
    public class Projectile : WorldObject
    {
        /// <summary>
        /// The constructor of a projectile which sets a couple of default values.
        /// </summary>
        public Projectile()
        {
            this.Mass = 300;
            this.Radius = 40;
            this.Rotation = 0;
            this.Position = new Vector2(0, 0);
            this.Velocity = new Vector2(0,0);
        }

        /// <summary>
        /// Gets and sets the shooting spaceship.
        /// </summary>
        private Spaceship shooter;
        public Spaceship Shooter
        {
            get { return shooter; }
            set { shooter = value; }
        }

        /// <summary>
        /// Gets and sets the respective weapon.
        /// </summary>
        private Weapon weapon;
        public Weapon Weapon
        {
            get { return weapon; }
            set { weapon = value; }
        }
    }
}
