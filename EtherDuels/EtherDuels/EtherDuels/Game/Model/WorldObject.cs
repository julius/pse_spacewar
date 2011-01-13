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

        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }        

        public int Health
        {
            get { return health; }
            set { health = value; }
        }        

        public double Mass
        {
            get { return mass; }
            set { mass = value; }
        }

        public float Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Vector2 Velocity 
        {
            get { return velocity; }
            set { velocity = value; }
        }
    }
}
