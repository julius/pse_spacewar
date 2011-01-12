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

        public TimeSpan CreationTime
        {
            get { return creationTime; }
            set { creationTime = value; }
        }
    }
}
