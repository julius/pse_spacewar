﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;


namespace EtherDuels.Config
{
    public class ConfigurationReader
    {
        private BinaryFormatter binaryFormatter;
        private Stream stream;

        ConfigurationReader(BinaryFormatter binForm, Stream stream)
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
                throw new Exception("No config file found.");
            }

            if (binaryFormatter == null)
            {
                binaryFormatter = new BinaryFormatter();
            }

            return (Configuration)binaryFormatter.Deserialize(stream);
        }
    }
}