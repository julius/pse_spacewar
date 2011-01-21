using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using EtherDuels.Config;

namespace EtherDuels.Game.Model
{   
    /// <summary>
    /// Defines the reaction to the human player's input.
    /// </summary>
    public class HumanPlayer: Player
    {
        private InputConfigurationRetriever inputConfigurationRetriever;
        private bool isFireKeyDown = false;
        private bool isNextWeaponKeyDown = false;
        private bool isPrevWeaponKeyDown = false;

        /// <summary>
        /// Creates a HumanPlayer.
        /// </summary>
        /// <param name="playerId">The player's ID.</param>
        /// <param name="playerHandler">The player's Handler.</param>
        /// <param name="inputConfigurationRetriever">The input configuration for the player.</param>
        public HumanPlayer(int playerId, PlayerHandler playerHandler, Color playerColor, InputConfigurationRetriever inputConfigurationRetriever)
            : base(playerId, playerHandler, playerColor)
        {
            this.inputConfigurationRetriever = inputConfigurationRetriever;
        }

        /// <summary>
        /// This method is being called for every frame of the game.
        /// It computes keyboard inputs and makes the player behave accordingly.
        /// </summary>
        /// <param name="frameState">The frame specific state.</param>
        public override void Update(FrameState frameState)
        {
            if (frameState.KeyboardState.IsKeyDown(this.inputConfigurationRetriever.Fire)) isFireKeyDown = true;
            if (frameState.KeyboardState.IsKeyUp(this.inputConfigurationRetriever.Fire) && isFireKeyDown)
            {
                isFireKeyDown = false;
                this.playerHandler.OnFire(this.spaceship);
            }

            if (frameState.KeyboardState.IsKeyDown(this.inputConfigurationRetriever.NextWeapon)) isNextWeaponKeyDown = true;
            if (frameState.KeyboardState.IsKeyUp(this.inputConfigurationRetriever.NextWeapon) && isNextWeaponKeyDown)
            {
                isNextWeaponKeyDown = false;
                if (this.spaceship.CurrentWeapon == Weapon.Laser)
                {
                    this.spaceship.CurrentWeapon = Weapon.Rocket;
                }
                else
                {
                    this.spaceship.CurrentWeapon = Weapon.Laser;
                }
            }

            if (frameState.KeyboardState.IsKeyDown(this.inputConfigurationRetriever.PrevWeapon)) isPrevWeaponKeyDown = true;
            if (frameState.KeyboardState.IsKeyUp(this.inputConfigurationRetriever.PrevWeapon) && isPrevWeaponKeyDown)
            {
                isPrevWeaponKeyDown = false;
                if (this.spaceship.CurrentWeapon == Weapon.Laser)
                {
                    this.spaceship.CurrentWeapon = Weapon.Rocket;
                }
                else
                {
                    this.spaceship.CurrentWeapon = Weapon.Laser;
                }
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
                float speed = ((float)frameState.GameTime.ElapsedGameTime.TotalMilliseconds) * 0.003f;
                this.spaceship.Rotation = this.spaceship.Rotation + (speed * -1f);
            }

            if (frameState.KeyboardState.IsKeyDown(this.inputConfigurationRetriever.Right))
            {
                float speed = ((float)frameState.GameTime.ElapsedGameTime.TotalMilliseconds) * 0.003f;
                this.spaceship.Rotation = this.spaceship.Rotation + (speed * 1f);
            }
        }
    }
}
