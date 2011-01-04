using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace EtherDuels.Game.Model
{
    public class World
    {
        List<WorldObject> worldObjects = new List<WorldObject>();

        public World(List<WorldObject> worldObjects)
        {
            this.worldObjects = worldObjects;
        }

        public void AddWorldObject(WorldObject worldObject)
        {
            worldObjects.Add(worldObject);
        }

        public WorldObject[] GetWorldObjects()
        {
            return worldObjects.ToArray<WorldObject>();
        }

        public void RemoveWorldObject(WorldObject worldObject)
        {
            worldObjects.Remove(worldObject);
        }

    }
}
