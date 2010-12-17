using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtherDuels.Game.Model
{
    class World
    {
        WorldObject[] worldObjects;

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
