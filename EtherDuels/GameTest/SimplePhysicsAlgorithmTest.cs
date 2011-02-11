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
        // G: gravitational constant
        public static double G = 6.67428E-11;  // in m^3/kg/s^2
        // N: normalisation factor, to downsize the dimensions of the universe to those of our game
        public static float N = 300000;        // must NOT be 0!!

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
            configuration = configurationReader.Read("config.cfg");
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

            WorldObject object3 = new WorldObject();
            object3.Position = new Vector2(200, 200);
            object3.Radius = 1.0f;

            WorldObject object4 = new WorldObject();
            object4.Position = new Vector2(201, 201);
            object4.Radius = 1.0f;

            world.AddWorldObject(object1);
            world.AddWorldObject(object2);

            mockCollisionHandler.Setup(m => m.OnCollision(object1, object2));

            target = new SimplePhysicsAlgorithm(mockCollisionHandler.Object, world, configuration);
            target.Update(new GameTime(new TimeSpan(0, 0, 10, 3, 0), new TimeSpan(0, 0, 0, 0, 1)));

            world.AddWorldObject(object3);
            world.AddWorldObject(object4);
            target.Update(new GameTime(new TimeSpan(0, 0, 10, 3, 1), new TimeSpan(0, 0, 0, 0, 1)));

            mockCollisionHandler.Verify(m => m.OnCollision(object1, object2), Times.Exactly(1));
            mockCollisionHandler.Verify(m => m.OnCollision(object3, object4), Times.Exactly(1));
        }

        /// <summary>
        /// Test the speed limitation
        /// </summary>
        [TestMethod()]
        public void UpdateMaxSpeedTest()
        {
            float MAX_VELOCITY = 299792458.0f;
            WorldObject worldObject1 = new WorldObject();
            worldObject1.Position = new Vector2(0.0f, 0.0f);
            worldObject1.Velocity = new Vector2(MAX_VELOCITY + 5.0f, MAX_VELOCITY + 1.0f);
            world.AddWorldObject(worldObject1);

            WorldObject worldObject2 = new WorldObject();
            worldObject2.Position = new Vector2(200, 200);
            worldObject2.Velocity = Vector2.One;
            world.AddWorldObject(worldObject2);

            planet.Mass = 0.0;

            Vector2 expectedVel = worldObject1.Velocity;
            expectedVel.Normalize();
            expectedVel *= MAX_VELOCITY;

            target = new SimplePhysicsAlgorithm(mockCollisionHandler.Object, world, configuration);
            target.Update(new GameTime(new TimeSpan(0, 0, 10, 3, 0), new TimeSpan(0, 0, 0, 0, 1)));

            Assert.AreEqual(worldObject1.Velocity, expectedVel);
            Assert.AreEqual(worldObject2.Velocity, Vector2.One);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod()]
        public void UpdateDifficultyTest()
        {
            Mock<ConfigurationRetriever> mockConfRet = new Mock<ConfigurationRetriever>();
            mockConfRet.SetupGet(m => m.Difficulty).Returns(1);

            // set up a big planet
            Planet bigPlanet = new Planet();
            bigPlanet.IsFlexible = false;
            bigPlanet.Position = new Vector2(0, 0);
            bigPlanet.Radius = 300;
            world.AddWorldObject(bigPlanet);

            // set up a small planet
            float desiredDistance = 700;

            Planet smallPlanet = new Planet();
            smallPlanet.IsFlexible = true;
            smallPlanet.Position = new Vector2(desiredDistance, 0);

            // calculate velocity needed to circuit in orbit
            float smallPlanetVelocity = (float)Math.Sqrt(bigPlanet.Mass * G / desiredDistance / (N * 1000));
            smallPlanet.Velocity = new Vector2(0, smallPlanetVelocity);
            smallPlanet.Radius = 150;
            world.AddWorldObject(smallPlanet);

            target = new SimplePhysicsAlgorithm(mockCollisionHandler.Object, world, mockConfRet.Object);

            //TODO: kay problem is: wenn TimeSpan zu groß, funzt UpdateGravity nicht richtig. Muss ich mal in der Physik untersuchen.
            //for (int i = 0; i < 1000000; i++)
            //{
                target.Update(new GameTime(new TimeSpan(0, 0, 10, 3, 0), new TimeSpan(0, 0, 0, 5, 10)));
            //}

            // check whether the distance between the planets is still about the same
            float distance = Vector2.Distance(bigPlanet.Position, smallPlanet.Position);
            System.Console.Write("desired: " + desiredDistance + "; actual: " + distance + "; position: " + smallPlanet.Position);

            Assert.IsTrue(distance <= desiredDistance + 30);

        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod()]
        public void UpdateDeleteExplosionTest()
        {
            // create explosions
            Explosion explosion1 = new Explosion();
            Explosion explosion2 = new Explosion();
            Explosion explosion3 = new Explosion();
            explosion1.Health = 100;
            explosion2.Health = 100;
            explosion3.Health = 100;
            explosion1.CreationTime = new TimeSpan(0, 0, 0, 0, 1); // should be destroyed at (0, 0, 0, 0, 100)
            explosion2.CreationTime = new TimeSpan(0, 0, 0, 0, 250); // should be destroyed at (0, 0, 0, 0, 351)
            explosion3.CreationTime = new TimeSpan(0, 0, 0, 0, 34); // should be destroyed at (0, 0, 0, 0, 135)

            // create a mock world
            Mock<World> mockWorld = new Mock<World>();
            WorldObject[] worldObjects = { explosion1, explosion2, explosion3 };
            mockWorld.SetupGet(m => m.WorldObjects).Returns(worldObjects);
            mockWorld.Setup(m => m.RemoveWorldObject(explosion1));
            mockWorld.Setup(m => m.RemoveWorldObject(explosion3));


            // create target and call update
            target = new SimplePhysicsAlgorithm(mockCollisionHandler.Object, mockWorld.Object, configuration);
            target.Update(new GameTime(new TimeSpan(0, 0, 0, 0, 135), new TimeSpan(0, 0, 0, 0, 1)));

            // explosions 1 and 3 should be destroyed, explosion 2 should still be there
            Assert.IsTrue(explosion1.Health <= 0);
            Assert.IsTrue(explosion2.Health > 0);
            Assert.IsTrue(explosion3.Health <= 0);

            mockWorld.Verify(m => m.RemoveWorldObject(explosion1), Times.Exactly(1));
            mockWorld.Verify(m => m.RemoveWorldObject(explosion3), Times.Exactly(1));            
        }
    }
}
