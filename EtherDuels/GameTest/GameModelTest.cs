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
            n = 10;
        }


        /// <summary>
        ///A test for RemovePlayer
        ///</summary>
        [TestMethod()]
        public void RemovePlayerTest()
        {
            for (int i = 1; i < n; i++)
            {
                mockPlayers.Clear();
                players.Clear();

                for (int j = 0; j < i; j++)
                {
                    mockPlayers.Add(new Mock<Player>());
                    players.Add(mockPlayers[j].Object);
                }

                // create target
                GameModel target = new GameModel(mockFactory.Object, mockPhysics.Object, players, mockWorld.Object);


                for (int j = i - 1; j >= 0; j--)
                {
                    Player player = players[j];

                    // execute RemovePlayer(player)
                    target.RemovePlayer(player);

                    // verify that player has been removed from players
                    Assert.IsFalse(players.Contains(player));

                    // reset players for next test
                    players.Add(player);
                }
            }
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            for (int i = 1; i < n; i++)
            {
                mockPlayers.Clear();
                players.Clear();

                for (int j = 0; j < i; j++)
                {
                    mockPlayers.Add(new Mock<Player>());
                    players.Add(mockPlayers[j].Object);
                }

                // create target
                GameModel target = new GameModel(mockFactory.Object, mockPhysics.Object, players, mockWorld.Object);
                FrameState frameState = new FrameState();

                // set up mock functionalities
                mockPhysics.Setup(m => m.Update(frameState.GameTime));
                for (int j = 0; j < i; j++)
                {
                    mockPlayers[j].Setup(m => m.Update(frameState));
                }

                // execute Update(frameState)
                target.Update(frameState);

                // verify functionality of the Update function
                mockPhysics.Verify(m => m.Update(frameState.GameTime), Times.Exactly(1));
                for (int j = 0; j < i; j++)
                {
                    mockPlayers[j].Verify(m => m.Update(frameState), Times.Exactly(1));
                }
            }
        }
    }
}
