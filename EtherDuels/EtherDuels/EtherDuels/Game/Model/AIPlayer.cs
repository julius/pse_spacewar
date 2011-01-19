using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using EtherDuels.Config;

namespace EtherDuels.Game.Model
{
    class AIPlayer : Player
    {
        private InputConfigurationRetriever inputConfigurationRetriever;
        private World world;
        private Planet planet;
        private GameTime gameTime;

        private Vector2 actualDistance;
        private float desiredDistance;
        private static double G = 6.67428E-11;
        private static float N = 100000;

        public AIPlayer(int playerId, PlayerHandler playerHandler, Color playerColor, World world) : base(playerId, playerHandler, playerColor)
        {
            this.world = world;
            planet = world.Planets[0];
            desiredDistance = planet.Radius * 1.5f;
        }

        public override void Update(FrameState frameState)
        {
            gameTime = frameState.GameTime;
            actualDistance = new Vector2(spaceship.Position.X - planet.Position.X, spaceship.Position.Y - planet.Position.Y);
            
        }

        private void UpdateVelocity()
        {
            float distaceDiff = desiredDistance - actualDistance.Length();
            spaceship.Velocity.Normalize();
        }

        private Vector2 ReckonGravity()
        {
            Vector2 distance = new Vector2(actualDistance.X, actualDistance.Y);
            if (distance.Length() != 0)
            {
                float acceleration = ((float)(G * planet.Mass / distance.LengthSquared()));
                distance.Normalize();
                Vector2 accelerationVector = Vector2.Multiply(distance, acceleration);
                Vector2 velocityVector = Vector2.Multiply(accelerationVector, 0.01f * (float)gameTime.ElapsedGameTime.TotalSeconds);
                 Vector2.Divide(velocityVector, N);
            }

            return Vector2.One;
        }
    }
}
