using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtherDuels.Game.Model
{
    /// <summary>
    /// Defines an explosion in a game.
    /// </summary>
    public class Explosion : WorldObject
    {
        TimeSpan creationTime;

        /// <summary>
        /// Gets and sets the creation time of an explosion.
        /// </summary>
        public TimeSpan CreationTime
        {
            get { return creationTime; }
            set { creationTime = value; }
        }
    }
}
