using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtherDuels.Game.Model
{
    public class World
    {
        WorldObject[] worldObjects;

        // TODO initialize this.worldObjects (eg. with a constructor)

        public void AddWorldObject(WorldObject worldObject)
        {
            int numberOfObjects = worldObjects.Length;

        }

        public WorldObject[] GetWorldObjects()
        {
            return worldObjects;
        }

        public void RemoveWorldObject(WorldObject worldObject)
        {
        }

    }
}
