using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace EtherDuels.Game.Model
{
    abstract class Player
    {
        // TODO Constructor

        public int GetPlayerId()
        {
            // TODO
            return 0;
        }

        public int GetPoints()
        {
            // TODO
            return 0;
        }

        public void SetPoints(int points)
        {
            // TODO
        }

        public Spaceship GetSpaceship()
        {
            // TODO
            return null;
        }

        public void SetSpaceship(Spaceship spaceship)
        {
            // TODO
        }

        public void Update(GameTime gameTime)
        {
            // TODO
        }
    }
}
