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
        // TODO: static oder const für konstanten?
        private static float MAX_VELOCITY = 299792458.0f;
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

            foreach (Planet planet in world.Planets)
            {
                planet.Rotation += 0.005f;
                System.Console.Write(planet.Position + "\n");
            }

            foreach (WorldObject[] collision in GetNewCollisions())
            {
                collisionHandler.OnCollision(collision[0], collision[1]);
            }
        }

        /// <summary>
        /// Applies the gravity of the planets and spaceships to all other worldObjects and updates their velocities.
        /// </summary>
        /// <param name="gameTime"></param>
        private void UpdateGravity(GameTime gameTime)
        {
            //TODO: funktioniert bisher nur wenn der Planet als erstes in der liste steht. Das korrigier ich aber noch.
            for (int i = 0; i < worldObjects.Length; i++)
            {
                if (worldObjects[i] is Planet || worldObjects[i] is Spaceship)
                {
                    for (int j = 0; j < worldObjects.Length; j++)
                    {
                        /* 
                         * physics annotation: 
                         * m: meter
                         * s: seconds
                         * kg: kilogram
                         * 
                         * F: gravitational force in Newton = kg * m / s^2
                         * G: gravitational constant in m^3 / kg / s^2
                         * mass1: mass of the first object in kg
                         * mass2: mass of the second object in kg
                         * a : acceleration in m / s^2
                         * r: distance vector between the two objects
                         * v: velocity vector
                         * t: time in seconds
                         * 
                         * F = G * mass1 * mass2 / r^2
                         * F = a * mass2 => a = F / mass2 = G * mass1 / r^2
                         * v = a * t in m / s
                         */
                        
                        // planets should not be influenced by gravity if they are not set to flexible
                        if (!(worldObjects[j] is Planet && (worldObjects[j] as Planet).IsFlexible == false))
                        {
                            Vector2 distance = new Vector2(worldObjects[i].Position.X - worldObjects[j].Position.X, worldObjects[i].Position.Y - worldObjects[j].Position.Y);
                            // avoid dividing by zero(meaning the two objects are either the same or already collided)
                            if (distance.Length() != 0)
                            {
                                float acceleration = ((float)(GameAssets.G * worldObjects[i].Mass / distance.LengthSquared()));
                                distance.Normalize();
                                Vector2 accelerationVector = Vector2.Multiply(distance, acceleration);
                                Vector2 velocityVector = Vector2.Multiply(accelerationVector, 0.01f * (float)gameTime.ElapsedGameTime.TotalSeconds);
                                worldObjects[j].Velocity += Vector2.Divide(velocityVector, GameAssets.N);
                            }
                        }
                    }
                }                
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
                    worldObject.Velocity = velocity;

                    // calculate new positions
                    Vector2 postion = worldObject.Position;
                    postion.X += worldObject.Velocity.X * (float)gameTime.ElapsedGameTime.TotalMilliseconds * 0.01f;
                    postion.Y += worldObject.Velocity.Y * (float)gameTime.ElapsedGameTime.TotalMilliseconds * 0.01f;

                    // torodial field
                    postion.X = postion.X > 3300 ? -2800 : postion.X;
                    postion.Y = postion.Y > 2400 ? -2000 : postion.Y;
                    postion.X = postion.X < -3300 ? 2800 : postion.X;
                    postion.Y = postion.Y < -2400 ? 2000 : postion.Y;

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
