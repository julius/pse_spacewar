using EtherDuels.Game.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework;
using EtherDuels.Game.View;
using EtherDuels;
using Moq;

namespace GameTest
{
    
    
    /// <summary>
    ///This is a test class for SimpleShortLifespanObjectFactoryTest and is intended
    ///to contain all SimpleShortLifespanObjectFactoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SimpleShortLifespanObjectFactoryTest
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
        ///A test for CreateExplosion
        ///</summary>
        [TestMethod()]
        public void CreateExplosionTest()
        {
            SimpleShortLifespanObjectFactory target = new SimpleShortLifespanObjectFactory();
            Mock<GameTime> gameTime = new Moq.Mock<GameTime>();
            Explosion actual = target.CreateExplosion(gameTime.Object);
            Assert.AreEqual(gameTime.Object.TotalGameTime, actual.CreationTime);  // macht der hier überhaupt was?
        }

        /// <summary>
        ///A test for CreateExplosionView
        ///</summary>
        [TestMethod()]
        public void CreateExplosionViewTest()
        {
            SimpleShortLifespanObjectFactory target = new SimpleShortLifespanObjectFactory();
            Explosion explosion = new Explosion();
            WorldObjectView expected = new WorldObjectView(explosion);
            WorldObjectView actual = target.CreateExplosionView(explosion);
            Assert.AreEqual(expected, actual);  // geht nicht, zwar selber typ, aber nicht identisch
        }

        /// <summary>
        ///A test for CreateProjectile
        ///</summary>
        [TestMethod()]
        public void CreateProjectileTest()
        {
            SimpleShortLifespanObjectFactory target = new SimpleShortLifespanObjectFactory(); // TODO: Initialize to an appropriate value
            Weapon weapon = new Weapon(); // TODO: Initialize to an appropriate value
            Projectile expected = null; // TODO: Initialize to an appropriate value
            Projectile actual;
            actual = target.CreateProjectile(weapon);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CreateProjectileview
        ///</summary>
        [TestMethod()]
        public void CreateProjectileviewTest()
        {
            SimpleShortLifespanObjectFactory target = new SimpleShortLifespanObjectFactory(); // TODO: Initialize to an appropriate value
            Weapon weapon = new Weapon(); // TODO: Initialize to an appropriate value
            Projectile projectile = null; // TODO: Initialize to an appropriate value
            WorldObjectView expected = null; // TODO: Initialize to an appropriate value
            WorldObjectView actual;
            actual = target.CreateProjectileview(weapon, projectile);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
