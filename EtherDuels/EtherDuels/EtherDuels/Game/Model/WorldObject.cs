using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace EtherDuels.Game.Model
{
    /// <summary>
    /// Defines an object in the world.
    /// </summary>
    public class WorldObject
    {
        int attack;
        int health;
        double mass;
        Vector2 position;
        float radius;
        float rotation;
        Vector2 velocity;

        public WorldObject()
        {
            health = 100;
        }

        /// <summary>
        /// Gets and sets the attackpower of a WorldObject.
        /// </summary>
        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }        

        /// <summary>
        /// Gets and sets the health of a Worldobject.
        /// </summary>
        public int Health
        {
            get { return health; }
            set { health = value; }
        }        

        /// <summary>
        /// Gets and sets the mass of a WorldObject.
        /// </summary>
        public double Mass
        {
            get { return mass; }
            set { mass = value; }
        }

        /// <summary>
        /// Gets and sets the radius a WorldObject has.
        /// </summary>
        public float Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        /// <summary>
        /// Gets and sets the rotation of a WorldObject.
        /// </summary>
        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        /// <summary>
        /// Gets and sets the posizion of a WorldObject in the world.
        /// </summary>
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        /// <summary>
        /// Gets and sets the velocity of a WorldObject.
        /// </summary>
        public Vector2 Velocity 
        {
            get { return velocity; }
            set { velocity = value; }
        }
    }
}
