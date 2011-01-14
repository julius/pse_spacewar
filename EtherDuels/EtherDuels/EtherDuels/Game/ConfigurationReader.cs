using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using Microsoft.Xna.Framework.Input;

using EtherDuels.Game.Model;

namespace EtherDuels.Game
{
    class ConfigurationReader
    {
        private BinaryFormatter binaryFormatter;
        private Stream stream;

        public ConfigurationReader(BinaryFormatter binForm, Stream stream)
        {
            this.binaryFormatter    = binForm;
            this.stream             = stream;
        }


        public Configuration read(string path)
        {
            if (File.Exists(path))
            {
                stream = File.Open("etherduels.conf", FileMode.Open);
            }
            else
            {
                Configuration defaultConf = new Configuration();
                KeyboardConfiguration defaultKeyConfPlayerA = new KeyboardConfiguration();
                KeyboardConfiguration defaultKeyConfPlayerB = new KeyboardConfiguration();

                defaultKeyConfPlayerA.Backward = Keys.S;
                defaultKeyConfPlayerA.Forward = Keys.W;
                defaultKeyConfPlayerA.Right = Keys.D;
                defaultKeyConfPlayerA.Left = Keys.A;
                defaultKeyConfPlayerA.PrevWeapon = Keys.Q;
                defaultKeyConfPlayerA.NextWeapon = Keys.E;
                defaultKeyConfPlayerA.Fire = Keys.Space;

                defaultKeyConfPlayerB.Backward = Keys.Down;
                defaultKeyConfPlayerB.Forward = Keys.Up;
                defaultKeyConfPlayerB.Right = Keys.Right;
                defaultKeyConfPlayerB.Left = Keys.Left;
                defaultKeyConfPlayerB.PrevWeapon = Keys.O;
                defaultKeyConfPlayerB.NextWeapon = Keys.P;
                defaultKeyConfPlayerB.Fire = Keys.RightControl;

                defaultConf.SetKeyboardConfiguration(1, defaultKeyConfPlayerA);
                defaultConf.SetKeyboardConfiguration(2, defaultKeyConfPlayerB);

                return defaultConf;
                //throw new Exception("No config file found.");
            }

            if (binaryFormatter == null)
            {
                binaryFormatter = new BinaryFormatter();
            }

            return (Configuration)binaryFormatter.Deserialize(stream);
        }
    }
}
