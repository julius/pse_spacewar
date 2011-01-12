using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace EtherDuels.Game.Model
{
    public class World
    {
        private List<WorldObject> worldObjects;
        private Planet planet;

        public World(WorldObject[] worldObjects, Planet planet)
        {
            this.worldObjects = new List<WorldObject>(worldObjects);
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
