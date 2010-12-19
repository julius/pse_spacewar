using EtherDuels.Game.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Moq;

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
        private int playerId;
        private Mock<PlayerHandler> mockPlayerHandler;
        private Mock<InputConfigurationRetriever> mockInputConfigurationRetriever;
        private Spaceship spaceship;
        private HumanPlayer target;

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
            this.playerId = 0;
            this.mockPlayerHandler = new Moq.Mock<PlayerHandler>();
            this.mockInputConfigurationRetriever = new Moq.Mock<InputConfigurationRetriever>();
            this.spaceship = new Spaceship();

            mockInputConfigurationRetriever.Setup(b => b.GetFireKey()).Returns(Keys.Space);
            mockInputConfigurationRetriever.Setup(b => b.GetForwardKey()).Returns(Keys.Up);
            mockInputConfigurationRetriever.Setup(b => b.GetBackwardKey()).Returns(Keys.Down);
            mockInputConfigurationRetriever.Setup(b => b.GetLeftKey()).Returns(Keys.Left);
            mockInputConfigurationRetriever.Setup(b => b.GetRightKey()).Returns(Keys.Right);
        }

        /// <summary>
        /// Tests firing a weapon
        /// </summary>
        [TestMethod()]
        public void UpdateFireTest()
        {
            mockPlayerHandler.Setup(b => b.OnFire(this.spaceship));

            this.target = new HumanPlayer(playerId, mockPlayerHandler.Object, mockInputConfigurationRetriever.Object);
            this.target.SetSpaceship(this.spaceship);

            Keys[] keys = { Keys.Space };
            FrameState frameState = new FrameState(null, new KeyboardState(keys));

            target.Update(frameState);

            mockPlayerHandler.Verify(b => b.OnFire(spaceship), Times.Exactly(1));
        }

        /// <summary>
        /// Tests accelerating forward
        /// </summary>
        [TestMethod()]
        public void UpdateAccelerationForward1Test()
        {
            this.target = new HumanPlayer(playerId, null, mockInputConfigurationRetriever.Object);
            this.target.SetSpaceship(this.spaceship);

            Keys[] keys = { Keys.Up };
            GameTime gameTime = new GameTime(new TimeSpan(0, 0, 10, 3, 0), new TimeSpan(0, 0, 0, 0, 100));
            FrameState frameState = new FrameState(gameTime, new KeyboardState(keys));

            spaceship.SetRotation(0);
            spaceship.SetVelocity(new Vector2(0, 0));

            target.Update(frameState);

            Assert.AreEqual(new Vector2(0f, -1f), spaceship.GetVeloctiy());
        }

        /// <summary>
        /// Tests accelerating forward
        /// </summary>
        [TestMethod()]
        public void UpdateAccelerationForward2Test()
        {
            this.target = new HumanPlayer(playerId, null, mockInputConfigurationRetriever.Object);
            this.target.SetSpaceship(this.spaceship);

            Keys[] keys = { Keys.Up };
            GameTime gameTime = new GameTime(new TimeSpan(0, 0, 10, 3, 0), new TimeSpan(0, 0, 0, 0, 100));
            FrameState frameState = new FrameState(gameTime, new KeyboardState(keys));

            spaceship.SetRotation((float)(270.0 * Math.PI / 180.0));
            spaceship.SetVelocity(new Vector2(0, 0));

            target.Update(frameState);

            bool correctX = (spaceship.GetVeloctiy().X < -0.99) && (spaceship.GetVeloctiy().X > -1.001);
            bool correctY = (spaceship.GetVeloctiy().Y > -0.001) && (spaceship.GetVeloctiy().Y < 0.001);
            Assert.AreEqual(true, correctX);
            Assert.AreEqual(true, correctY);
        }

        /// <summary>
        /// Tests accelerating backward
        /// </summary>
        [TestMethod()]
        public void UpdateAccelerationBackward1Test()
        {
            this.target = new HumanPlayer(playerId, null, mockInputConfigurationRetriever.Object);
            this.target.SetSpaceship(this.spaceship);

            Keys[] keys = { Keys.Down };
            GameTime gameTime = new GameTime(new TimeSpan(0, 0, 10, 3, 0), new TimeSpan(0, 0, 0, 0, 100));
            FrameState frameState = new FrameState(gameTime, new KeyboardState(keys));

            spaceship.SetRotation(0);
            spaceship.SetVelocity(new Vector2(0, 0));

            target.Update(frameState);

            Assert.AreEqual(new Vector2(0f, 1f), spaceship.GetVeloctiy());
        }

        /// <summary>
        /// Tests accelerating Backward
        /// </summary>
        [TestMethod()]
        public void UpdateAccelerationBackward2Test()
        {
            this.target = new HumanPlayer(playerId, null, mockInputConfigurationRetriever.Object);
            this.target.SetSpaceship(this.spaceship);

            Keys[] keys = { Keys.Down };
            GameTime gameTime = new GameTime(new TimeSpan(0, 0, 10, 3, 0), new TimeSpan(0, 0, 0, 0, 100));
            FrameState frameState = new FrameState(gameTime, new KeyboardState(keys));

            spaceship.SetRotation((float)(270.0 * Math.PI / 180.0));
            spaceship.SetVelocity(new Vector2(0, 0));

            target.Update(frameState);

            bool correctX = (spaceship.GetVeloctiy().X > 0.99) && (spaceship.GetVeloctiy().X < 1.001);
            bool correctY = (spaceship.GetVeloctiy().Y > -0.001) && (spaceship.GetVeloctiy().Y < 0.001);
            Assert.AreEqual(true, correctX);
            Assert.AreEqual(true, correctY);
        }

        /// <summary>
        /// Tests rotating left
        /// </summary>
        [TestMethod()]
        public void UpdateRotateLeftTest()
        {
            this.target = new HumanPlayer(playerId, null, mockInputConfigurationRetriever.Object);
            this.target.SetSpaceship(this.spaceship);

            Keys[] keys = { Keys.Left };
            GameTime gameTime = new GameTime(new TimeSpan(0, 0, 10, 3, 0), new TimeSpan(0, 0, 0, 0, 100));
            FrameState frameState = new FrameState(gameTime, new KeyboardState(keys));

            spaceship.SetRotation(0);

            target.Update(frameState);

            Assert.AreEqual(-1f, spaceship.GetRotation());
        }

        /// <summary>
        /// Tests rotating right
        /// </summary>
        [TestMethod()]
        public void UpdateRotateRightTest()
        {
            this.target = new HumanPlayer(playerId, null, mockInputConfigurationRetriever.Object);
            this.target.SetSpaceship(this.spaceship);

            Keys[] keys = { Keys.Right };
            GameTime gameTime = new GameTime(new TimeSpan(0, 0, 10, 3, 0), new TimeSpan(0, 0, 0, 0, 200));
            FrameState frameState = new FrameState(gameTime, new KeyboardState(keys));

            spaceship.SetRotation(0);

            target.Update(frameState);

            Assert.AreEqual(2f, spaceship.GetRotation());
        }
    }
}
