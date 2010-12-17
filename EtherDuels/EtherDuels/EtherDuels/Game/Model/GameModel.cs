using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtherDuels.Game.Model
{
    public class GameModel
    {

        ShortLifespanObjectFactory factory;
        Physics physics;
        Player[] players;
        World world;

        public GameModel(ShortLifeSpanObjectFactory factory, Physics physics, Player[] players, World world)
        {
            this.factory = factory;
            this.physics = physics;
            this.players = players;
            this.world = world;
        }

        public ShortLifespanObjectFactory GetFactory()
        {
            return factory;
        }

        public Player[] GetPlayers()
        {
            return players;
        }

        public World GetWorld()
        {
            return world;
        }

        public void SetWorld(World world)
        {
            this.world = world;
        }

        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < players.GetLength(); i++)
            {
                players[i].Update(gameTime);
            }

            physics.Update(gameTime);

        }


    }
}
