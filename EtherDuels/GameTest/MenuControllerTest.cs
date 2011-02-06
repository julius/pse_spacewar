using EtherDuels.Menu;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EtherDuels.Menu.Model;
using EtherDuels.Menu.View;
using EtherDuels;
using Moq;

namespace GameTest
{
    
    
    /// <summary>
    ///This is a test class for MenuControllerTest and is intended
    ///to contain all MenuControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MenuControllerTest
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
        ///A test for SetGameEndedMenu
        ///</summary>
        [TestMethod()]
        public void SetGameEndedMenuTest()
        {
            int playerID = 0;

            Mock<MenuHandler> mockMenuHandler = new Mock<MenuHandler>();
            Mock<MenuModel> mockMenuModel = new Mock<MenuModel>();
            mockMenuModel.Setup(m => m.SetGameEndedMenu(playerID));
            Mock<IMenuView> mockMenuView = new Mock<IMenuView>();
            MenuController target = new MenuController(mockMenuHandler.Object, mockMenuModel.Object, mockMenuView.Object);

            target.SetGameEndedMenu(playerID);

            mockMenuModel.Verify(m => m.SetGameEndedMenu(playerID), Times.Exactly(1));
        }

        /// <summary>
        ///A test for SetMainMenu
        ///</summary>
        [TestMethod()]
        public void SetMainMenuTest()
        {
            Mock<MenuHandler> mockMenuHandler = new Mock<MenuHandler>();
            Mock<MenuModel> mockMenuModel = new Mock<MenuModel>();
            mockMenuModel.Setup(m => m.SetMainMenu());
            Mock<IMenuView> mockMenuView = new Mock<IMenuView>();
            MenuController target = new MenuController(mockMenuHandler.Object, mockMenuModel.Object, mockMenuView.Object);
            target.SetMainMenu();

            mockMenuModel.Verify(m => m.SetMainMenu(), Times.Exactly(1));
        }

        /// <summary>
        ///A test for SetPauseMenu
        ///</summary>
        [TestMethod()]
        public void SetPauseMenuTest()
        {
            Mock<MenuHandler> mockMenuHandler = new Mock<MenuHandler>();
            Mock<MenuModel> mockMenuModel = new Mock<MenuModel>();
            mockMenuModel.Setup(m => m.SetPauseMenu());
            Mock<IMenuView> mockMenuView = new Mock<IMenuView>();
            MenuController target = new MenuController(mockMenuHandler.Object, mockMenuModel.Object, mockMenuView.Object);

            target.SetPauseMenu();

            mockMenuModel.Verify(m => m.SetPauseMenu(), Times.Exactly(1));            
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            MenuHandler menuHandler = null; // TODO: Initialize to an appropriate value
            MenuModel menuModel = null; // TODO: Initialize to an appropriate value
            IMenuView menuView = null; // TODO: Initialize to an appropriate value
            MenuController target = new MenuController(menuHandler, menuModel, menuView); // TODO: Initialize to an appropriate value
            FrameState frameState = null; // TODO: Initialize to an appropriate value
            target.Update(frameState);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
