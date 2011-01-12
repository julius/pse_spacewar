using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtherDuels.Game.Model;
using EtherDuels.Game.View;

namespace EtherDuels.Game
{
    class SimpleGameBuilder: GameBuilder
    {
        private CollisionHandler collisionHandler;
        public CollisionHandler CollisionHandler
        {
            set { this.collisionHandler = value; }
        }

        private PlayerHandler playerHandler;
        public PlayerHandler PlayerHandler
        {
            set { this.playerHandler = value; }
        }

        private Game.Model.InputConfigurationRetriever inputConfigurationRetriever;

        public SimpleGameBuilder(Game.Model.InputConfigurationRetriever inputConfigurationRetriever)
        {
            this.inputConfigurationRetriever = inputConfigurationRetriever;
        }

        public GameModel BuildModel()
        {
            // build game objects
            Planet planet = new Planet();
            Spaceship spaceship1 = new Spaceship();
            Spaceship spaceship2 = new Spaceship();

            Player player1 = new HumanPlayer(1, this.playerHandler, this.inputConfigurationRetriever);
            Player player2 = new HumanPlayer(2, this.playerHandler, this.inputConfigurationRetriever);

            Player[] players = { player1, player2 };
            WorldObject[] worldObjects = { planet, spaceship1, spaceship2 };

            // build game model
            ShortLifespanObjectFactory shortLifespanObjectFactory = new SimpleShortLifespanObjectFactory();
            World world = new World(worldObjects, planet);
            Physics physics = new SimplePhysicsAlgorithm(this.collisionHandler, world);
            GameModel gameModel = new GameModel(shortLifespanObjectFactory, physics, players, world);
            return gameModel;
        }

        public GameView BuildView(GameModel model)
        {
            throw new NotImplementedException();
        }
    }
}
