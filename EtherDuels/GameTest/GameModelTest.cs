using EtherDuels.Game.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;

namespace GameTest
{
    
    
    /// <summary>
    ///This is a test class for GameModelTest and is intended
    ///to contain all GameModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GameModelTest
    {


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
        private Mock<ShortLifespanObjectFactory> mockFactory;
        private Mock<Physics> mockPhysics;
        private Player[] mockPlayers;
        private Mock<World> mockWorld;
        private GameModel target;


        [TestInitialize()]
        public void Initialize()
        {
            mockFactory = new Moq.Mock<ShortLifespanObjectFactory>();
            mockPhysics = new Moq.Mock<Physics>();
            mockWorld = new Moq.Mock<World>();

            // create a random number of players for testing
            Random random = new Random();
            int nrOfPlayers = random.Next(0,10);
            mockPlayers = new Player[nrOfPlayers];
            for (int i = 0; i < nrOfPlayers; i++) {
                mockPlayers[i] = new Moq.Mock<Player>().Object;
            }
        }

        /* /// <summary>
        ///A test for GameModel Constructor
        ///</summary>
        [TestMethod()]
        public void GameModelConstructorTest()
        {
            
            target = new GameModel(factory, physics, players, world);
            Assert.Inconclusive("TODO: Implement code to verify target");
        } */

        /// <summary>
        ///A test for GetFactory
        ///</summary>
        [TestMethod()]
        public void GetFactoryTest()
        {
            target = new GameModel(mockFactory.Object, mockPhysics.Object, mockPlayers, mockWorld.Object);
            ShortLifespanObjectFactory expected = mockFactory.Object;
            ShortLifespanObjectFactory actual = target.GetFactory();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetPlayers
        ///</summary>
        [TestMethod()]
        public void GetPlayersTest()
        {
            target = new GameModel(mockFactory.Object, mockPhysics.Object, mockPlayers, mockWorld.Object);
            Player[] expected = mockPlayers;
            Player[] actual = target.GetPlayers();
            Assert.AreEqual(expected, actual);
        }

       /* /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            target = new GameModel(mockFactory.Object, mockPhysics.Object, mockPlayers, mockWorld.Object);
            Mock<FrameState> mockFrameState = new Moq.Mock<FrameState>();
            target.Update(mockFrameState.Object);

            for (int i = 0; i < mockPlayers.Length; i++) {
                mockPlayers[i].
            mockPhysics.Verify(b => b.Update(mockFrameState.Object.GetGameTime()), Times.Exactly(1));
        }

        /// <summary>
        ///A test for World
        ///</summary>
        [TestMethod()]
        public void WorldTest()
        {
            target = new GameModel(mockFactory.Object, mockPhysics.Object, mockPlayers, mockWorld.Object);
            World expected = mockWorld.Object;
            World actual;
            target.World = expected;
            actual = target.World;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        } */
    }
}
