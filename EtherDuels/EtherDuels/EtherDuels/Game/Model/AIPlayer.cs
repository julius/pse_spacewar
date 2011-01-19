using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using EtherDuels.Config;

namespace EtherDuels.Game.Model
{
    class AIPlayer : Player
    {
        private InputConfigurationRetriever inputConfigurationRetriever;
        private World world;
        private Planet planet;

        public AIPlayer(int playerId, PlayerHandler playerHandler, Color playerColor, World world) : base(playerId, playerHandler, playerColor)
        {
            this.world = world;
            planet = world.Planets[0];
        }

        public override void Update(FrameState frameState)
        {
            throw new NotImplementedException();
        }

        private void UpdateVelocity()
        {
            Vector2 distance = new Vector2(spaceship.Position.X - planet.Position.X, spaceship.Position.Y - planet.Position.Y);

        }
    }
}
