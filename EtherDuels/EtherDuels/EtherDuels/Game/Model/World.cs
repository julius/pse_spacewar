using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace EtherDuels.Game.Model
{
    /// <summary>
    /// Defines the world in a game which contains all world objects.
    /// </summary>
    public class World
    {
        private List<WorldObject> worldObjects;

        /// <summary>
        /// Creates a new World.
        /// </summary>
        /// <param name="worldObjects">A list of world objects the world contains at the beginning of a game.</param>
        public World(WorldObject[] worldObjects)
        {
            this.worldObjects = new List<WorldObject>(worldObjects);
        }

        //TODO: schöner?
        /// <summary>
        /// Needed for testing.
        /// </summary>
        public World()
        {
            this.worldObjects = new List<WorldObject>();
        }

        /// <summary>
        /// Returns an array of all the world objects that exist in the world at this moment.
        /// </summary>
        virtual public WorldObject[] WorldObjects
        {
            get { return worldObjects.ToArray<WorldObject>(); }
        }

        /// <summary>
        /// Adds a world object to the world.
        /// </summary>
        /// <param name="worldObject">The WorldObject which needs to be added.</param>
        virtual public void AddWorldObject(WorldObject worldObject)
        {
            if (worldObject == null)
            {
                throw new System.ArgumentException("Parameter cannot be null", "worldObject");
            }

            worldObjects.Add(worldObject);
        }

        /// <summary>
        /// Removes a world object from the world.
        /// </summary>
        /// <param name="worldObject">The WorldObject which is to be remove.</param>
        virtual public void RemoveWorldObject(WorldObject worldObject)
        {
            if (worldObject == null)
            {
                throw new System.ArgumentException("Parameter cannot be null", "worldObject");
            }

            worldObjects.Remove(worldObject);
        }

        /// <summary>
        /// Returns all world objects which are planets.
        /// </summary>
        public Planet[] Planets
        {
            get
            {
                List<Planet> planets = new List<Planet>();
                foreach (WorldObject worldObject in this.worldObjects)
                {
                    if (worldObject is Planet)
                    {
                        planets.Add((Planet)worldObject);
                    }
                }
                return planets.ToArray();
            }
        }
    }
}
