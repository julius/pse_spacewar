using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtherDuels.Game.Model
{
    /// <summary>
    /// A planet is a world object which is nearly undestroyable. There are two types of planets:
    /// those that are being influenced by other planets' gravitational force and those that are not.
    /// </summary>
    public class Planet : WorldObject
    {
        /// <summary>
        /// The constructor of a planet which sets a couple of default values.
        /// </summary>
        public Planet()
        {
            isFlexible = false;
            this.Health = 1000000;
            this.Attack = 1000000;
            this.Mass = 6E24;
        }

        /// <summary>
        /// Gets and sets whether the planet should react to other planets' gravitational force.
        /// </summary>
        private bool isFlexible;
        public bool IsFlexible
        {
            get { return isFlexible; }
            set { isFlexible = value; }
        }
    }
}
