using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;


namespace EtherDuels.Game.Model
{   
    /// <summary>
    /// Defines a concrete Physics.
    /// It provides methods to update the WorldObjects positions depending on a simple
    /// physics, which just contains gravity.
    /// </summary>
    public class SimplePhysicsAlgorithm : Physics
    {
        // TODO: speed of light in m/s, should be set to a more reasonable value
        private static float MAX_VELOCITY = 299792458.0f;
        // gravitational constant
        private static double G = 6.67428E-11;

        private CollisionHandler collisionHandler;
        private World world;

        private WorldObject[] worldObjects;
        private WorldObject[][] oldCollisions = new WorldObject[0][];

        /// <summary>
        /// Creates a new SimplePhysicsAlgorithm object.
        /// </summary>
        /// <param name="collisionHandler">The assigned CollisionHandler, which is to inform.</param>
        /// <param name="world">The assigned World, whose objects are to update.</param>
        public SimplePhysicsAlgorithm(CollisionHandler collisionHandler, World world)
        {
            this.collisionHandler = collisionHandler;
            this.world = world;
        }

        /// <summary>
        /// Updates gravity effects, calculates the new positions of all worldObjects 
        /// and then reports all new collisions to the collisionHandler.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            worldObjects = world.WorldObjects;

            UpdateGravity(gameTime);
            UpdatePositions(gameTime);

            foreach (WorldObject[] collision in GetNewCollisions())
            {
                collisionHandler.OnCollision(collision[0], collision[1]);
            }
        }

        /// <summary>
        /// Applies the gravity of the Planet to all other worldObjects and updates their velocities.
        /// </summary>
        /// <param name="gameTime"></param>
        private void UpdateGravity(GameTime gameTime)
        {
            foreach (WorldObject worldObject in worldObjects)
            {
                // f = m * a
                // f = G * m / r^2
                // m_object * a = G * m_planet / r^2
                // a = (G * m_planet / r^2) / m_object

                Vector2 distanceVector = new Vector2(world.Planet.Position.X - worldObject.Position.X, 
                    world.Planet.Position.Y - worldObject.Position.Y);
                double velocityDiff = ((G * world.Planet.Mass / distanceVector.LengthSquared()) / worldObject.Mass) * gameTime.ElapsedGameTime.TotalMilliseconds;
                // angle of the velocity
                double angle = Math.Asin(distanceVector.Y / distanceVector.Length());

                Vector2 objVelocity = worldObject.Velocity;
                objVelocity.X += (float) (Math.Cos(angle) * velocityDiff);
                objVelocity.Y += (float)(Math.Sin(angle) * velocityDiff);
            }
        }

        /// <summary>
        /// Limits the velocity and updates the position of each worldObject.
        /// </summary>
        /// <param name="gameTime"></param>
        private void UpdatePositions(GameTime gameTime)
        {
            foreach (WorldObject worldObject in worldObjects)
            {
                if (worldObject is Explosion)
                {   
                    // deleting explosions after a certain amount of time
                    if ((gameTime.TotalGameTime.TotalMilliseconds - (worldObject as Explosion).CreationTime.TotalMilliseconds) > 100)
                    {
                        worldObject.Health = 0;
                        world.RemoveWorldObject(worldObject);
                    }
                }
                    // limit velocities
                    // TODO: check if the resulting velocity is higher than MAX_VELOCITY - does this make sense?
                    Vector2 velocity = worldObject.Velocity;
                    velocity.X = velocity.X > MAX_VELOCITY ? MAX_VELOCITY : velocity.X;
                    velocity.Y = velocity.Y > MAX_VELOCITY ? MAX_VELOCITY : velocity.Y;

                    // calculate new positions
                    Vector2 postion = worldObject.Position;
                    postion.X += worldObject.Velocity.X * (float)gameTime.ElapsedGameTime.TotalMilliseconds * 0.01f;
                    postion.Y += worldObject.Velocity.Y * (float)gameTime.ElapsedGameTime.TotalMilliseconds * 0.01f;

                    // torodial field
                    postion.X = postion.X > 3600 ? -3600 : postion.X;
                    postion.Y = postion.Y > 2400 ? -2400 : postion.Y;
                    postion.X = postion.X < -3600 ? 3600 : postion.X;
                    postion.Y = postion.Y < -2400 ? 2400 : postion.Y;

                    worldObject.Position = postion;
                
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

                //TODO: edit claudi: explosionen sollen nicht kollidieren. hab das jetz ma provisorisch gemacht. gibs ein "is not"?
                if (object1 is Explosion) { }
                else
                {

                    for (int j = i + 1; j < worldObjects.GetLength(0); j += 1)
                    {   
                        WorldObject object2 = worldObjects[j];

                        //TODO: edit claudi: hier auch
                        if (object2 is Explosion) { }
                        else
                        {

                            float distance = Vector2.Distance(object1.Position, object2.Position);
                            if (distance < object1.Radius + object2.Radius)
                            {
                                WorldObject[] collision = { object1, object2 };
                                collisions.Add(collision);
                            }
                        }
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
