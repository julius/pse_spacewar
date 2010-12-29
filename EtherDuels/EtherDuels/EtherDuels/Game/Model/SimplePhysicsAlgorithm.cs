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

        private WorldObject[][] oldCollisions = new WorldObject[0][];

        public SimplePhysicsAlgorithm(CollisionHandler collisionHandler, World world)
        {
            this.collisionHandler = collisionHandler;
            this.world = world;
        }

        public override void Update(FrameState frameState)
        {
            WorldObject[] objects = world.GetWorldObjects();

            foreach (WorldObject worldObject in objects)
            {
            }
        }

        /// <summary>
        /// Detects all current collisions
        /// </summary>
        /// <returns>All current collisions</returns>
        private WorldObject[][] GetCollisions()
        {
            WorldObject[] objects = world.GetWorldObjects();
            List<WorldObject[]> collisions = new List<WorldObject[]>();

            for (int i = 0; i < objects.GetLength(0); i += 1)
            {
                WorldObject object1 = objects[i];

                for (int j = i + 1; j < objects.GetLength(0); j += 1)
                {
                    WorldObject object2 = objects[j];

                    float distance = Vector2.Distance(object1.GetPosition(), object2.GetPosition());
                    if (distance < object1.GetRadius() + object2.GetRadius())
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
