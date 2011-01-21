using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtherDuels.Game;
using EtherDuels.Game.Model;
using EtherDuels.Config;
using Microsoft.Xna.Framework;
using EtherDuels.Game.View;
using Microsoft.Scripting.Hosting;

namespace EtherDuels.Ruby
{
    class RubyGameBuilder: GameBuilder
    {
        private GameAssets gameAssets = GameAssets.Instance;

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

        private Configuration configuration;
        private string path;

        public RubyGameBuilder(string path, Configuration configuration)
        {
            this.path = path;
            this.configuration = configuration;
        }

        class RubyPhysic
        {
            public double G;
            public float N;

            public RubyPhysic(double G, float N)
            {
                this.G = G;
                this.N = N;
            }
        }

        public GameModel BuildModel()
        {
            // build game objects
            LevelBuilder levelBuilder = new LevelBuilder(this.configuration, this.playerHandler);
            ScriptEngine scriptEngine = IronRuby.Ruby.CreateEngine();
            ScriptScope scriptScope = scriptEngine.CreateScope();
            scriptScope.SetVariable("level", levelBuilder);
            scriptScope.SetVariable("physic", new RubyPhysic(GameAssets.G, GameAssets.N));
            try
            {
                ScriptSource source = scriptEngine.CreateScriptSourceFromFile(this.path);
                source.Compile();
                source.Execute(scriptScope);
            }
            catch (Exception e)
            {
                string errorMessage = "[" + this.path + "]\nError: " + e.Message;
                System.Windows.Forms.MessageBox.Show(errorMessage);
            }

            // build ShortLifespanObjectFactory
            ShortLifespanObjectFactory shortLifespanObjectFactory = new SimpleShortLifespanObjectFactory();

            // build game model
            World world = new World(levelBuilder.WorldObjects);
            Physics physics = new SimplePhysicsAlgorithm(this.collisionHandler, world, configuration);
            GameModel gameModel = new GameModel(shortLifespanObjectFactory, physics, levelBuilder.Players, world);
            return gameModel;
        }

        public GameView BuildView(GameModel model)
        {
            WorldView worldView = new WorldView(model.World);
            GameView gameView;
            int i = 0; // to count the planets in the worldobject list

            foreach (WorldObject worldObject in model.World.WorldObjects)
            {
                if (worldObject is Spaceship)
                {
                    Player player = GetPlayerOfSpaceship(model, (Spaceship)worldObject);
                    worldView.AddWorldObjectView(new WorldObjectView(gameAssets.GetColoredSpaceship(player.PlayerColor), worldObject));
                    //worldView.AddWorldObjectView(new WorldObjectView(gameAssets.ModelSpaceship, worldObject));
                }
                else if (worldObject is Planet)
                {
                    worldView.AddWorldObjectView(new WorldObjectView(gameAssets.GetModelPlanets()[i], worldObject));
                    i++;
                }
                else if (worldObject is Projectile)
                {
                    worldView.AddWorldObjectView(new WorldObjectView(gameAssets.ModelRocket, worldObject));
                }
            }

            gameView = new GameView(model, worldView);

            return gameView;
        }

        private Player GetPlayerOfSpaceship(GameModel gameModel, Spaceship spaceship)
        {
            foreach (Player player in gameModel.Players)
            {
                if (player.Spaceship == spaceship)
                {
                    return player;
                }
            }
            return null;
        }
    }
}
