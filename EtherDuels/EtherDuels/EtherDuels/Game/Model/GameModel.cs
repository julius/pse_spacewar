using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace EtherDuels.Game.Model
{
    public class GameModel
    {

        ShortLifespanObjectFactory factory;
        Physics physics;
        Player[] players;
        World world;

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

        public World GetWorld()
        {
            return world;
        }

        public void SetWorld(World world)
        {
            this.world = world;
        }

        public void Update(FrameState frameState)
        {
            for (int i = 0; i < players.Length; i++)
            {
                players[i].Update(frameState);
            }

            physics.Update(frameState.GetGameTime());
        }


    }
}
