using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace EtherDuels.Game.Model
{
    public class SimplePhysicsAlgorithm : Physics
    {
        private CollisionHandler collisionHandler;
        private World world;

        private WorldObject[] worldObjects;
        private WorldObject[][] oldCollisions = new WorldObject[0][];

        public SimplePhysicsAlgorithm(CollisionHandler collisionHandler, World world)
        {
            this.collisionHandler = collisionHandler;
            this.world = world;
        }

        /// <summary>
        /// Updates gravity effects, calculates the new positions of all worldObjects 
        /// and then reports all new collisions to the collisionHandler.
        /// </summary>
        /// <param name="frameState"></param>
        public override void Update(FrameState frameState)
        {
            worldObjects = world.WorldObjects;

            UpdateGravity(frameState.GetGameTime());
            UpdatePositions(frameState.GetGameTime());

            foreach (WorldObject[] collision in GetNewCollisions())
            {
                collisionHandler.OnCollision(collision[0], collision[1]);
            }
        }

        private void UpdateGravity(GameTime gameTime)
        {
            foreach (WorldObject worldObject in worldObjects)
            {
            }
        }

        private void UpdatePositions(GameTime gameTime)
        {
            foreach (WorldObject worldObject in worldObjects)
            {
                
            }
        }

        /// <summary>
        /// Detects all current collisions
        /// </summary>
        /// <returns>All current collisions</returns>
        private WorldObject[][] GetCollisions()
        {
            List<WorldObject[]> collisions = new List<WorldObject[]>();

            for (int i = 0; i < worldObjects.GetLength(0); i += 1)
            {
                WorldObject object1 = worldObjects[i];

                for (int j = i + 1; j < worldObjects.GetLength(0); j += 1)
                {
                    WorldObject object2 = worldObjects[j];

                    float distance = Vector2.Distance(object1.Position, object2.Position);
                    if (distance < object1.Radius + object2.Radius)
                    {
                        WorldObject[] collision = { object1, object2 };
                        collisions.Add(collision);
                    }
                }
            }

            return collisions.ToArray<WorldObject[]>();
        }

        /// <summary>
        /// Filters the new collisions
        /// </summary>
        /// <returns>All new collisions</returns>
        private WorldObject[][] GetNewCollisions()
        {
            WorldObject[][] collisions = GetCollisions();
            List<WorldObject[]> filteredCollisions = new List<WorldObject[]>();


            foreach (WorldObject[] collision in collisions)
            {
                bool unique = true;

                foreach (WorldObject[] oldCollision in oldCollisions)
                {
                    if ((collision[0] == oldCollision[0] && collision[1] == oldCollision[1]) 
                        || (collision[0] == oldCollision[1] && collision[1] == oldCollision[0]))
                    {
                        unique = false;
                        break;
                    }
                }

                if (unique)
                {
                    filteredCollisions.Add(collision);
                }
            }

            oldCollisions = collisions;

            return filteredCollisions.ToArray<WorldObject[]>();
        }
                        
    }
}
