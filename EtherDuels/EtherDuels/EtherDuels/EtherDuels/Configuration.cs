using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

using Microsoft.Xna.Framework.Input;

using EtherDuels.Game.Model;


namespace EtherDuels.Config
{
    [Serializable()]
    public class Configuration : ConfigurationRetriever, ISerializable
    {
        private BinaryFormatter binaryFormatter;

        private KeyboardConfiguration[] keyConfigurations = new KeyboardConfiguration[2]; // fixed number of players, for now

        
        public KeyboardConfiguration GetKeyboardConfiguration(int playerID)
        {
            if (playerID < 1 || playerID > keyConfigurations.Length)
            {
                return null;
            }
            return keyConfigurations[playerID];
        }

        public void SetKeyboardConfiguration(int playerID, KeyboardConfiguration keyConfiguration)
        {
            if (playerID < 1 || playerID > keyConfigurations.Length)
            {
                return;
            }
            this.keyConfigurations[playerID] = keyConfiguration;
        }

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

        public void Save()
        {
            if (this.path == null)
            {
                throw new Exception("0010 Path not set for saving configuration.");
            }

            try
            {
                if (File.Exists(this.path))
                {
                    stream = File.Open(this.path, FileMode.Truncate);
                }
                else
                {
                    stream = File.Open(this.path, FileMode.Create);
                }
            }
            catch (FileNotFoundException e)
            {
                throw new Exception("0020 File couldn't be found / opened while saving configuration.\n" + e.ToString());
            }
            catch (UnauthorizedAccessException e)
            {
                throw new Exception("0030 Lacking permission to create / write " + this.path.ToString() + " file.\n" + e.ToString());
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

        // required by test class
        // if-blocks aligned for superior visibility not chained in one large if for marginally better performance
        public bool Equals(Configuration secConf)
        {
            if (secConf == null)
                return false;

            if (this.path != secConf.path
                || this.difficulty != secConf.difficulty
                || this.difficulty_AI != secConf.difficulty_AI)
                return false;

            if (this.keyConfigurations.Length != secConf.keyConfigurations.Length)
                return false;

            for (int i = 0; i < this.keyConfigurations.Length; i++)
            {
                if (!this.keyConfigurations[i].Equals(secConf.keyConfigurations[i]))
                    return false;
            }

            return true;
        }
    }
}
