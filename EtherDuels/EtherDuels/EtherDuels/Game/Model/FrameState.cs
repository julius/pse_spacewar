using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace EtherDuels.Game.Model
{
    /// <summary>
    /// Holds State specific for one Frame
    /// </summary>
    public class FrameState
    {
        private GameTime gameTime;
        private KeyboardState keyboardState;

        /// <summary>
        /// Initializes a FrameState object
        /// </summary>
        /// <param name="gameTime">The frame's time object</param>
        /// <param name="keyboardState">The frame's keyboard state</param>
        public FrameState(GameTime gameTime, KeyboardState keyboardState)
        {
            this.gameTime = gameTime;
            this.keyboardState = keyboardState;
        }

        /// <summary>
        /// Gets the frame's time object
        /// </summary>
        /// <returns>The time object</returns>
        public GameTime GetGameTime()
        {
            return this.gameTime;
        }

        /// <summary>
        /// Gets the frame's keyboard state
        /// </summary>
        /// <returns>The keyboard state</returns>
        public KeyboardState GetKeyboardState()
        {
            return this.keyboardState;
        }
    }
}
