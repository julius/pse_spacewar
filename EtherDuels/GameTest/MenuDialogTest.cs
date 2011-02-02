using EtherDuels.Menu.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GameTest
{
    /// <summary>
    ///This is a test class for MenuDialogTest and is intended
    ///to contain all MenuDialogTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MenuDialogTest
    {
        private TestContext testContextInstance;

        private int action1;
        private int action2;
        private int action3;
        private MenuItem menuItem1;
        private MenuItem menuItem2;
        private MenuItem menuItem3;
        private MenuItem menuItem4;
        private MenuItem[] menuItems;

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
            this.action1 = 0;
            this.menuItem1 = new MenuItem(delegate(MenuItem m) { this.action1 += 1; }, null);
            this.action2 = 0;
            this.menuItem2 = new MenuItem(delegate(MenuItem m) { this.action2 += 1; }, null);
            this.action3 = 0;
            this.menuItem3 = new MenuItem(delegate(MenuItem m) { this.action3 += 1; }, null);
            this.menuItem4 = new MenuItem(null, null);

            MenuItem[] menuItems = { menuItem1, menuItem2, menuItem3, menuItem4 };
            this.menuItems = menuItems;
        }

        /// <summary>
        ///A test for Action
        ///</summary>
        [TestMethod()]
        public void ActionTest()
        {
            this.menuItem2.Selected = true;
            MenuDialog target = new MenuDialog(menuItems);
            target.Action();
            Assert.AreEqual(0, action1);
            Assert.AreEqual(1, action2);
            Assert.AreEqual(0, action3);
        }

        /// <summary>
        ///A test for Down
        ///</summary>
        [TestMethod()]
        public void DownTest()
        {
            this.menuItem3.Selected = true;
            MenuDialog target = new MenuDialog(menuItems);

            target.Down();
            Assert.IsTrue(this.menuItem1.Selected);
            Assert.IsFalse(this.menuItem2.Selected);
            Assert.IsFalse(this.menuItem3.Selected);
            Assert.IsFalse(this.menuItem4.Selected);

            target.Down();
            Assert.IsFalse(this.menuItem1.Selected);
            Assert.IsTrue(this.menuItem2.Selected);
            Assert.IsFalse(this.menuItem3.Selected);
            Assert.IsFalse(this.menuItem4.Selected);
        }

        /// <summary>
        ///A test for Up
        ///</summary>
        [TestMethod()]
        public void UpTest()
        {
            this.menuItem1.Selected = true;
            MenuDialog target = new MenuDialog(menuItems);

            target.Up();
            Assert.IsFalse(this.menuItem1.Selected);
            Assert.IsFalse(this.menuItem2.Selected);
            Assert.IsTrue(this.menuItem3.Selected);
            Assert.IsFalse(this.menuItem4.Selected);

            target.Up();
            Assert.IsFalse(this.menuItem1.Selected);
            Assert.IsTrue(this.menuItem2.Selected);
            Assert.IsFalse(this.menuItem3.Selected);
            Assert.IsFalse(this.menuItem4.Selected);
        }

        /// <summary>
        ///A test for Active
        ///</summary>
        [TestMethod()]
        public void ActiveTest()
        {
            MenuDialog target = new MenuDialog(menuItems);
            Assert.IsFalse(target.Active);

            target.Active = true;
            Assert.IsTrue(target.Active);

            target.Active = false;
            Assert.IsFalse(target.Active);
        }

        /// <summary>
        ///A test for MenuItems
        ///</summary>
        [TestMethod()]
        public void MenuItemsTest()
        {
            MenuDialog target = new MenuDialog(menuItems);
            Assert.AreEqual(this.menuItems, target.MenuItems);
        }
    }
}
