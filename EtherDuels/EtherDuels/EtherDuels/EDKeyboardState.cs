using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace EtherDuels
{
    public class EDKeyboardState
    {
        private KeyboardState keyboardState;

        public EDKeyboardState()
        {
            keyboardState = new KeyboardState();
        }

        public EDKeyboardState(KeyboardState keyboardState)
        {
            this.keyboardState = keyboardState;
        }

        virtual public bool IsKeyDown(Keys key)
        {
            return keyboardState.IsKeyDown(key);
        }

        virtual public bool IsKeyUp(Keys key)
        {
            return keyboardState.IsKeyUp(key);
        }

        virtual public Keys[] GetPressedKeys()
        {
            return keyboardState.GetPressedKeys();
        }
    }
}
