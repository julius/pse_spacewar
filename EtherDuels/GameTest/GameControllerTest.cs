using EtherDuels.Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EtherDuels.Game.Model;
using Moq;
using EtherDuels.Config;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using EtherDuels.Game.View;

namespace GameTest
{
    
    
    /// <summary>
    ///This is a test class for GameControllerTest and is intended
    ///to contain all GameControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GameControllerTest
    {
        private GameController target;
        private Mock<GameBuilder> mockGameBuilder;

        private TestContext testContextInstance;

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
            Configuration configuration = configurationReader.read("config.cfg");
           
            GameTime gameTime = new GameTime(new TimeSpan(0, 0, 10, 3, 0), new TimeSpan(0, 0, 0, 0, 100));

            Mock<Physics> mockPhysics = new Mock<Physics>();
            mockPhysics.Setup(m => m.Update(gameTime));

            Mock<Player> mockPlayer = new Mock<Player>();
            mockPlayer.Setup(m => m.Update(new EtherDuels.FrameState(gameTime, null)));
            List<Player> players = new List<Player>();
            players.Add(mockPlayer.Object);

            WorldObject object1 = new WorldObject();
            WorldObject object2 = new WorldObject();
            WorldObject[] worldObjects = { object1, object2 };
            World world = new World(worldObjects);

            GameModel model = new GameModel(new SimpleShortLifespanObjectFactory(), mockPhysics.Object, players, world);
            GameView view = new SimpleGameBuilder(configuration).BuildView(model);

            mockGameBuilder = new Mock<GameBuilder>();
            mockGameBuilder.Setup(m => m.BuildModel()).Returns(model);
            mockGameBuilder.Setup(m => m.BuildView(model));
        }

        /// <summary>
        ///A test for OnFire
        ///</summary>
        [TestMethod()]
        public void OnFireTest()
        {
            GameBuilder gameBuilder = null; // TODO: Initialize to an appropriate value
            GameHandler gameHandler = null; // TODO: Initialize to an appropriate value
            GameController target = new GameController(gameBuilder, gameHandler); // TODO: Initialize to an appropriate value
            Spaceship shooter = null; // TODO: Initialize to an appropriate value
            target.OnFire(shooter);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnCollision
        ///</summary>
        [TestMethod()]
        public void OnCollisionTest()
        {
            GameBuilder gameBuilder = null; // TODO: Initialize to an appropriate value
            GameHandler gameHandler = null; // TODO: Initialize to an appropriate value
            GameController target = new GameController(gameBuilder, gameHandler); // TODO: Initialize to an appropriate value
            WorldObject collisionObject1 = null; // TODO: Initialize to an appropriate value
            WorldObject collisionObject2 = null; // TODO: Initialize to an appropriate value
            target.OnCollision(collisionObject1, collisionObject2);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
