using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace EtherDuels.Game.Model
{
    public class GameModel
    {
        private ShortLifespanObjectFactory factory;
        private Physics physics;
        private Player[] players;
        private World world;

        public GameModel(ShortLifespanObjectFactory factory, Physics physics, Player[] players, World world)
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

        public void Update(FrameState frameState)
        {
            for (int i = 0; i < players.Length; i++)
            {
                players[i].Update(frameState);
            }

            physics.Update(frameState.GameTime);
        }

        public World World
        {
            get { return world; }
            set { world = value; }
        }
    }
}
