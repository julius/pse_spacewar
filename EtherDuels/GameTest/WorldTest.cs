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
            Planet planet1 = new Planet();
            WorldObject[] worldObjects = {planet1};

            World target = new World(worldObjects);
            WorldObject spaceship1 = new Spaceship();
            WorldObject spaceship2 = new Spaceship();
            WorldObject projectile = new Projectile();
            WorldObject explosion = new Explosion();
            WorldObject planet2 = new Planet();

            target.AddWorldObject(spaceship1);
            target.AddWorldObject(spaceship2);
            target.AddWorldObject(projectile);
            target.AddWorldObject(explosion);
            target.AddWorldObject(planet2);

            Assert.IsTrue((new List<WorldObject>(target.WorldObjects)).Contains(planet1));
            Assert.IsTrue((new List<WorldObject>(target.WorldObjects)).Contains(spaceship1));
            Assert.IsTrue((new List<WorldObject>(target.WorldObjects)).Contains(spaceship2));
            Assert.IsTrue((new List<WorldObject>(target.WorldObjects)).Contains(projectile));
            Assert.IsTrue((new List<WorldObject>(target.WorldObjects)).Contains(explosion));
            Assert.IsTrue((new List<WorldObject>(target.WorldObjects)).Contains(planet2));
        }

        /// <summary>
        ///A test for RemoveWorldObject
        ///</summary>
        [TestMethod()]
        public void RemoveWorldObjectTest()
        {
            Projectile projectile1 = new Projectile();
            Projectile projectile2 = new Projectile();
            Spaceship spaceship = new Spaceship();
            Planet planet = new Planet();
            Explosion explosion = new Explosion();

            WorldObject[] worldObjects = { projectile1, projectile2, spaceship, planet, explosion };

            World target = new World(worldObjects);
            target.RemoveWorldObject(projectile1);
            target.RemoveWorldObject(projectile2);
            target.RemoveWorldObject(spaceship);
            target.RemoveWorldObject(explosion);

            Assert.IsFalse((new List<WorldObject>(target.WorldObjects)).Contains(projectile1));
            Assert.IsFalse((new List<WorldObject>(target.WorldObjects)).Contains(projectile2));
            Assert.IsFalse((new List<WorldObject>(target.WorldObjects)).Contains(spaceship));
            Assert.IsFalse((new List<WorldObject>(target.WorldObjects)).Contains(explosion));
            Assert.IsTrue((new List<WorldObject>(target.WorldObjects)).Contains(planet));
        }
    }
}
