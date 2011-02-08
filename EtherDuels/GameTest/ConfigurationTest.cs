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
        public void SaveFileTest()
        {
            string path = "etherduels.conf";
            conf.Path = path;
            conf.Save();

            ConfigurationReader reader = new ConfigurationReader(new BinaryFormatter(), null);
            Configuration secondConf = reader.Read(path);

            if (secondConf == null)
                Assert.Fail("Deserialized config is null");
            if (!secondConf.Equals(conf))
                Assert.Fail("Deserialized config != original conf");

            conf.ToString();

            secondConf.ToString();

        }
    }
}
