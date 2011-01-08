//using EtherDuels;
using EtherDuels.Config;
using EtherDuels.Game;
using EtherDuels.Game.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace GameTest
{
    [TestClass()]
    public class ConfigurationTest
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        private Configuration conf;


        [TestInitialize()]
        public void Initialize()
        {
            conf = new Configuration();
        }

        [TestMethod()]
        public void SaveFile()
        {
            conf.Path = "etherduels.conf";
            conf.Save();

            Configuration secondConf = getConfig();

            if (secondConf == null)
                Assert.Fail("Deserialized config is null");
            if (!secondConf.Equals(conf))
                Assert.Fail("Deserialized config != original conf");

            conf.ToString();

            secondConf.ToString();

        }

        private Configuration getConfig()
        {
            if (conf.Path == null)
                conf.Path = "etherduels.conf";

            //StreamReader streamR = null;
            Stream stream = null;

            try 
            {
                stream = File.Open(conf.Path, FileMode.Open);
                //new StreamReader(conf.Path);
            }
            catch (Exception e)
            {
                Assert.Fail("File.open() threw exception: " + e.ToString());
                //Assert.Fail("new StreamReader() threw exception: " + e.ToString());
            }

            //string text = streamR.ReadToEnd();
            //streamR.Close();

            BinaryFormatter bFormatter = new BinaryFormatter();
            Configuration deSerializedConfig = (Configuration)bFormatter.Deserialize(stream);
            stream.Close();

            return deSerializedConfig;
        }


        [TestMethod()]
        public void UpdateTest2()
        {

        }
    }
}
