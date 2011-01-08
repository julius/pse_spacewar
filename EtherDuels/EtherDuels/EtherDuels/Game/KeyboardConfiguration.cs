using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;


namespace EtherDuels.Game
{
    class KeyboardConfiguration : InputConfigurationRetriever
    {
        private Keys backward;
        public Keys Backward
        {
            get { return backward; }
            set { backward = value; }
        }

        private Keys fire;
        public Keys Fire
        {
            get { return fire; }
            set { fire = value; }
        }

        private Keys forward;
        public Keys Forward
        {
            get { return forward; }
            set { forward = value; }
        }

        private Keys left;
        public Keys Left
        {
            get { return left; }
            set { left = value; }
        }
        
        private Keys nextWeapon;
        public Keys NextWeapon
        {
            get { return nextWeapon; }
            set { nextWeapon = value; }
        }

        private Keys prevWeapon;
        public Keys PrevWeapon
        {
            get { return prevWeapon; }
            set { prevWeapon = value; }
        }

        private Keys right;
        public Keys Right
        {
            get { return right; }
            set { right = value; }
        }
    }
}
