using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace EtherDuels
{
    /// <summary>
    /// Holds State specific for one Frame.
    /// </summary>
    public class FrameState
    {
        private GameTime gameTime;
        private KeyboardState keyboardState;

        /// <summary>
        /// Initializes a FrameState object.
        /// </summary>
        /// <param name="gameTime">The frame's time object.</param>
        /// <param name="keyboardState">The frame's keyboard state.</param>
        public FrameState(GameTime gameTime, KeyboardState keyboardState)
        {
            this.gameTime = gameTime;
            this.keyboardState = keyboardState;
        }

        //TODO: geht das schöner?
        /// <summary>
        /// Needed for testing.
        /// </summary>
        public FrameState() 
        {
            this.gameTime = new GameTime();
            this.keyboardState = new KeyboardState();
        }

        /// <summary>
        /// The frame's time object.
        /// </summary>
        public GameTime GameTime
        {
            get { return this.gameTime; }
        }

        /// <summary>
        /// The frame's keyboard state.
        /// </summary>
        public KeyboardState KeyboardState
        {
            get { return this.keyboardState; }
        }
    }
}
