using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace EtherDuels.Game.Model
{   
    /// <summary>
    /// Defines the reaction to the human player's input.
    /// </summary>
    public class HumanPlayer: Player
    {
        private InputConfigurationRetriever inputConfigurationRetriever;

        /// <summary>
        /// Creates a Human Player.
        /// </summary>
        /// <param name="playerId">The player's ID.</param>
        /// <param name="playerHandler">The player's Handler.</param>
        /// <param name="inputConfigurationRetriever">The input configuration for the player.</param>
        public HumanPlayer(int playerId, PlayerHandler playerHandler, Game.Model.InputConfigurationRetriever inputConfigurationRetriever)
            : base(playerId, playerHandler)
        {
            this.inputConfigurationRetriever = inputConfigurationRetriever;
        }

        /// <summary>
        /// Called for every frame of the game.
        /// Computes keyboard input and moves, shoots... accordingly.
        /// </summary>
        /// <param name="frameState">frame specific state.</param>
        public override void Update(FrameState frameState)
        {
            if (frameState.KeyboardState.IsKeyDown(this.inputConfigurationRetriever.Fire))
            {
                this.playerHandler.OnFire(this.spaceship);
            }

            if (frameState.KeyboardState.IsKeyDown(this.inputConfigurationRetriever.Forward))
            {
                float speed = ((float)frameState.GameTime.ElapsedGameTime.TotalMilliseconds) * 0.1f;
                Vector2 velocity = this.spaceship.Velocity;
                velocity.X += (float)Math.Sin(this.spaceship.Rotation) * speed;
                velocity.Y -= (float)Math.Cos(this.spaceship.Rotation) * speed;
                this.spaceship.Velocity = velocity;
            }

            if (frameState.KeyboardState.IsKeyDown(this.inputConfigurationRetriever.Backward))
            {
                float speed = ((float)frameState.GameTime.ElapsedGameTime.TotalMilliseconds) * -0.1f;
                Vector2 velocity = this.spaceship.Velocity;
                velocity.X += (float)Math.Sin(this.spaceship.Rotation) * speed;
                velocity.Y -= (float)Math.Cos(this.spaceship.Rotation) * speed;
                this.spaceship.Velocity = velocity;
            }

            if (frameState.KeyboardState.IsKeyDown(this.inputConfigurationRetriever.Left))
            {
                float speed = ((float)frameState.GameTime.ElapsedGameTime.TotalMilliseconds) * 0.01f;
                this.spaceship.Rotation = this.spaceship.Rotation + (speed * -1f);
            }

            if (frameState.KeyboardState.IsKeyDown(this.inputConfigurationRetriever.Right))
            {
                float speed = ((float)frameState.GameTime.ElapsedGameTime.TotalMilliseconds) * 0.01f;
                this.spaceship.Rotation = this.spaceship.Rotation + (speed * 1f);
            }
        }
    }
}
