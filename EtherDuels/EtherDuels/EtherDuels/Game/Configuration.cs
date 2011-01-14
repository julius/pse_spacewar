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
    [Serializable()]
    class Configuration : ConfigurationRetriever, ISerializable
    {
        private BinaryFormatter binaryFormatter;
        private KeyboardConfiguration[] keyConfigurations;
        private Stream stream;

        private int difficulty;
        public int Difficulty
        {
            get { return difficulty; }
            set { difficulty = value; }
        }

        private int difficulty_AI;
        public int Difficulty_AI
        {
            get { return difficulty_AI; }
            set { difficulty_AI = value; }
        }


        private string path;
        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        public Configuration()
        {
            keyConfigurations = new KeyboardConfiguration[10];
        }

        //Deserialization constructor.
        public Configuration(SerializationInfo info, StreamingContext ctxt)
        {
            this.difficulty = (int)info.GetValue("difficulty", typeof(int));
            this.difficulty_AI = (int)info.GetValue("difficulty_AI", typeof(int));
            keyConfigurations = (KeyboardConfiguration[])info.GetValue("keyConfigurations", typeof(KeyboardConfiguration[]));
        }

        //Serialization function.
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("difficulty", difficulty);
            info.AddValue("difficulty_AI", difficulty_AI);
            info.AddValue("keyConfigurations", keyConfigurations);
        }


        public KeyboardConfiguration GetKeyboardConfiguration(int playerID)
        {
            return keyConfigurations[playerID];
        }

        public void Save()
        {
            if (File.Exists(this.path))
            {
                stream = File.Open("etherduels.conf", FileMode.Truncate);
            } 
            else
            {
                stream = File.Open("etherduels.conf", FileMode.Create);
            }

            if (binaryFormatter == null)
            {
                binaryFormatter = new BinaryFormatter();
            }

            binaryFormatter.Serialize(stream, this);
            stream.Close();
        }


        public void SetBackwardKey(int playerID, Keys key)
        {
            keyConfigurations[playerID].Backward = key;
        }

        public void SetFireKey(int playerID, Keys key)
        {
            keyConfigurations[playerID].Fire = key;
        }

        public void SetForwardKey(int playerID, Keys key)
        {
            keyConfigurations[playerID].Forward = key;
        }

        public void SetKeyboardConfiguration(int playerID, KeyboardConfiguration keyConfiguration)
        {
            this.keyConfigurations[playerID] = keyConfiguration;
        }

        public void SetLeftKey(int playerID, Keys key)
        {
            keyConfigurations[playerID].Left = key;
        }

        public void SetNextWeaponKey(int playerID, Keys key)
        {
            keyConfigurations[playerID].NextWeapon = key;
        }


        public void SetPrevWeaponKey(int playerID, Keys key)
        {
            keyConfigurations[playerID].PrevWeapon = key;
        }

        public void SetRightKey(int playerID, Keys key)
        {
            keyConfigurations[playerID].Right = key;
        }
    }
}
