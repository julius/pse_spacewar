using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using EtherDuels;

namespace EtherDuels.Game.Model
{
    abstract class Physics
    {
        private CollisionHandler collisionHandler;
        private World world;

        abstract public void Update(GameTime gameTime);
    }
}
