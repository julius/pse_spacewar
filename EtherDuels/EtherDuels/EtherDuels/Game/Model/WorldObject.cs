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

        public double GetMass()
        {
            return mass;
        }

        public void SetMass(double mass)
        {
            this.mass = mass;
        }

        public Vector2 GetPosition()
        {
            return position;
        }

        public void SetPosition(Vector2 position)
        {
            this.position = position;
        }

        public float GetRadius()
        {
            return radius;
        }

        public void SetRadius(float radius)
        {
            this.radius = radius;
        }

        public float GetRotation()
        {
            return rotation;
        }

        public void SetRotation(float rotation)
        {
            this.rotation = rotation;
        }

        public Vector2 GetVeloctiy()
        {
            return velocity;
        }

        public void SetVelocity(Vector2 velocity)
        {
            this.velocity = velocity;
        }

        //TODO: Properties
        public object Radius { get; set; }

        public Vector2 Position { get; set; }
    }
}
