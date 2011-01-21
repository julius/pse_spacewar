using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using Microsoft.Xna.Framework.Input;

namespace EtherDuels.Config
{
    public class ConfigurationReader
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
                stream = File.Open(path, FileMode.Open);
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
                defaultConf.Difficulty = 1;

                defaultConf.Path = path;
                return defaultConf;
            }

            if (binaryFormatter == null)
            {
                binaryFormatter = new BinaryFormatter();
            }

            Configuration result = (Configuration)binaryFormatter.Deserialize(stream);
            stream.Close();
            result.Path = path;
            return result;
        }
    }
}
