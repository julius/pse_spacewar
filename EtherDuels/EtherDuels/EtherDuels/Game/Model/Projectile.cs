using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace EtherDuels.Game.Model
{
    /// <summary>
    /// Defines a projectile.
    /// </summary>
    public class Projectile : WorldObject
    {
        public Projectile()
        {
            this.Mass = 300;
            this.Radius = 20;
            this.Rotation = 0;
            this.Position = new Vector2(0, 0);
            this.Velocity = new Vector2(0,0);
        }

        private Weapon weapon;
        public Weapon Weapon
        {
            get { return weapon; }
            set { weapon = value; }
        }
    }
}
