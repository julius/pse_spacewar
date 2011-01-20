using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtherDuels.Game.Model
{
    /// <summary>
    /// Defines a projectile.
    /// </summary>
    public class Projectile : WorldObject
    {
        private Weapon weapon;
        public Weapon Weapon
        {
            get { return weapon; }
            set { weapon = value; }
        }
    }
}
