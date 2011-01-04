using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
//using EtherDuels;

namespace EtherDuels.Game.Model
{
    public abstract class Physics
    {
        // TODO handle never used warning. (for example, try a constructor.. not sure what the right solution is)
        private CollisionHandler collisionHandler;
        private World world;

        abstract public void Update(FrameState frameState);
    }
}
