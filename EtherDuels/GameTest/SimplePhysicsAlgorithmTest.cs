using EtherDuels.Game.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework;

using Microsoft.Xna.Framework.Input;
using Moq;
using System.Collections.Generic;

using EtherDuels.Config;
using System.Runtime.Serialization.Formatters.Binary;

namespace GameTest
{
    
    
    /// <summary>
    ///This is a test class for SimplePhysicsAlgorithmTest and is intended
    ///to contain all SimplePhysicsAlgorithmTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SimplePhysicsAlgorithmTest
    {
        private TestContext testContextInstance;

        private SimplePhysicsAlgorithm target;
        private Configuration configuration;
        private Mock<CollisionHandler> mockCollisionHandler;
        private Planet planet;
        private World world;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        [TestInitialize()]
        public void Initialize()
        {
            ConfigurationReader configurationReader = new ConfigurationReader(new BinaryFormatter(), null);
            configuration = configurationReader.read("config.cfg");
            mockCollisionHandler = new Mock<CollisionHandler>();
            planet = new Planet();
            planet.Mass = 100000;
            // asume 40.0 * 40.0 world, planet is in the center
            planet.Position = new Vector2(20.0f, 20.0f);
            planet.Velocity = new Vector2(0.0f, 0.0f);
            world = new World(new WorldObject[0]);
        }

        /// <summary>
        /// Test of the collision detection
        ///</summary>
        [TestMethod()]
        public void UpdateCollisionTest()
        {
            WorldObject object1 = new WorldObject();
            object1.Position = new Vector2(0.0f, 0.0f);
            object1.Radius = 1.0f;

            WorldObject object2 = new WorldObject();
            object2.Position = new Vector2(1.0f, 1.0f);
            object2.Radius = 1.0f;

            world.AddWorldObject(object1);
            world.AddWorldObject(object2);

            mockCollisionHandler.Setup(m => m.OnCollision(object1, object2));

            target = new SimplePhysicsAlgorithm(mockCollisionHandler.Object, world, configuration);
            target.Update(new GameTime(new TimeSpan(0, 0, 10, 3, 0), new TimeSpan(0, 0, 0, 0, 100)));
            target.Update(new GameTime(new TimeSpan(0, 0, 10, 3, 0), new TimeSpan(0, 0, 0, 0, 100)));

            mockCollisionHandler.Verify(m => m.OnCollision(object1, object2), Times.Exactly(1));
        }

        /// <summary>
        /// Test the speed limitation
        /// </summary>
        [TestMethod()]
        public void UpdateMaxSpeedTest()
        {
            float MAX_VELOCITY = 299792458.0f;
            WorldObject worldObject = new WorldObject();
            worldObject.Position = new Vector2(0.0f, 0.0f);
            worldObject.Velocity = new Vector2(MAX_VELOCITY + 5.0f, MAX_VELOCITY + 1.0f);

            planet.Mass = 0.0;
            world.AddWorldObject(worldObject);

            target = new SimplePhysicsAlgorithm(mockCollisionHandler.Object, world, configuration);
            target.Update(new GameTime(new TimeSpan(0, 0, 10, 3, 0), new TimeSpan(0, 0, 0, 0, 0)));

            // TODO an den code anpassen, siehe SimplePhysicsAlgorithm
            Assert.IsTrue(worldObject.Velocity.X == MAX_VELOCITY && worldObject.Velocity.Y == MAX_VELOCITY);
        }
    }
}
