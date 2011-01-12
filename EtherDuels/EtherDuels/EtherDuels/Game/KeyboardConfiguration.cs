using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;


namespace EtherDuels.Game
{
    //KeyboardConfiguration has to be serializable as well as Configuration, 
    // if Configuration is supposed to store KeyboardConfiguration as well if it is serialized
    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    class KeyboardConfiguration : InputConfigurationRetriever
    {
        //Deserialization constructor.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="ctxt"></param>
        public KeyboardConfiguration(SerializationInfo info, StreamingContext ctxt)
        {
            this.backward   = (Keys)info.GetValue("backward", typeof(Keys));
            this.fire       = (Keys)info.GetValue("fire", typeof(Keys));
            this.forward    = (Keys)info.GetValue("forward", typeof(Keys));
            this.left       = (Keys)info.GetValue("left", typeof(Keys));
            this.nextWeapon = (Keys)info.GetValue("nextWeapon", typeof(Keys));
            this.prevWeapon = (Keys)info.GetValue("prevWeapon", typeof(Keys));
            this.right      = (Keys)info.GetValue("right", typeof(Keys));
        }

        //Serialization function.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="ctxt"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("backward", backward);
            info.AddValue("fire", fire);
            info.AddValue("forward", forward);
            info.AddValue("left", left);
            info.AddValue("nextWeapon", nextWeapon);
            info.AddValue("prevWeapon", prevWeapon);
            info.AddValue("right", right);
        }

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="secKeyConf"></param>
        /// <returns></returns>
        public bool Equals(KeyboardConfiguration secKeyConf)
        {
            if (secKeyConf == null)
                return false;

            // all the same
            if (this.backward != secKeyConf.backward
                || this.fire != secKeyConf.fire
                || this.forward != secKeyConf.forward
                || this.left != secKeyConf.left
                || this.nextWeapon != secKeyConf.nextWeapon
                || this.prevWeapon != secKeyConf.prevWeapon
                || this.right != secKeyConf.right)
                return false;

            return true;
        }
    }
}
