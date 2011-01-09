using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace EtherDuels.Game.Model
{
    public class World
    {
        private List<WorldObject> worldObjects = new List<WorldObject>();
        private Planet planet;

        public World(List<WorldObject> worldObjects, Planet planet)
        {
            this.worldObjects = worldObjects;
            this.planet = planet;
        }

        public WorldObject[] WorldObjects
        {
            get { return worldObjects.ToArray<WorldObject>(); }
        }

        public void AddWorldObject(WorldObject worldObject)
        {
            worldObjects.Add(worldObject);
        }

        public void RemoveWorldObject(WorldObject worldObject)
        {
            worldObjects.Remove(worldObject);
        }

        public Planet Planet
        {
            get { return planet; }
        }
    }
}
