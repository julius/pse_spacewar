using EtherDuels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EtherDuels.Menu;
using Moq;
using EtherDuels.Menu.Model;
using EtherDuels.Menu.View;
using EtherDuels.Game;

namespace GameTest
{
    
    
    /// <summary>
    ///This is a test class for EtherDuelsTest and is intended
    ///to contain all EtherDuelsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EtherDuelsTest
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


        /// <summary>
        ///A test for OnGameEnded
        ///</summary>
        [TestMethod()]
        public void OnGameEndedTest()
        {
            int playerID = 0;

            // setup the ProgramState
            ProgramState programState = new ProgramState();
            programState.GameState = GameState.InGame;
            programState.MenuState = MenuState.NoMenu;

            Mock<MenuModel> mockMenuModel = new Mock<MenuModel>();
            Mock<IMenuView> mockMenuView = new Mock<IMenuView>();

            EtherDuels.EtherDuels target = new EtherDuels.EtherDuels(programState);
            
            // setup MenuController mock
            Mock<MenuController> mockMenuController = new Mock<MenuController>(target, mockMenuModel.Object, mockMenuView.Object);
            mockMenuController.Setup(m => m.SetGameEndedMenu(playerID));

            target.MenuController = mockMenuController.Object;

            target.OnGameEnded(playerID);

            Assert.AreEqual(programState.GameState, GameState.GameEnded);
            Assert.AreEqual(programState.MenuState, MenuState.NoMenu);

            mockMenuController.Verify(m => m.SetGameEndedMenu(playerID), Times.Exactly(1));
        }

        /// <summary>
        ///A test for OnGamePaused
        ///</summary>
        [TestMethod()]
        public void OnGamePausedTest()
        {
            // setup the ProgramState
            ProgramState programState = new ProgramState();
            programState.GameState = GameState.InGame;
            programState.MenuState = MenuState.NoMenu;

            Mock<MenuModel> mockMenuModel = new Mock<MenuModel>();
            Mock<IMenuView> mockMenuView = new Mock<IMenuView>();

            EtherDuels.EtherDuels target = new EtherDuels.EtherDuels(programState);

            // setup MenuController mock
            Mock<MenuController> mockMenuController = new Mock<MenuController>(target, mockMenuModel.Object, mockMenuView.Object);
            mockMenuController.Setup(m => m.SetPauseMenu());
            
            target.MenuController = mockMenuController.Object;

            target.OnGamePaused();

            Assert.AreEqual(programState.GameState, GameState.GamePaused);
            Assert.AreEqual(programState.MenuState, MenuState.InMenu);

            mockMenuController.Verify(m => m.SetPauseMenu(), Times.Exactly(1));
        }

        /// <summary>
        ///A test for OnNewGame
        ///</summary>
        [TestMethod()]
        public void OnNewGameTest()
        {
            // setup the ProgramState
            ProgramState programState = new ProgramState();
            programState.GameState = GameState.NoGame;
            programState.MenuState = MenuState.InMenu;

            Mock<GameBuilder> mockGameBuilder = new Mock<GameBuilder>();

            EtherDuels.EtherDuels target = new EtherDuels.EtherDuels(programState);

            Mock<GameController> mockGameController = new Mock<GameController>(mockGameBuilder.Object, target);
            mockGameController.Setup(m => m.CreateGame());


            target.GameController = mockGameController.Object;

            target.OnNewGame();

            Assert.AreEqual(programState.GameState, GameState.InGame);
            Assert.AreEqual(programState.MenuState, MenuState.NoMenu);
            mockGameController.Verify(m => m.CreateGame(), Times.Exactly(1));
        }

/*
        /// <summary>
        ///A test for OnQuitProgram
        ///</summary>
        [TestMethod()]
        public void OnQuitProgramTest()
        {
            EtherDuels.EtherDuels target = new EtherDuels.EtherDuels();

            target.OnQuitProgram();

            Assert.Inconclusive("There is no behaviour to be tested.");
        }
*/ 

        /// <summary>
        ///A test for OnResumeGame
        ///</summary>
        [TestMethod()]
        public void OnResumeGameTest()
        {
            // setup the ProgramState
            ProgramState programState = new ProgramState();
            programState.GameState = GameState.GamePaused;
            programState.MenuState = MenuState.InMenu;

            EtherDuels.EtherDuels target = new EtherDuels.EtherDuels(programState);

            target.OnResumeGame();

            Assert.AreEqual(programState.GameState, GameState.InGame);
            Assert.AreEqual(programState.MenuState, MenuState.NoMenu);
        }
    }
}
