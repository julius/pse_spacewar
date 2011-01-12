using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace EtherDuels.Game.Model
{
    /// <summary>
    /// Defines the world in a game.
    /// </summary>
    public class World
    {
        List<WorldObject> worldObjects = new List<WorldObject>();

        private Planet planet;

        /// <summary>
        /// Creates a new World object.
        /// </summary>
        /// <param name="worldObjects">A list of WorldObjects, the world 
        /// contains in the beginning of a game.</param>
        /// <param name="planet">The planet the ships circuit.</param>
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
