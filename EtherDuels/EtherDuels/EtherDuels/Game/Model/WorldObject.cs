using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace EtherDuels.Game.Model
{
    public class WorldObject
    {
        int attack;
        int health;
        double mass;
        Vector2 position;
        float radius;
        float rotation;
        Vector2 velocity;

        public int GetAttack()
        {
            return attack;
        }

        public void SetAttack(int attack)
        {
            this.attack = attack;
        }

        public int GetHealth()
        {
            return health;
        }

        public void SetHealth(int health)
        {
            this.health = health;
        }

        public float GetRotation()
        {
            return rotation;
        }

        public void SetRotation(float rotation)
        {
            this.rotation = rotation;
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
