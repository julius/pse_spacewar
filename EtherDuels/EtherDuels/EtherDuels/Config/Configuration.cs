using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using Microsoft.Xna.Framework.Input;
using EtherDuels.Game.Model;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;


namespace EtherDuels.Config
{
    /// <summary>
    /// The Configuration provides all the settings needed for the game and the menu.
    /// It saves personal settings in a file.
    /// </summary>
    [Serializable()]
    public class Configuration : ConfigurationRetriever, ISerializable
    {
        private BinaryFormatter binaryFormatter;
        private KeyboardConfiguration[] keyConfigurations = new KeyboardConfiguration[2]; // fixed number of players, for now
        private Stream stream;

        /// <summary>
        /// Constructor which initializes the KeyboardConfiguration Array. Currently, fixed sized of 10 players.
        /// </summary>
        public Configuration()
        {
            keyConfigurations = new KeyboardConfiguration[10];
            for (int i = 0; i < keyConfigurations.Length; i++)
            {
                keyConfigurations[i] = new KeyboardConfiguration();
            }
        }

        private float volumeMusic;
        /// <summary>
        /// Gets and sets the volume of the music in the game.
        /// </summary>
        public float VolumeMusic
        {
            get { return this.volumeMusic; }
            set
            {
                this.volumeMusic = value;
                MediaPlayer.Volume = value;
            }
        }

        private float volumeEffects;
        /// <summary>
        ///  Gets and sets the volume of the sound effects.
        /// </summary>
        public float VolumeEffects
        {
            get { return this.volumeEffects; }
            set
            {
                this.volumeEffects = value;
                SoundEffect.MasterVolume = value;
            }
        }


        private int difficulty;
        /// <summary>
        /// Gets and sets the difficulty level.
        /// </summary>
        public int Difficulty
        {
            get { return difficulty; }
            set { difficulty = value; }
        }

        private int difficulty_AI;
        /// <summary>
        /// Gets and sets the difficulty level of the AI Player.
        /// </summary>
        public int Difficulty_AI
        {
            get { return difficulty_AI; }
            set { difficulty_AI = value; }
        }


        private string path;
        /// <summary>
        /// Gets and sets the path to read the configuration file from.
        /// </summary>
        public string Path
        {
            get { return path; }
            set { path = value; }
        }
        

        /// <summary>
        /// Creates a new Configuration.
        /// </summary>
        /// <param name="info">Info on how to serialize this class.</param>
        /// <param name="ctxt">The assigned StreamingContext.</param>
        public Configuration(SerializationInfo info, StreamingContext ctxt)
        {
            this.difficulty = (int)info.GetValue("difficulty", typeof(int));
            this.difficulty_AI = (int)info.GetValue("difficulty_AI", typeof(int));
            keyConfigurations = (KeyboardConfiguration[])info.GetValue("keyConfigurations", typeof(KeyboardConfiguration[]));

            this.VolumeMusic = (float)info.GetValue("volumeMusic", typeof(float));
            this.VolumeEffects = (float)info.GetValue("volumeEffects", typeof(float));
        }

        /// <summary>
        /// Adds all important values to the SerializationInfo.
        /// </summary>
        /// <param name="info">The assigned SerializationInfo.</param>
        /// <param name="ctxt">The assigned StreamingContext.</param>
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("difficulty", difficulty);
            info.AddValue("difficulty_AI", difficulty_AI);
            info.AddValue("keyConfigurations", keyConfigurations);
            info.AddValue("volumeMusic", volumeMusic);
            info.AddValue("volumeEffects", volumeEffects);
        }

        /// <summary>
        /// Returns the KeyboardConfiguration of the specified player.
        /// </summary>
        /// <param name="playerID">The ID which specifies the player.</param>
        /// <returns>The KeyboardConfiguration of the specified player. Returns null if player is non-existent.</returns>
        public KeyboardConfiguration GetKeyboardConfiguration(int playerID)
        {
            if (playerID < 1 || playerID > keyConfigurations.Length)
            {
                return null;
            }
            return keyConfigurations[playerID];
        }

        /// <summary>
        /// Sets the KeyboardConfiguration for the specified player.
        /// </summary>
        /// <param name="playerID">The ID which specifies the player.</param>
        /// <param name="keyConfiguration">The KeyboardConfiguration of the specified player.</param>
        public void SetKeyboardConfiguration(int playerID, KeyboardConfiguration keyConfiguration)
        {
            if (playerID < 1 || playerID > keyConfigurations.Length)
            {
                return;
            }
            this.keyConfigurations[playerID] = keyConfiguration;
        }

        /// <summary>
        /// Saves the current Configuration to a file.
        /// </summary>
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

        /// <summary>
        /// Sets the backward key for the player specified by the playerID.
        /// </summary>
        /// <param name="playerID">The ID which specifies the player.</param>
        /// <param name="key">The new key which needs to be assigned.</param>
        public void SetBackwardKey(int playerID, Keys key)
        {
            keyConfigurations[playerID].Backward = key;
        }

        /// <summary>
        /// Sets the fire key for the player specified by the playerID.
        /// </summary>
        /// <param name="playerID">The ID which specifies the player.</param>
        /// <param name="key">The new key which needs to be assigned.</param>
        public void SetFireKey(int playerID, Keys key)
        {
            keyConfigurations[playerID].Fire = key;
        }

        /// <summary>
        /// Sets the forward key for the player specified by the playerID.
        /// </summary>
        /// <param name="playerID">The ID which specifies the player.</param>
        /// <param name="key">The new key which needs to be assigned.</param>
        public void SetForwardKey(int playerID, Keys key)
        {
            keyConfigurations[playerID].Forward = key;
        }

        /// <summary>
        /// Sets the turn-left key for the player specified by the playerID.
        /// </summary>
        /// <param name="playerID">The ID which specifies the player.</param>
        /// <param name="key">The new key which needs to be assigned.</param>
        public void SetLeftKey(int playerID, Keys key)
        {
            keyConfigurations[playerID].Left = key;
        }

        /// <summary>
        /// Sets the next-weapon key for the player specified by the playerID.
        /// </summary>
        /// <param name="playerID">The ID which specifies the player.</param>
        /// <param name="key">The new key which needs to be assigned.</param>
        public void SetNextWeaponKey(int playerID, Keys key)
        {
            keyConfigurations[playerID].NextWeapon = key;
        }

        /// <summary>
        /// Sets the prev-weapon key for the player specified by the playerID.
        /// </summary>
        /// <param name="playerID">The ID which specifies the player.</param>
        /// <param name="key">The new key which needs to be assigned.</param>
        public void SetPrevWeaponKey(int playerID, Keys key)
        {
            keyConfigurations[playerID].PrevWeapon = key;
        }

        /// <summary>
        /// Sets the turn-right key for the player specified by the playerID.
        /// </summary>
        /// <param name="playerID">The ID which specifies the player.</param>
        /// <param name="key">The new key which needs to be assigned.</param>
        public void SetRightKey(int playerID, Keys key)
        {
            keyConfigurations[playerID].Right = key;
        }

        /// <summary>
        /// Checks if the assigned Configuration object is equal to this one.
        /// Objects are defined equal if all the respective settings match with each other. 
        /// </summary>
        /// <param name="secKeyConf">The Configuration which needs to be checked for equality.</param>
        /// <returns>true if all respective settings are equal. false otherwise.</returns>
        public bool Equals(Configuration secConf)
        {
            if (secConf == null)
                return false;

            if (this.difficulty != secConf.difficulty
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
