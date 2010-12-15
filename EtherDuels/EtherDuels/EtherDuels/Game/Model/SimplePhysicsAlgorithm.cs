using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace EtherDuels.Game.Model
{
    class SimplePhysicsAlgorithm : Physics
    {
        private CollisionHandler collisionHandler;
        private World world;

        public override void Update(GameTime gameTime)
        {
            WorldObject[] objects = world.GetWorldObjects();

            foreach (WorldObject worldObject in objects)
            {
            }
        }

    }
}
