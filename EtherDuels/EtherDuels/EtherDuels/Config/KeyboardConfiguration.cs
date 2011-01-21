using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using Microsoft.Xna.Framework.Input;


namespace EtherDuels.Config
{
    /// <summary>
    /// The KeyboardConfiguration provides methods for setting and getting the respective keys
    /// of a player.
    /// </summary>
    [Serializable()]
    public class KeyboardConfiguration : InputConfigurationRetriever
    {
        // Deserialization constructor.
        /// <summary>
        /// Creates a new KeyboradConfiguration.
        /// </summary>
        /// <param name="info">The SerializationInfo.</param>
        /// <param name="ctxt">The StreamingContext.</param>
        public KeyboardConfiguration(SerializationInfo info, StreamingContext ctxt)
        {
            this.backward = (Keys)info.GetValue("backward", typeof(Keys));
            this.fire = (Keys)info.GetValue("fire", typeof(Keys));
            this.forward = (Keys)info.GetValue("forward", typeof(Keys));
            this.left = (Keys)info.GetValue("left", typeof(Keys));
            this.nextWeapon = (Keys)info.GetValue("nextWeapon", typeof(Keys));
            this.prevWeapon = (Keys)info.GetValue("prevWeapon", typeof(Keys));
            this.right = (Keys)info.GetValue("right", typeof(Keys));
        }

        public KeyboardConfiguration()
        {
        }

        // Serialization function.
        //TODO: kommentar vervollstaendigen
        /// <summary>
        ///  
        /// </summary>
        /// <param name="info">The SerializationInfo.</param>
        /// <param name="ctxt">The StreamingContext</param>
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

        /// <summary>
        /// Gets and sets the key for backward movement.
        /// </summary>
        private Keys backward;
        public Keys Backward
        {
            get { return backward; }
            set { backward = value; }
        }

        /// <summary>
        /// Gets and sets the key for firing a weapon.
        /// </summary>
        private Keys fire;
        public Keys Fire
        {
            get { return fire; }
            set { fire = value; }
        }

        /// <summary>
        /// Gets and sets the key for forward movement.
        /// </summary>
        private Keys forward;
        public Keys Forward
        {
            get { return forward; }
            set { forward = value; }
        }

        /// <summary>
        /// Gets and sets the key for turning to the left.
        /// </summary>
        private Keys left;
        public Keys Left
        {
            get { return left; }
            set { left = value; }
        }
        
        /// <summary>
        /// Gets and sets the key for changing to the next weapon.
        /// </summary>
        private Keys nextWeapon;
        public Keys NextWeapon
        {
            get { return nextWeapon; }
            set { nextWeapon = value; }
        }

        /// <summary>
        /// Gets and sets the key for changing to the previous weapon.
        /// </summary>
        private Keys prevWeapon;
        public Keys PrevWeapon
        {
            get { return prevWeapon; }
            set { prevWeapon = value; }
        }

        /// <summary>
        /// Gets and sets the key for turning to the right.
        /// </summary>
        private Keys right;
        public Keys Right
        {
            get { return right; }
            set { right = value; }
        }

        /// <summary>
        /// Checks if the assigned KeyboardConfiguration object is 
        /// equal to this one.
        /// Objects are defined equal if all the respective keyboard shortcuts match with each other. 
        /// </summary>
        /// <param name="secKeyConf">The KeyboardConfiguration which needs to be checked for equality.</param>
        /// <returns>true if all respective keyboard shortcuts are equal. false otherwise.</returns>
        public bool Equals(KeyboardConfiguration secKeyConf)
        {
            if (secKeyConf == null)
                return false;

            //TODO: kommentar verwirrend
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
