using EtherDuels.Menu;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EtherDuels.Menu.Model;
using EtherDuels.Menu.View;
using EtherDuels;
using Moq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

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
        public void UpdateTest1()
        {
            Mock<MenuHandler> mockMenuHandler = new Mock<MenuHandler>();
            Mock<IMenuView> mockMenuView = new Mock<IMenuView>();

            Mock<MenuModel> mockMenuModel = new Mock<MenuModel>();
            mockMenuModel.Setup(m => m.Down());
            mockMenuModel.Setup(m => m.Up());
            mockMenuModel.Setup(m => m.Action());

            MenuController target = new MenuController(mockMenuHandler.Object, mockMenuModel.Object, mockMenuView.Object);

            GameTime gameTime = new GameTime(new TimeSpan(0, 0, 10, 3, 0), new TimeSpan(0, 0, 0, 0, 100));
            FrameState frameState = new FrameState(gameTime, new KeyboardState());
            target.Update(frameState);

            gameTime = new GameTime(new TimeSpan(0, 0, 10, 3, 0), new TimeSpan(0, 0, 0, 0, 100));
            Keys[] keys = { Keys.Up, Keys.Down, Keys.Enter };
            frameState = new FrameState(gameTime, new KeyboardState(keys));
            target.Update(frameState);

            mockMenuModel.Verify(m => m.Down(), Times.Exactly(1));
            mockMenuModel.Verify(m => m.Up(), Times.Exactly(1));
            mockMenuModel.Verify(m => m.Action(), Times.Exactly(1));
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest2()
        {
            // setup FrameState
            GameTime gameTime = new GameTime(new TimeSpan(0, 0, 10, 3, 0), new TimeSpan(0, 0, 0, 0, 100));
            Keys[] keys = { Keys.Down };
            FrameState frameState = new FrameState(gameTime, new KeyboardState(keys));

            Mock<MenuHandler> mockMenuHandler = new Mock<MenuHandler>();
            Mock<IMenuView> mockMenuView = new Mock<IMenuView>();

            Mock<MenuModel> mockMenuModel = new Mock<MenuModel>();
            mockMenuModel.SetupGet<bool>(m => m.IsWaitingForKey).Returns(true);
            mockMenuModel.Setup(m => m.SetWaitingKey(keys[0]));
            
            MenuController target = new MenuController(mockMenuHandler.Object, mockMenuModel.Object, mockMenuView.Object);
            target.Update(frameState);

            mockMenuModel.Verify(m => m.SetWaitingKey(keys[0]), Times.Exactly(1));
        }
    }
}
