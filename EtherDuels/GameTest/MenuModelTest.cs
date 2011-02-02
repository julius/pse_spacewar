using EtherDuels.Menu.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework.Input;
using EtherDuels.Menu;
using Microsoft.Xna.Framework.Audio;
using System.IO;

namespace GameTest
{
    
    
    /// <summary>
    ///This is a test class for MenuModelTest and is intended
    ///to contain all MenuModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MenuModelTest
    {
        private TestContext testContextInstance;

        private int action11;
        private int action12;
        private MenuItem menuItem11;
        private MenuItem menuItem12;
        private MenuDialog dialog1;

        private int action21;
        private int action22;
        private MenuItem menuItem21;
        private MenuItem menuItem22;
        private MenuDialog dialog2;

        private MenuDialog[] dialogs;

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
            this.action11 = 0;
            this.menuItem11 = new MenuItem(delegate(MenuItem m) { this.action11 += 1; }, null);
            this.action12 = 0;
            this.menuItem12 = new MenuItem(delegate(MenuItem m) { this.action12 += 1; }, null);
            MenuItem[] menuItems1 = { menuItem11, menuItem12 };
            this.dialog1 = new MenuDialog(menuItems1);

            this.action21 = 0;
            this.menuItem21 = new MenuItem(delegate(MenuItem m) { this.action21 += 1; }, null);
            this.action22 = 0;
            this.menuItem22 = new MenuItem(delegate(MenuItem m) { this.action22 += 1; }, null);
            MenuItem[] menuItems2 = { menuItem21, menuItem22 };
            this.dialog2 = new MenuDialog(menuItems2);

            MenuDialog[] dialogs = { dialog1, dialog2 };
            this.dialogs = dialogs;

            FileStream stream = new FileStream(@"..\..\..\GameTest\null_sound.wav", FileMode.Open);
            MenuAssets.Instance.SoundMenuClick = SoundEffect.FromStream(stream);
            stream.Close();
        }

        /// <summary>
        ///A test for Action
        ///</summary>
        [TestMethod()]
        public void ActionTest()
        {
            this.dialog1.Active = false;
            this.dialog2.Active = true;

            MenuModel target = new MenuModel();
            target.MenuDialogs = this.dialogs;
            target.Action();

            Assert.AreEqual(0, action11);
            Assert.AreEqual(1, action21);
        }

        /// <summary>
        ///A test for Down
        ///</summary>
        [TestMethod()]
        public void DownTest()
        {
            MenuModel target = new MenuModel(); // TODO: Initialize to an appropriate value
            target.Down();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetActiveDialogByIndex
        ///</summary>
        [TestMethod()]
        public void SetActiveDialogByIndexTest()
        {
            MenuModel target = new MenuModel(); // TODO: Initialize to an appropriate value
            int index = 0; // TODO: Initialize to an appropriate value
            target.SetActiveDialogByIndex(index);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetGameEndedMenu
        ///</summary>
        [TestMethod()]
        public void SetGameEndedMenuTest()
        {
            MenuModel target = new MenuModel(); // TODO: Initialize to an appropriate value
            int playerID = 0; // TODO: Initialize to an appropriate value
            target.SetGameEndedMenu(playerID);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetMainMenu
        ///</summary>
        [TestMethod()]
        public void SetMainMenuTest()
        {
            MenuModel target = new MenuModel(); // TODO: Initialize to an appropriate value
            target.SetMainMenu();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetPauseMenu
        ///</summary>
        [TestMethod()]
        public void SetPauseMenuTest()
        {
            MenuModel target = new MenuModel(); // TODO: Initialize to an appropriate value
            target.SetPauseMenu();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetPreviousDialogActive
        ///</summary>
        [TestMethod()]
        public void SetPreviousDialogActiveTest()
        {
            MenuModel target = new MenuModel(); // TODO: Initialize to an appropriate value
            target.SetPreviousDialogActive();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SetWaitingKey
        ///</summary>
        [TestMethod()]
        public void SetWaitingKeyTest()
        {
            MenuModel target = new MenuModel(); // TODO: Initialize to an appropriate value
            Keys key = new Keys(); // TODO: Initialize to an appropriate value
            target.SetWaitingKey(key);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Up
        ///</summary>
        [TestMethod()]
        public void UpTest()
        {
            MenuModel target = new MenuModel(); // TODO: Initialize to an appropriate value
            target.Up();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for WaitForKey
        ///</summary>
        [TestMethod()]
        public void WaitForKeyTest()
        {
            MenuModel target = new MenuModel(); // TODO: Initialize to an appropriate value
            MenuModel.KeySetter keyWaiter = null; // TODO: Initialize to an appropriate value
            target.WaitForKey(keyWaiter);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for IsWaitingForKey
        ///</summary>
        [TestMethod()]
        public void IsWaitingForKeyTest()
        {
            MenuModel target = new MenuModel(); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsWaitingForKey;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MenuDialogs
        ///</summary>
        [TestMethod()]
        public void MenuDialogsTest()
        {
            MenuModel target = new MenuModel(); // TODO: Initialize to an appropriate value
            MenuDialog[] expected = null; // TODO: Initialize to an appropriate value
            MenuDialog[] actual;
            target.MenuDialogs = expected;
            actual = target.MenuDialogs;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for WinningPlayerID
        ///</summary>
        [TestMethod()]
        public void WinningPlayerIDTest()
        {
            MenuModel target = new MenuModel(); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.WinningPlayerID;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
