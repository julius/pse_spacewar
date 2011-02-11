using EtherDuels.Game.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Moq;
using EtherDuels;
using EtherDuels.Config;

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
        private Weapon[] weapons;

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

            weapons = (Weapon[])Enum.GetValues(typeof(Weapon));

            // default keyboard configuration for a player
            mockInputConfigurationRetriever.Setup(b => b.Fire).Returns(Keys.Space);
            mockInputConfigurationRetriever.Setup(b => b.Forward).Returns(Keys.Up);
            mockInputConfigurationRetriever.Setup(b => b.Backward).Returns(Keys.Down);
            mockInputConfigurationRetriever.Setup(b => b.Left).Returns(Keys.Left);
            mockInputConfigurationRetriever.Setup(b => b.Right).Returns(Keys.Right);
            mockInputConfigurationRetriever.Setup(b => b.NextWeapon).Returns(Keys.P);
            mockInputConfigurationRetriever.Setup(b => b.PrevWeapon).Returns(Keys.O);
        }

        /// <summary>
        /// Tests firing a weapon
        /// </summary>
        [TestMethod()]
        public void UpdateFireTest()
        {
            mockPlayerHandler.Setup(b => b.OnFire(this.spaceship));

            this.target = new HumanPlayer(playerId, mockPlayerHandler.Object, Color.Blue, mockInputConfigurationRetriever.Object);
            this.target.Spaceship = this.spaceship;

            Keys[] keys = { Keys.Space };
            KeyboardState keyboardState = new KeyboardState(keys);
            FrameState frameState = new FrameState(null, new KeyboardState(keys));

            target.Update(frameState);

            mockPlayerHandler.Verify(b => b.OnFire(spaceship), Times.Exactly(1));
        }

        /// <summary>
        /// Tests switching to the next weapon.
        /// </summary>
        [TestMethod()]
        public void UpdateNextWeaponTest()
        {
            this.target = new HumanPlayer(playerId, mockPlayerHandler.Object, Color.Blue, mockInputConfigurationRetriever.Object);
            this.target.Spaceship = this.spaceship;
            
            Weapon currentWeapon = weapons[0];
            spaceship.CurrentWeapon = weapons[0];

            Keys[] keys = { Keys.P };
            FrameState frameState = new FrameState(null, new KeyboardState(keys));

            for (int i = 1; i < 7; i++)
            {
                currentWeapon = weapons[i % weapons.Length];
                target.Update(frameState);
                Assert.AreEqual(currentWeapon, spaceship.CurrentWeapon);
            } 
        }

        /// <summary>
        /// Tests switching to the previous weapon.
        /// </summary>
        [TestMethod()]
        public void UpdatePrevWeaponTest()
        {
            this.target = new HumanPlayer(playerId, mockPlayerHandler.Object, Color.Blue, mockInputConfigurationRetriever.Object);
            this.target.Spaceship = this.spaceship;

            Weapon currentWeapon = weapons[11 % weapons.Length];
            spaceship.CurrentWeapon = weapons[11 % weapons.Length];

            Keys[] keys = { Keys.O };
            FrameState frameState = new FrameState(null, new KeyboardState(keys));

            for (int i = 10; i >= 0; i--)
            {
                currentWeapon = weapons[Math.Abs(i % weapons.Length)];
                target.Update(frameState);
                Assert.AreEqual(currentWeapon, spaceship.CurrentWeapon);
            }
        }

        

        /// <summary>
        /// Tests accelerating forward
        /// </summary>
        [TestMethod()]
        public void UpdateAccelerationForward1Test()
        {
            this.target = new HumanPlayer(playerId, null, Color.Blue, mockInputConfigurationRetriever.Object);
            this.target.Spaceship = this.spaceship;
            spaceship.Rotation = 0;
            spaceship.Velocity = new Vector2(0, 0);

            Keys[] keys = { Keys.Up };
            GameTime gameTime = new GameTime(new TimeSpan(0, 0, 10, 3, 0), new TimeSpan(0, 0, 0, 0, 1));
            FrameState frameState = new FrameState(gameTime, new KeyboardState(keys));
            float speed;
            Vector2 velocity;

            for (int i = 0; i < 20; i++)
            {
                speed = (float) gameTime.ElapsedGameTime.TotalMilliseconds * 0.1f;
                velocity = spaceship.Velocity;
                velocity.X += (float)Math.Sin(this.spaceship.Rotation) * speed;
                velocity.Y -= (float)Math.Cos(this.spaceship.Rotation) * speed;

                target.Update(frameState);

                Assert.AreEqual(velocity, spaceship.Velocity);

                // construct a new random TimeSpan for the next test
                gameTime = new GameTime(new TimeSpan(0, 0, 10, 3, 0), new TimeSpan(0, 0, 0, 0, i*(87 + i)));
            }
        }

        /// <summary>
        /// Tests accelerating forward
        /// </summary>
        [TestMethod()]
        public void UpdateAccelerationForward2Test()
        {
            this.target = new HumanPlayer(playerId, null, Color.Blue, mockInputConfigurationRetriever.Object);
            this.target.Spaceship = this.spaceship;

            Keys[] keys = { Keys.Up };
            GameTime gameTime = new GameTime(new TimeSpan(0, 0, 10, 3, 0), new TimeSpan(0, 0, 0, 0, 100));
            FrameState frameState = new FrameState(gameTime, new KeyboardState(keys));

            spaceship.Rotation = (float)(270.0 * Math.PI / 180.0);
            spaceship.Velocity = new Vector2(0, 0);

            target.Update(frameState);

            bool correctX = (spaceship.Velocity.X < -9.99) && (spaceship.Velocity.X > -10.001);
            bool correctY = (spaceship.Velocity.Y > -0.001) && (spaceship.Velocity.Y < 0.001);
            Assert.AreEqual(true, correctX);
            Assert.AreEqual(true, correctY);
        }

        /// <summary>
        /// Tests accelerating backward
        /// </summary>
        [TestMethod()]
        public void UpdateAccelerationBackward1Test()
        {
            /*this.target = new HumanPlayer(playerId, null, Color.Blue, mockInputConfigurationRetriever.Object);
            this.target.Spaceship = this.spaceship;

            Keys[] keys = { Keys.Down };
            GameTime gameTime = new GameTime(new TimeSpan(0, 0, 10, 3, 0), new TimeSpan(0, 0, 0, 0, 100));
            FrameState frameState = new FrameState(gameTime, new KeyboardState(keys));

            spaceship.Rotation = 0;
            spaceship.Velocity = new Vector2(0, 0);

            target.Update(frameState);

            Assert.AreEqual(new Vector2(0f, 10f), spaceship.Velocity);*/

            this.target = new HumanPlayer(playerId, null, Color.Blue, mockInputConfigurationRetriever.Object);
            this.target.Spaceship = this.spaceship;
            spaceship.Rotation = 0;
            spaceship.Velocity = new Vector2(0, 0);

            Keys[] keys = { Keys.Up };
            GameTime gameTime = new GameTime(new TimeSpan(0, 0, 10, 3, 0), new TimeSpan(0, 0, 0, 0, 1));
            FrameState frameState = new FrameState(gameTime, new KeyboardState(keys));
            float speed;
            Vector2 velocity;

            for (int i = 0; i < 20; i++)
            {
                speed = (float)gameTime.ElapsedGameTime.TotalMilliseconds * -0.1f;
                velocity = spaceship.Velocity;
                velocity.X += (float)Math.Sin(this.spaceship.Rotation) * speed;
                velocity.Y -= (float)Math.Cos(this.spaceship.Rotation) * speed;

                target.Update(frameState);

                Assert.AreEqual(velocity, spaceship.Velocity);

                // construct a new random TimeSpan for the next test
                gameTime = new GameTime(new TimeSpan(0, 0, 10, 3, 0), new TimeSpan(0, 0, 0, 0, i * (69 + i)));
            }
        }

        /// <summary>
        /// Tests accelerating Backward
        /// </summary>
        [TestMethod()]
        public void UpdateAccelerationBackward2Test()
        {
            this.target = new HumanPlayer(playerId, null, Color.Blue, mockInputConfigurationRetriever.Object);
            this.target.Spaceship = this.spaceship;

            Keys[] keys = { Keys.Down };
            GameTime gameTime = new GameTime(new TimeSpan(0, 0, 10, 3, 0), new TimeSpan(0, 0, 0, 0, 100));
            FrameState frameState = new FrameState(gameTime, new KeyboardState(keys));

            spaceship.Rotation = (float)(270.0 * Math.PI / 180.0);
            spaceship.Velocity = new Vector2(0, 0);

            target.Update(frameState);

            bool correctX = (spaceship.Velocity.X > 9.99) && (spaceship.Velocity.X < 10.001);
            bool correctY = (spaceship.Velocity.Y > -0.001) && (spaceship.Velocity.Y < 0.001);
            Assert.AreEqual(true, correctX);
            Assert.AreEqual(true, correctY);
        }

        /// <summary>
        /// Tests rotating left
        /// </summary>
        [TestMethod()]
        public void UpdateRotateLeftTest()
        {
            /*this.target = new HumanPlayer(playerId, null, Color.Blue, mockInputConfigurationRetriever.Object);
            this.target.Spaceship = this.spaceship;

            Keys[] keys = { Keys.Left };
            GameTime gameTime = new GameTime(new TimeSpan(0, 0, 10, 3, 0), new TimeSpan(0, 0, 0, 0, 100));
            FrameState frameState = new FrameState(gameTime, new KeyboardState(keys));

            spaceship.Rotation = 0;

            target.Update(frameState);

            Assert.AreEqual(-0.3f, spaceship.Rotation);*/

            this.target = new HumanPlayer(playerId, null, Color.Blue, mockInputConfigurationRetriever.Object);
            this.target.Spaceship = this.spaceship;
            spaceship.Rotation = 0;

            Keys[] keys = { Keys.Up };
            GameTime gameTime = new GameTime(new TimeSpan(0, 0, 10, 3, 0), new TimeSpan(0, 0, 0, 0, 1));
            FrameState frameState = new FrameState(gameTime, new KeyboardState(keys));
            float speed;
            float rotation;

            for (int i = 0; i < 20; i++)
            {
                speed = ((float)frameState.GameTime.ElapsedGameTime.TotalMilliseconds) * 0.003f;
                rotation = spaceship.Rotation + (speed * -1f);

                target.Update(frameState);

                Assert.AreEqual(rotation, spaceship.Rotation);

                // construct a new random TimeSpan for the next test
                gameTime = new GameTime(new TimeSpan(0, 0, 10, 3, 0), new TimeSpan(0, 0, 0, 0, i * (76 + i)));
            }
        }

        /// <summary>
        /// Tests rotating right
        /// </summary>
        [TestMethod()]
        public void UpdateRotateRightTest()
        {
            /*this.target = new HumanPlayer(playerId, null, Color.Blue, mockInputConfigurationRetriever.Object);
            this.target.Spaceship = this.spaceship;

            Keys[] keys = { Keys.Right };
            GameTime gameTime = new GameTime(new TimeSpan(0, 0, 10, 3, 0), new TimeSpan(0, 0, 0, 0, 200));
            FrameState frameState = new FrameState(gameTime, new KeyboardState(keys));

            spaceship.Rotation = 0;

            target.Update(frameState);

            Assert.AreEqual(0.6f, spaceship.Rotation);*/

            this.target = new HumanPlayer(playerId, null, Color.Blue, mockInputConfigurationRetriever.Object);
            this.target.Spaceship = this.spaceship;
            spaceship.Rotation = 0;

            Keys[] keys = { Keys.Up };
            GameTime gameTime = new GameTime(new TimeSpan(0, 0, 10, 3, 0), new TimeSpan(0, 0, 0, 0, 1));
            FrameState frameState = new FrameState(gameTime, new KeyboardState(keys));
            float speed;
            float rotation;

            for (int i = 0; i < 20; i++)
            {
                speed = ((float)frameState.GameTime.ElapsedGameTime.TotalMilliseconds) * 0.003f;
                rotation = spaceship.Rotation + (speed * 1f);

                target.Update(frameState);

                Assert.AreEqual(rotation, spaceship.Rotation);

                // construct a new random TimeSpan for the next test
                gameTime = new GameTime(new TimeSpan(0, 0, 10, 3, 0), new TimeSpan(0, 0, 0, 0, i * (74 + i)));
            }
        }
    }
}
