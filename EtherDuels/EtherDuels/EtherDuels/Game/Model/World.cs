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
        private List<WorldObject> worldObjects;
        private Planet planet;

        /// <summary>
        /// Creates a new World object.
        /// </summary>
        /// <param name="worldObjects">A list of WorldObjects the world 
        /// contains at the beginning of a game.</param>
        /// <param name="planet">The planet the ships circuit.</param>
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
            if (worldObject == null)
            {
                throw new System.ArgumentException("Parameter cannot be null", "worldObject");
            }

            worldObjects.Add(worldObject);
        }

        public void RemoveWorldObject(WorldObject worldObject)
        {
            if (worldObject == null)
            {
                throw new System.ArgumentException("Parameter cannot be null", "worldObject");
            }

            worldObjects.Remove(worldObject);
        }

        public Planet Planet
        {
            get { return planet; }
        }
    }
}
