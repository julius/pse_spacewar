﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using EtherDuels.Config;

namespace EtherDuels.Game.Model
{   
    /// <summary>
    /// Defines a concrete physics algorithm.
    /// It provides methods to update the world objects' positions depending on a simple
    /// physics algorithm, which only contains gravity and the difficulty level.
    /// </summary>
    public class SimplePhysicsAlgorithm : Physics
    {
        private const float MAX_VELOCITY = 299792458.0f;
        private CollisionHandler collisionHandler;
        private ConfigurationRetriever configRetriever;
        private World world;
        private int difficulty;

        private WorldObject[] worldObjects;
        private WorldObject[][] oldCollisions = new WorldObject[0][];

        /// <summary>
        /// Creates a new SimplePhysicsAlgorithm object.
        /// </summary>
        /// <param name="collisionHandler">The assigned CollisionHandler which will be informed about collisions.</param>
        /// <param name="world">The assigned World whose objects are to be updated.</param>
        public SimplePhysicsAlgorithm(CollisionHandler collisionHandler, World world, ConfigurationRetriever configRetriever)
        {
            this.collisionHandler = collisionHandler;
            this.world = world;
            this.configRetriever = configRetriever;
            this.difficulty = 0;
        }

        /// <summary>
        /// Updates gravity effects, calculates the new positions of all world objects 
        /// and then reports all new collisions to the collisionHandler.
        /// </summary>
        /// <param name="gameTime">The GameTime which contains how much time has passed since the last update.</param>
        public void Update(GameTime gameTime)
        {
            worldObjects = world.WorldObjects;

            if (difficulty != configRetriever.Difficulty)
            {
                difficulty = configRetriever.Difficulty;
                UpdateDifficulty();
            }

            UpdateExplosions(gameTime);

            GameTime reducedGameTime = new GameTime(gameTime.TotalGameTime, new TimeSpan(0, 0, 0, 0, 1));
            TimeSpan countingTimeSpan = new TimeSpan(0, 0, 0, 0, 0);
            while (countingTimeSpan < gameTime.ElapsedGameTime)
            {
                countingTimeSpan += reducedGameTime.ElapsedGameTime;
                UpdateGravity(reducedGameTime);
                UpdatePositions(reducedGameTime);
            }
           

            foreach (Planet planet in world.Planets)
            {
                planet.Rotation += 0.0005f;
            }

            foreach (WorldObject[] collision in GetNewCollisions())
            {
                collisionHandler.OnCollision(collision[0], collision[1]);
            }
        }

       

        // Applies the gravity of the planets and spaceships to all other world objects and updates their velocities.
        private void UpdateGravity(GameTime gameTime)
        {
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
                                
                                // adapt velocity of projectiles to menu settings (difficulty is being disregarded for projectiles, so that it's still fun to play)
                                if (worldObjects[j] is Projectile)
                                {
                                    worldObjects[j].Velocity += Vector2.Divide(velocityVector, GameAssets.N * configRetriever.Realism);
                                }
                                else
                                {
                                    worldObjects[j].Velocity += Vector2.Divide(velocityVector, GameAssets.N * difficulty);
                                }
                            }
                        }
                    }
                }                
            }
        }

        // Limits the total velocity and updates the position of each worldObject.
        private void UpdatePositions(GameTime gameTime)
        {
            foreach (WorldObject worldObject in worldObjects)
            {
                // limit velocities
                Vector2 velocity = worldObject.Velocity;
                if (velocity.Length() > MAX_VELOCITY)
                {
                    velocity.Normalize();
                    velocity *= MAX_VELOCITY;
                    worldObject.Velocity = velocity;
                }

                // calculate new positions
                Vector2 postion = worldObject.Position;
                postion.X += worldObject.Velocity.X * (float)gameTime.ElapsedGameTime.TotalMilliseconds * 0.01f;
                postion.Y += worldObject.Velocity.Y * (float)gameTime.ElapsedGameTime.TotalMilliseconds * 0.01f;

                // torodial field
                postion.X = postion.X > GameAssets.rightFieldBoundary ? GameAssets.leftFieldBoundary : postion.X;
                postion.Y = postion.Y > GameAssets.lowerFieldBoundary ? GameAssets.upperFieldBoundary : postion.Y;
                postion.X = postion.X < GameAssets.leftFieldBoundary ? GameAssets.rightFieldBoundary : postion.X;
                postion.Y = postion.Y < GameAssets.upperFieldBoundary ? GameAssets.lowerFieldBoundary : postion.Y;
                
                worldObject.Position = postion;
            }
        }

        private void UpdateExplosions(GameTime gameTime)
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
            }
        }
        
        // Applies the effect that a changed difficulty level has on world objects.
        private void UpdateDifficulty()
        {
            /* A new difficulty level means stronger/weaker gravity. For most world objects this effect
             * is being handled in UpdateGravity(), but there are planets which circle in the orbit of other
             * planets and their velocities need to be readjusted to prevent these planets from leaving the orbit.
             * */            
            foreach (Planet planet in world.Planets)
            {
                if (planet.IsFlexible)
                {
                    // find the planet that this one is most attracted to
                    // default values
                    float highestAcceleration = 0;
                    Planet mostAttractivePlanet = planet;
                    Vector2 distance = new Vector2(1, 1);

                    foreach (Planet planet2 in world.Planets)
                    {
                        Vector2 distanceToPlanet = new Vector2(planet2.Position.X - planet.Position.X, planet2.Position.Y - planet.Position.Y);
                        if (distanceToPlanet.Length() != 0)
                        {
                            float acceleration = ((float)(GameAssets.G * planet2.Mass / distanceToPlanet.LengthSquared()));
                            if (acceleration > highestAcceleration)
                            {
                                highestAcceleration = acceleration;
                                mostAttractivePlanet = planet2;
                                distance = distanceToPlanet;
                            }
                        }
                    }

                    // calculate the velocity needed for orbiting this planet with the given distance.
                    float planetVelocity = (float) Math.Sqrt(mostAttractivePlanet.Mass * GameAssets.G / distance.Length() / (GameAssets.N * 1000 * difficulty));
                    distance.Normalize();
                    Vector2 newVelocity = new Vector2(distance.Y, -distance.X);
                    planet.Velocity = Vector2.Multiply(newVelocity, planetVelocity);
                }
            }
        }

        // Detects all current collisions.
        private WorldObject[][] GetCollisions()
        {
            List<WorldObject[]> collisions = new List<WorldObject[]>();

            for (int i = 0; i < worldObjects.GetLength(0); i += 1)
            {
                WorldObject object1 = worldObjects[i];
                if (!(object1 is Explosion))
                {
                    for (int j = i + 1; j < worldObjects.GetLength(0); j += 1)
                    {   
                        WorldObject object2 = worldObjects[j];
                        if (!(object2 is Explosion))
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

        // Filters the new collisions.
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
