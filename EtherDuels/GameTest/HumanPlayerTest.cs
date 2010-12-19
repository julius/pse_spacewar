using EtherDuels.Game.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameTest
{
    
    
    /// <summary>
    ///This is a test class for HumanPlayerTest and is intended
    ///to contain all HumanPlayerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class HumanPlayerTest
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
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            //int playerId = 0;
            //var mockPlayerHandler = new Moq.Mock<PlayerHandler>();
            //var mockInputConfigurationRetriever = new Moq.Mock<InputConfigurationRetriever>();
            //mockInputConfigurationRetriever.Setup(b => b.GetFireKey()).Returns(Keys.Space);

            //HumanPlayer target = new HumanPlayer(playerId, mockPlayerHandler.Object, mockInputConfigurationRetriever.Object);

            //Spaceship spaceship = new Spaceship();
            //target.SetSpaceship(spaceship);

            //Keys[] keys = { Keys.Space };
            //var keyboardState = new KeyboardState(keys);

            //GameTime gameTime = null; // TODO: Initialize to an appropriate value
            //FrameState frameState = new FrameState(gameTime, keyboardState);
            
            //target.Update(frameState);

            //mockPlayerHandler.Verify(b => b.OnFire(spaceship));
        }
    }
}
