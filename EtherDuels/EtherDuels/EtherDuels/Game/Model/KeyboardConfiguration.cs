using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace EtherDuels.Game.Model
{   
    /// <summary>
    /// Saves the current KeyboardConfiguration of a Player.
    /// </summary>
    class KeyboardConfiguration : InputConfigurationRetriever
    {
        private Keys backwardKey;
        private Keys forwardKey;
        private Keys leftKey;
        private Keys rightKey;
        private Keys fireKey;
        private Keys nextWeaponKey;
        private Keys prevWeaponKey;

        public Keys ForwardKey
        {
            get { return forwardKey; }
            set { forwardKey = value; }
        }

        public Keys LeftKey
        {
            get { return leftKey; }
            set { leftKey = value; }
        }

        public Keys RightKey
        {
            get { return rightKey; }
            set { rightKey = value; }
        }

        public Keys FireKey
        {
            get { return fireKey; }
            set { fireKey = value; }
        }

        public Keys NextWeaponKey
        {
            get { return nextWeaponKey; }
            set { nextWeaponKey = value; }
        }

        public Keys PrevWeaponKey
        {
            get { return prevWeaponKey; }
            set { prevWeaponKey = value; }
        }

        public Keys BackwardKey
        {
            get { return backwardKey; }
            set { backwardKey = value; }
        }
    }
}
