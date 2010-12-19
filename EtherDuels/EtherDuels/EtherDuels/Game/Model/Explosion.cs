using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtherDuels.Game.Model
{
    public class Explosion : WorldObject
    {
        TimeSpan creationTime;

        public TimeSpan GetCreationTime()
        {
            return creationTime;
        }

        public void SetCreationTime(TimeSpan creationTime)
        {
            this.creationTime = creationTime;
        }
    }
}
