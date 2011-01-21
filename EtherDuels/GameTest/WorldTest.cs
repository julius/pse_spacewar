using EtherDuels.Game.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Moq;

namespace GameTest
{
    
    
    /// <summary>
    ///This is a test class for WorldTest and is intended
    ///to contain all WorldTest Unit Tests
    ///</summary>
    [TestClass()]
    public class WorldTest
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
        private Mock<List<WorldObject>> mockWorldObjects;

        [TestInitialize()]
        public void Initialize()
        {
        }

        /// <summary>
        ///A test for AddWorldObject
        ///</summary>
        [TestMethod()]
        public void AddWorldObjectTest()
        {
            WorldObject[] worldObjects = new WorldObject[0];
            Planet planet = new Planet();

            World target = new World(worldObjects);
            WorldObject spaceship1 = new Spaceship();
            target.AddWorldObject(spaceship1);

            Assert.IsTrue((new List<WorldObject>(target.WorldObjects)).Contains(spaceship1));
        }

        /// <summary>
        ///A test for RemoveWorldObject
        ///</summary>
        [TestMethod()]
        public void RemoveWorldObjectTest()
        {
            Projectile projectile1 = new Projectile();
            WorldObject[] worldObjects = { projectile1 };
            Planet planet = new Planet();

            World target = new World(worldObjects);
            target.RemoveWorldObject(projectile1);

            Assert.IsFalse((new List<WorldObject>(target.WorldObjects)).Contains(projectile1));
        }
    }
}
