using EtherDuels.Game.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework;

using Moq;

namespace GameTest
{
    
    
    /// <summary>
    ///This is a test class for SimplePhysicsAlgorithmTest and is intended
    ///to contain all SimplePhysicsAlgorithmTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SimplePhysicsAlgorithmTest
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
        ///A test for SimplePhysicsAlgorithm Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("EtherDuels.exe")]
        public void SimplePhysicsAlgorithmConstructorTest()
        {
            SimplePhysicsAlgorithm_Accessor target = new SimplePhysicsAlgorithm_Accessor();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        [DeploymentItem("EtherDuels.exe")]
        public void UpdateTest()
        {
            

            SimplePhysicsAlgorithm_Accessor target = new SimplePhysicsAlgorithm_Accessor(); // TODO: Initialize to an appropriate value
            GameTime gameTime = null; // TODO: Initialize to an appropriate value
            target.Update(gameTime);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
