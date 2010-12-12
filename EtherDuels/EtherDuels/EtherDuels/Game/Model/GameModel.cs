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

        public GameModel()
        {
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
            return World;
        }

        public void SetWorld(World world)
        {
            this.world = world;
        }

        public void Update(GameTime gameTime)
        {

        }


    }
}
