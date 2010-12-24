using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace EtherDuels.Game.Model
{
    public class World
    {
        //WorldObject[] worldObjects;
        ArrayList worldObjects;

        public World(ArrayList worldObjects)
        {
            this.worldObjects = worldObjects;
        }

        public void AddWorldObject(WorldObject worldObject)
        {
            worldObjects.Add(worldObject);
        }

        public ArrayList GetWorldObjects()
        {
            return worldObjects;
        }

        public void RemoveWorldObject(WorldObject worldObject)
        {
            worldObjects.Remove(worldObject);
        }

    }
}
