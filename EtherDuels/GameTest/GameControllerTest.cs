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
using Microsoft.Xna.Framework.Input;

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
            ConfigurationReader configurationReader = new ConfigurationReader(new BinaryFormatter(), null);
            Configuration configuration = configurationReader.read("config.cfg");
           
            GameTime gameTime = new GameTime(new TimeSpan(0, 0, 10, 3, 0), new TimeSpan(0, 0, 0, 0, 100));

            Mock<Physics> mockPhysics = new Mock<Physics>();
            mockPhysics.Setup(m => m.Update(gameTime));

            //Mock<PlayerHandler> mockPlayerHandler = new Mock<PlayerHandler>();
            Mock<Player> mockPlayer = new Mock<Player>();          //Mock<Player>(0, mockPlayerHandler.Object, Color.AliceBlue);
            Keys[] keys = { Keys.Space };
            mockPlayer.Setup(m => m.Update(new EtherDuels.FrameState(gameTime, new KeyboardState(keys))));
            List<Player> players = new List<Player>();
            players.Add(mockPlayer.Object);

            Spaceship object1 = new Spaceship();
            mockPlayer.SetupGet(m => m.Spaceship).Returns(object1);

            WorldObject object2 = new WorldObject();
            WorldObject[] worldObjects = { object1, object2 };
            WorldObject[][] mockParams = { worldObjects };
            Mock<World> mockWorld = new Mock<World>(mockParams);

            Mock<ShortLifespanObjectFactory> mockFactory = new Mock<ShortLifespanObjectFactory>();
            Explosion explosion = new Explosion();
            explosion.CreationTime = gameTime.TotalGameTime;
            mockFactory.Setup(m => m.CreateExplosion(gameTime)).Returns(explosion);
            Mock<WorldObjectView> mockExplosionView = new Mock<WorldObjectView>();
            mockFactory.Setup(m => m.CreateExplosionView(explosion)).Returns(mockExplosionView.Object);
            GameModel model = new GameModel(mockFactory.Object, mockPhysics.Object, players, mockWorld.Object);

            Mock<WorldView> mockWorldView = new Mock<WorldView>(mockWorld.Object);
            Mock<GameView> mockGameView = new Mock<GameView>(model, mockWorldView.Object);
            mockGameView.SetupGet(m => m.WorldView).Returns(mockWorldView.Object);


            mockGameBuilder = new Mock<GameBuilder>();
            mockGameBuilder.Setup(m => m.BuildModel()).Returns(model);
            mockGameBuilder.Setup(m => m.BuildView(model)).Returns(mockGameView.Object);

            Mock<GameHandler> mockGameHandler = new Mock<GameHandler>();
            mockGameHandler.Setup(m => m.OnGameEnded(mockPlayer.Object.PlayerId));

            object1.Position = new Vector2(100.0f, 100.0f);
            object2.Position = new Vector2(100.0f, 100.0f);

            target = new GameController(mockGameBuilder.Object, mockGameHandler.Object);
            target.CreateGame();
            target.OnCollision(object1, object2);

            Assert.Inconclusive("blabla");
        }
    }
}
