using EtherDuels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EtherDuels.Menu;
using Moq;
using EtherDuels.Menu.Model;
using EtherDuels.Menu.View;

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

            Mock<MenuHandler> mockMenuHandler = new Mock<MenuHandler>();
            Mock<MenuModel> mockMenuModel = new Mock<MenuModel>();
            Mock<IMenuView> mockMenuView = new Mock<IMenuView>();

            // setup MenuController mock
            Mock<MenuController> mockMenuController = new Mock<MenuController>(mockMenuHandler.Object, mockMenuModel.Object, mockMenuView.Object);
            mockMenuController.Setup(m => m.SetGameEndedMenu(playerID));

            EtherDuels.EtherDuels target = new EtherDuels.EtherDuels(programState);
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
            EtherDuels.EtherDuels target = new EtherDuels.EtherDuels(); // TODO: Initialize to an appropriate value
            target.OnGamePaused();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnNewGame
        ///</summary>
        [TestMethod()]
        public void OnNewGameTest()
        {
            EtherDuels.EtherDuels target = new EtherDuels.EtherDuels(); // TODO: Initialize to an appropriate value
            target.OnNewGame();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnQuitProgram
        ///</summary>
        [TestMethod()]
        public void OnQuitProgramTest()
        {
            EtherDuels.EtherDuels target = new EtherDuels.EtherDuels(); // TODO: Initialize to an appropriate value
            target.OnQuitProgram();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnResumeGame
        ///</summary>
        [TestMethod()]
        public void OnResumeGameTest()
        {
            EtherDuels.EtherDuels target = new EtherDuels.EtherDuels(); // TODO: Initialize to an appropriate value
            target.OnResumeGame();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
