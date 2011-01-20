using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtherDuels.Game.Model
{
    /// <summary>
    /// Defines a planet.
    /// </summary>
    public class Planet : WorldObject
    {
        public Planet()
        {
            isFlexible = false;
            this.Health = 1000000;
            this.Attack = 1000000;
            this.Mass = 6E24;
        }

        private bool isFlexible;
        public bool IsFlexible
        {
            get { return isFlexible; }
            set { isFlexible = value; }
        }
    }
}
