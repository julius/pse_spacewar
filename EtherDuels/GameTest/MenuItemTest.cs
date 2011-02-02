using EtherDuels.Menu.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GameTest
{
    
    
    /// <summary>
    ///This is a test class for MenuItemTest and is intended
    ///to contain all MenuItemTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MenuItemTest
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
        ///A test for IsStaticText = true
        ///</summary>
        [TestMethod()]
        public void IsStaticTextTrueTest()
        {
            MenuItem.ActionHandler actionHandler = null;
            MenuItem.TextProvider textProvider = null;
            MenuItem target = new MenuItem(actionHandler, textProvider);
            Assert.IsTrue(target.IsStaticText);
        }

        /// <summary>
        ///A test for IsStaticText = false
        ///</summary>
        [TestMethod()]
        public void IsStaticTextFalseTest()
        {
            MenuItem.ActionHandler actionHandler = delegate(MenuItem menuItem) { };
            MenuItem.TextProvider textProvider = null;
            MenuItem target = new MenuItem(actionHandler, textProvider);
            Assert.IsFalse(target.IsStaticText);
        }

        /// <summary>
        ///A test for Action
        ///</summary>
        [TestMethod()]
        public void ActionTest()
        {
            int actionCalled = 0;
            MenuItem.ActionHandler actionHandler = delegate(MenuItem menuItem) { actionCalled += 1; };
            MenuItem.TextProvider textProvider = null;
            MenuItem target = new MenuItem(actionHandler, textProvider);
            target.Action();
            Assert.AreEqual(1, actionCalled, "Action should be called exactly once");
        }

        /// <summary>
        ///A test for Selected
        ///</summary>
        [TestMethod()]
        public void SelectedTest()
        {
            MenuItem target = new MenuItem(null, null);
            target.Selected = true;
            Assert.IsTrue(target.Selected);
            target.Selected = false;
            Assert.IsFalse(target.Selected);
        }

        /// <summary>
        ///A test for Text
        ///</summary>
        [TestMethod()]
        public void TextTest()
        {
            string changingString = "Test";
            MenuItem.TextProvider textProvider = delegate() { return "Hello " + changingString; };
            MenuItem target = new MenuItem(null, textProvider);

            Assert.AreEqual("Hello Test", target.Text);

            changingString = "World";
            Assert.AreEqual("Hello World", target.Text);
        }
    }
}
