using EtherDuels.Game.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using EtherDuels;
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
        Mock<World> mockWorld = new Mock<World>(); // is only needed for the constructor
        Mock<ShortLifespanObjectFactory> mockFactory = new Mock<ShortLifespanObjectFactory>(); // is only needed for the constructor
        Mock<Physics> mockPhysics = new Mock<Physics>();    
        List<Player> players = new List<Player>();
        List<Mock<Player>> mockPlayers = new List<Mock<Player>>();
        int n; // number of players

        [TestInitialize()]
        public void Initialize()
        {
            // test with a random number of players to be sure it works every time.
            Random random = new Random();
            n = 1 + random.Next() % 9; // there must be a minimum of 1 player

            for (int i = 0; i < n; i++)
            {
                mockPlayers.Add(new Mock<Player>());
                players.Add(mockPlayers[i].Object);
            }
        }


        /// <summary>
        ///A test for RemovePlayer
        ///</summary>
        [TestMethod()]
        public void RemovePlayerTest()
        {
            GameModel target = new GameModel(mockFactory.Object, mockPhysics.Object, players, mockWorld.Object);

            // choose one of the players randomly
            Random random = new Random();
            int x;
            if (n == 1)
            {
                x = 0;
            }
            else
            {
                x = random.Next() % (n - 1);
            }
            
            Player player = players[x];
            
            // execute RemovePlayer(player)
            target.RemovePlayer(player);

            // verify that player has been removed from players
            Assert.IsFalse(players.Contains(player));
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            
            
            GameModel target = new GameModel(mockFactory.Object, mockPhysics.Object, players, mockWorld.Object);
            FrameState frameState = new FrameState();

            // set up mock functionalities
            mockPhysics.Setup(m => m.Update(frameState.GameTime));
            for (int i = 0; i < n; i++)
            {
                mockPlayers[i].Setup(m => m.Update(frameState));
            }

            // execute Update(frameState)
            target.Update(frameState);
            
            // verify functionality of the Update function
            mockPhysics.Verify(m => m.Update(frameState.GameTime), Times.Exactly(1));
            for (int i = 0; i < n; i++)
            {
                mockPlayers[i].Verify(m => m.Update(frameState), Times.Exactly(1));
            }
        }
    }
}
