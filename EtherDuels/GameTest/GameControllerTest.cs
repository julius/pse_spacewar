using EtherDuels.Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EtherDuels.Game.Model;
using Moq;
using EtherDuels.Config;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using EtherDuels.Game.View;
using Microsoft.Xna.Framework.Input;
using EtherDuels;

namespace GameTest
{
    
    
    /// <summary>
    ///This is a test class for GameControllerTest and is intended
    ///to contain all GameControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GameControllerTest
    {
        private GameController target;
        private Mock<GameBuilder> mockGameBuilder;
        private Mock<GameHandler> mockGameHandler;
        private Mock<ShortLifespanObjectFactory> mockFactory;
        private Mock<Physics> mockPhysics;
        private Spaceship object1;

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

        [TestInitialize()]
        public void Initialize()
        {
            mockPhysics = new Mock<Physics>();
            mockGameHandler = new Mock<GameHandler>();
            mockGameBuilder = new Mock<GameBuilder>();
            mockFactory = new Mock<ShortLifespanObjectFactory>();
            object1 = new Spaceship();
        }

        /// <summary>
        ///A test for OnFire
        ///</summary>
        [TestMethod()]
        public void OnFireTest()
        {
            // configure object1
            object1.Position = new Vector2(100.0f, 100.0f);
            Weapon weapon = Weapon.Rocket;
            object1.CurrentWeapon = weapon;

            // create world mock
            WorldObject[] worldObjects = { object1 };
            WorldObject[][] mockParams = { worldObjects };
            Mock<World> mockWorld = new Mock<World>(mockParams);

            // setup SLsO factory
            Projectile projectile = new Projectile();
            mockFactory.Setup(m => m.CreateProjectile(weapon)).Returns(projectile);
            Mock<WorldObjectView> mockProjectileView = new Mock<WorldObjectView>(projectile);
            mockFactory.Setup(m => m.CreateProjectileView(weapon, projectile)).Returns(mockProjectileView.Object);

            // create GameModel
            GameModel model = new GameModel(mockFactory.Object, mockPhysics.Object, new List<Player>(), mockWorld.Object);

            // setup GameView
            Mock<WorldView> mockWorldView = new Mock<WorldView>(mockWorld.Object);
            Mock<GameView> mockGameView = new Mock<GameView>(model, mockWorldView.Object);
            mockGameView.SetupGet(m => m.WorldView).Returns(mockWorldView.Object);

            // setup GameBuilder
            mockGameBuilder.Setup(m => m.BuildModel()).Returns(model);
            mockGameBuilder.Setup(m => m.BuildView(model)).Returns(mockGameView.Object);

            // setup target and test it
            target = new GameController(mockGameBuilder.Object, mockGameHandler.Object);
            target.CreateGame();
            target.OnFire(object1);

            // verify correct rotation of the projectile
            Assert.AreEqual(projectile.Rotation, object1.Rotation);

            // calculate and verify the expected position of the projectile
            Vector2 expectedProjectilePos;
            expectedProjectilePos.X = object1.Position.X + (float)Math.Sin(object1.Rotation) * (object1.Radius + projectile.Radius + 1);
            expectedProjectilePos.Y = object1.Position.Y - (float)Math.Cos(object1.Rotation) * (object1.Radius + projectile.Radius + 1);
            Assert.AreEqual(expectedProjectilePos, projectile.Position);

            // calculate and verify the expected velocity of the projectile
            int velocityFactor = 100;
            switch (weapon) 
            {
                case Weapon.Laser: { velocityFactor = target.VelocityLaser; break; }
                case Weapon.Rocket: { velocityFactor = target.VelocityRocket; break; }
            }

            Vector2 expectedProjectileVelocity = object1.Velocity;
            expectedProjectileVelocity.X += (float)Math.Sin(object1.Rotation) * velocityFactor;
            expectedProjectileVelocity.Y -= (float)Math.Cos(object1.Rotation) * velocityFactor;
            Assert.AreEqual(expectedProjectileVelocity, projectile.Velocity);

            // verify the called mock methods
            mockFactory.Verify(m => m.CreateProjectile(weapon), Times.Exactly(1));
            mockFactory.Verify(m => m.CreateProjectileView(weapon, projectile), Times.Exactly(1));
            mockWorld.Verify(m => m.AddWorldObject(projectile), Times.Exactly(1));
            mockWorldView.Verify(m => m.AddWorldObjectView(mockProjectileView.Object), Times.Exactly(1));
        }

        /// <summary>
        ///A test for OnCollision
        ///</summary>
        [TestMethod()]
        public void OnCollisionTest()
        {
            // configure object1
            object1.Attack = 0;
            object1.Position = new Vector2(100.0f, 100.0f);
            
            // create and configure object2
            WorldObject object2 = new WorldObject();
            object2.Attack = 1000;
            object2.Position = new Vector2(100.0f, 100.0f);

            // initialize players
            Mock<Player> mockPlayer1 = new Mock<Player>();
            mockPlayer1.SetupGet(m => m.Spaceship).Returns(object1);
            mockPlayer1.SetupGet(m => m.PlayerId).Returns(0);
            Keys[] keys = { Keys.Space };
            Mock<Player> mockPlayer2 = new Mock<Player>();
            mockPlayer2.SetupGet(m => m.PlayerId).Returns(1);
            List<Player> players = new List<Player>();
            players.Add(mockPlayer1.Object);
            players.Add(mockPlayer2.Object);

            // create world mock
            WorldObject[] worldObjects = { object1, object2 };
            WorldObject[][] mockParams = { worldObjects };
            Mock<World> mockWorld = new Mock<World>(mockParams);

            // setup SLsO factory
            Explosion explosion = new Explosion();
            mockFactory.Setup(m => m.CreateExplosion(null)).Returns(explosion);
            Mock<WorldObjectView> mockExplosionView = new Mock<WorldObjectView>(explosion);
            mockFactory.Setup(m => m.CreateExplosionView(explosion)).Returns(mockExplosionView.Object);

            // create GameModel
            GameModel model = new GameModel(mockFactory.Object, mockPhysics.Object, players, mockWorld.Object);

            // setup GameView
            Mock<WorldView> mockWorldView = new Mock<WorldView>(mockWorld.Object);
            Mock<GameView> mockGameView = new Mock<GameView>(model, mockWorldView.Object);
            mockGameView.SetupGet(m => m.WorldView).Returns(mockWorldView.Object);
            
            // setup GameBuilder
            mockGameBuilder.Setup(m => m.BuildModel()).Returns(model);
            mockGameBuilder.Setup(m => m.BuildView(model)).Returns(mockGameView.Object);

            // setup GameHandler      
            mockGameHandler.Setup(m => m.OnGameEnded(mockPlayer2.Object.PlayerId));
                        
            // setup target and test it
            target = new GameController(mockGameBuilder.Object, mockGameHandler.Object);
            target.CreateGame();
            target.OnCollision(object1, object2);

            //calculate and verify the expected position of the explosion
            Vector2 deltaPos = new Vector2(object2.Position.X - object1.Position.X, object2.Position.Y - object1.Position.Y);
            Vector2 expectedExplosionPos = new Vector2(object1.Position.X + deltaPos.X / 2, object1.Position.Y + deltaPos.Y / 2);
            Assert.AreEqual(expectedExplosionPos, explosion.Position);

            // verify the called mock methods
            mockFactory.Verify(m => m.CreateExplosion(null), Times.Exactly(1));
            mockFactory.Verify(m => m.CreateExplosionView(explosion), Times.Exactly(1));
            mockWorld.Verify(m => m.AddWorldObject(explosion), Times.Exactly(1));
            mockWorldView.Verify(m => m.AddWorldObjectView(mockExplosionView.Object), Times.Exactly(1));
            mockWorld.Verify(m => m.RemoveWorldObject(object1), Times.Exactly(1));
            mockGameHandler.Verify(m => m.OnGameEnded(mockPlayer2.Object.PlayerId), Times.Exactly(1));
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            // create world mock
            WorldObject[] worldObjects = { object1 };
            WorldObject[][] mockParams = { worldObjects };
            Mock<World> mockWorld = new Mock<World>(mockParams);

            // setup FrameState
            GameTime gameTime = new GameTime(new TimeSpan(0, 0, 10, 3, 0), new TimeSpan(0, 0, 0, 0, 100));
            Keys[] keys = { Keys.Escape };
            Mock<FrameState> mockFrameState = new Mock<FrameState>(gameTime, new KeyboardState(keys));
            mockFrameState.SetupGet(m => m.GameTime).Returns(gameTime);

            // create GameModel
            Mock<GameModel> mockGameModel = new Mock<GameModel>(null, null, null, null);
            mockGameModel.Setup(m => m.Update(mockFrameState.Object));

            // setup GameView
            Mock<WorldView> mockWorldView = new Mock<WorldView>(mockWorld.Object);
            Mock<GameView> mockGameView = new Mock<GameView>(mockGameModel.Object, mockWorldView.Object);
            mockGameView.SetupGet(m => m.WorldView).Returns(mockWorldView.Object);

            // setup GameBuilder
            mockGameBuilder.Setup(m => m.BuildModel()).Returns(mockGameModel.Object);
            mockGameBuilder.Setup(m => m.BuildView(mockGameModel.Object)).Returns(mockGameView.Object);

            // setup GameHandler      
            mockGameHandler.Setup(m => m.OnGamePaused());

            // setup target and test it
            target = new GameController(mockGameBuilder.Object, mockGameHandler.Object);
            target.CreateGame();
            target.Update(mockFrameState.Object);

            // verify the called mock methods
            mockGameHandler.Verify(m => m.OnGamePaused(), Times.Exactly(1));
            mockGameModel.Verify(m => m.Update(mockFrameState.Object), Times.Exactly(1));
        }
    }
}
