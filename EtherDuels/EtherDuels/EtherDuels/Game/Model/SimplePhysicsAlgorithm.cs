using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace EtherDuels.Game.Model
{
    public class SimplePhysicsAlgorithm : Physics
    {
        // TODO: find a suitable value
        private static float MAX_VELOCITY = 100.0f;

        private CollisionHandler collisionHandler;
        private World world;

        public SimplePhysicsAlgorithm(CollisionHandler collisionHandler, World world)
        {
            this.collisionHandler = collisionHandler;
            this.world = world;
        }

        public override void Update(GameTime gameTime)
        {
            worldObjects = world.WorldObjects;

            UpdateGravity(frameState.GetGameTime());
            UpdatePositions(frameState.GetGameTime());

            foreach (WorldObject worldObject in objects)
            {
            }
        }

        private void CheckCollision(WorldObject object1, WorldObject object2)
        {
	}

        /// <summary>
        /// Limits the velocity and updates the position of each worldObject.
        /// </summary>
        /// <param name="gameTime"></param>
        private void UpdatePositions(GameTime gameTime)
        {
            foreach (WorldObject worldObject in worldObjects)
            {
                Vector2 velocity = worldObject.Velocity;
                velocity.X = velocity.X > MAX_VELOCITY ? MAX_VELOCITY : velocity.X;
                velocity.Y = velocity.Y > MAX_VELOCITY ? MAX_VELOCITY : velocity.Y;

                Vector2 postion = worldObject.Position;
                postion.X += worldObject.Velocity.X * gameTime.ElapsedGameTime.Milliseconds;
                postion.Y += worldObject.Velocity.Y * gameTime.ElapsedGameTime.Milliseconds;
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
