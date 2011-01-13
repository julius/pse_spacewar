using EtherDuels.Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EtherDuels.Game.Model;
using Moq;
using Microsoft.Xna.Framework;

namespace GameTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "GameControllerTest" und soll
    ///alle GameControllerTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class GameControllerTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Ruft den Testkontext auf, der Informationen
        ///über und Funktionalität für den aktuellen Testlauf bietet, oder legt diesen fest.
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

        #region Zusätzliche Testattribute
        // 
        //Sie können beim Verfassen Ihrer Tests die folgenden zusätzlichen Attribute verwenden:
        //
        //Mit ClassInitialize führen Sie Code aus, bevor Sie den ersten Test in der Klasse ausführen.
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Mit ClassCleanup führen Sie Code aus, nachdem alle Tests in einer Klasse ausgeführt wurden.
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Mit TestInitialize können Sie vor jedem einzelnen Test Code ausführen.
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Mit TestCleanup können Sie nach jedem einzelnen Test Code ausführen.
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Ein Test für "OnCollision"
        ///</summary>
        [TestMethod()]
        public void OnCollisionTest()
        {
            Mock<GameBuilder> gameBuilder = new Moq.Mock<GameBuilder>();
            Mock<GameHandler> gameHandler = new Moq.Mock<GameHandler>();
            GameController target = new GameController(gameBuilder.Object, gameHandler.Object);
            WorldObject collisionObject1 = new Spaceship();
            collisionObject1.Position = new Vector2(13, 25);
            collisionObject1.Radius = 5;
            WorldObject collisionObject2 = new Spaceship();
            collisionObject2.Position = new Vector2(20, 30);
            collisionObject2.Radius = 2;

            target.OnCollision(collisionObject1, collisionObject2);
            //TODO
        }
    }
}
