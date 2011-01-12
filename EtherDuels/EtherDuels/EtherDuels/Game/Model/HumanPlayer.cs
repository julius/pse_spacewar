using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace EtherDuels.Game.Model
{
    public class HumanPlayer: Player
    {
        private InputConfigurationRetriever inputConfigurationRetriever;

        /// <summary>
        /// Creates a Human Player
        /// </summary>
        /// <param name="playerId">The player's ID</param>
        /// <param name="playerHandler">The player's Handler</param>
        /// <param name="inputConfigurationRetriever">The input configuration for the player</param>
        public HumanPlayer(int playerId, PlayerHandler playerHandler, InputConfigurationRetriever inputConfigurationRetriever): base(playerId, playerHandler)
        {
            this.inputConfigurationRetriever = inputConfigurationRetriever;
        }

        /// <summary>
        /// Called for every frame of the game.
        /// Computes keyboard input and moves, shoots... accordingly.
        /// </summary>
        /// <param name="frameState">frame specific state</param>
        public override void Update(FrameState frameState)
        {
            if (frameState.KeyboardState.IsKeyDown(this.inputConfigurationRetriever.FireKey))
            {
                this.playerHandler.OnFire(this.spaceship);
            }

            if (frameState.KeyboardState.IsKeyDown(this.inputConfigurationRetriever.ForwardKey))
            {
                float speed = ((float)frameState.GameTime.ElapsedGameTime.TotalMilliseconds) * 0.01f;
                Vector2 velocity = this.spaceship.Velocity;
                velocity.X += (float)Math.Sin(this.spaceship.Rotation) * speed;
                velocity.Y -= (float)Math.Cos(this.spaceship.Rotation) * speed;
                this.spaceship.Velocity = velocity;
            }

            if (frameState.KeyboardState.IsKeyDown(this.inputConfigurationRetriever.BackwardKey))
            {
                float speed = ((float)frameState.GameTime.ElapsedGameTime.TotalMilliseconds) * -0.01f;
                Vector2 velocity = this.spaceship.Velocity;
                velocity.X += (float)Math.Sin(this.spaceship.Rotation) * speed;
                velocity.Y -= (float)Math.Cos(this.spaceship.Rotation) * speed;
                this.spaceship.Velocity = velocity;
            }

            if (frameState.KeyboardState.IsKeyDown(this.inputConfigurationRetriever.LeftKey))
            {
                float speed = ((float)frameState.GameTime.ElapsedGameTime.TotalMilliseconds) * 0.01f;
                this.spaceship.Rotation = this.spaceship.Rotation + (speed * -1f);
            }

            if (frameState.KeyboardState.IsKeyDown(this.inputConfigurationRetriever.RightKey))
            {
                float speed = ((float)frameState.GameTime.ElapsedGameTime.TotalMilliseconds) * 0.01f;
                this.spaceship.Rotation = this.spaceship.Rotation + (speed * 1f);
            }
        }
    }
}
