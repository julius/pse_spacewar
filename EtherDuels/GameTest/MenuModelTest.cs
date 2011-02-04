using EtherDuels.Menu.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework.Input;
using EtherDuels.Menu;
using Microsoft.Xna.Framework.Audio;
using System.IO;
using System.Collections.Generic;

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
            this.dialog1.Active = false;
            this.dialog2.Active = true;

            MenuModel target = new MenuModel();
            target.MenuDialogs = this.dialogs;
            target.Down();

            Assert.IsTrue(this.menuItem11.Selected);
            Assert.IsFalse(this.menuItem12.Selected);
            Assert.IsFalse(this.menuItem21.Selected);
            Assert.IsTrue(this.menuItem22.Selected);
        }

        /// <summary>
        ///A test for SetActiveDialogByIndex
        ///</summary>
        [TestMethod()]
        public void SetActiveDialogByIndexTest()
        {
            this.dialog1.Active = false;
            this.dialog2.Active = true;

            MenuModel target = new MenuModel();
            target.MenuDialogs = this.dialogs;
            target.SetActiveDialogByIndex(0);

            Assert.IsTrue(dialog1.Active);
            Assert.IsFalse(dialog2.Active);
        }

        /// <summary>
        ///A test for SetGameEndedMenu
        ///</summary>
        [TestMethod()]
        public void SetGameEndedMenuTest()
        {
            List<MenuDialog> dialogList = new List<MenuDialog>();
            for (int i = 0; i <= 10; i += 1)
            {
                MenuItem menuItem = new MenuItem(delegate(MenuItem m) { }, null);
                MenuItem[] menuItems = { menuItem };
                MenuDialog d = new MenuDialog(menuItems);
                d.Active = (i == 3) ? true : false;
                dialogList.Add(d);
            }

            MenuModel target = new MenuModel();
            target.MenuDialogs = dialogList.ToArray();
            target.SetGameEndedMenu(2);

            Assert.IsFalse(dialogList[3].Active);
            Assert.IsTrue(dialogList[10].Active);
            Assert.AreEqual(2, target.WinningPlayerID);
        }

        /// <summary>
        ///A test for SetMainMenu
        ///</summary>
        [TestMethod()]
        public void SetMainMenuTest()
        {
            this.dialog1.Active = false;
            this.dialog2.Active = true;

            MenuModel target = new MenuModel();
            target.MenuDialogs = this.dialogs;
            target.SetMainMenu();

            Assert.IsTrue(dialog1.Active);
            Assert.IsFalse(dialog2.Active);
        }

        /// <summary>
        ///A test for SetPauseMenu
        ///</summary>
        [TestMethod()]
        public void SetPauseMenuTest()
        {
            this.dialog1.Active = true;
            this.dialog2.Active = false;

            MenuModel target = new MenuModel();
            target.MenuDialogs = this.dialogs;
            target.SetPauseMenu();

            Assert.IsFalse(dialog1.Active);
            Assert.IsTrue(dialog2.Active);
        }

        /// <summary>
        ///A test for SetPreviousDialogActive
        ///</summary>
        [TestMethod()]
        public void SetPreviousDialogActiveTest()
        {
            this.dialog1.Active = true;
            this.dialog2.Active = false;

            MenuModel target = new MenuModel();
            target.MenuDialogs = this.dialogs;
            target.SetActiveDialogByIndex(1);
            target.SetPreviousDialogActive();

            Assert.IsTrue(dialog1.Active);
            Assert.IsFalse(dialog2.Active);
        }

        /// <summary>
        ///A test for Up
        ///</summary>
        [TestMethod()]
        public void UpTest()
        {
            this.dialog1.Active = false;
            this.dialog2.Active = true;

            MenuModel target = new MenuModel();
            target.MenuDialogs = this.dialogs;
            target.Up();

            Assert.IsTrue(this.menuItem11.Selected);
            Assert.IsFalse(this.menuItem12.Selected);
            Assert.IsFalse(this.menuItem21.Selected);
            Assert.IsTrue(this.menuItem22.Selected);
        }

        /// <summary>
        ///A test for WaitForKey
        ///</summary>
        [TestMethod()]
        public void WaitForKeyTest()
        {
            MenuModel target = new MenuModel();
            Assert.IsFalse(target.IsWaitingForKey);

            Keys k = Keys.None;
            target.WaitForKey(delegate(Keys key) { k = key; });

            Assert.IsTrue(target.IsWaitingForKey);

            target.SetWaitingKey(Keys.A);

            Assert.IsFalse(target.IsWaitingForKey);
            Assert.AreEqual(Keys.A, k);
        }

        /// <summary>
        ///A test for MenuDialogs
        ///</summary>
        [TestMethod()]
        public void MenuDialogsTest()
        {
            MenuModel target = new MenuModel();
            target.MenuDialogs = this.dialogs;
            Assert.AreEqual(this.dialogs, target.MenuDialogs);
        }
    }
}
